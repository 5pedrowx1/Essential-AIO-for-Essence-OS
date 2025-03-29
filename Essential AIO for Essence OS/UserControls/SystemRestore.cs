using Essential_AIO_for_Essence_OS.Helpers;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;

namespace Essential_AIO_for_Essence_OS.UserControls
{
    public partial class SystemRestore : UserControl
    {
        [DllImport("srclient.dll", CharSet = CharSet.Unicode)]
        private static extern int SRSetRestorePoint(ref RestorePointInfo pRestoreInfo, out int pState);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct RestorePointInfo
        {
            public int EventType;
            public int RestorePointType;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string Description;
        }

        public SystemRestore()
        {
            InitializeComponent();
            LoadRestorePoints();
            FormHelper.ArredondarBotao(btnCreateRestorePoint, 15);
            FormHelper.ArredondarBotao(btnRestore, 15);
            FormHelper.ArredondarBotao(btnManageSpace, 15);
        }

        public static bool IsSystemProtectionEnabled()
        {
            try
            {
                ProcessStartInfo psi = new()
                {
                    FileName = "cmd.exe",
                    Arguments = "/c vssadmin list shadowstorage",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using Process? process = Process.Start(psi);
                string output = process!.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return !output.Contains("No items found");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking System Protection: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LoadRestorePoints()
        {
            lvRestorePoints.Items.Clear();

            try
            {
                ManagementScope scope = new(@"\\.\root\default");
                scope.Connect();

                ObjectQuery query = new("SELECT * FROM SystemRestore");
                ManagementObjectSearcher searcher = new(scope, query);
                ManagementObjectCollection restorePoints = searcher.Get();

                foreach (ManagementObject restorePoint in restorePoints.Cast<ManagementObject>())
                {
                    string? creationTimeStr = restorePoint["CreationTime"]?.ToString();
                    DateTime creationTime = !string.IsNullOrEmpty(creationTimeStr)
                        ? ManagementDateTimeConverter.ToDateTime(creationTimeStr)
                        : DateTime.MinValue;

                    string description = restorePoint["Description"]?.ToString() ?? "No description";

                    int sequenceNumber = restorePoint["SequenceNumber"] != null
                        ? Convert.ToInt32(restorePoint["SequenceNumber"])
                        : 0;

                    ListViewItem item = new(creationTime.ToString("g"));
                    item.SubItems.Add(description);
                    item.Tag = sequenceNumber;
                    lvRestorePoints.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading restore points: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCreateRestorePoint_Click(object sender, EventArgs e)
        {
            if (!IsSystemProtectionEnabled())
            {
                var result = MessageBox.Show(
                    "System Protection is turned on. To create a restore point, you must temporarily turn it off..\n\nDo you want to open System Protection settings??",
                    "System Protection Enabled",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    string protectionPath = Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess
                                             ? @"C:\Windows\Sysnative\SystemPropertiesProtection.exe"
                                             : @"C:\Windows\System32\SystemPropertiesProtection.exe";

                    Process.Start(protectionPath);
                }

                return;
            }

            try
            {
                RestorePointInfo restoreInfo = new()
                {
                    EventType = 100,
                    RestorePointType = 0,
                    Description = "AIO Restore Point"
                };

                int result = SRSetRestorePoint(ref restoreInfo, out int state);

                if (result == 0)
                {
                    MessageBox.Show("Restore point created successfully.", "Restore Point", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to create restore point. Error code: " + result, "Restore Point Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating restore point: " + ex.Message, "Restore Point Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadRestorePoints();
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            if (lvRestorePoints.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a restore point.", "System Restore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to restore the system to the selected restore point??\n\nThe process will restart the computer.",
                                                  "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Process.Start(@"C:\Windows\Sysnative\rstrui.exe");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error starting system restore: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnManageSpace_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Enter the new maximum size for Shadow Storage (in GB):", "Manage Space", "10");
            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            if (!double.TryParse(input, out double newSize))
            {
                MessageBox.Show("Invalid value. Please enter a number.", "Manage Space", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string vssadminPath = @"C:\Windows\Sysnative\vssadmin.exe";

            try
            {
                ProcessStartInfo psi = new()
                {
                    FileName = vssadminPath,
                    Arguments = $"Resize ShadowStorage /For=C: /On=C: /MaxSize={newSize}GB",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };

                using Process? process = Process.Start(psi);
                string output = process!.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    MessageBox.Show("Shadow storage resized successfully.\n\nOutput: " + output, "Manage Space", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to resize shadow storage.\n\nError: " + error, "Manage Space", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing command: " + ex.Message, "Manage Space", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}