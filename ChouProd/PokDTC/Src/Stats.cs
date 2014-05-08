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

namespace poker
{
	/// <summary>
	/// Display table stats
	/// </summary>
	public class Stats : System.Windows.Forms.Form
	{
		private ArrayList listLabel=new ArrayList(11);
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button1;
		//private int offsetX=0;
		//private int offsetY=0;
		private const int offset=5;
		private int currentX=40; 
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;
	
		private Game game;
        /// <summary>
        /// for VS only 
        /// </summary>
        public Stats() {

            InitializeComponent();
            Translation();
        }
        /// <summary>
        /// Build stats window
        /// </summary>
        /// <param name="g"></param>
		public Stats(Game g)
		{
			game=g;
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
           
			InitializeComponent();
            this.ClientSize = new System.Drawing.Size(706, (1 + this.game.NbrPlayerSinceBegin) * 40);
            Translation();
            SeekPlayer();
			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

        private void Translation()
        {
            this.Text = Language.GetStatsTitle();
            this.label1.Text = Language.GetPlayerLabel();
            this.label6.Text = Language.GetMoneyLabel();
            this.label2.Text = Language.GetFlopHandWonLabel();
            this.label3.Text = Language.GetAllInsWonLabel();
            this.label4.Text = Language.GetShowdownsWonLabel();
            this.label5.Text = Language.GetTakedownsLabel();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stats));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(242, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Flop/Hand/Won";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(376, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "AllIns/Won";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(470, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 35);
            this.label4.TabIndex = 3;
            this.label4.Text = "Showdowns/Won";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(598, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 35);
            this.label5.TabIndex = 4;
            this.label5.Text = "Takedowns";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(168, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 35);
            this.label6.TabIndex = 5;
            this.label6.Text = "Money";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // Stats
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(730, 383);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stats";
            this.Opacity = 0.75;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Stats";
            this.TopMost = true;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Mouse_Up);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Stats_Closing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mouse_Down);
            this.Load += new System.EventHandler(this.Stats_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void SeekPlayer()
		{
	//	AddPlayer(this.game.GetPlayer(0));
			for(int i=0;i<this.game.NbrPlayerSinceBegin;i++)
			{
				AddPlayer(this.game.GetPlayer(i));
			}
		
		}
		private void AddPlayer(Player pl)
		{
		
			System.Windows.Forms.Label label11;
			System.Windows.Forms.Label label22;
			System.Windows.Forms.Label label33;
			System.Windows.Forms.Label label44;
			System.Windows.Forms.Label label55;
			System.Windows.Forms.Label label66;
			label11 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label33 = new System.Windows.Forms.Label();
			label44 = new System.Windows.Forms.Label();
			label55 = new System.Windows.Forms.Label();
			label66 = new System.Windows.Forms.Label();
			this.listLabel.Add(label11);
			this.listLabel.Add(label22);
			this.listLabel.Add(label33);
			this.listLabel.Add(label44);
			this.listLabel.Add(label55);
			this.listLabel.Add(label66);



			this.SuspendLayout();
			// 
			// label1
			// 
			label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			label11.Location = new System.Drawing.Point(40, 16 +this.currentX + offset);
			label11.Name = "label11" + this.currentX;
			label11.Size = new System.Drawing.Size(120, 35);
			label11.TabIndex = 0;
			label11.Text = pl.Name;
			// 
			// label2
			// 
			label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			
			label22.Location = new System.Drawing.Point(264, 16+this.currentX+ offset);
			label22.Name = "label22"+this.currentX;
			label22.Size = new System.Drawing.Size(88, 35);
			label22.TabIndex = 1;
			label22.Text = pl.Profil.PayedFlop.ToString() +" / " + pl.Profil.HandsPlayed.ToString() + " / " + pl.Profil.Won.ToString();;
			// 
			// label3
			// 
			label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			
			label33.Location = new System.Drawing.Point(392, 16+this.currentX+ offset);
			label33.Name = "label33" +this.currentX;
			label33.Size = new System.Drawing.Size(72, 24);
			label33.TabIndex = 2;
			label33.Text = pl.Profil.Allins + " / " +  pl.Profil.AllinsWon; //to do maybe in percentage
			// 
			// label4
			// 
			label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			
			label44.Location = new System.Drawing.Point(488, 16+this.currentX+ offset);
			label44.Name = "label44" +this.currentX;
			label44.Size = new System.Drawing.Size(104,35);
			label44.TabIndex = 3;
			int a = pl.Profil.Won - pl.Profil.WonWithoutShow;
			label44.Text = pl.Profil.Showdowns + " / " + a.ToString();
			// 
			// label5
			// 
			label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			
			label55.Location = new System.Drawing.Point(616, 16+this.currentX+ offset);
			label55.Name = "label55" +this.currentX;
			label55.Size = new System.Drawing.Size(64, 35);
			label55.TabIndex = 4;
			label55.Text = pl.Profil.TakeDowns.ToString();
			// 
			// label6
			// 
			label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			
			label66.Location = new System.Drawing.Point(168, 16+this.currentX+ offset);
			label66.Name = "label6";
			label66.Size = new System.Drawing.Size(80, 35);
			label66.TabIndex = 5;
			label66.Text = pl.Money.Money.ToString();
			this.Controls.Add(label11);
			
			this.Controls.Add(label22);
			
			this.Controls.Add(label33);
			this.Controls.Add(label44);
			this.Controls.Add(label55);
			this.Controls.Add(label66);		
		
		
	
			this.currentX+=35;
			
		
		}

        public void RefreshMe(Control c)
        {
            string st = "{stats§";
            for (int i = 0; i < this.game.NbrPlayerSinceBegin; i++)
            {

                Player pl = this.game.GetPlayer(i);
                CurrentProfil pro = pl.Profil;
                ((System.Windows.Forms.Label)this.listLabel[6 * i + 1]).Text = pl.Profil.PayedFlop.ToString() + " / " + pl.Profil.HandsPlayed.ToString() + " / " + pl.Profil.Won.ToString(); ;
                ((System.Windows.Forms.Label)this.listLabel[6 * i]).Text = pl.Name;
                ((System.Windows.Forms.Label)this.listLabel[6 * i + 2]).Text = pl.Profil.Allins + " / " + pl.Profil.AllinsWon; //to do maybe in percentage
                int a = pl.Profil.Won - pl.Profil.WonWithoutShow;
                ((System.Windows.Forms.Label)this.listLabel[6 * i + 3]).Text = pl.Profil.Showdowns + " / " + a.ToString();
                ((System.Windows.Forms.Label)this.listLabel[6 * i + 4]).Text = pl.Profil.TakeDowns.ToString();
                ((System.Windows.Forms.Label)this.listLabel[6 * i + 5]).Text = pl.Money.Money.ToString();
                st += "§" + pl.Profil.PayedFlop.ToString() + " / " + pl.Profil.HandsPlayed.ToString() + " / " + pl.Profil.Won.ToString();
                st += "§" + pl.Name;
                st += "§" + pl.Profil.Allins + " / " + pl.Profil.AllinsWon;
                st += "§" + pl.Profil.Showdowns + " / " + a.ToString();
                st += "§" + pl.Profil.TakeDowns.ToString();
                st += "§" + pl.Money.Money.ToString();

            }
            this.Update();
            this.game.Dispatcher.Communication.SendBroadCast(st);

        }
		public void RefreshMe()
		{
            try
            {
                this.Invoke(new DelegateRefresh(RefreshMe), new object[] { this });
            }
            catch(Exception ex) { }
		
		}

        public delegate void DelegateRefresh(Control c);
		private ArrayList stats=new ArrayList(60);
		public ArrayList StatsStock{
			get{return stats;}set{stats=value;}
		}
		public void RefreshMeNet(){
            try
            {
                
                for (int i = 0; i < this.game.NbrPlayerSinceBegin; i++)
                {
                    if (6 * i +5 > stats.Count-1)
                        return;
                    ((System.Windows.Forms.Label)this.listLabel[6 * i]).Text = stats[6 * i + 1].ToString();
                    ((System.Windows.Forms.Label)this.listLabel[6 * i + 1]).Text = stats[6 * i].ToString();
                    ((System.Windows.Forms.Label)this.listLabel[6 * i + 2]).Text = stats[6 * i + 2].ToString();
                    ((System.Windows.Forms.Label)this.listLabel[6 * i + 3]).Text = stats[6 * i + 3].ToString();
                    ((System.Windows.Forms.Label)this.listLabel[6 * i + 4]).Text = stats[6 * i + 4].ToString();
                    ((System.Windows.Forms.Label)this.listLabel[6 * i + 5]).Text = stats[6 * i + 5].ToString();
                }
            }
            catch { }
		
		}
		private void button1_Click(object sender, System.EventArgs e){
		
		this.Hide();

		}
		private void Stats_Load(object sender, System.EventArgs e)
		{
		
		}
		private void Mouse_Up(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			return;
            /*
			int a=e.X;
			int b=e.Y;
			this.Location=new Point(e.X-offsetX,e.Y-offsetY);
             * */
		
		}
		private void Mouse_Down(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			return;
            /*
		this.offsetX=e.X;
			this.offsetY=e.Y;
             * */
		}
		private void Stats_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		this.game.Dispatcher.Form.Stats=new Stats(this.game);
		}
	}
}
