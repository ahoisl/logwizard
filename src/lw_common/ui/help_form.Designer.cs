namespace lw_common.ui {
    partial class help_form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(help_form));
            this.helpViewer = new System.Windows.Forms.WebBrowser();
            this.helpPicker = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // helpViewer
            // 
            this.helpViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpViewer.Location = new System.Drawing.Point(156, 0);
            this.helpViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.helpViewer.Name = "helpViewer";
            this.helpViewer.Size = new System.Drawing.Size(852, 596);
            this.helpViewer.TabIndex = 0;
            this.helpViewer.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.helpViewer_Navigating);
            // 
            // helpPicker
            // 
            this.helpPicker.Dock = System.Windows.Forms.DockStyle.Left;
            this.helpPicker.Location = new System.Drawing.Point(0, 0);
            this.helpPicker.Name = "helpPicker";
            this.helpPicker.Size = new System.Drawing.Size(150, 596);
            this.helpPicker.TabIndex = 1;
            this.helpPicker.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.helpPicker_AfterSelect);
            // 
            // help_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1009, 596);
            this.Controls.Add(this.helpPicker);
            this.Controls.Add(this.helpViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "help_form";
            this.Text = "Help";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser helpViewer;
        private System.Windows.Forms.TreeView helpPicker;
    }
}