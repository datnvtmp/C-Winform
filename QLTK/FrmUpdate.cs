using System;
using System.Windows.Forms;

namespace QLTK
{
    public partial class FrmUpdate : Form
    {
        private readonly UpdateInfo _updateInfo;

        public FrmUpdate(UpdateInfo updateInfo)
        {
            InitializeComponent();
            _updateInfo = updateInfo;
            LoadUpdateInfo();
        }

        private void LoadUpdateInfo()
        {
            lblCurrentVersion.Text = $"Phiên bản hiện tại: {_updateInfo.CurrentVersion}";
            lblNewVersion.Text = $"Phiên bản mới: {_updateInfo.LatestVersion}";
            txtChangelog.Text = _updateInfo.Changelog ?? "Không có thông tin cập nhật.";
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnLater.Enabled = false;
            progressBar.Visible = true;
            lblProgress.Visible = true;

            var progress = new Progress<int>(percent =>
            {
                progressBar.Value = percent;
                lblProgress.Text = $"Đang tải xuống... {percent}%";
            });

            bool success = await UpdateChecker.DownloadAndInstallUpdateAsync(_updateInfo.DownloadUrl, progress);

            if (success)
            {
                MessageBox.Show("Ứng dụng sẽ tự động khởi động lại để hoàn tất cập nhật!", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
            {
                btnUpdate.Enabled = true;
                btnLater.Enabled = true;
                progressBar.Visible = false;
                lblProgress.Visible = false;
            }
        }

        private void btnLater_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
