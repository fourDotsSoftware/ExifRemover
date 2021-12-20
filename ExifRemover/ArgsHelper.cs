using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;

namespace ExifRemover
{ 
    public class ArgsHelper
    {
        public static string[] SelectedFiles = null;

        public static bool ExamineArgs(string[] args)
        {           
            if (args.Length == 0) return true;

            Module.args = args;

            try
            {                               
                if (args.Length>0 && args[0].ToLower().Trim().Contains("-tempfile:"))
                {                    
                    string tempfile = GetParameter(args[0]);                    

                    using (StreamReader sr = new StreamReader(tempfile, Encoding.Unicode))
                    {
                        string scont = sr.ReadToEnd();                        

                        SelectedFiles = SplitArguments(scont);                                                
                    }

                    try
                    {
                        System.IO.File.Delete(tempfile);
                    }
                    catch
                    {}                    

                    
                }
                else
                {                    
                    Module.IsCommandLine = true;

                    frmMain fr = new frmMain();
                    
                    frmMain.Instance.SetupOnLoad();

                    bool folderwatcher = false;

                    for (int k = 0; k < Module.args.Length; k++)
                    {
                        //Console.WriteLine(Module.args[k]);

                        if (System.IO.File.Exists(Module.args[k]))
                        {
                            frmMain.Instance.AddFile(Module.args[k]);
                        }
                        else if (System.IO.Directory.Exists(Module.args[k]))
                        {
                            frmMain.Instance.AddFolder(Module.args[k]);
                        }                                                                                                
                        else if (Module.args[k].ToLower().StartsWith("/pattern:") ||
                    Module.args[k].ToLower().StartsWith("-pattern:"))
                        {
                            string val = GetParameter(Module.args[k]);

                            frmMain.Instance.txtFilenamePattern.Text = val;
                        }
                        else if (Module.args[k].ToLower().StartsWith("/keepfs") ||
                Module.args[k].ToLower().StartsWith("-keepfs"))
                        {
                            frmMain.Instance.chkKeepFolderStructure.Checked = true;                            
                        }
                        else if (Module.args[k].ToLower().StartsWith("/keepcd") ||
            Module.args[k].ToLower().StartsWith("-keepcd"))
                        {
                            frmMain.Instance.chkKeepCreationDate.Checked = true;
                        }
                        else if (Module.args[k].ToLower().StartsWith("/keepmd") ||
            Module.args[k].ToLower().StartsWith("-keepmd"))
                        {
                            frmMain.Instance.chkKeepLastModDate.Checked = true;
                        }
                        else if (Module.args[k].ToLower().StartsWith("/outfolder:") ||
                        Module.args[k].ToLower().StartsWith("-outfolder:"))
                        {
                            string val = GetParameter(Module.args[k]);

                            frmMain.Instance.cmbOutputDir.Text = val;
                        }
                        else if (Module.args[k].ToLower() == "/folderwatcher" ||
Module.args[k].ToLower() == "-folderwatcher")
                        {
                            frmMain.Instance.IsFromFolderWatcher = true;
                        }
                        else if (Module.args[k].ToLower() == "/h" ||
Module.args[k].ToLower() == "-h" ||
Module.args[k].ToLower() == "-?" ||
Module.args[k].ToLower() == "/?")
                        {
                            ShowCommandUsage();
                            Environment.Exit(1);
                            return true;
                        }

                    }                    

                    frmMain.Instance.tsbRemoveExif_Click(null, null);

                    while (frmMain.Instance.Working)
                    {
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not parse Arguments !", ex.ToString());
                return false;
            }


            return true;
        }

        public static string GetParameter(string arg)
        {
            int spos = arg.IndexOf(":");
            if (spos == arg.Length - 1) return "";
            else
            {
                string str=arg.Substring(spos + 1);

                if ((str.StartsWith("\"") && str.EndsWith("\"")) ||
                    (str.StartsWith("'") && str.EndsWith("'")))
                {
                    if (str.Length > 2)
                    {
                        str = str.Substring(1, str.Length - 2);
                    }
                    else
                    {
                        str = "";
                    }
                }

                return str;
            }
        }

        public static string[] SplitArguments(string commandLine)
        {
            char[] parmChars = commandLine.ToCharArray();
            bool inSingleQuote = false;
            bool inDoubleQuote = false;
            for (int index = 0; index < parmChars.Length; index++)
            {
                if (parmChars[index] == '"' && !inSingleQuote)
                {
                    inDoubleQuote = !inDoubleQuote;
                    parmChars[index] = '\n';
                }
                if (parmChars[index] == '\'' && !inDoubleQuote)
                {
                    inSingleQuote = !inSingleQuote;
                    parmChars[index] = '\n';
                }
                if (!inSingleQuote && !inDoubleQuote && parmChars[index] == ' ')
                    parmChars[index] = '\n';
            }
            return (new string(parmChars)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }
        
        public static void ShowCommandUsage()
        {
            string msg = "Remove Exif Information from files.\n\n" +
            "ExifRemover.exe [[file|directory]]\n" +            
            "[/pattern:PATTERN_VALUE]\n" +
            "[/outfolder:OUTFOLDER_VALUE]\n" +          
            "[/keepfs]\n"+
            "[/keepcd]\n"+
            "[/keepmd]\n"+
            "[/?]\n\n\n" +            
            "file : one or more image files to be processed.\n" +
            "directory : one or more directories containing images to be processed.\n" +                        
            "pattern : output filename pattern\n"+
            "keepfs : keep folder structure when adding directories.\n"+
            "keepcd : keep file creation date.\n"+
            "keepmd : keep file last modification date.\n"+
            "outfolder : output folder\n"+                        
            "/? : show help\n";
            
            Module.ShowMessage(msg);
                        
            Environment.Exit(0);
        }

        public static bool IsFromWindowsExplorer
        {
            get
            {
                if (Module.IsFromWindowsExplorer) return true;

                if (Module.args!=null && Module.args.Length > 0 && Module.args[0].ToLower().Trim().Contains("-tempfile:"))
                {
                    Module.IsFromWindowsExplorer = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsFromCommandLine
        {
            get
            {
                if (Module.args == null || Module.args.Length == 0)
                {
                    return false;
                }

                if (ArgsHelper.IsFromWindowsExplorer)
                {
                    Module.IsCommandLine = false;
                    return false;
                }
                else
                {
                    Module.IsCommandLine = true;
                    return true;
                }
            }
        }

        /*
        public static bool IsFromWindowsExplorer()
        {
            if (Module.args == null || Module.args.Length == 0)
            {
                return false;
            }

            for (int k = 0; k < Module.args.Length; k++)
            {
                if (Module.args[k] == "-visual")
                {
                    Module.IsFromWindowsExplorer = true;
                    return true;
                }
            }

            Module.IsFromWindowsExplorer = false;
            return false;
        }
        */

        public static void ExecuteCommandLine()
        {
            /*
            string err = "";
            bool finished = false;

            try
            {
                if (Module.CmdLogFile != string.Empty)
                {
                    try
                    {
                        Module.CmdLogFileWriter = new StreamWriter(Module.CmdLogFile, true);
                        Module.CmdLogFileWriter.AutoFlush = true;
                        Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] Started compressing PDF files !");
                    }
                    catch (Exception exl)
                    {
                        Module.ShowMessage("Error could not start log writer !");
                        ShowCommandUsage();
                        Environment.Exit(0);
                        return;
                    }
                }                

                if (Module.CmdImportListFile != string.Empty)
                {
                    frmMain.Instance.ImportList(Module.CmdImportListFile);

                    err += frmMain.Instance.SilentAddErr;

                }

                if ( Module.dt.Rows.Count == 0)
                {
                    err+="Please specify PDF Files to Compress !";
                    ShowCommandUsage();
                    Environment.Exit(0);
                    return;
                }

                try
                {
                    err += PDFCompressHelper.CompressDecompressMultiplePDFCmd( Module.dt);
                    finished = true;
                }
                catch (Exception ex)
                {
                    err += ex.Message + "\r\n";
                }                
            }
            finally
            {
                if (Module.CmdLogFile == string.Empty)
                {
                    if (err == string.Empty && finished)
                    {
                        Module.ShowMessage("Operation completed successfully !");
                    }
                    else
                    {
                        Module.ShowMessage("An error occured !\n" + err);
                    }
                }
                else
                {
                    if (err == string.Empty && finished)
                    {
                        Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] Operation completed successfully !");
                    }
                    else
                    {
                        Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] An error occured !\n" + err);
                    }
                }

                if (Module.CmdLogFileWriter != null)
                {
                    Module.CmdLogFileWriter.Flush();
                    Module.CmdLogFileWriter.Close();
                }
            }
            Environment.Exit(0);
            */
        }                                                      
    }

    public class ReadListsResult
    {
        public bool Success = true;
        public string err = "";
    }
}