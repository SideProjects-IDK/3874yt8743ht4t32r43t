using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AgePay
{
    public partial class frmEditTimeRegister : Form
    {
        private readonly SqlConnection connection = ConnectToSqlDatabase_MsSQL.GetConnection();
        private DataTable dataTable;
        private DataRow selectedRow;

        public frmEditTimeRegister()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
            txt_search_date.TextChanged += txt_search_date_TextChanged;
            txt_search_date.Click += txt_search_date_Click; // Added click event for calendar
            txt_search_date.Enter += txt_search_date_Click; // Added enter event for calendar
        }

        private void frmEditTimeRegister_Load(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                LoadData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void LoadData(DateTime? filterDate = null)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT TOP 1000 ar.[Date], ar.[EmployeeID], ep.EmployeeName, ar.[TimeIn], ar.[TimeOut], ar.[Leave_Type] FROM [AttendanceRegister] ar LEFT JOIN EmployeeProfile ep ON ar.EmployeeID = ep.EmployeeID";
                if (filterDate.HasValue)
                {
                    query += " WHERE ar.[Date] = @Date";
                }
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    if (filterDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@Date", filterDate.Value.Date);
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
                            selectedRow = dataTable.Rows[0];
                        }
                        else
                        {
                            selectedRow = null;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void txt_search_date_TextChanged(object sender, EventArgs e)
        {
            string dateText = txt_search_date.Text.Trim();
            if (string.IsNullOrEmpty(dateText))
            {
                txt_search_date.ForeColor = Color.Black;
                LoadData();
                return;
            }

            if (DateTime.TryParse(dateText, out DateTime parsedDate))
            {
                txt_search_date.ForeColor = Color.Black;
                LoadData(parsedDate);
            }
            else
            {
                txt_search_date.ForeColor = Color.Red;
                dataGridView1.DataSource = null;
            }
        }

        private void txt_search_date_Click(object sender, EventArgs e)
        {
            using (MonthCalendar calendar = new MonthCalendar())
            {
                Form calendarForm = new Form
                {
                    Text = "Select Date",
                    Size = new Size(250, 220),
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    StartPosition = FormStartPosition.CenterParent,
                    MaximizeBox = false,
                    MinimizeBox = false
                };
                calendar.MaxSelectionCount = 1;
                calendar.Location = new Point(10, 10);
                if (DateTime.TryParse(txt_search_date.Text, out DateTime selectedDate))
                {
                    calendar.SetDate(selectedDate);
                }
                calendar.DateSelected += (s, args) =>
                {
                    txt_search_date.Text = args.Start.ToString("yyyy-MM-dd");
                    txt_search_date.ForeColor = Color.Black;
                    LoadData(args.Start);
                    calendarForm.Close();
                };
                calendarForm.Controls.Add(calendar);
                calendarForm.ShowDialog();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dataTable.Rows[e.RowIndex];
                int employeeId = Convert.ToInt32(selectedRow["EmployeeID"]);
                string employeeName = selectedRow["EmployeeName"]?.ToString() ?? "N/A";
                TimeSpan? timeIn = selectedRow["TimeIn"] != DBNull.Value ? (TimeSpan?)TimeSpan.Parse(selectedRow["TimeIn"].ToString()) : null;
                TimeSpan? timeOut = selectedRow["TimeOut"] != DBNull.Value ? (TimeSpan?)TimeSpan.Parse(selectedRow["TimeOut"].ToString()) : null;
                string leaveType = selectedRow["Leave_Type"]?.ToString()?.Trim() ?? "";
                DateTime date = (DateTime)selectedRow["Date"];
                ShowEditAttendanceForm(employeeId, employeeName, date, timeIn, timeOut, leaveType);
            }
        }

        private void ShowEditAttendanceForm(int employeeId, string employeeName, DateTime date, TimeSpan? timeIn, TimeSpan? timeOut, string leaveType)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                using (EditAttendanceForm editForm = new EditAttendanceForm(employeeId, employeeName, date, timeIn, timeOut, leaveType, connection))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        SaveAttendanceChange(employeeId, date, editForm.TimeIn, editForm.TimeOut, editForm.LeaveType);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening edit form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void SaveAttendanceChange(int employeeId, DateTime date, TimeSpan? timeIn, TimeSpan? timeOut, string leaveType)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string checkQuery = "SELECT COUNT(*) FROM [AttendanceRegister] WHERE [Date] = @Date AND [EmployeeID] = @EmployeeID";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@Date", date);
                    checkCmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        string updateQuery = @"
                            UPDATE [AttendanceRegister]
                            SET [TimeIn] = @TimeIn, [TimeOut] = @TimeOut, [Leave_Type] = @Leave_Type
                            WHERE [Date] = @Date AND [EmployeeID] = @EmployeeID";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                            cmd.Parameters.Add("@TimeIn", SqlDbType.Time).Value = timeIn.HasValue ? timeIn.Value : DBNull.Value;
                            cmd.Parameters.Add("@TimeOut", SqlDbType.Time).Value = timeOut.HasValue ? timeOut.Value : DBNull.Value;
                            cmd.Parameters.Add("@Leave_Type", SqlDbType.Char, 1).Value = string.IsNullOrWhiteSpace(leaveType) ? DBNull.Value : leaveType;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Attendance updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        string insertQuery = @"
                            INSERT INTO [AttendanceRegister] ([Date], [EmployeeID], [TimeIn], [TimeOut], [Leave_Type])
                            VALUES (@Date, @EmployeeID, @TimeIn, @TimeOut, @Leave_Type)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                            cmd.Parameters.Add("@TimeIn", SqlDbType.Time).Value = timeIn.HasValue ? timeIn.Value : DBNull.Value;
                            cmd.Parameters.Add("@TimeOut", SqlDbType.Time).Value = timeOut.HasValue ? timeOut.Value : DBNull.Value;
                            cmd.Parameters.Add("@Leave_Type", SqlDbType.Char, 1).Value = string.IsNullOrWhiteSpace(leaveType) ? DBNull.Value : leaveType;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Attendance added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    LoadData(date); // Refresh data with the current date
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving attendance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }

    public class EditAttendanceForm : Form
    {
        private readonly int employeeId;
        private readonly string employeeName;
        private readonly DateTime date;
        private readonly SqlConnection connection;
        private TextBox txtTimeIn;
        private TextBox txtTimeOut;
        private ComboBox cmbLeaveType;
        private PictureBox pictureBox;
        private Label lblHoliday;
        public TimeSpan? TimeIn => string.IsNullOrWhiteSpace(txtTimeIn.Text) ? null : TimeSpan.TryParse(txtTimeIn.Text, out TimeSpan time) ? time : null;
        public TimeSpan? TimeOut => string.IsNullOrWhiteSpace(txtTimeOut.Text) ? null : TimeSpan.TryParse(txtTimeOut.Text, out TimeSpan time) ? time : null;
        public string LeaveType => cmbLeaveType.SelectedItem?.ToString()?.Split('-')[0].Trim() ?? "";

        public EditAttendanceForm(int employeeId, string employeeName, DateTime date, TimeSpan? timeIn, TimeSpan? timeOut, string leaveType, SqlConnection connection)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.date = date;
            this.connection = connection;
            InitializeComponents(timeIn, timeOut, leaveType);
        }

        private void InitializeComponents(TimeSpan? timeIn, TimeSpan? timeOut, string leaveType)
        {
            this.Size = new Size(450, 500);
            this.Text = "Edit Attendance Record";
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblEmployeeID = new Label
            {
                Text = $"Employee ID: {employeeId}",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            Label lblEmployeeName = new Label
            {
                Text = $"Name: {employeeName}",
                Location = new Point(20, 50),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            Label lblDate = new Label
            {
                Text = $"Date: {date:yyyy-MM-dd}",
                Location = new Point(20, 80),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            lblHoliday = new Label
            {
                Text = "Holiday: None",
                Location = new Point(20, 110),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.DarkRed
            };

            pictureBox = new PictureBox
            {
                Location = new Point(20, 140),
                Size = new Size(150, 150),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.Fixed3D,
                BackColor = Color.White
            };
            pictureBox.Click += PictureBox_Click;

            Label lblTimeIn = new Label
            {
                Text = "Time In (HH:mm:ss):",
                Location = new Point(20, 300),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };

            txtTimeIn = new TextBox
            {
                Text = timeIn?.ToString(@"hh\:mm\:ss") ?? "",
                Location = new Point(190, 300),
                Width = 200,
                Font = new Font("Segoe UI", 9)
            };

            Label lblTimeOut = new Label
            {
                Text = "Time Out (HH:mm:ss):",
                Location = new Point(20, 330),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };

            txtTimeOut = new TextBox
            {
                Text = timeOut?.ToString(@"hh\:mm\:ss") ?? "",
                Location = new Point(190, 330),
                Width = 200,
                Font = new Font("Segoe UI", 9)
            };

            Label lblLeaveType = new Label
            {
                Text = "Leave Type:",
                Location = new Point(20, 360),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };

            cmbLeaveType = new ComboBox
            {
                Location = new Point(150, 360),
                Width = 200,
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbLeaveType.Items.AddRange(new object[] { "", "C - Casual", "A - Annual", "S - Sick" });
            cmbLeaveType.SelectedItem = leaveType switch
            {
                "C" => "C - Casual",
                "A" => "A - Annual",
                "S" => "S - Sick",
                _ => ""
            };

            Button btnSave = new Button
            {
                Text = "Save",
                Location = new Point(150, 400),
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
                Location = new Point(260, 400),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.Cancel
            };

            btnSave.Click += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtTimeIn.Text) && !TimeSpan.TryParseExact(txtTimeIn.Text, @"hh\:mm\:ss", null, out _))
                {
                    MessageBox.Show("Time In must be a valid time (HH:mm:ss).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (!string.IsNullOrWhiteSpace(txtTimeOut.Text) && !TimeSpan.TryParseExact(txtTimeOut.Text, @"hh\:mm\:ss", null, out _))
                {
                    MessageBox.Show("Time Out must be a valid time (HH:mm:ss).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }
                string selectedLeaveType = cmbLeaveType.SelectedItem?.ToString()?.Split('-')[0].Trim() ?? "";
                if (!string.IsNullOrEmpty(selectedLeaveType) && !new[] { "C", "A", "S" }.Contains(selectedLeaveType))
                {
                    MessageBox.Show("Leave Type must be 'C', 'A', 'S', or empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to save changes?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                }
            };

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                LoadEmployeeImage();
                LoadHolidayInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            this.Controls.AddRange(new Control[] { lblEmployeeID, lblEmployeeName, lblDate, lblHoliday, pictureBox, lblTimeIn, txtTimeIn, lblTimeOut, txtTimeOut, lblLeaveType, cmbLeaveType, btnSave, btnCancel });
        }

        private void LoadEmployeeImage()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string query = "SELECT EmployeeImage FROM EmployeeProfile WHERE EmployeeID = @EmployeeID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["EmployeeImage"] != DBNull.Value)
                        {
                            byte[] imageData = (byte[])reader["EmployeeImage"];
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageData))
                            {
                                pictureBox.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pictureBox.Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void LoadHolidayInfo()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string query = "SELECT HolidayDetail FROM Holidays WHERE [Date] = @Date";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Date", date);
                    object result = cmd.ExecuteScalar();
                    lblHoliday.Text = result != null ? $"Holiday: {result}" : "Holiday: None";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading holiday info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                using (Form profileForm = new Form
                {
                    Size = new Size(400, 600),
                    Text = "Employee Profile",
                    StartPosition = FormStartPosition.CenterParent,
                    BackColor = Color.FromArgb(240, 240, 240),
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                })
                {
                    PictureBox profilePicture = new PictureBox
                    {
                        Location = new Point(20, 20),
                        Size = new Size(150, 150),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderStyle = BorderStyle.Fixed3D
                    };

                    int yOffset = 20;
                    Label[] labels = new Label[10];
                    string query = "SELECT EmployeeName, FatherName, Designation, DeptID, DOB, DOA, CNIC, GrossSalary, Address, DutyIn, DutyOut FROM EmployeeProfile WHERE EmployeeID = @EmployeeID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["EmployeeImage"] != DBNull.Value)
                                {
                                    byte[] imageData = (byte[])reader["EmployeeImage"];
                                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageData))
                                    {
                                        profilePicture.Image = Image.FromStream(ms);
                                    }
                                }

                                labels[0] = new Label { Text = $"Name: {reader["EmployeeName"] ?? "N/A"}", Location = new Point(180, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 30;
                                labels[1] = new Label { Text = $"Father's Name: {reader["FatherName"] ?? "N/A"}", Location = new Point(180, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 30;
                                labels[2] = new Label { Text = $"Designation: {reader["Designation"] ?? "N/A"}", Location = new Point(180, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 30;
                                labels[3] = new Label { Text = $"Department ID: {reader["DeptID"] ?? "N/A"}", Location = new Point(180, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 30;
                                labels[4] = new Label { Text = $"DOB: {(reader["DOB"] != DBNull.Value ? Convert.ToDateTime(reader["DOB"]).ToString("yyyy-MM-dd") : "N/A")}", Location = new Point(180, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 30;
                                labels[5] = new Label { Text = $"DOA: {(reader["DOA"] != DBNull.Value ? Convert.ToDateTime(reader["DOA"]).ToString("yyyy-MM-dd") : "N/A")}", Location = new Point(180, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 30;
                                labels[6] = new Label { Text = $"CNIC: {reader["CNIC"] ?? "N/A"}", Location = new Point(180, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 30;
                                labels[7] = new Label { Text = $"Gross Salary: {(reader["GrossSalary"] != DBNull.Value ? Convert.ToDecimal(reader["GrossSalary"]).ToString("F2") : "N/A")}", Location = new Point(180, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 30;
                                labels[8] = new Label { Text = $"Address: {reader["Address"] ?? "N/A"}", Location = new Point(180, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                                yOffset += 30;
                                labels[9] = new Label { Text = $"Duty Hours: {(reader["DutyIn"] != DBNull.Value && reader["DutyOut"] != DBNull.Value ? $"{reader["DutyIn"]} - {reader["DutyOut"]}" : "N/A")}", Location = new Point(180, yOffset), AutoSize = true, Font = new Font("Segoe UI", 9) };
                            }
                            else
                            {
                                MessageBox.Show("Employee profile not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    Button btnClose = new Button
                    {
                        Text = "Close",
                        Location = new Point(150, yOffset + 50),
                        Size = new Size(100, 30),
                        Font = new Font("Segoe UI", 10),
                        BackColor = Color.FromArgb(108, 117, 125),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        DialogResult = DialogResult.OK
                    };

                    profileForm.Controls.AddRange(new Control[] { profilePicture, btnClose });
                    profileForm.Controls.AddRange(labels);
                    profileForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}