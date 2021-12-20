using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExifRemover
{
    public partial class frmMessageCheckbox : CustomForm
    {
        public frmMessageCheckbox(string title,string lblDesc):this(title,lblDesc,"")
        {

        }

        public frmMessageCheckbox(string title,string lblDesc,string chkDesc)
        {
            InitializeComponent();

            this.Text = title;

            this.lblOption.Text = lblDesc;

            if (chkDesc != String.Empty)
            {
                this.chkOption.Text = chkDesc;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkOption.Checked)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }        
    }
}

