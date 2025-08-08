using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AgePay
{
    public partial class frmManualTimeRegister : Form
    {
        private readonly string connectionString = ConnectToSqlDatabase_MsSQL.connectionString;
        private System.Windows.Forms.Timer clockTimer;
        private TextBox txtEmployeeID;
        private TextBox txtName;
        private GroupBox groupBoxAttendance;
        private Label lblCurrentTime;
        private Button btnTimeIn;
        private Button btnTimeOut;
        private int employeeId;

        public frmManualTimeRegister()
        {
            InitializeComponent();
            this.Size = new Size(500, 400);
            this.BackColor = Color.FromArgb(245, 245, 245); // Light gray background
            this.Font = new Font("Segoe UI", 10); // Modern, clean font
            clockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            clockTimer.Tick += (s, e) =>
            {
                if (lblCurrentTime != null)
                    lblCurrentTime.Text = $"Current Time: {DateTime.Now:HH:mm:ss}";
            };
        }

        private void frmManualTimeRegister_Load(object sender, EventArgs e)
        {
            // Initialize Labels and TextBoxes, centered with improved spacing
            Label lblEmployeeID = new Label
            {
                Text = "Employee ID:",
                Location = new Point((this.ClientSize.Width - 100) / 2 - 180, this.ClientSize.Height / 2 - 80),
                Size = new Size(100, 25),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 11, FontStyle.Regular)
            };

            txtEmployeeID = new TextBox
            {
                Location = new Point((this.ClientSize.Width - 250) / 2, this.ClientSize.Height / 2 - 80),
                Size = new Size(250, 30),
                TabIndex = 0,
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblName = new Label
            {
                Text = "Name:",
                Location = new Point((this.ClientSize.Width - 100) / 2 - 180, this.ClientSize.Height / 2 - 30),
                Size = new Size(100, 25),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 11, FontStyle.Regular)
            };

            txtName = new TextBox
            {
                Location = new Point((this.ClientSize.Width - 250) / 2, this.ClientSize.Height / 2 - 30),
                Size = new Size(250, 30),
                TabIndex = 1,
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Add event handler for Enter key
            txtEmployeeID.KeyDown += TextBox_KeyDown;
            txtName.KeyDown += TextBox_KeyDown;

            // Add controls to form
            this.Controls.Add(lblEmployeeID);
            this.Controls.Add(txtEmployeeID);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);

            // Start the clock timer
            clockTimer.Start();
            txtEmployeeID.Focus();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                try
                {
                    // Validate EmployeeID and fetch EmployeeName
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT EmployeeName FROM EmployeeProfile WHERE EmployeeID = @EmployeeID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                txtName.Text = result.ToString();
                                txtEmployeeID.ForeColor = Color.Black;
                                txtName.ForeColor = Color.Black;
                            }
                            else
                            {
                                MessageBox.Show("Employee ID not found.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtEmployeeID.ForeColor = Color.Red;
                                txtName.Text = "";
                                txtName.ForeColor = Color.Black;
                                return;
                            }
                        }
                    }

                    employeeId = GetEmployeeIdFromEmployeeID(txtEmployeeID.Text);
                    txtEmployeeID.Enabled = false;
                    txtName.Enabled = false;

                    // Create GroupBox for attendance controls
                    groupBoxAttendance = new GroupBox
                    {
                        Text = "Attendance",
                        Location = new Point((this.ClientSize.Width - 400) / 2, this.ClientSize.Height / 2 + 20),
                        Size = new Size(400, 120),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        BackColor = Color.FromArgb(230, 230, 230)
                    };

                    lblCurrentTime = new Label
                    {
                        Text = $"Current Time: {DateTime.Now:HH:mm:ss}",
                        Location = new Point(20, 30),
                        Size = new Size(360, 25),
                        Font = new Font("Segoe UI", 11)
                    };

                    btnTimeIn = new Button
                    {
                        Text = "Time-In",
                        Location = new Point(20, 70),
                        Size = new Size(180, 35),
                        TabIndex = 2,
                        Font = new Font("Segoe UI", 10),
                        BackColor = Color.White, // Default to white for enabled
                        ForeColor = Color.Black,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(56, 189, 85) }
                    };

                    btnTimeOut = new Button
                    {
                        Text = "Time-Out",
                        Location = new Point(200, 70),
                        Size = new Size(180, 35),
                        TabIndex = 3,
                        Font = new Font("Segoe UI", 10),
                        BackColor = Color.White, // Default to white for enabled
                        ForeColor = Color.Black,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(240, 73, 89) }
                    };

                    btnTimeIn.Click += BtnTimeIn_Click;
                    btnTimeOut.Click += BtnTimeOut_Click;

                    groupBoxAttendance.Controls.Add(lblCurrentTime);
                    groupBoxAttendance.Controls.Add(btnTimeIn);
                    groupBoxAttendance.Controls.Add(btnTimeOut);
                    this.Controls.Add(groupBoxAttendance);

                    UpdateButtonStates(employeeId, DateTime.Today);
                    btnTimeIn.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetForm();
                }
            }
        }

        private void UpdateButtonStates(int employeeId, DateTime attendanceDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string checkTableQuery = "SELECT 1 FROM sys.tables WHERE name = 'AttendanceRegister'";
                    using (SqlCommand checkCommand = new SqlCommand(checkTableQuery, connection))
                    {
                        object result = checkCommand.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("The table 'AttendanceRegister' does not exist in the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                bool hasTimeIn = reader["TimeIn"] != DBNull.Value;
                                bool hasTimeOut = reader["TimeOut"] != DBNull.Value;

                                btnTimeIn.Enabled = !hasTimeIn;
                                btnTimeOut.Enabled = hasTimeIn && !hasTimeOut;

                                // Always show time in button text if available
                                btnTimeIn.Text = hasTimeIn ? $"Time-In ({((TimeSpan)reader["TimeIn"]).ToString(@"hh\:mm\:ss")})" : "Time-In";
                                btnTimeOut.Text = hasTimeOut ? $"Time-Out ({((TimeSpan)reader["TimeOut"]).ToString(@"hh\:mm\:ss")})" : "Time-Out";

                                // Set button colors based on enabled state
                                btnTimeIn.BackColor = btnTimeIn.Enabled ? Color.White : Color.Red;
                                btnTimeOut.BackColor = btnTimeOut.Enabled ? Color.White : Color.Red;

                                // Show message box for disabled buttons
                                if (!btnTimeIn.Enabled)
                                {
                                    MessageBox.Show($"Time-In button is disabled because you were recorded entering at {((TimeSpan)reader["TimeIn"]).ToString(@"hh\:mm\:ss")}",
                                        "Button Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                if (!btnTimeOut.Enabled)
                                {
                                    string message = hasTimeOut
                                        ? $"Time-Out button is disabled because you were recorded leaving at {((TimeSpan)reader["TimeOut"]).ToString(@"hh\:mm\:ss")}"
                                        : "Time-Out button is disabled because no Time-In was recorded for today.";
                                    MessageBox.Show(message, "Button Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                btnTimeIn.Enabled = true;
                                btnTimeOut.Enabled = false;
                                btnTimeIn.Text = "Time-In";
                                btnTimeOut.Text = "Time-Out";

                                // Set button colors based on enabled state
                                btnTimeIn.BackColor = Color.White;
                                btnTimeOut.BackColor = Color.Red;

                                // Show message for disabled Time-Out button
                                MessageBox.Show("Time-Out button is disabled because no Time-In was recorded for today.",
                                    "Button Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnTimeIn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime attendanceDate = DateTime.Today;
                TimeSpan timeIn = DateTime.Now.TimeOfDay;

                DialogResult result = MessageBox.Show($"{txtName.Text} entering office by {timeIn.ToString(@"hh\:mm\:ss")} on {attendanceDate:yyyy-MM-dd}?",
                    "Confirm Time-In", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                MessageBox.Show($"Time-In recorded for {txtName.Text} at {timeIn.ToString(@"hh\:mm\:ss")}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateButtonStates(employeeId, attendanceDate);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTimeOut_Click(object sender, EventArgs e)
        {
            try
            {
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

                    DialogResult resultDialog = MessageBox.Show($"{txtName.Text} leaving office by {timeOut.ToString(@"hh\:mm\:ss")} on {attendanceDate:yyyy-MM-dd}?",
                        "Confirm Time-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                MessageBox.Show($"Time-Out recorded for {txtName.Text} at {timeOut.ToString(@"hh\:mm\:ss")}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateButtonStates(employeeId, attendanceDate);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetEmployeeIdFromEmployeeID(string employeeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT EmployeeID FROM EmployeeProfile WHERE EmployeeID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    object result = command.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                        throw new Exception("Employee not found for the given EmployeeID.");
                    return Convert.ToInt32(result);
                }
            }
        }

        private void ResetForm()
        {
            txtEmployeeID.Text = "";
            txtName.Text = "";
            txtEmployeeID.ForeColor = Color.Black;
            txtName.ForeColor = Color.Black;
            txtEmployeeID.Enabled = true;
            txtName.Enabled = true;

            if (groupBoxAttendance != null)
            {
                groupBoxAttendance.Dispose();
                groupBoxAttendance = null;
                lblCurrentTime = null;
                btnTimeIn = null;
                btnTimeOut = null;
            }

            txtEmployeeID.Focus();
        }
    }
}