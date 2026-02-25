using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTK
{
    public class UpdateChecker
    {
        private const string VERSION_URL = "https://raw.githubusercontent.com/datnvtmp/C-Winform/main/version.txt";
        private const string DOWNLOAD_URL = "https://github.com/datnvtmp/C-Winform/releases/latest/download/QLTK.exe";

        public static string CurrentVersion
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return $"{version.Major}.{version.Minor}.{version.Build}";
            }
        }

        public static async Task<UpdateInfo> CheckForUpdatesAsync()
        {
            try
            {
                Debug.WriteLine($"🌐 Checking URL: {VERSION_URL}");

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);

                    string content = await client.GetStringAsync(VERSION_URL);
                    Debug.WriteLine($"📄 Content received: {content.Substring(0, Math.Min(100, content.Length))}...");

                    var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    if (lines.Length >= 2)
                    {
                        string latestVersion = lines[0].Trim();
                        string changelog = string.Join("\n", lines, 1, lines.Length - 1);

                        Debug.WriteLine($"🔢 Latest version: {latestVersion}");
                        Debug.WriteLine($"🔢 Current version: {CurrentVersion}");

                        if (IsNewerVersion(latestVersion, CurrentVersion))
                        {
                            Debug.WriteLine("✅ Update available!");
                            return new UpdateInfo
                            {
                                IsUpdateAvailable = true,
                                LatestVersion = latestVersion,
                                CurrentVersion = CurrentVersion,
                                Changelog = changelog,
                                DownloadUrl = DOWNLOAD_URL
                            };
                        }
                        else
                        {
                            Debug.WriteLine("ℹ️ Already up to date");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Lỗi kiểm tra update: {ex.Message}");
                Debug.WriteLine($"❌ StackTrace: {ex.StackTrace}");
            }

            return new UpdateInfo
            {
                IsUpdateAvailable = false,
                CurrentVersion = CurrentVersion
            };
        }

        private static bool IsNewerVersion(string latest, string current)
        {
            try
            {
                var latestParts = latest.Split('.');
                var currentParts = current.Split('.');

                for (int i = 0; i < Math.Min(latestParts.Length, currentParts.Length); i++)
                {
                    if (int.TryParse(latestParts[i], out int latestNum) &&
                        int.TryParse(currentParts[i], out int currentNum))
                    {
                        if (latestNum > currentNum) return true;
                        if (latestNum < currentNum) return false;
                    }
                }

                return latestParts.Length > currentParts.Length;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> DownloadAndInstallUpdateAsync(string downloadUrl, IProgress<int> progress = null)
        {
            try
            {
                string tempPath = Path.Combine(Path.GetTempPath(), "QLTK_Update.exe");
                string updaterPath = Path.Combine(Application.StartupPath, "Updater.bat");

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(5);

                    using (var response = await client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                        var canReportProgress = totalBytes != -1 && progress != null;

                        using (var contentStream = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                        {
                            var buffer = new byte[8192];
                            long totalRead = 0;
                            int bytesRead;

                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                                totalRead += bytesRead;

                                if (canReportProgress)
                                {
                                    progress.Report((int)((totalRead * 100) / totalBytes));
                                }
                            }
                        }
                    }
                }

                // Tạo file batch để cập nhật
                string currentExe = Application.ExecutablePath;
                string batchContent = $@"@echo off
timeout /t 2 /nobreak > nul
taskkill /F /IM QLTK.exe > nul 2>&1
timeout /t 1 /nobreak > nul
copy /Y ""{tempPath}"" ""{currentExe}""
del ""{tempPath}""
start """" ""{currentExe}""
del ""%~f0""
";

                File.WriteAllText(updaterPath, batchContent);

                // Chạy batch file và thoát
                Process.Start(new ProcessStartInfo
                {
                    FileName = updaterPath,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden
                });

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi tải update: {ex.Message}");
                MessageBox.Show($"Lỗi khi tải bản cập nhật:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    public class UpdateInfo
    {
        public bool IsUpdateAvailable { get; set; }
        public string CurrentVersion { get; set; }
        public string LatestVersion { get; set; }
        public string Changelog { get; set; }
        public string DownloadUrl { get; set; }
    }
}
