using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FileSystemWatcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            diag.ShowDialog();
            if (diag.SelectedPath != "")
            {
                txtPath.Text = diag.SelectedPath;
            }

        }

        private void btnWatch_Click(object sender, EventArgs e)
        {
            fswTestFSW.Path = txtPath.Text;
            fswTestFSW.IncludeSubdirectories = true;
            fswTestFSW.EnableRaisingEvents = true;


            fswMONO_FSW.Path = txtPath.Text;
            fswMONO_FSW.IncludeSubdirectories = true;
            fswMONO_FSW.EnableRaisingEvents = true;


        }

        private void fswTestFSW_OnChanged(System.IO.FileSystemEventArgs e)
        {
            this.lboTestFSW.Items.Add("Changed: " + e.FullPath + "   -   " + e.ChangeType);
			HandRead handRead = new HandRead ();
			handRead.Filename = e.FullPath;
			List<string> hand = handRead.GetLastHand ();
			foreach (var item in hand) {
				lboTestFSW.Items.Add (item);
			}
        }

        private void fswTestFSW_OnCreated(System.IO.FileSystemEventArgs e)
        {
            this.lboTestFSW.Items.Add("Created: " + e.FullPath + "   -   " + e.ChangeType);
        }

        private void fswTestFSW_OnDeleted(System.IO.FileSystemEventArgs e)
        {
            this.lboTestFSW.Items.Add("Deleted: " + e.FullPath + "   -   " + e.ChangeType);
        }

        private void fswMONO_FSW_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            this.lbodotNetFSW.Items.Add("Changed: " + e.FullPath + "   -   " + e.ChangeType);
        }

        private void fswMONO_FSW_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            this.lbodotNetFSW.Items.Add("Created: " + e.FullPath + "   -   " + e.ChangeType);
        }

        private void fswMONO_FSW_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            this.lbodotNetFSW.Items.Add("Deleted: " + e.FullPath + "   -   " + e.ChangeType);
        }



    }
}
