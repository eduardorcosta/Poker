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
using System.Threading;
using System.Windows.Forms;
namespace poker
{
	/// <summary>
	/// Description résumée de YOU.
	/// </summary>
	public class LocalPlayer:Player
	{
        /// <summary>
        /// build real player
        /// </summary>
        /// <param name="n">name</param>
        /// <param name="m">money</param>
        /// <param name="j">game</param>
        /// <param name="i">id</param>
		public LocalPlayer(string n,long m,Game j ,int i)
		{ 
			Id=i;
			game=j;
			form=game.Dispatcher.Form;
			form.SetPlayer(this);
			this.money=new Pot(m);
			this.hand=new Hand();
			this.ownpot=new Pot(0);
			this.totalRaise=new Pot(0);
			name=n;
            this.ownChrono.Game = j;
            this.ownChrono.Type_CHRONO = 1;
            ownChrono.InitTimeLeft = this.game.Dispatcher.GameData.Time2Mind;
            ownChrono.TimeLeft = ownChrono.InitTimeLeft;
            this.ownChrono.Start();
		}

        public override void Mise(long mise)
        {

            this.game.Dispatcher.Form.Media.Chips();
            money.RemoveMoney(mise);
            game.AddPot(mise);
            ownpot.AddMoney(mise);
            totalRaise.AddMoney(mise);
            //if(this.Money.Money<=0) this.IsAllin=true;

        }


