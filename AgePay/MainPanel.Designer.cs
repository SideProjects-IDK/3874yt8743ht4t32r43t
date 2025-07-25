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
            employeeProfileToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
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
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 209);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.Font = new Font("Consolas", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { aGGIGIHRToolStripMenuItem, employeeProfileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1416, 30);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // aGGIGIHRToolStripMenuItem
            // 
            aGGIGIHRToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editDailyRegsiterToolStripMenuItem, manualAttendanceToolStripMenuItem, yearlyHolidaysToolStripMenuItem, importToolStripMenuItem, exportToolStripMenuItem });
            aGGIGIHRToolStripMenuItem.Name = "aGGIGIHRToolStripMenuItem";
            aGGIGIHRToolStripMenuItem.Size = new Size(124, 26);
            aGGIGIHRToolStripMenuItem.Text = "Attendance";
            // 
            // editDailyRegsiterToolStripMenuItem
            // 
            editDailyRegsiterToolStripMenuItem.Name = "editDailyRegsiterToolStripMenuItem";
            editDailyRegsiterToolStripMenuItem.Size = new Size(284, 26);
            editDailyRegsiterToolStripMenuItem.Text = "Edit Daily Regsiter";
            editDailyRegsiterToolStripMenuItem.Click += editDailyRegsiterToolStripMenuItem_Click;
            // 
            // manualAttendanceToolStripMenuItem
            // 
            manualAttendanceToolStripMenuItem.Name = "manualAttendanceToolStripMenuItem";
            manualAttendanceToolStripMenuItem.Size = new Size(284, 26);
            manualAttendanceToolStripMenuItem.Text = "Manual Attendance";
            manualAttendanceToolStripMenuItem.Click += manualAttendanceToolStripMenuItem_Click;
            // 
            // yearlyHolidaysToolStripMenuItem
            // 
            yearlyHolidaysToolStripMenuItem.Name = "yearlyHolidaysToolStripMenuItem";
            yearlyHolidaysToolStripMenuItem.Size = new Size(284, 26);
            yearlyHolidaysToolStripMenuItem.Text = "Yearly Holidays";
            yearlyHolidaysToolStripMenuItem.Click += yearlyHolidaysToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dailyAttendanceDataToolStripMenuItem });
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(284, 26);
            importToolStripMenuItem.Text = "Import";
            // 
            // dailyAttendanceDataToolStripMenuItem
            // 
            dailyAttendanceDataToolStripMenuItem.Name = "dailyAttendanceDataToolStripMenuItem";
            dailyAttendanceDataToolStripMenuItem.Size = new Size(304, 26);
            dailyAttendanceDataToolStripMenuItem.Text = "Daily Attendance Data";
            dailyAttendanceDataToolStripMenuItem.Click += dailyAttendanceDataToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { monthlyAttendanceDataToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(284, 26);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // monthlyAttendanceDataToolStripMenuItem
            // 
            monthlyAttendanceDataToolStripMenuItem.Name = "monthlyAttendanceDataToolStripMenuItem";
            monthlyAttendanceDataToolStripMenuItem.Size = new Size(324, 26);
            monthlyAttendanceDataToolStripMenuItem.Text = "Monthly Attendance Data";
            monthlyAttendanceDataToolStripMenuItem.Click += monthlyAttendanceDataToolStripMenuItem_Click;
            // 
            // employeeProfileToolStripMenuItem
            // 
            employeeProfileToolStripMenuItem.Name = "employeeProfileToolStripMenuItem";
            employeeProfileToolStripMenuItem.Size = new Size(184, 26);
            employeeProfileToolStripMenuItem.Text = "Employee Profile";
            employeeProfileToolStripMenuItem.Click += employeeProfileToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1166, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 488);
            panel1.TabIndex = 10;
            // 
            // MainPanel
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1416, 518);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Font = new Font("Consolas", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainPanel";
            Text = "MainPanel";
            WindowState = FormWindowState.Maximized;
            Load += MainPanel_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
    }
}