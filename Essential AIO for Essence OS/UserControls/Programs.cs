using Essential_AIO_for_Essence_OS.Models;
using System.Diagnostics;

namespace Essential_AIO_for_Essence_OS.UserControls
{
    public partial class Programs : UserControl
    {
        public Programs()
        {
            InitializeComponent();
            LoadProgramItems();
        }

        private void LoadProgramItems()
        {
            var packages = new List<PackageModel>
            {
                new() {
                    Title = "Google Chrome",
                    Description = "Popular web browser",
                    DownloadUrl64 = "https://dl.google.com/chrome/install/latest/chrome_installer.exe",
                    DonwloadUrl86 = "",
                    Category = "Browsers",
                    IconPath = Properties.Resources.Chrome
                },
                new() {
                    Title = "FireFox",
                    Description = "Popular Chrome replacement browser",
                    DownloadUrl64 = "https://www.mozilla.org/pt-PT/firefox/download/thanks/",
                    DonwloadUrl86 = "",
                    Category = "Browsers",
                    IconPath = Properties.Resources.FireFox
                },
                new() {
                    Title = "Brave",
                    Description = "A fast, secure browser that blocks ads and trackers by default.",
                    DownloadUrl64 = "https://laptop-updates.brave.com/download/BRV010?bitness=64",
                    DonwloadUrl86 = "",
                    Category = "Browsers",
                    IconPath = Properties.Resources.Brave
                },
                new() {
                    Title = "Opera",
                    Description = "A fast, secure browser with a built-in VPN and ad blocker, designed for smooth browsing.",
                    DownloadUrl64 = "https://net.geo.opera.com/opera/stable/windows?utm_tryagain=yes&utm_source=google-ads&utm_medium=ba_ose&utm_campaign=%252300%2520-%2520WW%2520-%2520Search%2520-%2520EN%2520-%2520Branded&utm_content=37670026502&utm_id=gclidCj0KCQjwhYS_BhD2ARIsAJTMMQYlL_4jYnpHYogPBzA5Px4LZgY_2HApRHznH61WScOdHGHcTaBfsVMaAt8eEALw_wcB&http_referrer=https%3A%2F%2Fwww.google.com%2F&utm_site=opera_com&&utm_lastpage=opera.com/",
                    DonwloadUrl86 = "",
                    Category = "Browsers",
                    IconPath = Properties.Resources.Opera
                },
                new() {
                    Title = "Opera GX",
                    Description = "A gaming-focused browser with CPU, RAM, and network limiters, plus built-in Twitch and Discord integration.",
                    DownloadUrl64 = "https://www.opera.com/pt/computer/thanks?ni=eapgx&os=windows&edition=std-2",
                    DonwloadUrl86 = "",
                    Category = "Browsers",
                    IconPath = Properties.Resources.Opera_GX
                },
                new() {
                    Title = "7-Zip",
                    Description = "7-Zip is a free file archiver with a high compression ratio, supporting multiple formats like 7z, ZIP, and more.",
                    DownloadUrl64 = "https://www.7-zip.org/a/7z2409-x64.exe",
                    DonwloadUrl86 = "https://www.7-zip.org/a/7z2409.exe",
                    Category = "Archiver/Extractor",
                    IconPath = Properties.Resources._7Zip
                },
                new() {
                    Title = "WinRAR",
                    Description = "WinRAR is a popular compression tool that supports formats like RAR and ZIP with strong features.",
                    DownloadUrl64 = "https://www.win-rar.com/postdownload.html?&L=0",
                    DonwloadUrl86 = "",
                    Category = "Archiver/Extractor",
                    IconPath = Properties.Resources.WinRAR
                },
                new()
                {
                    Title = "VLC Media Player",
                    Description = "VLC Media Player is a free and open-source multimedia player that supports various audio and video formats without the need for additional codecs.",
                    DownloadUrl64 = "https://ftp.rnl.tecnico.ulisboa.pt/pub/videolan/vlc/3.0.21/win64/vlc-3.0.21-win64.exe",
                    DonwloadUrl86 = "https://ftp.rnl.tecnico.ulisboa.pt/pub/videolan/vlc/3.0.21/win32/vlc-3.0.21-win32.exe",
                    Category = "Useful Programs",
                    IconPath = Properties.Resources.VLC
                },
                new()
                {
                    Title = "ShareX",
                    Description = "ShareX is a free and open-source screen capture and file-sharing tool with powerful customization options.",
                    DownloadUrl64 = "https://github.com/ShareX/ShareX/releases/download/v17.0.0/ShareX-17.0.0-setup.exe",
                    DonwloadUrl86 = "",
                    Category = "Useful Programs",
                    IconPath = Properties.Resources.ShareX
                }
            };

            flowLayoutPanelPackages.Controls.Clear();

            var categorias = packages.Select(p => p.Category).Distinct();

            foreach (var categoria in categorias)
            {
                var lblCategoria = new Label
                {
                    Text = categoria,
                    AutoSize = false,
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    Height = 35,
                    Width = flowLayoutPanelPackages.Width - 27,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(0, 5, 5, 5),
                    Margin = new Padding(0, 0, 10, 0),
                    BackColor = Color.FromArgb(30, 30, 30),
                    ForeColor = Color.White
                };

                flowLayoutPanelPackages.Controls.Add(lblCategoria);

                var categoryPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    WrapContents = true,
                    Padding = new Padding(0),
                    Margin = new Padding(0, 0, 0, 0),
                    BackColor = Color.FromArgb(45, 45, 45)
                };

                var pacotesDaCategoria = packages.Where(p => p.Category == categoria);

                foreach (var pkg in pacotesDaCategoria)
                {
                    var item = new PackageItem
                    {
                        Title = pkg.Title,
                        Description = pkg.Description,
                        DonwloadUrl86 = pkg.DonwloadUrl86,
                        DownloadUrl64 = pkg.DownloadUrl64,
                        Icon = pkg.IconPath,
                        Category = pkg.Category
                    };

                    item.DownloadClicked += Item_DownloadClicked;

                    categoryPanel.Controls.Add(item);
                }
                flowLayoutPanelPackages.Controls.Add(categoryPanel);
            }
        }