        /// <summary>
        /// make local player play
        /// </summary>
		public override  void Play()
		{//changed

         //this.game.Dispatcher.Form.button6_Click(null,null);
         //   return;
          /////();

            //this.game.MakeCurrentPlayerFold(this.Id);
            //return;
            try
            {

                if (this.game.Dispatcher.Form.IsAutoFold())
                {
                    this.game.Dispatcher.Form.UnCheckRadio();
                    this.game.Dispatcher.Form.button7_Click(null, null);
                    return;

                }

                if (this.game.Dispatcher.Form.IsAutoCall())
                {
                    this.game.Dispatcher.Form.UnCheckRadio();
                    if (this.game.CurrentRaise.Money <= this.game.Dispatcher.GameData.BigBlind)
                    {
                        this.form.button6_Click(null, null);
                        return;
                    }

                }


                //pas de blink ici pour un joueur reseau, le blink est activé via {currentp 

                if (!this.game.Dispatcher.Communication.IsConnected())


                    game.Dispatcher.Form.MakeBlinkingGroupBox();


                if (this.game.GamePause)
                {
                    this.game.Dispatcher.Form.GameEvents.AddDia("Game Paused\n");
                }
                while (this.game.GamePause)
                {
                    Thread.Sleep(500);
                }
                this.ownChrono.HavePlayed = true;
                this.game.ActualizeMinMax(this.id);
                long a = game.CurrentRaise.Money - OwnPot.Money;
                form.Setlabel3(a.ToString());
                // set visibility 
                try
                {
                    this.game.Dispatcher.Form.SetVisibilityFold(true);
                    this.game.Dispatcher.Form.SetVisibilityCall(true);

                    if (this.game.Dispatcher.GameData.Max >= this.money.Money)
                    {
                        this.game.Dispatcher.Form.SetVisibilityAllin(true);

                    }
                    if ((this.game.Dispatcher.GameData.Type != 3) || (this.game.Dispatcher.GameData.Type == 3 && this.game.NbrOfRaise < 3))
                    {

                        this.game.Dispatcher.Form.SetVisibilityRaise(true);

                        this.game.Dispatcher.Form.ChangeScrollValue((int)this.game.Dispatcher.GameData.Min);

                    }
                  //  form.UpdateInvoke();

                }
                catch (Exception exception) { }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
		}

        //// "Decide " outdated
        ///// <summary>
        ///// outdated
        ///// </summary>
        ///// <param name="m"></param>
        //public void Decide(object m)
        //{
        //    long mise=0;
        //    if(m.ToString().CompareTo("Bet")==0)
        //    {
        //            HasCheck=false;
        //        if(Game.GetTypePoker()==3)
        //            switch (Game.CurrentTurn) 
        //            {			
        //                case 1:mise=Game.Dispatcher.GameData.Min;break;
        //                case 2:
        //                case 3:mise=Game.Dispatcher.GameData.Min;break;	
        //            }
        //        else
        //        {
        //            mise=form.GetTextBox1();
        //        }
        //        if((long) mise>=Money.Money)
        //        {
        //            IsAllin=true;
        //            Mise(Money.Money);
        //            form.Setlabel1(Money.Money);  //ke faire si le pot n'est pas assuré? on doit ouvrir qd meme <minraise
        //            Game.CurrentRaise.Money=Money.Money;
        //            game.Dispatcher.Form.GameEvents.AddDia(Name +" bets and is all in!\n");				
		
        //        }
        //        else 
        //        {
        //            Mise(mise);
        //            form.Setlabel1(Money.Money);
        //            game.Dispatcher.Form.GameEvents.AddDia(Name +" bets!\n");				
		
        //            Game.CurrentRaise.Money=(long) mise; 
        //        }
			
        //    }
        //    else 
        //        if (m.ToString().CompareTo("Call")==0)
        //    {
        //            HasCheck=false;
        //        long diff=Game.CurrentRaise.Money-OwnPot.Money;

        //        if(diff>=Money.Money)
        //        {
        //            Mise(Money.Money);
        //            IsAllin=true;
					
        //game.Dispatcher.Form.GameEvents.AddDia(Name +" is all in!!\n");				
        //        }
        //        else
        //        {
        //            Mise(diff);
        //        }
        //    game.Dispatcher.Form.GameEvents.AddDia(Name +" calls\n");
        //        form.Setlabel1(Money.Money);
        //        form.UpdateInvoke();
        //    }
        //    if  (m.ToString().CompareTo("Fold")==0)
        //    {
        //            HasCheck=false;
        //            Game.ErasePlayerRound(Id);
        //        if (Game.NbrPlayerInRound==1)
        //        {
        //            Game.SeekSurvivor();
        //            return;
        //        }
        //    }
        //    if  (m.ToString().CompareTo("Check")==0)
        //    {
				
        //            game.Dispatcher.Form.GameEvents.AddDia(Name +" checks\n");
        //        Game.GetPlayer(this.Id).HasCheck=true;
			
        //    }
        //    if  (m.ToString().CompareTo("All In")==0)
        //    {
        //        HasCheck=false;
        //        long diff=Money.Money;
        //        if(diff>(Game.CurrentRaise.Money-OwnPot.Money))
        //            Game.CurrentRaise.Money=(Money.Money-Game.CurrentRaise.Money);
        //        Mise(diff);
        //        IsAllin=true;
        //        form.Setlabel1(diff);
        //        form.UpdateInvoke();
        //                game.Dispatcher.Form.GameEvents.AddDia(Name +" is all in!!\n");
        //    } 
        //    if  (m.ToString().CompareTo("Raise")==0)
        //    {
        //        HasCheck=false;

        //        if(Game.CurrentTurn==0 && Game.CurrentRaise.Money==game.Dispatcher.GameData.Min && Game.CurrentPlayer==game.Dispatcher.GameData.BigBlind)
        //        {	
        //            if(game.Dispatcher.GameData.Min<Money.Money)
        //            {
        //                Mise(game.Dispatcher.GameData.Min);
        //                Game.CurrentRaise.Money=(game.Dispatcher.GameData.Min);
        //                game.Dispatcher.Form.GameEvents.AddDia(Name +" raises!!\n");
        //            }
        //            else 
        //            {
        //                Game.CurrentRaise.Money=(Money.Money);
        //                Mise(Money.Money);
        //                IsAllin=true;
        //                game.Dispatcher.Form.GameEvents.AddDia(Name +" raises and is all in !!\n");
        //            }
        //        }
        //        else
        //        {

        //            if(Game.GetTypePoker()!=3)
        //                mise=form.GetTextBox1();
				
        //            else
        //            {
        //                switch (Game.CurrentTurn)
        //                {
        //                    case 0: 
        //                    case 1: mise =game.Dispatcher.GameData.Min+Game.CurrentRaise.Money-OwnPot.Money;break;
        //                    default: mise=game.Dispatcher.GameData.Min+Game.CurrentRaise.Money-OwnPot.Money;break;
        //                }
				
        //            }
        //            if( mise>=Money.Money)
        //            {
        //                if(Money.Money-Game.CurrentRaise.Money>0)
        //                    Game.CurrentRaise.Money=(Money.Money-Game.CurrentRaise.Money);
        //                Mise(Money.Money);
        //                IsAllin=(true);
        //            game.Dispatcher.Form.GameEvents.AddDia(Name +" raises and is all in!!\n");					
        //            }
        //            else
        //            {
        //                Mise(mise);
        //                this.Game.AddOneRelance();
        //                if(mise>Game.CurrentRaise.Money)
        //                    Game.CurrentRaise.Money=(mise-Game.CurrentRaise.Money);
        //                game.Dispatcher.Form.GameEvents.AddDia(Name +" raises!!\n");
        //            }
				
        //            this.Game.AddOneRelance();
        //            form.Setlabel1(Money.Money);
        //            form.UpdateInvoke();
        //        } 
        //    }
        //    int p=Game.NextPlayer();
        //    if (p==-1)
        //        Game.ContinueRound();
        //    else
        //    { 
        //        Game.CurrentPlayer=p;
        //        Game.GetPlayer(Game.CurrentPlayer).Play();
        //    }

        //}
        /// <summary>
        /// show what cards local player get
        /// </summary>
		public override void SendPrivateCard(){
		
		this.Game.Dispatcher.Form.GameEvents.AddOwnDia("You get " + this.Hand.Card1.Name+ " " + this.Hand.Card1.Color + " " + this.Hand.Card2.Name+ " " + this.Hand.Card2.Color+"\n");
		
		
		}
	


		private Form1 form; 
	}
}