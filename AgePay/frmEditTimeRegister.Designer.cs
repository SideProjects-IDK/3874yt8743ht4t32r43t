namespace AgePay
{
    partial class frmEditTimeRegister
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
            splitContainer1 = new SplitContainer();
            groupBox2 = new GroupBox();
            groupBox5 = new GroupBox();
            btn_load_data_from_tab_seperated_file = new Button();
            btn_load_data_from_csv = new Button();
            groupBox4 = new GroupBox();
            groupBox7 = new GroupBox();
            txtfiltercardno = new TextBox();
            groupBox6 = new GroupBox();
            txtfilterdate = new TextBox();
            button1 = new Button();
            groupBox1 = new GroupBox();
            splitContainer2 = new SplitContainer();
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            txt_usersname = new TextBox();
            txt_timeout = new TextBox();
            label3 = new Label();
            txt_timein = new TextBox();
            label2 = new Label();
            txt_cardno = new TextBox();
            label1 = new Label();
            pictureBox_usersimage = new PictureBox();
            btn_update_record = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_usersimage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(1211, 472);
            splitContainer1.SplitterDistance = 403;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(button1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(403, 472);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "@";
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.White;
            groupBox5.Controls.Add(btn_load_data_from_tab_seperated_file);
            groupBox5.Controls.Add(btn_load_data_from_csv);
            groupBox5.Dock = DockStyle.Bottom;
            groupBox5.Location = new Point(3, 300);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(397, 125);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "Data Import";
            // 
            // btn_load_data_from_tab_seperated_file
            // 
            btn_load_data_from_tab_seperated_file.Dock = DockStyle.Top;
            btn_load_data_from_tab_seperated_file.FlatStyle = FlatStyle.Popup;
            btn_load_data_from_tab_seperated_file.Location = new Point(3, 68);
            btn_load_data_from_tab_seperated_file.Name = "btn_load_data_from_tab_seperated_file";
            btn_load_data_from_tab_seperated_file.Size = new Size(391, 44);
            btn_load_data_from_tab_seperated_file.TabIndex = 6;
            btn_load_data_from_tab_seperated_file.Text = "Load Data from TSF";
            btn_load_data_from_tab_seperated_file.UseVisualStyleBackColor = true;
            // 
            // btn_load_data_from_csv
            // 
            btn_load_data_from_csv.Dock = DockStyle.Top;
            btn_load_data_from_csv.FlatStyle = FlatStyle.Popup;
            btn_load_data_from_csv.Location = new Point(3, 24);
            btn_load_data_from_csv.Name = "btn_load_data_from_csv";
            btn_load_data_from_csv.Size = new Size(391, 44);
            btn_load_data_from_csv.TabIndex = 5;
            btn_load_data_from_csv.Text = "Load Data from CSV";
            btn_load_data_from_csv.UseVisualStyleBackColor = true;
            btn_load_data_from_csv.Click += btn_load_data_from_csv_Click;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.White;
            groupBox4.Controls.Add(groupBox7);
            groupBox4.Controls.Add(groupBox6);
            groupBox4.Dock = DockStyle.Top;
            groupBox4.Location = new Point(3, 24);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(397, 181);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Search Data";
            // 
            // groupBox7
            // 
            groupBox7.BackColor = Color.FromArgb(224, 224, 224);
            groupBox7.Controls.Add(txtfiltercardno);
            groupBox7.Dock = DockStyle.Top;
            groupBox7.Location = new Point(3, 96);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(391, 72);
            groupBox7.TabIndex = 7;
            groupBox7.TabStop = false;
            groupBox7.Text = "Filter Card No.";
            // 
            // txtfiltercardno
            // 
            txtfiltercardno.Dock = DockStyle.Top;
            txtfiltercardno.Location = new Point(3, 24);
            txtfiltercardno.Name = "txtfiltercardno";
            txtfiltercardno.Size = new Size(385, 28);
            txtfiltercardno.TabIndex = 0;
            txtfiltercardno.Text = "Card No.";
            // 
            // groupBox6
            // 
            groupBox6.BackColor = Color.FromArgb(224, 224, 224);
            groupBox6.Controls.Add(txtfilterdate);
            groupBox6.Dock = DockStyle.Top;
            groupBox6.Location = new Point(3, 24);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(391, 72);
            groupBox6.TabIndex = 6;
            groupBox6.TabStop = false;
            groupBox6.Text = "Filter Date";
            // 
            // txtfilterdate
            // 
            txtfilterdate.Dock = DockStyle.Top;
            txtfilterdate.Location = new Point(3, 24);
            txtfilterdate.Name = "txtfilterdate";
            txtfilterdate.Size = new Size(385, 28);
            txtfilterdate.TabIndex = 0;
            txtfilterdate.Text = "Date";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 192, 192);
            button1.Dock = DockStyle.Bottom;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(3, 425);
            button1.Name = "button1";
            button1.Size = new Size(397, 44);
            button1.TabIndex = 2;
            button1.Text = "EXIT";
            button1.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(splitContainer2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(804, 472);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "@";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 24);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(panel1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dataGridView1);
            splitContainer2.Size = new Size(798, 445);
            splitContainer2.SplitterDistance = 262;
            splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(798, 262);
            panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(txt_usersname);
            groupBox3.Controls.Add(txt_timeout);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(txt_timein);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(txt_cardno);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(pictureBox_usersimage);
            groupBox3.Controls.Add(btn_update_record);
            groupBox3.Dock = DockStyle.Left;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(757, 262);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Details";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(101, 211);
            label5.Name = "label5";
            label5.Size = new Size(43, 21);
            label5.TabIndex = 10;
            label5.Text = "###";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 211);
            label4.Name = "label4";
            label4.Size = new Size(45, 21);
            label4.TabIndex = 9;
            label4.Text = "Date";
            // 
            // txt_usersname
            // 
            txt_usersname.Location = new Point(212, 36);
            txt_usersname.Name = "txt_usersname";
            txt_usersname.Size = new Size(281, 28);
            txt_usersname.TabIndex = 8;
            txt_usersname.TextChanged += txt_usersname_TextChanged;
            // 
            // txt_timeout
            // 
            txt_timeout.Location = new Point(115, 110);
            txt_timeout.Name = "txt_timeout";
            txt_timeout.Size = new Size(157, 28);
            txt_timeout.TabIndex = 7;
            txt_timeout.TextChanged += txt_timeout_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 113);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 6;
            label3.Text = "Time Out";
            // 
            // txt_timein
            // 
            txt_timein.Location = new Point(115, 72);
            txt_timein.Name = "txt_timein";
            txt_timein.Size = new Size(157, 28);
            txt_timein.TabIndex = 5;
            txt_timein.TextChanged += txt_timein_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 76);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 4;
            label2.Text = "Time In";
            // 
            // txt_cardno
            // 
            txt_cardno.Location = new Point(115, 36);
            txt_cardno.Name = "txt_cardno";
            txt_cardno.Size = new Size(87, 28);
            txt_cardno.TabIndex = 3;
            txt_cardno.TextChanged += txt_cardno_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 39);
            label1.Name = "label1";
            label1.Size = new Size(76, 21);
            label1.TabIndex = 2;
            label1.Text = "Card No.";
            // 
            // pictureBox_usersimage
            // 
            pictureBox_usersimage.Location = new Point(502, 3);
            pictureBox_usersimage.Name = "pictureBox_usersimage";
            pictureBox_usersimage.Size = new Size(242, 193);
            pictureBox_usersimage.TabIndex = 0;
            pictureBox_usersimage.TabStop = false;
            pictureBox_usersimage.Click += pictureBox_usersimage_Click;
            // 
            // btn_update_record
            // 
            btn_update_record.FlatStyle = FlatStyle.Popup;
            btn_update_record.Location = new Point(502, 203);
            btn_update_record.Name = "btn_update_record";
            btn_update_record.Size = new Size(242, 38);
            btn_update_record.TabIndex = 1;
            btn_update_record.Text = "Update Record";
            btn_update_record.UseVisualStyleBackColor = true;
            btn_update_record.Click += btn_update_record_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(798, 179);
            dataGridView1.TabIndex = 0;
            // 
            // frmEditTimeRegister
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 472);
            Controls.Add(splitContainer1);
            Font = new Font("Bahnschrift", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frmEditTimeRegister";
            ShowIcon = false;
            Text = "Edit time in/out";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_usersimage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private SplitContainer splitContainer2;
        private Panel panel1;
        private PictureBox pictureBox_usersimage;
        private DataGridView dataGridView1;
        private Button btn_update_record;
        private GroupBox groupBox3;
        private TextBox txt_timeout;
        private Label label3;
        private TextBox txt_timein;
        private Label label2;
        private TextBox txt_cardno;
        private Label label1;
        private Label label5;
        private Label label4;
        private TextBox txt_usersname;
        private GroupBox groupBox4;
        private Button button1;
        private GroupBox groupBox5;
        private Button btn_load_data_from_tab_seperated_file;
        private Button btn_load_data_from_csv;
        private GroupBox groupBox7;
        private TextBox txtfiltercardno;
        private GroupBox groupBox6;
        private TextBox txtfilterdate;
    }
}