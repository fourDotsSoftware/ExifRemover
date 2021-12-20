using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ExifRemover
{
    static class Program
    {        
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        const int ATTACH_PARENT_PROCESS = -1;
        const int ERROR_ACCESS_DENIED = 5;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ExceptionHandlersHelper.AddUnhandledExceptionHandlers();            

            Module.args = args;
                        
            frmLanguage.SetLanguages();
            frmLanguage.SetLanguage();

            if (args.Length > 0 && args[0].StartsWith("/uninstall"))
            {
                Module.DeleteApplicationSettingsFile();

                System.Diagnostics.Process.Start("https://www.4dots-software.com/support/bugfeature.php?uninstall=true&app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));
                
                Environment.Exit(0);

                return;
            }

            Module.args = args;

            if (Module.args.Length > 0)
            {
                string sargs = "";

                for (int k = 0; k < args.Length; k++)
                {
                    sargs += args[k] + " ";
                }

                //Module.ShowMessage(sargs);
            }
            //Module.ShowMessage(args[0]);            

            if (ArgsHelper.IsFromWindowsExplorer)
            {                
                ArgsHelper.ExamineArgs(args);                
            }
            else if (ArgsHelper.IsFromCommandLine)
            {                
                if (!AttachConsole(ATTACH_PARENT_PROCESS) && Marshal.GetLastWin32Error() == ERROR_ACCESS_DENIED)
                {
                    AllocConsole();
                }

                ArgsHelper.ExamineArgs(args);

                ArgsHelper.ExecuteCommandLine();

                Environment.Exit(0);                
            }            

                Application.Run(new frmMain());                                                                                              
        }
    }
}
