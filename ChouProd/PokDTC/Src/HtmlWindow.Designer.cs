namespace poker
{
    partial class HtmlWindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowserBox = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserBox
            // 
            this.webBrowserBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserBox.Location = new System.Drawing.Point(0, 0);
            this.webBrowserBox.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserBox.Name = "webBrowserBox";
            this.webBrowserBox.Size = new System.Drawing.Size(426, 284);
            this.webBrowserBox.TabIndex = 0;
            this.webBrowserBox.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowserBox_Navigated);
            this.webBrowserBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowserBox_PreviewKeyDown);
            // 
            // HtmlWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.webBrowserBox);
            this.Name = "HtmlWindow";
            this.Size = new System.Drawing.Size(426, 284);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserBox;
    }
}
