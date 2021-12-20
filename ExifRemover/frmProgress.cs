using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExifRemover
{
    public partial class frmProgress : CustomForm
    {
        public static frmProgress Instance = null;               

        public frmProgress()
        {
            InitializeComponent();

            this.Text = Module.ApplicationName;
            progressBar1.Style = ProgressBarStyle.Continuous;

            lblAppName.Text = Module.ApplicationName;
            lblAppName.Left = this.Width / 2 - lblAppName.Width / 2;
            lblRemainingTime.Visible = true;
            label2.Visible = true;

            Instance = this;
        }        

        public frmProgress(int maxvalue)
            : this()
        {            
            progressBar1.Maximum = maxvalue;                       
        }                        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //frmMainOwner.ActionStopped = true;

            frmMain.Instance.ActionStopped = true;

            /*
            if (LockHelper.p != null)
            {
                try
                {
                   // if (!LockHelper.p.HasExited) LockHelper.p.Kill();
                }
                catch { }
            }
            */
            //this.Hide();
        }

        public int Secs = 0;

        private void timTime_Tick(object sender, EventArgs e)
        {            
            Secs++;

            TimeSpan ts = new TimeSpan(0, 0, Secs);

            lblElapsedTime.Text = (ts.Hours > 0 ? ts.Hours.ToString("D2") + ":" : "") + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

            if (progressBar1.Value > 0)
            {
                //val elapsed time
                //max-val ?
                decimal d1 = (decimal)progressBar1.Value;
                decimal d2 = (decimal)Secs;
                decimal d3 = (decimal)progressBar1.Maximum - progressBar1.Value;

                decimal d = (d3 * d2) / d1;
                int id = (int)d;

                ts = new TimeSpan(0, 0, id);

                if (!lblRemainingTime.Visible)
                {
                    lblRemainingTime.Visible = true;
                    label2.Visible = true;
                }

                lblRemainingTime.Text = (ts.Hours > 0 ? ts.Hours.ToString("D2") + ":" : "") + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");
            }
            else
            {
                lblRemainingTime.Text = "";
            }

            Application.DoEvents();
        }

        private void timUpdate_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();
        }

        private void frmProgress_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

        public void SetMarquee()
        {
            label1.Visible = false;
            label2.Visible = false;
            lblElapsedTime.Visible = false;
            lblRemainingTime.Visible = false;
            btnCancel.Visible = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
        }

        private void lblRemainingTime_Click(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(2, 2, this.Width - 4, this.Height - 4));
        }

        private void btnPause_Click(object sender, EventArgs e)
        {            
            frmMain.Instance.ActionPaused = !frmMain.Instance.ActionPaused;

            timTime.Enabled = !frmMain.Instance.ActionPaused;
        }

    }
}

