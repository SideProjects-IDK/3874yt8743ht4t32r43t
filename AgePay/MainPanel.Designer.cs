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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file = new Button();
            groupBox1 = new GroupBox();
            button5 = new Button();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Location = new Point(7, 93);
            button3.Name = "button3";
            button3.Size = new Size(321, 60);
            button3.TabIndex = 1;
            button3.Text = "Daily Register";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(7, 30);
            button2.Name = "button2";
            button2.Size = new Size(321, 60);
            button2.TabIndex = 0;
            button2.Text = "Employee Profile";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(7, 159);
            button1.Name = "button1";
            button1.Size = new Size(321, 60);
            button1.TabIndex = 2;
            button1.Text = "Manual Attendance";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file
            // 
            btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file.BackColor = Color.White;
            btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file.FlatStyle = FlatStyle.Popup;
            btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file.ForeColor = Color.Blue;
            btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file.Location = new Point(6, 30);
            btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file.Name = "btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file";
            btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file.Size = new Size(321, 60);
            btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file.TabIndex = 4;
            btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file.Text = "Import Daily Register \r\nFingerprint Data";
            btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file.UseVisualStyleBackColor = false;
            btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file.Click += this.btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(258, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(336, 494);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "General";
            // 
            // button5
            // 
            button5.BackColor = Color.White;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Location = new Point(6, 225);
            button5.Name = "button5";
            button5.Size = new Size(321, 60);
            button5.TabIndex = 3;
            button5.Text = "Yearly Holidays";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file);
            groupBox2.Location = new Point(600, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(336, 247);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Import Data";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button4);
            groupBox3.Location = new Point(600, 265);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(336, 247);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Export Data";
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.FlatStyle = FlatStyle.Popup;
            button4.ForeColor = Color.Blue;
            button4.Location = new Point(6, 30);
            button4.Name = "button4";
            button4.Size = new Size(321, 60);
            button4.TabIndex = 4;
            button4.Text = "Export Daily \r\nAttendance Report";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(193, 210);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // MainPanel
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1416, 518);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Consolas", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainPanel";
            Text = "MainPanel";
            WindowState = FormWindowState.Maximized;
            Load += MainPanel_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

       

        #endregion
        private Button button3;
        private Button button2;
        private Button button1;
        private Button btn_import_daily_resisgter_data_from_csv_or_tab_seperated_file;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button5;
        private GroupBox groupBox3;
        private Button button4;
        private PictureBox pictureBox1;
    }
}