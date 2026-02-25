#define DEBUG
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTK;

public partial class QLTK : Form
{
    // ─── Inner class ───────────────────────────────────────────────────────────
    public class ItemDisplay
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    // ─── Non-UI fields ─────────────────────────────────────────────────────────
    private Socket_Server _socketServer;
    private AccountManager _accountManager;
    private GameProcessManager _processManager;

    private ConcurrentDictionary<string, string> _accountData = new();
    private ConcurrentDictionary<string, bool> _keepAliveState = new();
    private ConcurrentDictionary<string, DateTime> _lastActiveTime = new();
    private ConcurrentDictionary<string, System.Threading.CancellationTokenSource> _reconnectTasks = new();

    private bool _isLoadingSettings = false;
    private AccountSettings _clipboardSettings = null;

    private static string angelPath = "AngelPro.jar";
    private static string gamePath = "project246.jar";
    private static string javaExecutable = "javaw.exe";
    private static string serverPort = "9999";

    private Timer _refreshTimer;
    private bool _needRefresh = false;
    private readonly object _refreshLock = new object();

    private Timer _minHpDebounceTimer; // ← Thêm timer debounce

    private static int width;
    private static int height;

    // ─── Constructor ───────────────────────────────────────────────────────────
    public QLTK()
    {
        InitializeComponent();

        _socketServer = new Socket_Server();
        _socketServer.OnMessageReceived += Socket_server_OnMessageReceived;
        _socketServer.OnClientDisconnected += Socket_server_OnClientDisconnected;
        _socketServer.Start();

        _accountManager = new AccountManager();
        _processManager = new GameProcessManager();

        _refreshTimer = new Timer();
        _refreshTimer.Interval = 1500;
        _refreshTimer.Tick += RefreshTimer_Tick;
        _refreshTimer.Start();

        _minHpDebounceTimer = new Timer();
        _minHpDebounceTimer.Interval = 500;
        _minHpDebounceTimer.Tick += (s, e) =>
        {
            _minHpDebounceTimer.Stop();
            Account acc = GetCurrentAccount();
            if (acc != null)
            {
                string hp = string.IsNullOrWhiteSpace(minHp.Text) ? "100000000" : minHp.Text;
                _socketServer.SendString(acc.ID.ToString(), $"18|{hp}");
            }
        };
    }

    // ─── Timer ─────────────────────────────────────────────────────────────────
    private void RefreshTimer_Tick(object sender, EventArgs e)
    {
        lock (_refreshLock)
        {
            if (_needRefresh)
            {
                dataGridView1.Refresh();
                _needRefresh = false;
            }
        }

        DateTime now = DateTime.Now;
        foreach (KeyValuePair<string, bool> item in _keepAliveState)
        {
            string key = item.Key;
            if (item.Value
                && _lastActiveTime.TryGetValue(key, out var value)
                && (now - value).TotalMinutes >= 5.0)
            {
                _lastActiveTime[key] = now;
                Debug.WriteLine("Acc " + key + " treo 5p -> Kill để tự mở lại.");
                _processManager.KillProcess(key);
            }
        }
    }

    // ─── Socket callbacks ──────────────────────────────────────────────────────
    private async void Socket_server_OnMessageReceived(string accountID, string msg)
    {
        if (base.InvokeRequired)
            BeginInvoke((Action)async delegate { await HandleClientMessageAsync(accountID, msg); });
        else
            await HandleClientMessageAsync(accountID, msg);
    }

    private void Socket_server_OnClientDisconnected(string accountID)
    {
        if (base.InvokeRequired)
            BeginInvoke((Action)async delegate { await HandleClientDisconnectAsync(accountID); });
        else
            HandleClientDisconnectAsync(accountID);
    }

