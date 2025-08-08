using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgePay.mainpanel_utils
{
    public class frmImportData : Form
    {
        private readonly string connectionString = ConnectToSqlDatabase_MsSQL.connectionString;
        private RadioButton rbCsv;
        private RadioButton rbTab;
        private Button btnBrowse;
        private DataGridView dgvRawData;
        private DataGridView dgvProcessedData;
        private Button btnProcess;
        private Button btnUpload;
        private string filePath;

        public frmImportData()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new Size(800, 600);
            this.Text = "Import Data from CSV or Tab-Separated File";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 240);

            rbCsv = new RadioButton
            {
                Text = "CSV",
                Location = new Point(10, 10),
                Width = 100,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };
            rbTab = new RadioButton
            {
                Text = "Tab-Separated",
                Location = new Point(120, 10),
                Width = 100,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };

            btnBrowse = new Button
            {
                Text = "Browse File",
                Location = new Point(230, 10),
                Size = new Size(120, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(150, 159, 167) }
            };
            btnBrowse.Click += BtnBrowse_Click;
            btnBrowse.MouseEnter += (s, e) => btnBrowse.BackColor = Color.FromArgb(150, 159, 167);
            btnBrowse.MouseLeave += (s, e) => btnBrowse.BackColor = Color.FromArgb(108, 117, 125);

            dgvRawData = new DataGridView
            {
                Location = new Point(10, 50),
                Size = new Size(760, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                ForeColor = Color.Black,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.AliceBlue },
                BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(200, 200, 200)
            };
            dgvRawData.Columns.Add("CardID", "CardID");
            dgvRawData.Columns.Add("Timestamp", "Timestamp");

            btnProcess = new Button
            {
                Text = "Process Data",
                Location = new Point(10, 260),
                Size = new Size(120, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(150, 159, 167) },
                Enabled = false
            };
            btnProcess.Click += BtnProcess_Click;
            btnProcess.MouseEnter += (s, e) => btnProcess.BackColor = Color.FromArgb(150, 159, 167);
            btnProcess.MouseLeave += (s, e) => btnProcess.BackColor = Color.FromArgb(108, 117, 125);

            dgvProcessedData = new DataGridView
            {
                Location = new Point(10, 300),
                Size = new Size(760, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                ForeColor = Color.Black,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.AliceBlue },
                BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(200, 200, 200)
            };
            dgvProcessedData.Columns.Add("EmployeeID", "EmployeeID");
            dgvProcessedData.Columns.Add("Date", "Date");
            dgvProcessedData.Columns.Add("TimeIn", "TimeIn");
            dgvProcessedData.Columns.Add("TimeOut", "TimeOut");

            btnUpload = new Button
            {
                Text = "Upload to Database",
                Location = new Point(140, 260),
                Size = new Size(150, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(150, 159, 167) },
                Enabled = false
            };
            btnUpload.Click += BtnUpload_Click;
            btnUpload.MouseEnter += (s, e) => btnUpload.BackColor = Color.FromArgb(150, 159, 167);
            btnUpload.MouseLeave += (s, e) => btnUpload.BackColor = Color.FromArgb(108, 117, 125);

            this.Controls.AddRange(new Control[] { rbCsv, rbTab, btnBrowse, dgvRawData, btnProcess, dgvProcessedData, btnUpload });
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = rbCsv.Checked ? "CSV Files (*.csv)|*.csv" : "Text Files (*.txt)|*.txt",
                    Title = "Select a File to Import"
                })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        LoadFileData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFileData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CardID", typeof(string));
                dt.Columns.Add("Timestamp", typeof(DateTime));

                char delimiter = rbCsv.Checked ? ',' : '\t';
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length == 0)
                {
                    MessageBox.Show("The selected file is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (string line in lines)
                {
                    string[] fields = line.Split(delimiter);
                    if (fields.Length >= 2)
                    {
                        string cardID = fields[0].Trim();
                        cardID = cardID.TrimStart('0');
                        if (string.IsNullOrEmpty(cardID) || !int.TryParse(cardID, out _))
                        {
                            MessageBox.Show($"Invalid CardID in line: {line}. CardID must be a valid integer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                        if (DateTime.TryParse(fields[1].Trim(), out DateTime timestamp))
                        {
                            dt.Rows.Add(cardID, timestamp);
                        }
                        else
                        {
                            MessageBox.Show($"Invalid timestamp format in line: {line}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Invalid line format: {line}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No valid data found in the file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvRawData.DataSource = dt;
                btnProcess.Enabled = dt.Rows.Count > 0;
                btnUpload.Enabled = false;
                dgvProcessedData.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable rawData = (DataTable)dgvRawData.DataSource;
                if (rawData == null || rawData.Rows.Count == 0)
                {
                    MessageBox.Show("No data to process.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Dictionary<string, int> cardIdToEmployeeId = new Dictionary<string, int>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT EmployeeID FROM EmployeeProfile";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int employeeId = Convert.ToInt32(reader["EmployeeID"]);
                                string cardId = employeeId.ToString();
                                cardIdToEmployeeId[cardId] = employeeId;
                            }
                        }
                    }
                }

                DataTable processedData = new DataTable();
                processedData.Columns.Add("EmployeeID", typeof(int));
                processedData.Columns.Add("Date", typeof(DateTime));
                processedData.Columns.Add("TimeIn", typeof(TimeSpan));
                processedData.Columns.Add("TimeOut", typeof(TimeSpan));

                var groupedData = rawData.AsEnumerable()
                    .GroupBy(row => new
                    {
                        CardID = row.Field<string>("CardID"),
                        Date = row.Field<DateTime>("Timestamp").Date
                    })
                    .Select(g => new
                    {
                        CardID = g.Key.CardID,
                        Date = g.Key.Date,
                        TimeIn = g.Min(row => row.Field<DateTime>("Timestamp").TimeOfDay),
                        TimeOut = g.Max(row => row.Field<DateTime>("Timestamp").TimeOfDay)
                    });

                List<string> unmatchedCardIDs = new List<string>();
                foreach (var group in groupedData)
                {
                    if (cardIdToEmployeeId.TryGetValue(group.CardID, out int employeeId))
                    {
                        TimeSpan? timeOut = group.TimeOut;
                        // Check if TimeIn and TimeOut are the same or within 10 seconds
                        if (group.TimeIn == group.TimeOut ||
                            Math.Abs((group.TimeOut - group.TimeIn).TotalSeconds) <= 10)
                        {
                            timeOut = null; // Set TimeOut to null if within 10 seconds
                        }
                        processedData.Rows.Add(employeeId, group.Date, group.TimeIn, timeOut);
                    }
                    else
                    {
                        unmatchedCardIDs.Add(group.CardID);
                    }
                }

                if (unmatchedCardIDs.Count > 0)
                {
                    MessageBox.Show($"The following CardIDs were not found in EmployeeProfile: {string.Join(", ", unmatchedCardIDs)}. Ensure CardIDs match EmployeeID values in EmployeeProfile.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (processedData.Rows.Count == 0)
                {
                    MessageBox.Show("No valid records processed. Ensure CardIDs match EmployeeID values in EmployeeProfile.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvProcessedData.DataSource = processedData;
                btnUpload.Enabled = processedData.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable processedData = (DataTable)dgvProcessedData.DataSource;
                if (processedData == null || processedData.Rows.Count == 0)
                {
                    MessageBox.Show("No processed data to upload.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show($"Upload {processedData.Rows.Count} attendance records to the database?", "Confirm Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string createTempTableQuery = @"
                    CREATE TABLE #TempAttendance (
                        EmployeeID INT NOT NULL,
                        [Date] DATE NOT NULL,
                        TimeIn TIME(7) NULL,
                        TimeOut TIME(7) NULL,
                        PRIMARY KEY (EmployeeID, [Date])
                    )";
                    using (SqlCommand command = new SqlCommand(createTempTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                    {
                        bulkCopy.DestinationTableName = "#TempAttendance";
                        bulkCopy.ColumnMappings.Add("EmployeeID", "EmployeeID");
                        bulkCopy.ColumnMappings.Add("Date", "Date");
                        bulkCopy.ColumnMappings.Add("TimeIn", "TimeIn");
                        bulkCopy.ColumnMappings.Add("TimeOut", "TimeOut");
                        bulkCopy.WriteToServer(processedData);
                    }

                    string mergeQuery = @"
                    MERGE INTO AttendanceRegister AS target
                    USING #TempAttendance AS source
                    ON target.EmployeeID = source.EmployeeID AND target.[Date] = source.[Date]
                    WHEN MATCHED THEN
                        UPDATE SET 
                            target.TimeIn = source.TimeIn,
                            target.TimeOut = source.TimeOut,
                            target.Leave_Type = NULL
                    WHEN NOT MATCHED THEN
                        INSERT (EmployeeID, [Date], TimeIn, TimeOut, Leave_Type)
                        VALUES (source.EmployeeID, source.[Date], source.TimeIn, source.TimeOut, NULL)
                    OUTPUT INSERTED.EmployeeID, INSERTED.[Date];";

                    int recordsUploaded = 0;
                    using (SqlCommand command = new SqlCommand(mergeQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recordsUploaded++;
                            }
                        }
                    }

                    using (SqlCommand command = new SqlCommand("DROP TABLE #TempAttendance", connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Successfully uploaded {recordsUploaded} attendance records to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnUpload.Enabled = false;
                    dgvProcessedData.DataSource = null;
                    dgvRawData.DataSource = null;
                    btnProcess.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uploading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}