namespace HTMLScreenSaver
{
    partial class frmIdentify
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
            this.lblDispaly = new System.Windows.Forms.Label();
            this.tmrTTL = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblDispaly
            // 
            this.lblDispaly.AutoSize = true;
            this.lblDispaly.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDispaly.ForeColor = System.Drawing.Color.White;
            this.lblDispaly.Location = new System.Drawing.Point(12, 9);
            this.lblDispaly.Name = "lblDispaly";
            this.lblDispaly.Size = new System.Drawing.Size(142, 36);
            this.lblDispaly.TabIndex = 0;
            this.lblDispaly.Text = "DISPLAY";
            // 
            // tmrTTL
            // 
            this.tmrTTL.Interval = 5000;
            this.tmrTTL.Tick += new System.EventHandler(this.tmrTTL_Tick);
            // 
            // frmIdentify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(384, 56);
            this.Controls.Add(this.lblDispaly);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmIdentify";
            this.ShowInTaskbar = false;
            this.Text = "Identify";
            this.Load += new System.EventHandler(this.frmIdentify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDispaly;
        private System.Windows.Forms.Timer tmrTTL;
    }
}