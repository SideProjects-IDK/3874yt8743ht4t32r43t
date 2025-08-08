using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AgePay.mainpanel_utils;

namespace AgePay
{
    public partial class DepartmentSetup : Form
    {
        private readonly SqlConnection connection = ConnectToSqlDatabase_MsSQL.GetConnection();

        public DepartmentSetup()
        {
            InitializeComponent();
        }

        private void DepartmentSetup_Load(object sender, EventArgs e)
        {
            // Disable direct editing in DataGridView
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            // Load all departments into DataGridView
            LoadDepartments();
        }

        private void LoadDepartments(string filterQuery = "SELECT DeptID, DeptName FROM Departments ORDER BY DeptName")
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(filterQuery, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open a popup form to create a new department
            using (NewDepartmentForm newDeptForm = new NewDepartmentForm(connection))
            {
                if (newDeptForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string deptName = newDeptForm.DepartmentName;
                        if (string.IsNullOrWhiteSpace(deptName))
                        {
                            MessageBox.Show("Department name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (deptName.Length > 50)
                        {
                            MessageBox.Show("Department name cannot exceed 50 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Calculate the next DeptID
                        int nextDeptID;
                        string query = "SELECT ISNULL(MAX(DeptID), 0) + 1 FROM Departments";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            if (connection.State != ConnectionState.Open)
                                connection.Open();
                            nextDeptID = Convert.ToInt32(command.ExecuteScalar());
                        }

                        // Insert with the calculated DeptID
                        query = "INSERT INTO Departments (DeptID, DeptName) VALUES (@DeptID, @DeptName)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@DeptID", nextDeptID);
                            command.Parameters.AddWithValue("@DeptName", deptName);
                            if (connection.State != ConnectionState.Open)
                                connection.Open();
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Department added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDepartments(); // Refresh DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // First confirmation
            DialogResult result1 = MessageBox.Show("Are you sure you want to delete all departments? This action cannot be undone.",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result1 != DialogResult.Yes)
                return;

            // Second confirmation
            DialogResult result2 = MessageBox.Show("Please confirm again: Do you really want to delete all departments?",
                "Final Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result2 != DialogResult.Yes)
                return;

            try
            {
                // Save current data to a text file on the desktop with a random UUID name
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"{Guid.NewGuid()}.txt";
                string filePath = Path.Combine(desktopPath, fileName);

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    string query = "SELECT DeptID, DeptName FROM Departments";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                writer.WriteLine($"DeptID: {reader.GetInt32(0)}, DeptName: {reader.GetString(1)}");
                            }
                        }
                    }
                }

                // Delete all departments
                string deleteQuery = "DELETE FROM Departments";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    command.ExecuteNonQuery();
                }

                MessageBox.Show($"All departments deleted. Data saved to {fileName} on Desktop.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDepartments(); // Refresh DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["DeptID"].Value != null && row.Cells["DeptName"].Value != null)
                {
                    int deptID = Convert.ToInt32(row.Cells["DeptID"].Value);
                    string deptName = row.Cells["DeptName"].Value.ToString();

                    using (DepartmentActionForm actionForm = new DepartmentActionForm(deptID, deptName))
                    {
                        if (actionForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadDepartments(); // Refresh DataGridView after edit or delete
                        }
                    }
                }
            }
        }

        private void txt_search_with_ID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txt_search_with_ID.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadDepartments(); // Load all departments if search is empty
                }
                else if (int.TryParse(searchText, out int deptID))
                {
                    string query = "SELECT DeptID, DeptName FROM Departments WHERE DeptID = @DeptID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DeptID", deptID);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
                else
                {
                    // If input is not a valid integer, show no results
                    dataGridView1.DataSource = new DataTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering by ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_search_with_name_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txt_search_with_name.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadDepartments(); // Load all departments if search is empty
                }
                else
                {
                    string query = "SELECT DeptID, DeptName FROM Departments WHERE DeptName LIKE @SearchText ORDER BY DeptName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering by name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Placeholder for panel paint
        }
    }

    // Form for creating a new department
    public class NewDepartmentForm : Form
    {
        private TextBox txtDeptID;
        private TextBox txtDeptName;
        private Button btnSave;
        private Button btnCancel;
        private readonly SqlConnection connection;

        public string DepartmentName { get; private set; }

