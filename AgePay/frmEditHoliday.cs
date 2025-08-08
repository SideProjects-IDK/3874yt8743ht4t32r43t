using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AgePay
{
    public partial class frmEditHoliday : Form
    {
        private readonly string connectionString = ConnectToSqlDatabase_MsSQL.connectionString;

        public frmEditHoliday()
        {
            InitializeComponent();
            InitializeDataGridView();
            txt_search_with_date.Click += txt_search_with_date_Click; // Added click event for calendar
            txt_search_with_date.Enter += txt_search_with_date_Click; // Added enter event for calendar
        }

        private void InitializeDataGridView()
        {
            // Assume DataGridView is set up in the designer
        }

        private void frmEditHoliday_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Check if Holidays table exists
                    string checkTableQuery = "SELECT 1 FROM sys.tables WHERE name = 'Holidays'";
                    using (SqlCommand checkCommand = new SqlCommand(checkTableQuery, connection))
                    {
                        connection.Open();
                        object result = checkCommand.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("The table 'Holidays' does not exist in the database. Please create the table.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                LoadHolidays();
                UpdateYearStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddSundays_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int currentYear = DateTime.Today.Year;
                    DateTime startDate = new DateTime(currentYear, 1, 1);
                    // Find first Sunday
                    while (startDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        startDate = startDate.AddDays(1);
                    }

                    int inserted = 0;
                    int updated = 0;
                    // Iterate through all Sundays in the year
                    while (startDate.Year == currentYear)
                    {
                        string holidayDetail = $"Sunday - {startDate:MMMM d, yyyy}";

                        // Check if holiday exists
                        string checkQuery = "SELECT COUNT(*) FROM Holidays WHERE [Date] = @Date";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Date", startDate);
                            int count = (int)checkCommand.ExecuteScalar();

                            if (count > 0)
                            {
                                // Update existing holiday
                                string updateQuery = "UPDATE Holidays SET HolidayDetail = @HolidayDetail WHERE [Date] = @Date";
                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@Date", startDate);
                                    updateCommand.Parameters.AddWithValue("@HolidayDetail", holidayDetail);
                                    updateCommand.ExecuteNonQuery();
                                }
                                updated++;
                            }
                            else
                            {
                                // Insert new holiday
                                string insertQuery = "INSERT INTO Holidays ([Date], HolidayDetail) VALUES (@Date, @HolidayDetail)";
                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@Date", startDate);
                                    insertCommand.Parameters.AddWithValue("@HolidayDetail", holidayDetail);
                                    insertCommand.ExecuteNonQuery();
                                }
                                inserted++;
                            }
                        }

                        startDate = startDate.AddDays(7); // Move to next Sunday
                    }

                    MessageBox.Show($"Successfully processed Sundays for {currentYear}: {inserted} added, {updated} updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHolidays();
                    UpdateYearStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Sundays: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DialogResult result = MessageBox.Show("Are you sure you want to delete all holidays? This action cannot be undone.", "Confirm Delete All", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result != DialogResult.Yes)
                        return;

                    string query = "DELETE FROM Holidays";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("All holidays deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHolidays();
                    UpdateYearStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting all holidays: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int currentYear = DateTime.Today.Year;
                    DateTime startDate = new DateTime(currentYear, 1, 1);
                    // Find first Sunday
                    while (startDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        startDate = startDate.AddDays(1);
                    }

                    int inserted = 0;
                    int updated = 0;
                    // Iterate through all Sundays in the year
                    while (startDate.Year == currentYear)
                    {
                        string holidayDetail = $"Sunday - {startDate:MMMM d, yyyy}";

                        // Check if holiday exists
                        string checkQuery = "SELECT COUNT(*) FROM Holidays WHERE [Date] = @Date";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Date", startDate);
                            int count = (int)checkCommand.ExecuteScalar();

                            if (count > 0)
                            {
                                // Update existing holiday
                                string updateQuery = "UPDATE Holidays SET HolidayDetail = @HolidayDetail WHERE [Date] = @Date";
                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@Date", startDate);
                                    updateCommand.Parameters.AddWithValue("@HolidayDetail", holidayDetail);
                                    updateCommand.ExecuteNonQuery();
                                }
                                updated++;
                            }
                            else
                            {
                                // Insert new holiday
                                string insertQuery = "INSERT INTO Holidays ([Date], HolidayDetail) VALUES (@Date, @HolidayDetail)";
                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@Date", startDate);
                                    insertCommand.Parameters.AddWithValue("@HolidayDetail", holidayDetail);
                                    insertCommand.ExecuteNonQuery();
                                }
                                inserted++;
                            }
                        }

                        startDate = startDate.AddDays(7); // Move to next Sunday
                    }

                    MessageBox.Show($"Successfully processed Sundays for {currentYear}: {inserted} added, {updated} updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHolidays();
                    UpdateYearStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Sundays: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DialogResult result = MessageBox.Show("Are you sure you want to delete all holidays? This action cannot be undone.", "Confirm Delete All", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result != DialogResult.Yes)
                        return;

                    string query = "DELETE FROM Holidays";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("All holidays deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHolidays();
                    UpdateYearStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting all holidays: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHolidays(string searchDate = null, string searchName = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT [Date], HolidayDetail FROM Holidays";
                    if (!string.IsNullOrWhiteSpace(searchDate) || !string.IsNullOrWhiteSpace(searchName))
                    {
                        query += " WHERE 1=1";
                        if (!string.IsNullOrWhiteSpace(searchDate))
                            query += " AND [Date] = @Date";
                        if (!string.IsNullOrWhiteSpace(searchName))
                            query += " AND HolidayDetail LIKE @HolidayDetail";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(searchDate))
                            command.Parameters.AddWithValue("@Date", searchDate);
                        if (!string.IsNullOrWhiteSpace(searchName))
                            command.Parameters.AddWithValue("@HolidayDetail", $"%{searchName}%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count == 0 && string.IsNullOrWhiteSpace(searchDate) && string.IsNullOrWhiteSpace(searchName))
                            {
                                MessageBox.Show("No holidays found in the database. Please add holidays to display them.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            dataGridView1.DataSource = dataTable;

                            // Update search textbox colors based on results
                            if (!string.IsNullOrWhiteSpace(searchDate))
                            {
                                txt_search_with_date.ForeColor = dataTable.Rows.Count > 0 ? Color.Black : Color.Red;
                            }
                            if (!string.IsNullOrWhiteSpace(searchName))
                            {
                                txt_search_with_name.ForeColor = dataTable.Rows.Count > 0 ? Color.Black : Color.Red;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading holidays: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateYearStatistics()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int currentYear = DateTime.Today.Year;
                    bool isLeapYear = DateTime.IsLeapYear(currentYear);
                    lbl_days_in_this_year.Text = $"Days in {currentYear}: {(isLeapYear ? 366 : 365)}";

                    string query = "SELECT COUNT(*) FROM Holidays WHERE YEAR([Date]) = @Year";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Year", currentYear);
                        int holidayCount = (int)command.ExecuteScalar();
                        lbl_count_of_toall_holidays_this_year.Text = $"Total Holidays in {currentYear}: {holidayCount}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_search_with_date_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txt_search_with_date.Text.Trim();
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    txt_search_with_date.BackColor = Color.White;
                    txt_search_with_date.ForeColor = Color.Black;
                    LoadHolidays(searchName: txt_search_with_name.Text.Trim());
                    return;
                }

                if (DateTime.TryParse(searchText, out DateTime searchDate))
                {
                    txt_search_with_date.BackColor = Color.White;
                    LoadHolidays(searchDate.ToString("yyyy-MM-dd"), txt_search_with_name.Text.Trim());
                }
                else
                {
                    txt_search_with_date.BackColor = Color.Red;
                    txt_search_with_date.ForeColor = Color.Black;
                    LoadHolidays(searchName: txt_search_with_name.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching by date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_search_with_name_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txt_search_with_name.Text.Trim();
                txt_search_with_name.ForeColor = Color.Black;
                LoadHolidays(txt_search_with_date.Text.Trim(), searchText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching by name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_search_with_date_Click(object sender, EventArgs e)
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
                if (DateTime.TryParse(txt_search_with_date.Text, out DateTime selectedDate))
                {
                    calendar.SetDate(selectedDate);
                }
                calendar.DateSelected += (s, args) =>
                {
                    txt_search_with_date.Text = args.Start.ToString("yyyy-MM-dd");
                    txt_search_with_date.BackColor = Color.White;
                    txt_search_with_date.ForeColor = Color.Black;
                    LoadHolidays(txt_search_with_date.Text, txt_search_with_name.Text.Trim());
                    calendarForm.Close();
                };
                calendarForm.Controls.Add(calendar);
                calendarForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowHolidayEditForm(true); // True for adding a new holiday
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowHolidayActionForm(e.RowIndex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowHolidayActionForm(e.RowIndex);
            }
        }

        private void ShowHolidayActionForm(int rowIndex)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                DateTime holidayDate = Convert.ToDateTime(row.Cells["Date"].Value);
                string holidayDetail = row.Cells["HolidayDetail"].Value?.ToString() ?? "";

                using (Form actionForm = new Form
                {
                    Size = new Size(400, 200),
                    Text = $"Holiday: {holidayDetail} ({holidayDate:yyyy-MM-dd})",
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    BackColor = Color.FromArgb(240, 240, 240)
                })
                {
                    Button btnUpdate = new Button
                    {
                        Text = "Update this holiday",
                        Location = new Point(20, 20),
                        Size = new Size(150, 30),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        BackColor = Color.FromArgb(108, 117, 125),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(150, 159, 167) }
                    };
                    btnUpdate.MouseEnter += (s, e) => btnUpdate.BackColor = Color.FromArgb(150, 159, 167);
                    btnUpdate.MouseLeave += (s, e) => btnUpdate.BackColor = Color.FromArgb(108, 117, 125);
                    btnUpdate.Click += (s, e) => { ShowHolidayEditForm(false, holidayDate, holidayDetail); actionForm.Close(); };

                    Button btnDelete = new Button
                    {
                        Text = "Delete this holiday",
                        Location = new Point(20, 60),
                        Size = new Size(150, 30),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        BackColor = Color.FromArgb(108, 117, 125),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(150, 159, 167) }
                    };
                    btnDelete.MouseEnter += (s, e) => btnDelete.BackColor = Color.FromArgb(150, 159, 167);
                    btnDelete.MouseLeave += (s, e) => btnDelete.BackColor = Color.FromArgb(108, 117, 125);
                    btnDelete.Click += (s, e) => DeleteHoliday(holidayDate, holidayDetail, actionForm);

                    Button btnExit = new Button
                    {
                        Text = "Exit",
                        Location = new Point(20, 100),
                        Size = new Size(150, 30),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        BackColor = Color.FromArgb(108, 117, 125),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(150, 159, 167) }
                    };
                    btnExit.MouseEnter += (s, e) => btnExit.BackColor = Color.FromArgb(150, 159, 167);
                    btnExit.MouseLeave += (s, e) => btnExit.BackColor = Color.FromArgb(108, 117, 125);
                    btnExit.Click += (s, e) => actionForm.Close();

                    actionForm.Controls.Add(btnUpdate);
                    actionForm.Controls.Add(btnDelete);
                    actionForm.Controls.Add(btnExit);
                    actionForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening action form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteHoliday(DateTime holidayDate, string holidayDetail, Form actionForm)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DialogResult result = MessageBox.Show($"Are you sure you want to remove the holiday '{holidayDetail}' on {holidayDate:yyyy-MM-dd}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes)
                        return;

                    string query = "DELETE FROM Holidays WHERE [Date] = @Date";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Date", holidayDate);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Holiday '{holidayDetail}' on {holidayDate:yyyy-MM-dd} removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHolidays();
                    UpdateYearStatistics();
                    actionForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing holiday: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowHolidayEditForm(bool isAddMode, DateTime? initialDate = null, string initialDetail = null)
        {
            try
            {
                using (Form editForm = new Form
                {
                    Size = new Size(400, 200),
                    Text = isAddMode ? "Add New Holiday" : "Update Holiday",
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    BackColor = Color.FromArgb(240, 240, 240)
                })
                {
                    Label lblDate = new Label
                    {
                        Text = "Date:",
                        Location = new Point(20, 20),
                        Size = new Size(100, 20),
                        Font = new Font("Segoe UI", 10)
                    };

                    DateTimePicker dtpDate = new DateTimePicker
                    {
                        Location = new Point(120, 20),
                        Width = 250,
                        Format = DateTimePickerFormat.Short,
                        Font = new Font("Segoe UI", 10),
                        Enabled = isAddMode // Disable date picker in update mode
                    };
                    if (initialDate.HasValue)
                    {
                        dtpDate.Value = initialDate.Value;
                    }

                    Label lblDetail = new Label
                    {
                        Text = "Holiday Detail:",
                        Location = new Point(20, 50),
                        Size = new Size(100, 20),
                        Font = new Font("Segoe UI", 10)
                    };

                    TextBox txtDetail = new TextBox
                    {
                        Location = new Point(120, 50),
                        Width = 250,
                        MaxLength = 50,
                        Font = new Font("Segoe UI", 10),
                        Text = initialDetail ?? ""
                    };

                    Button btnSave = new Button
                    {
                        Text = "Save",
                        Location = new Point(120, 90),
                        Size = new Size(100, 30),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        BackColor = Color.FromArgb(108, 117, 125),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(150, 159, 167) }
                    };
                    btnSave.MouseEnter += (s, e) => btnSave.BackColor = Color.FromArgb(150, 159, 167);
                    btnSave.MouseLeave += (s, e) => btnSave.BackColor = Color.FromArgb(108, 117, 125);

                    btnSave.Click += (s, args) =>
                    {
                        try
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                DateTime holidayDate = dtpDate.Value.Date;
                                string holidayDetail = txtDetail.Text.Trim();
                                if (string.IsNullOrWhiteSpace(holidayDetail))
                                {
                                    MessageBox.Show("Please enter a holiday detail.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                int count;
                                string checkQuery = "SELECT COUNT(*) FROM Holidays WHERE [Date] = @Date";
                                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                                {
                                    checkCommand.Parameters.AddWithValue("@Date", holidayDate);
                                    count = (int)checkCommand.ExecuteScalar();
                                }

                                if (isAddMode && count > 0)
                                {
                                    MessageBox.Show($"A holiday already exists on {holidayDate:yyyy-MM-dd}. Please choose a different date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                if (!isAddMode && count == 0)
                                {
                                    MessageBox.Show($"No holiday found on {holidayDate:yyyy-MM-dd}. Please add a new holiday instead.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                string action = isAddMode ? "insert" : "update";
                                string confirmMessage = isAddMode
                                    ? $"Add new holiday on {holidayDate:yyyy-MM-dd} as '{holidayDetail}'?"
                                    : $"Update holiday on {holidayDate:yyyy-MM-dd} to '{holidayDetail}'?";

                                DialogResult result = MessageBox.Show(confirmMessage, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result != DialogResult.Yes)
                                    return;

                                string query = isAddMode
                                    ? "INSERT INTO Holidays ([Date], HolidayDetail) VALUES (@Date, @HolidayDetail)"
                                    : "UPDATE Holidays SET HolidayDetail = @HolidayDetail WHERE [Date] = @Date";

                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@Date", holidayDate);
                                    command.Parameters.AddWithValue("@HolidayDetail", holidayDetail);
                                    command.ExecuteNonQuery();
                                }

                                MessageBox.Show($"Holiday '{holidayDetail}' on {holidayDate:yyyy-MM-dd} {(isAddMode ? "added" : "updated")} successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadHolidays();
                                UpdateYearStatistics();
                                editForm.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error saving holiday: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    Button btnCancel = new Button
                    {
                        Text = "Cancel",
                        Location = new Point(230, 90),
                        Size = new Size(100, 30),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        BackColor = Color.FromArgb(108, 117, 125),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(150, 159, 167) }
                    };
                    btnCancel.MouseEnter += (s, e) => btnCancel.BackColor = Color.FromArgb(150, 159, 167);
                    btnCancel.MouseLeave += (s, e) => btnCancel.BackColor = Color.FromArgb(108, 117, 125);
                    btnCancel.Click += (s, e) => editForm.Close();

                    editForm.Controls.Add(lblDate);
                    editForm.Controls.Add(dtpDate);
                    editForm.Controls.Add(lblDetail);
                    editForm.Controls.Add(txtDetail);
                    editForm.Controls.Add(btnSave);
                    editForm.Controls.Add(btnCancel);
                    editForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening holiday form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}