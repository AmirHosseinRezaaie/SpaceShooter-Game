using Final_Ap_Project.Managers;
using Final_Ap_Project.UI;

namespace Final_Ap_Project
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
            
            AudioManager.Init();

            DatabaseManager.Initialize();
            
            Application.Run(new LoginForm());
        }
    }
}