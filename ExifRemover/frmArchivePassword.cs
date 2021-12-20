using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExifRemover
{
    public partial class frmArchivePassword : ExifRemover.CustomForm
    {
        public bool PressedSkip = false;
        public bool PressedSkipAll = false;
        public bool PressedOK = false;

        private int iTimer = 180;
        public bool TimerExceeded = false;

        public frmArchivePassword()
        {
            InitializeComponent();
        }

        private void btnSkipAll_Click(object sender, EventArgs e)
        {
            PressedSkipAll = true;
            this.DialogResult = DialogResult.OK;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            PressedSkip = true;
            this.DialogResult = DialogResult.OK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == String.Empty)
            {
                Module.ShowMessage("Please insert the Archive Password !");
                return;
            }
            PressedOK = true;
            this.DialogResult = DialogResult.OK;
        }

        private void frmArchivePassword_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            iTimer--;

            if (iTimer == 0)
            {
                TimerExceeded = true;
                PressedSkipAll = true;
                this.DialogResult = DialogResult.Cancel;
            }
            else if (iTimer<=60)
            {
                lblTimer.Visible = true;
                lblTimer.Text = iTimer.ToString();
                btnStopTimer.Visible = true;
            }
        }

        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}

