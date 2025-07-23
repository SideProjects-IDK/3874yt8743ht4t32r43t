using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AgePay
{
    public partial class frmManualTimeRegister : Form
    {
        private readonly string connectionString = ConnectToSqlDatabase_MsSQL.connectionString; private System.Windows.Forms.Timer clockTimer;

        public frmManualTimeRegister()
        {
            InitializeComponent();
            clockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            clockTimer.Tick += (s, e) => lbl_current_time.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void frmManualTimeRegister_Load(object sender, EventArgs e)
        {
            group_box_phase_2.Enabled = false;
            group_box_phase_3.Enabled = false;
            clockTimer.Start();
            lbl_current_time.Text = DateTime.Now.ToString("HH:mm:ss");
            ShowEmployeeSearchForm();
        }

        private void ResetForm()
        {
            lbl_my_cardno.Text = "";
            lbl_my_name.Text = "";
            lbl_my_fathername.Text = "";
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = null;
            group_box_phase_2.Enabled = false;
            group_box_phase_3.Enabled = false;
            btn_settimein.Text = "Time-In";
            btn_set_timeout.Text = "Time-Out";
            ShowEmployeeSearchForm();
        }

        private void ShowEmployeeSearchForm()
        {
            try
            {
                using (Form searchForm = new Form
                {
                    Size = new Size(600, 430),
                    Text = "Search Employee",
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                })
                {
                    Label lblTitle = new Label
                    {
                        Text = $"Manual Attendance {DateTime.Today:yyyy-MM-dd}!",
                        Location = new Point(10, 10),
                        Size = new Size(560, 30),
                        Font = new Font("Segoe UI", 14, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    TextBox txtSearch = new TextBox
                    {
                        Location = new Point(10, 50),
                        Width = 460,
                        PlaceholderText = "Search by Card No."
                    };

                    DataGridView dataGridView = new DataGridView
                    {
                        Location = new Point(10, 80),
                        Size = new Size(560, 270),
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        ReadOnly = true,
                        AllowUserToAddRows = false,
                        AllowUserToDeleteRows = false,
                        SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    };

                    Button btnExit = new Button
                    {
                        Text = "Exit",
                        Location = new Point(480, 50),
                        Size = new Size(90, 25),
                        Font = new Font("Segoe UI", 9),
                        BackColor = Color.FromArgb(108, 117, 125),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat
                    };

                    DataTable dataTable = new DataTable();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT EmployeeID, EmployeeName, CNIC FROM EmployeeProfile";
                        using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                        {
                            adapter.Fill(dataTable);
                            dataGridView.DataSource = dataTable;
                        }
                    }

                    txtSearch.TextChanged += (s, args) =>
                    {
                        try
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                string query = "SELECT EmployeeID, EmployeeName, CNIC FROM EmployeeProfile WHERE  EmployeeID LIKE @EmployeeID";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@EmployeeID", $"%{txtSearch.Text}%");
                                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                                    {
                                        DataTable filteredTable = new DataTable();
                                        adapter.Fill(filteredTable);
                                        dataGridView.DataSource = filteredTable;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    dataGridView.DoubleClick += (s, args) =>
                    {
                        if (dataGridView.SelectedRows.Count > 0)
                        {
                            try
                            {
                                DataGridViewRow row = dataGridView.SelectedRows[0];
                                lbl_my_cardno.Text = row.Cells["CNIC"].Value?.ToString() ?? "";
                                lbl_my_name.Text = row.Cells["EmployeeName"].Value?.ToString() ?? "";

                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    string query = "SELECT FatherName, EmployeeImage FROM EmployeeProfile WHERE EmployeeID = @EmployeeID";
                                    using (SqlCommand command = new SqlCommand(query, connection))
                                    {
                                        command.Parameters.AddWithValue("@EmployeeID", Convert.ToInt32(row.Cells["EmployeeID"].Value));
                                        using (SqlDataReader reader = command.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                lbl_my_fathername.Text = reader["FatherName"]?.ToString() ?? "";
                                                pictureBox1.Image?.Dispose();
                                                pictureBox1.Image = null;
                                                if (reader["EmployeeImage"] != DBNull.Value)
                                                {
                                                    byte[] imageData = (byte[])reader["EmployeeImage"];
                                                    using (MemoryStream ms = new MemoryStream(imageData))
                                                    {
                                                        pictureBox1.Image = Image.FromStream(ms);
                                                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                group_box_phase_2.Enabled = true;
                                group_box_phase_3.Enabled = true;
                                UpdateButtonStates(Convert.ToInt32(row.Cells["EmployeeID"].Value), DateTime.Today);
                                searchForm.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };

                    btnExit.Click += (s, args) =>
                    {
                        searchForm.Close();
                        this.Close();
                    };

                    searchForm.Controls.Add(lblTitle);
                    searchForm.Controls.Add(txtSearch);
                    searchForm.Controls.Add(dataGridView);
                    searchForm.Controls.Add(btnExit);
                    searchForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening search form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateButtonStates(int employeeId, DateTime attendanceDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Check if AttendanceRegister table exists
                    string checkTableQuery = "SELECT 1 FROM sys.tables WHERE name = 'AttendanceRegister'";
                    using (SqlCommand checkCommand = new SqlCommand(checkTableQuery, connection))
                    {
                        object result = checkCommand.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("The table 'AttendanceRegister' does not exist in the database. Please verify the database schema.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = "SELECT TimeIn, TimeOut FROM AttendanceRegister WHERE EmployeeID = @EmployeeID AND [Date] = @AttendanceDate";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        command.Parameters.AddWithValue("@AttendanceDate", attendanceDate);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                btn_settimein.Enabled = reader["TimeIn"] == DBNull.Value;
                                btn_set_timeout.Enabled = reader["TimeIn"] != DBNull.Value && reader["TimeOut"] == DBNull.Value;

                                // Update button text based on TimeIn and TimeOut values
                                btn_settimein.Text = reader["TimeIn"] == DBNull.Value ? "Time-In" : $"Time-In ({((TimeSpan)reader["TimeIn"]).ToString(@"hh\:mm\:ss")})";
                                btn_set_timeout.Text = reader["TimeOut"] == DBNull.Value ? "Time-Out" : $"Time-Out ({((TimeSpan)reader["TimeOut"]).ToString(@"hh\:mm\:ss")})";
                            }
                            else
                            {
                                btn_settimein.Enabled = true;
                                btn_set_timeout.Enabled = false;
                                btn_settimein.Text = "Time-In";
                                btn_set_timeout.Text = "Time-Out";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_settimein_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lbl_my_cardno.Text))
                {
                    MessageBox.Show("Please select an employee from the grid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int employeeId = GetEmployeeIdFromCNIC(lbl_my_cardno.Text);
                DateTime attendanceDate = DateTime.Today;
                TimeSpan timeIn = DateTime.Now.TimeOfDay;

                DialogResult result = MessageBox.Show($"{lbl_my_name.Text} entering office by {timeIn.ToString(@"hh\:mm\:ss")} on {attendanceDate:yyyy-MM-dd}?", "Confirm Time-In", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                    INSERT INTO AttendanceRegister (EmployeeID, [Date], TimeIn, Leave_Type)
                    VALUES (@EmployeeID, @Date, @TimeIn, NULL)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        command.Parameters.AddWithValue("@Date", attendanceDate);
                        command.Parameters.Add("@TimeIn", SqlDbType.Time).Value = timeIn;
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Time-In recorded for {lbl_my_name.Text} at {timeIn.ToString(@"hh\:mm\:ss")}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateButtonStates(employeeId, attendanceDate);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_set_timeout_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lbl_my_cardno.Text))
                {
                    MessageBox.Show("Please select an employee from the grid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int employeeId = GetEmployeeIdFromCNIC(lbl_my_cardno.Text);
                DateTime attendanceDate = DateTime.Today;
                TimeSpan timeOut = DateTime.Now.TimeOfDay;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT TimeIn FROM AttendanceRegister WHERE EmployeeID = @EmployeeID AND [Date] = @AttendanceDate";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        command.Parameters.AddWithValue("@AttendanceDate", attendanceDate);
                        object result = command.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("No Time-In recorded for this employee today.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        TimeSpan timeIn = (TimeSpan)result;
                        if (timeOut <= timeIn)
                        {
                            MessageBox.Show("Time-Out must be after Time-In.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    DialogResult resultDialog = MessageBox.Show($"{lbl_my_name.Text} leaving office by {timeOut.ToString(@"hh\:mm\:ss")} on {attendanceDate:yyyy-MM-dd}?", "Confirm Time-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultDialog != DialogResult.Yes)
                        return;

                    query = "UPDATE AttendanceRegister SET TimeOut = @TimeOut WHERE EmployeeID = @EmployeeID AND [Date] = @AttendanceDate";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        command.Parameters.AddWithValue("@AttendanceDate", attendanceDate);
                        command.Parameters.Add("@TimeOut", SqlDbType.Time).Value = timeOut;
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Time-Out recorded for {lbl_my_name.Text} at {timeOut.ToString(@"hh\:mm\:ss")}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateButtonStates(employeeId, attendanceDate);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetEmployeeIdFromCNIC(string cnic)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT EmployeeID FROM EmployeeProfile WHERE CNIC = @CNIC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CNIC", cnic);
                    object result = command.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                        throw new Exception("Employee not found for the given CNIC.");
                    return Convert.ToInt32(result);
                }
            }
        }

        private void group_box_phase_3_Enter(object sender, EventArgs e) { }
        private void group_box_phase_2_Enter(object sender, EventArgs e) { }
        private void lbl_my_cardno_Click(object sender, EventArgs e) { }
        private void lbl_my_name_Click(object sender, EventArgs e) { }
        private void lbl_my_fathername_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }

}