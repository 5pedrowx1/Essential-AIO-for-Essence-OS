using System.Text.Json;

namespace Essential_AIO_for_Essence_OS.Helpers
{
    public class TweaksSettings
    {
        // Essential Tweaks
        public bool DeleteTemporaryFiles { get; set; }
        public bool DisableConsumerFeatures { get; set; }
        public bool DisableTelemetry { get; set; }
        public bool DisableActivityHistory { get; set; }
        public bool DisableGameDVR { get; set; }
        public bool DisableHibernation { get; set; }
        public bool DisableHomeGroup { get; set; }
        public bool DisableLocationTracker { get; set; }
        public bool DisableStorageSense { get; set; }
        public bool DisableWifiSense { get; set; }
        public bool EnableEndTaskRightClick { get; set; }
        public bool RunDiskCleanup { get; set; }
        public bool DisablePowerShell7Telemetry { get; set; }
        public bool SetServicesToManual { get; set; }

        // Advance Tweaks
        public bool DisableMicrosoftCopilot { get; set; }
        public bool RemoveMicrosoftEdge { get; set; }
        public bool RemoveHomeAndGalleryFromExplorer { get; set; }
        public bool RemoveOneDrive { get; set; }

        // Preference Tweaks
        public bool DarkThemeForWindows { get; set; }
        public bool BingSearchInStartMenu { get; set; }
        public bool RecommendationsInStartMenu { get; set; }
        public bool ShowHiddenFiles { get; set; }
        public bool ShowFileExtensions { get; set; }
        public bool SearchButtonInTaskBar { get; set; }
        public bool TaskViewButtonInTaskBar { get; set; }
        public bool CenterTaskItems { get; set; }
        public bool WidgetsButtonInTaskBar { get; set; }
    }

    public static class TweaksHelper
    {
        private static readonly string settingsFilePath = Path.Combine(Application.UserAppDataPath, "tweaksSettings.json");

        public static TweaksSettings LoadSettings()
        {
            try
            {
                if (!File.Exists(settingsFilePath))
                    return new TweaksSettings();

                string json = File.ReadAllText(settingsFilePath);
                var settings = JsonSerializer.Deserialize<TweaksSettings>(json);
                return settings ?? new TweaksSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar configurações: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new TweaksSettings();
            }
        }

        public static JsonSerializerOptions GetOptions()
        {
            return new JsonSerializerOptions { WriteIndented = true };
        }

        public static void SaveSettings(TweaksSettings settings, JsonSerializerOptions options)
        {
            try
            {
                string json = JsonSerializer.Serialize(settings, options);
                File.WriteAllText(settingsFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar configurações: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
