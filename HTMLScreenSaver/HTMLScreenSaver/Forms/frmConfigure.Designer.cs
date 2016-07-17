namespace HTMLScreenSaver
{
    partial class frmConfigure
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
            this.lbScreens = new System.Windows.Forms.ListBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.panPreview = new System.Windows.Forms.Panel();
            this.lblPreview = new System.Windows.Forms.Label();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.lblSuggestionName = new System.Windows.Forms.Label();
            this.lblSuggestionDescription = new System.Windows.Forms.Label();
            this.btnTry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbScreens
            // 
            this.lbScreens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbScreens.FormattingEnabled = true;
            this.lbScreens.Location = new System.Drawing.Point(15, 311);
            this.lbScreens.Name = "lbScreens";
            this.lbScreens.Size = new System.Drawing.Size(657, 69);
            this.lbScreens.TabIndex = 0;
            this.lbScreens.SelectedIndexChanged += new System.EventHandler(this.lbScreens_SelectedIndexChanged);
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(342, 400);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(330, 20);
            this.txtURL.TabIndex = 1;
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // lblURL
            // 
            this.lblURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(339, 383);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(29, 13);
            this.lblURL.TabIndex = 2;
            this.lblURL.Text = "URL";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(342, 426);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(597, 426);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // panPreview
            // 
            this.panPreview.Location = new System.Drawing.Point(12, 25);
            this.panPreview.Name = "panPreview";
            this.panPreview.Size = new System.Drawing.Size(660, 280);
            this.panPreview.TabIndex = 5;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(12, 9);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(45, 13);
            this.lblPreview.TabIndex = 6;
            this.lblPreview.Text = "Preview";
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(516, 426);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(75, 23);
            this.btnIdentify.TabIndex = 7;
            this.btnIdentify.Text = "Identify";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // lblSuggestionName
            // 
            this.lblSuggestionName.AutoSize = true;
            this.lblSuggestionName.Location = new System.Drawing.Point(12, 383);
            this.lblSuggestionName.Name = "lblSuggestionName";
            this.lblSuggestionName.Size = new System.Drawing.Size(98, 13);
            this.lblSuggestionName.TabIndex = 8;
            this.lblSuggestionName.Text = "lblSuggestionName";
            // 
            // lblSuggestionDescription
            // 
            this.lblSuggestionDescription.Location = new System.Drawing.Point(12, 396);
            this.lblSuggestionDescription.Name = "lblSuggestionDescription";
            this.lblSuggestionDescription.Size = new System.Drawing.Size(324, 27);
            this.lblSuggestionDescription.TabIndex = 9;
            this.lblSuggestionDescription.Text = "lblSuggestionDescription";
            // 
            // btnTry
            // 
            this.btnTry.Location = new System.Drawing.Point(12, 426);
            this.btnTry.Name = "btnTry";
            this.btnTry.Size = new System.Drawing.Size(75, 23);
            this.btnTry.TabIndex = 10;
            this.btnTry.Text = "Try It";
            this.btnTry.UseVisualStyleBackColor = true;
            this.btnTry.Click += new System.EventHandler(this.btnTry_Click);
            // 
            // frmConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.btnTry);
            this.Controls.Add(this.lblSuggestionDescription);
            this.Controls.Add(this.lblSuggestionName);
            this.Controls.Add(this.btnIdentify);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.panPreview);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lbScreens);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigure";
            this.Text = "Configure";
            this.Load += new System.EventHandler(this.frmConfigure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbScreens;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Panel panPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Label lblSuggestionName;
        private System.Windows.Forms.Label lblSuggestionDescription;
        private System.Windows.Forms.Button btnTry;
    }
}