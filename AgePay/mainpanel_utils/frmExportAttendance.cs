using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgePay.mainpanel_utils
{
    public class frmExportAttendance : Form
    {
        private readonly string connectionString = ConnectToSqlDatabase_MsSQL.connectionString;
        private Label lblStartDate;
        private DateTimePicker dtpStartDate;
        private Label lblEndDate;
        private DateTimePicker dtpEndDate;
        private Label lblEmployeeId;
        private TextBox txtEmployeeId;
        private Button btnBrowse;
        private Button btnExport;
        private Button btnExportCurrentDay;
        private Button btnExportCurrentMonth;
        private Button btnExportByEmployeeId;
        private string filePath;
        private DataTable attendanceData;

        public frmExportAttendance()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new Size(400, 400);
            this.Text = "Export Attendance Register";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            lblStartDate = new Label
            {
                Text = "Start Date:",
                Location = new Point(20, 20),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black
            };

            dtpStartDate = new DateTimePicker
            {
                Location = new Point(120, 20),
                Size = new Size(250, 25),
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10),
                Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1),
                BackColor = Color.White,
                ForeColor = Color.Black
            };

            lblEndDate = new Label
            {
                Text = "End Date:",
                Location = new Point(20, 50),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black
            };

            dtpEndDate = new DateTimePicker
            {
                Location = new Point(120, 50),
                Size = new Size(250, 25),
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10),
                Value = DateTime.Today,
                BackColor = Color.White,
                ForeColor = Color.Black
            };

            lblEmployeeId = new Label
            {
                Text = "Employee ID:",
                Location = new Point(20, 80),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black
            };

            txtEmployeeId = new TextBox
            {
                Location = new Point(120, 80),
                Size = new Size(250, 25),
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White,
                ForeColor = Color.Black
            };

            btnBrowse = new Button
            {
                Text = "Browse File",
                Location = new Point(20, 120),
                Size = new Size(120, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(30, 144, 255) }
            };
            btnBrowse.Click += BtnBrowse_Click;
            btnBrowse.MouseEnter += (s, e) => btnBrowse.BackColor = Color.FromArgb(30, 144, 255);
            btnBrowse.MouseLeave += (s, e) => btnBrowse.BackColor = Color.FromArgb(0, 120, 215);

            btnExport = new Button
            {
                Text = "Export Range",
                Location = new Point(150, 120),
                Size = new Size(120, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(30, 144, 255) },
                Enabled = false
            };
            btnExport.Click += BtnExport_Click;
            btnExport.MouseEnter += (s, e) => btnExport.BackColor = Color.FromArgb(30, 144, 255);
            btnExport.MouseLeave += (s, e) => btnExport.BackColor = Color.FromArgb(0, 120, 215);

            btnExportCurrentDay = new Button
            {
                Text = "Export Today",
                Location = new Point(20, 190),
                Size = new Size(150, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(30, 144, 255) }
            };
            btnExportCurrentDay.Click += BtnExportCurrentDay_Click;
            btnExportCurrentDay.MouseEnter += (s, e) => btnExportCurrentDay.BackColor = Color.FromArgb(30, 144, 255);
            btnExportCurrentDay.MouseLeave += (s, e) => btnExportCurrentDay.BackColor = Color.FromArgb(0, 120, 215);

            btnExportCurrentMonth = new Button
            {
                Text = "Export Month",
                Location = new Point(20, 230),
                Size = new Size(150, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(30, 144, 255) }
            };
            btnExportCurrentMonth.Click += BtnExportCurrentMonth_Click;
            btnExportCurrentMonth.MouseEnter += (s, e) => btnExportCurrentMonth.BackColor = Color.FromArgb(30, 144, 255);
            btnExportCurrentMonth.MouseLeave += (s, e) => btnExportCurrentMonth.BackColor = Color.FromArgb(0, 120, 215);

            btnExportByEmployeeId = new Button
            {
                Text = "Export by ID",
                Location = new Point(20, 270),
                Size = new Size(150, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(30, 144, 255) }
            };
            btnExportByEmployeeId.Click += BtnExportByEmployeeId_Click;
            btnExportByEmployeeId.MouseEnter += (s, e) => btnExportByEmployeeId.BackColor = Color.FromArgb(30, 144, 255);
            btnExportByEmployeeId.MouseLeave += (s, e) => btnExportByEmployeeId.BackColor = Color.FromArgb(0, 120, 215);

            this.Controls.AddRange(new Control[] { lblStartDate, dtpStartDate, lblEndDate, dtpEndDate, lblEmployeeId, txtEmployeeId, btnBrowse, btnExport, btnExportCurrentDay, btnExportCurrentMonth, btnExportByEmployeeId });
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt",
                    Title = "Save Attendance Report",
                    FileName = $"AttendanceReport_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
                })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog.FileName;
                        btnExport.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportAttendance(DateTime startDate, DateTime endDate, string filePath, int? employeeId = null)
        {
            try
            {
                // Fetch employee data
                DataTable employeeData = new DataTable();
                DataTable holidayData = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Fetch employee data
                    string employeeQuery = employeeId.HasValue
                        ? "SELECT EmployeeID, EmployeeName, DutyIn FROM EmployeeProfile WHERE EmployeeID = @EmployeeID"
                        : "SELECT EmployeeID, EmployeeName, DutyIn FROM EmployeeProfile";
                    using (SqlCommand command = new SqlCommand(employeeQuery, connection))
                    {
                        if (employeeId.HasValue)
                        {
                            command.Parameters.AddWithValue("@EmployeeID", employeeId.Value);
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(employeeData);
                        }
                    }

                    // Fetch holiday data
                    string holidayQuery = "SELECT Date FROM Holidays WHERE Date BETWEEN @StartDate AND @EndDate";
                    using (SqlCommand command = new SqlCommand(holidayQuery, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate.Date);
                        command.Parameters.AddWithValue("@EndDate", endDate.Date);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(holidayData);
                        }
                    }

                    // Fetch attendance data
                    attendanceData = new DataTable();
                    string attendanceQuery = @"
                    SELECT ar.EmployeeID, ep.EmployeeName, ar.[Date], ar.TimeIn, ar.TimeOut, ar.Leave_Type
                    FROM AttendanceRegister ar
                    LEFT JOIN EmployeeProfile ep ON ar.EmployeeID = ep.EmployeeID
                    WHERE ar.[Date] BETWEEN @StartDate AND @EndDate";
                    if (employeeId.HasValue)
                    {
                        attendanceQuery += " AND ar.EmployeeID = @EmployeeID";
                    }
                    attendanceQuery += " ORDER BY ar.[Date], ar.EmployeeID";
                    using (SqlCommand command = new SqlCommand(attendanceQuery, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate.Date);
                        command.Parameters.AddWithValue("@EndDate", endDate.Date);
                        if (employeeId.HasValue)
                        {
                            command.Parameters.AddWithValue("@EmployeeID", employeeId.Value);
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(attendanceData);
                        }
                    }
                }

                if (employeeId.HasValue && employeeData.Rows.Count == 0)
                {
                    MessageBox.Show($"No employee found with EmployeeID {employeeId.Value}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Generate all expected records for each employee and date
                DataTable finalData = new DataTable();
                finalData.Columns.Add("EmployeeID", typeof(int));
                finalData.Columns.Add("EmployeeName", typeof(string));
                finalData.Columns.Add("Date", typeof(DateTime));
                finalData.Columns.Add("TimeIn", typeof(TimeSpan));
                finalData.Columns.Add("TimeOut", typeof(TimeSpan));
                finalData.Columns.Add("Leave_Type", typeof(string));
                finalData.Columns.Add("Status", typeof(string));

                var dateRange = Enumerable.Range(0, (endDate.Date - startDate.Date).Days + 1)
                    .Select(d => startDate.Date.AddDays(d));
                var holidays = holidayData.AsEnumerable().Select(r => r.Field<DateTime>("Date")).ToList();

                foreach (DataRow emp in employeeData.Rows)
                {
                    int empId = Convert.ToInt32(emp["EmployeeID"]);
                    string employeeName = emp["EmployeeName"]?.ToString() ?? "Unknown";
                    TimeSpan? scheduledDutyIn = emp["DutyIn"] != DBNull.Value ? (TimeSpan?)emp["DutyIn"] : null;

                    foreach (DateTime date in dateRange)
                    {
                        if (holidays.Contains(date))
                        {
                            finalData.Rows.Add(empId, employeeName, date, null, null, "", "Holiday");
                            continue;
                        }

                        var attendanceRows = attendanceData.AsEnumerable()
                            .Where(r => r.Field<int>("EmployeeID") == empId && r.Field<DateTime>("Date").Date == date)
                            .ToList();

                        if (attendanceRows.Any())
                        {
                            foreach (var row in attendanceRows)
                            {
                                string status = "";
                                if (string.IsNullOrEmpty(row["Leave_Type"]?.ToString()) && scheduledDutyIn.HasValue && row["TimeIn"] != DBNull.Value)
                                {
                                    TimeSpan actualTimeIn = (TimeSpan)row["TimeIn"];
                                    if (actualTimeIn > scheduledDutyIn.Value)
                                    {
                                        status = "Late";
                                    }
                                }
                                finalData.Rows.Add(
                                    empId,
                                    employeeName,
                                    row["Date"],
                                    row["TimeIn"] != DBNull.Value ? (TimeSpan?)row["TimeIn"] : null,
                                    row["TimeOut"] != DBNull.Value ? (TimeSpan?)row["TimeOut"] : null,
                                    row["Leave_Type"]?.ToString() ?? "",
                                    status
                                );
                            }
                        }
                        else
                        {
                            finalData.Rows.Add(empId, employeeName, date, null, null, "", "Absent");
                        }
                    }
                }

                if (finalData.Rows.Count == 0)
                {
                    MessageBox.Show("No attendance records found for the selected criteria.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Generate text file
                StringBuilder textReport = new StringBuilder();
                textReport.AppendLine("Daily Attendance Report");
                textReport.AppendLine($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                textReport.AppendLine($"Date Range: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");
                if (employeeId.HasValue)
                {
                    textReport.AppendLine($"Employee ID: {employeeId.Value}");
                }
                textReport.AppendLine(new string('=', 90));
                textReport.AppendLine($"{"EmployeeID",-10} {"EmployeeName",-30} {"Date",-12} {"TimeIn",-10} {"TimeOut",-10} {"Leave Type",-10} {"Status",-10}");
                textReport.AppendLine(new string('-', 90));

                foreach (DataRow row in finalData.Rows)
                {
                    int empId = Convert.ToInt32(row["EmployeeID"]);
                    string employeeName = row["EmployeeName"]?.ToString() ?? "Unknown";
                    DateTime date = Convert.ToDateTime(row["Date"]);
                    string timeIn = row["TimeIn"] != DBNull.Value ? ((TimeSpan)row["TimeIn"]).ToString(@"hh\:mm\:ss") : "";
                    string timeOut = row["TimeOut"] != DBNull.Value ? ((TimeSpan)row["TimeOut"]).ToString(@"hh\:mm\:ss") : "";
                    string leaveType = row["Leave_Type"]?.ToString() ?? "";
                    string status = row["Status"]?.ToString() ?? "";
                    textReport.AppendLine($"{empId,-10} {employeeName,-30} {date:yyyy-MM-dd,-12} {timeIn,-10} {timeOut,-10} {leaveType,-10} {status,-10}");
                }

                textReport.AppendLine(new string('=', 90));
                textReport.AppendLine($"Total Records: {finalData.Rows.Count}");

                File.WriteAllText(filePath, textReport.ToString());

                // Generate HTML file
                string htmlFilePath = Path.ChangeExtension(filePath, ".html");
                StringBuilder htmlReport = new StringBuilder();
                htmlReport.AppendLine("<!DOCTYPE html>");
                htmlReport.AppendLine("<html lang='en'>");
                htmlReport.AppendLine("<head>");
                htmlReport.AppendLine("<meta charset='UTF-8'>");
                htmlReport.AppendLine("<title>Daily Attendance Report</title>");
                htmlReport.AppendLine("<style>");
                htmlReport.AppendLine("body { font-family: 'Segoe UI', Arial, sans-serif; margin: 20px; background-color: #fff; }");
                htmlReport.AppendLine("h1 { text-align: center; color: #333; }");
                htmlReport.AppendLine("p { margin: 5px 0; color: #333; }");
                htmlReport.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
                htmlReport.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
                htmlReport.AppendLine("th { background-color: #f2f2f2; color: #333; }");
                htmlReport.AppendLine("tr:nth-child(even) { background-color: #f9f9f9; }");
                htmlReport.AppendLine("tr:hover { background-color: #f0f0f0; }");
                htmlReport.AppendLine("@media print {");
                htmlReport.AppendLine("  body { margin: 0; }");
                htmlReport.AppendLine("  table { font-size: 12pt; }");
                htmlReport.AppendLine("  .no-print { display: none; }");
                htmlReport.AppendLine("}");
                htmlReport.AppendLine("</style>");
                htmlReport.AppendLine("</head>");
                htmlReport.AppendLine("<body>");
                htmlReport.AppendLine("<h1>Daily Attendance Report</h1>");
                htmlReport.AppendLine($"<p>Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}</p>");
                htmlReport.AppendLine($"<p>Date Range: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}</p>");
                if (employeeId.HasValue)
                {
                    htmlReport.AppendLine($"<p>Employee ID: {employeeId.Value}</p>");
                }
                htmlReport.AppendLine("<table>");
                htmlReport.AppendLine("<tr><th>EmployeeID</th><th>EmployeeName</th><th>Date</th><th>TimeIn</th><th>TimeOut</th><th>Leave Type</th><th>Status</th></tr>");

                foreach (DataRow row in finalData.Rows)
                {
                    int empId = Convert.ToInt32(row["EmployeeID"]);
                    string employeeName = row["EmployeeName"]?.ToString() ?? "Unknown";
                    DateTime date = Convert.ToDateTime(row["Date"]);
                    string timeIn = row["TimeIn"] != DBNull.Value ? ((TimeSpan)row["TimeIn"]).ToString(@"hh\:mm\:ss") : "";
                    string timeOut = row["TimeOut"] != DBNull.Value ? ((TimeSpan)row["TimeOut"]).ToString(@"hh\:mm\:ss") : "";
                    string leaveType = row["Leave_Type"]?.ToString() ?? "";
                    string status = row["Status"]?.ToString() ?? "";
                    htmlReport.AppendLine($"<tr><td>{empId}</td><td>{System.Web.HttpUtility.HtmlEncode(employeeName)}</td><td>{date:yyyy-MM-dd}</td><td>{timeIn}</td><td>{timeOut}</td><td>{leaveType}</td><td>{status}</td></tr>");
                }

                htmlReport.AppendLine("</table>");
                htmlReport.AppendLine($"<p>Total Records: {finalData.Rows.Count}</p>");
                htmlReport.AppendLine("</body>");
                htmlReport.AppendLine("</html>");

                File.WriteAllText(htmlFilePath, htmlReport.ToString());

                // Print document
                PrintDocument printDoc = new PrintDocument();
                printDoc.DocumentName = "Daily Attendance Report";
                int currentRow = 0;
                int rowsPerPage = 50;
                float yPos = 0;
                printDoc.PrintPage += (s, args) =>
                {
                    float margin = 100;
                    float x = margin;
                    yPos = margin;
                    float pageWidth = args.PageBounds.Width - 2 * margin;
                    float tableWidth = pageWidth;
                    float[] columnWidths = { 0.1f * tableWidth, 0.3f * tableWidth, 0.15f * tableWidth, 0.15f * tableWidth, 0.15f * tableWidth, 0.1f * tableWidth, 0.1f * tableWidth };
                    using (Font headerFont = new Font("Segoe UI", 12, FontStyle.Bold))
                    using (Font bodyFont = new Font("Segoe UI", 10))
                    {
                        // Header
                        args.Graphics.DrawString("Daily Attendance Report", headerFont, Brushes.Black, new RectangleF(margin, yPos, pageWidth, 30), new StringFormat { Alignment = StringAlignment.Center });
                        yPos += 40;
                        args.Graphics.DrawString($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", bodyFont, Brushes.Black, margin, yPos);
                        yPos += 20;
                        args.Graphics.DrawString($"Date Range: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}", bodyFont, Brushes.Black, margin, yPos);
                        if (employeeId.HasValue)
                        {
                            yPos += 20;
                            args.Graphics.DrawString($"Employee ID: {employeeId.Value}", bodyFont, Brushes.Black, margin, yPos);
                        }
                        yPos += 30;

                        // Table headers
                        string[] headers = { "EmployeeID", "EmployeeName", "Date", "TimeIn", "TimeOut", "Leave Type", "Status" };
                        for (int i = 0; i < headers.Length; i++)
                        {
                            args.Graphics.FillRectangle(Brushes.LightGray, x, yPos, columnWidths[i], 20);
                            args.Graphics.DrawRectangle(Pens.Black, x, yPos, columnWidths[i], 20);
                            args.Graphics.DrawString(headers[i], bodyFont, Brushes.Black, new RectangleF(x + 2, yPos + 2, columnWidths[i] - 4, 20), new StringFormat { Alignment = StringAlignment.Near });
                            x += columnWidths[i];
                        }
                        yPos += 20;

                        // Table data
                        int rowsThisPage = 0;
                        while (currentRow < finalData.Rows.Count && rowsThisPage < rowsPerPage)
                        {
                            DataRow row = finalData.Rows[currentRow];
                            x = margin;
                            string[] rowData = new[]
                            {
                                row["EmployeeID"].ToString(),
                                row["EmployeeName"]?.ToString() ?? "Unknown",
                                Convert.ToDateTime(row["Date"]).ToString("yyyy-MM-dd"),
                                row["TimeIn"] != DBNull.Value ? ((TimeSpan)row["TimeIn"]).ToString(@"hh\:mm\:ss") : "",
                                row["TimeOut"] != DBNull.Value ? ((TimeSpan)row["TimeOut"]).ToString(@"hh\:mm\:ss") : "",
                                row["Leave_Type"]?.ToString() ?? "",
                                row["Status"]?.ToString() ?? ""
                            };

                            for (int i = 0; i < rowData.Length; i++)
                            {
                                args.Graphics.DrawRectangle(Pens.Black, x, yPos, columnWidths[i], 20);
                                args.Graphics.DrawString(rowData[i], bodyFont, Brushes.Black, new RectangleF(x + 2, yPos + 2, columnWidths[i] - 4, 20), new StringFormat { Alignment = StringAlignment.Near });
                                x += columnWidths[i];
                            }
                            yPos += 20;
                            currentRow++;
                            rowsThisPage++;
                        }

                        // Footer
                        if (currentRow >= finalData.Rows.Count)
                        {
                            yPos += 20;
                            args.Graphics.DrawString($"Total Records: {finalData.Rows.Count}", bodyFont, Brushes.Black, margin, yPos);
                        }

                        args.HasMorePages = currentRow < finalData.Rows.Count;
                        if (args.HasMorePages)
                        {
                            yPos = margin; // Reset for next page
                        }
                    }
                };

                using (PrintDialog printDialog = new PrintDialog())
                {
                    printDialog.Document = printDoc;
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        printDoc.Print();
                    }
                }

                MessageBox.Show($"Successfully exported {finalData.Rows.Count} attendance records to {filePath} and {htmlFilePath} and sent to printer.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting or printing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageBox.Show("Start date cannot be after end date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Please select a file path.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ExportAttendance(dtpStartDate.Value, dtpEndDate.Value, filePath);
            btnExport.Enabled = false;
            this.Close();
        }

        private void BtnExportCurrentDay_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime currentDate = DateTime.Today;
                string defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"AttendanceReport_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                ExportAttendance(currentDate, currentDate, defaultPath);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting or printing current day data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportCurrentMonth_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);
                string defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"AttendanceReport_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                ExportAttendance(startDate, endDate, defaultPath);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting or printing current month data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportByEmployeeId_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmployeeId.Text) || !int.TryParse(txtEmployeeId.Text, out int employeeId))
                {
                    MessageBox.Show("Please enter a valid Employee ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
                {
                    MessageBox.Show("Start date cannot be after end date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"AttendanceReport_Employee{employeeId}_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                ExportAttendance(dtpStartDate.Value, dtpEndDate.Value, defaultPath, employeeId);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting or printing data for Employee ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}