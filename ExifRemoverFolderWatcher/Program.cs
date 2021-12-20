using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExifRemoverFolderWatcher
{ 
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool cu = true;

            if (args.Length > 0 && args[0].Trim().ToLower() == "-lm")
            {
                cu = false;
            }

            Application.Run(new frmMain(cu));
        }
    }
}
