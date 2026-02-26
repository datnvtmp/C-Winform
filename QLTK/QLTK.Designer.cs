using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QLTK;

partial class QLTK
{
    // ─── Designer-managed fields ───────────────────────────────────────────────
    private IContainer components = null;

    private Label label1;
    private Label label2;
    private MaskedTextBox txtTaiKhoan;
    private Button btnThem;
    private Button button2;
    private Button button4;
    private MaskedTextBox txtMatKhau;
    private Label label3;
    private ComboBox cmbServer;
    private Button button5;
    private DataGridView dataGridView1;
    private GroupBox groupBox1;
    private Button button6;
    private Button button7;
    private TabControl tabControl2;
    private TabPage tabPage2;
    private TabPage tabPage7;
    private TextBox infomation;
    private Button button9;
    private Button button3;
    private Button button10;
    private new TextBox Size;
    private Button SaveSize;
    private Button button19;
    private Button button15;
    private TabPage Gold;
    private Button button20;
    private Label label19;
    private TextBox MobLoaiTru;
    private TabPage ConFig;
    private Button button17;
    private MaskedTextBox maskedTextBox1;
    private Label label14;
    private Button button16;
    private Button SaveProxy;
    private Label label10;
    private MaskedTextBox InputProxy;
    private Button button13;
    private Button button12;
    private Button button11;
    private TabPage ViewGTS;
    private Button SaveFarmBoss;
    private CheckBox FarmReverseGTS;
    private CheckBox AutoBossNapa;
    private ComboBox QuantityGTS;
    private TabPage tabPage3;
    private GroupBox groupBox4;
    private Label label15;
    private CheckBox checkBox6;
    private Button button1;
    private NumericUpDown numericUpDown3;
    private ComboBox treoGiap;
    private RadioButton radioButton3;
    private RadioButton radioButton2;
    private RadioButton radioButton1;
    private CheckBox checkBox5;
    private Label label9;
    private NumericUpDown numericUpDown2;
    private Label label8;
    private ComboBox TypeMvbt;
    private Label label6;
    private NumericUpDown numericUpDown1;
    private CheckBox checkBoxUpMvbt;
    private Label label4;
    private ComboBox listMapMvbt;
    private TabPage tabPage1;
    private GroupBox groupBox3;
    private CheckBox AttackFull;
    private CheckBox UpMapPrivate;
    private CheckBox AutoGB;
    private CheckBox AutoFlag;
    private CheckBox SKH;
    private CheckBox TrainNotMove;
    private CheckBox AutoPorata;
    private CheckBox AutoLogin;
    private CheckBox AutoBuyTDLT;
    private CheckBox AutoUseGiapLT;
    private GroupBox listItem;
    private Button button18;
    private TextBox TrashItemIds;
    private Label label16;
    private Label label13;
    private Button SaveListItems;
    private TextBox ListIDItems;
    private CheckBox UseCanCo;
    private CheckBox UseGiapXen;
    private CheckBox UseBoHuyet;
    private CheckBox UseKhauTrang;
    private CheckBox UseCuongNo;
    private GroupBox groupBox2;
    private TextBox character;
    private CheckBox nechar;
    private Button button21;
    private Button SaveIDSL;
    private Label label18;
    private TextBox IDSL;
    private Button SaveListIDMob;
    private Label label17;
    private TextBox ListIDMob;
    private CheckBox checkMinHp;
    private TextBox minHp;
    private CheckBox UseHpThreshold;
    private TextBox HpThreshold;
    private Button button8;
    private TextBox SkillsText;
    private Label label7;
    private ComboBox MobTypeIndex;
    private Label label5;
    private CheckBox AutoZoneEnabled;
    private CheckBox AutoTrainEnabled;
    private Label label12;
    private ComboBox MapId;
    private Label label11;
    private NumericUpDown Zone;
    private TabControl KSGold;
    private NumericUpDown numThread;
    private Button button23;
    private DataGridViewTextBoxColumn ID;
    private DataGridViewTextBoxColumn CharName;
    private DataGridViewTextBoxColumn DataInGame;
    private DataGridViewTextBoxColumn UserName;
    private DataGridViewTextBoxColumn Password;
    private DataGridViewTextBoxColumn Settings;
    private DataGridViewTextBoxColumn Server;
    private DataGridViewTextBoxColumn Status;
    private DataGridViewCheckBoxColumn Auto;
    private Label label20;
    private Button button24;
    private Button button22;
    private Button btnImport;
    private Button button14;

