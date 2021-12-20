using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ExifRemover
{
    class ExceptionHandlersHelper
    {
        public static void AddUnhandledExceptionHandlers()
        {            
            // Define a handler for unhandled exceptions.
            AppDomain.CurrentDomain.UnhandledException +=
                new System.UnhandledExceptionEventHandler(myExceptionHandler);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(
                myThreadExceptionHandler);

        }

        private static void myExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;            

            Module.ShowError(TranslateHelper.Translate("Unspecified Error"), ex.ToString());

        }

        private static void myThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = (Exception)e.Exception;            

            Module.ShowError(TranslateHelper.Translate("Unspecified Error"), e.Exception.ToString());            
        }

    }
}
