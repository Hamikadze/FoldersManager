using System;
using System.Windows.Forms;

namespace FoldersManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            {
                FoldersFilesUtils.CreateFolder();
            }
            Application.Run(new MainForm());
        }
    }
}