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
        private Button btnBrowse;
        private Button btnExport;
        private Button btnExportCurrentMonth;
        private string filePath;
        private DataTable attendanceData;

        public frmExportAttendance()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new Size(400, 230);
            this.Text = "Export Attendance Register";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 240);

            lblStartDate = new Label
            {
                Text = "Start Date:",
                Location = new Point(20, 20),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 10)
            };

            dtpStartDate = new DateTimePicker
            {
                Location = new Point(120, 20),
                Width = 250,
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10),
                Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
            };

            lblEndDate = new Label
            {
                Text = "End Date:",
                Location = new Point(20, 50),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 10)
            };

            dtpEndDate = new DateTimePicker
            {
                Location = new Point(120, 50),
                Width = 250,
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10),
                Value = DateTime.Today
            };

            btnBrowse = new Button
            {
                Text = "Browse File",
                Location = new Point(20, 90),
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

            btnExport = new Button
            {
                Text = "Export",
                Location = new Point(150, 90),
                Size = new Size(120, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(150, 159, 167) },
                Enabled = false
            };
            btnExport.Click += BtnExport_Click;
            btnExport.MouseEnter += (s, e) => btnExport.BackColor = Color.FromArgb(150, 159, 167);
            btnExport.MouseLeave += (s, e) => btnExport.BackColor = Color.FromArgb(108, 117, 125);

            btnExportCurrentMonth = new Button
            {
                Text = "Export Current Month",
                Location = new Point(20, 130),
                Size = new Size(250, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(150, 159, 167) }
            };
            btnExportCurrentMonth.Click += BtnExportCurrentMonth_Click;
            btnExportCurrentMonth.MouseEnter += (s, e) => btnExportCurrentMonth.BackColor = Color.FromArgb(150, 159, 167);
            btnExportCurrentMonth.MouseLeave += (s, e) => btnExportCurrentMonth.BackColor = Color.FromArgb(108, 117, 125);

            this.Controls.AddRange(new Control[] { lblStartDate, dtpStartDate, lblEndDate, dtpEndDate, btnBrowse, btnExport, btnExportCurrentMonth });
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

        private void ExportAttendance(DateTime startDate, DateTime endDate, string filePath)
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
                    string employeeQuery = "SELECT EmployeeID, EmployeeName, DutyIn FROM EmployeeProfile";
                    using (SqlCommand command = new SqlCommand(employeeQuery, connection))
                    {
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
                    WHERE ar.[Date] BETWEEN @StartDate AND @EndDate
                    ORDER BY ar.[Date], ar.EmployeeID";
                    using (SqlCommand command = new SqlCommand(attendanceQuery, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate.Date);
                        command.Parameters.AddWithValue("@EndDate", endDate.Date);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(attendanceData);
                        }
                    }
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
                    int employeeId = Convert.ToInt32(emp["EmployeeID"]);
                    string employeeName = emp["EmployeeName"]?.ToString() ?? "Unknown";
                    TimeSpan? scheduledDutyIn = emp["DutyIn"] != DBNull.Value ? (TimeSpan?)emp["DutyIn"] : null;

                    foreach (DateTime date in dateRange)
                    {
                        if (holidays.Contains(date))
                        {
                            finalData.Rows.Add(employeeId, employeeName, date, null, null, "", "Holiday");
                            continue;
                        }

                        var attendanceRows = attendanceData.AsEnumerable()
                            .Where(r => r.Field<int>("EmployeeID") == employeeId && r.Field<DateTime>("Date").Date == date)
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
                                    employeeId,
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
                            finalData.Rows.Add(employeeId, employeeName, date, null, null, "", "Absent");
                        }
                    }
                }

                if (finalData.Rows.Count == 0)
                {
                    MessageBox.Show("No attendance records found for the selected date range.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Generate text file
                StringBuilder textReport = new StringBuilder();
                textReport.AppendLine("Daily Attendance Report");
                textReport.AppendLine($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                textReport.AppendLine($"Date Range: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");
                textReport.AppendLine(new string('=', 90));
                textReport.AppendLine($"{"EmployeeID",-10} {"EmployeeName",-30} {"Date",-12} {"TimeIn",-10} {"TimeOut",-10} {"Leave Type",-10} {"Status",-10}");
                textReport.AppendLine(new string('-', 90));

                foreach (DataRow row in finalData.Rows)
                {
                    int employeeId = Convert.ToInt32(row["EmployeeID"]);
                    string employeeName = row["EmployeeName"]?.ToString() ?? "Unknown";
                    DateTime date = Convert.ToDateTime(row["Date"]);
                    string timeIn = row["TimeIn"] != DBNull.Value ? ((TimeSpan)row["TimeIn"]).ToString(@"hh\:mm\:ss") : "";
                    string timeOut = row["TimeOut"] != DBNull.Value ? ((TimeSpan)row["TimeOut"]).ToString(@"hh\:mm\:ss") : "";
                    string leaveType = row["Leave_Type"]?.ToString() ?? "";
                    string status = row["Status"]?.ToString() ?? "";
                    textReport.AppendLine($"{employeeId,-10} {employeeName,-30} {date:yyyy-MM-dd,-12} {timeIn,-10} {timeOut,-10} {leaveType,-10} {status,-10}");
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
                htmlReport.AppendLine("body { font-family: 'Segoe UI', Arial, sans-serif; margin: 20px; }");
                htmlReport.AppendLine("h1 { text-align: center; }");
                htmlReport.AppendLine("p { margin: 5px 0; }");
                htmlReport.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
                htmlReport.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
                htmlReport.AppendLine("th { background-color: #f2f2f2; }");
                htmlReport.AppendLine("tr:nth-child(even) { background-color: #f9f9f9; }");
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
                htmlReport.AppendLine("<table>");
                htmlReport.AppendLine("<tr><th>EmployeeID</th><th>EmployeeName</th><th>Date</th><th>TimeIn</th><th>TimeOut</th><th>Leave Type</th><th>Status</th></tr>");

                foreach (DataRow row in finalData.Rows)
                {
                    int employeeId = Convert.ToInt32(row["EmployeeID"]);
                    string employeeName = row["EmployeeName"]?.ToString() ?? "Unknown";
                    DateTime date = Convert.ToDateTime(row["Date"]);
                    string timeIn = row["TimeIn"] != DBNull.Value ? ((TimeSpan)row["TimeIn"]).ToString(@"hh\:mm\:ss") : "";
                    string timeOut = row["TimeOut"] != DBNull.Value ? ((TimeSpan)row["TimeOut"]).ToString(@"hh\:mm\:ss") : "";
                    string leaveType = row["Leave_Type"]?.ToString() ?? "";
                    string status = row["Status"]?.ToString() ?? "";
                    htmlReport.AppendLine($"<tr><td>{employeeId}</td><td>{System.Web.HttpUtility.HtmlEncode(employeeName)}</td><td>{date:yyyy-MM-dd}</td><td>{timeIn}</td><td>{timeOut}</td><td>{leaveType}</td><td>{status}</td></tr>");
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
                    float margin = 100; // 1 inch margin
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
                        yPos += 30;

                        // Table headers
                        string[] headers = { "EmployeeID", "EmployeeName", "Date", "TimeIn", "TimeOut", "Leave Type", "Status" };
                        float headerY = yPos;
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
            ExportAttendance(dtpStartDate.Value, dtpEndDate.Value, filePath);
            btnExport.Enabled = false;
            this.Close();
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
    }
}