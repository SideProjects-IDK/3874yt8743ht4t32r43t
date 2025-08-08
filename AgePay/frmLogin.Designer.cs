namespace AgePay
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            groupBox1 = new GroupBox();
            button1 = new Button();
            label2 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(537, 103);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(336, 200);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(190, 159);
            button1.Name = "button1";
            button1.Size = new Size(125, 35);
            button1.TabIndex = 4;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 101);
            label2.Name = "label2";
            label2.Size = new Size(90, 22);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(110, 48);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(205, 30);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(110, 98);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '#';
            textBox1.Size = new Size(205, 29);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 51);
            label1.Name = "label1";
            label1.Size = new Size(90, 22);
            label1.TabIndex = 0;
            label1.Text = "UserName";
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(969, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 521);
            panel1.TabIndex = 11;
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
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1219, 521);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Font = new Font("Consolas", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmLogin";
            ShowIcon = false;
            Text = "Login ~Please";
            WindowState = FormWindowState.Maximized;
            Load += frmLogin_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private Label label2;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}