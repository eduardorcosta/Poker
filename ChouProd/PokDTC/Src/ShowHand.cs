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
	/// outdated
	/// </summary>
	public class ShowHand : System.Windows.Forms.Form
	{
		private CommunityCards board;
		private Player winner;
		private Player localplayer;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.PictureBox pictureBox7;
		private System.Windows.Forms.PictureBox pictureBox8;
		private System.Windows.Forms.PictureBox pictureBox9;
		private System.Windows.Forms.PictureBox pictureBox10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.PictureBox pictureBox11;
		private System.Windows.Forms.PictureBox pictureBox12;
		private System.Windows.Forms.PictureBox pictureBox13;
		private System.Windows.Forms.PictureBox pictureBox14;
		private System.Windows.Forms.PictureBox pictureBox15;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.PictureBox pictureBox16;
		private System.Windows.Forms.PictureBox pictureBox17;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ShowHand(Player win,Player you,CommunityCards b)
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			
			InitializeComponent();
			winner=win;
			board=b;
			localplayer=you;
            DrawCards();
			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		public ShowHand()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			
			InitializeComponent();
			this.Visible=false;
		
		}
		public void DrawCards(){
		
			if(this.localplayer==null || winner.Id==this.localplayer.Id)
			{
				//change size to hide bottom

				this.Size=new Size(576,528);
			}
			pictureBox15.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + board.Flop1.ValueR.ToString() +  board.Flop1.AbsColorL +".jpg");
			pictureBox14.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + board.Flop2.ValueR.ToString() +  board.Flop2.AbsColorL +".jpg");
			pictureBox13.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + board.Flop3.ValueR.ToString() +  board.Flop3.AbsColorL +".jpg");
			pictureBox12.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + board.Turn.ValueR.ToString() + board.Turn.AbsColorL+".jpg");
			pictureBox11.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + board.River.ValueR.ToString() + board.River.AbsColorL +".jpg");
			

			this.label3.Text=winner.Name +" wins with ";
			this.label1.Text=winner.Hand.HandName;
			pictureBox1.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + winner.Hand.Hand1.ValueR.ToString() + winner.Hand.Hand1.AbsColorL +".jpg");
			pictureBox2.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + winner.Hand.Hand2.ValueR.ToString() + winner.Hand.Hand2.AbsColorL +".jpg");
			pictureBox3.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + winner.Hand.Hand3.ValueR.ToString() + winner.Hand.Hand3.AbsColorL +".jpg");
			pictureBox4.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + winner.Hand.Hand4.ValueR.ToString() + winner.Hand.Hand4.AbsColorL+".jpg");
			pictureBox5.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + winner.Hand.Hand5.ValueR.ToString() + winner.Hand.Hand5.AbsColorL +".jpg");
			try
			{
			
				pictureBox17.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + localplayer.Hand.Card1.ValueR + localplayer.Hand.Card1.AbsColorL +".jpg");
				pictureBox16.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + localplayer.Hand.Card2.ValueR + localplayer.Hand.Card2.AbsColorL +".jpg");
		
			
			
			
			
		
			if(this.localplayer==null || winner.Id==this.localplayer.Id )
			{
				//change size to hide bottom

				return;
			}

	this.label2.Text=localplayer.Hand.HandName;
			this.label4.Text=localplayer.Name;

			pictureBox10.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + this.localplayer.Hand.Hand1.ValueR + localplayer.Hand.Hand1.AbsColorL +".jpg");
			pictureBox9.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + localplayer.Hand.Hand2.ValueR + localplayer.Hand.Hand2.AbsColorL +".jpg");
			pictureBox8.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + localplayer.Hand.Hand3.ValueR + localplayer.Hand.Hand3.AbsColorL +".jpg");
			pictureBox7.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + localplayer.Hand.Hand4.ValueR + localplayer.Hand.Hand4.AbsColorL +".jpg");
			pictureBox6.Image=new Bitmap(Application.StartupPath +"\\cartes\\" + localplayer.Hand.Hand5.ValueR + localplayer.Hand.Hand5.AbsColorL +".jpg");
		

			}
			catch(Exception)
			{
			
				return;
			}
			
		
		
		
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this.pictureBox8 = new System.Windows.Forms.PictureBox();
			this.pictureBox9 = new System.Windows.Forms.PictureBox();
			this.pictureBox10 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.pictureBox11 = new System.Windows.Forms.PictureBox();
			this.pictureBox12 = new System.Windows.Forms.PictureBox();
			this.pictureBox13 = new System.Windows.Forms.PictureBox();
			this.pictureBox14 = new System.Windows.Forms.PictureBox();
			this.pictureBox15 = new System.Windows.Forms.PictureBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.pictureBox16 = new System.Windows.Forms.PictureBox();
			this.pictureBox17 = new System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(16, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(80, 104);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.pictureBox5);
			this.groupBox1.Controls.Add(this.pictureBox4);
			this.groupBox1.Controls.Add(this.pictureBox3);
			this.groupBox1.Controls.Add(this.pictureBox2);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Location = new System.Drawing.Point(16, 160);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(512, 184);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Winner Hand ";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(112, 40);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(80, 104);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Location = new System.Drawing.Point(208, 40);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(80, 104);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 2;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.Location = new System.Drawing.Point(304, 40);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(80, 104);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox4.TabIndex = 3;
			this.pictureBox4.TabStop = false;
			// 
			// pictureBox5
			// 
			this.pictureBox5.Location = new System.Drawing.Point(400, 40);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(80, 104);
			this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox5.TabIndex = 4;
			this.pictureBox5.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.pictureBox6);
			this.groupBox2.Controls.Add(this.pictureBox7);
			this.groupBox2.Controls.Add(this.pictureBox8);
			this.groupBox2.Controls.Add(this.pictureBox9);
			this.groupBox2.Controls.Add(this.pictureBox10);
			this.groupBox2.Location = new System.Drawing.Point(8, 504);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(512, 184);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Your Hand ";
			// 
			// pictureBox6
			// 
			this.pictureBox6.Location = new System.Drawing.Point(400, 40);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(80, 104);
			this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox6.TabIndex = 4;
			this.pictureBox6.TabStop = false;
			// 
			// pictureBox7
			// 
			this.pictureBox7.Location = new System.Drawing.Point(304, 40);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(80, 104);
			this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox7.TabIndex = 3;
			this.pictureBox7.TabStop = false;
			// 
			// pictureBox8
			// 
			this.pictureBox8.Location = new System.Drawing.Point(208, 40);
			this.pictureBox8.Name = "pictureBox8";
			this.pictureBox8.Size = new System.Drawing.Size(80, 104);
			this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox8.TabIndex = 2;
			this.pictureBox8.TabStop = false;
			// 
			// pictureBox9
			// 
			this.pictureBox9.Location = new System.Drawing.Point(112, 40);
			this.pictureBox9.Name = "pictureBox9";
			this.pictureBox9.Size = new System.Drawing.Size(80, 104);
			this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox9.TabIndex = 1;
			this.pictureBox9.TabStop = false;
			// 
			// pictureBox10
			// 
			this.pictureBox10.Location = new System.Drawing.Point(16, 40);
			this.pictureBox10.Name = "pictureBox10";
			this.pictureBox10.Size = new System.Drawing.Size(80, 104);
			this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox10.TabIndex = 0;
			this.pictureBox10.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(216, 152);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(272, 24);
			this.label1.TabIndex = 5;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(208, 152);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(288, 24);
			this.label2.TabIndex = 6;
			this.label2.Text = "label2";
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label3.Location = new System.Drawing.Point(16, 152);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(152, 24);
			this.label3.TabIndex = 6;
			this.label3.Text = "label3";
			// 
			// label4
			// 
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label4.Location = new System.Drawing.Point(16, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(152, 24);
			this.label4.TabIndex = 7;
			this.label4.Text = "label4";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.pictureBox11);
			this.groupBox3.Controls.Add(this.pictureBox12);
			this.groupBox3.Controls.Add(this.pictureBox13);
			this.groupBox3.Controls.Add(this.pictureBox14);
			this.groupBox3.Controls.Add(this.pictureBox15);
			//this.groupBox3.Location = new System.Drawing.Point(16, 8);
			this.groupBox3.Name = "groupBox3";
			//this.groupBox3.Size = new System.Drawing.Size(512, 144);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Board";
			// 
			// pictureBox11
			// 
			this.pictureBox11.Location = new System.Drawing.Point(408, 20);
			this.pictureBox11.Name = "pictureBox11";
			this.pictureBox11.Size = new System.Drawing.Size(80, 104);
			this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox11.TabIndex = 9;
			this.pictureBox11.TabStop = false;
			// 
			// pictureBox12
			// 
			this.pictureBox12.Location = new System.Drawing.Point(312, 20);
			this.pictureBox12.Name = "pictureBox12";
			this.pictureBox12.Size = new System.Drawing.Size(80, 104);
			this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox12.TabIndex = 8;
			this.pictureBox12.TabStop = false;
			// 
			// pictureBox13
			// 
			this.pictureBox13.Location = new System.Drawing.Point(216, 20);
			this.pictureBox13.Name = "pictureBox13";
			this.pictureBox13.Size = new System.Drawing.Size(80, 104);
			this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox13.TabIndex = 7;
			this.pictureBox13.TabStop = false;
			// 
			// pictureBox14
			// 
			this.pictureBox14.Location = new System.Drawing.Point(120, 20);
			this.pictureBox14.Name = "pictureBox14";
			this.pictureBox14.Size = new System.Drawing.Size(80, 104);
			this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox14.TabIndex = 6;
			this.pictureBox14.TabStop = false;
			// 
			// pictureBox15
			// 
			this.pictureBox15.Location = new System.Drawing.Point(24, 20);
			this.pictureBox15.Name = "pictureBox15";
			this.pictureBox15.Size = new System.Drawing.Size(80, 104);
			this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox15.TabIndex = 5;
			this.pictureBox15.TabStop = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.pictureBox16);
			this.groupBox4.Controls.Add(this.pictureBox17);
			this.groupBox4.Location = new System.Drawing.Point(16, 352);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(408, 144);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Your private cards";
			// 
			// pictureBox16
			// 
			this.pictureBox16.Location = new System.Drawing.Point(212, 20);
			this.pictureBox16.Name = "pictureBox16";
			this.pictureBox16.Size = new System.Drawing.Size(80, 104);
			this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox16.TabIndex = 3;
			this.pictureBox16.TabStop = false;
			// 
			// pictureBox17
			// 
			this.pictureBox17.Location = new System.Drawing.Point(116, 20);
			this.pictureBox17.Name = "pictureBox17";
			this.pictureBox17.Size = new System.Drawing.Size(80, 104);
			this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox17.TabIndex = 2;
			this.pictureBox17.TabStop = false;
			// 
			// ShowHand
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(746, 696);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ShowHand";
			this.Text = "Summary";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		public void Win(Player win){
		
		winner=win;
		}
		public void Local(Player win)
		{
		
			this.localplayer=win;
			
		}
		public void Board(CommunityCards win)
		{
		
			this.board=win;
			
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
		this.Hide();	//this.Dispose();
		}
	}
}
