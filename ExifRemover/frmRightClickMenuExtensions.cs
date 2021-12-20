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
    public partial class frmRightClickMenuExtensions : ExifRemover.CustomForm
    {
        public frmRightClickMenuExtensions()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ext = txtExtension.Text.Trim();

            if (ext != string.Empty)
            {
                if (!ext.StartsWith("."))
                {
                    ext = "." + ext;
                }

                bool found = false;

                for (int k = 0; k < lstExtensions.Items.Count; k++)
                {
                    if (lstExtensions.Items[k].ToString().ToLower() == ext.ToLower())
                    {
                        found = true;

                        break;
                    }
                }

                if (!found)
                {
                    lstExtensions.Items.Add(ext.ToLower());
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            while (lstExtensions.SelectedItems.Count > 0)
            {
                lstExtensions.Items.Remove(lstExtensions.SelectedItems[0]);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstExtensions.Items.Count > 20)
            {
                DialogResult dres = Module.ShowQuestionDialog(TranslateHelper.Translate("Enter maximum around 20 File Extensions only ! Do you want to continue ?"), TranslateHelper.Translate("Continue ? Maximum around 20 File extensions !"));

                if (dres != DialogResult.Yes)
                {
                    return;
                }
            }

            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software",true);

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

            string extensions = "";

            for (int k = 0; k < lstExtensions.Items.Count; k++)
            {
                extensions += "*"+lstExtensions.Items[k].ToString().ToLower() + "|||";
            }

            key3.SetValue("File Extensions", extensions);

            key3.Close();
            key2.Close();
            key.Close();

            this.DialogResult = DialogResult.OK;
        }

        private void frmRightClickMenuExtensions_Load(object sender, EventArgs e)
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

            string extensions = key3.GetValue("File Extensions","").ToString().Replace("*","");

            key3.Close();
            key2.Close();
            key.Close();

            string[] sz = extensions.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < sz.Length; k++)
            {
                lstExtensions.Items.Add(sz[k]);
            }
        }

        private void btnAddDefImageExt_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>() { ".png", ".jpeg", ".jpg", ".gif" };

            string str = "";

            for (int k = 0; k < lst.Count; k++)
            {
                lstExtensions.Items.Add("."+lst[k]);

                str += "*."+lst[k] + "|||";
            }

            //Clipboard.Clear();
            //Clipboard.SetText(str);
        }
    }
}
