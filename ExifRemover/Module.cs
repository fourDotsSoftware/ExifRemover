using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ExifRemover
{
    class Module
    {
        public static string ApplicationName = "Exif Remover";
        public static string ApplicationVersion = "1.4";
        public static string ShortApplicationTitle = ApplicationName + " V" + ApplicationVersion;
        public static string ApplicationTitle = ShortApplicationTitle + " - 4dots Software";
                
        public static string DownloadURL = "http://www.4dots-software.com/d/ExifRemover/";
        public static string HelpURL = "https://www.4dots-software.com/exif-remover/how-to-use.php";
        public static string LangURL = "http://www.4dots-software.com/exif-remover/lang/";
        public static string ProductWebpageURL = "https://www.4dots-software.com/exif-remover/";
        public static string BuyURL = "http://www.4dots-software.com/store/buy-exif-remover.php";
        public static string VersionURL = "http://cssspritestool.com/versions/exif-remover.txt";
        
        public static string TipText = "Great application to remove sensitive Exif information from images !";

        public static string Ver = "3";

        public static System.Data.DataTable dt = new System.Data.DataTable("table");

        public static bool CmdAddSubdirectories = true;

        public static string ImageFilter = "Images Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files (*.*)|*.*|JPEG Images (*.jpg)|*.jpg;*.jpeg|GIF Images (*.gif)|*.gif" +
        "|Bitmap Images (*.bmp)|*.bmp|PNG Images (*.png)|*.png";

        //public static string ImageFilter = "All Supported Image and Archive Types (*.bmp;*.ico;*.jpg;*.jif;*.jpeg;*.jpe;*.jng;*.koa;*.iff;*.lbm;*.iff;*.lbm;*.mng;*.pbm;*.pbm;*.pcd;*.pcx;*.pgm;*.pgm;*.png;*.ppm;*.ppm;*.ras;*.tga;*.targa;*.tif;*.tiff;*.wap;*.wbmp;*.wbm;*.psd;*.cut;*.xbm;*.xpm;*.dds;*.gif;*.hdr;*.g3;*.sgi;*.exr;*.j2k;*.j2c;*.jp2;*.pfm;*.pct;*.pict;*.pic;*.3fr;*.arw;*.bay;*.bmq;*.cap;*.cine;*.cr2;*.crw;*.cs1;*.dc2;*.dcr;*.drf;*.dsc;*.dng;*.erf;*.fff;*.ia;*.iiq;*.k25;*.kc2;*.kdc;*.mdc;*.mef;*.mos;*.mrw;*.nef;*.nrw;*.orf;*.pef;*.ptx;*.pxn;*.qtk;*.raf;*.raw;*.rdc;*.rw2;*.rwl;*.rwz;*.sr2;*.srf;*.sti;*.zip;*.rar;*.bz2;*.gz;*.gzip;*.bzip2;*.bz;*.tar)|*.bmp;*.ico;*.jpg;*.jif;*.jpeg;*.jpe;*.jng;*.koa;*.iff;*.lbm;*.iff;*.lbm;*.mng;*.pbm;*.pbm;*.pcd;*.pcx;*.pgm;*.pgm;*.png;*.ppm;*.ppm;*.ras;*.tga;*.targa;*.tif;*.tiff;*.wap;*.wbmp;*.wbm;*.psd;*.cut;*.xbm;*.xpm;*.dds;*.gif;*.hdr;*.g3;*.sgi;*.exr;*.j2k;*.j2c;*.jp2;*.pfm;*.pct;*.pict;*.pic;*.3fr;*.arw;*.bay;*.bmq;*.cap;*.cine;*.cr2;*.crw;*.cs1;*.dc2;*.dcr;*.drf;*.dsc;*.dng;*.erf;*.fff;*.ia;*.iiq;*.k25;*.kc2;*.kdc;*.mdc;*.mef;*.mos;*.mrw;*.nef;*.nrw;*.orf;*.pef;*.ptx;*.pxn;*.qtk;*.raf;*.raw;*.rdc;*.rw2;*.rwl;*.rwz;*.sr2;*.srf;*.sti;*.zip;*.rar;*.bz2;*.gz;*.gzip;*.bzip2;*.bz;*.tar|All Files (*.*)|*.*|Windows or OS/2 Bitmap (*.bmp)|*.bmp|Windows Icon (*.ico)|*.ico|JPEG - JFIF Compliant (*.jpg;*.jif;*.jpeg;*.jpe)|*.jpg;*.jif;*.jpeg;*.jpe|JPEG Network Graphics (*.jng)|*.jng|C64 Koala Graphics (*.koa)|*.koa|IFF Interleaved Bitmap (*.iff;*.lbm)|*.iff;*.lbm|IFF Interleaved Bitmap (*.iff;*.lbm)|*.iff;*.lbm|Multiple Network Graphics (*.mng)|*.mng|Portable Bitmap (ASCII) (*.pbm)|*.pbm|Portable Bitmap (RAW) (*.pbm)|*.pbm|Kodak PhotoCD (*.pcd)|*.pcd|Zsoft Paintbrush (*.pcx)|*.pcx|Portable Greymap (ASCII) (*.pgm)|*.pgm|Portable Greymap (RAW) (*.pgm)|*.pgm|Portable Network Graphics (*.png)|*.png|Portable Pixelmap (ASCII) (*.ppm)|*.ppm|Portable Pixelmap (RAW) (*.ppm)|*.ppm|Sun Raster Image (*.ras)|*.ras|Truevision Targa (*.tga;*.targa)|*.tga;*.targa|Tagged Image File Format (*.tif;*.tiff)|*.tif;*.tiff|Wireless Bitmap (*.wap;*.wbmp;*.wbm)|*.wap;*.wbmp;*.wbm|Adobe Photoshop (*.psd)|*.psd|Dr. Halo (*.cut)|*.cut|X11 Bitmap Format (*.xbm)|*.xbm|X11 Pixmap Format (*.xpm)|*.xpm|DirectX Surface (*.dds)|*.dds|Graphics Interchange Format (*.gif)|*.gif|High Dynamic Range Image (*.hdr)|*.hdr|Raw fax format CCITT G.3 (*.g3)|*.g3|SGI Image Format (*.sgi)|*.sgi|ILM OpenEXR (*.exr)|*.exr|JPEG-2000 codestream (*.j2k;*.j2c)|*.j2k;*.j2c|JPEG-2000 File Format (*.jp2)|*.jp2|Portable floatmap (*.pfm)|*.pfm|Macintosh PICT (*.pct;*.pict;*.pic)|*.pct;*.pict;*.pic|RAW camera image (*.3fr;*.arw;*.bay;*.bmq;*.cap;*.cine;*.cr2;*.crw;*.cs1;*.dc2;*.dcr;*.drf;*.dsc;*.dng;*.erf;*.fff;*.ia;*.iiq;*.k25;*.kc2;*.kdc;*.mdc;*.mef;*.mos;*.mrw;*.nef;*.nrw;*.orf;*.pef;*.ptx;*.pxn;*.qtk;*.raf;*.raw;*.rdc;*.rw2;*.rwl;*.rwz;*.sr2;*.srf;*.sti)|*.3fr;*.arw;*.bay;*.bmq;*.cap;*.cine;*.cr2;*.crw;*.cs1;*.dc2;*.dcr;*.drf;*.dsc;*.dng;*.erf;*.fff;*.ia;*.iiq;*.k25;*.kc2;*.kdc;*.mdc;*.mef;*.mos;*.mrw;*.nef;*.nrw;*.orf;*.pef;*.ptx;*.pxn;*.qtk;*.raf;*.raw;*.rdc;*.rw2;*.rwl;*.rwz;*.sr2;*.srf;*.sti|Compressed Archives (*.zip;*.rar;*.bz2;*.gz;*.gzip;*.bzip2;*.bz;*.tar)|*.zip;*.rar;*.bz2;*.gz;*.gzip;*.bzip2;*.bz;*.tar";        

        public static string AppDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ExifRemover\\";

        public static List<string> GeneratedTemporaryFiles = new List<string>();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam,
        int lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        public static string SelectedProfileName = "";

        public static string ShortAppName
        {
            get
            {
                // get short application name without version part
                System.Text.RegularExpressions.Regex rex=new System.Text.RegularExpressions.Regex(@"V\d\.");

                if (rex.IsMatch(ShortApplicationTitle))
                {
                    return ShortApplicationTitle.Substring(0, rex.Match(ShortApplicationTitle).Index).Trim();
                }
                else
                {
                    return ShortApplicationTitle;
                }
            }
        }

        public static string StoreUrl = "http://www.pdfdocmerge.com/store/";
        public static string SelectedLanguage = "en-US";

        public static string[] args = null;
        public static bool IsCommandLine = false;
        public static bool IsFromWindowsExplorer = false;                               

        [DllImport("shell32.dll")]
		public static extern Int32 SHParseDisplayName(
			[MarshalAs(UnmanagedType.LPWStr)]
			String pszName,
			IntPtr pbc,
			out IntPtr ppidl,
			UInt32 sfgaoIn,
			out UInt32 psfgaoOut);

        [DllImport("shell32.dll", ExactSpelling=true, SetLastError=true, CharSet=CharSet.Unicode)]
        public static extern Int32 SHOpenFolderAndSelectItems(IntPtr pidlFolder , UInt32 cidl, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl , UInt32 dwFlags);

        /*
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam,
        int lParam);

        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);
        */              

        public static void SaveSettings()
        {
            if (!Module.IsCommandLine)
            {
                Properties.Settings.Default.Save();
            }

            if (!System.IO.Directory.Exists(Module.AppDataDirectory))
            {
                System.IO.Directory.CreateDirectory(Module.AppDataDirectory);
            }

            string tempfile = System.IO.Path.GetTempFileName();

            
        }

        public static bool IsDebugMode
        {
            get
            {
                return System.IO.Path.GetFileName(Application.StartupPath).ToLower() == "debug";
                
            }
        }

        public static bool IsValidFile(string filepath)
        {
            try
            {
                filepath = filepath.ToLower();
                FileInfo fi = new FileInfo(filepath);

                if (fi.Extension != String.Empty && Module.ImageFilter.IndexOf(fi.Extension) >= 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        public static bool IsFileListFile(string filepath)
        {
            try
            {
                filepath = filepath.ToLower();
                FileInfo fi = new FileInfo(filepath);

                if (fi.Extension != String.Empty && fi.Extension.ToLower()==".txt")
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }                       

        public static string GetRelativePath(string mainDirPath, string absoluteFilePath)
        {
            string[] firstPathParts = mainDirPath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
            string[] secondPathParts = absoluteFilePath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);

            int sameCounter = 0;
            for (int i = 0; i < Math.Min(firstPathParts.Length,
            secondPathParts.Length); i++)
            {
                if (
                !firstPathParts[i].ToLower().Equals(secondPathParts[i].ToLower()))
                {
                    break;
                }
                sameCounter++;
            }

            if (sameCounter == 0)
            {
                return absoluteFilePath;
            }

            string newPath = String.Empty;
            for (int i = sameCounter; i < firstPathParts.Length; i++)
            {
                if (i > sameCounter)
                {
                    newPath += Path.DirectorySeparatorChar;
                }
                newPath += "..";
            }
            if (newPath.Length == 0)
            {
                newPath = ".";
            }
            for (int i = sameCounter; i < secondPathParts.Length; i++)
            {
                newPath += Path.DirectorySeparatorChar;
                newPath += secondPathParts[i];
            }
            return newPath;
        }

        public static void ShowMessage(string msg)
        {
            if (msg == string.Empty) return;

            if (Module.IsCommandLine)
            {
                Console.WriteLine(TranslateHelper.Translate(msg));
            }
            else
            {
                MessageBox.Show(TranslateHelper.Translate(msg));
            }
        }

        public static void ShowCompletedSuccessfully()
        {
            ShowMessage(TranslateHelper.Translate("Operation completed successfuly !"));
        }
        public static DialogResult ShowQuestionDialog(string msg, string caption)
        {
            return MessageBox.Show(TranslateHelper.Translate(msg), TranslateHelper.Translate(caption), MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
        }


        public static void ShowError(Exception ex)
        {
            ShowError("Error", ex);
        }

        public static void ShowError(string msg)
        {
            if (Module.IsCommandLine)
            {
                Console.WriteLine("Error:" + msg);
            }
            else
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public static void ShowError(string msg, Exception ex)
        {
            ShowError(msg + "\n\n" + ex.Message);
        }

        public static void ShowError(string msg, string exstr)
        {
            ShowError(msg + "\n\n" + exstr);
        }

        /*
        public static Image ImageFromFile(string path)
        {
            if (!System.IO.File.Exists(path)) return null;

            var bytes = System.IO.File.ReadAllBytes(path);
            var ms = new System.IO.MemoryStream(bytes);
            Image img = null;

            try
            {
                img = Image.FromStream(ms);
                return img;
                /*
                using (var ms = new System.IO.MemoryStream(bytes))
                {
                    var img = Image.FromStream(ms);
                    return img;
                }*//*
            }
            catch
            {
                if (ms != null)
                {
                    ms.Dispose();
                    ms = null;
                }

                if (img != null)
                {
                    try
                    {
                        ((Image)img).Dispose();
                        img = null;
                    }
                    catch { }

                }

                bytes = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();

                return null;
            }

        }
        */

        public static DialogResult ShowQuestionDialogYesFocus(string msg, string caption)
        {
            return MessageBox.Show(TranslateHelper.Translate(msg), TranslateHelper.Translate(caption), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowQuestionDialogWithCancelYesFocus(string msg, string caption)
        {
            return MessageBox.Show(TranslateHelper.Translate(msg), TranslateHelper.Translate(caption), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowQuestionDialogWithCancel(string msg, string caption)
        {
            return MessageBox.Show(TranslateHelper.Translate(msg), TranslateHelper.Translate(caption), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }


        public static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {           
            
        }

        public static bool RunAdminAction(string args)
        {
            try
            {
                System.Diagnostics.Process pr = new System.Diagnostics.Process();
                pr.StartInfo.FileName = Application.StartupPath + "\\4dotsAdminActions.exe";
                pr.StartInfo.Arguments = args;
                pr.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                pr.Start();

                System.Threading.Thread.Sleep(300);

                while (!pr.HasExited)
                {
                    Application.DoEvents();
                }

                if (pr.ExitCode != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public static int _Modex64 = -1;

        public static bool Modex64
        {
            get
            {
                if (_Modex64 == -1)
                {
                    if (Marshal.SizeOf(typeof(IntPtr)) == 8)
                    {
                        _Modex64 = 1;
                        return true;
                    }
                    else
                    {
                        _Modex64 = 0;
                        return false;
                    }
                }
                else if (_Modex64 == 1)
                {
                    return true;
                }
                else if (_Modex64 == 0)
                {
                    return false;
                }
                return false;
            }
        }                            

        public static bool IsLegalFilename(string name)
        {
            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string DecimalToString(decimal dec)
        {
            return DecimalToString(dec, 1);
        }

        public static string DecimalToString(decimal dec,int decimal_places)
        {
            string format="#0";
            
            if (decimal_places>0)
            {
                format+=".";
            }

            for (int k=0;k<decimal_places;k++)
            {
                format+="0";
            }
            
             return dec.ToString(format,new System.Globalization.CultureInfo("en-US")).Replace(",", ".");
        }

        public static decimal StringToDecimal(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            int epos = str.LastIndexOf(".");

            if (epos < 0)
            {
                epos = str.LastIndexOf(",");
            }

            if (epos < 0)
            {
                bool ihask = false;

                string sintegral = str;

                if (sintegral.ToLower().IndexOf("k") >= 0)
                {
                    ihask = true;
                }

                int integral_part = int.Parse(sintegral.ToLower().Replace("k", ""));

                return (decimal)integral_part;
            }
            else
            {
                bool ihask = false;

                string sintegral = str.Substring(0,epos);

                if (str.ToLower().IndexOf("k") >= 0)
                {
                    ihask = true;
                }

                int integral_part = int.Parse(sintegral.ToLower().Replace("k",""));

                

                string sdecimal = str.Substring(epos + 1, str.Length - epos - 1).ToLower().Replace("k", "");
                
                int decimal_part=int.Parse(sdecimal);                                

                decimal d10 = 1;

                for (int k = 0; k < sdecimal.Length; k++)
                {
                    d10 = d10 * 10;
                }

                decimal ddecimal_part = (decimal)decimal_part;

                decimal ddec=ddecimal_part/d10;

                decimal dintegral_part = (decimal)integral_part;

                decimal d = dintegral_part + ddec;

                if (ihask)
                {
                    d = d * 1000;
                }
                

                return d;
            }
        }

        public static string EscapeLikeValue(string value)
        {
            StringBuilder sb = new StringBuilder(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                switch (c)
                {
                    case ']':
                    case '[':
                    case '%':
                    case '*':
                        sb.Append("[").Append(c).Append("]");
                        break;
                    case '\'':
                        sb.Append("''");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        public static bool DeleteApplicationSettingsFile()
        {
            try
            {
                string settingsFile = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;

                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Save();

                System.IO.FileInfo fi = new FileInfo(settingsFile);
                fi.Attributes = System.IO.FileAttributes.Normal;
                fi.Delete();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    public class GetTitleAndNumberOfPagesResult
    {
        public string Title = "";
        public int NumberOfPages = -1;
    }

    public class InitializedBackgroundWorker : System.ComponentModel.BackgroundWorker
    {
        public InitializedBackgroundWorker()
            : base()
        {
        }

        protected override void OnDoWork(System.ComponentModel.DoWorkEventArgs e)
        {
            frmMain.Instance.ActionStopped = false;

            base.OnDoWork(e);
        }
    }
}