        private async void Item_DownloadClicked(object? sender, EventArgs e)
        {
            if (sender is PackageItem item)
            {
                try
                {
                    string downloadUrl = string.Empty;

                    if (!string.IsNullOrEmpty(item.DownloadUrl64) && !string.IsNullOrEmpty(item.DonwloadUrl86))
                    {
                        using var versionForm = new VersionSelectionForm();
                        var result = versionForm.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            downloadUrl = versionForm.SelectedVersion == "64-bit" ? item.DownloadUrl64 : item.DonwloadUrl86;
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else
                    {
                        downloadUrl = !string.IsNullOrEmpty(item.DownloadUrl64) ? item.DownloadUrl64 : item.DonwloadUrl86;
                    }

                    if (string.IsNullOrEmpty(downloadUrl))
                    {
                        MessageBox.Show("No download URL available for the selected version.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!(downloadUrl.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) ||
                          downloadUrl.EndsWith(".msi", StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("The link does not point to a direct installer. Opening in browser...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = downloadUrl,
                            UseShellExecute = true
                        });
                        return;
                    }

                    lblDownload.Text = $"Downloading... {item.Title}";

                    string fileName = Path.GetFileName(downloadUrl);
                    if (string.IsNullOrEmpty(Path.GetExtension(fileName)))
                    {
                        fileName += ".exe";
                    }

                    string tempFilePath = Path.Combine(Path.GetTempPath(), fileName);

                    using (HttpClient httpClient = new())
                    {
                        byte[] fileBytes = await httpClient.GetByteArrayAsync(downloadUrl);
                        await File.WriteAllBytesAsync(tempFilePath, fileBytes);
                    }

                    try
                    {
                        RunWithElevatedPermissions(tempFilePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error running installer with elevated permissions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    lblDownload.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error downloading and running the installer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void RunWithElevatedPermissions(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            ProcessStartInfo startInfo;
            if (extension == ".msi")
            {
                startInfo = new ProcessStartInfo
                {
                    FileName = "msiexec",
                    Arguments = $"/i \"{filePath}\"",
                    Verb = "runas",
                    UseShellExecute = true
                };
            }
            else
            {
                startInfo = new ProcessStartInfo
                {
                    FileName = filePath,
                    Verb = "runas",
                    UseShellExecute = true
                };
            }

            try
            {
                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                if (ex.NativeErrorCode == 1223)
                {
                    MessageBox.Show("The operation was canceled by the user.", "Elevated Permissions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"An error occurred while trying to run the installer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
