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
using System.Net.Sockets;
namespace poker
{
	/// <summary>
	///Class describing network player
	/// </summary>
	public class NetworkPlayer:Player
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i">id</param>
        /// <param name="s">socket</param>
        /// <param name="n">name</param>
        /// <param name="m">money</param>
        /// <param name="f">form</param>
        /// <param name="j">game</param>
		public NetworkPlayer(int i, Socket s, string n,long m,Form1 f,Game j)
		{
            Id=i;
			socket=s;
			Name=n;
			this.ownpot=new Pot(0);
			this.totalRaise=new Pot(0);
			this.money=new Pot(m);
			this.hand=new Hand();
			Money.Money=m;
			form=f;
			game=j;
            ownChrono.InitTimeLeft = this.game.Dispatcher.GameData.Time2Mind;
            ownChrono.TimeLeft = ownChrono.InitTimeLeft;
            this.ownChrono.Game = j;
            this.ownChrono.Type_CHRONO = 1;
            this.ownChrono.Start();
		}
        /// <summary>
        /// send to player his cards
        /// </summary>
		public override void SendPrivateCard()
		{
			SendToClient("{private "+this.Hand.Card1.AbsValue +" "+this.Hand.Card2.AbsValue );
			
		}
        /// <summary>
        /// network player action, "pay "  is sent only for blind and big blind
        /// </summary>
        /// <param name="mise"></param>
        public override void Mise(long mise)
		{
            
			//if(Game.CurrentTurn==0 && (Game.GetPot()==0 || Game.CurrentRaise.Money==100))
            if (Game.CurrentTurn == 0 && ( Game.GetPot() == game.Dispatcher.GameData.Ante || Game.GetPot() == game.Dispatcher.GameData.SmallBlind) )
			SendToClient("{pay "+ mise );
			money.RemoveMoney(mise);
			if(mise!=0) 
			Game.MainPot.AddMoney(mise);
			ownpot.AddMoney(mise);
			totalRaise.AddMoney(mise);		
		} 
        /// <summary>
        /// send to client message
        /// </summary>
        /// <param name="m"></param>
		public void SendToClient(string m){
			try
			{
				byte[] buffer2 = System.Text.Encoding.Unicode.GetBytes(m.ToCharArray());
				// on envoie le texte au client
				socket.Send(buffer2);		
			}
			catch(Exception){
			return;
			}
		}
        /// <summary>
        /// make network player playing
        /// </summary>
		public override  void Play(){
		//demande de jeu changed
            this.game.Dispatcher.Form.MakeBlinkingGroupBox();
            this.OwnChrono.HavePlayed = true;
            this.game.ActualizeMinMax(this.id);
			SendToClient("{play");
			
		}
        /// <summary>
        /// analyse action 
        /// </summary>
        /// <param name="isAllin"></param>
        /// <param name="action"></param>
        /// <param name="mise"></param>
		public void FinishToPlay(bool isAllin,string action,long mise){
           
			this.HasCheck=false;		
			//y avait un truc chelou en all in 

			//to do mettre les call /check 
			if(action.CompareTo("bet")==0)
			{
				this.BetRaise(mise);
		
			}
			else 
				if (action.ToString().CompareTo("call")==0)
			{
				
			this.Call();
				
			}
			if  (action.ToString().CompareTo("fold")==0)
			{
                if(this.id==this.game.CurrentPlayer)
				this.Fold();
			
			}
			if  (action.ToString().CompareTo("check")==0)
			{
				this.Check();
				
			}
			if  (action.ToString().CompareTo("allin")==0)
			{
				this.Allin();
			
			} 
			if  (action.ToString().CompareTo("raise")==0)
			{
				this.BetRaise(mise);

			}
            this.game.Dispatcher.Form.ReinitGroupBox();
            this.OwnChrono.HavePlayed = false;
          
		//another thread to avoid overflow stack
		Thread th=new Thread(new ThreadStart(Cont));
      //  th.SetApartmentState(ApartmentState.STA);
		th.Start();

		
		}
        /// <summary>
        /// next player
        /// </summary>
		private void Cont()
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
		private Socket socket;
		private Form1 form;
	}
}
