namespace ExifRemover
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.resizeSelectedImagesOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsdbAddFile = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsdbAddFolder = new System.Windows.Forms.ToolStripSplitButton();
            this.tsdbImportList = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbResize = new System.Windows.Forms.ToolStripButton();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbOutputDir = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.importListFromTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importListFromExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderWatcherOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExtensionsForWindowsExplorerShellExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOperationCompletedMeesageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreOutputFolderWhenFinishedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEXIFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tryAlsoOnlineVersionAtExifviewerremovercomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pleaseDonateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionEachWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dotsSoftwareYoutubeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.bwResize = new System.ComponentModel.BackgroundWorker();
            this.msColumns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.lblPreviewSize = new System.Windows.Forms.Label();
            this.chkKeepFolderStructure = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkKeepLastModDate = new System.Windows.Forms.CheckBox();
            this.chkKeepCreationDate = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudThreads = new System.Windows.Forms.NumericUpDown();
            this.txtFilenamePattern = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bwZipDir = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.resizeSelectedImagesOnlyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ExifRemover.Properties.Resources.folder;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            resources.ApplyResources(this.exploreToolStripMenuItem, "exploreToolStripMenuItem");
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.exploreToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::ExifRemover.Properties.Resources.delete;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // resizeSelectedImagesOnlyToolStripMenuItem
            // 
            this.resizeSelectedImagesOnlyToolStripMenuItem.Image = global::ExifRemover.Properties.Resources.flash;
            this.resizeSelectedImagesOnlyToolStripMenuItem.Name = "resizeSelectedImagesOnlyToolStripMenuItem";
            resources.ApplyResources(this.resizeSelectedImagesOnlyToolStripMenuItem, "resizeSelectedImagesOnlyToolStripMenuItem");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnChangeFolder
            // 
            resources.ApplyResources(this.btnChangeFolder, "btnChangeFolder");
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.toolTip1.SetToolTip(this.btnChangeFolder, resources.GetString("btnChangeFolder.ToolTip"));
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            // 
            // btnOpenFolder
            // 
            resources.ApplyResources(this.btnOpenFolder, "btnOpenFolder");
            this.btnOpenFolder.Image = global::ExifRemover.Properties.Resources.folder;
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.toolTip1.SetToolTip(this.btnOpenFolder, resources.GetString("btnOpenFolder.ToolTip"));
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdbAddFile,
            this.tsbRemove,
            this.toolStripSeparator3,
            this.tsdbAddFolder,
            this.tsdbImportList,
            this.toolStripSeparator1,
            this.tsbResize});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsdbAddFile
            // 
            resources.ApplyResources(this.tsdbAddFile, "tsdbAddFile");
            this.tsdbAddFile.Image = global::ExifRemover.Properties.Resources.add1;
            this.tsdbAddFile.Name = "tsdbAddFile";
            this.tsdbAddFile.ButtonClick += new System.EventHandler(this.btnAddFiles_Click);
            this.tsdbAddFile.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbAddFile_DropDownItemClicked);
            // 
            // tsbRemove
            // 
            resources.ApplyResources(this.tsbRemove, "tsbRemove");
            this.tsbRemove.Image = global::ExifRemover.Properties.Resources.delete1;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tsdbAddFolder
            // 
            resources.ApplyResources(this.tsdbAddFolder, "tsdbAddFolder");
            this.tsdbAddFolder.Image = global::ExifRemover.Properties.Resources.folder_add;
            this.tsdbAddFolder.Name = "tsdbAddFolder";
            this.tsdbAddFolder.ButtonClick += new System.EventHandler(this.btnAddFolder_Click);
            this.tsdbAddFolder.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbAddFolder_DropDownItemClicked);
            // 
            // tsdbImportList
            // 
            resources.ApplyResources(this.tsdbImportList, "tsdbImportList");
            this.tsdbImportList.Image = global::ExifRemover.Properties.Resources.import1;
            this.tsdbImportList.Name = "tsdbImportList";
            this.tsdbImportList.ButtonClick += new System.EventHandler(this.tsdbImportList_Click);
            this.tsdbImportList.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbImportList_DropDownItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsbResize
            // 
            resources.ApplyResources(this.tsbResize, "tsbResize");
            this.tsbResize.ForeColor = System.Drawing.Color.DarkBlue;
            this.tsbResize.Image = global::ExifRemover.Properties.Resources.flash1;
            this.tsbResize.Name = "tsbResize";
            this.tsbResize.Click += new System.EventHandler(this.tsbRemoveExif_Click);
            // 
            // dgFiles
            // 
            this.dgFiles.AllowDrop = true;
            this.dgFiles.AllowUserToAddRows = false;
            this.dgFiles.AllowUserToDeleteRows = false;
            this.dgFiles.AllowUserToOrderColumns = true;
            this.dgFiles.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgFiles, "dgFiles");
            this.dgFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilename,
            this.colSize,
            this.colFileDate,
            this.colFullFilePath});
            this.dgFiles.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFiles.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgFiles.GridColor = System.Drawing.Color.Black;
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.RowHeadersVisible = false;
            this.dgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFiles.CurrentCellChanged += new System.EventHandler(this.dgFiles_CurrentCellChanged);
            this.dgFiles.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFiles_RowEnter);
            this.dgFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragDrop);
            this.dgFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragEnter);
            this.dgFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragOver);
            // 
            // colFilename
            // 
            this.colFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFilename.DataPropertyName = "filename";
            resources.ApplyResources(this.colFilename, "colFilename");
            this.colFilename.Name = "colFilename";
            this.colFilename.ReadOnly = true;
            // 
            // colSize
            // 
            this.colSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSize.DataPropertyName = "sizekb";
            resources.ApplyResources(this.colSize, "colSize");
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            // 
            // colFileDate
            // 
            this.colFileDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFileDate.DataPropertyName = "filedate";
            resources.ApplyResources(this.colFileDate, "colFileDate");
            this.colFileDate.Name = "colFileDate";
            this.colFileDate.ReadOnly = true;
            // 
            // colFullFilePath
            // 
            this.colFullFilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFullFilePath.DataPropertyName = "fullfilepath";
            resources.ApplyResources(this.colFullFilePath, "colFullFilePath");
            this.colFullFilePath.Name = "colFullFilePath";
            this.colFullFilePath.ReadOnly = true;
            // 
            // cmbOutputDir
            // 
            resources.ApplyResources(this.cmbOutputDir, "cmbOutputDir");
            this.cmbOutputDir.FormattingEnabled = true;
            this.cmbOutputDir.Name = "cmbOutputDir";
            this.cmbOutputDir.SelectedIndexChanged += new System.EventHandler(this.cmbOutputDir_SelectedIndexChanged);
            // 
            // lblTotal
            // 
            resources.ApplyResources(this.lblTotal, "lblTotal");
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotal.Name = "lblTotal";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.toolStripMenuItem3});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.addFolderToolStripMenuItem,
            this.toolStripMenuItem1,
            this.importListFromTextFileToolStripMenuItem,
            this.importListFromExcelFileToolStripMenuItem,
            this.enterFileListToolStripMenuItem,
            this.saveCurrentListToolStripMenuItem,
            this.toolStripMenuItem9,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Image = global::ExifRemover.Properties.Resources.add;
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            resources.ApplyResources(this.addFilesToolStripMenuItem, "addFilesToolStripMenuItem");
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::ExifRemover.Properties.Resources.folder;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            resources.ApplyResources(this.addFolderToolStripMenuItem, "addFolderToolStripMenuItem");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // importListFromTextFileToolStripMenuItem
            // 
            this.importListFromTextFileToolStripMenuItem.Image = global::ExifRemover.Properties.Resources.import1;
            this.importListFromTextFileToolStripMenuItem.Name = "importListFromTextFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromTextFileToolStripMenuItem, "importListFromTextFileToolStripMenuItem");
            this.importListFromTextFileToolStripMenuItem.Click += new System.EventHandler(this.tsdbImportList_Click);
            // 
            // importListFromExcelFileToolStripMenuItem
            // 
            this.importListFromExcelFileToolStripMenuItem.Image = global::ExifRemover.Properties.Resources.import1;
            this.importListFromExcelFileToolStripMenuItem.Name = "importListFromExcelFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromExcelFileToolStripMenuItem, "importListFromExcelFileToolStripMenuItem");
            this.importListFromExcelFileToolStripMenuItem.Click += new System.EventHandler(this.importListFromExcelFileToolStripMenuItem_Click);
            // 
            // enterFileListToolStripMenuItem
            // 
            this.enterFileListToolStripMenuItem.Name = "enterFileListToolStripMenuItem";
            resources.ApplyResources(this.enterFileListToolStripMenuItem, "enterFileListToolStripMenuItem");
            this.enterFileListToolStripMenuItem.Click += new System.EventHandler(this.enterFileListToolStripMenuItem_Click);
            // 
            // saveCurrentListToolStripMenuItem
            // 
            this.saveCurrentListToolStripMenuItem.Image = global::ExifRemover.Properties.Resources.disk_blue;
            this.saveCurrentListToolStripMenuItem.Name = "saveCurrentListToolStripMenuItem";
            resources.ApplyResources(this.saveCurrentListToolStripMenuItem, "saveCurrentListToolStripMenuItem");
            this.saveCurrentListToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::ExifRemover.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem1,
            this.clearToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.unselectAllToolStripMenuItem,
            this.invertSelectionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Image = global::ExifRemover.Properties.Resources.delete;
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            resources.ApplyResources(this.removeToolStripMenuItem1, "removeToolStripMenuItem1");
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::ExifRemover.Properties.Resources.brush2;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            resources.ApplyResources(this.unselectAllToolStripMenuItem, "unselectAllToolStripMenuItem");
            this.unselectAllToolStripMenuItem.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            resources.ApplyResources(this.invertSelectionToolStripMenuItem, "invertSelectionToolStripMenuItem");
            this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.btnInvertSelection_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderWatcherOptionsToolStripMenuItem,
            this.fileExtensionsForWindowsExplorerShellExtensionToolStripMenuItem,
            this.showOperationCompletedMeesageToolStripMenuItem,
            this.exploreOutputFolderWhenFinishedToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // folderWatcherOptionsToolStripMenuItem
            // 
            this.folderWatcherOptionsToolStripMenuItem.Name = "folderWatcherOptionsToolStripMenuItem";
            resources.ApplyResources(this.folderWatcherOptionsToolStripMenuItem, "folderWatcherOptionsToolStripMenuItem");
            this.folderWatcherOptionsToolStripMenuItem.Click += new System.EventHandler(this.folderWatcherOptionsToolStripMenuItem_Click);
            // 
            // fileExtensionsForWindowsExplorerShellExtensionToolStripMenuItem
            // 
            this.fileExtensionsForWindowsExplorerShellExtensionToolStripMenuItem.Name = "fileExtensionsForWindowsExplorerShellExtensionToolStripMenuItem";
            resources.ApplyResources(this.fileExtensionsForWindowsExplorerShellExtensionToolStripMenuItem, "fileExtensionsForWindowsExplorerShellExtensionToolStripMenuItem");
            this.fileExtensionsForWindowsExplorerShellExtensionToolStripMenuItem.Click += new System.EventHandler(this.fileExtensionsForWindowsExplorerShellExtensionToolStripMenuItem_Click);
            // 
            // showOperationCompletedMeesageToolStripMenuItem
            // 
            this.showOperationCompletedMeesageToolStripMenuItem.CheckOnClick = true;
            this.showOperationCompletedMeesageToolStripMenuItem.Name = "showOperationCompletedMeesageToolStripMenuItem";
            resources.ApplyResources(this.showOperationCompletedMeesageToolStripMenuItem, "showOperationCompletedMeesageToolStripMenuItem");
            this.showOperationCompletedMeesageToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showOperationCompletedMeesageToolStripMenuItem_CheckedChanged);
            // 
            // exploreOutputFolderWhenFinishedToolStripMenuItem
            // 
            this.exploreOutputFolderWhenFinishedToolStripMenuItem.CheckOnClick = true;
            this.exploreOutputFolderWhenFinishedToolStripMenuItem.Name = "exploreOutputFolderWhenFinishedToolStripMenuItem";
            resources.ApplyResources(this.exploreOutputFolderWhenFinishedToolStripMenuItem, "exploreOutputFolderWhenFinishedToolStripMenuItem");
            this.exploreOutputFolderWhenFinishedToolStripMenuItem.CheckedChanged += new System.EventHandler(this.exploreOutputFolderWhenFinishedToolStripMenuItem_CheckedChanged);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeEXIFToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // removeEXIFToolStripMenuItem
            // 
            this.removeEXIFToolStripMenuItem.Image = global::ExifRemover.Properties.Resources.flash;
            this.removeEXIFToolStripMenuItem.Name = "removeEXIFToolStripMenuItem";
            resources.ApplyResources(this.removeEXIFToolStripMenuItem, "removeEXIFToolStripMenuItem");
            this.removeEXIFToolStripMenuItem.Click += new System.EventHandler(this.tsbRemoveExif_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languages1ToolStripMenuItem,
            this.languages2ToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // languages1ToolStripMenuItem
            // 
            this.languages1ToolStripMenuItem.Name = "languages1ToolStripMenuItem";
            resources.ApplyResources(this.languages1ToolStripMenuItem, "languages1ToolStripMenuItem");
            // 
            // languages2ToolStripMenuItem
            // 
            this.languages2ToolStripMenuItem.Name = "languages2ToolStripMenuItem";
            resources.ApplyResources(this.languages2ToolStripMenuItem, "languages2ToolStripMenuItem");
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.tryAlsoOnlineVersionAtExifviewerremovercomToolStripMenuItem,
            this.pleaseDonateToolStripMenuItem1,
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem,
            this.checkForNewVersionEachWeekToolStripMenuItem,
            this.toolStripMenuItem5,
            this.checkForNewVersionToolStripMenuItem,
            this.toolStripSeparator2,
            this.dotsSoftwareYoutubeChannelToolStripMenuItem,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::ExifRemover.Properties.Resources.help2;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            this.toolStripMenuItem4.Click += new System.EventHandler(this.helpGuideToolStripMenuItem_Click);
            // 
            // tryAlsoOnlineVersionAtExifviewerremovercomToolStripMenuItem
            // 
            resources.ApplyResources(this.tryAlsoOnlineVersionAtExifviewerremovercomToolStripMenuItem, "tryAlsoOnlineVersionAtExifviewerremovercomToolStripMenuItem");
            this.tryAlsoOnlineVersionAtExifviewerremovercomToolStripMenuItem.Name = "tryAlsoOnlineVersionAtExifviewerremovercomToolStripMenuItem";
            this.tryAlsoOnlineVersionAtExifviewerremovercomToolStripMenuItem.Click += new System.EventHandler(this.tryAlsoOnlineVersionAtExifviewerremovercomToolStripMenuItem_Click);
            // 
            // pleaseDonateToolStripMenuItem1
            // 
            this.pleaseDonateToolStripMenuItem1.BackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.pleaseDonateToolStripMenuItem1, "pleaseDonateToolStripMenuItem1");
            this.pleaseDonateToolStripMenuItem1.Name = "pleaseDonateToolStripMenuItem1";
            this.pleaseDonateToolStripMenuItem1.Click += new System.EventHandler(this.pleaseDonateToolStripMenuItem1_Click);
            // 
            // dotsSoftwarePRODUCTCATALOGToolStripMenuItem
            // 
            resources.ApplyResources(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem, "dotsSoftwarePRODUCTCATALOGToolStripMenuItem");
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Name = "dotsSoftwarePRODUCTCATALOGToolStripMenuItem";
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Click += new System.EventHandler(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click);
            // 
            // checkForNewVersionEachWeekToolStripMenuItem
            // 
            this.checkForNewVersionEachWeekToolStripMenuItem.CheckOnClick = true;
            this.checkForNewVersionEachWeekToolStripMenuItem.Name = "checkForNewVersionEachWeekToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionEachWeekToolStripMenuItem, "checkForNewVersionEachWeekToolStripMenuItem");
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // checkForNewVersionToolStripMenuItem
            // 
            this.checkForNewVersionToolStripMenuItem.Name = "checkForNewVersionToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionToolStripMenuItem, "checkForNewVersionToolStripMenuItem");
            this.checkForNewVersionToolStripMenuItem.Click += new System.EventHandler(this.checkForNewVersionToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // dotsSoftwareYoutubeChannelToolStripMenuItem
            // 
            this.dotsSoftwareYoutubeChannelToolStripMenuItem.Image = global::ExifRemover.Properties.Resources.youtube_32;
            this.dotsSoftwareYoutubeChannelToolStripMenuItem.Name = "dotsSoftwareYoutubeChannelToolStripMenuItem";
            resources.ApplyResources(this.dotsSoftwareYoutubeChannelToolStripMenuItem, "dotsSoftwareYoutubeChannelToolStripMenuItem");
            this.dotsSoftwareYoutubeChannelToolStripMenuItem.Click += new System.EventHandler(this.dotsSoftwareYoutubeChannelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Image = global::ExifRemover.Properties.Resources.twitter_24;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Image = global::ExifRemover.Properties.Resources.earth;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = global::ExifRemover.Properties.Resources.information;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // bwResize
            // 
            this.bwResize.WorkerReportsProgress = true;
            this.bwResize.WorkerSupportsCancellation = true;
            this.bwResize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRemovePasswords_DoWork);
            this.bwResize.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwRemovePasswords_ProgressChanged);
            this.bwResize.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRemovePasswords_RunWorkerCompleted);
            // 
            // msColumns
            // 
            this.msColumns.Name = "msColumns";
            resources.ApplyResources(this.msColumns, "msColumns");
            // 
            // picPreview
            // 
            resources.ApplyResources(this.picPreview, "picPreview");
            this.picPreview.BackColor = System.Drawing.Color.DimGray;
            this.picPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPreview.Name = "picPreview";
            this.picPreview.TabStop = false;
            this.picPreview.Click += new System.EventHandler(this.picPreview_Click);
            // 
            // chkPreview
            // 
            resources.ApplyResources(this.chkPreview, "chkPreview");
            this.chkPreview.BackColor = System.Drawing.Color.Transparent;
            this.chkPreview.Checked = true;
            this.chkPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreview.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.UseVisualStyleBackColor = false;
            // 
            // lblPreviewSize
            // 
            resources.ApplyResources(this.lblPreviewSize, "lblPreviewSize");
            this.lblPreviewSize.BackColor = System.Drawing.Color.Transparent;
            this.lblPreviewSize.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblPreviewSize.Name = "lblPreviewSize";
            // 
            // chkKeepFolderStructure
            // 
            resources.ApplyResources(this.chkKeepFolderStructure, "chkKeepFolderStructure");
            this.chkKeepFolderStructure.BackColor = System.Drawing.Color.Transparent;
            this.chkKeepFolderStructure.Checked = true;
            this.chkKeepFolderStructure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepFolderStructure.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkKeepFolderStructure.Name = "chkKeepFolderStructure";
            this.chkKeepFolderStructure.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // chkKeepLastModDate
            // 
            resources.ApplyResources(this.chkKeepLastModDate, "chkKeepLastModDate");
            this.chkKeepLastModDate.BackColor = System.Drawing.Color.Transparent;
            this.chkKeepLastModDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkKeepLastModDate.Name = "chkKeepLastModDate";
            this.chkKeepLastModDate.UseVisualStyleBackColor = false;
            // 
            // chkKeepCreationDate
            // 
            resources.ApplyResources(this.chkKeepCreationDate, "chkKeepCreationDate");
            this.chkKeepCreationDate.BackColor = System.Drawing.Color.Transparent;
            this.chkKeepCreationDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkKeepCreationDate.Name = "chkKeepCreationDate";
            this.chkKeepCreationDate.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // nudThreads
            // 
            resources.ApplyResources(this.nudThreads, "nudThreads");
            this.nudThreads.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreads.Name = "nudThreads";
            this.nudThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtFilenamePattern
            // 
            resources.ApplyResources(this.txtFilenamePattern, "txtFilenamePattern");
            this.txtFilenamePattern.Name = "txtFilenamePattern";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Name = "label8";
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.chkKeepFolderStructure);
            this.Controls.Add(this.cmbOutputDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkKeepCreationDate);
            this.Controls.Add(this.chkKeepLastModDate);
            this.Controls.Add(this.btnChangeFolder);
            this.Controls.Add(this.txtFilenamePattern);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.nudThreads);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblPreviewSize);
            this.Controls.Add(this.chkPreview);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgFiles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.ShowInTaskbar = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragOver);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnChangeFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbResize;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ComboBox cmbOutputDir;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        public System.Windows.Forms.ToolStripSplitButton tsdbImportList;
        public System.Windows.Forms.ToolStripSplitButton tsdbAddFile;
        public System.Windows.Forms.ToolStripSplitButton tsdbAddFolder;
        public System.ComponentModel.BackgroundWorker bwResize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ToolStripMenuItem languages1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languages2ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip msColumns;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem resizeSelectedImagesOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.CheckBox chkPreview;
        private System.Windows.Forms.Label lblPreviewSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudThreads;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentListToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bwZipDir;
        public System.Windows.Forms.TextBox txtFilenamePattern;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileExtensionsForWindowsExplorerShellExtensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderWatcherOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem pleaseDonateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dotsSoftwarePRODUCTCATALOGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem dotsSoftwareYoutubeChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOperationCompletedMeesageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreOutputFolderWhenFinishedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeEXIFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        public System.Windows.Forms.CheckBox chkKeepFolderStructure;
        public System.Windows.Forms.CheckBox chkKeepLastModDate;
        public System.Windows.Forms.CheckBox chkKeepCreationDate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importListFromTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importListFromExcelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionEachWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tryAlsoOnlineVersionAtExifviewerremovercomToolStripMenuItem;
    }
}
