using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;
using AgePay.mainpanel_utils;

namespace AgePay
{
    public partial class frmLogin : Form
    {
        private readonly SqlConnection connection = ConnectToSqlDatabase_MsSQL.GetConnection();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Center the GroupBox
            groupBox1.Location = new Point(
                (this.ClientSize.Width - groupBox1.Width) / 2,
                (this.ClientSize.Height - groupBox1.Height) / 2
            );
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = comboBox1.Text.Trim();
                comboBox1.Items.Clear();

                if (!string.IsNullOrEmpty(searchText))
                {
                    string query = "SELECT TOP 5 cardno, username FROM tblUserAccess WHERE username LIKE @SearchText ORDER BY username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");
                        if (connection.State != ConnectionState.Open)
                            connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string cardno = reader.GetString(0);
                                string username = reader.GetString(1);
                                comboBox1.Items.Add(new ComboBoxItem(cardno, username));
                            }
                        }
                    }
                }

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading username suggestions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = comboBox1.Text.Trim();
                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Please enter or select a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string password = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "SELECT privileges FROM tblUserAccess WHERE username = @Username AND password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string privileges = result.ToString();
                        bool hasLoginPrivilege;

                        // Handle privileges as either a JSON array or a single string
                        if (privileges.StartsWith("[") && privileges.EndsWith("]"))
                        {
                            var privilegeList = JsonSerializer.Deserialize<List<string>>(privileges) ?? new List<string>();
                            hasLoginPrivilege = privilegeList.Contains("frmLogin");
                        }
                        else
                        {
                            hasLoginPrivilege = privileges == "frmLogin";
                        }

                        if (hasLoginPrivilege)
                        {
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            MainPanel mainPanel = new MainPanel(privileges);
                            mainPanel.FormClosed += (s, args) => this.Close();
                            mainPanel.Show();
                        }
                        else
                        {
                            MessageBox.Show("ACCOUNT LOCKED", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Placeholder to preserve designer event hookup
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Placeholder to preserve designer event hookup
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Placeholder to preserve designer event hookup
        }

        private class ComboBoxItem
        {
            public string CardNo { get; }
            public string Username { get; }

            public ComboBoxItem(string cardno, string username)
            {
                CardNo = cardno;
                Username = username;
            }

            public override string ToString()
            {
                return Username;
            }
        }
    }
}