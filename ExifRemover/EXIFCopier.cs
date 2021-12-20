using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExifRemover
{
    public class EXIFCopier
    {        
        public static bool ClearEXIF(string inputFilepath,string outputFilepath)
        {
            if (System.IO.File.Exists(inputFilepath + "_original"))
            {
                System.IO.File.Delete(inputFilepath + "_original");
            }

            if (System.IO.File.Exists(inputFilepath))
            {
                System.Diagnostics.Process pr = new Process();
                pr.StartInfo.FileName = "\"" + System.IO.Path.Combine(Application.StartupPath, "exiftool.exe") + "\"";
                pr.StartInfo.Arguments = "-exif= \"" + inputFilepath + "\"";
                pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pr.StartInfo.UseShellExecute = true;
                pr.Start();

                while (!pr.HasExited)
                {
                    Application.DoEvents();
                }

                if (inputFilepath == outputFilepath)
                {
                    if (System.IO.File.Exists(inputFilepath + "_original"))                    
                    {
                        ImageHelper.FixFileDates(outputFilepath, inputFilepath + "_original");

                        try
                        {
                            System.IO.File.Delete(inputFilepath + "_original");
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    if (System.IO.File.Exists(inputFilepath + "_original"))
                    {
                        if (System.IO.File.Exists(outputFilepath))
                        {
                            System.IO.File.Delete(outputFilepath);
                        }

                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(outputFilepath)))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(outputFilepath));
                        }

                        System.IO.File.Move(inputFilepath, outputFilepath);

                        System.IO.File.Move(inputFilepath + "_original",inputFilepath);

                        ImageHelper.FixFileDates(outputFilepath, inputFilepath);
                    }
                }

                
            }

            return true;
        }
    }
}
