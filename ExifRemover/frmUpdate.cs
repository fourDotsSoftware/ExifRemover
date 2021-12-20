using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExifRemover
{
    public partial class frmUpdate : ExifRemover.CustomForm
    {
        public static bool PressedSkip = false;

        public frmUpdate()
        {
            InitializeComponent();
        }

        public static bool ShouldShowUpdateScreenOnExit()
        {
            return (PressedSkip || IsAdwareFreeVersion());            
        }

        public static bool IsAdwareFreeVersion()
        {
            return (Module.ApplicationTitle.IndexOf("(AF)") >= 0);
        }

        public static void ShowUpdateScreen()
        {
            if (IsAdwareFreeVersion())
            {
                frmUpdate f = new frmUpdate();
                f.ShowDialog();
            }
        }

        private int TimerValue = 18;

        private void timUpgrade_Tick(object sender, EventArgs e)
        {
            TimerValue--;

            lblTimer.Text = "(" + TimerValue.ToString() + ")";

            if (TimerValue == 0)
            {
                timUpgrade.Enabled = false;
                btnSkip.Visible = true;
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            DialogResult dres=Module.ShowQuestionDialogWithCancel(TranslateHelper.Translate("Are you sure you want to exit the upgrade? This upgrade is higly recommended"),
                TranslateHelper.Translate("Are you sure you want to Skip Upgrade ?"));

            if (dres == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                PressedSkip = true;

            }
            else
            {
                this.DialogResult = DialogResult.OK;
                frmDownloadUpdate fdu = new frmDownloadUpdate();
                fdu.ShowDialog();
            }
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Visible = false;

            frmDownloadUpdate fdu = new frmDownloadUpdate();
            fdu.ShowDialog();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawRectangle(Pens.DarkGray, 0, 0, this.Width - 2, this.Height - 2);
            e.Graphics.DrawRectangle(Pens.DarkGray, 1, 1, this.Width - 3, this.Height - 3);
        }
    }
}
