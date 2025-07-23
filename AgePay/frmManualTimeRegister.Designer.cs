namespace AgePay
{
    partial class frmManualTimeRegister
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
            group_box_phase_2 = new GroupBox();
            lbl_my_fathername = new Label();
            Fathersssss = new Label();
            pictureBox1 = new PictureBox();
            lbl_my_name = new Label();
            lbl_my_cardno = new Label();
            label2 = new Label();
            group_box_phase_3 = new GroupBox();
            lbl_current_time = new Label();
            btn_set_timeout = new Button();
            btn_settimein = new Button();
            group_box_phase_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            group_box_phase_3.SuspendLayout();
            SuspendLayout();
            // 
            // group_box_phase_2
            // 
            group_box_phase_2.Controls.Add(lbl_my_fathername);
            group_box_phase_2.Controls.Add(Fathersssss);
            group_box_phase_2.Controls.Add(pictureBox1);
            group_box_phase_2.Controls.Add(lbl_my_name);
            group_box_phase_2.Controls.Add(lbl_my_cardno);
            group_box_phase_2.Controls.Add(label2);
            group_box_phase_2.Location = new Point(8, 5);
            group_box_phase_2.Name = "group_box_phase_2";
            group_box_phase_2.Size = new Size(593, 279);
            group_box_phase_2.TabIndex = 1;
            group_box_phase_2.TabStop = false;
            group_box_phase_2.Text = "Your Profile";
            group_box_phase_2.Enter += group_box_phase_2_Enter;
            // 
            // lbl_my_fathername
            // 
            lbl_my_fathername.AutoSize = true;
            lbl_my_fathername.Location = new Point(300, 76);
            lbl_my_fathername.Name = "lbl_my_fathername";
            lbl_my_fathername.Size = new Size(90, 22);
            lbl_my_fathername.TabIndex = 9;
            lbl_my_fathername.Text = "Card No.";
            // 
            // Fathersssss
            // 
            Fathersssss.AutoSize = true;
            Fathersssss.Location = new Point(209, 76);
            Fathersssss.Name = "Fathersssss";
            Fathersssss.Size = new Size(70, 22);
            Fathersssss.TabIndex = 8;
            Fathersssss.Text = "Father";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(9, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(185, 190);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lbl_my_name
            // 
            lbl_my_name.AutoSize = true;
            lbl_my_name.Font = new Font("Consolas", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_my_name.Location = new Point(209, 25);
            lbl_my_name.Name = "lbl_my_name";
            lbl_my_name.Size = new Size(116, 27);
            lbl_my_name.TabIndex = 4;
            lbl_my_name.Text = "Card No.";
            lbl_my_name.Click += lbl_my_name_Click;
            // 
            // lbl_my_cardno
            // 
            lbl_my_cardno.AutoSize = true;
            lbl_my_cardno.Location = new Point(291, 113);
            lbl_my_cardno.Name = "lbl_my_cardno";
            lbl_my_cardno.Size = new Size(90, 22);
            lbl_my_cardno.TabIndex = 2;
            lbl_my_cardno.Text = "Card No.";
            lbl_my_cardno.Click += lbl_my_cardno_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 113);
            label2.Name = "label2";
            label2.Size = new Size(90, 22);
            label2.TabIndex = 1;
            label2.Text = "Card No.";
            // 
            // group_box_phase_3
            // 
            group_box_phase_3.Controls.Add(lbl_current_time);
            group_box_phase_3.Controls.Add(btn_set_timeout);
            group_box_phase_3.Controls.Add(btn_settimein);
            group_box_phase_3.Location = new Point(7, 290);
            group_box_phase_3.Name = "group_box_phase_3";
            group_box_phase_3.Size = new Size(593, 118);
            group_box_phase_3.TabIndex = 2;
            group_box_phase_3.TabStop = false;
            group_box_phase_3.Text = "@";
            group_box_phase_3.Enter += group_box_phase_3_Enter;
            // 
            // lbl_current_time
            // 
            lbl_current_time.AutoSize = true;
            lbl_current_time.Font = new Font("Consolas", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_current_time.Location = new Point(10, 34);
            lbl_current_time.Name = "lbl_current_time";
            lbl_current_time.Size = new Size(93, 40);
            lbl_current_time.TabIndex = 2;
            lbl_current_time.Text = "time";
            // 
            // btn_set_timeout
            // 
            btn_set_timeout.FlatStyle = FlatStyle.Popup;
            btn_set_timeout.Font = new Font("Consolas", 10.8F, FontStyle.Italic);
            btn_set_timeout.Location = new Point(308, 18);
            btn_set_timeout.Name = "btn_set_timeout";
            btn_set_timeout.Size = new Size(279, 38);
            btn_set_timeout.TabIndex = 1;
            btn_set_timeout.Text = "TimeOUT";
            btn_set_timeout.UseVisualStyleBackColor = true;
            btn_set_timeout.Click += btn_set_timeout_Click;
            // 
            // btn_settimein
            // 
            btn_settimein.FlatStyle = FlatStyle.Popup;
            btn_settimein.Font = new Font("Consolas", 10.8F, FontStyle.Italic);
            btn_settimein.Location = new Point(308, 62);
            btn_settimein.Name = "btn_settimein";
            btn_settimein.Size = new Size(279, 37);
            btn_settimein.TabIndex = 0;
            btn_settimein.Text = "TimeIN";
            btn_settimein.UseVisualStyleBackColor = true;
            btn_settimein.Click += btn_settimein_Click;
            // 
            // frmManualTimeRegister
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(612, 421);
            Controls.Add(group_box_phase_3);
            Controls.Add(group_box_phase_2);
            Font = new Font("Consolas", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmManualTimeRegister";
            ShowIcon = false;
            Text = "Time IN/OUT Screen";
            Load += frmManualTimeRegister_Load;
            group_box_phase_2.ResumeLayout(false);
            group_box_phase_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            group_box_phase_3.ResumeLayout(false);
            group_box_phase_3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox group_box_phase_2;
        private GroupBox group_box_phase_3;
        private Button btn_set_timeout;
        private Button btn_settimein;
        private Label lbl_current_time;
        private Label lbl_my_cardno;
        private Label label2;
        private Label lbl_my_name;
        private PictureBox pictureBox1;
        private Label lbl_my_fathername;
        private Label Fathersssss;
    }
}