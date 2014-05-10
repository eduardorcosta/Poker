
/*This file is part of PokDTC developed by Alexandre CHOUVELLON.

PokDTC is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

PokDTC is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with PokDTC; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;
namespace poker
{
	/// <summary>
	/// Description résumée de Welcome.
	/// </summary>
	public class Welcome : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label6;
        private Label label7;
        private LinkLabel linkLabelDownload;
        private Label labelCheckLast;
        private Label labelPostCard;
        private Label label8;
        private Form1 form;
		private void ShowProperties(){
		form.ShowProperties();
		}

        public Welcome()
        {
           

            InitializeComponent();
           

        }
		public Welcome(Form1 f)
		{
			form=f;
		
			InitializeComponent();
            Translation();
			
		}

        private void Translation()
        {
            this.label1.Text = Language.GetWelcomeToLabel() +" " +Language.Version;
            this.label2.Text = Language.GetPlayPokerLabel();
            this.label3.Text = Language.GetCreateYourPLabel();
            this.label7.Text = Language.GetTryLabel();
            this.label5.Text = Language.GetSendyourComLabel();
            this.label4.Text = Language.GetDevUnderLabel();
            this.label6.Text = Language.GetMainContriLabel() + " " + Language.MainContributors();
            this.labelCheckLast.Text = Language.GetDownloadLast();
            label8.Text = Language.GetSeeMyAddress();
            this.labelPostCard.Text = Language.GetPostCardMenu();
        
        }

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabelDownload = new System.Windows.Forms.LinkLabel();
            this.labelCheckLast = new System.Windows.Forms.Label();
            this.labelPostCard = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(5, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to PokDTC v0.85";
            this.label1.Click += new System.EventHandler(this.Welcome_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(12, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(516, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Play poker with friends over LAN/NET or against virtual players";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.Welcome_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(12, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(516, 48);
            this.label3.TabIndex = 2;
            this.label3.Text = "Create your profile, follow your stats and perform your skills";
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.Welcome_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(46, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(472, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Developed under GPL terms by Alexandre Chouvellon";
            this.label4.Click += new System.EventHandler(this.Welcome_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(46, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(472, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Send your comments to chouprod@gmail.com";
            this.label5.Click += new System.EventHandler(this.Welcome_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(46, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(348, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Main Contributors:  Mister T, Cc, Crusher";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Brown;
            this.label7.Location = new System.Drawing.Point(13, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(516, 32);
            this.label7.TabIndex = 6;
            this.label7.Text = "Try Survival mode and access to the Hall of Fame on web";
            this.label7.Visible = false;
            // 
            // linkLabelDownload
            // 
            this.linkLabelDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelDownload.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelDownload.ForeColor = System.Drawing.Color.Transparent;
            this.linkLabelDownload.LinkColor = System.Drawing.Color.Red;
            this.linkLabelDownload.Location = new System.Drawing.Point(242, 9);
            this.linkLabelDownload.Name = "linkLabelDownload";
            this.linkLabelDownload.Size = new System.Drawing.Size(286, 18);
            this.linkLabelDownload.TabIndex = 9;
            this.linkLabelDownload.TabStop = true;
            this.linkLabelDownload.Text = "http://www.sourceforge.net/projects/chouprod";
            this.linkLabelDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDownload_LinkClicked);
            // 
            // labelCheckLast
            // 
            this.labelCheckLast.AutoSize = true;
            this.labelCheckLast.BackColor = System.Drawing.Color.Transparent;
            this.labelCheckLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckLast.Location = new System.Drawing.Point(29, 11);
            this.labelCheckLast.Name = "labelCheckLast";
            this.labelCheckLast.Size = new System.Drawing.Size(165, 16);
            this.labelCheckLast.TabIndex = 10;
            this.labelCheckLast.Text = "Download last version:";
            // 
            // labelPostCard
            // 
            this.labelPostCard.BackColor = System.Drawing.Color.Transparent;
            this.labelPostCard.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPostCard.ForeColor = System.Drawing.Color.White;
            this.labelPostCard.Location = new System.Drawing.Point(11, 164);
            this.labelPostCard.Name = "labelPostCard";
            this.labelPostCard.Size = new System.Drawing.Size(483, 91);
            this.labelPostCard.TabIndex = 11;
            this.labelPostCard.Text = "Play poker with friends over LAN/NET or against virtual players";
            this.labelPostCard.Click += new System.EventHandler(this.labelPostCard_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(11, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(483, 26);
            this.label8.TabIndex = 12;
            this.label8.Text = "See my addr";
            this.label8.Click += new System.EventHandler(this.label8_Click_1);
            // 
            // Welcome
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(530, 416);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelPostCard);
            this.Controls.Add(this.labelCheckLast);
            this.Controls.Add(this.linkLabelDownload);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "Welcome";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.TopMost = true;
            this.Click += new System.EventHandler(this.Welcome_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void Welcome_Click(object sender, System.EventArgs e)
		{
            this.Close();
            this.form.Show();
			this.ShowProperties();
			
		}

        private void linkLabelDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo("IExplore.exe");
            

                info.Arguments = this.linkLabelDownload.Text;
                Process p = Process.Start(info);
            }
            catch (Exception exception){

                return;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void labelPostCard_Click(object sender, EventArgs e)
        {
            Welcome_Click(sender, e);
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            Welcome_Click(sender, e);
        }

	
	}
}
