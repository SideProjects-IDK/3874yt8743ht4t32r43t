namespace AgePay
{
    partial class MainPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPanel));
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            aGGIGIHRToolStripMenuItem = new ToolStripMenuItem();
            editDailyRegsiterToolStripMenuItem = new ToolStripMenuItem();
            manualAttendanceToolStripMenuItem = new ToolStripMenuItem();
            yearlyHolidaysToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            dailyAttendanceDataToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            monthlyAttendanceDataToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            editUserProvlidgesToolStripMenuItem = new ToolStripMenuItem();
            employeeProfileToolStripMenuItem = new ToolStripMenuItem();
            editTimeToolStripMenuItem = new ToolStripMenuItem();
            manualAttendanceRegToolStripMenuItem = new ToolStripMenuItem();
            advanceRegisterToolStripMenuItem = new ToolStripMenuItem();
            loanRegisterToolStripMenuItem = new ToolStripMenuItem();
            salaryRegisterToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            updateToolStripMenuItem = new ToolStripMenuItem();
            checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
            updateNowToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(295, 245);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += PictureBox1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { aGGIGIHRToolStripMenuItem, employeeProfileToolStripMenuItem, exitToolStripMenuItem, updateToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1395, 31);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // aGGIGIHRToolStripMenuItem
            // 
            aGGIGIHRToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editDailyRegsiterToolStripMenuItem, manualAttendanceToolStripMenuItem, yearlyHolidaysToolStripMenuItem, importToolStripMenuItem, exportToolStripMenuItem, toolStripMenuItem2, editUserProvlidgesToolStripMenuItem });
            aGGIGIHRToolStripMenuItem.Name = "aGGIGIHRToolStripMenuItem";
            aGGIGIHRToolStripMenuItem.Size = new Size(79, 27);
            aGGIGIHRToolStripMenuItem.Text = "Setup";
            aGGIGIHRToolStripMenuItem.Click += aGGIGIHRToolStripMenuItem_Click;
            // 
            // editDailyRegsiterToolStripMenuItem
            // 
            editDailyRegsiterToolStripMenuItem.Name = "editDailyRegsiterToolStripMenuItem";
            editDailyRegsiterToolStripMenuItem.Size = new Size(314, 28);
            editDailyRegsiterToolStripMenuItem.Text = "Employees Profile";
            editDailyRegsiterToolStripMenuItem.Click += editDailyRegsiterToolStripMenuItem_Click;
            // 
            // manualAttendanceToolStripMenuItem
            // 
            manualAttendanceToolStripMenuItem.Name = "manualAttendanceToolStripMenuItem";
            manualAttendanceToolStripMenuItem.Size = new Size(314, 28);
            manualAttendanceToolStripMenuItem.Text = "Department Setup";
            manualAttendanceToolStripMenuItem.Click += manualAttendanceToolStripMenuItem_Click;
            // 
            // yearlyHolidaysToolStripMenuItem
            // 
            yearlyHolidaysToolStripMenuItem.Name = "yearlyHolidaysToolStripMenuItem";
            yearlyHolidaysToolStripMenuItem.Size = new Size(314, 28);
            yearlyHolidaysToolStripMenuItem.Text = "Holidays Setup";
            yearlyHolidaysToolStripMenuItem.Click += yearlyHolidaysToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dailyAttendanceDataToolStripMenuItem });
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(314, 28);
            importToolStripMenuItem.Text = "Import DB";
            // 
            // dailyAttendanceDataToolStripMenuItem
            // 
            dailyAttendanceDataToolStripMenuItem.Name = "dailyAttendanceDataToolStripMenuItem";
            dailyAttendanceDataToolStripMenuItem.Size = new Size(325, 28);
            dailyAttendanceDataToolStripMenuItem.Text = "Daily Attendance Data";
            dailyAttendanceDataToolStripMenuItem.Click += dailyAttendanceDataToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { monthlyAttendanceDataToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(314, 28);
            exportToolStripMenuItem.Text = "Export XLS";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // monthlyAttendanceDataToolStripMenuItem
            // 
            monthlyAttendanceDataToolStripMenuItem.Name = "monthlyAttendanceDataToolStripMenuItem";
            monthlyAttendanceDataToolStripMenuItem.Size = new Size(347, 28);
            monthlyAttendanceDataToolStripMenuItem.Text = "Monthly Attendance Data";
            monthlyAttendanceDataToolStripMenuItem.Click += monthlyAttendanceDataToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(314, 28);
            toolStripMenuItem2.Text = " ";
            // 
            // editUserProvlidgesToolStripMenuItem
            // 
            editUserProvlidgesToolStripMenuItem.Name = "editUserProvlidgesToolStripMenuItem";
            editUserProvlidgesToolStripMenuItem.Size = new Size(314, 28);
            editUserProvlidgesToolStripMenuItem.Text = "Edit User Privlidges";
            editUserProvlidgesToolStripMenuItem.Click += editUserProvlidgesToolStripMenuItem_Click;
            // 
            // employeeProfileToolStripMenuItem
            // 
            employeeProfileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editTimeToolStripMenuItem, manualAttendanceRegToolStripMenuItem, advanceRegisterToolStripMenuItem, loanRegisterToolStripMenuItem, salaryRegisterToolStripMenuItem });
            employeeProfileToolStripMenuItem.Name = "employeeProfileToolStripMenuItem";
            employeeProfileToolStripMenuItem.Size = new Size(145, 27);
            employeeProfileToolStripMenuItem.Text = "Transaction";
            employeeProfileToolStripMenuItem.Click += employeeProfileToolStripMenuItem_Click;
            // 
            // editTimeToolStripMenuItem
            // 
            editTimeToolStripMenuItem.Name = "editTimeToolStripMenuItem";
            editTimeToolStripMenuItem.Size = new Size(325, 28);
            editTimeToolStripMenuItem.Text = "Edit Time";
            editTimeToolStripMenuItem.Click += editTimeToolStripMenuItem_Click;
            // 
            // manualAttendanceRegToolStripMenuItem
            // 
            manualAttendanceRegToolStripMenuItem.Name = "manualAttendanceRegToolStripMenuItem";
            manualAttendanceRegToolStripMenuItem.Size = new Size(325, 28);
            manualAttendanceRegToolStripMenuItem.Text = "Manual Attendance Reg";
            manualAttendanceRegToolStripMenuItem.Click += manualAttendanceRegToolStripMenuItem_Click;
            // 
            // advanceRegisterToolStripMenuItem
            // 
            advanceRegisterToolStripMenuItem.Name = "advanceRegisterToolStripMenuItem";
            advanceRegisterToolStripMenuItem.Size = new Size(325, 28);
            advanceRegisterToolStripMenuItem.Text = "Advance Register";
            // 
            // loanRegisterToolStripMenuItem
            // 
            loanRegisterToolStripMenuItem.Name = "loanRegisterToolStripMenuItem";
            loanRegisterToolStripMenuItem.Size = new Size(325, 28);
            loanRegisterToolStripMenuItem.Text = "Loan Register";
            // 
            // salaryRegisterToolStripMenuItem
            // 
            salaryRegisterToolStripMenuItem.Name = "salaryRegisterToolStripMenuItem";
            salaryRegisterToolStripMenuItem.Size = new Size(325, 28);
            salaryRegisterToolStripMenuItem.Text = "Salary Register";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(68, 27);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1100, 31);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 581);
            panel1.TabIndex = 10;
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { checkForUpdatesToolStripMenuItem, updateNowToolStripMenuItem });
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(90, 27);
            updateToolStripMenuItem.Text = "Update";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            checkForUpdatesToolStripMenuItem.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            checkForUpdatesToolStripMenuItem.Size = new Size(281, 28);
            checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
            checkForUpdatesToolStripMenuItem.Click += checkForUpdatesToolStripMenuItem_Click;
            // 
            // updateNowToolStripMenuItem
            // 
            updateNowToolStripMenuItem.Name = "updateNowToolStripMenuItem";
            updateNowToolStripMenuItem.Size = new Size(281, 28);
            updateNowToolStripMenuItem.Text = "Update Now!";
            updateNowToolStripMenuItem.Click += updateNowToolStripMenuItem_Click;
            // 
            // MainPanel
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1395, 612);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Font = new Font("Consolas", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 4, 5, 4);
            Name = "MainPanel";
            Text = "AG-GiGi Pvt Ltd.";
            WindowState = FormWindowState.Maximized;
            Load += MainPanel_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
             
        }

        #endregion
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aGGIGIHRToolStripMenuItem;
        private ToolStripMenuItem editDailyRegsiterToolStripMenuItem;
        private ToolStripMenuItem manualAttendanceToolStripMenuItem;
        private ToolStripMenuItem yearlyHolidaysToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem dailyAttendanceDataToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem monthlyAttendanceDataToolStripMenuItem;
        private ToolStripMenuItem employeeProfileToolStripMenuItem;
        private Panel panel1;
        private ToolStripMenuItem editTimeToolStripMenuItem;
        private ToolStripMenuItem manualAttendanceRegToolStripMenuItem;
        private ToolStripMenuItem advanceRegisterToolStripMenuItem;
        private ToolStripMenuItem loanRegisterToolStripMenuItem;
        private ToolStripMenuItem salaryRegisterToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem editUserProvlidgesToolStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private ToolStripMenuItem updateNowToolStripMenuItem;
    }
}