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
using System.Windows.Forms;
using System.Drawing;

namespace poker
{
	/// <summary>
	/// mother class
	/// </summary>
	public abstract class Player
	{
        protected ChronoTimer ownChrono = new ChronoTimer();


        public ChronoTimer OwnChrono {
            get { return this.ownChrono; }
        }
		protected CurrentProfil profil=new CurrentProfil();
		public Player()
		{
            this.ownChrono.Type_CHRONO = 1;
         
            ownChrono.HavePlayed = false;
       
		}

		
		public CurrentProfil Profil{
		
			get{return this.profil;}
            set { this.profil = value; }
		}
		public abstract void Play()	;
        /// <summary>
        /// bet or raise action
        /// </summary>
        /// <param name="mise">mise correspond à la relance faite entre min et max </param>
		public void BetRaise(long mise)
        {
            //evite les raise qd on est le dernier à parler
            if (this.game.NbrPlayerInRoundWithMoney == 1)
            {
                this.Call();
                return;
            }
			this.game.Dispatcher.Form.HideChoice();
				if(mise<game.Dispatcher.GameData.Min)
					mise=game.Dispatcher.GameData.Min;
				if(mise>game.Dispatcher.GameData.Max)
					mise=game.Dispatcher.GameData.Max;
		
			HasCheck=false;
			if( mise-this.OwnPot.Money+game.CurrentRaise.Money>=Money.Money)
			{
              
				this.Allin();
				return;
		    }
			else 
			{
                //diff sert à rien 
				long diff=mise+this.OwnPot.Money-game.CurrentRaise.Money;
                if ((mise >= game.Dispatcher.GameData.Min || game.PreviousRaise == this.game.Dispatcher.GameData.BigBlind && mise == game.PreviousRaise) && (game.Dispatcher.GameData.Type != 3 || (game.Dispatcher.GameData.Type == 3 && this.game.NbrOfRaise != 3)))
				{

                    this.game.Dispatcher.Form.Media.Raise(this.Id);
                    game.FormerRaiser = game.LastRaiser;
                    game.LastRaiser=this.id;
					game.PreviousRaise=mise;
					if(this.game.CurrentRaise.Money!=0)
					{
                       long m = mise +  this.game.CurrentRaise.Money;
						this.Game.AddOneRelance();
						game.Dispatcher.Form.GameEvents.AddDia(Name +" " +Language.GetRaisesToEvents() + " "+ m +"$\n");
                        this.game.ShowAction(this.id, Language.GetRaisesToEvents() + " " + m + "$");
                        this.Profil.IncreaseRaise(this.game);
					}
					else 
					{
						mise=game.PreviousRaise;
						game.Dispatcher.Form.GameEvents.AddDia(Name +" " +Language.GetBetsToEvents() + " " + mise +"$\n");
                        this.game.ShowAction(this.id, Language.GetBetsToEvents() + " " + mise + "$");
                        this.Profil.IncreaseBet(this.game);
                    }
					Mise(mise-this.OwnPot.Money+game.CurrentRaise.Money);
					Game.CurrentRaise.Money=(long) this.OwnPot.Money;
					if(this.Money.Money<=0) this.IsAllin=true;
					if(this.GetType().ToString().CompareTo("poker.LocalPlayer")==0){
						//this.game.SecretRaise++;
					this.game.Dispatcher.Profil.Raise++;
					
					}
					if(this.GetType().ToString().CompareTo("poker.LocalPlayer")==0
						&& game.Dispatcher.Communication.IsConnected()
						)
					{
					
						game.Dispatcher.Communication.SendToServer("{action "+Id +" true raise "+mise);
					
					}
					

				}
				else 	
				{
					this.Call();
				
				
				
				
				}			
				
			
			

	
			}
	

		}
        /// <summary>
        /// all in action
        /// </summary>
		public void Allin()
		{
            //disabled raise if only one person  with money left ,  allin must be allowed if last player do not have enough money
            if (this.game.NbrPlayerInRoundWithMoney == 1 && this.game.CurrentRaise.Money < this.money.Money +this.OwnPot.Money)
            {
                this.Call();
                return;
            }


         
            this.game.Dispatcher.Form.Media.AllIn(this.Id);
            this.profil.Allins++;
			if(this.GetType().ToString().CompareTo("poker.LocalPlayer")==0){
				this.game.SecretRaise+=2;
			if(this.game.SecretRaise>20)
				this.game.SecretRaise=0;
			}
			//this.game.ShowAction(this.id,Language.GetAllInButton()+" " + this.money.Money +"$");
			this.game.Dispatcher.Form.HideChoice();
			HasCheck=false;
			long m=money.Money;
			long r=game.CurrentRaise.Money;
	

            //est ce une relance legale ?
			if(m+this.OwnPot.Money>r)
			{
                if (m + this.OwnPot.Money - game.CurrentRaise.Money >= this.game.CurrentRaise.Money)
                {
                    this.game.PreviousRaise = m + this.OwnPot.Money - game.CurrentRaise.Money;

                    game.FormerRaiser = game.LastRaiser;
                    game.LastRaiser = this.id;
                   

                }
                else  //all in non legale   on s'en souvient 
                { if (game.AllinNonRaise == -1) game.AllinNonRaise = this.id; 
                }
				game.CurrentRaise.Money=m+this.OwnPot.Money;
                this.Profil.IncreaseRaise(this.game);
			}		
			Mise(m);
			
			if(this.GetType().ToString().CompareTo("poker.LocalPlayer")==0
				&& game.Dispatcher.Communication.IsConnected()
				)
			{
					
				game.Dispatcher.Communication.SendToServer("{action "+Id +" true allin "+m);
					
			}

			IsAllin=true;
			if(this.GetType().ToString().CompareTo("poker.LocalPlayer")==0
				&& !game.Dispatcher.Communication.IsConnected()
				)
			{
			
				//this.game.Dispatcher.Profil.AllIn++;
			
			}
		}
        /// <summary>
        /// call action
        /// </summary>
		public void Call()
        {
           
			HasCheck=false;
			long m=money.Money;
			long r=game.CurrentRaise.Money;
			if (r-this.OwnPot.Money==0){
				this.Check();
				return;
				}
                this.game.Dispatcher.Form.Media.Call(this.Id);
                if (this.GetType().ToString().CompareTo("poker.LocalPlayer") == 0)
                    this.game.SecretRaise--;
                this.game.Dispatcher.Form.HideChoice();
			if(r-this.OwnPot.Money<m)
			{
				long mise=r-this.OwnPot.Money;
				Mise(mise);
				game.Dispatcher.Form.GameEvents.AddDia(Name +" " + Language.GetCallsEvents() +" "+ r+ " $ \n");
                this.game.ShowAction(this.id, Language.GetCallsEvents() + " " + r + " $");
				if(this.GetType().ToString().CompareTo("poker.LocalPlayer")==0
					&& game.Dispatcher.Communication.IsConnected()
					)
				{
					
					game.Dispatcher.Communication.SendToServer("{action "+Id +" false call "+ mise);
					
				}
                this.Profil.IncreaseCall(this.game);
			}
			else 
			{
				this.Allin();
			}
			
	

		}
			/// <summary>
			/// fold action
			/// </summary>
	

