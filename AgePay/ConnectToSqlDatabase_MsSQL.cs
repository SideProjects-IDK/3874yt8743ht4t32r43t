using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AgePay
{
    public static class ConnectToSqlDatabase_MsSQL
    {
        public static readonly string connectionString = "Server=192.168.1.197;Database=AgePay;User Id=sa;Password=ilahia;";
        private static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Application will exit if connection fails.
                    Application.Exit();
                }
            }
            return connection;
        }

        public static void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
