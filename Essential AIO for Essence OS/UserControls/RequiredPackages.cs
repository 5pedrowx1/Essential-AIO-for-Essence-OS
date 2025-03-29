using Essential_AIO_for_Essence_OS.Models;
using System.Diagnostics;

namespace Essential_AIO_for_Essence_OS.UserControls
{
    public partial class RequiredPackages : UserControl
    {
        public RequiredPackages()
        {
            InitializeComponent();
            LoadPackageItems();
        }

        private void LoadPackageItems()
        {
            var packages = new List<PackageModel>
            {
                new() {
                    Title = "Visual C ++",
                    Description = "Many programs and games require the Microsoft Visual C++ Redistributable to run, as it installs necessary runtime libraries and DLL files. Without it, some software may not work properly",
                    DownloadUrl64 = "https://aka.ms/vs/17/release/vc_redist.x64.exe",
                    DonwloadUrl86 = "https://aka.ms/vs/17/release/vc_redist.x86.exe",
                    Category =  "",
                    IconPath = Properties.Resources.Visual_C__
                },
                new()
                {
                    Title = "DirectX",
                    Description = "DirectX is a set of APIs that enables software, particularly games, to interact with hardware like graphics cards. It is essential for running many Windows games and applications smoothly.",
                    DownloadUrl64 = "",
                    DonwloadUrl86 = "https://download.microsoft.com/download/1/7/1/1718ccc4-6315-4d8e-9543-8e28a4e18c4c/dxwebsetup.exe",
                    Category =  "",
                    IconPath = Properties.Resources.DirectX
                },
                new()
                {
                    Title = ".NET Framework",
                    Description = "Many Windows applications rely on the .NET Framework to run. It provides essential libraries and runtime components for proper execution. Without it, some programs may not work.",
                    DownloadUrl64 = "https://dotnet.microsoft.com/pt-br/download/dotnet-framework/thank-you/net48-web-installer",
                    DonwloadUrl86 = "",
                    Category =  "",
                    IconPath = Properties.Resources._NET_Framework
                },
                new()
                {
                    Title = "XNA Framework",
                    Description = "XNA Framework provides libraries for game development on Windows. It's essential for running games built with XNA. Without it, these games won't work properly.",
                    DownloadUrl64 = "https://download.microsoft.com/download/a/c/2/ac2c903b-e6e8-42c2-9fd7-bebac362a930/xnafx40_redist.msi",
                    DonwloadUrl86 = "",
                    Category =  "",
                    IconPath = Properties.Resources.XNA_Framwork
                },
                new()
                {
                    Title = "OpenAL",
                    Description = "OpenAL is an API for 3D audio, used in games and multimedia applications. It's necessary for sound processing in certain applications.",
                    DownloadUrl64 = "",
                    DonwloadUrl86 = "",
                    Category =  "",
                    IconPath = Properties.Resources.OpenAL
                }
            };

            foreach (var pkg in packages)
            {
                var item = new PackageItem
                {
                    Title = pkg.Title,
                    Description = pkg.Description,
                    DonwloadUrl86 = pkg.DonwloadUrl86,
                    DownloadUrl64 = pkg.DownloadUrl64,
                    Icon = pkg.IconPath
                };

                item.DownloadClicked += Item_DownloadClicked;
                flowLayoutPanelPackages.Controls.Add(item);
            }
        }

        private async void Item_DownloadClicked(object? sender, EventArgs e)
        {
            if (sender is PackageItem item)
            {
                try
                {
                    string downloadUrl = string.Empty;

                    // Se ambos os URLs estiverem preenchidos, pede para o usuário escolher a versão.
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
                            // Cancelado: retorna sem mostrar mensagem.
                            return;
                        }
                    }
                    else
                    {
                        downloadUrl = !string.IsNullOrEmpty(item.DownloadUrl64) ? item.DownloadUrl64 : item.DonwloadUrl86;
                    }

                    // Se após a seleção (ou ausência de múltiplos URLs) a URL estiver vazia,
                    // verifica se realmente não há URL disponível.
                    if (string.IsNullOrEmpty(downloadUrl))
                    {
                        // Se o item não possuir URL, exibe a mensagem.
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