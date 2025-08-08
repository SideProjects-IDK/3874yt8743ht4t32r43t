using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using AgePay.mainpanel_utils;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace AgePay
{
    public partial class MainPanel : Form
    {
        private System.Windows.Forms.Timer panelSlideTimer;
        private bool isPanelExpanded = true;
        private int panelTargetWidth;
        private const int panelCollapsedWidth = 57;
        private const int panelExpandedWidth = 344;
        private const int panelSlideStep = 20;
        private readonly string connectionString = ConnectToSqlDatabase_MsSQL.connectionString;
        private readonly string userPrivileges;

        public static string CurrentVersion = "1.0.0";

        public MainPanel(string privileges)
        {
            userPrivileges = privileges;
            InitializeComponent();
        }

        private bool HasAccess(string formName)
        {
            try
            {
                var privileges = JsonSerializer.Deserialize<List<string>>(userPrivileges) ?? new List<string>();
                return privileges.Contains(formName);
            }
            catch
            {
                return false;
            }
        }

        private void ConfigureButtonAccess()
        {
            // Configure ToolStripMenuItem visibility and enabled state
            editDailyRegsiterToolStripMenuItem.Visible = editDailyRegsiterToolStripMenuItem.Enabled = HasAccess("frmEmployeeProfile");
            manualAttendanceToolStripMenuItem.Visible = manualAttendanceToolStripMenuItem.Enabled = HasAccess("frmEditDepo");
            yearlyHolidaysToolStripMenuItem.Visible = yearlyHolidaysToolStripMenuItem.Enabled = HasAccess("frmEditHoliday");
            dailyAttendanceDataToolStripMenuItem.Visible = dailyAttendanceDataToolStripMenuItem.Enabled = HasAccess("frmImportData");
            monthlyAttendanceDataToolStripMenuItem.Visible = monthlyAttendanceDataToolStripMenuItem.Enabled = HasAccess("frmExportAttendance");
            editTimeToolStripMenuItem.Visible = editTimeToolStripMenuItem.Enabled = HasAccess("frmEditTimeRegister");
            manualAttendanceRegToolStripMenuItem.Visible = manualAttendanceRegToolStripMenuItem.Enabled = HasAccess("frmManualTimeRegister");
            advanceRegisterToolStripMenuItem.Visible = advanceRegisterToolStripMenuItem.Enabled = HasAccess("frmAdvanceRegister");
            loanRegisterToolStripMenuItem.Visible = loanRegisterToolStripMenuItem.Enabled = HasAccess("frmLoanRegister");
            salaryRegisterToolStripMenuItem.Visible = salaryRegisterToolStripMenuItem.Enabled = HasAccess("frmSalaryRegister");
            editUserProvlidgesToolStripMenuItem.Visible = editUserProvlidgesToolStripMenuItem.Enabled = HasAccess("frmEditUserPrivlidges");
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {
            ConfigureButtonAccess();
        }

        private void editDailyRegsiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmEmployeeProfile"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmEmployeeProfile employeeForm = new frmEmployeeProfile();
            employeeForm.FormClosed += (s, args) => this.Show();
            employeeForm.Show();
        }

        private void manualAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmEditDepo"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DepartmentSetup employeeForm = new DepartmentSetup();
            employeeForm.FormClosed += (s, args) => this.Show();
            employeeForm.Show();
        }

        private void yearlyHolidaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmEditHoliday"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmEditHoliday timeRegisterForm = new frmEditHoliday();
            timeRegisterForm.FormClosed += (s, args) => this.Show();
            timeRegisterForm.Show();
        }

        private void employeeProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dailyAttendanceDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmImportData"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmImportData importForm = new frmImportData();
            importForm.FormClosed += (s, args) => this.Show();
            importForm.Show();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void monthlyAttendanceDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmExportAttendance"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmExportAttendance exportForm = new frmExportAttendance();
            exportForm.FormClosed += (s, args) => this.Show();
            exportForm.Show();
        }

        private void aGGIGIHRToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void editTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmEditTimeRegister"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmEditTimeRegister timeRegisterForm = new frmEditTimeRegister();
            timeRegisterForm.FormClosed += (s, args) => this.Show();
            timeRegisterForm.Show();
        }

        private void manualAttendanceRegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmManualTimeRegister"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmManualTimeRegister timeRegisterForm = new frmManualTimeRegister();
            timeRegisterForm.FormClosed += (s, args) => this.Show();
            timeRegisterForm.Show();
        }

        private void advanceRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmAdvanceRegister"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                //throw new NotImplementedException("Advance Register feature is not yet implemented.");
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loanRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmLoanRegister"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                //throw new NotImplementedException("Loan Register feature is not yet implemented.");
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void salaryRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmSalaryRegister"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                //throw new NotImplementedException("Salary Register feature is not yet implemented.");
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editUserProvlidgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmEditUserPrivlidges"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //EditUserPrivlidges userPrivilegesForm = new EditUserPrivlidges();
            //userPrivilegesForm.FormClosed += (s, args) => this.Show();
            //userPrivilegesForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "AgePay");
                    // Optional: Add GitHub token for private repositories
                    // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "your_github_token_here");

                    int newUpdateCount = 0;
                    string repoUrl = "https://api.github.com/repos/SideProjects-IDK/Ag-gigi-ERP/contents/versions";
                    HttpResponseMessage response = await client.GetAsync(repoUrl);
                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            MessageBox.Show("Repository or versions directory not found. Please check the repository URL or authentication.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Error accessing repository: {response.StatusCode} - {response.ReasonPhrase}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var files = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(responseBody);

                    foreach (var file in files)
                    {
                        string fileName = file["name"].ToString();
                        // Only process .txt files that are numeric (e.g., 1.txt, 2.txt)
                        if (fileName.EndsWith(".txt") && int.TryParse(Path.GetFileNameWithoutExtension(fileName), out _))
                        {
                            string versionUrl = file["download_url"].ToString();
                            try
                            {
                                string versionContent = await client.GetStringAsync(versionUrl);
                                if (Version.TryParse(versionContent.Trim(), out Version remoteVersion) &&
                                    Version.TryParse(CurrentVersion, out Version currentVersion))
                                {
                                    if (remoteVersion > currentVersion)
                                    {
                                        newUpdateCount++;
                                    }
                                }
                            }
                            catch (HttpRequestException ex)
                            {
                                // Skip individual file errors to continue checking others
                                continue;
                            }
                        }
                    }

                    if (newUpdateCount > 0)
                    {
                        MessageBox.Show($"There {(newUpdateCount == 1 ? "is" : "are")} {newUpdateCount} new update(s) available!",
                            "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No new updates available.", "Up to Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void updateNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "AgePay");
                    // Optional: Add GitHub token for private repositories
                    // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "your_github_token_here");

                    string repoUrl = "https://api.github.com/repos/SideProjects-IDK/Ag-gigi-ERP/contents/versions";
                    HttpResponseMessage response = await client.GetAsync(repoUrl);
                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            MessageBox.Show("Repository or versions directory not found. Please check the repository URL or authentication.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Error accessing repository: {response.StatusCode} - {response.ReasonPhrase}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var files = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(responseBody);

                    int latestVersionNumber = 0;
                    string latestVersionString = CurrentVersion;
                    Version currentVersion = Version.Parse(CurrentVersion);

                    // Find the latest version by highest numeric .txt filename
                    foreach (var file in files)
                    {
                        string fileName = file["name"].ToString();
                        if (fileName.EndsWith(".txt") && int.TryParse(Path.GetFileNameWithoutExtension(fileName), out int versionNumber))
                        {
                            if (versionNumber > latestVersionNumber)
                            {
                                try
                                {
                                    string versionUrl = file["download_url"].ToString();
                                    string versionContent = await client.GetStringAsync(versionUrl);
                                    if (Version.TryParse(versionContent.Trim(), out Version remoteVersion) &&
                                        remoteVersion > currentVersion)
                                    {
                                        latestVersionNumber = versionNumber;
                                        latestVersionString = remoteVersion.ToString();
                                    }
                                }
                                catch (HttpRequestException)
                                {
                                    // Skip individual file errors
                                    continue;
                                }
                            }
                        }
                    }

                    if (latestVersionNumber > 0)
                    {
                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                        string newExePath = Path.Combine(desktopPath, "AgePay.exe");
                        string oldExePath = Path.Combine(homePath, $"AgePay_{Guid.NewGuid().ToString()}.exe");

                        // Download new executable
                        string exeUrl = $"https://raw.githubusercontent.com/SideProjects-IDK/Ag-gigi-ERP/main/versions/{latestVersionNumber}/AgePay.exe";
                        try
                        {
                            var exeBytes = await client.GetByteArrayAsync(exeUrl);
                            // Backup existing executable if it exists
                            if (File.Exists(newExePath))
                            {
                                File.Move(newExePath, oldExePath);
                            }
                            // Save new executable
                            File.WriteAllBytes(newExePath, exeBytes);
                        }
                        catch (HttpRequestException ex)
                        {
                            MessageBox.Show($"Error downloading executable: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Try to open readme in browser
                        string readmeUrl = $"https://github.com/SideProjects-IDK/Ag-gigi-ERP/blob/main/versions/{latestVersionNumber}/readme.md";
                        try
                        {
                            Process.Start(new ProcessStartInfo(readmeUrl) { UseShellExecute = true });
                        }
                        catch
                        {
                            // Silently handle case where readme doesn't exist
                        }

                        // Start the new executable
                        try
                        {
                            Process.Start(newExePath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error starting new version: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        MessageBox.Show($"Update to version {latestVersionString} downloaded successfully to Desktop!",
                            "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Update current version
                        CurrentVersion = latestVersionString;

                        // Close the current application
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("No newer version available.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}