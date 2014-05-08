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
	/// Display odds 
	/// </summary>
	public class Odds : System.Windows.Forms.Form
	{
		private  const int HIGH=0;
		public static  int TEST=7000;//10000
		private  const int PAIR=1;
		private  const int TWOPAIRS=2;
		private  const int THREE=3;
		private  const int FOUR=7;
		private  const int STRAIGHT=4;
		private  const int FULL=6;
		private  const int FLUSH=5;
		private  const int STRAIGHTFLUSH=8;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
        private Player player;

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }
		private Game game;
        private Form1 mainW;
		private int[] list1=new int[9];  //hand type player wins


        public int getOddsHigh()
        {

            return this.list1[0];
        }

        public int getOddsPair()
        {

            return list1[1];
        }
        public int getOddsDoublePair()
        {

            return list1[2];
        }
        public int getOddsThree()
        {

            return list1[3];
        }
        public int getOddsStraight()
        {

            return list1[4];
        }
        public int getOddsFlush()
        {

            return list1[5];
        }
        public int getOddsFull()
        {

            return list1[6];
        }
        public int getOddsFour()
        {

            return list1[7];
        }
        public int getOddsStraigthFlush()
        {

            return list1[8];
        }
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;
	

		private delegate void MakeVisibleHandler(Control control);

		public void Ref()
		{
		
			object[] p = new object[1];
		
			p[0] =this;
			this.Invoke(new MakeVisibleHandler(Re), p);
			
		}
        /// <summary>
        /// Refresh 
        /// </summary>
        /// <param name="c"></param>

		private void Re(Control c){
		
		c.Refresh();
		}
        /// <summary>
        /// build odds
        /// </summary>
        /// <param name="pl">player</param>
        /// <param name="a">game</param>
        /// <param name="f">mainform</param>
		public Odds(Player pl,Game a,Form1 f )
		{
			player = pl;
			game = a;
            mainW = f;

			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();
            ComputeOdds();
            Translation();
			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

        private void Translation()
        {
            this.Text = Language.GetOddsLabel();
            this.label1.Text = Language.GetOddsLabel();
            this.label2.Text = Language.GetWonLabel();
            this.label3.Text = Language.GetPairLabel();

            this.label4.Text = Language.Get2PairLabel();
            this.label5.Text = Language.GetThreeOfKindLabel();
            this.label6.Text = Language.GetStraightLabel();
            this.label7.Text = Language.GetFlushLabel();
            this.label8.Text = Language.GetFullHouseLabel();
            this.label9.Text = Language.GetFourOfKindLabel();
            this.label10.Text = Language.GetStraightFlushLabel();

        }


        public Odds(Game g ) 
        {

            game = g;

        
        } 
        /// <summary>
        ///  Compute chance to win against others
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public int[] CompareHands(ArrayList players,bool cheat)
        {
            int[] won = new int[players.Count]; //nbr of time you won against others
           
            Deck deck = new Deck();
            for (int i = 0; i < players.Count; i++)
            {
            
            won[i]=0;
            }
            for (int i = 0; i < TEST; i++) //tirage des cartes
            {

                Card b1 = game.Board.Flop1;
                Card b2 = game.Board.Flop2;
                Card b3 = game.Board.Flop3;
                Card b4 = game.Board.Turn;
                Card b5 = game.Board.River;
              
                //reinit du game 
                deck.Shuffle();
                foreach (Player p in players)
                {
                    if (cheat)
                    {
                        if (1 == game.InGame(p.Id)) // si InGame on calcule meme les cartes que les autres ont
                        {
                            deck.RemoveACard(p.Hand.Card1);
                            deck.RemoveACard(p.Hand.Card2);
                        }
                    }
                    else {

                        if (1 == game.InRound(p.Id)) 
                        {
                            deck.RemoveACard(p.Hand.Card1);
                            deck.RemoveACard(p.Hand.Card2);
                        }
                    
                    }
                }
                if (b1 != null) deck.RemoveACard(b1);
                if (b2 != null) deck.RemoveACard(b2);
                if (b3 != null) deck.RemoveACard(b3);
                if (b4 != null) deck.RemoveACard(b4);
                if (b5 != null) deck.RemoveACard(b5);
                if (b1 == (null))
                {
                    b1 = new Card(deck.TakeACard());

                }
                if (b2 == (null))
                {
                    b2 = new Card(deck.TakeACard());
                }
                if (b3 == (null))
                {
                    b3 = new Card(deck.TakeACard());
                }
                if (b4 == (null))
                {
                    b4 = new Card(deck.TakeACard());
                }
                if (b5 == (null))
                {
                    b5 = new Card(deck.TakeACard());
                }

                //list des mains evaluées
                ArrayList others = new ArrayList(10);

                foreach (Player p in players)
                {
                    if (1==game.InRound(p.Id))
                    {
                        Card p1 = p.Hand.Card1;
                        Card p2 = p.Hand.Card2;
                        Hand h = new Hand(p1, p2, b1, b2, b3, b4, b5);
                        h.EvaluateHand();
                        others.Add(h);
                    }
                }


            //best hand 
                int ind = 0;
                Hand hand = ((Hand)(others[0]));
                foreach (Hand h in others)
                {
                    //if (0 == game.InRound(ind))
                    //    continue;
                    if (hand >= h)
                        continue;
                    else { hand = h; }
                    //ind++;
                }
                //seek owners
                ind=0;  ///juste ceux en jeu

                int person = 0; //0 -> nbPLayers (meme ceux pas en jeu
                foreach (Hand h in others)
                {
                    while(0 == game.InRound(((Player)players[person]).Id))
                    {

                        person++;
                        
                    }
                    //person is the next player in game
                    if (hand <= h)
                        won[person]++;

                    person++;


                  
                   
                }
               
            }





            return won;
        } 


		private int Max(Card c1,Card c2)
		{
			if (c1.Value==1) return 14;
			else return c1.Value>c2.Value?c1.Value:c2.Value;

		
		}
        public void ComputeOdds()
        {
            int a ;

           
           a = ComputeStats();

           if (a > 100)
           {
               a = 0;
           
           }
               ShowOdds(a);
           

        }

		/// <summary>
		/// compute odds
		/// </summary>
		public int ComputeStats(){
			for(int i=0;i<9;i++)
			{
				list1[i]=0;
			}
			int won=0; //nbr of time you won against others
            if (player.Hand.Card1 == null || player.Hand.Card2 == null)
                return 111;
			Card c1=player.Hand.Card1;
			Card c2=player.Hand.Card2;
				Deck deck=new Deck();
				for(int i=0;i<TEST;i++) //tirage des cartes
				{
					
					Card b1=game.Board.Flop1;
					Card b2=game.Board.Flop2;
					Card b3=game.Board.Flop3;
					Card b4=game.Board.Turn;
					Card b5=game.Board.River;
					list1[0]=Max(c1,c2);
					//reinit du game 
					deck.Shuffle();
					deck.RemoveACard(c1);
					deck.RemoveACard(c2);
					if(b1!=null) deck.RemoveACard(b1);
					if(b2!=null) deck.RemoveACard(b2);
					if(b3!=null) deck.RemoveACard(b3);
					if(b4!=null) deck.RemoveACard(b4);
					if(b5!=null) deck.RemoveACard(b5);
					if(b1==(null))
					{
						b1=new Card(deck.TakeACard());
				
					}
					if(b2==(null))
					{
						b2=new Card(deck.TakeACard());
					}
					if(b3==(null))
					{
						b3=new Card(deck.TakeACard());
					}
					if(b4==(null))
					{
						b4=new Card(deck.TakeACard());
					}
					if(b5==(null))
					{
						b5=new Card(deck.TakeACard());
					}
					ArrayList others=new ArrayList(9);
					
					for(int e=0;e<game.NbrPlayerInRound-1;e++){
							Card p1 =new Card(deck.TakeACard());
							Card p2 = new Card(deck.TakeACard());		   
							Hand h=	 new Hand(p1,p2,b1,b2,b3,b4,b5);
						h.EvaluateHand();
						others.Add(h);
					}
					Hand hand=new Hand(c1,c2,b1,b2,b3,b4,b5);
					bool pair,pair2,brelan,full,four;
					pair=hand.IsPair();
					pair2=hand.IsTwoPair();
					brelan=hand.IsThree();
					full=hand.IsFull();
					four=hand.IsFour();
					if(pair){
					list1[1]++;
					}
					if(hand.IsTwoPair()) {
						
						list1[2]++;
						
					}
					if(hand.IsThree())
						list1[3]++;
					if(hand.IsFull()) list1[6]++;
					if(hand.IsFour())  list1[7]++;

					
					hand.EvaluateHand();
					//compute hand type

					switch (hand.CombiId)
					{
						case STRAIGHTFLUSH:list1[8]++;list1[4]++;list1[5]++; break;
						case FOUR:
						
						
							break;
						case FULL:				
							break;
						case FLUSH:list1[5]++;break;
						case STRAIGHT:list1[4]++;break;
						case THREE:			
							break;
						case TWOPAIRS:					break;
						case PAIR:break;
						default:break;
				
				
					}
					bool b=true;
					foreach(Hand h in others)
					{
						if(hand >= h)
							continue;
						else {b=false; break; }
					
					}
					if(b) won++;
				}


                return (int) (100*(float) won / (float)TEST);
		
		}
        /// <summary>
        /// display odds
        /// </summary>
        /// <param name="a"></param>
		private void ShowOdds(int a){
		float paire=100.0f*(float) list1[1] / (float)TEST;
			float paire2=100.0f*(float) list1[2] / (float)TEST;
			float three=100.0f*(float) list1[3] / (float)TEST;
			float quinte=100.0f*(float) list1[4] / (float)TEST;
			float flush=100.0f*(float) list1[5] / (float)TEST;
			float full=100.0f*(float) list1[6] / (float)TEST;
			float four=100.0f*(float) list1[7] / (float)TEST;
			float flushstraight=100.0f*(float) list1[8] / (float)TEST;
		
            string p=paire.ToString();
            string p2=paire2.ToString();
			string b=three.ToString();
			string q=quinte.ToString();
			string f=flush.ToString();
			string fu=full.ToString();
			string c=four.ToString();
			string sf=flushstraight.ToString();
            if(p.Length>4)
	                p=p.Substring(0,4);
			if(p2.Length>4)
				p2=p2.Substring(0,4);
			if(b.Length>4)
				b=b.Substring(0,4);
			if(q.Length>4)
				q=q.Substring(0,4);
			if(f.Length>4)
				f=f.Substring(0,4);
			if(fu.Length>4)
				fu=fu.Substring(0,4);
			if(c.Length>4)
				c=c.Substring(0,4);
			if(sf.Length>4)
				sf=sf.Substring(0,4);

	
		    this.label12.Text=p + "%";
			this.label13.Text=p2 +"%";
			this.label14.Text=b+"%";
			this.label15.Text=q +"%";
			this.label16.Text=f +"%";
			this.label17.Text=fu + "%";
			this.label18.Text=c +"%";
			this.label19.Text=sf + "%";
            float r = a;// 100.0f * (float)a / (float)TEST;
			if(r.ToString().Length>4)

    			this.label11.Text= r.ToString().Substring(0,4) + "%";
			else 

				this.label11.Text= r.ToString() + "%";
	
	
		this.Refresh();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Odds));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Odds";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(45, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Won";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(136, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Pair";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(182, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Double pair";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(262, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "Three of a kind";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(342, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "Straight";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(414, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "Flush";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(480, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "Full";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(534, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 32);
            this.label9.TabIndex = 9;
            this.label9.Text = "Four of a Kind";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(600, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 32);
            this.label10.TabIndex = 10;
            this.label10.Text = "Flush Straight";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(72, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 16);
            this.label11.TabIndex = 11;
            this.label11.Text = "High";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(200, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 13;
            this.label13.Text = "High";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(128, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 15;
            this.label12.Text = "High";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(280, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 16);
            this.label14.TabIndex = 14;
            this.label14.Text = "High";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(352, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 16);
            this.label15.TabIndex = 17;
            this.label15.Text = "High";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(416, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 16);
            this.label16.TabIndex = 16;
            this.label16.Text = "High";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(480, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 16);
            this.label17.TabIndex = 19;
            this.label17.Text = "High";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(544, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 16);
            this.label18.TabIndex = 18;
            this.label18.Text = "High";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(600, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 16);
            this.label19.TabIndex = 20;
            this.label19.Text = "High";
            // 
            // Odds
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(664, 110);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Odds";
            this.Opacity = 0.75;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Odds";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Odds_FormClosed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Odds_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Odds_FormClosing);
            this.Load += new System.EventHandler(this.Odds_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void label12_Click(object sender, System.EventArgs e)
		{
		
		}

		private void Odds_Load(object sender, System.EventArgs e)
		{
		
		}

		private void Odds_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}

        private void Odds_FormClosing(object sender, FormClosingEventArgs e)
        {
            

        }

        private void Odds_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainW.Odds = null;
        }
	}
}
