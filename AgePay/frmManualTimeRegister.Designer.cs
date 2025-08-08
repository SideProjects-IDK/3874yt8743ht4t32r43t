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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 16);
            label1.Name = "label1";
            label1.Size = new Size(270, 33);
            label1.TabIndex = 0;
            label1.Text = "Manual Attendance";
            // 
            // frmManualTimeRegister
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(456, 372);
            Controls.Add(label1);
            Font = new Font("Consolas", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmManualTimeRegister";
            ShowIcon = false;
            Text = "Time IN/OUT Screen";
            Load += frmManualTimeRegister_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox lbl_my_fathername;
        private Label label1;
    }
}