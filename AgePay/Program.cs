namespace AgePay
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //ConnectToSqlDatabase_MsSQL.GetConnection();
            Application.Run(new frmLogin());
           // ConnectToSqlDatabase_MsSQL.CloseConnection();
        }
    }
}
