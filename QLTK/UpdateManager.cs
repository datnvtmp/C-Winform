using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace QLTK;

public class UpdateManager
{
    private const string GITHUB_REPO_OWNER = "datnvtmp";
    private const string GITHUB_REPO_NAME = "C-Winform";
    private const string CURRENT_VERSION = "1.2.1"; // ← Thay đổi version ở đây khi có bản mới

    public static string Version => CURRENT_VERSION; // ← Public property để lấy version

    private static readonly HttpClient _httpClient = new HttpClient();

    static UpdateManager()
    {
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "QLTK-AutoUpdater");
    }

    public static async Task<bool> CheckForUpdatesAsync(bool showNoUpdateMessage = false)
    {
        try
        {
            string apiUrl = $"https://api.github.com/repos/{GITHUB_REPO_OWNER}/{GITHUB_REPO_NAME}/releases/latest";

            var response = await _httpClient.GetStringAsync(apiUrl);
            var json = JObject.Parse(response);

            string latestVersion = json["tag_name"]?.ToString()?.TrimStart('v');
            var assets = json["assets"] as JArray;

            if (string.IsNullOrEmpty(latestVersion) || assets == null || assets.Count == 0)
            {
                if (showNoUpdateMessage)
                    MessageBox.Show("Không tìm thấy bản cập nhật!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (CompareVersions(CURRENT_VERSION, latestVersion) >= 0)
            {
                if (showNoUpdateMessage)
                    MessageBox.Show($"Bạn đang sử dụng phiên bản mới nhất ({CURRENT_VERSION})!", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Lấy tất cả các file cần download (exe, jar, v.v.)
            var filesToDownload = new System.Collections.Generic.List<(string Url, string FileName)>();
            foreach (var asset in assets)
            {
                string fileName = asset["name"]?.ToString();
                string downloadUrl = asset["browser_download_url"]?.ToString();

                if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(downloadUrl))
                {
                    // Chỉ tải các file exe và jar
                    if (fileName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) || 
                        fileName.EndsWith(".jar", StringComparison.OrdinalIgnoreCase))
                    {
                        filesToDownload.Add((downloadUrl, fileName));
                    }
                }
            }

            if (filesToDownload.Count == 0)
            {
                if (showNoUpdateMessage)
                    MessageBox.Show("Không tìm thấy file cập nhật!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var result = MessageBox.Show(
                $"Có phiên bản mới: {latestVersion}\n" +
                $"Phiên bản hiện tại: {CURRENT_VERSION}\n" +
                $"Số file cần tải: {filesToDownload.Count}\n\n" +
                $"Bạn có muốn cập nhật không?",
                "Cập nhật mới",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await DownloadAndInstallUpdateAsync(filesToDownload);
                return true;
            }
        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine($"Lỗi kết nối GitHub: {ex.Message}");
            if (showNoUpdateMessage)
                MessageBox.Show("Không thể kết nối đến GitHub để kiểm tra cập nhật.\n" + 
                    "Vui lòng kiểm tra kết nối mạng.", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Lỗi kiểm tra update: {ex.Message}");
            if (showNoUpdateMessage)
                MessageBox.Show($"Lỗi kiểm tra cập nhật: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return false;
    }

    private static async Task DownloadAndInstallUpdateAsync(System.Collections.Generic.List<(string Url, string FileName)> filesToDownload)
    {
        try
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "QLTK_Update");
            Directory.CreateDirectory(tempDir);

            using (var progressForm = new UpdateProgressForm())
            {
                progressForm.Show();

                var downloadedFiles = new System.Collections.Generic.List<string>();

                // Tải xuống từng file
                for (int i = 0; i < filesToDownload.Count; i++)
                {
                    var (url, fileName) = filesToDownload[i];
                    string tempFile = Path.Combine(tempDir, fileName);

                    progressForm.UpdateStatus($"Đang tải {fileName}... ({i + 1}/{filesToDownload.Count})");

                    using (var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                        var canReportProgress = totalBytes != -1;

                        using (var contentStream = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = new FileStream(tempFile, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
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
                                    var progress = (int)((totalRead * 100) / totalBytes);
                                    progressForm.UpdateProgress(progress);
                                }

                                Application.DoEvents();
                            }
                        }
                    }

                    downloadedFiles.Add(tempFile);
                    Debug.WriteLine($"✅ Đã tải: {fileName}");
                }

                progressForm.UpdateStatus("Đang cài đặt...");
                await Task.Delay(500);

                // Tạo batch script để update tất cả các file
                string currentExe = Application.ExecutablePath;
                string appDir = Path.GetDirectoryName(currentExe);
                string batchFile = Path.Combine(Path.GetTempPath(), "update.bat");

                var batchLines = new System.Collections.Generic.List<string>
                {
                    "@echo off",
                    "timeout /t 2 /nobreak > nul",
                    $"taskkill /f /im \"{Path.GetFileName(currentExe)}\" > nul 2>&1",
                    "timeout /t 1 /nobreak > nul"
                };

                // Copy từng file
                foreach (var tempFile in downloadedFiles)
                {
                    string fileName = Path.GetFileName(tempFile);
                    string targetFile = Path.Combine(appDir, fileName);
                    batchLines.Add($"copy /y \"{tempFile}\" \"{targetFile}\"");
                    batchLines.Add("echo Updated: " + fileName);
                }

                // Dọn dẹp và kết thúc
                batchLines.Add("timeout /t 1 /nobreak > nul");
                batchLines.Add($"rd /s /q \"{tempDir}\"");
                batchLines.Add("del \"%~f0\"");

                string batchContent = string.Join("\r\n", batchLines);
                File.WriteAllText(batchFile, batchContent);

                var psi = new ProcessStartInfo
                {
                    FileName = batchFile,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(psi);

                Application.Exit();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static int CompareVersions(string current, string latest)
    {
        try
        {
            var currentParts = current.Split('.').Select(int.Parse).ToArray();
            var latestParts = latest.Split('.').Select(int.Parse).ToArray();
            
            int maxLength = Math.Max(currentParts.Length, latestParts.Length);
            
            for (int i = 0; i < maxLength; i++)
            {
                int currentPart = i < currentParts.Length ? currentParts[i] : 0;
                int latestPart = i < latestParts.Length ? latestParts[i] : 0;
                
                if (currentPart < latestPart) return -1;
                if (currentPart > latestPart) return 1;
            }
            
            return 0;
        }
        catch
        {
            return 0;
        }
    }
}
