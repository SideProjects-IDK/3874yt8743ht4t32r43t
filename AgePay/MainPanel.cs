using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using AgePay.mainpanel_utils;

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmManualTimeRegister"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmManualTimeRegister timeRegisterForm = new frmManualTimeRegister();
            timeRegisterForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            timeRegisterForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmEmployeeProfile"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmEmployeeProfile employeeForm = new frmEmployeeProfile();
            employeeForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            employeeForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmEditTimeRegister"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmEditTimeRegister timeRegisterForm = new frmEditTimeRegister();
            timeRegisterForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            timeRegisterForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmExportAttendance"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmExportAttendance exportForm = new frmExportAttendance();
            exportForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            exportForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmEditHoliday"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmEditHoliday timeRegisterForm = new frmEditHoliday();
            timeRegisterForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            timeRegisterForm.Show();
        }

        private void btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmImportData"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmImportData importForm = new frmImportData();
            importForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            importForm.Show();
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmImportData"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmImportData importForm = new frmImportData();
            importForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            importForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Placeholder for pictureBox1 functionality
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {
            // Optional: run logic on form load
        }

        private void editDailyRegsiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmEditTimeRegister"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmEditTimeRegister timeRegisterForm = new frmEditTimeRegister();
            timeRegisterForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            timeRegisterForm.Show();
        }

        private void manualAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmManualTimeRegister"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmManualTimeRegister timeRegisterForm = new frmManualTimeRegister();
            timeRegisterForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            timeRegisterForm.Show();
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
            this.Hide();
            timeRegisterForm.Show();
        }

        private void employeeProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!HasAccess("frmEmployeeProfile"))
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmEmployeeProfile employeeForm = new frmEmployeeProfile();
            employeeForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            employeeForm.Show();
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
            this.Hide();
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
            this.Hide();
            exportForm.Show();
        }
    }
}