		public void Fold()
        {

            if ( this.ownpot.Money == this.game.CurrentRaise.Money)
            {
                if (this.id == 0)
                {
                    DialogResult res = MessageBox.Show(null, Language.GetPlayForFreeEvents(), Language.GetAdviceEvents(), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (DialogResult.Yes == res)
                    {
                        this.Call();
                        return;

                    }
                }
                else { this.Check(); return; }
            }

            if (this.ownpot.Money == this.game.CurrentRaise.Money)
            {
                this.Check();
                return;
            }

            if (this.GetType().ToString().CompareTo("poker.IA") == 0)
            {
                if (this.money.Money <= this.game.CurrentBB && this.ownpot.Money>0)
                {
                    this.Allin();
                    return;
                }
            }
            this.game.ShowAction(this.id, Language.GetFoldButton());
            this.game.Dispatcher.Form.Media.Fold(this.Id);
			if(this.GetType().ToString().CompareTo("poker.LocalPlayer")==0)
				this.game.SecretRaise-=2;
            this.game.ShowAction(this.id, Language.GetFoldButton());
			this.game.Dispatcher.Form.HideChoice();
			Game.ErasePlayerRound(Id);
            this.profil.IncreaseFold(this.game);

            this.game.Dispatcher.Form.HideCard(id);
            this.game.Dispatcher.Form.HideCards(id);
			if(this.GetType().ToString().CompareTo("poker.LocalPlayer")==0
				&& game.Dispatcher.Communication.IsConnected()
				)
			{
					
				game.Dispatcher.Communication.SendToServer("{action "+Id +" false fold ");
					
			}
		}
        /// <summary>
        /// check action
        /// </summary>
		public void Check()
        {
            this.game.Dispatcher.Form.Media.Check(this.Id);
				if(this.GetType().ToString().CompareTo("poker.LocalPlayer")==0)
				this.game.SecretRaise--;
			this.game.ShowAction(this.id,Language.GetchecksEvents());
			this.game.Dispatcher.Form.HideChoice();
			HasCheck=true;
            this.Profil.IncreaseCheck(this.game);
            this.game.ShowAction(this.id, Language.GetchecksEvents());
			if(this.GetType().ToString().CompareTo("poker.LocalPlayer")==0
				&& game.Dispatcher.Communication.IsConnected()
				)
			{
					
				game.Dispatcher.Communication.SendToServer("{action "+Id +" false check ");
					
			}
		}
        /// <summary>
        /// pay action for blind, bet or raise
        /// </summary>
        /// <param name="p"></param>
		public void Pay(long p)
		{
			money.RemoveMoney(p);
		}
        /// <summary>
        /// add money 
        /// </summary>
        /// <param name="euro"></param>
		public void SetMoney(long  euro)
		{
			if (euro==0)
				money.ResetMoney();
			else 
				money.AddMoney(euro);
		
		}
        /// <summary>
        /// get pot Money
        /// </summary>
		public Pot Money
		{
			get{return money;}
			set{money=value;}
		
		}
	/// <summary>
	/// money player have bet on the current turn 
	/// </summary>
		public Pot OwnPot
		{
			get{return ownpot;}
			set{ownpot=value;}
		
		}
        /// <summary>
        /// add money to the ownpot 
        /// </summary>
        /// <param name="pot"></param>
		public void SetOwnPot(long pot)
		{
			if (pot==0)
				ownpot.ResetMoney();
			else 
				ownpot.AddMoney(pot);
		}
        /// <summary>
        /// bet action 
        /// </summary>
        /// <param name="mise"></param>
        public abstract void Mise(long mise);
        /*
		{
			money.RemoveMoney(mise);
			game.AddPot(mise);
			ownpot.AddMoney(mise);
			totalRaise.AddMoney(mise);
			//if(this.Money.Money<=0) this.IsAllin=true;
		}
        */
		public bool HasCheck
		{
			get{return check;}
			set
			{
				check=value;
				if(value) game.Dispatcher.Form.GameEvents.AddDia(this.Name +" "+ Language.GetchecksEvents()+" \n");
			
			}
		
		}
        /// <summary>
        /// total raise from the game  ( sum of each ownpot of each round)
        /// </summary>
		public void AddTotalRaise(long a)
		{
			totalRaise.AddMoney(a);
		}
		public void ResetTotalRaise()
		{
			totalRaise.ResetMoney();
		}
        /// <summary>
        /// total raise from the game  ( sum of each ownpot of each round)
        /// </summary>
		public Pot TotalRaise
		{
			get{return totalRaise;}
			set{totalRaise=value;}
		
		}

		public string Name
		{
			get{return name;}
			set{name=value;}
		
		}
		public int Id
		{
			get{return id;}
			set{id=value;}
		
		}
        /// <summary>
        /// get or set , when set broadcast the information
        /// </summary>
		public bool IsAllin
		{
			get{return allIn;}
			set
			{
				if (this.allIn && value)
					return;
				this.allIn=value;
				if (value) 
				{
                    this.game.ShowAction(this.id, Language.GetAllInButton() + " " + this.OwnPot.Money + "$");
			
					game.Dispatcher.Form.GameEvents.AddDia(this.Name + " " +Language.GetAllInButton() + " " + this.OwnPot.Money + " $\n");
					game.SetNbrPlayerInRoundWithMoney(1);
				}
			}
		
		}
		public abstract void SendPrivateCard();
		
		public Hand Hand
		{
		
			get {return hand;}
			set{hand=value;}
		}
		public Game Game
		{
		
			get {return game;}
			set{game=value;}
		}
        /// <summary>
        /// nextplayer to act 
        /// </summary>
		public void Next()
		{
            int p=Game.NextPlayer();
			if (p==-1)
				Game.ContinueRound();
			else
			{ 
				Game.CurrentPlayer=p;
				Game.GetPlayer(Game.CurrentPlayer).Play();
			}
		
		}
		public PictureBox HiddenCard1{
			get{return hiddenCard1;}
			set{hiddenCard1=value;}
		
		}
		public PictureBox HiddenCard2
		{
			get{return hiddenCard2;}
			set{hiddenCard2=value;}
		
		}
		public PictureBox ShowCard1
		{
			get{return showCard1;}
			set{showCard1=value;}
		
		}
		public PictureBox ShowCard2
		{
			get{return showCard2;}
			set{showCard2=value;}
		
		}
		public PictureBox Dealer
		{
			get{return dealer;}
			set{dealer=value;}
		
		}
		public void HideCard(){
		
		     this.game.MakeVisible(hiddenCard1);
			  this.game.MakeVisible(hiddenCard2);
		}
		public void NoCard()
		{
		
			hiddenCard1.Image=null;
			hiddenCard2.Image=null;		
		}
		public GroupBox Box{
			get{return this.box;}
			set{box=value;}
		
		}
		public Label MoneyLabel
		{
			get{return moneyLabel;}
			set{moneyLabel=value;}
		
		}
		public Label Action
		{
			get{return action;}
            set { action = value; ownChrono.Control = this.action; ownChrono.Type_CHRONO = 1; }
		
		}
        /// <summary>
        /// detecte le type de main au depart pour définir une IA 
        /// </summary>
        public void DetectMyCardsType() 
        {
            if (hand == null)
                return;
            if (hand.Card1 == null || hand.Card2 == null)
                return;

            //AA
            if (hand.Card1.ValueR == 1 && hand.Card2.ValueR == 1)
            {
                privateCardsType = 1;
                return;
            }
            //KK QQ JJ TT
            if (hand.Card1.ValueR ==  hand.Card2.ValueR   && hand.Card1.ValueR>=10)
            {
                privateCardsType = 2;
                return;
            }

            //99   <->  22
            if (hand.Card1.ValueR == hand.Card2.ValueR )
            {
                privateCardsType = 3;
                return;
            }
            //AK
            if ((hand.Card1.ValueR == 1 && hand.Card2.ValueR == 13) || (hand.Card1.ValueR == 13 && hand.Card2.ValueR == 1))
            {
                privateCardsType = 4;
                return;
            }

            //AQ <-> AT
            if ((hand.Card1.ValueR == 1 && hand.Card2.ValueR >=10) || (hand.Card1.ValueR>= 10 && hand.Card2.ValueR == 1))
            {
                privateCardsType = 5;
                return;
            }

            //A9 <-> A2
            if ((hand.Card1.ValueR == 1 ) || ( hand.Card2.ValueR == 1))
            {
                privateCardsType = 6;
                return;
            }

            //  main à tete 
            if ((hand.Card1.ValueR > 10) && (hand.Card2.ValueR > 10))
            {
                privateCardsType= 7;
                return;
            }

            //  suited connector
            if ((Math.Abs(hand.Card1.ValueR - hand.Card2.ValueR) == 1) && hand.Card1.AbsColor== hand.Card2.AbsColor)
            {
                privateCardsType = 8;
                return;
            }
            privateCardsType = 9;
        }
        private int voiceNumber = 0;

        protected int VoiceNumber
        {
            get { return voiceNumber; }
            set { voiceNumber = value; }
        }
		protected bool allIn; //is the player all in ?
		protected Pot money=null;//actual money
		protected string name; //player's name
		//somme des mises actuelles depuis le début du round
		protected Pot ownpot=null; //money player bet at the current turn
		protected Game game;  //link to a game
		protected int id;   //identification 
		protected bool check;  //is the player checks?
		protected Hand hand;
        protected int privateCardsType;
		protected Pot totalRaise;//total money player has bet since this round
		protected GroupBox box;
		protected Label moneyLabel,action;
		protected PictureBox hiddenCard1,hiddenCard2,showCard1,showCard2,dealer;
	}
}
