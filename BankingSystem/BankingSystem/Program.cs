using System.Configuration;
using BankingSystem.AboutClient;
using BankingSystem.Loading;
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
            PrePro("Alpha Bank");
            PrePro("BSB Bank");
            PrePro("Belarus Bank");
            Application.Run(new Form1());
        }
        static void PrePro(string BankName)
        {
            Load<string, Client> loadCl = new(BankName, "ClientsData");
            loadCl.LoadFromFile();
            foreach(var cl in loadCl.Information.Values)
            {
                cl.CheckCredits();
            }
            loadCl.LoadToFile();
        }
    }
}