    // ─── Dispose ───────────────────────────────────────────────────────────────
    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    // ─── InitializeComponent ───────────────────────────────────────────────────
    private void InitializeComponent()
    {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.MaskedTextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtMatKhau = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CharName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataInGame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Settings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Server = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Auto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.numThread = new System.Windows.Forms.NumericUpDown();
            this.button23 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.SaveSize = new System.Windows.Forms.Button();
            this.Size = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button19 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.infomation = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.SaveIDSL = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.Gold = new System.Windows.Forms.TabPage();
            this.button20 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.MobLoaiTru = new System.Windows.Forms.TextBox();
            this.ConFig = new System.Windows.Forms.TabPage();
            this.SaveTimeNextMap = new System.Windows.Forms.Button();
            this.TimeNextMap = new System.Windows.Forms.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.button17 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Button();
            this.SaveProxy = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.InputProxy = new System.Windows.Forms.MaskedTextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.ViewGTS = new System.Windows.Forms.TabPage();
            this.SaveFarmBoss = new System.Windows.Forms.Button();
            this.FarmReverseGTS = new System.Windows.Forms.CheckBox();
            this.AutoBossNapa = new System.Windows.Forms.CheckBox();
            this.QuantityGTS = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.treoGiap = new System.Windows.Forms.ComboBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.TypeMvbt = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxUpMvbt = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listMapMvbt = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AttackFull = new System.Windows.Forms.CheckBox();
            this.UpMapPrivate = new System.Windows.Forms.CheckBox();
            this.AutoGB = new System.Windows.Forms.CheckBox();
            this.AutoFlag = new System.Windows.Forms.CheckBox();
            this.SKH = new System.Windows.Forms.CheckBox();
            this.TrainNotMove = new System.Windows.Forms.CheckBox();
            this.AutoPorata = new System.Windows.Forms.CheckBox();
            this.AutoLogin = new System.Windows.Forms.CheckBox();
            this.AutoBuyTDLT = new System.Windows.Forms.CheckBox();
            this.AutoUseGiapLT = new System.Windows.Forms.CheckBox();
            this.listItem = new System.Windows.Forms.GroupBox();
            this.button18 = new System.Windows.Forms.Button();
            this.TrashItemIds = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SaveListItems = new System.Windows.Forms.Button();
            this.ListIDItems = new System.Windows.Forms.TextBox();
            this.UseCanCo = new System.Windows.Forms.CheckBox();
            this.UseGiapXen = new System.Windows.Forms.CheckBox();
            this.UseBoHuyet = new System.Windows.Forms.CheckBox();
            this.UseKhauTrang = new System.Windows.Forms.CheckBox();
            this.UseCuongNo = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.character = new System.Windows.Forms.TextBox();
            this.nechar = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.IDSL = new System.Windows.Forms.TextBox();
            this.SaveListIDMob = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.ListIDMob = new System.Windows.Forms.TextBox();
            this.checkMinHp = new System.Windows.Forms.CheckBox();
            this.minHp = new System.Windows.Forms.TextBox();
            this.UseHpThreshold = new System.Windows.Forms.CheckBox();
            this.HpThreshold = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.SkillsText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MobTypeIndex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AutoZoneEnabled = new System.Windows.Forms.CheckBox();
            this.AutoTrainEnabled = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.MapId = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Zone = new System.Windows.Forms.NumericUpDown();
            this.KSGold = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThread)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.Gold.SuspendLayout();
            this.ConFig.SuspendLayout();
            this.ViewGTS.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.listItem.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Zone)).BeginInit();
            this.KSGold.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(11, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tài khoản";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtTaiKhoan.Location = new System.Drawing.Point(100, 16);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(147, 23);
            this.txtTaiKhoan.TabIndex = 2;
            this.txtTaiKhoan.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtTaiKhoan_MaskInputRejected);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 118);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(55, 35);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.Btn_add_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnLogin_click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(129, 118);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 35);
            this.button4.TabIndex = 8;
            this.button4.Text = "Xóa";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnRemove_click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtMatKhau.Location = new System.Drawing.Point(100, 47);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(147, 23);
            this.txtMatKhau.TabIndex = 10;
            this.txtMatKhau.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtMatKhau_MaskInputRejected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(11, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Sever";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbServer
            // 
            this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Items.AddRange(new object[] {
            "Vũ Trụ 1",
            "Vũ Trụ 2",
            "Vũ Trụ 3",
            "Vũ Trụ 4",
            "Vũ Trụ 5",
            "Vũ Trụ 6",
            "Vũ Trụ 7",
            "Vũ Trụ 8",
            "Vũ Trụ 9",
            "Vũ Trụ 10",
            "Vũ Trụ 11",
            "Vũ Trụ 12",
            "Liên Vũ Trụ",
            "Universe 1",
            "Naga 1",
            "Super 1",
            "Super 2",
            "hmmm",
            "hmmm",
            "supper 3",
            "supper 3"});
            this.cmbServer.Location = new System.Drawing.Point(100, 80);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(88, 24);
            this.cmbServer.TabIndex = 13;
            this.cmbServer.SelectedIndexChanged += new System.EventHandler(this.cmbServer_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(69, 118);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(55, 35);
            this.button5.TabIndex = 14;
            this.button5.Text = "Sửa";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnUpdate_click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CharName,
            this.DataInGame,
            this.UserName,
            this.Password,
            this.Settings,
            this.Server,
            this.Status,
            this.Auto});
            this.dataGridView1.Location = new System.Drawing.Point(11, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(665, 250);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 106.9519F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 30;
            // 
            // CharName
            // 
            this.CharName.DataPropertyName = "CharName";
            this.CharName.HeaderText = "Nhân vật";
            this.CharName.MinimumWidth = 6;
            this.CharName.Name = "CharName";
            this.CharName.ReadOnly = true;
            this.CharName.Width = 80;
            // 
            // DataInGame
            // 
            this.DataInGame.DataPropertyName = "DataInGame";
            this.DataInGame.HeaderText = "Trạng Thái Game";
            this.DataInGame.MinimumWidth = 6;
            this.DataInGame.Name = "DataInGame";
            this.DataInGame.ReadOnly = true;
            this.DataInGame.Width = 170;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.FillWeight = 97.68271F;
            this.UserName.HeaderText = "Tài khoản";
            this.UserName.MinimumWidth = 6;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 110;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "Pass";
            this.Password.MinimumWidth = 6;
            this.Password.Name = "Password";
            this.Password.Visible = false;
            this.Password.Width = 125;
            // 
            // Settings
            // 
            this.Settings.DataPropertyName = "Settings";
            this.Settings.HeaderText = "Settings";
            this.Settings.MinimumWidth = 6;
            this.Settings.Name = "Settings";
            this.Settings.Visible = false;
            this.Settings.Width = 125;
            // 
            // Server
            // 
            this.Server.DataPropertyName = "Server";
            this.Server.FillWeight = 97.68271F;
            this.Server.HeaderText = "SV";
            this.Server.MinimumWidth = 6;
            this.Server.Name = "Server";
            this.Server.ReadOnly = true;
            this.Server.Width = 40;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Auto
            // 
            this.Auto.HeaderText = "Auto";
            this.Auto.MinimumWidth = 6;
            this.Auto.Name = "Auto";
            this.Auto.Width = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.button24);
            this.groupBox1.Controls.Add(this.button22);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.numThread);
            this.groupBox1.Controls.Add(this.button23);
            this.groupBox1.Controls.Add(this.button14);
            this.groupBox1.Controls.Add(this.SaveSize);
            this.groupBox1.Controls.Add(this.Size);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.txtTaiKhoan);
            this.groupBox1.Controls.Add(this.txtMatKhau);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.cmbServer);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Location = new System.Drawing.Point(682, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 321);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(222, 157);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(47, 35);
            this.btnImport.TabIndex = 33;
            this.btnImport.Text = "File";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(105, 274);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(80, 34);
            this.button24.TabIndex = 32;
            this.button24.Text = "Bỏ all";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(15, 274);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(73, 34);
            this.button22.TabIndex = 31;
            this.button22.Text = "Chọn all";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label20.Location = new System.Drawing.Point(17, 243);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 18);
            this.label20.TabIndex = 30;
            this.label20.Text = "Số luồng";
            // 
            // numThread
            // 
            this.numThread.Location = new System.Drawing.Point(97, 243);
            this.numThread.Name = "numThread";
            this.numThread.Size = new System.Drawing.Size(80, 22);
            this.numThread.TabIndex = 29;
            this.numThread.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(183, 241);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(64, 34);
            this.button23.TabIndex = 23;
            this.button23.Text = "Start";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(81, 157);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(60, 37);
            this.button14.TabIndex = 28;
            this.button14.Text = "Cmd";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.RunCmd);
            // 
            // SaveSize
            // 
            this.SaveSize.Location = new System.Drawing.Point(183, 118);
            this.SaveSize.Name = "SaveSize";
            this.SaveSize.Size = new System.Drawing.Size(71, 35);
            this.SaveSize.TabIndex = 27;
            this.SaveSize.Text = "Lưu Size";
            this.SaveSize.UseVisualStyleBackColor = true;
            this.SaveSize.Click += new System.EventHandler(this.SaveSize_Click);
            // 
            // Size
            // 
            this.Size.Location = new System.Drawing.Point(194, 80);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(60, 22);
            this.Size.TabIndex = 26;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(81, 200);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(47, 35);
            this.button10.TabIndex = 22;
            this.button10.Text = "Hiện";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 200);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 35);
            this.button3.TabIndex = 21;
            this.button3.Text = "Ẩn";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.button9.Location = new System.Drawing.Point(195, 200);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(59, 35);
            this.button9.TabIndex = 20;
            this.button9.Text = "Tắt All";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.CloseALl);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(134, 200);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(56, 35);
            this.button7.TabIndex = 20;
            this.button7.Text = "Tắt";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(147, 157);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(70, 35);
            this.button6.TabIndex = 19;
            this.button6.Text = "Sắp Xếp";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Location = new System.Drawing.Point(638, 322);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(245, 337);
            this.tabControl2.TabIndex = 19;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button19);
            this.tabPage2.Controls.Add(this.button15);
            this.tabPage2.Controls.Add(this.infomation);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(237, 308);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Bản thân";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(124, 3);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(101, 35);
            this.button19.TabIndex = 30;
            this.button19.Text = "Rương đồ";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(12, 3);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(101, 35);
            this.button15.TabIndex = 29;
            this.button15.Text = "Hành trang";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click_1);
            // 
            // infomation
            // 
            this.infomation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.infomation.Location = new System.Drawing.Point(3, 40);
            this.infomation.Multiline = true;
            this.infomation.Name = "infomation";
            this.infomation.Size = new System.Drawing.Size(231, 261);
            this.infomation.TabIndex = 0;
            this.infomation.TextChanged += new System.EventHandler(this.infomation_TextChanged);
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(237, 308);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Hành Trang";
            this.tabPage7.UseVisualStyleBackColor = true;
            this.tabPage7.Click += new System.EventHandler(this.tabPage7_Click);
            // 
            // SaveIDSL
            // 
            this.SaveIDSL.Location = new System.Drawing.Point(198, 247);
            this.SaveIDSL.Name = "SaveIDSL";
            this.SaveIDSL.Size = new System.Drawing.Size(48, 30);
            this.SaveIDSL.TabIndex = 36;
            this.SaveIDSL.Text = "Lưu";
            this.SaveIDSL.UseVisualStyleBackColor = true;
            this.SaveIDSL.Click += new System.EventHandler(this.SaveIDSL_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(263, 248);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(33, 30);
            this.button21.TabIndex = 37;
            this.button21.Text = "?";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // Gold
            // 
            this.Gold.Controls.Add(this.button20);
            this.Gold.Controls.Add(this.label19);
            this.Gold.Controls.Add(this.MobLoaiTru);
            this.Gold.Location = new System.Drawing.Point(4, 32);
            this.Gold.Name = "Gold";
            this.Gold.Padding = new System.Windows.Forms.Padding(3);
            this.Gold.Size = new System.Drawing.Size(622, 356);
            this.Gold.TabIndex = 5;
            this.Gold.Text = "Kẹp vàng";
            this.Gold.UseVisualStyleBackColor = true;
            this.Gold.Click += new System.EventHandler(this.Gold_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(111, 112);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(48, 30);
            this.button20.TabIndex = 40;
            this.button20.Text = "Lưu";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label19.Location = new System.Drawing.Point(20, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(186, 18);
            this.label19.TabIndex = 40;
            this.label19.Text = "ID quái loại trừ để pem chết";
            // 
            // MobLoaiTru
            // 
            this.MobLoaiTru.Location = new System.Drawing.Point(23, 73);
            this.MobLoaiTru.Name = "MobLoaiTru";
            this.MobLoaiTru.Size = new System.Drawing.Size(136, 22);
            this.MobLoaiTru.TabIndex = 32;
            // 
            // ConFig
            // 
            this.ConFig.Controls.Add(this.SaveTimeNextMap);
            this.ConFig.Controls.Add(this.TimeNextMap);
            this.ConFig.Controls.Add(this.label21);
            this.ConFig.Controls.Add(this.button17);
            this.ConFig.Controls.Add(this.maskedTextBox1);
            this.ConFig.Controls.Add(this.label14);
            this.ConFig.Controls.Add(this.button16);
            this.ConFig.Controls.Add(this.SaveProxy);
            this.ConFig.Controls.Add(this.label10);
            this.ConFig.Controls.Add(this.InputProxy);
            this.ConFig.Controls.Add(this.button13);
            this.ConFig.Controls.Add(this.button12);
            this.ConFig.Controls.Add(this.button11);
            this.ConFig.Location = new System.Drawing.Point(4, 32);
            this.ConFig.Name = "ConFig";
            this.ConFig.Padding = new System.Windows.Forms.Padding(3);
            this.ConFig.Size = new System.Drawing.Size(622, 356);
            this.ConFig.TabIndex = 3;
            this.ConFig.Text = "ConFig+Proxy";
            this.ConFig.UseVisualStyleBackColor = true;
            // 
            // SaveTimeNextMap
            // 
            this.SaveTimeNextMap.Location = new System.Drawing.Point(264, 258);
            this.SaveTimeNextMap.Name = "SaveTimeNextMap";
            this.SaveTimeNextMap.Size = new System.Drawing.Size(60, 35);
            this.SaveTimeNextMap.TabIndex = 34;
            this.SaveTimeNextMap.Text = "Lưu";
            this.SaveTimeNextMap.UseVisualStyleBackColor = true;
            this.SaveTimeNextMap.Click += new System.EventHandler(this.SaveTimeNextMap_Click);
            // 
            // TimeNextMap
            // 
            this.TimeNextMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.TimeNextMap.Location = new System.Drawing.Point(126, 264);
            this.TimeNextMap.Name = "TimeNextMap";
            this.TimeNextMap.Size = new System.Drawing.Size(108, 23);
            this.TimeNextMap.TabIndex = 33;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label21.Location = new System.Drawing.Point(20, 265);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 18);
            this.label21.TabIndex = 32;
            this.label21.Text = "TimeNextMap";
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(332, 157);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(60, 35);
            this.button17.TabIndex = 31;
            this.button17.Text = "Lưu";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.maskedTextBox1.Location = new System.Drawing.Point(88, 161);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(226, 23);
            this.maskedTextBox1.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label14.Location = new System.Drawing.Point(20, 163);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 18);
            this.label14.TabIndex = 29;
            this.label14.Text = "CapCha";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(407, 203);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(112, 35);
            this.button16.TabIndex = 28;
            this.button16.Text = "Check Proxy";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.checkProxy);
            // 
            // SaveProxy
            // 
            this.SaveProxy.Location = new System.Drawing.Point(332, 203);
            this.SaveProxy.Name = "SaveProxy";
            this.SaveProxy.Size = new System.Drawing.Size(60, 35);
            this.SaveProxy.TabIndex = 27;
            this.SaveProxy.Text = "Lưu";
            this.SaveProxy.UseVisualStyleBackColor = true;
            this.SaveProxy.Click += new System.EventHandler(this.SaveProxy_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label10.Location = new System.Drawing.Point(20, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 18);
            this.label10.TabIndex = 26;
            this.label10.Text = "Proxy";
            // 
            // InputProxy
            // 
            this.InputProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.InputProxy.Location = new System.Drawing.Point(88, 209);
            this.InputProxy.Name = "InputProxy";
            this.InputProxy.Size = new System.Drawing.Size(226, 23);
            this.InputProxy.TabIndex = 25;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(23, 105);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(225, 35);
            this.button13.TabIndex = 24;
            this.button13.Text = "Paste cho all";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(23, 64);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(225, 35);
            this.button12.TabIndex = 23;
            this.button12.Text = "Paste cho Acc này";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.btnPasteConfig_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(23, 23);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(225, 35);
            this.button11.TabIndex = 22;
            this.button11.Text = "Copy ConFig";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.btnCopyConfig_Click);
            // 
            // ViewGTS
            // 
            this.ViewGTS.Controls.Add(this.SaveFarmBoss);
            this.ViewGTS.Controls.Add(this.FarmReverseGTS);
            this.ViewGTS.Controls.Add(this.AutoBossNapa);
            this.ViewGTS.Controls.Add(this.QuantityGTS);
            this.ViewGTS.Location = new System.Drawing.Point(4, 32);
            this.ViewGTS.Name = "ViewGTS";
            this.ViewGTS.Padding = new System.Windows.Forms.Padding(3);
            this.ViewGTS.Size = new System.Drawing.Size(622, 356);
            this.ViewGTS.TabIndex = 1;
            this.ViewGTS.Text = "AutoBoss";
            this.ViewGTS.UseVisualStyleBackColor = true;
            this.ViewGTS.Click += new System.EventHandler(this.ViewGTS_Click);
            // 
            // SaveFarmBoss
            // 
            this.SaveFarmBoss.Location = new System.Drawing.Point(168, 118);
            this.SaveFarmBoss.Name = "SaveFarmBoss";
            this.SaveFarmBoss.Size = new System.Drawing.Size(60, 35);
            this.SaveFarmBoss.TabIndex = 20;
            this.SaveFarmBoss.Text = "Lưu";
            this.SaveFarmBoss.UseVisualStyleBackColor = true;
            this.SaveFarmBoss.Click += new System.EventHandler(this.SaveFarmBoss_Click);
            // 
            // FarmReverseGTS
            // 
            this.FarmReverseGTS.AutoSize = true;
            this.FarmReverseGTS.Location = new System.Drawing.Point(13, 81);
            this.FarmReverseGTS.Name = "FarmReverseGTS";
            this.FarmReverseGTS.Size = new System.Drawing.Size(215, 20);
            this.FarmReverseGTS.TabIndex = 19;
            this.FarmReverseGTS.Text = "Farm từ cuối về mặc định từ đầu";
            this.FarmReverseGTS.UseVisualStyleBackColor = true;
            // 
            // AutoBossNapa
            // 
            this.AutoBossNapa.AutoSize = true;
            this.AutoBossNapa.Location = new System.Drawing.Point(13, 44);
            this.AutoBossNapa.Name = "AutoBossNapa";
            this.AutoBossNapa.Size = new System.Drawing.Size(96, 20);
            this.AutoBossNapa.TabIndex = 18;
            this.AutoBossNapa.Text = "Farm Găng";
            this.AutoBossNapa.UseVisualStyleBackColor = true;
            this.AutoBossNapa.CheckedChanged += new System.EventHandler(this.checkBoxGTS_CheckedChanged);
            // 
            // QuantityGTS
            // 
            this.QuantityGTS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QuantityGTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.QuantityGTS.FormattingEnabled = true;
            this.QuantityGTS.Items.AddRange(new object[] {
            "40",
            "80"});
            this.QuantityGTS.Location = new System.Drawing.Point(120, 41);
            this.QuantityGTS.Name = "QuantityGTS";
            this.QuantityGTS.Size = new System.Drawing.Size(138, 24);
            this.QuantityGTS.TabIndex = 16;
            this.QuantityGTS.SelectedIndexChanged += new System.EventHandler(this.GangTS_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(622, 356);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "MVBT-Giáp";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.checkBox6);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.numericUpDown3);
            this.groupBox4.Controls.Add(this.treoGiap);
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.checkBox5);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.numericUpDown2);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.TypeMvbt);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Controls.Add(this.checkBoxUpMvbt);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.listMapMvbt);
            this.groupBox4.Location = new System.Drawing.Point(1, 23);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(402, 277);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MVBT";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label15.Location = new System.Drawing.Point(238, 166);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 18);
            this.label15.TabIndex = 35;
            this.label15.Text = "Khu:";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(214, 68);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(85, 20);
            this.checkBox6.TabIndex = 34;
            this.checkBox6.Tag = "";
            this.checkBox6.Text = "Mặc giáp";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 33);
            this.button1.TabIndex = 31;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(280, 165);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(52, 22);
            this.numericUpDown3.TabIndex = 33;
            // 
            // treoGiap
            // 
            this.treoGiap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.treoGiap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.treoGiap.FormattingEnabled = true;
            this.treoGiap.Items.AddRange(new object[] {
            "42. Vách núi Aru",
            "43. Vách núi Moori",
            "44. Vách núi Kakarot"});
            this.treoGiap.Location = new System.Drawing.Point(104, 163);
            this.treoGiap.Name = "treoGiap";
            this.treoGiap.Size = new System.Drawing.Size(128, 24);
            this.treoGiap.TabIndex = 32;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(9, 138);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(73, 20);
            this.radioButton3.TabIndex = 31;
            this.radioButton3.Text = "Up Kilis";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(9, 190);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(99, 20);
            this.radioButton2.TabIndex = 30;
            this.radioButton2.Text = "Tự tắt game";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(9, 164);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 20);
            this.radioButton1.TabIndex = 29;
            this.radioButton1.Text = "Treo Giáp";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(9, 68);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(18, 17);
            this.checkBox5.TabIndex = 28;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.Location = new System.Drawing.Point(35, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 18);
            this.label9.TabIndex = 26;
            this.label9.Text = "Khu:";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(84, 66);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(100, 22);
            this.numericUpDown2.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(168, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 18);
            this.label8.TabIndex = 25;
            this.label8.Text = "Loại:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // TypeMvbt
            // 
            this.TypeMvbt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeMvbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.TypeMvbt.FormattingEnabled = true;
            this.TypeMvbt.Items.AddRange(new object[] {
            "MVBT C2",
            "MVBT C3"});
            this.TypeMvbt.Location = new System.Drawing.Point(214, 99);
            this.TypeMvbt.Name = "TypeMvbt";
            this.TypeMvbt.Size = new System.Drawing.Size(98, 24);
            this.TypeMvbt.TabIndex = 24;
            this.TypeMvbt.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(6, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 23;
            this.label6.Text = "Số lượng:";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(84, 101);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(78, 22);
            this.numericUpDown1.TabIndex = 22;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // checkBoxUpMvbt
            // 
            this.checkBoxUpMvbt.AutoSize = true;
            this.checkBoxUpMvbt.Location = new System.Drawing.Point(8, 37);
            this.checkBoxUpMvbt.Name = "checkBoxUpMvbt";
            this.checkBoxUpMvbt.Size = new System.Drawing.Size(18, 17);
            this.checkBoxUpMvbt.TabIndex = 21;
            this.checkBoxUpMvbt.UseVisualStyleBackColor = true;
            this.checkBoxUpMvbt.CheckedChanged += new System.EventHandler(this.checkBoxUpMvbt_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(36, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Train:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // listMapMvbt
            // 
            this.listMapMvbt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listMapMvbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.listMapMvbt.FormattingEnabled = true;
            this.listMapMvbt.Items.AddRange(new object[] {
            "156. Tây thánh địa",
            "157. Đông thánh địa",
            "158. Bắc thánh địa",
            "159. Nam thánh địa"});
            this.listMapMvbt.Location = new System.Drawing.Point(84, 33);
            this.listMapMvbt.Name = "listMapMvbt";
            this.listMapMvbt.Size = new System.Drawing.Size(162, 24);
            this.listMapMvbt.TabIndex = 20;
            this.listMapMvbt.SelectedIndexChanged += new System.EventHandler(this.listMapMvbt_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.listItem);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(622, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AutoTrain";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AttackFull);
            this.groupBox3.Controls.Add(this.UpMapPrivate);
            this.groupBox3.Controls.Add(this.AutoGB);
            this.groupBox3.Controls.Add(this.AutoFlag);
            this.groupBox3.Controls.Add(this.SKH);
            this.groupBox3.Controls.Add(this.TrainNotMove);
            this.groupBox3.Controls.Add(this.AutoPorata);
            this.groupBox3.Controls.Add(this.AutoLogin);
            this.groupBox3.Controls.Add(this.AutoBuyTDLT);
            this.groupBox3.Controls.Add(this.AutoUseGiapLT);
            this.groupBox3.Location = new System.Drawing.Point(314, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 170);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Linh Tinh";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // AttackFull
            // 
            this.AttackFull.AutoSize = true;
            this.AttackFull.Location = new System.Drawing.Point(16, 130);
            this.AttackFull.Name = "AttackFull";
            this.AttackFull.Size = new System.Drawing.Size(178, 20);
            this.AttackFull.TabIndex = 9;
            this.AttackFull.Tag = "";
            this.AttackFull.Text = "Pem quái khi hp = hp gốc";
            this.AttackFull.UseVisualStyleBackColor = true;
            this.AttackFull.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_5);
            // 
            // UpMapPrivate
            // 
            this.UpMapPrivate.AutoSize = true;
            this.UpMapPrivate.Location = new System.Drawing.Point(193, 75);
            this.UpMapPrivate.Name = "UpMapPrivate";
            this.UpMapPrivate.Size = new System.Drawing.Size(95, 20);
            this.UpMapPrivate.TabIndex = 8;
            this.UpMapPrivate.Tag = "";
            this.UpMapPrivate.Text = "Up vé SKH";
            this.UpMapPrivate.UseVisualStyleBackColor = true;
            this.UpMapPrivate.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_4);
            // 
            // AutoGB
            // 
            this.AutoGB.AutoSize = true;
            this.AutoGB.Location = new System.Drawing.Point(112, 75);
            this.AutoGB.Name = "AutoGB";
            this.AutoGB.Size = new System.Drawing.Size(71, 20);
            this.AutoGB.TabIndex = 7;
            this.AutoGB.Tag = "";
            this.AutoGB.Text = "Đợi HS";
            this.AutoGB.UseVisualStyleBackColor = true;
            this.AutoGB.CheckedChanged += new System.EventHandler(this.AutoGB_CheckedChanged);
            // 
            // AutoFlag
            // 
            this.AutoFlag.AutoSize = true;
            this.AutoFlag.Location = new System.Drawing.Point(109, 49);
            this.AutoFlag.Name = "AutoFlag";
            this.AutoFlag.Size = new System.Drawing.Size(100, 20);
            this.AutoFlag.TabIndex = 6;
            this.AutoFlag.Tag = "";
            this.AutoFlag.Text = "Auto cờ đen";
            this.AutoFlag.UseVisualStyleBackColor = true;
            this.AutoFlag.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_3);
            // 
            // SKH
            // 
            this.SKH.AutoSize = true;
            this.SKH.Location = new System.Drawing.Point(109, 21);
            this.SKH.Name = "SKH";
            this.SKH.Size = new System.Drawing.Size(181, 20);
            this.SKH.TabIndex = 5;
            this.SKH.Tag = "";
            this.SKH.Text = "Pem quái khi hp != hp gốc";
            this.SKH.UseVisualStyleBackColor = true;
            this.SKH.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // TrainNotMove
            // 
            this.TrainNotMove.AutoSize = true;
            this.TrainNotMove.Location = new System.Drawing.Point(148, 101);
            this.TrainNotMove.Name = "TrainNotMove";
            this.TrainNotMove.Size = new System.Drawing.Size(110, 20);
            this.TrainNotMove.TabIndex = 5;
            this.TrainNotMove.Tag = "";
            this.TrainNotMove.Text = "Train đứng im";
            this.TrainNotMove.UseVisualStyleBackColor = true;
            this.TrainNotMove.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // AutoPorata
            // 
            this.AutoPorata.AutoSize = true;
            this.AutoPorata.Location = new System.Drawing.Point(16, 21);
            this.AutoPorata.Name = "AutoPorata";
            this.AutoPorata.Size = new System.Drawing.Size(78, 20);
            this.AutoPorata.TabIndex = 4;
            this.AutoPorata.Tag = "";
            this.AutoPorata.Text = "Bông tai";
            this.AutoPorata.UseVisualStyleBackColor = true;
            this.AutoPorata.CheckedChanged += new System.EventHandler(this.Fushion_CheckedChanged);
            // 
            // AutoLogin
            // 
            this.AutoLogin.AutoSize = true;
            this.AutoLogin.Location = new System.Drawing.Point(16, 49);
            this.AutoLogin.Name = "AutoLogin";
            this.AutoLogin.Size = new System.Drawing.Size(92, 20);
            this.AutoLogin.TabIndex = 3;
            this.AutoLogin.Tag = "";
            this.AutoLogin.Text = "Auto Login";
            this.AutoLogin.UseVisualStyleBackColor = true;
            this.AutoLogin.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // AutoBuyTDLT
            // 
            this.AutoBuyTDLT.AutoSize = true;
            this.AutoBuyTDLT.Location = new System.Drawing.Point(16, 101);
            this.AutoBuyTDLT.Name = "AutoBuyTDLT";
            this.AutoBuyTDLT.Size = new System.Drawing.Size(126, 20);
            this.AutoBuyTDLT.TabIndex = 2;
            this.AutoBuyTDLT.Tag = "";
            this.AutoBuyTDLT.Text = "Mua dùng TDLT";
            this.AutoBuyTDLT.UseVisualStyleBackColor = true;
            this.AutoBuyTDLT.CheckedChanged += new System.EventHandler(this.AutoBuyTDLTzz);
            // 
            // AutoUseGiapLT
            // 
            this.AutoUseGiapLT.AutoSize = true;
            this.AutoUseGiapLT.Location = new System.Drawing.Point(16, 75);
            this.AutoUseGiapLT.Name = "AutoUseGiapLT";
            this.AutoUseGiapLT.Size = new System.Drawing.Size(91, 20);
            this.AutoUseGiapLT.TabIndex = 1;
            this.AutoUseGiapLT.Tag = "";
            this.AutoUseGiapLT.Text = "Tháo giáp";
            this.AutoUseGiapLT.UseVisualStyleBackColor = true;
            this.AutoUseGiapLT.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listItem
            // 
            this.listItem.Controls.Add(this.button18);
            this.listItem.Controls.Add(this.TrashItemIds);
            this.listItem.Controls.Add(this.label16);
            this.listItem.Controls.Add(this.label13);
            this.listItem.Controls.Add(this.SaveListItems);
            this.listItem.Controls.Add(this.ListIDItems);
            this.listItem.Controls.Add(this.UseCanCo);
            this.listItem.Controls.Add(this.UseGiapXen);
            this.listItem.Controls.Add(this.UseBoHuyet);
            this.listItem.Controls.Add(this.UseKhauTrang);
            this.listItem.Controls.Add(this.UseCuongNo);
            this.listItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listItem.Location = new System.Drawing.Point(314, 10);
            this.listItem.Name = "listItem";
            this.listItem.Size = new System.Drawing.Size(300, 137);
            this.listItem.TabIndex = 16;
            this.listItem.TabStop = false;
            this.listItem.Text = "Item";
            this.listItem.Enter += new System.EventHandler(this.listItem_Enter);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(242, 90);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(48, 30);
            this.button18.TabIndex = 31;
            this.button18.Text = "Lưu";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.TrashItemIdszz);
            // 
            // TrashItemIds
            // 
            this.TrashItemIds.Location = new System.Drawing.Point(74, 92);
            this.TrashItemIds.Name = "TrashItemIds";
            this.TrashItemIds.Size = new System.Drawing.Size(157, 22);
            this.TrashItemIds.TabIndex = 30;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label16.Location = new System.Drawing.Point(6, 93);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 18);
            this.label16.TabIndex = 29;
            this.label16.Text = "ID Vứt";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label13.Location = new System.Drawing.Point(6, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 18);
            this.label13.TabIndex = 28;
            this.label13.Text = "ID Dùng";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // SaveListItems
            // 
            this.SaveListItems.Location = new System.Drawing.Point(242, 47);
            this.SaveListItems.Name = "SaveListItems";
            this.SaveListItems.Size = new System.Drawing.Size(48, 30);
            this.SaveListItems.TabIndex = 27;
            this.SaveListItems.Text = "Lưu";
            this.SaveListItems.UseVisualStyleBackColor = true;
            this.SaveListItems.Click += new System.EventHandler(this.button15_Click);
            // 
            // ListIDItems
            // 
            this.ListIDItems.Location = new System.Drawing.Point(74, 52);
            this.ListIDItems.Name = "ListIDItems";
            this.ListIDItems.Size = new System.Drawing.Size(157, 22);
            this.ListIDItems.TabIndex = 26;
            // 
            // UseCanCo
            // 
            this.UseCanCo.AutoSize = true;
            this.UseCanCo.Location = new System.Drawing.Point(179, 21);
            this.UseCanCo.Name = "UseCanCo";
            this.UseCanCo.Size = new System.Drawing.Size(46, 20);
            this.UseCanCo.TabIndex = 5;
            this.UseCanCo.Tag = "Cỏ may mắn|1635|13618";
            this.UseCanCo.Text = "Cỏ";
            this.UseCanCo.UseVisualStyleBackColor = true;
            this.UseCanCo.CheckedChanged += new System.EventHandler(this.OnBuffSettingChanged);
            // 
            // UseGiapXen
            // 
            this.UseGiapXen.AutoSize = true;
            this.UseGiapXen.Location = new System.Drawing.Point(127, 21);
            this.UseGiapXen.Name = "UseGiapXen";
            this.UseGiapXen.Size = new System.Drawing.Size(47, 20);
            this.UseGiapXen.TabIndex = 4;
            this.UseGiapXen.Tag = "Giáp Xên|384|2757";
            this.UseGiapXen.Text = "GX";
            this.UseGiapXen.UseVisualStyleBackColor = true;
            this.UseGiapXen.CheckedChanged += new System.EventHandler(this.OnBuffSettingChanged);
            // 
            // UseBoHuyet
            // 
            this.UseBoHuyet.AutoSize = true;
            this.UseBoHuyet.Location = new System.Drawing.Point(73, 21);
            this.UseBoHuyet.Name = "UseBoHuyet";
            this.UseBoHuyet.Size = new System.Drawing.Size(48, 20);
            this.UseBoHuyet.TabIndex = 2;
            this.UseBoHuyet.Tag = "Bổ Huyết|382|2755";
            this.UseBoHuyet.Text = "BH";
            this.UseBoHuyet.UseVisualStyleBackColor = true;
            this.UseBoHuyet.CheckedChanged += new System.EventHandler(this.OnBuffSettingChanged);
            // 
            // UseKhauTrang
            // 
            this.UseKhauTrang.AutoSize = true;
            this.UseKhauTrang.Location = new System.Drawing.Point(231, 21);
            this.UseKhauTrang.Name = "UseKhauTrang";
            this.UseKhauTrang.Size = new System.Drawing.Size(46, 20);
            this.UseKhauTrang.TabIndex = 1;
            this.UseKhauTrang.Tag = "Khẩu Trang|764|7149";
            this.UseKhauTrang.Text = "KT";
            this.UseKhauTrang.UseVisualStyleBackColor = true;
            this.UseKhauTrang.CheckedChanged += new System.EventHandler(this.OnBuffSettingChanged);
            // 
            // UseCuongNo
            // 
            this.UseCuongNo.AutoSize = true;
            this.UseCuongNo.Location = new System.Drawing.Point(19, 21);
            this.UseCuongNo.Name = "UseCuongNo";
            this.UseCuongNo.Size = new System.Drawing.Size(48, 20);
            this.UseCuongNo.TabIndex = 0;
            this.UseCuongNo.Tag = "Cuồng Nộ|381|2754";
            this.UseCuongNo.Text = "CN";
            this.UseCuongNo.UseVisualStyleBackColor = true;
            this.UseCuongNo.CheckedChanged += new System.EventHandler(this.OnBuffSettingChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.character);
            this.groupBox2.Controls.Add(this.nechar);
            this.groupBox2.Controls.Add(this.button21);
            this.groupBox2.Controls.Add(this.SaveIDSL);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.IDSL);
            this.groupBox2.Controls.Add(this.SaveListIDMob);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.ListIDMob);
            this.groupBox2.Controls.Add(this.checkMinHp);
            this.groupBox2.Controls.Add(this.minHp);
            this.groupBox2.Controls.Add(this.UseHpThreshold);
            this.groupBox2.Controls.Add(this.HpThreshold);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.SkillsText);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.MobTypeIndex);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.AutoZoneEnabled);
            this.groupBox2.Controls.Add(this.AutoTrainEnabled);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.MapId);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.Zone);
            this.groupBox2.Location = new System.Drawing.Point(6, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 327);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Train";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // character
            // 
            this.character.Location = new System.Drawing.Point(98, 292);
            this.character.Name = "character";
            this.character.Size = new System.Drawing.Size(198, 22);
            this.character.TabIndex = 39;
            // 
            // nechar
            // 
            this.nechar.AutoSize = true;
            this.nechar.Location = new System.Drawing.Point(12, 293);
            this.nechar.Name = "nechar";
            this.nechar.Size = new System.Drawing.Size(76, 20);
            this.nechar.TabIndex = 38;
            this.nechar.Text = "Né char";
            this.nechar.UseVisualStyleBackColor = true;
            this.nechar.CheckedChanged += new System.EventHandler(this.nechar_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label18.Location = new System.Drawing.Point(12, 253);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 18);
            this.label18.TabIndex = 35;
            this.label18.Text = "ID-SL";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // IDSL
            // 
            this.IDSL.Location = new System.Drawing.Point(97, 251);
            this.IDSL.Name = "IDSL";
            this.IDSL.Size = new System.Drawing.Size(88, 22);
            this.IDSL.TabIndex = 34;
            // 
            // SaveListIDMob
            // 
            this.SaveListIDMob.Location = new System.Drawing.Point(243, 119);
            this.SaveListIDMob.Name = "SaveListIDMob";
            this.SaveListIDMob.Size = new System.Drawing.Size(48, 30);
            this.SaveListIDMob.TabIndex = 33;
            this.SaveListIDMob.Text = "Lưu";
            this.SaveListIDMob.UseVisualStyleBackColor = true;
            this.SaveListIDMob.Click += new System.EventHandler(this.SaveListIDMob_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label17.Location = new System.Drawing.Point(14, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 18);
            this.label17.TabIndex = 32;
            this.label17.Text = "ID quái";
            // 
            // ListIDMob
            // 
            this.ListIDMob.Location = new System.Drawing.Point(97, 125);
            this.ListIDMob.Name = "ListIDMob";
            this.ListIDMob.Size = new System.Drawing.Size(136, 22);
            this.ListIDMob.TabIndex = 31;
            // 
            // checkMinHp
            // 
            this.checkMinHp.AutoSize = true;
            this.checkMinHp.Location = new System.Drawing.Point(13, 221);
            this.checkMinHp.Name = "checkMinHp";
            this.checkMinHp.Size = new System.Drawing.Size(78, 20);
            this.checkMinHp.TabIndex = 30;
            this.checkMinHp.Text = "Dưới hp:";
            this.checkMinHp.UseVisualStyleBackColor = true;
            this.checkMinHp.CheckedChanged += new System.EventHandler(this.checkMinHp_CheckedChanged);
            // 
            // minHp
            // 
            this.minHp.Location = new System.Drawing.Point(97, 223);
            this.minHp.Name = "minHp";
            this.minHp.Size = new System.Drawing.Size(136, 22);
            this.minHp.TabIndex = 29;
            this.minHp.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // UseHpThreshold
            // 
            this.UseHpThreshold.AutoSize = true;
            this.UseHpThreshold.Location = new System.Drawing.Point(13, 192);
            this.UseHpThreshold.Name = "UseHpThreshold";
            this.UseHpThreshold.Size = new System.Drawing.Size(78, 20);
            this.UseHpThreshold.TabIndex = 28;
            this.UseHpThreshold.Text = "Trên hp:";
            this.UseHpThreshold.UseVisualStyleBackColor = true;
            this.UseHpThreshold.CheckedChanged += new System.EventHandler(this.checkHp_CheckedChanged);
            // 
            // HpThreshold
            // 
            this.HpThreshold.Location = new System.Drawing.Point(97, 190);
            this.HpThreshold.Name = "HpThreshold";
            this.HpThreshold.Size = new System.Drawing.Size(136, 22);
            this.HpThreshold.TabIndex = 27;
            this.HpThreshold.TextChanged += new System.EventHandler(this.maxHp_TextChanged);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(243, 158);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(48, 30);
            this.button8.TabIndex = 26;
            this.button8.Text = "Lưu";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Skill);
            // 
            // SkillsText
            // 
            this.SkillsText.Location = new System.Drawing.Point(97, 158);
            this.SkillsText.Name = "SkillsText";
            this.SkillsText.Size = new System.Drawing.Size(136, 22);
            this.SkillsText.TabIndex = 25;
            this.SkillsText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(13, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "Skill";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // MobTypeIndex
            // 
            this.MobTypeIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MobTypeIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.MobTypeIndex.FormattingEnabled = true;
            this.MobTypeIndex.Items.AddRange(new object[] {
            "Tất cả",
            "Quái Đất",
            "Quái Bay",
            "Đánh theo ID"});
            this.MobTypeIndex.Location = new System.Drawing.Point(97, 92);
            this.MobTypeIndex.Name = "MobTypeIndex";
            this.MobTypeIndex.Size = new System.Drawing.Size(123, 24);
            this.MobTypeIndex.TabIndex = 21;
            this.MobTypeIndex.SelectedIndexChanged += new System.EventHandler(this.checkBoxAutoTrain_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(12, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Loại quái";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // AutoZoneEnabled
            // 
            this.AutoZoneEnabled.AutoSize = true;
            this.AutoZoneEnabled.Location = new System.Drawing.Point(15, 63);
            this.AutoZoneEnabled.Name = "AutoZoneEnabled";
            this.AutoZoneEnabled.Size = new System.Drawing.Size(18, 17);
            this.AutoZoneEnabled.TabIndex = 19;
            this.AutoZoneEnabled.UseVisualStyleBackColor = true;
            this.AutoZoneEnabled.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // AutoTrainEnabled
            // 
            this.AutoTrainEnabled.AutoSize = true;
            this.AutoTrainEnabled.Location = new System.Drawing.Point(15, 32);
            this.AutoTrainEnabled.Name = "AutoTrainEnabled";
            this.AutoTrainEnabled.Size = new System.Drawing.Size(18, 17);
            this.AutoTrainEnabled.TabIndex = 18;
            this.AutoTrainEnabled.UseVisualStyleBackColor = true;
            this.AutoTrainEnabled.CheckedChanged += new System.EventHandler(this.checkBoxAutoTrain_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label12.Location = new System.Drawing.Point(43, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 18);
            this.label12.TabIndex = 9;
            this.label12.Text = "Train";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // MapId
            // 
            this.MapId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.MapId.FormattingEnabled = true;
            this.MapId.Items.AddRange(new object[] {
            "0. Làng Aru",
            "1. Đồi hoa cúc",
            "2. Thung lũng tre",
            "3. Rừng nấm",
            "4. Rừng xương",
            "5. Đảo Kamê",
            "6. Đông Karin",
            "7. Làng Mori",
            "8. Đồi nấm tím",
            "9. Thị trấn Moori",
            "10. Thung lũng Namếc",
            "11. Thung lũng Maima",
            "12. Vực maima",
            "13. Đảo Guru",
            "14. Làng Kakarot",
            "15. Đồi hoang",
            "16. Làng Plant",
            "17. Rừng nguyên sinh",
            "18. Rừng thông Xayda",
            "19. Thành phố Vegeta",
            "20. Vách núi đen",
            "21. Nhà Gôhan",
            "22. Nhà Moori",
            "23. Nhà Broly",
            "24. Trạm tàu vũ trụ",
            "25. Trạm tàu vũ trụ",
            "26. Trạm tàu vũ trụ",
            "27. Rừng Bamboo",
            "28. Rừng dương xỉ",
            "29. Nam Kamê",
            "30. Đảo Bulông",
            "31. Núi hoa vàng",
            "32. Núi hoa tím",
            "33. Nam Guru",
            "34. Đông Nam Guru",
            "35. Rừng cọ",
            "36. Rừng đá",
            "37. Thung lũng đen",
            "38. Bờ vực đen",
            "39. Vách núi Aru",
            "40. Vách núi Moori",
            "41. Vực Plant",
            "42. Vách núi Aru",
            "43. Vách núi Moori",
            "44. Vách núi Kakarot",
            "45. Thần điện",
            "46. Tháp Karin",
            "47. Rừng Karin",
            "48. Hành tinh Kaio",
            "49. Phòng tập thời gian",
            "50. Thánh địa Kaio",
            "51. Đấu trường",
            "52. Đại hội võ thuật",
            "53. Tường thành 1",
            "54. Tầng 3",
            "55. Tầng 1",
            "56. Tầng 2",
            "57. Tầng 4",
            "58. Tường thành 2",
            "59. Tường thành 3",
            "60. Trại độc nhãn 1",
            "61. Trại độc nhãn 2",
            "62. Trại độc nhãn 3",
            "63. Trại lính Fide",
            "64. Núi dây leo",
            "65. Núi cây quỷ",
            "66. Trại quỷ già",
            "67. Vực chết",
            "68. Thung lũng Nappa",
            "69. Vực cấm",
            "70. Núi Appule",
            "71. Căn cứ Raspberry",
            "72. Thung lũng Raspberry",
            "73. Thung lũng chết",
            "74. Đồi cây Fide",
            "75. Khe núi tử thần",
            "76. Núi đá",
            "77. Rừng đá",
            "78. Lãnh địa Fize",
            "79. Núi khỉ đỏ",
            "80. Núi khỉ vàng",
            "81. Hang quỷ chim",
            "82. Núi khỉ đen",
            "83. Hang khỉ đen",
            "84. Siêu Thị",
            "85. Hành tinh M-2",
            "86. Hành tinh Polaris",
            "87. Hành tinh Cretaceous",
            "88. Hành tinh Monmaasu",
            "89. Hành tinh Rudeeze",
            "90. Hành tinh Gelbo",
            "91. Hành tinh Tigere",
            "92. Thành phố phía đông",
            "93. Thành phố phía nam",
            "94. Đảo Balê",
            "95. 95",
            "96. Cao nguyên",
            "97. Thành phố phía bắc",
            "98. Ngọn núi phía bắc",
            "99. Thung lũng phía bắc",
            "100. Thị trấn Ginder",
            "101. 101",
            "102. Nhà Bunma",
            "103. Võ đài Xên bọ hung",
            "104. Sân sau siêu thị",
            "105. Cánh đồng tuyết",
            "106. Rừng tuyết",
            "107. Núi tuyết",
            "108. Dòng sông băng",
            "109. Rừng băng",
            "110. Hang băng",
            "111. Đông Nam Karin",
            "112. Võ đài Hạt Mít",
            "113. Đại hội võ thuật",
            "114. Cổng phi thuyền",
            "115. Phòng chờ",
            "116. Thánh địa Kaio",
            "117. Cửa Ải 1",
            "118. Cửa Ải 2",
            "119. Cửa Ải 3",
            "120. Phòng chỉ huy",
            "121. Đấu trường",
            "122. Ngũ Hành Sơn",
            "123. Ngũ Hành Sơn",
            "124. Ngũ Hành Sơn",
            "125. Võ đài Bang",
            "126. Thành phố Santa",
            "127. Cổng phi thuyền",
            "128. Bụng Mabư",
            "129. Đại hội võ thuật",
            "130. Đại hội võ thuật Vũ Trụ",
            "131. Hành Tinh Yardart",
            "132. Hành Tinh Yardart 2",
            "133. Hành Tinh Yardart 3",
            "134. Đại hội võ thuật Vũ Trụ 6-7",
            "135. Động hải tặc",
            "136. Hang Bạch Tuộc",
            "137. Động kho báu",
            "138. Cảng hải tặc",
            "139. Hành tinh Potaufeu",
            "140. Hang động Potaufeu",
            "141. Con đường rắn độc",
            "142. Con đường rắn độc",
            "143. Con đường rắn độc",
            "144. Hoang mạc",
            "145. Võ Đài Siêu Cấp",
            "146. Tây Karin",
            "147. Sa mạc",
            "148. Lâu đài Lychee",
            "149. Thành phố Santa",
            "150. Lôi Đài",
            "151. Hành tinh bóng tối",
            "152. Vùng đất băng giá",
            "153. Lãnh địa bang hội",
            "154. Hành tinh Bill",
            "155. Hành tinh ngục tù",
            "156. Tây thánh địa",
            "157. Đông thánh Địa",
            "158. Bắc thánh địa",
            "159. Nam thánh Địa",
            "160. Khu hang động",
            "161. Bìa rừng nguyên thủy",
            "162. Rừng nguyên thủy",
            "163. Làng Plant nguyên thủy",
            "164. Tranh ngọc Namếc",
            "165. Map Boss",
            "166. Hành tinh ngục tù",
            "167. Địa ngục tầng 1",
            "168. Địa ngục tầng 2",
            "169. Địa ngục tầng 3",
            "170. Phòng tập thời gian",
            "171. Địa ngục tầng 4",
            "172. Phòng chờ thời gian",
            "173. Cánh đồng tuyết 2",
            "174. Rừng tuyết 2",
            "175. Hang băng 2",
            "176. NEW Nam Kamê",
            "177. Rừng nguyên sinh",
            "178. Ngọn núi phía bắc",
            "179. Phòng thí nghiệm Myuu",
            "180. Mù căng chải",
            "181. Sa mạc hoang vu"});
            this.MapId.Location = new System.Drawing.Point(97, 28);
            this.MapId.Name = "MapId";
            this.MapId.Size = new System.Drawing.Size(169, 24);
            this.MapId.TabIndex = 14;
            this.MapId.SelectedIndexChanged += new System.EventHandler(this.checkBoxAutoTrain_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label11.Location = new System.Drawing.Point(43, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 18);
            this.label11.TabIndex = 8;
            this.label11.Text = "Khu";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // Zone
            // 
            this.Zone.Location = new System.Drawing.Point(97, 62);
            this.Zone.Name = "Zone";
            this.Zone.Size = new System.Drawing.Size(100, 22);
            this.Zone.TabIndex = 10;
            this.Zone.ValueChanged += new System.EventHandler(this.Zone_ValueChanged);
            // 
            // KSGold
            // 
            this.KSGold.Controls.Add(this.tabPage1);
            this.KSGold.Controls.Add(this.Gold);
            this.KSGold.Controls.Add(this.tabPage3);
            this.KSGold.Controls.Add(this.ViewGTS);
            this.KSGold.Controls.Add(this.ConFig);
            this.KSGold.ItemSize = new System.Drawing.Size(71, 28);
            this.KSGold.Location = new System.Drawing.Point(7, 279);
            this.KSGold.Name = "KSGold";
            this.KSGold.SelectedIndex = 0;
            this.KSGold.Size = new System.Drawing.Size(630, 392);
            this.KSGold.TabIndex = 17;
            this.KSGold.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // QLTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(963, 671);
            this.Controls.Add(this.KSGold);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "QLTK";
            this.Text = "QLTK";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThread)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.Gold.ResumeLayout(false);
            this.Gold.PerformLayout();
            this.ConFig.ResumeLayout(false);
            this.ConFig.PerformLayout();
            this.ViewGTS.ResumeLayout(false);
            this.ViewGTS.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.listItem.ResumeLayout(false);
            this.listItem.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Zone)).EndInit();
            this.KSGold.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private Button SaveTimeNextMap;
    private MaskedTextBox TimeNextMap;
    private Label label21;
}