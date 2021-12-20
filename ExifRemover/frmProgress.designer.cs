namespace ExifRemover
{
    partial class frmProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProgress));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblCaption = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.timTime = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.timUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblAppName = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblImageNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Maximum = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // lblCaption
            // 
            resources.ApplyResources(this.lblCaption, "lblCaption");
            this.lblCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCaption.Name = "lblCaption";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblElapsedTime
            // 
            resources.ApplyResources(this.lblElapsedTime, "lblElapsedTime");
            this.lblElapsedTime.BackColor = System.Drawing.Color.Transparent;
            this.lblElapsedTime.Name = "lblElapsedTime";
            // 
            // timTime
            // 
            this.timTime.Enabled = true;
            this.timTime.Interval = 1000;
            this.timTime.Tick += new System.EventHandler(this.timTime_Tick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // lblRemainingTime
            // 
            resources.ApplyResources(this.lblRemainingTime, "lblRemainingTime");
            this.lblRemainingTime.BackColor = System.Drawing.Color.Transparent;
            this.lblRemainingTime.Name = "lblRemainingTime";
            this.lblRemainingTime.Click += new System.EventHandler(this.lblRemainingTime_Click);
            // 
            // timUpdate
            // 
            this.timUpdate.Enabled = true;
            this.timUpdate.Tick += new System.EventHandler(this.timUpdate_Tick);
            // 
            // lblAppName
            // 
            resources.ApplyResources(this.lblAppName, "lblAppName");
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblAppName.Name = "lblAppName";
            // 
            // btnPause
            // 
            this.btnPause.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnPause, "btnPause");
            this.btnPause.Name = "btnPause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // lblImageNumber
            // 
            resources.ApplyResources(this.lblImageNumber, "lblImageNumber");
            this.lblImageNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblImageNumber.Name = "lblImageNumber";
            // 
            // frmProgress
            // 
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.lblImageNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRemainingTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblElapsedTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProgress";
            this.ShowInTaskbar = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProgress_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblElapsedTime;
        public System.Windows.Forms.Timer timTime;
        public System.Windows.Forms.Label lblCaption;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRemainingTime;
        public System.Windows.Forms.Label lblAppName;
        public System.Windows.Forms.Timer timUpdate;
        private System.Windows.Forms.Button btnPause;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblImageNumber;
    }
}
