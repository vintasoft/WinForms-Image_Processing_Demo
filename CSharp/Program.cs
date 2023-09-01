using System;
using System.Windows.Forms;

namespace ImageProcessingDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DemosCommonCode.DemosTools.EnableLicenseExceptionDisplaying();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
