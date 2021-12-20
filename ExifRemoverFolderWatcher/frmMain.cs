using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ExifRemoverFolderWatcher
{
    public partial class frmMain : Form
    {
        public string AppFilepath = "";
        public string ConvertArgs = "";

        public List<System.IO.FileSystemWatcher> fws = new List<System.IO.FileSystemWatcher>();
        private List<string> lstWatchProfiles = new List<string>();

        public List<string> Filepaths = new List<string>();

        public frmMain(bool forCurrentUser)
        {
            InitializeComponent();

            this.Visible = false;

            if (forCurrentUser)
            {
                string watchfolders = RegistryHelper2.GetKeyValue("Exif Remover", "WatchFolders");

                if (watchfolders != string.Empty)
                {
                    AppFilepath = RegistryHelper2.GetKeyValue("Exif Remover", "AppFilepath");                    

                    string[] dirz = watchfolders.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);                    

                    for (int k = 0; k < dirz.Length; k++)
                    {
                        System.IO.FileSystemWatcher fw = new System.IO.FileSystemWatcher(dirz[k]);
                        fw.Created += fw_Created;
                        fw.IncludeSubdirectories = true;
                        fw.EnableRaisingEvents = true;
                                                
                        fws.Add(fw);                        
                    }
                }
            }
            else
            {
                string watchfolders = RegistryHelper2.GetKeyValueLMLowPriv("Exif Remover", "WatchFolders");

                if (watchfolders != string.Empty)
                {
                    AppFilepath = RegistryHelper2.GetKeyValueLMLowPriv("Exif Remover", "AppFilepath");                    

                    string[] dirz = watchfolders.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
                    
                    for (int k = 0; k < dirz.Length; k++)
                    {
                        System.IO.FileSystemWatcher fw = new System.IO.FileSystemWatcher(dirz[k]);
                        fw.Created += fw_Created;
                        fw.IncludeSubdirectories = true;
                        fw.EnableRaisingEvents = true;
                        
                        fws.Add(fw);                        
                    }
                }
            }
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            this.Hide();
        }               

        void fw_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            lock (Filepaths)
            {                
                if (IsPPDocument(e.FullPath))
                {
                    Filepaths.Add(e.FullPath);
                }

                while (Filepaths.Count>0)
                {                    
                     try
                     {
                        string filepath = Filepaths[0];

                        Filepaths.RemoveAt(0);

                        Process proc = new Process();

                        if (!AppFilepath.StartsWith("\""))
                        {
                           // AppFilepath = "\"" + AppFilepath + "\"";
                        }

                        proc.StartInfo.FileName = AppFilepath;

                        int k = fws.IndexOf((System.IO.FileSystemWatcher)sender);

                        proc.StartInfo.Arguments = "-folderwatcher \"" + filepath + "\"";

                        proc.StartInfo.UseShellExecute = false;
                        proc.StartInfo.CreateNoWindow = true;

                        proc.Start();
                        proc.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

        }

        public static string AcceptablePPMediaInputPattern = "*.*;";

        public static bool IsPPDocument(string filepath)
        {
            string fn = System.IO.Path.GetFileNameWithoutExtension(filepath);

            if (fn.ToLower().EndsWith("_fw"))
            {
                return false;
            }

            if (filepath.StartsWith("\"") && filepath.EndsWith("\""))
            {
                filepath = filepath.Substring(1, filepath.Length - 2);
            }

            string ext = "*" + System.IO.Path.GetExtension(filepath).ToLower() + ";";

            return true;

            /*if (AcceptablePPMediaInputPattern.IndexOf(ext) < 0)
            
            {
                return false;
            }
            else
            {
                return true;
            }*/
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}