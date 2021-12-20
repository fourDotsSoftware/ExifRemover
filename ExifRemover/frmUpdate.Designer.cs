namespace ExifRemover
{
    partial class frmUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdate));
            this.timUpgrade = new System.Windows.Forms.Timer(this.components);
            this.btnSkip = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnUpgrade = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timUpgrade
            // 
            this.timUpgrade.Enabled = true;
            this.timUpgrade.Interval = 1000;
            this.timUpgrade.Tick += new System.EventHandler(this.timUpgrade_Tick);
            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.Color.White;
            this.btnSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSkip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSkip.Location = new System.Drawing.Point(264, 286);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(208, 52);
            this.btnSkip.TabIndex = 5;
            this.btnSkip.Text = "&Skip";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Visible = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTimer.Location = new System.Drawing.Point(477, 225);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(42, 24);
            this.lblTimer.TabIndex = 4;
            this.lblTimer.Text = "(18)";
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.BackColor = System.Drawing.Color.White;
            this.btnUpgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnUpgrade.Image = global::ExifRemover.Properties.Resources.flash1;
            this.btnUpgrade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpgrade.Location = new System.Drawing.Point(264, 215);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(208, 52);
            this.btnUpgrade.TabIndex = 3;
            this.btnUpgrade.Text = "&Upgrade Now !";
            this.btnUpgrade.UseVisualStyleBackColor = false;
            this.btnUpgrade.Click += new System.EventHandler(this.btnUpgrade_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(76, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(577, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Click on the upgrade now button to download and install the update.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(127, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "This version is old. Please update to the latest Version !";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ExifRemover.Properties.Resources.warning;
            this.pictureBox1.Location = new System.Drawing.Point(37, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 52);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(704, 391);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnUpgrade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "frmUpdate";
            this.Text = "Please upgrade to the latest Version";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer timUpgrade;
        private System.Windows.Forms.Button btnSkip;
    }
}