        public NewDepartmentForm(SqlConnection connection)
        {
            this.connection = connection;
            InitializeComponents();
            LoadNextDeptID();
        }

        private void InitializeComponents()
        {
            this.Text = "Add New Department";
            this.Size = new Size(300, 200);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblDeptID = new Label
            {
                Text = "Department ID:",
                Location = new Point(20, 20),
                Size = new Size(100, 20)
            };

            txtDeptID = new TextBox
            {
                Location = new Point(120, 20),
                Size = new Size(150, 20),
                Enabled = false
            };

            Label lblDeptName = new Label
            {
                Text = "Department Name:",
                Location = new Point(20, 50),
                Size = new Size(100, 20)
            };

            txtDeptName = new TextBox
            {
                Location = new Point(120, 50),
                Size = new Size(150, 20)
            };

            btnSave = new Button
            {
                Text = "Save",
                Location = new Point(120, 90),
                Size = new Size(75, 30)
            };
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(200, 90),
                Size = new Size(75, 30)
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] { lblDeptID, txtDeptID, lblDeptName, txtDeptName, btnSave, btnCancel });
        }

        private void LoadNextDeptID()
        {
            try
            {
                string query = "SELECT ISNULL(MAX(DeptID), 0) + 1 FROM Departments";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    int nextDeptID = Convert.ToInt32(command.ExecuteScalar());
                    txtDeptID.Text = nextDeptID.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading next Department ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDeptID.Text = "N/A";
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeptName.Text))
            {
                MessageBox.Show("Please enter a department name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtDeptName.Text.Length > 50)
            {
                MessageBox.Show("Department name cannot exceed 50 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DepartmentName = txtDeptName.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }

    // Form for handling Edit/Delete/Members actions
    public class DepartmentActionForm : Form
    {
        private int DeptID;
        private string DeptName;
        private TextBox txtDeptName;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnMembers;
        private Button btnExit;
        private readonly SqlConnection connection = ConnectToSqlDatabase_MsSQL.GetConnection();

        public DepartmentActionForm(int deptID, string deptName)
        {
            DeptID = deptID;
            DeptName = deptName;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Department Actions";
            this.Size = new Size(300, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblDeptName = new Label
            {
                Text = "Department Name:",
                Location = new Point(20, 20),
                Size = new Size(100, 20)
            };

            txtDeptName = new TextBox
            {
                Text = DeptName,
                Location = new Point(120, 20),
                Size = new Size(150, 20)
            };

            btnEdit = new Button
            {
                Text = "Edit",
                Location = new Point(20, 60),
                Size = new Size(75, 30)
            };
            btnEdit.Click += BtnEdit_Click;

            btnDelete = new Button
            {
                Text = "Delete",
                Location = new Point(100, 60),
                Size = new Size(75, 30)
            };
            btnDelete.Click += BtnDelete_Click;

            btnMembers = new Button
            {
                Text = "Members",
                Location = new Point(180, 60),
                Size = new Size(75, 30)
            };
            btnMembers.Click += BtnMembers_Click;

            btnExit = new Button
            {
                Text = "Exit",
                Location = new Point(100, 100),
                Size = new Size(75, 30)
            };
            btnExit.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] { lblDeptName, txtDeptName, btnEdit, btnDelete, btnMembers, btnExit });
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to edit department '{DeptName}'?",
                "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                string newDeptName = txtDeptName.Text.Trim();
                if (string.IsNullOrEmpty(newDeptName))
                {
                    MessageBox.Show("Department name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newDeptName.Length > 50)
                {
                    MessageBox.Show("Department name cannot exceed 50 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "UPDATE Departments SET DeptName = @DeptName WHERE DeptID = @DeptID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DeptName", newDeptName);
                    command.Parameters.AddWithValue("@DeptID", DeptID);

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Department updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to delete department '{DeptName}'?",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;

            try
            {
                string query = "DELETE FROM Departments WHERE DeptID = @DeptID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DeptID", DeptID);

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Department deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void BtnMembers_Click(object sender, EventArgs e)
        {
            using (DepartmentMembersForm membersForm = new DepartmentMembersForm(DeptID, DeptName))
            {
                membersForm.ShowDialog();
            }
        }
    }

    // Form for displaying department members
    public class DepartmentMembersForm : Form
    {
        private int DeptID;
        private string DeptName;
        private DataGridView dataGridView;
        private Button btnExit;
        private readonly SqlConnection connection = ConnectToSqlDatabase_MsSQL.GetConnection();

        public DepartmentMembersForm(int deptID, string deptName)
        {
            DeptID = deptID;
            DeptName = deptName;
            InitializeComponents();
            LoadMembers();
        }

        private void InitializeComponents()
        {
            this.Text = $"Members of {DeptName} (DeptID: {DeptID})";
            this.Size = new Size(600, 400);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            dataGridView = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(560, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };
            dataGridView.CellClick += DataGridView_CellClick;

            btnExit = new Button
            {
                Text = "Exit",
                Location = new Point(250, 320),
                Size = new Size(75, 30)
            };
            btnExit.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { dataGridView, btnExit });
        }

        private void LoadMembers()
        {
            try
            {
                string query = "SELECT EmployeeID, EmployeeName, Designation, CNIC FROM EmployeeProfile WHERE DeptID = @DeptID ORDER BY EmployeeName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DeptID", DeptID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading department members: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                if (row.Cells["EmployeeID"].Value != null && row.Cells["EmployeeName"].Value != null)
                {
                    int employeeID = Convert.ToInt32(row.Cells["EmployeeID"].Value);
                    string employeeName = row.Cells["EmployeeName"].Value.ToString();

                    using (EditEmployeeDepartmentForm editForm = new EditEmployeeDepartmentForm(employeeID, employeeName, DeptID, connection))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadMembers(); // Refresh DataGridView after department change
                        }
                    }
                }
            }
        }
    }

    // Form for editing an employee's department
    public class EditEmployeeDepartmentForm : Form
    {
        private int EmployeeID;
        private string EmployeeName;
        private int CurrentDeptID;
        private TextBox txtEmployeeName;
        private ComboBox comboDeptID;
        private Button btnSave;
        private Button btnCancel;
        private readonly SqlConnection connection;

        public EditEmployeeDepartmentForm(int employeeID, string employeeName, int currentDeptID, SqlConnection connection)
        {
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            CurrentDeptID = currentDeptID;
            this.connection = connection;
            InitializeComponents();
            LoadDepartments();
        }

        private void InitializeComponents()
        {
            this.Text = "Edit Employee Department";
            this.Size = new Size(300, 200);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblEmployeeName = new Label
            {
                Text = "Employee Name:",
                Location = new Point(20, 20),
                Size = new Size(100, 20)
            };

            txtEmployeeName = new TextBox
            {
                Text = EmployeeName,
                Location = new Point(120, 20),
                Size = new Size(150, 20),
                Enabled = false
            };

            Label lblDeptID = new Label
            {
                Text = "Department ID:",
                Location = new Point(20, 50),
                Size = new Size(100, 20)
            };

            comboDeptID = new ComboBox
            {
                Location = new Point(120, 50),
                Size = new Size(150, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            btnSave = new Button
            {
                Text = "Save",
                Location = new Point(120, 90),
                Size = new Size(75, 30)
            };
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(200, 90),
                Size = new Size(75, 30)
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] { lblEmployeeName, txtEmployeeName, lblDeptID, comboDeptID, btnSave, btnCancel });
        }

        private void LoadDepartments()
        {
            try
            {
                string query = "SELECT DeptID, DeptName FROM Departments ORDER BY DeptName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        comboDeptID.Items.Clear();
                        while (reader.Read())
                        {
                            int deptID = reader.GetInt32(0);
                            string deptName = reader.GetString(1);
                            comboDeptID.Items.Add(new { DeptID = deptID, Display = $"{deptID} - {deptName}" });
                            if (deptID == CurrentDeptID)
                            {
                                comboDeptID.SelectedIndex = comboDeptID.Items.Count - 1;
                            }
                        }
                        comboDeptID.DisplayMember = "Display";
                        comboDeptID.ValueMember = "DeptID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (comboDeptID.SelectedItem == null)
            {
                MessageBox.Show("Please select a department.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newDeptID = (int)((dynamic)comboDeptID.SelectedItem).DeptID;

            if (newDeptID == CurrentDeptID)
            {
                MessageBox.Show("No change in department.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to change the department for {EmployeeName} to DeptID {newDeptID}?",
                "Confirm Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                string query = "UPDATE EmployeeProfile SET DeptID = @NewDeptID WHERE EmployeeID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewDeptID", newDeptID);
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee department updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}