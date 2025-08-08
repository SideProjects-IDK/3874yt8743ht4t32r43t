using System.Data.SqlClient;

namespace AgePay
{
    partial class frmEmployeeProfile
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
            label2 = new Label();
            txtEmployeeID = new TextBox();
            txtEmployeeName = new TextBox();
            label3 = new Label();
            txtCNIC = new TextBox();
            label4 = new Label();
            txtFatherName = new TextBox();
            label5 = new Label();
            txtGSalary = new TextBox();
            label6 = new Label();
            txtDesignation = new TextBox();
            label7 = new Label();
            txtDeptID = new TextBox();
            label8 = new Label();
            txtDOA = new TextBox();
            label9 = new Label();
            txtDOB = new TextBox();
            label10 = new Label();
            txtDOR = new TextBox();
            label11 = new Label();
            txtDutyIn = new TextBox();
            label12 = new Label();
            txtDutyOut = new TextBox();
            label13 = new Label();
            groupBox1 = new GroupBox();
            btnPrint = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnOpen = new Button();
            btnNew = new Button();
            groupBox2 = new GroupBox();
            comboBox_txtDeptID = new ComboBox();
            txtDepoNo = new TextBox();
            groupBox3 = new GroupBox();
            btnEDITphoto = new Button();
            pictureEmployee = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureEmployee).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(372, 47);
            label1.TabIndex = 0;
            label1.Text = "Employee's Setup";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 7.8F);
            label2.Location = new Point(29, 38);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 1;
            label2.Text = "EmployeeID";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Font = new Font("Consolas", 7.8F);
            txtEmployeeID.Location = new Point(188, 34);
            txtEmployeeID.Margin = new Padding(4);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(136, 23);
            txtEmployeeID.TabIndex = 2;
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Font = new Font("Consolas", 7.8F);
            txtEmployeeName.Location = new Point(188, 68);
            txtEmployeeName.Margin = new Padding(4);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Size = new Size(396, 23);
            txtEmployeeName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 7.8F);
            label3.Location = new Point(29, 72);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 3;
            label3.Text = "EmployeeName";
            // 
            // txtCNIC
            // 
            txtCNIC.Font = new Font("Consolas", 7.8F);
            txtCNIC.Location = new Point(188, 137);
            txtCNIC.Margin = new Padding(4);
            txtCNIC.Name = "txtCNIC";
            txtCNIC.Size = new Size(275, 23);
            txtCNIC.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Consolas", 7.8F);
            label4.Location = new Point(29, 141);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 7;
            label4.Text = "CNIC";
            // 
            // txtFatherName
            // 
            txtFatherName.Font = new Font("Consolas", 7.8F);
            txtFatherName.Location = new Point(188, 103);
            txtFatherName.Margin = new Padding(4);
            txtFatherName.Name = "txtFatherName";
            txtFatherName.Size = new Size(396, 23);
            txtFatherName.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Consolas", 7.8F);
            label5.Location = new Point(29, 106);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 5;
            label5.Text = "Father Name";
            // 
            // txtGSalary
            // 
            txtGSalary.Font = new Font("Consolas", 7.8F);
            txtGSalary.Location = new Point(188, 274);
            txtGSalary.Margin = new Padding(4);
            txtGSalary.Name = "txtGSalary";
            txtGSalary.Size = new Size(136, 23);
            txtGSalary.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Consolas", 7.8F);
            label6.Location = new Point(29, 277);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(91, 15);
            label6.TabIndex = 15;
            label6.Text = "Gross Salary";
            // 
            // txtDesignation
            // 
            txtDesignation.Font = new Font("Consolas", 7.8F);
            txtDesignation.Location = new Point(188, 240);
            txtDesignation.Margin = new Padding(4);
            txtDesignation.Name = "txtDesignation";
            txtDesignation.Size = new Size(396, 23);
            txtDesignation.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Consolas", 7.8F);
            label7.Location = new Point(29, 243);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(84, 15);
            label7.TabIndex = 13;
            label7.Text = "Designition";
            // 
            // txtDeptID
            // 
            txtDeptID.Font = new Font("Consolas", 7.8F);
            txtDeptID.Location = new Point(188, 205);
            txtDeptID.Margin = new Padding(4);
            txtDeptID.Name = "txtDeptID";
            txtDeptID.Size = new Size(55, 23);
            txtDeptID.TabIndex = 12;
            txtDeptID.TextChanged += txtDeptID_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Consolas", 7.8F);
            label8.Location = new Point(29, 209);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 11;
            label8.Text = "Department ";
            // 
            // txtDOA
            // 
            txtDOA.Font = new Font("Consolas", 7.8F);
            txtDOA.Location = new Point(188, 171);
            txtDOA.Margin = new Padding(4);
            txtDOA.Name = "txtDOA";
            txtDOA.Size = new Size(275, 23);
            txtDOA.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Consolas", 7.8F);
            label9.Location = new Point(29, 175);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(119, 15);
            label9.TabIndex = 9;
            label9.Text = "Appointment Date";
            // 
            // txtDOB
            // 
            txtDOB.Font = new Font("Consolas", 7.8F);
            txtDOB.Location = new Point(531, 137);
            txtDOB.Margin = new Padding(4);
            txtDOB.Name = "txtDOB";
            txtDOB.Size = new Size(195, 23);
            txtDOB.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Consolas", 7.8F);
            label10.Location = new Point(471, 141);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 17;
            label10.Text = "D.O.B";
            // 
            // txtDOR
            // 
            txtDOR.Font = new Font("Consolas", 7.8F);
            txtDOR.Location = new Point(584, 330);
            txtDOR.Margin = new Padding(4);
            txtDOR.Name = "txtDOR";
            txtDOR.Size = new Size(139, 23);
            txtDOR.TabIndex = 20;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Consolas", 7.8F);
            label11.Location = new Point(471, 336);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(84, 15);
            label11.TabIndex = 19;
            label11.Text = "Resig. Date";
            // 
            // txtDutyIn
            // 
            txtDutyIn.Font = new Font("Consolas", 7.8F);
            txtDutyIn.Location = new Point(188, 332);
            txtDutyIn.Margin = new Padding(4);
            txtDutyIn.Name = "txtDutyIn";
            txtDutyIn.Size = new Size(112, 23);
            txtDutyIn.TabIndex = 23;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Consolas", 7.8F);
            label12.Location = new Point(29, 336);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(154, 15);
            label12.TabIndex = 22;
            label12.Text = "Working Hrs Setup In:";
            // 
            // txtDutyOut
            // 
            txtDutyOut.Font = new Font("Consolas", 7.8F);
            txtDutyOut.Location = new Point(352, 332);
            txtDutyOut.Margin = new Padding(4);
            txtDutyOut.Name = "txtDutyOut";
            txtDutyOut.Size = new Size(110, 23);
            txtDutyOut.TabIndex = 25;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Consolas", 7.8F);
            label13.Location = new Point(308, 336);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(35, 15);
            label13.TabIndex = 24;
            label13.Text = "Out:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnPrint);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnOpen);
            groupBox1.Controls.Add(btnNew);
            groupBox1.Location = new Point(14, 429);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(1072, 70);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "@";
            // 
            // btnPrint
            // 
            btnPrint.Dock = DockStyle.Left;
            btnPrint.FlatStyle = FlatStyle.Popup;
            btnPrint.Location = new Point(380, 26);
            btnPrint.Margin = new Padding(4);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(94, 40);
            btnPrint.TabIndex = 4;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Left;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Location = new Point(286, 26);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 40);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Left;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Location = new Point(192, 26);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnOpen
            // 
            btnOpen.Dock = DockStyle.Left;
            btnOpen.FlatStyle = FlatStyle.Popup;
            btnOpen.Location = new Point(98, 26);
            btnOpen.Margin = new Padding(4);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(94, 40);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnNew
            // 
            btnNew.Dock = DockStyle.Left;
            btnNew.FlatStyle = FlatStyle.Popup;
            btnNew.Location = new Point(4, 26);
            btnNew.Margin = new Padding(4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(94, 40);
            btnNew.TabIndex = 0;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox_txtDeptID);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtDutyOut);
            groupBox2.Controls.Add(txtEmployeeID);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtDutyIn);
            groupBox2.Controls.Add(txtEmployeeName);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtDepoNo);
            groupBox2.Controls.Add(txtFatherName);
            groupBox2.Controls.Add(txtDOR);
            groupBox2.Controls.Add(txtCNIC);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtDOB);
            groupBox2.Controls.Add(txtDOA);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtGSalary);
            groupBox2.Controls.Add(txtDeptID);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtDesignation);
            groupBox2.Location = new Point(15, 64);
            groupBox2.Margin = new Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4);
            groupBox2.Size = new Size(740, 365);
            groupBox2.TabIndex = 27;
            groupBox2.TabStop = false;
            groupBox2.Text = "Info";
            // 
            // comboBox_txtDeptID
            // 
            comboBox_txtDeptID.FormattingEnabled = true;
            comboBox_txtDeptID.Location = new Point(408, 203);
            comboBox_txtDeptID.Margin = new Padding(4);
            comboBox_txtDeptID.Name = "comboBox_txtDeptID";
            comboBox_txtDeptID.Size = new Size(188, 30);
            comboBox_txtDeptID.TabIndex = 26;
            // 
            // txtDepoNo
            // 
            txtDepoNo.Font = new Font("Consolas", 7.8F);
            txtDepoNo.Location = new Point(251, 205);
            txtDepoNo.Margin = new Padding(4);
            txtDepoNo.Name = "txtDepoNo";
            txtDepoNo.Size = new Size(148, 23);
            txtDepoNo.TabIndex = 21;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnEDITphoto);
            groupBox3.Controls.Add(pictureEmployee);
            groupBox3.Location = new Point(762, 64);
            groupBox3.Margin = new Padding(4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4);
            groupBox3.Size = new Size(324, 365);
            groupBox3.TabIndex = 28;
            groupBox3.TabStop = false;
            groupBox3.Text = "Picture";
            // 
            // btnEDITphoto
            // 
            btnEDITphoto.FlatStyle = FlatStyle.Popup;
            btnEDITphoto.Location = new Point(166, 268);
            btnEDITphoto.Margin = new Padding(4);
            btnEDITphoto.Name = "btnEDITphoto";
            btnEDITphoto.Size = new Size(154, 44);
            btnEDITphoto.TabIndex = 6;
            btnEDITphoto.Text = "Update Image";
            btnEDITphoto.UseVisualStyleBackColor = true;
            btnEDITphoto.Click += BtnEDITphoto_Click;
            // 
            // pictureEmployee
            // 
            pictureEmployee.Dock = DockStyle.Top;
            pictureEmployee.Location = new Point(4, 26);
            pictureEmployee.Margin = new Padding(4);
            pictureEmployee.Name = "pictureEmployee";
            pictureEmployee.Size = new Size(316, 238);
            pictureEmployee.TabIndex = 0;
            pictureEmployee.TabStop = false;
            // 
            // frmEmployeeProfile
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1101, 513);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Font = new Font("Consolas", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "frmEmployeeProfile";
            ShowIcon = false;
            Text = "frmEmployeeProfile";
            Load += frmEmployeeProfile_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureEmployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtEmployeeID;
        private TextBox txtEmployeeName;
        private Label label3;
        private TextBox txtCNIC;
        private Label label4;
        private TextBox txtFatherName;
        private Label label5;
        private TextBox txtGSalary;
        private Label label6;
        private TextBox txtDesignation;
        private Label label7;
        private TextBox txtDeptID;
        private Label label8;
        private TextBox txtDOA;
        private Label label9;
        private TextBox txtDOB;
        private Label label10;
        private TextBox txtDOR;
        private Label label11;
        private TextBox txtDutyIn;
        private Label label12;
        private TextBox txtDutyOut;
        private Label label13;
        private GroupBox groupBox1;
        private Button btnPrint;
        private Button btnSave;
        private Button btnDelete;
        private Button btnOpen;
        private Button btnNew;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnEDITphoto;
        private PictureBox pictureEmployee;
        private ComboBox comboBox_txtDeptID;
        private TextBox txtDepoNo;
    }
}