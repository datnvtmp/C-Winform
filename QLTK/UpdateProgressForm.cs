using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLTK;

public class UpdateProgressForm : Form
{
    private ProgressBar progressBar;
    private Label statusLabel;

    public UpdateProgressForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.Text = "Đang cập nhật...";
        this.Size = new Size(400, 150);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.ControlBox = false;

        statusLabel = new Label
        {
            Text = "Đang chuẩn bị...",
            Location = new Point(20, 20),
            Size = new Size(360, 30),
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 10F)
        };

        progressBar = new ProgressBar
        {
            Location = new Point(20, 60),
            Size = new Size(360, 30),
            Minimum = 0,
            Maximum = 100,
            Value = 0,
            Style = ProgressBarStyle.Continuous
        };

        this.Controls.Add(statusLabel);
        this.Controls.Add(progressBar);
    }

    public void UpdateProgress(int percentage)
    {
        if (InvokeRequired)
        {
            Invoke(new Action<int>(UpdateProgress), percentage);
            return;
        }

        if (percentage >= 0 && percentage <= 100)
        {
            progressBar.Value = percentage;
            statusLabel.Text = $"Đang tải xuống... {percentage}%";
        }
    }

    public void UpdateStatus(string status)
    {
        if (InvokeRequired)
        {
            Invoke(new Action<string>(UpdateStatus), status);
            return;
        }

        statusLabel.Text = status;
    }
}
