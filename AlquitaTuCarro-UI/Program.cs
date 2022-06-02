using AlquitaTuCarro.Models;
using AlquitaTuCarro.UI.Forms;

namespace AlquitaTuCarro_UI
{
    internal static class Program
    {
        static public MainForm mainForm;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}