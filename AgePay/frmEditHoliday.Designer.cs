using System.Data.SqlClient;

namespace AgePay
{
    partial class frmEditHoliday
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
            groupBox1 = new GroupBox();
            button3 = new Button();
            button2 = new Button();
            lbl_count_of_toall_holidays_this_year = new Label();
            lbl_days_in_this_year = new Label();
            button1 = new Button();
            groupBox2 = new GroupBox();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            label3 = new Label();
            txt_search_with_name = new TextBox();
            txt_search_with_date = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(lbl_count_of_toall_holidays_this_year);
            groupBox1.Controls.Add(lbl_days_in_this_year);
            groupBox1.Controls.Add(button1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1128, 93);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "@";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 192, 192);
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Consolas", 9F, FontStyle.Italic);
            button3.Location = new Point(339, 28);
            button3.Name = "button3";
            button3.Size = new Size(143, 50);
            button3.TabIndex = 6;
            button3.Text = "Delete all Data";
            button3.UseVisualStyleBackColor = false;
            button3.Click += Button3_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Consolas", 9F, FontStyle.Italic);
            button2.Location = new Point(180, 28);
            button2.Name = "button2";
            button2.Size = new Size(153, 50);
            button2.TabIndex = 5;
            button2.Text = "Add all sundays!";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // lbl_count_of_toall_holidays_this_year
            // 
            lbl_count_of_toall_holidays_this_year.AutoSize = true;
            lbl_count_of_toall_holidays_this_year.Location = new Point(793, 56);
            lbl_count_of_toall_holidays_this_year.Name = "lbl_count_of_toall_holidays_this_year";
            lbl_count_of_toall_holidays_this_year.Size = new Size(150, 22);
            lbl_count_of_toall_holidays_this_year.TabIndex = 2;
            lbl_count_of_toall_holidays_this_year.Text = "Search w. Date";
            lbl_count_of_toall_holidays_this_year.Click += Lbl_count_of_toall_holidays_this_year_Click;
            // 
            // lbl_days_in_this_year
            // 
            lbl_days_in_this_year.AutoSize = true;
            lbl_days_in_this_year.Location = new Point(793, 25);
            lbl_days_in_this_year.Name = "lbl_days_in_this_year";
            lbl_days_in_this_year.Size = new Size(150, 22);
            lbl_days_in_this_year.TabIndex = 1;
            lbl_days_in_this_year.Text = "Search w. Date";
            lbl_days_in_this_year.Click += Lbl_days_in_this_year_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Consolas", 9F, FontStyle.Italic);
            button1.Location = new Point(6, 28);
            button1.Name = "button1";
            button1.Size = new Size(168, 50);
            button1.TabIndex = 0;
            button1.Text = "Add a new holiday!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(panel1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 93);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1128, 376);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Holidays";
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 68);
            panel2.Name = "panel2";
            panel2.Size = new Size(1122, 305);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1122, 305);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txt_search_with_name);
            panel1.Controls.Add(txt_search_with_date);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(1122, 43);
            panel1.TabIndex = 0;
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
            // txt_search_with_date
            // 
            txt_search_with_date.Location = new Point(177, 8);
            txt_search_with_date.Name = "txt_search_with_date";
            txt_search_with_date.Size = new Size(125, 29);
            txt_search_with_date.TabIndex = 1;
            txt_search_with_date.TextChanged += txt_search_with_date_TextChanged;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 12);
            label1.Name = "label1";
            label1.Size = new Size(150, 22);
            label1.TabIndex = 0;
            label1.Text = "Search w. Date";
            // 
            // frmEditHoliday
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1128, 469);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Consolas", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmEditHoliday";
            ShowIcon = false;
            Text = "Edit Holiday";
            Load += frmEditHoliday_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }



        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void Lbl_count_of_toall_holidays_this_year_Click(object sender, EventArgs e)
        {
           
        }

        private void Lbl_days_in_this_year_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Panel panel1;
        private Label label3;
        private TextBox txt_search_with_name;
        private TextBox txt_search_with_date;
        private Label label2;
        private Label label1;
        private Button button1;
        private Label lbl_count_of_toall_holidays_this_year;
        private Label lbl_days_in_this_year;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button2;
    }
}