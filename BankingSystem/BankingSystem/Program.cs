using System.Configuration;
namespace BankingSystem.Login
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
            ConfigurationManager.AppSettings.Set("DirectoryToProject", Directory.GetCurrentDirectory().ToString() + @"\..\..\..");
            Application.Run(new Form1());
        }
    }
}