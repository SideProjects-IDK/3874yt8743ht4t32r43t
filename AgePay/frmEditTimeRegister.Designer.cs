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
            label1 = new Label();
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            panel2 = new Panel();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            label3 = new Label();
            txt_search_date = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 11);
            label1.Name = "label1";
            label1.Size = new Size(321, 40);
            label1.TabIndex = 0;
            label1.Text = "Edit Time IN/OUT";
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox3);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 645);
            panel1.Name = "panel1";
            panel1.Size = new Size(968, 86);
            panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(968, 86);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "@";
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 54);
            panel2.Name = "panel2";
            panel2.Size = new Size(968, 591);
            panel2.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 92);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(968, 499);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Register";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(962, 471);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txt_search_date);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(968, 92);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(726, 25);
            label3.Name = "label3";
            label3.Size = new Size(230, 44);
            label3.TabIndex = 2;
            label3.Text = "Try edit date to fetch\r\n results of that date";
            // 
            // txt_search_date
            // 
            txt_search_date.Location = new Point(62, 38);
            txt_search_date.Name = "txt_search_date";
            txt_search_date.Size = new Size(168, 29);
            txt_search_date.TabIndex = 1;
            txt_search_date.TextChanged += txt_search_date_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 41);
            label2.Name = "label2";
            label2.Size = new Size(50, 22);
            label2.TabIndex = 0;
            label2.Text = "Date";
            // 
            // frmEditTimeRegister
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(968, 731);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Consolas", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmEditTimeRegister";
            ShowIcon = false;
            Text = "Edit Time";
            Load += frmEditTimeRegister_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Btn_update_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private GroupBox groupBox3;
        private Panel panel2;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private TextBox txt_search_date;
        private Label label2;
        private Label label3;
    }
}