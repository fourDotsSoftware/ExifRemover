using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExifRemover
{
    public partial class frmPromotion : ExifRemover.CustomForm
    {
        public frmPromotion()
        {
            InitializeComponent();
        }

        private void picPromotion_Click(object sender, EventArgs e)
        {
            VisitWebpage();
        }

        private void VisitWebpage()
        {
            System.Diagnostics.Process.Start("http://exifviewerremover.com");
        }

        private void lnkPromotion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VisitWebpage();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkVisitWebpage.Checked)
            {
                VisitWebpage();
            }

            Properties.Settings.Default.ShowPromotion = !chkDoNotShowAgain.Checked;

            Properties.Settings.Default.Save();

            //this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