    // ─── Handle messages ───────────────────────────────────────────────────────
    private async Task HandleClientMessageAsync(string accountID, string msg)
    {
        Account acc = _accountManager.GetAccount(accountID);
        if (acc == null) return;

        try
        {
            string[] parts = msg.Split(new char[] { ':' }, 2);
            if (parts.Length < 2) return;

            string key = parts[0];
            string value = parts[1];

            switch (key)
            {
                case "CHAR_NAME":
                    {
                        bool needSave = false;
                        if (acc.CharName == null || acc.CharName != value) { acc.CharName = value; needSave = true; }
                        if (acc.Status != "ON") { acc.Status = "ON"; needSave = true; }
                        if (needSave)
                        {
                            await Task.Run(() => _accountManager.SaveAccounts());
                            _needRefresh = true;
                        }
                        await Task.Delay(500);
                        ResendActiveSettings(acc);
                        break;
                    }
                case "INFO":
                    {
                        string currentTime = DateTime.Now.ToString("HH:mm:ss");
                        string textToShow = "[ Cập nhật lúc: " + currentTime + " ]\r\n"
                                            + value.Replace("\n", "\r\n");
                        _accountData[accountID] = textToShow;
                        _lastActiveTime[accountID] = DateTime.Now;

                        Account currentAcc = GetCurrentAccount();
                        if (currentAcc != null && currentAcc.ID == acc.ID)
                            infomation.Text = textToShow;
                        break;
                    }
                case "OUT":
                    _keepAliveState[acc.ID.ToString()] = false;
                    break;

                case "KILL":
                    await Task.Run(() => _processManager.KillProcess(acc.ID.ToString()));
                    break;

                case "GAME_STATE":
                    acc.DataInGame = value;
                    _needRefresh = true;
                    break;

                case "SHOW_BAG":
                    try
                    {
                        var listItems = new List<ItemDisplay>();
                        foreach (string row in value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            string[] data = row.Split(',');
                            if (data.Length >= 3
                                && short.TryParse(data[0], out var id)
                                && int.TryParse(data[2], out var qty))
                            {
                                listItems.Add(new ItemDisplay { Id = id, Name = data[1], Quantity = qty });
                            }
                        }
                        listItems.Sort((x, y) => x.Id.CompareTo(y.Id));

                        if (base.IsHandleCreated)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                var frm = new FrmHanhTrang();
                                frm.HienThiDuLieu(listItems);
                                frm.Show();
                            });
                        }
                    }
                    catch (Exception ex) { Debug.WriteLine("Lỗi SHOW_BAG: " + ex.Message); }
                    break;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("❌ Lỗi xử lý message từ " + accountID + ": " + ex.Message);
        }
    }

    private async Task HandleClientDisconnectAsync(string accountID)
    {
        Account acc = _accountManager.GetAccount(accountID);
        if (acc == null) return;

        await Task.Run(() => _processManager.KillProcess(accountID));

        if (_keepAliveState.ContainsKey(accountID) && _keepAliveState[accountID])
        {
            acc.Status = "Mất kết nối";
            acc.DataInGame = "Tự mở lại sau 5s...";
            _needRefresh = true;

            // Tạo CancellationToken để có thể hủy task reconnect
            var cts = new System.Threading.CancellationTokenSource();
            _reconnectTasks[accountID] = cts;

            try
            {
                await Task.Delay(5000, cts.Token);
                await LoginProcess(acc);
            }
            catch (System.Threading.Tasks.TaskCanceledException)
            {
                Debug.WriteLine($"❌ Reconnect của {accountID} đã bị hủy (user login thủ công)");
            }
            finally
            {
                _reconnectTasks.TryRemove(accountID, out _);
            }
            return;
        }

        acc.Status = "OFF";
        acc.DataInGame = "";
        _accountData.TryRemove(accountID, out _);
        _lastActiveTime.TryRemove(accountID, out _);
        _needRefresh = true;
    }

    // ─── Form events ───────────────────────────────────────────────────────────
    private void Form1_Load(object sender, EventArgs e)
    {
        // Hiển thị version trên title bar
        this.Text = $"QLTK - v{UpdateManager.Version}";

        dataGridView1.Columns["Auto"].DataPropertyName = "Auto";
        base.FormClosing += QLTK_FormClosing;
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = _accountManager.Accounts;

        _isLoadingSettings = true;
        cmbServer.SelectedIndex = 0;
        MapId.SelectedIndex = 0;
        MobTypeIndex.SelectedIndex = 0;
        QuantityGTS.SelectedIndex = 0;
        txtMatKhau.UseSystemPasswordChar = true;
        listMapMvbt.SelectedIndex = 0;
        TypeMvbt.SelectedIndex = 0;
        treoGiap.SelectedIndex = 0;
        _isLoadingSettings = false;

        dataGridView1.CellFormatting += dataGridView1_CellFormatting;

        // Load saved window size
        string sizePath = Path.Combine(Application.StartupPath, "Data", "size.txt");
        Size.Text = File.Exists(sizePath) ? (File.ReadAllText(sizePath).Trim()) : "250 x 350";

        // Center column headers
        foreach (string col in new[] { "CharName", "DataInGame", "Server", "Status", "ID", "UserName" })
        {
            if (dataGridView1.Columns.Contains(col))
            {
                dataGridView1.Columns[col].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        try
        {
            string[] parts = Size.Text.Split('x');
            if (parts.Length == 2) { width = int.Parse(parts[0].Trim()); height = int.Parse(parts[1].Trim()); }
        }
        catch { width = 250; height = 350; }

        // Kiểm tra cập nhật khi khởi động
        _ = CheckForUpdatesOnStartup();
    }

    private async Task CheckForUpdatesOnStartup()
    {
        //await Task.Delay(1000); // Đợi form load xong
        await UpdateManager.CheckForUpdatesAsync(showNoUpdateMessage: false);
    }

    private void QLTK_FormClosing(object sender, FormClosingEventArgs e)
    {
        try
        {
            _keepAliveState.Clear();
            _socketServer?.BroadcastString("999");
            foreach (Account account in _accountManager.Accounts)
            {
                try { _processManager.KillProcess(account.ID.ToString()); } catch { }
            }
            _accountManager.SaveAccounts();
            _socketServer.Stop();
        }
        catch (Exception ex) { Debug.WriteLine("Lỗi khi đóng Form: " + ex.Message); }
    }

    // ─── Account CRUD ──────────────────────────────────────────────────────────
    private async void Btn_add_Click(object sender, EventArgs e)
    {
        string username = txtTaiKhoan.Text.Trim();
        string password = txtMatKhau.Text.Trim();
        string server = (cmbServer.SelectedIndex + 1).ToString();

        if (string.IsNullOrEmpty(username)) { MessageBox.Show("Nhập tài khoản"); return; }
        if (string.IsNullOrEmpty(password)) { MessageBox.Show("Nhập mật khẩu"); return; }
        if (string.IsNullOrEmpty(server)) { MessageBox.Show("Chọn server"); return; }

        _accountManager.AddAccount(new Account
        {
            CharName = "",
            UserName = username,
            Password = password,
            Server = server,
            Status = "OFF",
            Settings = new AccountSettings()
        });
        await Task.Run(() => _accountManager.SaveAccounts());
        _needRefresh = true;
    }

    private async void btnUpdate_click(object sender, EventArgs e)
    {
        Account acc = GetCurrentAccount();
        if (acc == null) return;

        string username = txtTaiKhoan.Text.Trim();
        string password = txtMatKhau.Text.Trim();
        if (string.IsNullOrEmpty(username)) { MessageBox.Show("Nhập tài khoản v0"); return; }
        if (string.IsNullOrEmpty(password)) { MessageBox.Show("Nhập mật khẩu"); return; }

        acc.UserName = username;
        acc.Password = password;
        acc.Server = (cmbServer.SelectedIndex + 1).ToString();
        await Task.Run(() => _accountManager.SaveAccounts());
        _needRefresh = true;
    }

    private async void btnRemove_click(object sender, EventArgs e)
    {
        Account acc = GetCurrentAccount();
        if (acc == null) return;
        _accountManager.RemoveAccount(acc);
        await Task.Run(() => _accountManager.SaveAccounts());
        _needRefresh = true;
    }

    // ─── DataGridView ──────────────────────────────────────────────────────────
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        Account acc = GetCurrentAccount();
        if (acc == null) return;

        _isLoadingSettings = true;
        txtTaiKhoan.Text = acc.UserName;
        txtMatKhau.Text = acc.Password;
        cmbServer.SelectedIndex = int.Parse(acc.Server) - 1;
        InputProxy.Text = acc.Proxy;
        LoadSettingsToUI(acc);

        infomation.Text = _accountData.TryGetValue(acc.ID.ToString(), out var info) ? info : acc.Status;
        _isLoadingSettings = false;
    }

    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "Status" && e.Value != null)
        {
            bool isOn = e.Value.ToString() == "ON";
            e.CellStyle.BackColor = isOn ? System.Drawing.Color.Green : System.Drawing.Color.DarkGray;
            e.CellStyle.ForeColor = System.Drawing.Color.White;
            e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font,
                                        isOn ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
        }
    }

    private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dataGridView1.Columns[e.ColumnIndex].Name != "Auto") return;

        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        bool isChecked = (bool)dataGridView1.Rows[e.RowIndex].Cells["Auto"].Value;

        if (!int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value?.ToString(), out var accId)) return;

        Account acc = _accountManager.GetAccount(accId);
        if (acc == null) return;

        string strID = accId.ToString();
        if (isChecked) { _keepAliveState[strID] = true; _lastActiveTime[strID] = DateTime.Now; }
        else _keepAliveState[strID] = false;

        await Task.Run(() => _accountManager.SaveAccounts());
    }

    // ─── Login / Process ───────────────────────────────────────────────────────
    private async Task LoginProcess(Account acc)
    {
        string javaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jre", "bin", "java.exe");
        if (!File.Exists(javaPath))
        {
            MessageBox.Show("Không tìm thấy Java tại:\n" + javaPath + "\n\nVui lòng kiểm tra thư mục jre!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return;
        }

        string args = $"-Dfile.encoding=UTF-8 -Xms4m -Xmx18m -Xss192k -Xint -XX:+UseSerialGC "
                    + $"-XX:MinHeapFreeRatio=5 -XX:MaxHeapFreeRatio=20 "
                    + $"-Dport={serverPort} -Did={acc.ID} -Duser={acc.UserName} -Dpass={acc.Password} "
                    + $"-Dserver={acc.Server} -Dproxy={acc.Proxy} "
                    + $"-cp {angelPath};{gamePath} org.microemu.app.Main main.GameMidlet "
                    + $"--resizableDevice {width} {height} --quit";

        await Task.Run(() => _processManager.StartProcess(acc.ID.ToString(), new System.Diagnostics.ProcessStartInfo
        {
            FileName = javaPath,
            Arguments = args,
            UseShellExecute = false,
            CreateNoWindow = true,
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        }));
        acc.DataInGame = "Đang kết nối";
        _needRefresh = true;
    }

    private async void btnLogin_click(object sender, EventArgs e)
    {
        Account acc = GetCurrentAccount();
        if (acc == null) return;

        string id = acc.ID.ToString();

        // Hủy task reconnect tự động (nếu đang chờ)
        if (_reconnectTasks.TryRemove(id, out var cts))
        {
            cts.Cancel();
            cts.Dispose();
            Debug.WriteLine($"✅ Đã hủy reconnect tự động cho {id}");
        }

        // Nếu đã ON rồi thì không login nữa
        if (acc.Status == "ON")
        {
            MessageBox.Show("Tài khoản đang online!", "Thông báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _keepAliveState[id] = true;
        _lastActiveTime[id] = DateTime.Now;
        await LoginProcess(acc);
    }

    private async void RunCmd(object sender, EventArgs e)
    {
        Account acc = GetCurrentAccount();
        if (acc == null) return;
        string id = acc.ID.ToString();
        _keepAliveState[id] = true;
        _lastActiveTime[id] = DateTime.Now;

        string javaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jre", "bin", "java.exe");
        if (!File.Exists(javaPath))
        {
            MessageBox.Show("Không tìm thấy Java tại:\n" + javaPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return;
        }

        string args = $"-Dfile.encoding=UTF-8 -Xms4m -Xmx18m -Xss192k -Xint -XX:+UseSerialGC "
                    + $"-XX:MinHeapFreeRatio=5 -XX:MaxHeapFreeRatio=20 "
                    + $"-Dport={serverPort} -Did={acc.ID} -Duser={acc.UserName} -Dpass={acc.Password} "
                    + $"-Dserver={acc.Server} -Dproxy={acc.Proxy} "
                    + $"-cp {angelPath};{gamePath} org.microemu.app.Main main.GameMidlet "
                    + $"--resizableDevice {width} {height} --headless --quit";

        await Task.Run(() => _processManager.StartProcess(acc.ID.ToString(), new System.Diagnostics.ProcessStartInfo
        {
            FileName = javaPath,
            Arguments = args,
            UseShellExecute = false,
            CreateNoWindow = true,
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        }));
        acc.DataInGame = "Đang kết nối";
        _needRefresh = true;
    }

    // ─── Settings load / save ──────────────────────────────────────────────────
    private void LoadSettingsToUI(Account acc)
    {
        _isLoadingSettings = true;

        // ✅ TỰ ĐỘNG load tất cả settings lên UI
        acc.Settings.LoadToUI(this);

        // Special handling cho MapId (vì cần SelectMapInListBox)
        SelectMapInListBox(acc.Settings.MapId);

        _isLoadingSettings = false;
    }

    private async Task SaveUIToSettingsAsync(Account acc)
    {
        if (acc == null) return;

        // ✅ TỰ ĐỘNG save tất cả UI controls vào settings
        acc.Settings.SaveFromUI(this);

        // Special handling cho MapId (parse từ ComboBox text)
        acc.Settings.MapId = int.Parse(MapId.SelectedItem.ToString().Split('.')[0].Trim());

        await Task.Run(() => _accountManager.SaveAccounts());
    }

    // ─── Resend settings after reconnect ──────────────────────────────────────
    private void ResendActiveSettings(Account acc)
    {
        if (acc == null) return;
        AccountSettings s = acc.Settings;
        string id = acc.ID.ToString();

        // Simple boolean settings (flag → command)
        var simpleSettings = new (bool flag, Func<string> buildCmd)[]
        {
            (s.UpMapPrivate, Constants.BuildAutoUpMapPrivate),
            (s.UseCuongNo, Constants.BuildCuongNoCommand),
            (s.UseBoHuyet, Constants.BuildBoHuyetCommand),
            (s.UseGiapXen, Constants.BuildGiapXenCommand),
            (s.UseKhauTrang, Constants.BuildKhauTrangCommand),
            (s.UseCanCo, Constants.BuildCanCoCommand),
            (s.AutoPorata, Constants.BuildAutoPorata),
            (s.AutoLogin, Constants.BuildAutoLogin),
            (s.SKH, Constants.BuildAutoSKH),
            (s.AttackFull, Constants.BuildAttackFull),
            (s.AutoFlag, Constants.BuildAutoFlag),
            (s.AutoGB, Constants.BuildAutoGB),
            (s.TrainNotMove, Constants.BuildTrainDontMove),
            (s.AutoBuyTDLT, Constants.BuildAutoBuyTDLT)
        };

        foreach (var (flag, buildCmd) in simpleSettings)
        {
            if (flag) _socketServer.SendString(id, buildCmd());
        }

        // AutoUseGiapLT (special case: sends command for both on/off states)
        _socketServer.SendString(id, s.AutoUseGiapLT ? "15" : "16");

        // Complex settings with parameters
        if (s.AutoTrainEnabled) 
            _socketServer.SendString(id, Constants.BuildAutoTrainFull(s.MapId, s.MobTypeIndex));

        if (s.AutoZoneEnabled) 
            _socketServer.SendString(id, Constants.BuildSetZoneId(s.Zone));

        if (s.AutoBossNapa)
            _socketServer.SendString(id, Constants.BuildAutoBossNapa(s.QuantityGTS == 0 ? 40 : 80, s.FarmReverseGTS ? 1 : 0));

        if (s.UseHpThreshold) 
            _socketServer.SendString(id, Constants.BuildSetMaxHp(s.HpThreshold));

        if (s.checkMinHp)
        {
            string hp = string.IsNullOrWhiteSpace(s.minHp) ? "100000000" : s.minHp;
            _socketServer.SendString(id, $"18|{hp}");
        }

        // Text-based settings
        if (!string.IsNullOrWhiteSpace(s.SkillsText))
            _socketServer.SendString(id, Constants.BuildHandleSkill(string.Join("|", s.SkillsText.Split(','))));

        if (!string.IsNullOrWhiteSpace(s.IDSL))
            _socketServer.SendString(id, Constants.BuildHandleIDSL(string.Join("|", s.IDSL.Split('-'))));

        if (!string.IsNullOrEmpty(s.ListIDItems))
            _socketServer.SendString(id, Constants.BuildListIDItems(string.Join("|", s.ListIDItems.Split(','))));

        if (!string.IsNullOrEmpty(s.TrashItemIds))
            _socketServer.SendString(id, Constants.BuildTrashItemIds(string.Join("|", s.TrashItemIds.Split(','))));

        if (!string.IsNullOrEmpty(s.ListIDMob))
            _socketServer.SendString(id, Constants.BuildListIDMob(string.Join("|", s.ListIDMob.Split(','))));
    }

    // ─── Helper methods ────────────────────────────────────────────────────────
    private Account GetCurrentAccount()
    {
        if (dataGridView1.CurrentRow == null) return null;
        var cell = dataGridView1.CurrentRow.Cells["ID"];
        if (cell?.Value == null) return null;
        if (!int.TryParse(cell.Value.ToString(), out var id)) return null;
        return _accountManager?.GetAccount(id);
    }

    private void SelectMapInListBox(int mapId)
    {
        string prefix = mapId + ".";
        for (int i = 0; i < MapId.Items.Count; i++)
        {
            if (MapId.Items[i].ToString().StartsWith(prefix)) { MapId.SelectedIndex = i; return; }
        }
        if (MapId.Items.Count > 0) MapId.SelectedIndex = 0;
    }

    private async Task<bool> SendCommandAsync(string command, bool saveSettings = false)
    {
        if (_isLoadingSettings) return false;
        Account acc = GetCurrentAccount();
        if (acc == null) return false;
        if (saveSettings) await SaveUIToSettingsAsync(acc);
        _socketServer.SendString(acc.ID.ToString(), command);
        return true;
    }

    private AccountSettings CloneSettings(AccountSettings src)
    {
        // ✅ TỰ ĐỘNG clone tất cả properties
        return src.Clone();
    }

    // ─── Event handlers – Train / Zone ─────────────────────────────────────────
    private async void checkBoxAutoTrain_CheckedChanged(object sender, EventArgs e)
    {
        int idMap = int.Parse(MapId.SelectedItem.ToString().Split('.')[0].Trim());
        int mobType = MobTypeIndex.SelectedIndex;
        string cmd = AutoTrainEnabled.Checked ? $"2|{idMap}|{mobType}" : "3";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void checkBox8_CheckedChanged(object sender, EventArgs e)
    {
        string cmd = AutoZoneEnabled.Checked ? $"7|{Zone.Value}" : "8";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void Zone_ValueChanged(object sender, EventArgs e)
    {
        if (AutoZoneEnabled.Checked)
            await SendCommandAsync($"7|{Zone.Value}");
    }

    // ─── Event handlers – Buffs ────────────────────────────────────────────────
    private async void OnBuffSettingChanged(object sender, EventArgs e)
    {
        CheckBox cb = sender as CheckBox;
        if (cb?.Tag == null || string.IsNullOrEmpty(cb.Tag.ToString())) return;

        string tag = cb.Tag.ToString();
        string cmd;
        if (cb.Checked)
        {
            cmd = $"9|{tag}";
        }
        else
        {
            string[] parts = tag.Split('|');
            if (parts.Length <= 1) return;
            cmd = Constants.BuildStopAutoItem(int.Parse(parts[1]));
        }
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void Skill(object sender, EventArgs e)
    {
        string cmd = $"11|{string.Join("|", SkillsText.Text.Split(','))}";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void checkHp_CheckedChanged(object sender, EventArgs e)
    {
        string maxhp = string.IsNullOrWhiteSpace(HpThreshold.Text) ? "0" : HpThreshold.Text;
        string cmd = UseHpThreshold.Checked ? $"17|{maxhp}" : "17|0";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void maxHp_TextChanged(object sender, EventArgs e)
    {
        if (UseHpThreshold.Checked)
        {
            string maxhp = string.IsNullOrWhiteSpace(HpThreshold.Text) ? "0" : HpThreshold.Text;
            await SendCommandAsync($"17|{maxhp}");
        }
    }

    private void textBox1_TextChanged_1(object sender, EventArgs e)
    {
        if (_isLoadingSettings) return;
        if (GetCurrentAccount() == null) return;
        if (!checkMinHp.Checked) return; // ✅ Chỉ gửi khi checkbox được tích

        Account acc = GetCurrentAccount();
        if (acc != null)
        {
            string hp = string.IsNullOrWhiteSpace(minHp.Text) ? "100000000" : minHp.Text;
            _socketServer.SendString(acc.ID.ToString(), $"18|{hp}");
        }
    }

    private async void checkMinHp_CheckedChanged(object sender, EventArgs e)
    {
        if (_isLoadingSettings) return;
        if (GetCurrentAccount() == null) return;

        string hp = string.IsNullOrWhiteSpace(minHp.Text) ? "100000000" : minHp.Text;
        string cmd = checkMinHp.Checked ? $"18|{hp}" : "18|100000000"; // ← Tắt = 0, không phải MaxValue

        await SendCommandAsync(cmd, saveSettings: true); // ← Theo chuẩn
    }

    // ─── Event handlers – Misc checkboxes ─────────────────────────────────────
    private async void checkBox1_CheckedChanged(object sender, EventArgs e)   // AutoUseGiapLT
    {
        string cmd = AutoUseGiapLT.Checked ? "15" : "16";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void checkBox1_CheckedChanged_1(object sender, EventArgs e) // TrainNotMove
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }
        string cmd = TrainNotMove.Checked ? Constants.BuildTrainDontMove() : Constants.BuildTrainDontMove() + "|0";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void checkBox1_CheckedChanged_2(object sender, EventArgs e) // SKH
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }
        string cmd = SKH.Checked ? Constants.BuildAutoSKH() : Constants.BuildAutoSKH() + "|0";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void checkBox1_CheckedChanged_3(object sender, EventArgs e) // AutoFlag
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }
        string cmd = AutoFlag.Checked ? Constants.BuildAutoFlag() : Constants.BuildAutoFlag() + "|0";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void checkBox1_CheckedChanged_4(object sender, EventArgs e) // UpMapPrivate
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }
        string cmd = UpMapPrivate.Checked ? Constants.BuildAutoUpMapPrivate() : Constants.BuildAutoUpMapPrivate() + "|0";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void checkBox1_CheckedChanged_5(object sender, EventArgs e) // AttackFull
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }
        string cmd = AttackFull.Checked ? Constants.BuildAttackFull() : Constants.BuildAttackFull() + "|0";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void Fushion_CheckedChanged(object sender, EventArgs e)     // AutoPorata
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }
        string cmd = AutoPorata.Checked ? Constants.BuildAutoPorata() : Constants.BuildAutoPorata() + "|0";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void checkBox3_CheckedChanged(object sender, EventArgs e)   // AutoLogin
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }
        string cmd = AutoLogin.Checked ? Constants.BuildAutoLogin() : Constants.BuildAutoLogin() + "|0";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void AutoBuyTDLTzz(object sender, EventArgs e)              // AutoBuyTDLT
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }
        string cmd = AutoBuyTDLT.Checked ? Constants.BuildAutoBuyTDLT() : Constants.BuildAutoBuyTDLT() + "|0";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void AutoGB_CheckedChanged(object sender, EventArgs e)      // AutoGB
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }
        string cmd = AutoGB.Checked ? Constants.BuildAutoGB() : Constants.BuildAutoGB() + "|0";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    // ─── Event handlers – Buttons ──────────────────────────────────────────────
    private void button6_Click(object sender, EventArgs e) => _processManager.ArrangeAllWindows();
    private void button3_Click(object sender, EventArgs e) => _processManager.MinimizeAll();
    private void button10_Click(object sender, EventArgs e) => _processManager.RestoreAll();

    private async void CloseALl(object sender, EventArgs e)
    {
        // Hủy tất cả task reconnect đang chờ
        foreach (var kvp in _reconnectTasks.ToList())
        {
            if (_reconnectTasks.TryRemove(kvp.Key, out var cts))
            {
                cts.Cancel();
                cts.Dispose();
                Debug.WriteLine($"✅ Đã hủy reconnect tự động cho {kvp.Key}");
            }
        }

        // Tắt tất cả và reset DataInGame
        foreach (var item in _keepAliveState)
        {
            _keepAliveState[item.Key] = false;

            var acc = _accountManager.GetAccount(item.Key);
            if (acc != null)
            {
                acc.DataInGame = "";  // ← Reset DataInGame về rỗng
            }
        }

        _needRefresh = true;
        _socketServer.BroadcastString("999");
        await Task.Delay(500);
        await Task.Run(() => _accountManager.SaveAccounts());
    }

    private async void button7_Click(object sender, EventArgs e)
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }

        Account acc = GetCurrentAccount();
        string id = acc.ID.ToString();

        // Hủy task reconnect tự động (nếu đang chờ)
        if (_reconnectTasks.TryRemove(id, out var cts))
        {
            cts.Cancel();
            cts.Dispose();
            Debug.WriteLine($"✅ Đã hủy reconnect tự động cho {id}");
        }

        _keepAliveState[id] = false;
        acc.DataInGame = "";  // ← Reset DataInGame về rỗng
        _needRefresh = true;

        await SendCommandAsync("999");
    }

    private async void SaveFarmBoss_Click(object sender, EventArgs e)
    {
        string qty = QuantityGTS.SelectedItem.ToString();
        string rev = FarmReverseGTS.Checked ? "1" : "0";
        string cmd = AutoBossNapa.Checked ? $"13|{qty}|{rev}" : "14";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private void SaveSize_Click(object sender, EventArgs e)
    {
        try
        {
            string[] parts = Size.Text.Split('x');
            if (parts.Length == 2) { width = int.Parse(parts[0].Trim()); height = int.Parse(parts[1].Trim()); }
            string dir = Path.Combine(Application.StartupPath, "Data");
            Directory.CreateDirectory(dir);
            File.WriteAllText(Path.Combine(dir, "size.txt"), Size.Text);
            MessageBox.Show("Lưu thành công!");
        }
        catch { width = 250; height = 350; }
    }

    private void SaveProxy_Click(object sender, EventArgs e)
    {
        Account acc = GetCurrentAccount();
        if (acc == null) { MessageBox.Show("Vui lòng chọn tài khoản để lưu Proxy!"); return; }
        acc.Proxy = InputProxy.Text.Trim();
        _accountManager.UpdateAccount(acc);
        MessageBox.Show("Đã lưu Proxy cho tài khoản " + acc.UserName + ": " + acc.Proxy);
    }

    private async void checkProxy(object sender, EventArgs e)
    {
        Account acc = GetCurrentAccount();
        if (acc == null) { MessageBox.Show("Vui lòng chọn tài khoản để check Proxy!"); return; }
        if (string.IsNullOrEmpty(acc.Proxy)) { MessageBox.Show("Tài khoản này chưa có Proxy!"); return; }

        Button btn = sender as Button;
        if (btn != null) { btn.Enabled = false; btn.Text = "Đang check..."; }

        try
        {
            string[] parts = acc.Proxy.Split(':');
            if (parts.Length < 2) throw new Exception("Định dạng Proxy sai (Yêu cầu IP:PORT hoặc IP:PORT:USER:PASS)");

            string ip = parts[0];
            if (!int.TryParse(parts[1], out int port)) throw new Exception("Port không hợp lệ");
            string user = parts.Length >= 4 ? parts[2] : "";
            string pass = parts.Length >= 4 ? parts[3] : "";

            var proxy = new WebProxy(ip, port);
            if (!string.IsNullOrEmpty(user)) proxy.Credentials = new NetworkCredential(user, pass);

            using var client = new HttpClient(new HttpClientHandler
            {
                Proxy = proxy,
                UseProxy = true,
                ServerCertificateCustomValidationCallback = (_, _, _, _) => true
            })
            { Timeout = TimeSpan.FromSeconds(5) };

            var response = await client.GetAsync("https://www.google.com");
            if (response.IsSuccessStatusCode)
                MessageBox.Show("Proxy LIVE!\nIP: " + ip, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
                MessageBox.Show($"Proxy Die! Code: {response.StatusCode}", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        catch (TaskCanceledException)
        {
            MessageBox.Show("Proxy Die! (Timeout)", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi Check Proxy:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        finally
        {
            if (btn != null) { btn.Enabled = true; btn.Text = "Check Proxy"; }
        }
    }

    private async void button15_Click(object sender, EventArgs e)   // SaveListItems
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }
        string cmd = Constants.BuildListIDItems(string.Join("|", ListIDItems.Text.Split(',')));
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void TrashItemIdszz(object sender, EventArgs e)
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }
        string cmd = Constants.BuildTrashItemIds(string.Join("|", TrashItemIds.Text.Split(',')));
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void button15_Click_1(object sender, EventArgs e) => await SendCommandAsync("27"); // Hành trang
    private async void button19_Click(object sender, EventArgs e) => await SendCommandAsync("28"); // Rương đồ

    private async void SaveListIDMob_Click(object sender, EventArgs e)
    {
        string list = string.Join("|", ListIDMob.Text.Split(','));
        MessageBox.Show(list);
        await SendCommandAsync($"29|{list}", saveSettings: true);
    }

    private async void SaveIDSL_Click(object sender, EventArgs e)
    {
        string cmd = $"37|{string.Join("|", IDSL.Text.Trim().Split('-'))}";
        await SendCommandAsync(cmd, saveSettings: true);
    }

    private async void button20_Click(object sender, EventArgs e)
    {
        if (GetCurrentAccount() == null) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }
        await SendCommandAsync("99|" + MobLoaiTru.Text);
    }

    // ─── Copy / Paste Config ───────────────────────────────────────────────────
    private void btnCopyConfig_Click(object sender, EventArgs e)
    {
        Account acc = GetCurrentAccount();
        if (acc == null) { MessageBox.Show("Vui lòng chọn tài khoản cần Copy!"); return; }
        _clipboardSettings = CloneSettings(acc.Settings);
        MessageBox.Show("Đã copy cấu hình của: " + acc.UserName);
    }

    private async void btnPasteConfig_Click(object sender, EventArgs e)
    {
        if (_clipboardSettings == null) { MessageBox.Show("Chưa có cấu hình nào được Copy!"); return; }
        Account acc = GetCurrentAccount();
        if (acc == null) { MessageBox.Show("Vui lòng chọn một tài khoản để dán!"); return; }

        if (MessageBox.Show("Dán cấu hình cho: " + acc.UserName + "?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

        acc.Settings = CloneSettings(_clipboardSettings);
        await Task.Run(() => _accountManager.SaveAccounts());
        LoadSettingsToUI(acc);
    }

    private async void button13_Click(object sender, EventArgs e)
    {
        if (_clipboardSettings == null)
        {
            MessageBox.Show("Chưa có cấu hình nào được Copy! Vui lòng chọn 1 acc rồi bấm 'Copy ConFig' trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        if (MessageBox.Show("Bạn có chắc chắn muốn áp dụng cấu hình cho TẤT CẢ tài khoản không?\n\nHành động này không thể hoàn tác!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes) return;

        var allAccounts = _accountManager.Accounts.ToList();
        foreach (var acc in allAccounts) acc.Settings = CloneSettings(_clipboardSettings);

        await Task.Run(() => _accountManager.SaveAccounts());
        Account current = GetCurrentAccount();
        if (current != null) LoadSettingsToUI(current);
        MessageBox.Show($"Đã dán cấu hình thành công cho {allAccounts.Count} tài khoản!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    // ─── Bulk Auto / Import ────────────────────────────────────────────────────
    private async void button22_Click(object sender, EventArgs e)
    {
        foreach (var acc in _accountManager.Accounts.ToList()) acc.Auto = true;
        dataGridView1.Refresh();
        await Task.Run(() => _accountManager.SaveAccounts());
    }

    private async void button24_Click(object sender, EventArgs e)
    {
        foreach (var acc in _accountManager.Accounts.ToList()) acc.Auto = false;
        dataGridView1.Refresh();
        await Task.Run(() => _accountManager.SaveAccounts());
    }

    private async void button23_Click(object sender, EventArgs e)
    {
        int limit = (int)numThread.Value;
        if (limit < 1) { MessageBox.Show("Nhập số luồng đi bấm củ cải :>"); return; }

        var toRun = new List<Account>();
        foreach (DataGridViewRow row in (IEnumerable)dataGridView1.Rows)
        {
            var autoCell = row.Cells["Auto"];
            if (autoCell.Value != null && (bool)autoCell.Value
                && int.TryParse(row.Cells["ID"].Value?.ToString(), out var id))
            {
                var acc = _accountManager.GetAccount(id);
                if (acc != null && acc.Status != "ON") toRun.Add(acc);
            }
        }

        if (toRun.Count == 0) { MessageBox.Show("Chưa có tài khoản nào được chọn Auto hoặc tất cả đã Online!"); return; }
        if (toRun.Count > limit) toRun = toRun.Take(limit).ToList();

        foreach (var acc in toRun)
        {
            string id = acc.ID.ToString();
            _keepAliveState[id] = true; _lastActiveTime[id] = DateTime.Now;
            await LoginProcess(acc);
            await Task.Delay(1000);
        }
        await Task.Delay(2000);
        _processManager.ArrangeAllWindows();
    }

    private async void btnImport_Click(object sender, EventArgs e)
    {
        var ofd = new OpenFileDialog { Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*", Title = "Chọn file chứa danh sách tài khoản (User|Pass|Server)" };
        if (ofd.ShowDialog() != DialogResult.OK) return;

        try
        {
            int count = 0;
            foreach (string line in File.ReadAllLines(ofd.FileName))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] p = line.Split('|');
                if (p.Length < 3) continue;
                _accountManager.AddAccount(new Account
                {
                    UserName = p[0].Trim(),
                    Password = p[1].Trim(),
                    Server = p[2].Trim(),
                    Proxy = p.Length >= 4 ? p[3].Trim() : "",
                    Status = "OFF",
                    Auto = false,
                    Settings = new AccountSettings(),
                    CharName = ""
                });
                count++;
            }
            await Task.Run(() => _accountManager.SaveAccounts());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _accountManager.Accounts;
            _needRefresh = true;
            MessageBox.Show($"Đã nhập thành công {count} tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        catch (Exception ex) { MessageBox.Show("Có lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
    }

    // ─── Help dialog ───────────────────────────────────────────────────────────
    private void button21_Click(object sender, EventArgs e)
    {
        MessageBox.Show("HƯỚNG DẪN CHỨC NĂNG ID - SỐ LƯỢNG:\n\n- Điền ID vật phẩm và số lượng cần đạt.\n- Khi số lượng vật phẩm đạt đủ, nhân vật sẽ tự động thoát.\n- Nếu để trống ID hoặc số lượng, hệ thống sẽ không thực hiện hành động gì.\n",
            "Hướng dẫn ID - SL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    // ─── Empty / stub handlers ─────────────────────────────────────────────────
    private void cmbServer_SelectedIndexChanged(object sender, EventArgs e) { }
    private void checkBoxGTS_CheckedChanged(object sender, EventArgs e) { }
    private void checkBoxUpMvbt_CheckedChanged(object sender, EventArgs e) { }
    private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
    private void numericUpDown4_ValueChanged(object sender, EventArgs e) { }
    private void listMapMvbt_SelectedIndexChanged(object sender, EventArgs e) { }
    private void button1_Click(object sender, EventArgs e) { }
    private void Gold_Click(object sender, EventArgs e) { }
    private void GangTS_SelectedIndexChanged(object sender, EventArgs e) { }
    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) { }
    private void tabControl2_SelectedIndexChanged(object sender, EventArgs e) { }
    private void tabPage1_Click(object sender, EventArgs e) { }
    private void tabPage2_Click(object sender, EventArgs e) { }
    private void tabPage3_Click(object sender, EventArgs e) { }
    private void tabPage4_Click(object sender, EventArgs e) { }
    private void tabPage7_Click(object sender, EventArgs e) { }
    private void ViewGTS_Click(object sender, EventArgs e) { }
    private void viewMGTS_TextChanged(object sender, EventArgs e) { }
    private void groupBox1_Enter(object sender, EventArgs e) { }
    private void groupBox2_Enter(object sender, EventArgs e) { }
    private void groupBox3_Enter(object sender, EventArgs e) { }
    private void groupBox4_Enter(object sender, EventArgs e) { }
    private void listItem_Enter(object sender, EventArgs e) { }
    private void hide_CheckedChanged(object sender, EventArgs e) { }
    private void infomation_TextChanged(object sender, EventArgs e) { }
    private void textBox1_TextChanged(object sender, EventArgs e) { }
    private void label1_Click(object sender, EventArgs e) { }
    private void label2_Click(object sender, EventArgs e) { }
    private void label3_Click(object sender, EventArgs e) { }
    private void label4_Click(object sender, EventArgs e) { }
    private void label5_Click(object sender, EventArgs e) { }
    private void label6_Click(object sender, EventArgs e) { }
    private void label6_Click_1(object sender, EventArgs e) { }
    private void label7_Click(object sender, EventArgs e) { }
    private void label8_Click(object sender, EventArgs e) { }
    private void label11_Click(object sender, EventArgs e) { }
    private void label12_Click(object sender, EventArgs e) { }
    private void label13_Click(object sender, EventArgs e) { }
    private void label18_Click(object sender, EventArgs e) { }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    private void txtTaiKhoan_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
    private void txtMatKhau_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }

    private void SaveTimeNextMap_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TimeNextMap.Text))
        {
            MessageBox.Show("Vui lòng nhập số giây!");
            return;
        }

        if (!int.TryParse(TimeNextMap.Text, out int seconds))
        {
            MessageBox.Show("Số giây không hợp lệ!");
            return;
        }

        _socketServer.BroadcastString($"888|{seconds}");
    }
}