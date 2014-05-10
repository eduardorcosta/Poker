namespace FileSystemWatcher
{
    partial class Form1
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnWatch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fswMONO_FSW = new System.IO.FileSystemWatcher();
            this.lboTestFSW = new System.Windows.Forms.ListBox();
            this.lbodotNetFSW = new System.Windows.Forms.ListBox();
            this.fswTestFSW = new OSX.IO.FileSystemWatcher.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fswMONO_FSW)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(583, 15);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 15);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(565, 20);
            this.txtPath.TabIndex = 1;
            // 
            // btnWatch
            // 
            this.btnWatch.Location = new System.Drawing.Point(583, 44);
            this.btnWatch.Name = "btnWatch";
            this.btnWatch.Size = new System.Drawing.Size(75, 23);
            this.btnWatch.TabIndex = 3;
            this.btnWatch.Text = "Watch";
            this.btnWatch.UseVisualStyleBackColor = true;
            this.btnWatch.Click += new System.EventHandler(this.btnWatch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Test FileSystemWatcher";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "System.IO.FileSystemWatcher";
            // 
            // fswMONO_FSW
            // 
            this.fswMONO_FSW.EnableRaisingEvents = true;
            this.fswMONO_FSW.IncludeSubdirectories = true;
            this.fswMONO_FSW.SynchronizingObject = this;
            this.fswMONO_FSW.Deleted += new System.IO.FileSystemEventHandler(this.fswMONO_FSW_Deleted);
            this.fswMONO_FSW.Created += new System.IO.FileSystemEventHandler(this.fswMONO_FSW_Created);
            this.fswMONO_FSW.Changed += new System.IO.FileSystemEventHandler(this.fswMONO_FSW_Changed);
            // 
            // lboTestFSW
            // 
            this.lboTestFSW.FormattingEnabled = true;
            this.lboTestFSW.Location = new System.Drawing.Point(15, 96);
            this.lboTestFSW.Name = "lboTestFSW";
            this.lboTestFSW.Size = new System.Drawing.Size(634, 160);
            this.lboTestFSW.TabIndex = 7;
            // 
            // lbodotNetFSW
            // 
            this.lbodotNetFSW.FormattingEnabled = true;
            this.lbodotNetFSW.Location = new System.Drawing.Point(15, 294);
            this.lbodotNetFSW.Name = "lbodotNetFSW";
            this.lbodotNetFSW.Size = new System.Drawing.Size(634, 160);
            this.lbodotNetFSW.TabIndex = 8;
            // 
            // fswTestFSW
            // 
            this.fswTestFSW.EnableRaisingEvents = false;
			this.fswTestFSW.Filter = "*.txt";
            this.fswTestFSW.IncludeSubdirectories = false;
            this.fswTestFSW.InternalBufferSize = 0;
            this.fswTestFSW.NotifyFilter = ((System.IO.NotifyFilters)(((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName)
                        | System.IO.NotifyFilters.LastWrite)));
            this.fswTestFSW.Path = "";
            this.fswTestFSW.RaiseAllEvents = true;
            this.fswTestFSW.TimerInterval = 1000;
            this.fswTestFSW.OnCreated += new OSX.IO.FileSystemWatcher.FileSystemWatcher.OnChangedEventHandler(this.fswTestFSW_OnCreated);
            this.fswTestFSW.OnDeleted += new OSX.IO.FileSystemWatcher.FileSystemWatcher.OnChangedEventHandler(this.fswTestFSW_OnDeleted);
            this.fswTestFSW.OnChanged += new OSX.IO.FileSystemWatcher.FileSystemWatcher.OnChangedEventHandler(this.fswTestFSW_OnChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 475);
            this.Controls.Add(this.lbodotNetFSW);
            this.Controls.Add(this.lboTestFSW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWatch);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnBrowse);
            this.Name = "Form1";
            this.Text = "FileSystemWatcher Test";
            ((System.ComponentModel.ISupportInitialize)(this.fswMONO_FSW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnWatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.IO.FileSystemWatcher fswMONO_FSW;
        private OSX.IO.FileSystemWatcher.FileSystemWatcher fswTestFSW;
        private System.Windows.Forms.ListBox lbodotNetFSW;
        private System.Windows.Forms.ListBox lboTestFSW;
    }
}

