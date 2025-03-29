using System.Management;
using System.Globalization;
namespace Essential_AIO_for_Essence_OS.UserControls
{
    public partial class SystemInformation : UserControl
    {
        public SystemInformation()
        {
            InitializeComponent();
            LoadSystemInformation();
            _ = LoadPublicIPAsync();
        }

        private void LoadSystemInformation()
        {
            labelHostName.Text = $"Host: {Environment.MachineName}";
            labelUserName.Text = $"User: {Environment.UserName}";

            try
            {
                var osSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject os in osSearcher.Get().Cast<ManagementObject>())
                {
                    string caption = os["Caption"]?.ToString() ?? "Unknown";
                    string version = os["Version"]?.ToString() ?? "Unknown";
                    string buildNumber = os["BuildNumber"]?.ToString() ?? "Unknown";
                    string architecture = os["OSArchitecture"]?.ToString() ?? "Unknown";
                    string activationStatus = "Unknown";

                    labelOSName.Text = $"OS: {caption}";
                    labelOSVersion.Text = $"Version: {version}";
                    labelOSBuild.Text = $"Build: {buildNumber}";
                    labelOSMode.Text = $"Arch: {architecture}";
                    labelOSActivationStatus.Text = $"Activation: {activationStatus}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving OS information: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                var csSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
                foreach (ManagementObject cs in csSearcher.Get().Cast<ManagementObject>())
                {
                    string model = cs["Model"]?.ToString() ?? "Unknown";
                    string systemType = cs["SystemType"]?.ToString() ?? "Unknown";

                    labelSystemModel.Text = $"Model: {model}";
                    labelSystemType.Text = $"Type: {systemType}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving System Model: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                var biosSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                foreach (ManagementObject bios in biosSearcher.Get().Cast<ManagementObject>())
                {
                    string serialNumber = bios["SerialNumber"]?.ToString() ?? "Unknown";
                    string biosVersion = "Unknown";

                    if (bios["BIOSVersion"] is string[] biosVersions)
                    {
                        biosVersion = string.Join(" ", biosVersions);
                    }
                    else if (bios["SMBIOSBIOSVersion"] != null)
                    {
                        biosVersion = bios["SMBIOSBIOSVersion"]?.ToString() ?? "Unknown";
                    }

                    labelSerialNumber.Text = $"Serial: {serialNumber}";
                    labelBIOSVersion.Text = $"BIOS: {biosVersion}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving BIOS info: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                var procSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                foreach (ManagementObject proc in procSearcher.Get().Cast<ManagementObject>())
                {
                    string procName = proc["Name"]?.ToString() ?? "Unknown";
                    uint cores = (uint)(proc["NumberOfCores"] ?? 0);
                    uint logicalProcessors = (uint)(proc["NumberOfLogicalProcessors"] ?? 0);

                    labelProcessorName.Text = $"CPU: {procName}";
                    labelProcessorCores.Text = $"Cores/Threads: {cores}/{logicalProcessors}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving Processor info: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                var tz = TimeZoneInfo.Local;
                labelTimeZone.Text = $"Time Zone: {tz.DisplayName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving Time Zone: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async System.Threading.Tasks.Task LoadPublicIPAsync()
        {
            try
            {
                using var client = new HttpClient();
                string publicIP = await client.GetStringAsync("https://api.ipify.org");
                labelPublicIP.Text = $"Public IP: {publicIP}";
            }
            catch
            {
                labelPublicIP.Text = "Public IP: Unknown";
            }
        }
        private static string ParseWmiDate(string? wmiDate)
        {
            if (string.IsNullOrEmpty(wmiDate))
                return "Unknown";

            try
            {
                string datePart = wmiDate[..14];
                DateTime dt = DateTime.ParseExact(datePart, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                return dt.ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch
            {
                return "Unknown";
            }
        }
    }
}