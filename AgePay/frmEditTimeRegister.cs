using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using LumenWorks.Framework.IO.Csv;

namespace AgePay
{
    public partial class frmEditTimeRegister : Form
    {
        private readonly string connectionString = "Server=192.168.1.197;Database=AgePay;User Id=sa;Password=ilahia;";
        private DataTable dataTable;
        private DataRow selectedRow;

        public frmEditTimeRegister()
        {
            InitializeComponent();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void frmEditTimeRegister_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(string filter = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = string.IsNullOrEmpty(filter)
                        ? "SELECT TOP 1000 ar.[Date], ar.[EmployeeID], ep.EmployeeName, ar.[TimeIn], ar.[TimeOut], ar.[Leave_Type] FROM [AttendanceRegister] ar LEFT JOIN EmployeeProfile ep ON ar.EmployeeID = ep.EmployeeID"
                        : $"SELECT ar.[Date], ar.[EmployeeID], ep.EmployeeName, ar.[TimeIn], ar.[TimeOut], ar.[Leave_Type] FROM [AttendanceRegister] ar LEFT JOIN EmployeeProfile ep ON ar.EmployeeID = ep.EmployeeID WHERE {filter}";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(filter))
                        {
                            if (filter.Contains("EmployeeID"))
                                cmd.Parameters.AddWithValue("@EmployeeID", txtfiltercardno.Text.Trim());
                            else if (filter.Contains("Date"))
                                cmd.Parameters.AddWithValue("@Date", txtfilterdate.Text.Trim());
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dataTable = new DataTable();
                            da.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                            dataGridView1.Columns["Date"].HeaderText = "Date";
                            dataGridView1.Columns["EmployeeID"].HeaderText = "Employee ID";
                            dataGridView1.Columns["EmployeeName"].HeaderText = "Employee Name";
                            dataGridView1.Columns["TimeIn"].HeaderText = "Time In";
                            dataGridView1.Columns["TimeOut"].HeaderText = "Time Out";
                            dataGridView1.Columns["Leave_Type"].HeaderText = "Leave Type";
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dataGridView1.ReadOnly = true;

                            if (dataTable.Rows.Count > 0)
                            {
                                dataGridView1.Rows[0].Selected = true;
                                UpdateSelectedRowDetails(dataTable.Rows[0]);
                            }
                            else
                            {
                                ClearDetails();
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}\nError Number: {ex.Number}\nEnsure the server is running at 192.168.1.197 and credentials are correct.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                selectedRow = dataTable.Rows[rowIndex];
                UpdateSelectedRowDetails(selectedRow);
            }
            else
            {
                ClearDetails();
            }
        }

        private void UpdateSelectedRowDetails(DataRow row)
        {
            txt_cardno.Text = row["EmployeeID"]?.ToString() ?? "";
            txt_usersname.Text = row["EmployeeName"]?.ToString() ?? "";
            txt_timein.Text = row["TimeIn"]?.ToString() ?? "";
            txt_timeout.Text = row["TimeOut"]?.ToString() ?? "";
            label5.Text = row["Date"] != DBNull.Value ? ((DateTime)row["Date"]).ToString("yyyy-MM-dd") : "";
            LoadUserImage(Convert.ToInt32(row["EmployeeID"]));
        }

        private void ClearDetails()
        {
            txt_cardno.Text = "";
            txt_usersname.Text = "";
            txt_timein.Text = "";
            txt_timeout.Text = "";
            label5.Text = "";
            pictureBox_usersimage.Image = null;
            selectedRow = null;
        }

