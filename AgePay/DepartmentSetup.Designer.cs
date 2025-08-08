namespace AgePay
{
    partial class DepartmentSetup
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
            label3 = new Label();
            txt_search_with_name = new TextBox();
            txt_search_with_ID = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            groupBox2 = new GroupBox();
            button3 = new Button();
            btn_add_a_new_depo = new Button();
            groupBox1 = new GroupBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(323, 4);
            label3.Name = "label3";
            label3.Size = new Size(31, 36);
            label3.TabIndex = 3;
            label3.Text = "|";
            // 
            // txt_search_with_name
            // 
            txt_search_with_name.Location = new Point(516, 7);
            txt_search_with_name.Name = "txt_search_with_name";
            txt_search_with_name.Size = new Size(125, 29);
            txt_search_with_name.TabIndex = 3;
            txt_search_with_name.TextChanged += txt_search_with_name_TextChanged;
            // 
            // txt_search_with_ID
            // 
            txt_search_with_ID.Location = new Point(177, 8);
            txt_search_with_ID.Name = "txt_search_with_ID";
            txt_search_with_ID.Size = new Size(125, 29);
            txt_search_with_ID.TabIndex = 1;
            txt_search_with_ID.TextChanged += txt_search_with_ID_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 12);
            label1.Name = "label1";
            label1.Size = new Size(130, 22);
            label1.TabIndex = 0;
            label1.Text = "Search w. ID";
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txt_search_with_name);
            panel1.Controls.Add(txt_search_with_ID);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(1009, 43);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(360, 11);
            label2.Name = "label2";
            label2.Size = new Size(150, 22);
            label2.TabIndex = 2;
            label2.Text = "Search w. Name";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1009, 322);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += this.DataGridView1_CellContentClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 68);
            panel2.Name = "panel2";
            panel2.Size = new Size(1009, 322);
            panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(panel1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 93);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1015, 393);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Departments";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 192, 192);
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Consolas", 9F, FontStyle.Italic);
            button3.Location = new Point(860, 28);
            button3.Name = "button3";
            button3.Size = new Size(143, 50);
            button3.TabIndex = 6;
            button3.Text = "Delete all Data";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // btn_add_a_new_depo
            // 
            btn_add_a_new_depo.FlatStyle = FlatStyle.Popup;
            btn_add_a_new_depo.Font = new Font("Consolas", 9F, FontStyle.Italic);
            btn_add_a_new_depo.Location = new Point(6, 28);
            btn_add_a_new_depo.Name = "btn_add_a_new_depo";
            btn_add_a_new_depo.Size = new Size(168, 50);
            btn_add_a_new_depo.TabIndex = 0;
            btn_add_a_new_depo.Text = "Add a new Depo!";
            btn_add_a_new_depo.UseVisualStyleBackColor = true;
            btn_add_a_new_depo.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(btn_add_a_new_depo);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1015, 93);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "@";
            // 
            // DepartmentSetup
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1015, 486);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Consolas", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "DepartmentSetup";
            ShowIcon = false;
            Text = "DepartmentSetup";
            Load += DepartmentSetup_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

       

        #endregion

        private Label label3;
        private TextBox txt_search_with_name;
        private TextBox txt_search_with_ID;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private DataGridView dataGridView1;
        private Panel panel2;
        private GroupBox groupBox2;
        private Button button3;
        private Button btn_add_a_new_depo;
        private GroupBox groupBox1;
    }
}