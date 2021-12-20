using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
/*
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
*/
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace ExifRemover
{
    public partial class frmMain : CustomForm
    {
        public bool ActionStopped = false;
        public bool ActionPaused = false;

        public static frmMain Instance = null;

        /*        
        private static frmMain _Instance = null;
        public static frmMain Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmMain();                    
                }

                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        */

        public DataTable dt = new DataTable("pdfs");

        public static string Err = "";

        public bool IsFromFolderWatcher = false;

        public frmMain()
        {
            InitializeComponent();            

            Instance=this;
            
            dt.Columns.Add("filename");
            dt.Columns.Add("sizekb");
            dt.Columns.Add("size",typeof(long));
            dt.Columns.Add("fullfilepath");
            dt.Columns.Add("filedate");
            dt.Columns.Add("rootfolder");
            dt.Columns.Add("sizepixels");

            dt.Columns.Add("compressedFilepath");
            dt.Columns.Add("uncompressedDirectory");
            
            Instance = this;

            dgFiles.AutoGenerateColumns = false;

            if (Module.IsCommandLine || Module.IsFromWindowsExplorer)
            {
                this.Visible = false;
                this.ShowInTaskbar = false;
            }                                                                
            else
            {
                if (Properties.Settings.Default.ShowPromotion)
                {
                    frmPromotion fp = new frmPromotion();
                    fp.Show(this);
                }
            }
        }                

        private void FixRightClickExtensions()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

            RegistryKey key2 = key.OpenSubKey("4dots Software", true);

            if (key2 == null)
            {
                key2 = key.CreateSubKey("4dots Software");
            }

            RegistryKey key3 = key2.OpenSubKey("Exif Remover", true);

            if (key3 == null)
            {
                key3 = key2.CreateSubKey("Exif Remover");
            }

            try
            {
                string extensions = key3.GetValue("File Extensions").ToString();
            }
            catch
            {
                key3.SetValue("File Extensions",
                    //"*.bmp|||*.ico|||*.jpg|||*.jif|||*.jpeg|||*.jpe|||*.jng|||*.koa|||*.iff|||*.lbm|||*.iff|||*.lbm|||*.mng|||*.pbm|||*.pbm|||*.pcd|||*.pcx|||*.pgm|||*.pgm|||*.png|||*.ppm|||*.ppm|||*.ras|||*.tga|||*.targa|||*.tif|||*.tiff|||*.wap|||*.wbmp|||*.wbm|||*.psd|||*.cut|||*.xbm|||*.xpm|||*.dds|||*.gif|||*.hdr|||*.g3|||*.sgi|||*.exr|||*.j2k|||*.j2c|||*.jp2|||*.pfm|||*.pct|||*.pict|||*.pic|||*.3fr|||*.arw|||*.bay|||*.bmq|||*.cap|||*.cine|||*.cr2|||*.crw|||*.cs1|||*.dc2|||*.dcr|||*.drf|||*.dsc|||*.dng|||*.erf|||*.fff|||*.ia|||*.iiq|||*.k25|||*.kc2|||*.kdc|||*.mdc|||*.mef|||*.mos|||*.mrw|||*.nef|||*.nrw|||*.orf|||*.pef|||*.ptx|||*.pxn|||*.qtk|||*.raf|||*.raw|||*.rdc|||*.rw2|||*.rwl|||*.rwz|||*.sr2|||*.srf|||*.sti|||");
                    "*.png|||*.jpg|||*.jpeg|||*.gif|||*.bmp|||*.tiff|||");
            }

            key3.Close();
            key2.Close();
            key.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //iTextSharp.text.Document doc = new iTextSharp.text.Document();
            /*
            PdfReader reader = new PdfReader(@"c:\4\head first ajax.pdf");

            Document doc = new Document(reader.GetPageSizeWithRotation(1));

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"c:\4\test.pdf",FileMode.Create));
            doc.Open();
            PdfContentByte cb = writer.DirectContent;
            */
            /*
            for (int k = 1; k <= reader.NumberOfPages; k++)
            {
                doc.SetPageSize(reader.GetPageSizeWithRotation(i));
                PdfDictionary pdfdict=pdfReader.GetPageN(k);
                PdfImportedPage imp=pdfWriter.GetImportedPage(pdfReader, k);
                pdfWriter.Add(imp);

            }
            */
        }

        private void AddVisual(string[] argsvisual)
        {
            
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //Module.ShowMessage("Is From Windows Explorer");                                

                for (int k = 0; k < argsvisual.Length; k++)
                {
                    if (System.IO.File.Exists(argsvisual[k]))
                    {
                        AddFile(argsvisual[k]);
                        RecentFilesHelper.AddRecentFile(argsvisual[k]);
                    }
                    else if (System.IO.Directory.Exists(argsvisual[k]))
                    {
                        AddFolder(argsvisual[k]);
                        RecentFilesHelper.AddRecentFolder(argsvisual[k]);
                    }
                }
            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void SetupOutputFolders()
        {
            cmbOutputDir.Items.Clear();
            cmbOutputDir.Items.Add(TranslateHelper.Translate("Same Folder of Image"));
            cmbOutputDir.Items.Add(TranslateHelper.Translate("Overwrite Images"));
            cmbOutputDir.Items.Add(TranslateHelper.Translate("Subfolder of Image"));
            cmbOutputDir.Items.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString());
            cmbOutputDir.Items.Add("---------------------------------------------------------------------------------------");

            OutputFolderHelper.LoadOutputFolders();
            cmbOutputDir.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;

            if (cmbOutputDir.SelectedIndex == -1) cmbOutputDir.SelectedIndex = 0;

            cmbOutputDir.Text = cmbOutputDir.SelectedItem.ToString();

        }

        public void SetupOnLoad()
        {            
            dgFiles.DataSource = dt;
            dgFiles.AutoGenerateColumns = false;

            //1this.Icon = Properties.Resources.pdf_password_remover;

            this.Text = Module.ApplicationTitle;
            //this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            //this.Left = 0;            

            AddLanguageMenuItems();

            //DownloadSuggestionsHelper ds = new DownloadSuggestionsHelper();
            //ds.SetupDownloadMenuItems(downloadToolStripMenuItem);            

            AdjustSizeLocation();

            //Module.ShowMessage("6");

            SetupOutputFolders();

            //Module.ShowMessage("7");
            /*
             * 
            chkKeepBackup.Checked = Properties.Settings.Default.KeepBackup;

            if (cmbOutputDir.SelectedIndex == 1)
            {
                chkKeepBackup.Visible = true;
            }
            else
            {
                chkKeepBackup.Visible = false;
            }
            */

            if (!ArgsHelper.IsFromCommandLine)
            {
                RecentFilesHelper.FillMenuRecentFile();
                RecentFilesHelper.FillMenuRecentFolder();
                RecentFilesHelper.FillMenuRecentImportList();
            }

            //this.Width = 700;
            //this.Height = 500;

            //3ShowGridColumns();
            //3SetGridColumnOrderWidths();                                                                                                                   

            //Module.ShowMessage("8");

            /*
            //3
            buyToolStripMenuItem.Visible = frmPurchase.RenMove;

            if (Properties.Settings.Default.Price != string.Empty && !buyApplicationToolStripMenuItem.Text.EndsWith(Properties.Settings.Default.Price))
            {
                buyApplicationToolStripMenuItem.Text = buyApplicationToolStripMenuItem.Text + " " + Properties.Settings.Default.Price;
            }
            */

            exploreOutputFolderWhenFinishedToolStripMenuItem.Checked=Properties.Settings.Default.ExploreOutputFolderWhenFinished;

            showOperationCompletedMeesageToolStripMenuItem.Checked = Properties.Settings.Default.ShowOperationCompletedMessage;

            txtFilenamePattern.Text = Properties.Settings.Default.OFilenamePattern;

            if (Properties.Settings.Default.OThreads == -1)
            {
                Properties.Settings.Default.OThreads = Environment.ProcessorCount;
            }

            nudThreads.Value = Properties.Settings.Default.OThreads;

            chkKeepCreationDate.Checked = Properties.Settings.Default.OKeepCreationDate;
            chkKeepFolderStructure.Checked = Properties.Settings.Default.OKeepFolderStrcture;
            chkKeepLastModDate.Checked = Properties.Settings.Default.OKeepLastModDate;

            checkForNewVersionEachWeekToolStripMenuItem.Checked =
                Properties.Settings.Default.CheckWeek;
        }                
        
        private void AdjustSizeLocation()
        {
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {

                if (Properties.Settings.Default.Width ==0)
                {
                    this.CenterToScreen();
                    return;
                }
                else
                {
                    this.Width = Properties.Settings.Default.Width;
                }
                if (Properties.Settings.Default.Height != 0)
                {
                    this.Height = Properties.Settings.Default.Height;
                }

                if (Properties.Settings.Default.Left != -1)
                {
                    this.Left = Properties.Settings.Default.Left;
                }

                if (Properties.Settings.Default.Top != -1)
                {
                    this.Top = Properties.Settings.Default.Top;
                }

                if (this.Width < 300)
                {
                    this.Width = 300;
                }

                if (this.Height < 300)
                {
                    this.Height = 300;
                }

                if (this.Left < 0)
                {
                    this.Left = 0;
                }

                if (this.Top < 0)
                {
                    this.Top = 0;
                }

                if (this.Bottom > System.Windows.Forms.Screen.GetWorkingArea(this).Height)
                {
                    this.Top = System.Windows.Forms.Screen.GetWorkingArea(this).Height - this.Height;
                }

                if (this.Right > System.Windows.Forms.Screen.GetWorkingArea(this).Width)
                {
                    this.Left = System.Windows.Forms.Screen.GetWorkingArea(this).Width - this.Width;
                }
            }

        }

        private void SaveSizeLocation()
        {
            Properties.Settings.Default.Maximized = (this.WindowState == FormWindowState.Maximized);
            Properties.Settings.Default.Left = this.Left;
            Properties.Settings.Default.Top = this.Top;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;

            if (!Module.IsCommandLine)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void EnableDisableForm(bool enable)
        {
            foreach (Control co in this.Controls)
            {
                co.Enabled = enable;
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            SetupOnLoad();

            if (ArgsHelper.IsFromWindowsExplorer)
            {
                //AddVisual(Module.args);
            }

            if (Properties.Settings.Default.CheckWeek)
            {
                UpdateHelper.InitializeCheckVersionWeek();
            }

            bool showopen = false;

            if (ArgsHelper.IsFromWindowsExplorer)
            {

            }

            if (ArgsHelper.SelectedFiles != null)
            {
                for (int m = 0; m < ArgsHelper.SelectedFiles.Length; m++)
                {
                    if (System.IO.File.Exists(ArgsHelper.SelectedFiles[m]))
                    {
                        //3frmMain.Instance.AddFile(ArgsHelper.SelectedFiles[m]);

                        AddFile(ArgsHelper.SelectedFiles[m]);
                    }
                    else if (System.IO.Directory.Exists(ArgsHelper.SelectedFiles[m]))
                    {
                        //3frmMain.Instance.AddFolder(ArgsHelper.SelectedFiles[m]);

                        AddFolder(ArgsHelper.SelectedFiles[m]);
                    }
                }

                if (!showopen && ArgsHelper.SelectedFiles.Length > 0)
                {
                    //3frmMain.Instance.tsbResizeImages_Click(null, null);

                    tsbRemoveExif_Click(null, null);

                    Environment.Exit(0);
                }
            }
        }

        #region Localization

        /*
        void tiLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            string langcode = ti.Tag.ToString();
            ChangeLanguage(langcode);

            for (int k = 0; k < languageToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languageToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }
        }
        */
        private void ChangeLanguage(string language_code)
        {
            Properties.Settings.Default.Language = language_code;
            frmLanguage.SetLanguage();

            //1SaveSizeLocation();

            Module.ShowMessage("Please restart the application");

            System.Diagnostics.Process.Start(Application.ExecutablePath);

            Application.Exit();

            /*
            bool maximized = (this.WindowState == FormWindowState.Maximized);
            this.WindowState = FormWindowState.Normal;                       

            SaveSizeLocation();

            this.Controls.Clear();

            InitializeComponent();

            SetupOnLoad();

            if (maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            this.ResumeLayout(true);                    
            */         
            /*
            bool t1e = timer1.Enabled;
            bool t2e = timer2.Enabled;
            bool t3e = timer3.Enabled;
            */            

            /*
            timer1.Enabled = t1e;
            timer2.Enabled = t2e;
            timer3.Enabled = t3e;
            */           
        }

        #endregion
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Module.ImageFilter;
            openFileDialog1.Multiselect = true;
            
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    for (int k = 0; k < openFileDialog1.FileNames.Length; k++)
                    {                        
                        AddFile(openFileDialog1.FileNames[k]);
                        RecentFilesHelper.AddRecentFile(openFileDialog1.FileNames[k]);
                    }

                    UpdateTotal();
                }
                finally
                {
                    this.Cursor = null;
                }
            }
        }

        public bool AddFile(string filepath)
        {
            return AddFile(filepath, "");
        }

        public bool AddFile(string filepath, string password)
        {
            return AddFile(filepath, password,"","","");
        }

        public bool AddFile(string filepath,string password,string compressedFilepath,string uncompressedDirectory,string rootfolder)            
        {            
            if (Properties.Settings.Default.CompressedArchives && CustomArchive.IsArchive(filepath))
            {
                try
                {

                    CustomArchive ca = new CustomArchive(filepath, "");
                    CustomExtractedFilesInfo cinfo = ca.DecompressArchive();

                    for (int k = 0; k < cinfo.UncompressedFiles.Count; k++)
                    {
                        AddFile(cinfo.UncompressedFiles[k], "", cinfo.CompressedFilepath, cinfo.UncompressedDirectory,rootfolder);
                    }

                    return true;
                }
                catch
                {

                }
            }

            DataRow dr = dt.NewRow();
                        
            FileInfo fi=new FileInfo(filepath);

            long sizekb=fi.Length/1024;
            dr["filename"]=fi.Name;
            dr["fullfilepath"] = filepath;
            dr["sizekb"] = sizekb.ToString() + "KB";
            dr["filedate"] = fi.LastWriteTime.ToString();
            dr["size"] = fi.Length / 1024;

            dr["compressedFilepath"] = compressedFilepath;
            dr["uncompressedDirectory"] = uncompressedDirectory;
            dr["rootfolder"] = rootfolder;
            /*
            try
            {
                Image img = Module.ImageFromFile(filepath);

                dr["sizepixels"] = img.Width.ToString() + "x" + img.Height.ToString();
            }
            catch { }
            */

            dt.Rows.Add(dr);

            return true;
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DialogResult dres = Module.ShowQuestionDialogYesFocus(TranslateHelper.Translate("Would you like to also add Images from Subdirectories ?"), TranslateHelper.Translate("Add Images from Subdirectories ?"));

                    this.Cursor = Cursors.WaitCursor;

                    this.Cursor = Cursors.WaitCursor;

                    if (dres == DialogResult.Yes)
                    {                        
                        AddFolder(folderBrowserDialog1.SelectedPath,true);
                    }
                    else
                    {
                        AddFolder(folderBrowserDialog1.SelectedPath, false);
                    }
                    RecentFilesHelper.AddRecentFolder(folderBrowserDialog1.SelectedPath);
                }
                finally
                {
                    this.Cursor = null;
                }
            }

            UpdateTotal();
        }

        public void AddFolder(string folder_path)
        {
            AddFolder(folder_path,false);
        }

        //public void AddFolder(string folder_path,string password,int currentDepth)
        public void AddFolder(string folder_path, bool subdirs)
        {
            Module.CmdAddSubdirectories = subdirs;

            string[] filez = null;

            if (Module.IsCommandLine)
            {
                if (Module.CmdAddSubdirectories)
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.AllDirectories);
                }
                else
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.TopDirectoryOnly);
                }
            }
            else
            {
                if (System.IO.Directory.GetDirectories(folder_path).Length > 0)
                {
                    if (subdirs)
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.AllDirectories);
                    }
                    else
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.TopDirectoryOnly);
                    }

                    /*
                    DialogResult dres = Module.ShowQuestionDialog("Would you like to add also Subdirectories ?", TranslateHelper.Translate("Add Subdirectories ?"));

                    if (dres == DialogResult.Yes)
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.AllDirectories);
                    }
                    else
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.TopDirectoryOnly);
                    }*/
                }
                else
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.TopDirectoryOnly);
                }
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                for (int k = 0; k < filez.Length; k++)
                {
                    //if (!Properties.Settings.Default.ImageFilterFolder || (Properties.Settings.Default.ImageFilterFolder && frmInputFilesFilter.IsValidInputFilepath(filez[k])))
                    //{
                        AddFile(filez[k], "", "", "", folder_path);
                    //}
                }
            }
            finally
            {
                this.Cursor = null;
            }
        }                

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection cells = dgFiles.SelectedCells;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            for (int k = 0; k < cells.Count; k++)
            {
                if (rows.IndexOf(dgFiles.Rows[cells[k].RowIndex]) < 0)
                {
                    rows.Add(dgFiles.Rows[cells[k].RowIndex]);
                }
            }

            for (int k = 0; k < rows.Count; k++)
            {
                dgFiles.Rows.Remove(rows[k]);
            }

            UpdateTotal();

            if (dgFiles.Rows.Count == 0)
            {
                if (picPreview.Image != null)
                {
                    picPreview.Image.Dispose();
                    picPreview.Image = null;
                }
            }
            else
            {
                ShowPreview(dgFiles.CurrentRow.Index);
            }

        }

        private void tiHelpFeedback_Click(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow == null) return;

            System.Diagnostics.Process.Start(dgFiles.CurrentRow.Cells["colFullFilepath"].Value.ToString());


        }               

        private bool IsDragging = false;

        /*
        private void lvDocs_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void lvDocs_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop,false))
            {
                IsDragging = true;
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void lvDocs_DragDrop(object sender, DragEventArgs e)
        {           

            Point pt = lvDocs.PointToClient(Cursor.Position);
            ListViewHitTestInfo hiti = lvDocs.HitTest(pt.X, pt.Y);

            //if (hiti.Item != null)
            //{

            int ind = -1;
            if (hiti.Item != null)
            {
                ind = hiti.Item.Index;
            }

            List<ListViewItem> lst = new List<ListViewItem>();

            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    bool isimage = false;                                        

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        AddFile(filez[k]);
                    }
                    finally
                    {
                        this.Cursor = null;
                    }

                    lst.Add(lvDocs.Items[lvDocs.Items.Count - 1]);
                }

                if (hiti.Item != null && (lvDocs.Items.Count != lst.Count))
                {
                    for (int k = 0; k < lst.Count; k++)
                    {
                        lvDocs.Items.Remove(lst[k]);
                    }

                    for (int k = 0; k < lst.Count; k++)
                    {
                        lvDocs.Items.Insert(ind + k, lst[k]);
                    }
                }
            }


            //}

        }
        */                                                             
                
                
        protected override void WndProc(ref Message m)
        {
            /*
            if (m.Msg == Program.WM_MULTIPLE_SEARCH_REPLACE)
            {
                MessageBox.Show(m.GetLParam(typeof(string)).ToString());
                lstIncludePaths.Items.Add(m.GetLParam(typeof(string)));
            }
            base.WndProc(ref m);
            */

            if (m.Msg == MessageHelper.WM_COPYDATA)
            {
                MessageHelper.COPYDATASTRUCT mystr = new MessageHelper.COPYDATASTRUCT();
                Type mytype = mystr.GetType();
                mystr = (MessageHelper.COPYDATASTRUCT)m.GetLParam(mytype);
                //MessageBox.Show(mystr.lpData);

                string arg = mystr.lpData;

                //MessageBox.Show("RECEIVED MESSAGE :" + arg);
                string[] args = arg.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

                //frmClientImages.Instance.ShowSendToMenuForm(args);
                for (int n = 1; n <= args.GetUpperBound(0); n++)
                {
                    //MessageBox.Show(args[n]);
                }

                AddVisual(args);


            }
            else if (m.Msg == MessageHelper.WM_ACTIVATEAPP)
            {
                this.WindowState = FormWindowState.Normal;
                this.Show();
            }



            base.WndProc(ref m);
        }

        private void helpGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.HelpURL);
        }

        private void btnClearMerge_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();

            UpdateTotal();
            
        }

        private string OutputDir = "";
        private bool OverwritePDF = false;
        private bool KeepBackup = false;

        public static List<BackgroundWorker> lstbw = new List<BackgroundWorker>();                

        public bool Working = false;

        public void tsbRemoveExif_Click(object sender, EventArgs e)
        {
            try
            {
                frmMain.Instance.Working = true;

                dgFiles.EndEdit();                

                ActionStopped = false;
                ActionPaused = false;
                Err = "";
                Properties.Settings.Default.OutputFolderText = cmbOutputDir.Text;

                lstbw.Clear();

                //this.Enabled = false;
                EnableDisableForm(false);
                
                frmProgress fprog = new frmProgress(dt.Rows.Count);
                fprog.Show(this);

                int othreads = Properties.Settings.Default.OThreads;                

                if (Module.IsCommandLine)
                {
                    Properties.Settings.Default.OThreads = 1;
                }

                for (int k = 0; k < Properties.Settings.Default.OThreads; k++)
                {
                    Application.DoEvents();

                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += bw_DoWork;
                    bw.WorkerReportsProgress = true;
                    bw.WorkerSupportsCancellation = true;
                    bw.ProgressChanged += bw_ProgressChanged;

                    lstbw.Add(bw);
                }

                Properties.Settings.Default.OThreads = othreads;

                int kk = 0;

                do
                {
                    while (ActionPaused)
                    {
                        Application.DoEvents();
                    }

                    if (ActionStopped)
                    {
                        break;
                    }

                    int m = 0;

                    while (true)
                    {
                        Application.DoEvents();

                        if (!lstbw[m].IsBusy)
                        {
                            lstbw[m].RunWorkerAsync(dt.Rows[kk]);

                            kk++;

                            break;
                        }
                        else
                        {
                            m++;

                            if (m == lstbw.Count)
                            {
                                m = 0;
                            }
                        }

                        Application.DoEvents();
                    }

                    Application.DoEvents();

                } while (kk < dt.Rows.Count);

                bool running = false;

                do
                {
                    Application.DoEvents();

                    for (int j = 0; j < lstbw.Count; j++)
                    {
                        Application.DoEvents();

                        if (lstbw[j].IsBusy)
                        {
                            running = true;

                            break;
                        }
                        else
                        {
                            if (j == lstbw.Count - 1)
                            {
                                running = false;
                                break;
                            }
                        }
                    }

                    Application.DoEvents();
                } while (running);

                fprog.Close();

                /*
                bwResizeImages.RunWorkerAsync();

                while (bwResizeImages.IsBusy)
                {
                    Application.DoEvents();
                }
                */                

                if (ActionStopped)
                {
                    this.Cursor = null;

                    //this.Enabled = true;

                    EnableDisableForm(true);
                    
                    Module.ShowMessage("Operation Cancelled !");
                    
                    return;
                }
                else
                {                    
                    this.Cursor = null;

                    //this.Enabled = true;

                    EnableDisableForm(true);

                    if (Err == String.Empty)
                    {
                        if (!(Module.IsFromWindowsExplorer && !this.Visible) && Properties.Settings.Default.ShowOperationCompletedMessage)
                        {
                            Module.ShowMessage("Operation completed successfully !");
                            //btnOpenFolder_Click(null, null);
                        }
                    }
                    else
                    {
                        frmMessage f = new frmMessage();
                        f.lblMsg.Text = TranslateHelper.Translate("Operation completed with Errors !");
                        f.txtMsg.Text = Err;

                        f.ShowDialog();
                    }

                    if (Properties.Settings.Default.ExploreOutputFolderWhenFinished
                        && !Module.IsCommandLine && !Module.IsFromWindowsExplorer)
                    {
                        btnOpenFolder_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error", ex);
            }
            finally
            {
                this.Cursor = null;

                //this.Enabled = true;

                EnableDisableForm(true);

                frmMain.Instance.Working = false;
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (IsFromFolderWatcher)
            {
                // if automatic profile or same folder of image add _fw
                                
                if (Properties.Settings.Default.OutputFolderText == TranslateHelper.Translate("Same Folder of Image"))
                {
                    if (!Properties.Settings.Default.OFilenamePattern.EndsWith("_fw"))
                    {
                        Properties.Settings.Default.OFilenamePattern += "_fw";
                    }
                }
            }

            DataRow dr = (DataRow)e.Argument;

            string filepath = dr["fullfilepath"].ToString();

            FilenameHelper fnl = new FilenameHelper();

            string outputfp = fnl.CalculateOutputFilepath(filepath, Properties.Settings.Default.OutputFolderText, dr["rootfolder"].ToString());            

            EXIFCopier.ClearEXIF(filepath, outputfp);

            BackgroundWorker bw = (BackgroundWorker)sender;

            bw.ReportProgress(0);
        }

        private delegate void delIncreaseProgress();

        private void IncreaseProgress()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((delIncreaseProgress)IncreaseProgress, null);
            }
            else
            {
                if (frmProgress.Instance == null) return;

                if (frmProgress.Instance.progressBar1.Value < frmProgress.Instance.progressBar1.Maximum)
                {
                    frmProgress.Instance.progressBar1.Value = frmProgress.Instance.progressBar1.Value + 1;

                    frmProgress.Instance.lblImageNumber.Text = frmProgress.Instance.progressBar1.Value.ToString() + " / " +
                        frmProgress.Instance.progressBar1.Maximum.ToString();

                }
            }

        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                IncreaseProgress();

                /*
                if (frmProgress.Instance == null) return;

                if (frmProgress.Instance.progressBar1.Value < frmProgress.Instance.progressBar1.Maximum)
                {
                    frmProgress.Instance.progressBar1.Value = frmProgress.Instance.progressBar1.Value + 1;

                    frmProgress.Instance.lblImageNumber.Text = frmProgress.Instance.progressBar1.Value.ToString() + " / " +
                        frmProgress.Instance.progressBar1.Maximum.ToString();

                }*/
            }            
        }                              

        private void frmMain_Resize(object sender, EventArgs e)
        {
            /*
            int bsize = btnEncrypt.Width + 20 + btnExit.Width;
            btnEncrypt.Left = (this.ClientRectangle.Width / 2) - (bsize / 2);
            btnExit.Left = btnEncrypt.Right + 20;
            */
            
        }

        private void dgFiles_DragDrop(object sender, DragEventArgs e)
        {            
            int add_subdirs = -1;

            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    if (System.IO.File.Exists(filez[k]))
                    {
                        if (Module.IsFileListFile(filez[k]))
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;

                                SilentAddErr = "";

                                ImportList(filez[k]);
                                RecentFilesHelper.ImportListRecent(filez[k]);

                                if (SilentAddErr != string.Empty)
                                {
                                    frmMessage f = new frmMessage();
                                    f.txtMsg.Text = SilentAddErr;
                                    f.ShowDialog();
                                }
                            }
                            finally
                            {
                                this.Cursor = null;
                            }

                        }
                        else
                        {
                            bool isimage = false;

                            try
                            {
                                this.Cursor = Cursors.WaitCursor;

                                AddFile(filez[k]);
                                RecentFilesHelper.AddRecentFile(filez[k]);
                            }
                            finally
                            {
                                this.Cursor = null;
                            }
                        }
                    }
                    else if (System.IO.Directory.Exists(filez[k]))
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;

                            if (add_subdirs == -1)
                            {
                                DialogResult dres = Module.ShowQuestionDialogYesFocus(TranslateHelper.Translate("Would you like to also add Images from Subdirectories ?"), TranslateHelper.Translate("Add Images from Subdirectories ?"));

                                add_subdirs = dres == DialogResult.Yes ? 1 : 0;
                            }

                            AddFolder(filez[k], add_subdirs==1);

                            RecentFilesHelper.AddRecentFolder(filez[k]);
                        }
                        finally
                        {
                            this.Cursor = null;
                        }
                    }
                }
            }

            UpdateTotal();
        }

        private void dgFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                IsDragging = true;
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void dgFiles_DragOver(object sender, DragEventArgs e)
        {
            IsDragging = true;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }                

        private void visit4dotsSoftwareWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com");
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            dgFiles.EndEdit();

            string outfilepath = "";
            string filepath = "";

            if (dgFiles.Rows.Count > 0)
            {
                if (dgFiles.SelectedCells.Count == 0)
                {
                    filepath = dgFiles.Rows[0].Cells["colFullfilepath"].Value.ToString();
                }
                else
                {
                    filepath = dgFiles.SelectedCells[0].OwningRow.Cells["colFullfilepath"].Value.ToString();
                }
            }

            if (!(frmMain.Instance.cmbOutputDir.Text.Trim() == TranslateHelper.Translate("Same Folder of Image")
                || frmMain.Instance.cmbOutputDir.Text.ToString().StartsWith(TranslateHelper.Translate("Subfolder") + " : ")
                || frmMain.Instance.cmbOutputDir.Text.Trim() == TranslateHelper.Translate("Overwrite Image")))
            {
                outfilepath = System.IO.Path.Combine(frmMain.Instance.cmbOutputDir.Text, System.IO.Path.GetFileName(filepath));
            }
            else
            {
                if (dt.Rows.Count == 0)
                {
                    Module.ShowMessage("Please add a PDF File first !");
                    return;
                }
                else
                {
                    string dirpath = "";

                    if (frmMain.Instance.cmbOutputDir.Text.Trim() == TranslateHelper.Translate("Same Folder of Image"))
                    {
                        dirpath = System.IO.Path.GetDirectoryName(filepath);
                        outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_unprotected.pdf");
                    }
                    else if (frmMain.Instance.cmbOutputDir.Text.ToString().StartsWith(TranslateHelper.Translate("Subfolder") + " : "))
                    {
                        int subfolderspos = (TranslateHelper.Translate("Subfolder") + " : ").Length;
                        string subfolder = frmMain.Instance.cmbOutputDir.Text.ToString().Substring(subfolderspos);

                        outfilepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath) + "\\" + subfolder, System.IO.Path.GetFileName(filepath));
                    }
                    else if (frmMain.Instance.cmbOutputDir.Text.Trim() == TranslateHelper.Translate("Overwrite Images"))
                    {
                        outfilepath = filepath;
                    }
                }
            }

            if (!(System.IO.File.Exists(outfilepath) || System.IO.Directory.Exists(outfilepath)))
            {
                outfilepath=System.IO.Path.GetDirectoryName(outfilepath);

            }
            
            string args = "";

            if (System.IO.File.Exists(outfilepath))
            {
                args = string.Format("/e, /select, \"{0}\"", outfilepath);
            }
            else
            {
                args = string.Format("\"{0}\"", outfilepath);
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                OutputFolderHelper.SaveOutputFolder(folderBrowserDialog2.SelectedPath);
            }
        }              

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            SaveSizeLocation();
            
            Properties.Settings.Default.OutputFolderIndex = cmbOutputDir.SelectedIndex;
            //Properties.Settings.Default.KeepBackup = chkKeepBackup.Checked;

            Properties.Settings.Default.OFilenamePattern = txtFilenamePattern.Text;

            Properties.Settings.Default.OKeepCreationDate = chkKeepCreationDate.Checked;
            Properties.Settings.Default.OKeepFolderStrcture = chkKeepFolderStructure.Checked;
            Properties.Settings.Default.OKeepLastModDate = chkKeepLastModDate.Checked;

            Properties.Settings.Default.OThreads = (int)nudThreads.Value;

            Properties.Settings.Default.CheckWeek = checkForNewVersionEachWeekToolStripMenuItem.Checked;
                
            if (!Module.IsCommandLine)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void cmbOutputDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            //chkKeepBackup.Visible = false;

            if (cmbOutputDir.SelectedIndex == 4)
            {
                Module.ShowMessage("Please specify another option as the Output Folder !");
                cmbOutputDir.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;
            }
            else if (cmbOutputDir.SelectedIndex == 2)
            {
                frmOutputSubFolder fob = new frmOutputSubFolder();

                if (fob.ShowDialog() == DialogResult.OK)
                {
                    OutputFolderHelper.SaveOutputFolder(TranslateHelper.Translate("Subfolder") + " : " + fob.txtSubfolder.Text);
                }
                else
                {
                    return;
                }
            }
            else if (cmbOutputDir.SelectedIndex == 1)
            {
                //chkKeepBackup.Visible = true;
            }
        }

        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow == null) return;

            string filepath = dgFiles.CurrentRow.Cells["colFullFilepath"].Value.ToString();

            string args = string.Format("/e, /select, \"{0}\"", filepath);
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);

        }              

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Point p = dgFiles.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
            DataGridView.HitTestInfo hit = dgFiles.HitTest(p.X, p.Y);

            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                bool current_row_is_selected = false;

                for (int k = 0; k < dgFiles.SelectedRows.Count; k++)
                {
                    if (dgFiles.SelectedRows[k].Index == hit.RowIndex)
                    {
                        current_row_is_selected = true;
                        break;
                    }
                }

                if (!current_row_is_selected)
                {
                    dgFiles.CurrentCell = dgFiles.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                }
            }

            if (dgFiles.CurrentRow == null)
            {
                e.Cancel = true;
            }
        }

        private void followUsOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.twitter.com/4dotsSoftware");
        }

        private bool SilentAdd = false;
        public string SilentAddErr = "";

        public void ImportList(string listfilepath)
        {
            int add_subdirs = -1;

            //if (Module.is(listfilepath))
            /*if (false)
            {
                ImportListExcel(listfilepath);
                return;
            }*/

            string curdir = Environment.CurrentDirectory;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                SilentAdd = true;
                using (StreamReader sr = new StreamReader(listfilepath))
                {
                    string line = null;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("#"))
                        {
                            continue;
                        }

                        string filepath = line;
                        string password = "";

                        try
                        {
                            if (line.StartsWith("\""))
                            {
                                int epos = line.IndexOf("\"", 1);

                                if (epos > 0)
                                {
                                    filepath = line.Substring(1, epos - 1);
                                }
                            }
                            else if (line.StartsWith("'"))
                            {
                                int epos = line.IndexOf("'", 1);

                                if (epos > 0)
                                {
                                    filepath = line.Substring(1, epos - 1);
                                }
                            }
                            else if (listfilepath.ToLower().EndsWith(".csv"))
                            {
                                int compos = line.IndexOf(",");

                                if (compos > 0)
                                {
                                    password = line.Substring(compos + 1);

                                    if (!line.StartsWith("\"") && !line.StartsWith("'"))
                                    {
                                        filepath = line.Substring(0, compos);
                                    }

                                    if ((password.StartsWith("\"") && password.EndsWith("\""))
                                        || (password.StartsWith("'") && password.EndsWith("'")))
                                    {
                                        if (password.Length == 2)
                                        {
                                            password = "";
                                        }
                                        else
                                        {
                                            password = password.Substring(1, password.Length - 2);
                                        }
                                    }

                                }
                            }
                            else
                            {
                                filepath = line;
                            }
                        }
                        catch (Exception exq)
                        {
                            SilentAddErr += TranslateHelper.Translate("Error while processing List !") + " " + line + " " + exq.Message + "\r\n";
                        }

                        line = filepath;

                        Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(listfilepath);
                        
                        line = System.IO.Path.GetFullPath(line);                        

                        if (System.IO.File.Exists(line))
                        {
                            AddFile(line, password);
                            /*
                            if (System.IO.Path.GetExtension(line).ToLower() == ".pdf")
                            {
                                
                            }
                            else
                            {
                                SilentAddErr += TranslateHelper.Translate("Error wrong file type !") + " " + line + "\r\n";
                            }*/
                        }
                        else if (System.IO.Directory.Exists(line))
                        {
                            if (add_subdirs == -1)
                            {
                                DialogResult dres = Module.ShowQuestionDialogYesFocus(TranslateHelper.Translate("Would you like to also add Images from Subdirectories ?"), TranslateHelper.Translate("Add Images from Subdirectories ?"));

                                add_subdirs = dres == DialogResult.Yes ? 1 : 0;
                            }

                            AddFolder(line, add_subdirs == 1);

                            //AddFolder(line, password,0);
                        }
                        else
                        {
                            SilentAddErr += TranslateHelper.Translate("Error. File or Directory not found !") + " " + line + "\r\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SilentAddErr += TranslateHelper.Translate("Error could not read file !") + " " + ex.Message + "\r\n";
            }
            finally
            {
                SilentAdd = false;

                Environment.CurrentDirectory = curdir;

                this.Cursor = null;
            }
        }        

        private static string GetPart(string part)
        {
            if (part.StartsWith("\""))
            {
                int epos = part.IndexOf("\"", 1);

                if (epos > 0)
                {
                    part = part.Substring(1, epos - 1);
                }
            }
            else if (part.StartsWith("'"))
            {
                int epos = part.IndexOf("'", 1);

                if (epos > 0)
                {
                    part = part.Substring(1, epos - 1);
                }
            }

            return part;
        }

        private void tsdbImportList_Click(object sender, EventArgs e)
        {
            SilentAddErr = "";

            //openFileDialog1.Filter = "File List Files (*.txt;*.csv;*.xls;*.xlt;*.xlsx)|*.txt;*.csv;*.xls;*.xlt;*.xlsx|Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|Excel Files (*.xls;*.xlt;*.xlsx)|*.xls;*.xlt;*.xlsx|All Files (*.*)|*.*";

            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    ImportList(openFileDialog1.FileName);
                    RecentFilesHelper.ImportListRecent(openFileDialog1.FileName);

                }
                finally
                {
                    this.Cursor = null;
                }

                if (SilentAddErr != string.Empty)
                {
                    frmMessage f = new frmMessage();
                    f.txtMsg.Text = SilentAddErr;
                    f.ShowDialog();

                }
            }

            UpdateTotal();
        }

        private void tsdbAddFile_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                AddFile(e.ClickedItem.Text);
                RecentFilesHelper.AddRecentFile(e.ClickedItem.Text);

                UpdateTotal();
                
            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void tsdbAddFolder_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int add_subdirs = -1;

            if (add_subdirs == -1)
            {
                DialogResult dres = Module.ShowQuestionDialogYesFocus(TranslateHelper.Translate("Would you like to also add Images from Subdirectories ?"), TranslateHelper.Translate("Add Images from Subdirectories ?"));

                add_subdirs = dres == DialogResult.Yes ? 1 : 0;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                AddFolder(e.ClickedItem.Text, add_subdirs == 1);

                RecentFilesHelper.AddRecentFolder(e.ClickedItem.Text);
                UpdateTotal();
            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void tsdbImportList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SilentAddErr = "";

            ImportList(e.ClickedItem.Text);
            RecentFilesHelper.ImportListRecent(e.ClickedItem.Text);

            if (SilentAddErr != string.Empty)
            {
                frmMessage f = new frmMessage();
                f.txtMsg.Text = SilentAddErr;
                f.ShowDialog();
            
            }

            UpdateTotal();
        }

        private void tsiFacebook_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareFacebook();
        }

        private void tsiTwitter_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareTwitter();
        }

        private void tsiGooglePlus_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareGooglePlus();
        }

        private void tsiLinkedIn_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareLinkedIn();
        }

        private void tsiEmail_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareEmail();
        }

        private void bwRemovePasswords_DoWork(object sender, DoWorkEventArgs e)
        {
            //1RemovePasswordsHelper.ErrMultiple = RemovePasswordsHelper.RemovePasswordsMultiplePDF(dt,OutputDir,OverwritePDF,KeepBackup);
        }

        private void bwRemovePasswords_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (frmProgress.Instance.progressBar1.Value < frmProgress.Instance.progressBar1.Maximum)
            {
                frmProgress.Instance.progressBar1.Value++;
            }

        }

        private void bwRemovePasswords_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                dgFiles.SelectAll();
            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (dgFiles.SelectedRows.Count > 0)
                {
                    dgFiles.ClearSelection();
                }
            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void btnInvertSelection_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                for (int k = 0; k < dgFiles.Rows.Count; k++)
                {
                    dgFiles.Rows[k].Selected = !dgFiles.Rows[k].Selected;
                }
            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void UpdateTotal()
        {
            int total_file = dgFiles.Rows.Count;

            long totalkb = 0;

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                totalkb += (long)(dt.Rows[k]["size"]);
            }

            decimal totalmb=totalkb/(decimal)1024;

            lblTotal.Text = total_file.ToString() + " " + TranslateHelper.Translate("Files") + " ( " + totalmb.ToString("0.00") + " MB )";

        }

        #region Localization

        private void AddLanguageMenuItems()
        {
            for (int k = 0; k < frmLanguage.LangCodes.Count; k++)
            {
                ToolStripMenuItem ti = new ToolStripMenuItem();
                ti.Text = frmLanguage.LangDesc[k];
                ti.Tag = frmLanguage.LangCodes[k];
                ti.Image = frmLanguage.LangImg[k];

                if (Properties.Settings.Default.Language == frmLanguage.LangCodes[k])
                {
                    ti.Checked = true;
                }

                ti.Click += new EventHandler(tiLang_Click);

                if (k < 25)
                {
                    languages1ToolStripMenuItem.DropDownItems.Add(ti);
                }
                else
                {
                    languages2ToolStripMenuItem.DropDownItems.Add(ti);
                }

                //languageToolStripMenuItem.DropDownItems.Add(ti);
            }
        }

        void tiLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            string langcode = ti.Tag.ToString();
            ChangeLanguage(langcode);

            //for (int k = 0; k < languageToolStripMenuItem.DropDownItems.Count; k++)
            for (int k = 0; k < languages1ToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languages1ToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }

            for (int k = 0; k < languages2ToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languages2ToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }
        }
        
        /*
        private void ChangeLanguage(string language_code)
        {
            Instance = null;

            InChangeLanguage = true;

            Properties.Settings.Default.Language = language_code;
            frmLanguage.SetLanguage();

            SaveSizeLocation();

            Module.ShowMessage("Please restart the application");

            System.Diagnostics.Process.Start(Application.ExecutablePath);

            Application.Exit();

            return;

            bool maximized = (this.WindowState == FormWindowState.Maximized);
            this.WindowState = FormWindowState.Normal;



            this.Controls.Clear();

            InitializeComponent();

            SetupOnLoad();

            if (maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            this.ResumeLayout(true);
          
        }
        */
        #endregion                        

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //frmMessageCheckbox.ShowStartupGuideMessage();
        }

        private void dgFiles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.RowIndex >= 0)
            {
                ShowPreview(e.RowIndex);   
            }
            */
        }

        private void ShowPreview(int rowIndex)
        {
            if (chkPreview.Checked && dt.Rows[rowIndex].RowState != DataRowState.Detached)
            {
                try
                {
                    string filepath = dt.Rows[rowIndex]["fullfilepath"].ToString();

                    if (picPreview.Image != null)
                    {
                        picPreview.Image.Dispose();
                        picPreview.Image = null;
                    }

                    //3Image img = Module.ImageFromFile(filepath);

                    Image img = ImageHelper.LoadImage(filepath);

                    lblPreviewSize.Text = TranslateHelper.Translate("Image Size")+" : "+ img.Width.ToString() + "x" + img.Height.ToString();

                    picPreview.Image = img;

                }
                catch { }
            }
            else
            {
                if (picPreview.Image != null)
                {
                    picPreview.Image.Dispose();
                    picPreview.Image = null;
                }
            }

        }        

        private void picPreview_Click(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow != null)
            {
                string filepath = dgFiles.CurrentRow.Cells["colFullFilePath"].Value.ToString();

                frmPreviewImage f = new frmPreviewImage(filepath);

                f.ShowDialog(this);
            }
        }                

        private void dgFiles_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow != null && dgFiles.CurrentRow.Index >= 0)
            {
                ShowPreview(dgFiles.CurrentRow.Index);
            }
        }        

        private void saveCurrentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    StringBuilder sb = new StringBuilder();

                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        sb.AppendLine(dt.Rows[k]["fullfilepath"].ToString());
                    }

                    System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
                }
                finally
                {
                    this.Cursor = null;
                }
            }
        }

        private delegate void delShowProgress();
        private delegate void delCloseProgress();

        private void ShowProgressForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((delShowProgress)ShowProgressForm,null);
            }
            else
            {
                frmProgress fprog = new frmProgress(dt.Rows.Count);
                fprog.Show(this);
            }

        }

        private void CloseProgressForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((delCloseProgress)CloseProgressForm, null);
            }
            else
            {
                frmProgress.Instance.Close();
            }

        }        

        private void fileExtensionsForWindowsExplorerShellExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRightClickMenuExtensions f = new frmRightClickMenuExtensions();
            f.ShowDialog(this);
        }

        private void folderWatcherOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFolderWatchers f = new frmFolderWatchers();
            f.ShowDialog(this);
        }

        #region Help Menu

        private void pleaseDonateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/donate.php");
        }

        private void dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/downloads/4dots-Software-PRODUCT-CATALOG.pdf");
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.4dots-software.com/support/bugfeature.php?app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));
        }

        private void checkForNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateHelper.CheckVersion(false);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.twitter.com/4dotsSoftware");
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.4dots-software.com");
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            /*
            List<string> lst=FreeImageHelper.GetSupportedFileExtensions();

            string str = "";

            for (int k = 0; k < lst.Count; k++)
            {
                str += lst[k] + "|||";
            }

            Module.ShowMessage(str);
            */            

            frmAbout f = new frmAbout();
            f.ShowDialog(this);
        }

        private void buyApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.BuyURL);
        }

        private void enterLicenseKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dotsSoftwareYoutubeChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCovA-lld9Q79l08K-V1QEng");
        }

        #endregion                

        private void showOperationCompletedMeesageToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadComplete)
            {                
                Properties.Settings.Default.ShowOperationCompletedMessage = showOperationCompletedMeesageToolStripMenuItem.Checked;
            }
        }

        private void exploreOutputFolderWhenFinishedToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadComplete)
            {                
                Properties.Settings.Default.ExploreOutputFolderWhenFinished = exploreOutputFolderWhenFinishedToolStripMenuItem.Checked;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();

            UpdateTotal();

            if (picPreview.Image != null)
            {
                picPreview.Image.Dispose();
                picPreview.Image = null;
            }
        }        

        private void importListFromExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel Files (*.xls;*.xlsx;*.xlt)|*.xls;*.xlsx;*.xlt";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelImporter xl = new ExcelImporter();
                xl.ImportListExcel(openFileDialog1.FileName);
            }

        }

        private void enterFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = "";

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                txt += dt.Rows[k]["fullfilepath"].ToString() + "\r\n";
            }

            frmMultipleFiles f = new frmMultipleFiles(false, txt);

            if (f.ShowDialog() == DialogResult.OK)
            {
                dt.Rows.Clear();

                for (int k = 0; k < f.txtFiles.Lines.Length; k++)
                {
                    if (System.IO.File.Exists(f.txtFiles.Lines[k].Trim()))
                    {
                        AddFile(f.txtFiles.Lines[k].Trim());
                    }
                    else if (System.IO.Directory.Exists(f.txtFiles.Lines[k].Trim()))
                    {
                        AddFolder(f.txtFiles.Lines[k].Trim());
                    }
                }
            }

        }

        private void tryAlsoOnlineVersionAtExifviewerremovercomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://exifviewerremover.com");
        }
    }
}