        private void pictureBox_usersimage_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                int employeeId = Convert.ToInt32(selectedRow["EmployeeID"]);
                ShowEmployeeProfile(employeeId);
            }
        }

        private void btn_update_record_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
            {
                MessageBox.Show("Please select a record to update.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form updateForm = new Form
            {
                Size = new Size(300, 200),
                Text = "Update Attendance",
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(240, 240, 240)
            })
            {
                Label lblTimeIn = new Label { Text = "Time In:", Location = new Point(20, 20), AutoSize = true, Font = new Font("Segoe UI", 9) };
                TextBox txtTimeIn = new TextBox { Text = txt_timein.Text, Location = new Point(100, 20), Width = 150, Font = new Font("Segoe UI", 9) };

                Label lblTimeOut = new Label { Text = "Time Out:", Location = new Point(20, 50), AutoSize = true, Font = new Font("Segoe UI", 9) };
                TextBox txtTimeOut = new TextBox { Text = txt_timeout.Text, Location = new Point(100, 50), Width = 150, Font = new Font("Segoe UI", 9) };

                Label lblLeaveType = new Label { Text = "Leave Type:", Location = new Point(20, 80), AutoSize = true, Font = new Font("Segoe UI", 9) };
                ComboBox cmbLeaveType = new ComboBox
                {
                    Location = new Point(100, 80),
                    Width = 150,
                    Font = new Font("Segoe UI", 9),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cmbLeaveType.Items.AddRange(new object[] { "", "C", "A", "S" });
                cmbLeaveType.SelectedItem = selectedRow["Leave_Type"] != DBNull.Value ? selectedRow["Leave_Type"].ToString() : "";

                Button btnSave = new Button { Text = "Save", Location = new Point(100, 130), Size = new Size(75, 30), Font = new Font("Segoe UI", 10), BackColor = Color.FromArgb(40, 167, 69), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, DialogResult = DialogResult.OK };
                Button btnCancel = new Button { Text = "Cancel", Location = new Point(180, 130), Size = new Size(75, 30), Font = new Font("Segoe UI", 10), BackColor = Color.FromArgb(108, 117, 125), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, DialogResult = DialogResult.Cancel };

                updateForm.Controls.AddRange(new Control[] { lblTimeIn, txtTimeIn, lblTimeOut, txtTimeOut, lblLeaveType, cmbLeaveType, btnSave, btnCancel });

                btnSave.Click += (s, ev) =>
                {
                    string leaveType = cmbLeaveType.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(leaveType) && !new[] { "C", "A", "S" }.Contains(leaveType))
                    {
                        MessageBox.Show("Leave Type must be 'C', 'A', or 'S'.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        updateForm.DialogResult = DialogResult.None;
                        return;
                    }

                    if (updateForm.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                conn.Open();
                                string updateQuery = @"
                                    UPDATE [AttendanceRegister]
                                    SET [TimeIn] = @TimeIn, [TimeOut] = @TimeOut, [Leave_Type] = @Leave_Type
                                    WHERE [Date] = @Date AND [EmployeeID] = @EmployeeID";
                                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@Date", selectedRow["Date"]);
                                    cmd.Parameters.AddWithValue("@EmployeeID", selectedRow["EmployeeID"]);
                                    cmd.Parameters.AddWithValue("@TimeIn", string.IsNullOrWhiteSpace(txtTimeIn.Text) ? (object)DBNull.Value : txtTimeIn.Text);
                                    cmd.Parameters.AddWithValue("@TimeOut", string.IsNullOrWhiteSpace(txtTimeOut.Text) ? (object)DBNull.Value : txtTimeOut.Text);
                                    cmd.Parameters.AddWithValue("@Leave_Type", string.IsNullOrEmpty(leaveType) ? (object)DBNull.Value : leaveType);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            MessageBox.Show("Attendance record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error updating record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                };

                updateForm.ShowDialog();
            }
        }

        private void txt_cardno_TextChanged(object sender, EventArgs e)
        {
            // Display-only; updated by selection
        }

        private void txt_timein_TextChanged(object sender, EventArgs e)
        {
            // Display-only; updated by selection
        }

        private void txt_timeout_TextChanged(object sender, EventArgs e)
        {
            // Display-only; updated by selection
        }

        private void txt_usersname_TextChanged(object sender, EventArgs e)
        {
            // Display-only; updated by selection
        }

        private void txtfilterdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string date = txtfilterdate.Text.Trim();
                if (!string.IsNullOrEmpty(date))
                {
                    LoadData("CONVERT(VARCHAR, ar.[Date], 23) LIKE @Date");
                }
                else
                {
                    LoadData();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtfiltercardno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cardNo = txtfiltercardno.Text.Trim();
                if (!string.IsNullOrEmpty(cardNo))
                {
                    LoadData("ar.[EmployeeID] LIKE @EmployeeID");
                }
                else
                {
                    LoadData();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Display-only; updated by selection
        }

        private void LoadUserImage(int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT EmployeeImage FROM EmployeeProfile WHERE EmployeeID = @EmployeeID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && reader["EmployeeImage"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])reader["EmployeeImage"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBox_usersimage.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                pictureBox_usersimage.Image = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowEmployeeProfile(int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT EmployeeID, EmployeeName, FatherName, Designation, DeptID, DOB, DOA, CNIC, GSalary, DOR, Address, DutyIn, DutyOut, EmployeeImage FROM EmployeeProfile WHERE EmployeeID = @EmployeeID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Form popup = new Form
                                {
                                    Size = new Size(400, 600),
                                    Text = "Employee Details",
                                    StartPosition = FormStartPosition.CenterParent,
                                    BackColor = Color.FromArgb(240, 240, 240)
                                };

                                PictureBox pictureBox = new PictureBox
                                {
                                    Location = new Point(10, 10),
                                    Size = new Size(150, 150),
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                    BorderStyle = BorderStyle.FixedSingle
                                };
                                if (reader["EmployeeImage"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])reader["EmployeeImage"];
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        pictureBox.Image = Image.FromStream(ms);
                                    }
                                }

                                int yOffset = 10;
                                Label lblName = new Label { Text = $"Name: {(reader["EmployeeName"] ?? "N/A")}", Location = new Point(170, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 20;
                                Label lblFatherName = new Label { Text = $"Father's Name: {(reader["FatherName"] ?? "N/A")}", Location = new Point(170, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 20;
                                Label lblCNIC = new Label { Text = $"CNIC: {(reader["CNIC"] ?? "N/A")}", Location = new Point(170, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 20;
                                Label lblDesignation = new Label { Text = $"Designation: {(reader["Designation"] ?? "N/A")}", Location = new Point(170, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 20;
                                Label lblDeptID = new Label { Text = $"Department ID: {(reader["DeptID"] ?? "N/A")}", Location = new Point(170, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 20;
                                Label lblDOB = new Label { Text = $"DOB: {(reader["DOB"] != DBNull.Value ? ((DateTime)reader["DOB"]).ToString("yyyy-MM-dd") : "N/A")}", Location = new Point(170, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 20;
                                Label lblDOA = new Label { Text = $"DOA: {(reader["DOA"] != DBNull.Value ? ((DateTime)reader["DOA"]).ToString("yyyy-MM-dd") : "N/A")}", Location = new Point(170, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 20;
                                Label lblDOR = new Label { Text = $"DOR: {(reader["DOR"] != DBNull.Value ? ((DateTime)reader["DOR"]).ToString("yyyy-MM-dd") : "N/A")}", Location = new Point(170, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 20;
                                Label lblGSalary = new Label { Text = $"Gross Salary: {(reader["GSalary"] != DBNull.Value ? ((decimal)reader["GSalary"]).ToString("F2") : "N/A")}", Location = new Point(170, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 20;
                                Label lblAddress = new Label { Text = $"Address: {(reader["Address"] ?? "N/A")}", Location = new Point(170, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 20;
                                Label lblDutyIn = new Label { Text = $"Duty In: {(reader["DutyIn"] ?? "N/A")}", Location = new Point(170, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 20;
                                Label lblDutyOut = new Label { Text = $"Duty Out: {(reader["DutyOut"] ?? "N/A")}", Location = new Point(170, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };

                                Button btnClose = new Button { Text = "Close", Location = new Point(150, 400), Size = new Size(100, 30), Font = new Font("Segoe UI", 10), BackColor = Color.FromArgb(108, 117, 125), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, DialogResult = DialogResult.OK };

                                popup.Controls.AddRange(new Control[] { pictureBox, lblName, lblFatherName, lblCNIC, lblDesignation, lblDeptID, lblDOB, lblDOA, lblDOR, lblGSalary, lblAddress, lblDutyIn, lblDutyOut, btnClose });
                                popup.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No profile found for this employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_import_data_csv_Click(object sender, EventArgs e)
        {
            ImportFile("CSV files (*.csv)|*.csv", ',');
        }

        private void btn_load_data_from_csv_Click(object sender, EventArgs e)
        {
            ImportFile("CSV files (*.csv)|*.csv", ',');
        }

        private void btn_load_data_from_tab_separated_file_Click(object sender, EventArgs e)
        {
            ImportFile("TSV files (*.tsv)|*.tsv", '\t');
        }

        private void ImportFile(string filter, char delimiter)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = filter;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable csvData = new DataTable();
                    try
                    {
                        using (var stream = File.OpenRead(openFileDialog.FileName))
                        using (var reader = new StreamReader(stream))
                        {
                            using (var csv = new CsvReader(reader, true, delimiter))
                            {
                                csvData.Load(csv);
                            }
                        }

                        using (Form confirmationForm = new Form())
                        {
                            confirmationForm.Text = $"Confirm {Path.GetExtension(openFileDialog.FileName).ToUpper().TrimStart('.')} Import";
                            confirmationForm.Size = new Size(600, 400);
                            confirmationForm.StartPosition = FormStartPosition.CenterParent;
                            confirmationForm.BackColor = Color.FromArgb(240, 240, 240);

                            DataGridView previewGrid = new DataGridView
                            {
                                Dock = DockStyle.Fill,
                                DataSource = csvData,
                                Font = new Font("Segoe UI", 9),
                                BackgroundColor = Color.White,
                                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                            };

                            Button btnConfirm = new Button
                            {
                                Text = "Import",
                                Location = new Point(250, 350),
                                Size = new Size(100, 30),
                                Font = new Font("Segoe UI", 10),
                                BackColor = Color.FromArgb(40, 167, 69),
                                ForeColor = Color.White,
                                FlatStyle = FlatStyle.Flat,
                                DialogResult = DialogResult.OK
                            };
                            Button btnCancel = new Button
                            {
                                Text = "Cancel",
                                Location = new Point(360, 350),
                                Size = new Size(100, 30),
                                Font = new Font("Segoe UI", 10),
                                BackColor = Color.FromArgb(108, 117, 125),
                                ForeColor = Color.White,
                                FlatStyle = FlatStyle.Flat,
                                DialogResult = DialogResult.Cancel
                            };

                            confirmationForm.Controls.AddRange(new Control[] { previewGrid, btnConfirm, btnCancel });

                            if (confirmationForm.ShowDialog() == DialogResult.OK)
                            {
                                foreach (DataRow row in csvData.Rows)
                                {
                                    string leaveType = row["Leave_Type"]?.ToString();
                                    if (!string.IsNullOrEmpty(leaveType) && !new[] { "C", "A", "S" }.Contains(leaveType))
                                    {
                                        MessageBox.Show($"Invalid Leave Type '{leaveType}' in file. Leave Type must be 'C', 'A', or 'S'.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                ImportToDatabase(csvData);
                                MessageBox.Show($"{Path.GetExtension(openFileDialog.FileName).ToUpper().TrimStart('.')} data imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ImportToDatabase(DataTable data)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (DataRow row in data.Rows)
                    {
                        string insertQuery = @"
                            INSERT INTO [AttendanceRegister] ([Date], [EmployeeID], [TimeIn], [TimeOut], [Leave_Type])
                            VALUES (@Date, @EmployeeID, @TimeIn, @TimeOut, @Leave_Type)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Date", row["Date"] != DBNull.Value ? (DateTime)row["Date"] : DBNull.Value);
                            cmd.Parameters.AddWithValue("@EmployeeID", row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : DBNull.Value);
                            cmd.Parameters.AddWithValue("@TimeIn", row["TimeIn"] != DBNull.Value ? row["TimeIn"].ToString() : DBNull.Value);
                            cmd.Parameters.AddWithValue("@TimeOut", row["TimeOut"] != DBNull.Value ? row["TimeOut"].ToString() : DBNull.Value);
                            string leaveType = row["Leave_Type"] != DBNull.Value ? row["Leave_Type"].ToString() : null;
                            cmd.Parameters.AddWithValue("@Leave_Type", string.IsNullOrEmpty(leaveType) ? (object)DBNull.Value : leaveType);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}