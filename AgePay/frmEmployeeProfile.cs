using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace AgePay
{
    public partial class frmEmployeeProfile : Form
    {
        private readonly SqlConnection connection = ConnectToSqlDatabase_MsSQL.GetConnection();
        private PrintDocument printDocument = new PrintDocument();
        private DataTable printData;

        public frmEmployeeProfile()
        {
            InitializeComponent();
            SetFormFieldsEnabled(false);
            printDocument.PrintPage += PrintDocument_PrintPage; ;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (printData != null && printData.Rows.Count > 0)
            {
                DataRow row = printData.Rows[0];
                float yPos = 100f;
                float leftMargin = e.MarginBounds.Left + 50f;
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font bodyFont = new Font("Arial", 10);

                if (row["EmployeeImage"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])row["EmployeeImage"];
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image img = Image.FromStream(ms);
                        e.Graphics.DrawImage(img, leftMargin, yPos, 100, 100);
                        yPos += 120;
                    }
                }

                e.Graphics.DrawString("Employee Profile", titleFont, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString("Employee Profile", titleFont).Width) / 2, e.MarginBounds.Top + 20);
                yPos += 50;

                string[] labels = { "Employee ID:", "Name:", "Father's Name:", "Designation:", "Department ID:", "Date of Birth:", "Date of Appointment:", "CNIC:", "Gross Salary:", "Address:", "Duty Hours:" };
                string[] values = {
            row["EmployeeID"].ToString(),
            row["EmployeeName"].ToString(),
            row["FatherName"].ToString(),
            row["Designation"].ToString(),
            row["DeptID"].ToString(),
            row["DOB"] != DBNull.Value ? Convert.ToDateTime(row["DOB"]).ToString("yyyy-MM-dd") : "",
            row["DOA"] != DBNull.Value ? Convert.ToDateTime(row["DOA"]).ToString("yyyy-MM-dd") : "",
            row["CNIC"].ToString(),
            row["GrossSalary"] != DBNull.Value ? Convert.ToDecimal(row["GrossSalary"]).ToString("F2") : "",
            row["Address"].ToString(),
            row["DutyIn"] != DBNull.Value && row["DutyOut"] != DBNull.Value ? $"{row["DutyIn"]} - {row["DutyOut"]}" : ""
        };

                for (int i = 0; i < labels.Length; i++)
                {
                    e.Graphics.DrawString(labels[i], headerFont, Brushes.Black, leftMargin, yPos);
                    e.Graphics.DrawString(values[i], bodyFont, Brushes.Black, leftMargin + 150, yPos);
                    yPos += 30;
                }

                e.Graphics.DrawString("Printed on: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), bodyFont, Brushes.Black, leftMargin, yPos + 20);
            }
        }

        private void frmEmployeeProfile_Load(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            try
            {
                string query = "SELECT DISTINCT DeptID FROM EmployeeProfile ORDER BY DeptID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming txtDeptID is a TextBox, we can't add items directly
                            // This method can be used for validation or future ComboBox upgrade
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetFormFieldsEnabled(bool enabled)
        {
            txtEmployeeID.Enabled = enabled;
            txtEmployeeName.Enabled = enabled;
            txtFatherName.Enabled = enabled;
            txtDesignation.Enabled = enabled;
            txtDeptID.Enabled = enabled;
            txtDOB.Enabled = enabled;
            txtDOA.Enabled = enabled;
            txtCNIC.Enabled = enabled;
            txtGSalary.Enabled = enabled;
            txtDepoNo.Enabled = enabled;
            txtDutyIn.Enabled = enabled;
            txtDutyOut.Enabled = enabled;
            pictureEmployee.Enabled = enabled;
            btnSave.Enabled = enabled;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                txtEmployeeID.Text = "";
                txtEmployeeName.Text = "";
                txtFatherName.Text = "";
                txtDesignation.Text = "";
                txtDeptID.Text = "";
                txtDOB.Text = "";
                txtDOA.Text = "";
                txtCNIC.Text = "";
                txtGSalary.Text = "";
                txtDepoNo.Text = "";
                txtDutyIn.Text = "";
                txtDutyOut.Text = "";
                pictureEmployee.Image?.Dispose();
                pictureEmployee.Image = null;

                SetFormFieldsEnabled(true);
                txtEmployeeID.Enabled = false;

                string query = "SELECT ISNULL(MAX(EmployeeID), 0) FROM EmployeeProfile";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int newEmployeeID = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    txtEmployeeID.Text = newEmployeeID.ToString();
                }

                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    ofd.Title = "Select Employee Photo (Optional)";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fileInfo = new FileInfo(ofd.FileName);
                        if (fileInfo.Length > 2 * 1024 * 1024)
                        {
                            MessageBox.Show("Image size exceeds 2MB limit.", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        using (Image tempImage = Image.FromFile(ofd.FileName))
                        {
                            if (tempImage.Width > 2000 || tempImage.Height > 2000)
                            {
                                MessageBox.Show("Image dimensions exceed 2000x2000 pixels.", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            pictureEmployee.Image?.Dispose();
                            pictureEmployee.Image = (Image)tempImage.Clone();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No image selected. Recommended: Max size 2MB, Max dimensions 2000x2000 pixels.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmployeeID.Text) ||
                    string.IsNullOrWhiteSpace(txtEmployeeName.Text) ||
                    string.IsNullOrWhiteSpace(txtDeptID.Text))
                {
                    MessageBox.Show("Employee ID, Name, and Department ID are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtEmployeeID.Text, out int employeeId))
                {
                    MessageBox.Show("Employee ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtDeptID.Text, out int deptId))
                {
                    MessageBox.Show("Department ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtEmployeeName.Text.Length > 50)
                {
                    MessageBox.Show("Employee Name must not exceed 50 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtFatherName.Text) && txtFatherName.Text.Length > 50)
                {
                    MessageBox.Show("Father's Name must not exceed 50 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtDesignation.Text) && txtDesignation.Text.Length > 50)
                {
                    MessageBox.Show("Designation must not exceed 50 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtCNIC.Text) && txtCNIC.Text.Length > 50)
                {
                    MessageBox.Show("CNIC must not exceed 50 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtDepoNo.Text) && txtDepoNo.Text.Length > 250)
                {
                    MessageBox.Show("Address must not exceed 250 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal? gSalary = null;
                if (!string.IsNullOrWhiteSpace(txtGSalary.Text))
                {
                    if (!decimal.TryParse(txtGSalary.Text, out decimal parsedGSalary) || parsedGSalary < 0 || parsedGSalary > 99999999.99m)
                    {
                        MessageBox.Show("Gross Salary must be a valid decimal number between 0 and 99999999.99.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    gSalary = parsedGSalary;
                }

                DateTime? dob = null;
                if (!string.IsNullOrWhiteSpace(txtDOB.Text))
                {
                    if (!DateTime.TryParseExact(txtDOB.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDOB))
                    {
                        MessageBox.Show("Date of Birth must be a valid date (yyyy-MM-dd).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dob = parsedDOB;
                }

                DateTime? doa = null;
                if (!string.IsNullOrWhiteSpace(txtDOA.Text))
                {
                    if (!DateTime.TryParseExact(txtDOA.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDOA))
                    {
                        MessageBox.Show("Date of Appointment must be a valid date (yyyy-MM-dd).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    doa = parsedDOA;
                }

                TimeSpan? dutyIn = null;
                if (!string.IsNullOrWhiteSpace(txtDutyIn.Text))
                {
                    if (!TimeSpan.TryParseExact(txtDutyIn.Text, @"hh\:mm\:ss", null, out TimeSpan parsedDutyIn))
                    {
                        MessageBox.Show("Duty In must be a valid time (HH:mm:ss).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dutyIn = parsedDutyIn;
                }

                TimeSpan? dutyOut = null;
                if (!string.IsNullOrWhiteSpace(txtDutyOut.Text))
                {
                    if (!TimeSpan.TryParseExact(txtDutyOut.Text, @"hh\:mm\:ss", null, out TimeSpan parsedDutyOut))
                    {
                        MessageBox.Show("Duty Out must be a valid time (HH:mm:ss).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dutyOut = parsedDutyOut;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to save this employee?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;

                int count; // Declare count outside the using block
                string checkQuery = "SELECT COUNT(*) FROM EmployeeProfile WHERE EmployeeID = @EmployeeID";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@EmployeeID", employeeId);
                    count = (int)checkCommand.ExecuteScalar();
                }

                string query = count == 0
                    ? @"
                        INSERT INTO EmployeeProfile (
                            EmployeeID, EmployeeName, FatherName, Designation, DeptID, 
                            DOB, DOA, CNIC, GrossSalary, Address, DutyIn, DutyOut, UserID, PostOn, EmployeeImage
                        )
                        VALUES (
                            @EmployeeID, @EmployeeName, @FatherName, @Designation, @DeptID, 
                            @DOB, @DOA, @CNIC, @GrossSalary, @Address, @DutyIn, @DutyOut, @UserID, @PostOn, @EmployeeImage
                        )"
                    : @"
                        UPDATE EmployeeProfile
                        SET EmployeeName = @EmployeeName,
                            FatherName = @FatherName,
                            Designation = @Designation,
                            DeptID = @DeptID,
                            DOB = @DOB,
                            DOA = @DOA,
                            CNIC = @CNIC,
                            GrossSalary = @GrossSalary,
                            Address = @Address,
                            DutyIn = @DutyIn,
                            DutyOut = @DutyOut,
                            UserID = @UserID,
                            PostOn = @PostOn,
                            EmployeeImage = @EmployeeImage
                        WHERE EmployeeID = @EmployeeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeId);
                    command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                    command.Parameters.AddWithValue("@FatherName", string.IsNullOrWhiteSpace(txtFatherName.Text) ? (object)DBNull.Value : txtFatherName.Text);
                    command.Parameters.AddWithValue("@Designation", string.IsNullOrWhiteSpace(txtDesignation.Text) ? (object)DBNull.Value : txtDesignation.Text);
                    command.Parameters.AddWithValue("@DeptID", deptId);
                    command.Parameters.AddWithValue("@DOB", dob.HasValue ? (object)dob.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@DOA", doa.HasValue ? (object)doa.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@CNIC", string.IsNullOrWhiteSpace(txtCNIC.Text) ? (object)DBNull.Value : txtCNIC.Text);
                    command.Parameters.AddWithValue("@GrossSalary", gSalary.HasValue ? (object)gSalary.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(txtDepoNo.Text) ? (object)DBNull.Value : txtDepoNo.Text);
                    command.Parameters.Add("@DutyIn", SqlDbType.Time).Value = dutyIn.HasValue ? (object)dutyIn.Value : DBNull.Value;
                    command.Parameters.Add("@DutyOut", SqlDbType.Time).Value = dutyOut.HasValue ? (object)dutyOut.Value : DBNull.Value;
                    command.Parameters.AddWithValue("@UserID", DBNull.Value);
                    command.Parameters.AddWithValue("@PostOn", DateTime.Now);
                    command.Parameters.AddWithValue("@EmployeeImage", pictureEmployee.Image != null ? ImageToByteArray(pictureEmployee.Image) : (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show($"Employee {(count == 0 ? "inserted" : "updated")} successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetFormFieldsEnabled(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                using (Form gridForm = new Form())
                {
                    TextBox txtSearch = new TextBox
                    {
                        Location = new Point(10, 10),
                        Width = 200,
                        PlaceholderText = "Search by Name or CNIC"
                    };

                    DataGridView dataGridView = new DataGridView
                    {
                        Location = new Point(10, 40),
                        Size = new Size(760, 310),
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        ReadOnly = true
                    };

                    DataTable dataTable = new DataTable();
                    string query = "SELECT EmployeeID, EmployeeName, FatherName, Designation, DeptID, DOB, DOA, CNIC, GrossSalary, Address, DutyIn, DutyOut, EmployeeImage FROM EmployeeProfile";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dataTable);
                        dataGridView.DataSource = dataTable;
                    }

                    txtSearch.TextChanged += (s, args) =>
                    {
                        try
                        {
                            string query = "SELECT EmployeeID, EmployeeName, FatherName, Designation, DeptID, DOB, DOA, CNIC, GrossSalary, Address, DutyIn, DutyOut, EmployeeImage FROM EmployeeProfile WHERE EmployeeName LIKE @SearchText OR CNIC LIKE @SearchText";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@SearchText", $"%{txtSearch.Text}%");
                                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                                {
                                    DataTable filteredTable = new DataTable();
                                    adapter.Fill(filteredTable);
                                    dataGridView.DataSource = filteredTable;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error searching: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    dataGridView.CellDoubleClick += (s, args) =>
                    {
                        if (dataGridView.CurrentRow != null)
                        {
                            DataGridViewRow row = dataGridView.CurrentRow;
                            txtEmployeeID.Text = row.Cells["EmployeeID"].Value?.ToString() ?? "";
                            txtEmployeeName.Text = row.Cells["EmployeeName"].Value?.ToString() ?? "";
                            txtFatherName.Text = row.Cells["FatherName"].Value?.ToString() ?? "";
                            txtDesignation.Text = row.Cells["Designation"].Value?.ToString() ?? "";
                            txtDeptID.Text = row.Cells["DeptID"].Value?.ToString() ?? "";
                            txtDOB.Text = row.Cells["DOB"].Value != DBNull.Value ? Convert.ToDateTime(row.Cells["DOB"].Value).ToString("yyyy-MM-dd") : "";
                            txtDOA.Text = row.Cells["DOA"].Value != DBNull.Value ? Convert.ToDateTime(row.Cells["DOA"].Value).ToString("yyyy-MM-dd") : "";
                            txtCNIC.Text = row.Cells["CNIC"].Value?.ToString() ?? "";
                            txtGSalary.Text = row.Cells["GrossSalary"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["GrossSalary"].Value).ToString("F2") : "";
                            txtDepoNo.Text = row.Cells["Address"].Value?.ToString() ?? "";
                            txtDutyIn.Text = row.Cells["DutyIn"].Value != DBNull.Value ? row.Cells["DutyIn"].Value.ToString() : "";
                            txtDutyOut.Text = row.Cells["DutyOut"].Value != DBNull.Value ? row.Cells["DutyOut"].Value.ToString() : "";
                            if (row.Cells["EmployeeImage"].Value != DBNull.Value)
                            {
                                byte[] imageData = (byte[])row.Cells["EmployeeImage"].Value;
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureEmployee.Image?.Dispose();
                                    pictureEmployee.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                pictureEmployee.Image?.Dispose();
                                pictureEmployee.Image = null;
                            }
                            SetFormFieldsEnabled(true);
                            txtEmployeeID.Enabled = false;
                            gridForm.Close();
                        }
                    };

                    gridForm.Controls.Add(txtSearch);
                    gridForm.Controls.Add(dataGridView);
                    gridForm.Size = new Size(800, 400);
                    gridForm.Text = "Select Employee";
                    gridForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    gridForm.MaximizeBox = false;
                    gridForm.MinimizeBox = false;
                    gridForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmployeeID.Text) || !int.TryParse(txtEmployeeID.Text, out int employeeId))
                {
                    MessageBox.Show("Please select a valid employee to print.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "SELECT EmployeeID, EmployeeName, FatherName, Designation, DeptID, DOB, DOA, CNIC, GrossSalary, Address, DutyIn, DutyOut, EmployeeImage FROM EmployeeProfile WHERE EmployeeID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        printData = new DataTable();
                        adapter.Fill(printData);

                        if (printData.Rows.Count > 0)
                        {
                            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
                            {
                                Document = printDocument
                            };
                            printPreviewDialog.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("No data found for the selected employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
