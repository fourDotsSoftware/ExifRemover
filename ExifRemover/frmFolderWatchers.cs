using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ExifRemover
{
    public partial class frmFolderWatchers : ExifRemover.CustomForm
    {
        private bool InitialRunAutomaticallyValue = false;

        public frmFolderWatchers()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbr = new FolderBrowserDialog();

            if (txtFolder.Text!=string.Empty && System.IO.Directory.Exists(txtFolder.Text))
            {
                fbr.SelectedPath = txtFolder.Text;
            }

            if (fbr.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = fbr.SelectedPath;
            }
        }

        private void frmFolderWatchers_Load(object sender, EventArgs e)
        {                       
            string folders = RegistryHelper2.GetKeyValue("Exif Remover", "WatchFolders");
                        
            string[] fz = folders.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < fz.Length; k++)
            {
                lvFolders.Items.Add(fz[k]);
            }

            lvFolders.Columns[0].Width = -2;
            
            RegistryKey key = Registry.CurrentUser;

            try
            {
                key = key.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

                if (key == null)
                {
                    Module.ShowMessage("Error. Could not specify if Application will start automatically with Windows");
                }

                if (key.GetValue("Exif Remover") == null)
                {

                }
                else
                {
                    chkRunAutomatically.Checked = true;
                }
            }
            catch
            {
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }

            InitialRunAutomaticallyValue = chkRunAutomatically.Checked;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFolder.Text.Trim()==string.Empty || !System.IO.Directory.Exists(txtFolder.Text))
            {
                Module.ShowMessage("Please specify a valid Folder to watch !");
                return;
            }

            ListViewItem lvi = new ListViewItem(txtFolder.Text);
            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, ""));            

            lvFolders.Items.Add(lvi);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            while (lvFolders.SelectedItems.Count > 0)
            {
                lvFolders.Items.Remove(lvFolders.SelectedItems[0]);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvFolders.Items.Count == 0)
            {
                DialogResult dres = Module.ShowQuestionDialogYesFocus(TranslateHelper.Translate("You do not have added any folder to the list. Would you like to continue ?"), TranslateHelper.Translate("You do not have added any Folder. Continue ?"));

                if (dres != DialogResult.Yes)
                {
                    return;
                }
            }

            string folders = "";

            for (int k = 0; k < lvFolders.Items.Count; k++)
            {
                folders += lvFolders.Items[k].Text + "|||";
            }                        

            RegistryHelper2.SetKeyValue("Exif Remover", "AppFilepath",Application.ExecutablePath);

            RegistryHelper2.SetKeyValue("Exif Remover", "WatchFolders",folders);

            if (chkRunAutomatically.Checked != InitialRunAutomaticallyValue)
            {
                Module.RunAdminAction("-runstartupcu \"" + bool.TrueString + "\" \"Exif Remover\" \"" +
                System.IO.Path.Combine(Application.StartupPath, "ExifRemoverFolderWatcher.exe") + "\" " +
                " \"\"");
            }

            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName("ExifRemoverFolderWatcher");

            for (int k = 0; k < procs.Length; k++)
            {
                try
                {
                    procs[k].Kill();
                }
                catch { }
            }

            System.Diagnostics.Process.Start("\""+System.IO.Path.Combine(Application.StartupPath, "ExifRemoverFolderWatcher.exe") + "\"");

            this.DialogResult = DialogResult.OK;
        }
    }
}
