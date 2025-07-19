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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            button1 = new Button();
            groupBox1 = new GroupBox();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            panel4 = new Panel();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(344, 518);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(344, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(344, 518);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(button1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(344, 48);
            panel3.TabIndex = 2;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(0, 0);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(56, 48);
            button1.TabIndex = 0;
            button1.Text = "@";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(224, 224, 224);
            groupBox1.Controls.Add(panel4);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(344, 518);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pages";
            // 
            // button5
            // 
            button5.BackColor = Color.White;
            button5.Dock = DockStyle.Bottom;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Location = new Point(4, 291);
            button5.Name = "button5";
            button5.Size = new Size(336, 56);
            button5.TabIndex = 3;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Dock = DockStyle.Bottom;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Location = new Point(4, 347);
            button4.Name = "button4";
            button4.Size = new Size(336, 56);
            button4.TabIndex = 2;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.Dock = DockStyle.Bottom;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Location = new Point(4, 403);
            button3.Name = "button3";
            button3.Size = new Size(336, 56);
            button3.TabIndex = 1;
            button3.Text = "Daily Register";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Dock = DockStyle.Bottom;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(4, 459);
            button2.Name = "button2";
            button2.Size = new Size(336, 56);
            button2.TabIndex = 0;
            button2.Text = "Employee Profile";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(4, 243);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(336, 48);
            panel4.TabIndex = 4;
            // 
            // MainPanel
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 518);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Consolas", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainPanel";
            Text = "MainPanel";
            Load += MainPanel_Load;
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button button1;
        private GroupBox groupBox1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Panel panel4;
    }
}