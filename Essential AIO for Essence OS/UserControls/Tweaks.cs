using System.Diagnostics;
using Microsoft.Win32;
using Essential_AIO_for_Essence_OS.Helpers;

namespace Essential_AIO_for_Essence_OS.UserControls
{
    public partial class Tweaks : UserControl
    {
        public Tweaks()
        {
            InitializeComponent();
            FormHelper.ArredondarBotao(btnApplyTweaks, 15);
            FormHelper.ArredondarBotao(btnRestoreDefaults, 15);
            TweaksHelper.LoadSettings();
        }

        private void BtnApplyTweaks_Click(object sender, EventArgs e)
        {
            TweaksSettings settings = new()
            {
                // Essential Tweaks
                DeleteTemporaryFiles = chkDeleteTemporaryFiles.Checked,
                DisableConsumerFeatures = chkDisableConsumerFeatures.Checked,
                DisableTelemetry = chkDisableTelemetry.Checked,
                DisableActivityHistory = chkDisableActivityHistory.Checked,
                DisableGameDVR = chkDisableGameDVR.Checked,
                DisableHibernation = chkDisableHibernation.Checked,
                DisableHomeGroup = chkDisableHomeGroup.Checked,
                DisableLocationTracker = chkDisableLocationTracker.Checked,
                DisableStorageSense = chkDisableStorageSense.Checked,
                DisableWifiSense = chkDisableWifiSense.Checked,
                EnableEndTaskRightClick = chkEnableEndTaskRightClick.Checked,
                RunDiskCleanup = chkRunDiskCleanup.Checked,
                DisablePowerShell7Telemetry = chkDisablePowerShell7Telemetry.Checked,
                SetServicesToManual = chkSetServicesToManual.Checked,

                // Advance Tweaks
                DisableMicrosoftCopilot = chkDisableMicrosoftCopilot.Checked,
                RemoveMicrosoftEdge = chkRemoveMicrosoftEdge.Checked,
                RemoveHomeAndGalleryFromExplorer = chkRemoveHomeAndGalleryFromExplorer.Checked,
                RemoveOneDrive = chkRemoveOneDrive.Checked,

                // Preference Tweaks
                DarkThemeForWindows = chkDarkThemeForWindows.Checked,
                BingSearchInStartMenu = chkBingSearchInStartMenu.Checked,
                RecommendationsInStartMenu = chkRecommendationsInStartMenu.Checked,
                ShowHiddenFiles = chkShowHiddenFiles.Checked,
                ShowFileExtensions = chkShowFileExtensions.Checked,
                SearchButtonInTaskBar = chkSearchButtonInTaskBar.Checked,
                TaskViewButtonInTaskBar = chkTaskViewButtonInTaskBar.Checked,
                CenterTaskItems = chkCenterTaskItems.Checked,
                WidgetsButtonInTaskBar = chkWidgetsButtonInTaskBar.Checked
            };

            // Essential Tweaks
            if (chkDeleteTemporaryFiles.Checked) DeleteTemporaryFiles();
            if (chkDisableConsumerFeatures.Checked) DisableConsumerFeatures();
            if (chkDisableTelemetry.Checked) DisableTelemetry();
            if (chkDisableActivityHistory.Checked) DisableActivityHistory();
            if (chkDisableGameDVR.Checked) DisableGameDVR();
            if (chkDisableHibernation.Checked) DisableHibernation();
            if (chkDisableHomeGroup.Checked) DisableHomeGroup();
            if (chkDisableLocationTracker.Checked) DisableLocationTracker();
            if (chkDisableStorageSense.Checked) DisableStorageSense();
            if (chkDisableWifiSense.Checked) DisableWifiSense();
            if (chkEnableEndTaskRightClick.Checked) EnableEndTaskWithRightClick();
            if (chkRunDiskCleanup.Checked) RunDiskCleanup();
            if (chkDisablePowerShell7Telemetry.Checked) DisablePowerShell7Telemetry();
            if (chkSetServicesToManual.Checked) SetServicesToManual();

            // Advance Tweaks
            if (chkDisableMicrosoftCopilot.Checked) DisableMicrosoftCopilot();
            if (chkRemoveMicrosoftEdge.Checked) RemoveMicrosoftEdge();
            if (chkRemoveHomeAndGalleryFromExplorer.Checked) RemoveHomeAndGalleryFromExplorer();
            if (chkRemoveOneDrive.Checked) RemoveOneDrive();

            // Preference Tweaks
            if (chkDarkThemeForWindows.Checked) EnableDarkThemeForWindows();
            if (chkBingSearchInStartMenu.Checked) SetBingSearchInStartMenu();
            if (chkRecommendationsInStartMenu.Checked) EnableRecommendationsInStartMenu();
            if (chkShowHiddenFiles.Checked) ShowHiddenFiles();
            if (chkShowFileExtensions.Checked) ShowFileExtensions();
            if (chkSearchButtonInTaskBar.Checked) ShowSearchButtonInTaskBar();
            if (chkTaskViewButtonInTaskBar.Checked) ShowTaskViewButtonInTaskBar();
            if (chkCenterTaskItems.Checked) CenterTaskItems();
            if (chkWidgetsButtonInTaskBar.Checked) ShowWidgetsButtonInTaskBar();
            TweaksHelper.SaveSettings(settings, TweaksHelper.GetOptions());
            MessageBox.Show("Tweaks applied successfully!", "Tweaks", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnRestoreDefaults_Click(object sender, EventArgs e)
        {
            RestoreDefaults();
        }

        #region Essential Tweaks Methods

        private static void DeleteTemporaryFiles()
        {
            try
            {
                string tempPath = Path.GetTempPath();
                DirectoryInfo di = new(tempPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    try { file.Delete(); }
                    catch { /* Ignorar erros em arquivos bloqueados */ }
                }

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try { dir.Delete(true); }
                    catch { /* Ignorar erros em pastas bloqueadas */ }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting temporary files: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void DisableConsumerFeatures()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\CloudContent",
                    "DisableConsumerFeatures",
                    1,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disabling Consumer Features: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void DisableTelemetry()
        {
            try
            {
                object? value = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection", "AllowTelemetry", null);
                bool telemetryDisabled = (value != null && Convert.ToInt32(value) == 0);

                if (!telemetryDisabled)
                {
                    Registry.SetValue(
                        @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection",
                        "AllowTelemetry",
                        0,
                        RegistryValueKind.DWord
                    );

                    MessageBox.Show("Telemetry disabled successfully. System restart may be required.",
                                    "Sucesso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Telemetry is already disabled.",
                                    "Informação",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disabling Telemetry: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void DisableActivityHistory()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System",
                    "PublishUserActivities",
                    0,
                    RegistryValueKind.DWord
                );

                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Privacy",
                    "TailoredExperiencesWithDiagnosticDataEnabled",
                    0,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disabling Activity History: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void DisableGameDVR()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\System\GameConfigStore",
                    "GameDVR_Enabled",
                    0,
                    RegistryValueKind.DWord
                );

                Registry.SetValue(
                    @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR",
                    "AppCaptureEnabled",
                    0,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disabling Game DVR: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void DisableHibernation()
        {
            try
            {
                ProcessStartInfo psi = new("powercfg", "/hibernate off")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi)?.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disabling hibernation: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void DisableHomeGroup()
        {
            try
            {
                ProcessStartInfo psi1 = new("sc", "config HomeGroupListener start= disabled")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi1)?.WaitForExit();

                ProcessStartInfo psi2 = new("sc", "config HomeGroupProvider start= disabled")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi2)?.WaitForExit();

                ProcessStartInfo psi3 = new("net", "stop HomeGroupListener")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi3);

                ProcessStartInfo psi4 = new("net", "stop HomeGroupProvider")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disabling HomeGroup: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void DisableLocationTracker()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\LocationAndSensors",
                    "DisableLocation",
                    1,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disabling Location Tracker: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void DisableStorageSense()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\StorageSense",
                    "AllowStorageSenseGlobal",
                    0,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disabling Storage Sense: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void DisableWifiSense()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config",
                    "AutoConnectAllowedOEM",
                    0,
                    RegistryValueKind.DWord
                );
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config",
                    "AutoConnectAllowed",
                    0,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disabling Wi-Fi Sense: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void EnableEndTaskWithRightClick()
        {
            try
            {
                using RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"exefile\shell\End Task\command");
                key?.SetValue("", "taskkill /F /IM \"%1\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enabling 'End Task' with right click: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void RunDiskCleanup()
        {
            try
            {
                ProcessStartInfo psi = new("cleanmgr.exe")
                {
                    Verb = "runas",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running Disk Cleanup: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void DisablePowerShell7Telemetry()
        {
            try
            {
                Environment.SetEnvironmentVariable("POWERSHELL_TELEMETRY_OPTOUT", "1", EnvironmentVariableTarget.Machine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disabling PowerShell 7 Telemetry: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void SetServicesToManual()
        {
            try
            {
                ProcessStartInfo psi = new("sc", "config DiagTrack start= demand")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi)?.WaitForExit();

                ProcessStartInfo psiStop = new("net", "stop DiagTrack")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psiStop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting services to Manual: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Advance Tweaks Methods

        private static void DisableMicrosoftCopilot()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\Windows Copilot",
                    "TurnOffWindowsCopilot",
                    1,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disabling Microsoft Copilot: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void RemoveMicrosoftEdge()
        {
            try
            {
                ProcessStartInfo psi = new("powershell",
                    "Get-AppxPackage *MicrosoftEdge* | Remove-AppxPackage")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi)?.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing Microsoft Edge: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void RemoveHomeAndGalleryFromExplorer()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "LaunchTo",
                    1,
                    RegistryValueKind.DWord
                );

                using RegistryKey key = Registry.CurrentUser.CreateSubKey(
                    @"Software\Classes\CLSID\{E8885EAD-9D08-4698-8FDC-0C23F4C8BA57}", true);
                key?.SetValue("System.IsPinnedToNameSpaceTree", 0, RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing Home and Gallery from Explorer: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void RemoveOneDrive()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\OneDrive",
                    "DisableFileSyncNGSC",
                    1,
                    RegistryValueKind.DWord
                );

                string systemRoot = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                string oneDriveSetupPath = Path.Combine(systemRoot, "SysWOW64", "OneDriveSetup.exe");

                if (!File.Exists(oneDriveSetupPath))
                {
                    oneDriveSetupPath = Path.Combine(systemRoot, "System32", "OneDriveSetup.exe");
                }

                if (File.Exists(oneDriveSetupPath))
                {
                    ProcessStartInfo psi = new(oneDriveSetupPath, "/uninstall")
                    {
                        Verb = "runas",
                        UseShellExecute = true,
                        CreateNoWindow = true
                    };
                    Process.Start(psi)?.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing OneDrive: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Preference Tweaks Methods

        private static void EnableDarkThemeForWindows()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                    "AppsUseLightTheme",
                    0,
                    RegistryValueKind.DWord
                );
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                    "SystemUsesLightTheme",
                    0,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error activating dark theme: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void SetBingSearchInStartMenu()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search",
                    "BingSearchEnabled",
                    1,
                    RegistryValueKind.DWord
                );
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search",
                    "CortanaConsent",
                    1,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enabling Bing Search in the Start Menu: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void EnableRecommendationsInStartMenu()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "Start_Recommendations",
                    1,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enabling recommendations in the Start Menu: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void ShowHiddenFiles()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "Hidden",
                    1,
                    RegistryValueKind.DWord
                );
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "ShowSuperHidden",
                    1,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing hidden files: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void ShowFileExtensions()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "HideFileExt",
                    0,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing file extensions: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void ShowSearchButtonInTaskBar()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search",
                    "SearchboxTaskbarMode",
                    1,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing search button on Taskbar: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void ShowTaskViewButtonInTaskBar()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "ShowTaskViewButton",
                    1,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing Task View on Taskbar: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void CenterTaskItems()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "TaskbarAl",
                    1,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error centering items on the Taskbar: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private static void ShowWidgetsButtonInTaskBar()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "TaskbarDa",
                    2,
                    RegistryValueKind.DWord
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing Widgets on Taskbar: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #endregion

        private static void RestoreDefaults()
        {
            try
            {
                // Essential Tweaks
                RestoreConsumerFeatures();
                RestoreTelemetry();
                RestoreActivityHistory();
                RestoreGameDVR();
                RestoreHibernation();
                RestoreHomeGroup();
                RestoreLocationTracker();
                RestoreStorageSense();
                RestoreWifiSense();
                RestoreEndTaskRightClick();
                RestorePowerShell7Telemetry();
                RestoreServicesToManual();

                // Advance Tweaks
                RestoreMicrosoftCopilot();
                RestoreHomeAndGalleryFromExplorer();
                RestoreOneDrive();

                // Preference Tweaks
                RestoreDarkThemeForWindows();
                RestoreBingSearchInStartMenu();
                RestoreRecommendationsInStartMenu();
                RestoreShowHiddenFiles();
                RestoreShowFileExtensions();
                RestoreSearchButtonInTaskBar();
                RestoreTaskViewButtonInTaskBar();
                RestoreCenterTaskItems();
                RestoreWidgetsButtonInTaskBar();

                MessageBox.Show("Default settings restored successfully!", "Tweaks", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error restoring default settings: {ex.Message}",
                                "Tweaks",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #region Restore Methods

        private static void RestoreConsumerFeatures()
        {
            try
            {
                RegistryKey? key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CloudContent", true);
                key?.DeleteValue("DisableConsumerFeatures", false);
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreTelemetry()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection",
                    "AllowTelemetry",
                    3,
                    RegistryValueKind.DWord
                );
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreActivityHistory()
        {
            try
            {
                RegistryKey? key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System", true);
                key?.DeleteValue("PublishUserActivities", false);

                RegistryKey? key2 = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Privacy", true);
                key2?.DeleteValue("TailoredExperiencesWithDiagnosticDataEnabled", false);
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreGameDVR()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\System\GameConfigStore",
                    "GameDVR_Enabled",
                    1,
                    RegistryValueKind.DWord
                );

                Registry.SetValue(
                    @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR",
                    "AppCaptureEnabled",
                    1,
                    RegistryValueKind.DWord
                );
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreHibernation()
        {
            try
            {
                ProcessStartInfo psi = new("powercfg", "/hibernate on")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi)?.WaitForExit();
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreHomeGroup()
        {
            try
            {
                ProcessStartInfo psi1 = new("sc", "config HomeGroupListener start= manual")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi1)?.WaitForExit();

                ProcessStartInfo psi2 = new("sc", "config HomeGroupProvider start= manual")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi2)?.WaitForExit();
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreLocationTracker()
        {
            try
            {
                RegistryKey? key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\LocationAndSensors", true);
                key?.DeleteValue("DisableLocation", false);
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreStorageSense()
        {
            try
            {
                RegistryKey? key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\StorageSense", true);
                key?.DeleteValue("AllowStorageSenseGlobal", false);
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreWifiSense()
        {
            try
            {
                RegistryKey? key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config", true);
                if (key != null)
                {
                    key.DeleteValue("AutoConnectAllowedOEM", false);
                    key.DeleteValue("AutoConnectAllowed", false);
                }
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreEndTaskRightClick()
        {
            try
            {
                RegistryKey? shellKey = Registry.ClassesRoot.OpenSubKey(@"exefile\shell", true);
                shellKey?.DeleteSubKeyTree("End Task", false);
            }
            catch { /* Ignorar */ }
        }

        private static void RestorePowerShell7Telemetry()
        {
            try
            {
                Environment.SetEnvironmentVariable("POWERSHELL_TELEMETRY_OPTOUT", null, EnvironmentVariableTarget.Machine);
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreServicesToManual()
        {
            try
            {
                ProcessStartInfo psi = new("sc", "config DiagTrack start= auto")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi)?.WaitForExit();
            }
            catch { /* Ignorar */ }
        }

        // Advance Tweaks Restore Methods
        private static void RestoreMicrosoftCopilot()
        {
            try
            {
                RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Software\Policies\Microsoft\Windows\Windows Copilot", true);
                key?.DeleteValue("TurnOffWindowsCopilot", false);
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreHomeAndGalleryFromExplorer()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "LaunchTo",
                    3,
                    RegistryValueKind.DWord
                );

                using RegistryKey key = Registry.CurrentUser.CreateSubKey(
                    @"Software\Classes\CLSID\{E8885EAD-9D08-4698-8FDC-0C23F4C8BA57}", true);
                key?.SetValue("System.IsPinnedToNameSpaceTree", 1, RegistryValueKind.DWord);
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreOneDrive()
        {
            try
            {
                RegistryKey? key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\OneDrive", true);
                key?.DeleteValue("DisableFileSyncNGSC", false);
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreDarkThemeForWindows()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                    "AppsUseLightTheme",
                    1,
                    RegistryValueKind.DWord
                );
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                    "SystemUsesLightTheme",
                    1,
                    RegistryValueKind.DWord
                );
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreBingSearchInStartMenu()
        {
            try
            {
                RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search", true);
                if (key != null)
                {
                    key.DeleteValue("BingSearchEnabled", false);
                    key.DeleteValue("CortanaConsent", false);
                }
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreRecommendationsInStartMenu()
        {
            try
            {
                RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true);
                key?.DeleteValue("Start_Recommendations", false);
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreShowHiddenFiles()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "Hidden",
                    2,
                    RegistryValueKind.DWord
                );
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "ShowSuperHidden",
                    0,
                    RegistryValueKind.DWord
                );
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreShowFileExtensions()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "HideFileExt",
                    1,
                    RegistryValueKind.DWord
                );
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreSearchButtonInTaskBar()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search",
                    "SearchboxTaskbarMode",
                    0,
                    RegistryValueKind.DWord
                );
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreTaskViewButtonInTaskBar()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "ShowTaskViewButton",
                    0,
                    RegistryValueKind.DWord
                );
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreCenterTaskItems()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "TaskbarAl",
                    0,
                    RegistryValueKind.DWord
                );
            }
            catch { /* Ignorar */ }
        }

        private static void RestoreWidgetsButtonInTaskBar()
        {
            try
            {
                Registry.SetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                    "TaskbarDa",
                    0,
                    RegistryValueKind.DWord
                );
            }
            catch { /* Ignorar */ }
        }

        #endregion
    }
}