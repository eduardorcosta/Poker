
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
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Text;
using System.Collections;
namespace poker
{
	/// <summary>
	/// CLASS ON DEV 
	/// </summary>
	public class ComInOut
	{
		public ComInOut(Dispatcher dis)
		{
			dispatcher=dis;
			dispatcher.Communication=this;
		}
		public void SendBroadCast(string msg)
		{
			byte[] buffer = System.Text.Encoding.Unicode.GetBytes(msg.ToCharArray());
			try
			{
				for(int i=0;i<nbr_socket;i++)
				{
					// on envoie le texte au client
					lock(mySockets[i])
					{
						if(mySockets[i]!=null)
							mySockets[i].Send(buffer,buffer.Length,0);
					}
				}
			}
			catch//(Exception e )
			{
			
			
			}
		}
		public void SendToSocket(int i,byte[] buffer)
		{
			if(mySockets[i]!=null)
				mySockets[i].Send(buffer,buffer.Length,0);	
		}
        public delegate void MakeVisibleHandler(Control control);
		public Socket GetSocket(int i)
		{
		
			return this.mySockets[i];
		}
		private  void Ecoute()
		{
			try
			{
				//addDia("Initialisation d'une socket d'ecoute ...waiting for players");
				int k=0;
		
				while(stop)
				{  
                    
					for(k=0;k<nbr_socket;k++)
					{ 
                        
                        ///to do rajouter un asynchronous
                        if (mySockets[k].Available == 0) { Thread.Sleep(500); continue; }
						// Creation d'un tableau de byte pour contenir les données reçues					Byte[] buffer = new Byte[1024];
						Byte[] buffer = new Byte[6048];
						// on met les bytes recuperés dans le tableau
						lock(mySockets[k])
						{
							mySockets[k].Receive(buffer);
						}
					
						string data = Encoding.Unicode.GetString(buffer);
					 
						char[] sepe=new char[1];
						sepe[0]='{';
						string[] split=data.Split(sepe);
						for(int i=0;i<split.Length;i++)
						{
                           
							data=split[i];
							if(data.StartsWith("name"))
							{
                               
								data=data.Remove(0,5);
								char[] c=new char[1];
								char[] sep=new char[1];
								sep[0]='§';
								c[0]='\0';
								string[] info=data.Split(sep);
								data=data.TrimEnd(c);
								int id=(int) Convert.ToInt32(info[0]);
                                if (!dispatcher.Game.GetPlayer(id).GetType().ToString().Contains("NetworkPlayer"))
                                    break;
								try
								{
                                    if (dispatcher.Game != null)
                                    {
                                        dispatcher.Game.GetPlayer(id).Name = info[1].TrimEnd(c);
                                  
              }
                                    else
                                    {


                                    }
								}
								catch//(Exception e)
								{
									
								}
								
							}
							
							
							if(data.StartsWith("action"))
                            {
                               
                                
                                    data = data.Remove(0, 7);
                                    char[] sep = new char[1];
                                    sep[0] = ' ';
                                    string[] msg = data.Split(sep);
                                    int id = (int)Convert.ToInt32(msg[0]);
                                    bool isAllin = msg[1].CompareTo("true") == 0;
                                    string action = msg[2];
                                    long mise = 0;
                                    if (action.CompareTo("check") != 0 && action.CompareTo("fold") != 0)
                                        mise = Convert.ToInt32(msg[3]);
                                    try
                                    {
                                        if (!dispatcher.Game.GetPlayer(id).GetType().ToString().Contains("NetworkPlayer"))
                                            break;
                                        ((NetworkPlayer)dispatcher.Game.GetPlayer(id)).FinishToPlay(isAllin, action, mise);
                                    }
                                    catch { }
                            }	
							if(data.StartsWith("msg"))
							{
                                if (this.dispatcher.Game != null)
                                {
                                    try
                                    {
                                        if (!dispatcher.Game.GetPlayer(k + 1).GetType().ToString().Contains("NetworkPlayer"))
                                            break;
                                    }
                                    catch { }
                                } 
								data=data.Remove(0,4);
								dispatcher.Form.Chat.AddChat(data);
								
							}
                            if (data.StartsWith("exit"))
                            {

                                data = data.Remove(0, 5);
                                try
                                {
                                    try
                                    {
                                        if (!dispatcher.Game.GetPlayer(Convert.ToInt16(data)).GetType().ToString().Contains("NetworkPlayer"))
                                        {
                                            break;
                                        }
                                    }
                                    catch { }
                                        if (dispatcher.Game.InGame(Convert.ToInt16(data)) == 1)
                                        {
                                            dispatcher.Form.Chat.AddChat("player " + dispatcher.Game.GetPlayer(Convert.ToInt16(data)).Name + " seems to be gone, a bot will take his place");
                                            IA newIA = new IA(dispatcher.Game.GetPlayer(Convert.ToInt16(data)).Name + "_BOT", 34, 45, 43, dispatcher.Game.GetPlayer(Convert.ToInt16(data)).Money.Money, dispatcher.Game, dispatcher.Game.GetPlayer(Convert.ToInt16(data)).Id, false);
                                            newIA.Box = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).Box;
                                            newIA.Action = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).Action;
                                            newIA.Dealer = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).Dealer;
                                            newIA.Hand = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).Hand;
                                            newIA.HasCheck = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).HasCheck;
                                            newIA.HiddenCard1 = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).HiddenCard1;
                                            newIA.HiddenCard2 = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).HiddenCard2;
                                            newIA.IsAllin = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).IsAllin;
                                            newIA.MoneyLabel = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).MoneyLabel;
                                            newIA.OwnPot = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).OwnPot;
                                            newIA.Profil = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).Profil;
                                            newIA.ShowCard1 = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).ShowCard1;
                                            newIA.ShowCard2 = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).ShowCard2;
                                            newIA.TotalRaise = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).TotalRaise;
                                            string nameOLD = dispatcher.Game.GetPlayer(Convert.ToInt16(data)).Name;

                                            dispatcher.Game.SetPlayer(newIA);
                                            //on envoie les modifs à la console
                                            dispatcher.Admin.Actualize(this.dispatcher);
                                            this.dispatcher.Communication.SendBroadCast("{msg " + nameOLD + " seems to be gone away, an AI should take his place");


                                        }
                                        else
                                        {
                                            dispatcher.Form.Chat.AddChat("player " + dispatcher.Game.GetPlayer(Convert.ToInt16(data)).Name + " seems to be gone");
                                            dispatcher.Game.InGame(Convert.ToInt16(data), 0);

                                        }
                                    
                                }
                                catch { }

                                //to do : vérifier qu'il reste des joueurs! 
                            }
						}
					}
				}
					
			}
			catch(Exception e)
			{
				stop = false;
				if(socket_ecoute!=null)
					socket_ecoute.Stop();
			
				dispatcher.Form.GameEvents.AddOwnDia("Connection lost");
				if(th.IsAlive)
					th.Abort();
				if(this.threadconnect!=null)
					this.threadconnect.Abort();
			}
		}
      
		private  void AcceptConnexion()
		{
			try
			{
				wait=true;
				socket_ecoute = new TcpListener(IPAddress.Parse(ip) ,port);
				socket_ecoute.Start();
				mySockets=new Socket[10];
                dispatcher.Form.GameEvents.AddOwnDia("waiting for clients\n");
					
				while(nbr_socket<10 && wait )
				{
					//	if(wait && socket_ecoute.Pending())
					//	{
					mySockets[nbr_socket]=socket_ecoute.AcceptSocket() ;
					nbr_socket++;
					dispatcher.Form.GameEvents.AddOwnDia("connected to a  client\n Click on New Game to start the game\n");
					if(nbr_socket==1)
					{
						th = new Thread(new ThreadStart(Ecoute));
                        th.Name = "ServeurListen";
                        th.Priority = ThreadPriority.AboveNormal;
						th.Start(); 
						//		}
					}
                    Thread.Sleep(1000);
				}
			}
			catch//(Exception e)
			{
				
				if(th!=null)
					th.Abort();
				if(this.threadconnect!=null)
					this.threadconnect.Abort();
				return;
			}

		}
		public void Listen()
		{
			this.nbr_socket=0;
			threadconnect = new Thread(new ThreadStart(AcceptConnexion));
            threadconnect.Name = "AcceptConnexion";
            threadconnect.Priority = ThreadPriority.AboveNormal;
      
			threadconnect.Start();
			
		}
		public Socket[] MySockets
		{
			get{return mySockets;}
			set{mySockets=value;}
		
		}
		public void ListenServer(string i,int p)
		{
			ip=i;
			port=p;
			th=new Thread(new ThreadStart(Connexion));
            th.Name = "Connexion";
            th.IsBackground = true;
           // th.SetApartmentState(ApartmentState.STA);
			th.Start();
		}
 
		public void Connexion()
		{
			//try 
			//{
			// On crée une socket client sur le port (int port) et l'ip donné
            try
            {
                clientsocket = new TcpClient(ip, port);
            }
            catch (Exception exception){
                this.dispatcher.Form.GameEvents.AddOwnDia("Connexion impossible\n "+exception);
                return;
            }
			this.dispatcher.Form.GameEvents.AddOwnDia("Connexion ...\n");		
				
			// si la socket a été crée
			if( clientsocket != null  )
			{
				// objet pour recuperer et envoyer les données
				clientsocket.ReceiveTimeout=1000000;
				ns = clientsocket.GetStream();

				this.dispatcher.Form.GameEvents.AddOwnDia( "connected to host\n Please wait for the game to begin\n The host will initialize it soon \n");
				connected=true;
				this.dispatcher.Form.Launch=true;
				dispatcher.Game=new Game(dispatcher);
				dispatcher.Form.MiniInfo=new MiniInfo(dispatcher.Form.ListBox1,dispatcher.Game);
				//this.SendToServer("{name 11§"+this.dispatcher.GameData.Name);
				// boucle infinie pour la reception des données du serveur
				while(stop)
				{
                   // to do mettre un asynchronous
                    if (!ns.DataAvailable) { Thread.Sleep(1000); continue; }
					// tableau de byte pour la reception des données
					Byte[] buffer = new Byte[56048];

					// reception des données
                    if (ns == null) { MessageBox.Show("disconnected"); return; }
						
						
					lock(ns)
					{
						ns.Read(buffer,0,buffer.Length);
					}
				//avant UTF8
					string texte = System.Text.Encoding.Unicode.GetString(buffer);

					char[] sepe=new char[1];
					sepe[0]='{';
					string[] split=texte.Split(sepe);
					for(int k=1;k<split.Length;k++) 
					{
						texte=split[k];
						if(texte.StartsWith("init"))
						{
							texte=texte.Remove(0,4);
							int i=(int) Convert.ToInt32(texte);
							this.SendToServer("{name "+i+"§"+this.dispatcher.GameData.Name);
                           
                            //set real local player
							if(everdo)
                            {
                                this.dispatcher.Game.GetPlayer(i).Name = this.dispatcher.GameData.Name;
								this.dispatcher.Game.Player=this.dispatcher.Game.GetPlayer(i);
								dispatcher.Form.SetPlayer(this.dispatcher.Game.Player);
								this.dispatcher.Game.SetInfo();
							}
								
							everdo=false;
							continue;
						}
						if(texte.CompareTo("play")==0)
						{
							Thread play=new Thread(new ThreadStart(dispatcher.Game.Player.Play));
                            //th.SetApartmentState(ApartmentState.STA);
							play.Start();
							//dispatcher.Game.Player.Play();
							continue;
						}
						if(texte.StartsWith("pay"))
						{
                            try
                            {
                                texte = texte.Remove(0, 4);
                                long fric = (long)Convert.ToInt32(texte);
                                dispatcher.Game.Player.Mise(fric);
                            }
                            catch { }
							continue;
						}
                    

						if(texte.StartsWith("maj"))
						{
                            try
                            {
                                texte = texte.Remove(0, 3);
                                char[] sep = new char[1];
                                sep[0] = ' ';
                                string[] msg = texte.Split(sep);

                                long pot = (long)Convert.ToInt32(msg[0]);
                                long raise = (long)Convert.ToInt32(msg[1]);
                                //jeu.NewRaise(raise);
                                dispatcher.Game.CurrentRaise.Money = raise;
                                dispatcher.Game.MainPot.Money = pot;
                                //jeu.NewPot(pot);
                                this.dispatcher.Form.Setlabel2(pot.ToString());
                                int t = (int)Convert.ToInt32(msg[2]);
                                dispatcher.Game.CurrentTurn = t;
                                long thune = (long)Convert.ToInt32(msg[3 + dispatcher.Game.Player.Id]);
                                dispatcher.Form.Player.Money.Money = thune;
                                //pl.SetMoney(thune);
                                //this.dispatcher.Form.Setlabel1((long ) Convert.ToInt32(thune.ToString()));
                                long diff = raise - dispatcher.Form.Player.TotalRaise.Money;
                                if (diff > 0)
                                    this.dispatcher.Form.Setlabel3(diff.ToString());
                                else this.dispatcher.Form.Setlabel3("0");
                                //on peut recuperer aussi l'argent des autres 
                                this.dispatcher.Form.MiniInfo.ResetList(); // on va récuperer tous noms une seule fois et apres juste le fric
                                for (int i = 3; i < this.dispatcher.GameData.Nbr + 3; i++)
                                {

                                    dispatcher.Game.SetMoney(i - 3, (long)Convert.ToInt32(msg[i]));

                                }
                                this.dispatcher.Game.ShowMoneyInBox();
                                dispatcher.Form.MiniInfo.ShowMoneyInfo();
                            }
                            catch { }
							continue;
						}
						if(texte.StartsWith("private"))
						{
                            try
                            {
                                for (int i = 0; i < this.dispatcher.GameData.Nbr; i++)
                                {
                                    this.dispatcher.Game.EraseHand(i);
                                }
                                texte = texte.Remove(0, 8);
                                char[] sep = new char[1];
                                sep[0] = ' ';
                                string[] msg = texte.Split(sep);
                                dispatcher.Form.Player.Hand.Card1 = new Card((int)Convert.ToInt32(msg[0]));
                                dispatcher.Form.Player.Hand.Card2 = new Card((int)Convert.ToInt32(msg[1]));
                                dispatcher.Form.Card1 = msg[0];
                                dispatcher.Form.Card2 = msg[1];
                                dispatcher.Form.SetCard1();
                                dispatcher.Form.SetCard2();
                                this.dispatcher.Form.SeeCards();
                                this.dispatcher.Form.GameEvents.AddOwnDia("You get "+ dispatcher.Form.Player.Hand.Card1.Name + " " + dispatcher.Form.Player.Hand.Card1.Color + " " + dispatcher.Form.Player.Hand.Card2.Name + " " + dispatcher.Form.Player.Hand.Card2.Color + "\n");
		
                                dispatcher.Form.GameEvents.AddPicture(new Card[] { dispatcher.Form.Player.Hand.Card1, dispatcher.Form.Player.Hand.Card2 },false);
                               // dispatcher.Form.GameEvents.AddPicture(dispatcher.Form.Player.Hand.Card2);

                                
                                dispatcher.Form.GameEvents.AddDia("\n"); 

                            }
                            catch { }
							continue;
						}
                        //receive current player
                        if (texte.StartsWith("currentp"))
                        {
                            try
                            {
                                texte = texte.Remove(0, 9);
                                
                                int currentP = Convert.ToInt16(texte);
                                this.dispatcher.Game.CurrentPlayer = currentP;
                                this.dispatcher.Form.MakeBlinkingGroupBox();
                            }
                            catch { }
                        }

                        if (texte.StartsWith("pause on"))
                        {
                            try
                            {
                                this.dispatcher.Game.GamePause = true;
                            }
                            catch { }
                        }
                        if (texte.StartsWith("pause off"))
                        {
                            try
                            {
                                this.dispatcher.Game.GamePause = false;
                            }
                            catch { }
                        }
						if(texte.StartsWith("flop"))
						{
                            try
                            {
                                texte = texte.Remove(0, 5);
                                char[] sep = new char[1];
                                sep[0] = ' ';
                                string[] msg = texte.Split(sep);
                                dispatcher.Game.Board.Flop1 = new Card((int)Convert.ToInt32(msg[0]));
                                dispatcher.Game.Board.Flop2 = new Card((int)Convert.ToInt32(msg[1]));
                                dispatcher.Game.Board.Flop3 = new Card((int)Convert.ToInt32(msg[2]));
                                dispatcher.Form.Card3 = msg[0];
                                dispatcher.Form.Card4 = msg[1];
                                dispatcher.Form.Card5 = msg[2];
                                dispatcher.Form.SetCard3();
                                dispatcher.Form.SetCard4();
                                dispatcher.Form.SetCard5();
                                dispatcher.Form.Player.OwnPot.Money = 0;
                                //dispatcher.Form.GameEvents.AddPicture(new Card[] { dispatcher.Game.Board.Flop1, dispatcher.Game.Board.Flop2, dispatcher.Game.Board.Flop3 });
                                //dispatcher.Form.GameEvents.AddOwnDia("\n");
                                ////dispatcher.Form.GameEvents.AddPicture(dispatcher.Game.Board.Flop1);
                                ////dispatcher.Form.GameEvents.AddPicture(dispatcher.Game.Board.Flop2);
                                ////dispatcher.Form.GameEvents.AddPicture(dispatcher.Game.Board.Flop3);
                                //Thread.Sleep(500);
                                //dispatcher.Form.GameEvents.AddDia("\n");
                               

                            }
                            catch (Exception exception){
                            MessageBox.Show(exception.ToString());
                            }
							continue;
								
						}
						if(texte.StartsWith("turn"))
						{
                            try
                            {
                                texte = texte.Remove(0, 5);
                                char[] sep = new char[1];
                                sep[0] = ' ';
                                string[] msg = texte.Split(sep);
                                dispatcher.Game.Board.Turn = new Card((int)Convert.ToInt32(msg[0]));
                                dispatcher.Form.Card6 = msg[0];
                                dispatcher.Form.SetCard6();
                               // dispatcher.Form.Player.OwnPot.Money = 0;
                                dispatcher.Form.GameEvents.AddPicture(new Card[] { dispatcher.Game.Board.Turn },true);
                              //  dispatcher.Form.GameEvents.AddPicture(dispatcher.Game.Board.Turn);
                                Thread.Sleep(500);
                                dispatcher.Form.GameEvents.AddDia("\n"); 
                            }
                            catch (Exception exception) { MessageBox.Show(exception.ToString()); }

								
							continue;
						}
						if(texte.StartsWith("msg"))
						{
							texte=texte.Remove(0,4);
							dispatcher.Form.Chat.AddChat(texte);
							continue;
						}
						if(texte.StartsWith("relance"))
						{
							
							dispatcher.Game.AddOneRelance();
							continue;
						}
						if(texte.StartsWith("connerie"))
						{
							
							this.dispatcher.Form.Connerie();
							continue;
						}
						if(texte.StartsWith("river"))
						{
                            try
                            {
                                texte = texte.Remove(0, 6);
                                char[] sep = new char[1];
                                sep[0] = ' ';
                                string[] msg = texte.Split(sep);
                                dispatcher.Game.Board.River = new Card((int)Convert.ToInt32(msg[0]));
                                dispatcher.Form.Card7 = msg[0];
                                dispatcher.Form.SetCard7();
                                dispatcher.Form.Player.OwnPot.Money = 0;
                               // dispatcher.Form.GameEvents.AddPicture(new Card[] { dispatcher.Game.Board.River });
                             
                                //dispatcher.Form.GameEvents.AddPicture(dispatcher.Game.Board.River);
                                Thread.Sleep(500);
                                dispatcher.Form.GameEvents.AddDia("\n"); 
                            }
                            catch (Exception exception) { MessageBox.Show(exception.ToString()); }
								
							continue;				
						}
						if(texte.StartsWith("win "))
						{
							texte=texte.Remove(0,4);
                            this.dispatcher.Form.GameEvents.AddOwnDia(texte);
                            this.dispatcher.Form.MakeItBlink = false;
							continue;
						}
						if(texte.StartsWith("dia "))
						{
							texte=texte.Remove(0,4);
							this.dispatcher.Form.GameEvents.AddOwnDia(texte);
							continue;
						}
                        if (texte.StartsWith("5cards "))
                        {
                            texte = texte.Remove(0, 7);
                           
                            char[] sep = new char[1];
                            sep[0] = ' ';
                            char[] supp = new char[2];
                            supp[0] = '\0';
                            supp[1] = ' ';
                            string[] msg = texte.Split(sep);

                            for (int i = 0; i < split.Length; i++)
                            {


                               // dispatcher.Form.GameEvents.AddPicture(new string[] { msg[i].TrimEnd(supp) });
                            
                            }

                            //this.dispatcher.Form.GameEvents.AddOwnDia("\n");







                            continue;
                        }


						//on vire on met une gamedata init a la place
						if(texte.StartsWith("gamedata"))
						{
                            try
                            {
                                texte = texte.Remove(0, 9);
                                char[] sep = new char[1];
                                sep[0] = ' ';
                                string[] msg = texte.Split(sep);



                                dispatcher.GameData.Ante = (long)Convert.ToInt32(msg[0]);
                                dispatcher.GameData.SmallBlind = (long)Convert.ToInt32(msg[1]);
                                dispatcher.GameData.BigBlind = (long)Convert.ToInt32(msg[2]);
                                dispatcher.GameData.Type = (int)Convert.ToInt32(msg[3]);
                                dispatcher.GameData.Max = (long)Convert.ToInt32(msg[4]);
                                dispatcher.GameData.Nbr = (int)Convert.ToInt32(msg[5]);
                                dispatcher.GameData.Money = (long)Convert.ToInt32(msg[6]);
                                dispatcher.GameData.Min = (long)Convert.ToInt32(msg[7]);
                                dispatcher.GameData.Time2Mind = (int)Convert.ToInt32(msg[8]);
                                dispatcher.GameData.TimeIncrease = (int)Convert.ToInt32(msg[9]);
                                dispatcher.Game.PreviousRaise = dispatcher.GameData.Min;
                                try
                                {
                                    dispatcher.Form.ChronoCtr1.ChangeStruct(dispatcher.GameData.Ante + "/" + dispatcher.GameData.SmallBlind + "/" + dispatcher.GameData.BigBlind);
                                }
                                catch { }
                                try
                                {
                                    this.dispatcher.Game.Player.OwnChrono.InitTimeLeft = dispatcher.GameData.Time2Mind;
                                }
                                catch { }
                                    this.dispatcher.Game.NbrPlayerSinceBegin = dispatcher.GameData.Nbr;
                            }
                            catch { }
							continue;										
						}
						if(texte.StartsWith("newturn"))
						{
							//this.dispatcher.Form.Stats=new Stats(this.dispatcher.Game);
                            try
                            {
                                this.dispatcher.Game.EraseAllAction();
                                dispatcher.Game.CurrentRaise.Money = 0;
                                dispatcher.Game.PreviousRaise = dispatcher.GameData.BigBlind;
                                dispatcher.Game.NbrOfRaise = 0;
                                dispatcher.Form.Player.OwnPot.Money = 0;
                                if (this.dispatcher.Game.CurrentTurn == 0)
                                {
                                    dispatcher.Game.Board.Flop1 = null;
                                    dispatcher.Game.Board.Flop2 = null;
                                    dispatcher.Game.Board.Flop3 = null;
                                    dispatcher.Game.Board.Turn = null;
                                    dispatcher.Game.Board.River = null;
                                    dispatcher.Form.ResetCard();

                                    for (int i = 0; i < 10; i++)
                                    {
                                        if (i != dispatcher.Game.Player.Id)
                                        {
                                            this.dispatcher.Game.MakeInVisible(this.dispatcher.Game.GetPlayer(i).ShowCard1);
                                            this.dispatcher.Game.MakeInVisible(this.dispatcher.Game.GetPlayer(i).ShowCard2);
                                        }
                                    }
                                }
                            }
                            catch { }

							continue;
								
						}

                        if (texte.StartsWith("chronoinit"))
                        {
                            try
                            {
                                if (dispatcher.Form.ChronoCtr1 != null)
                                {
                                    dispatcher.Form.ChronoCtr1.InitChrono(dispatcher.Game);

                                    dispatcher.Form.ChronoCtr1.Invoke(new MakeVisibleHandler(dispatcher.Form.MakeVisible), new object[] { dispatcher.Form});
                                }
                               
                            }
                            catch { }
                            continue;
                        }

                        //display dealers buttons 
						if(texte.StartsWith("reset"))
						{
                            try
                            {
                                texte = texte.Remove(0, 6).Trim();
                                dispatcher.Form.ResetCard();
                                
                                char[] sep = new char[] { ' ' };
                                string[] spli = texte.Split(sep); 
                                int id = (int)Convert.ToInt32(spli[0]);
                                int sb = (int)Convert.ToInt32(spli[1]);
                                int bb = (int)Convert.ToInt32(spli[2]);
                                this.dispatcher.Game.CurrentDealer = id;
                            

                                this.dispatcher.Game.ShowDealer();
                              
                            }
                            catch { }
							continue;
						}
                        if (texte.StartsWith("buttons"))
                        {
                            try
                            {
                                texte = texte.Remove(0, 7).Trim();
                               

                                char[] sep = new char[] { ' ' };
                                string[] spli = texte.Split(sep);
                                int id = (int)Convert.ToInt32(spli[0]);
                                int sb = (int)Convert.ToInt32(spli[1]);
                                int bb = (int)Convert.ToInt32(spli[2]);
                                this.dispatcher.Game.CurrentDealer = id;
                                this.dispatcher.Game.CurrentSB = sb;
                                this.dispatcher.Game.CurrentBB = bb;

                                this.dispatcher.Game.ShowDealer();

                                this.dispatcher.Form.ShowDealerbutton();
                                this.dispatcher.Form.ShowBBbutton();
                                this.dispatcher.Form.ShowSBbutton();
                            }
                            catch { }
                            continue;
                        }
						if(texte.StartsWith("user"))
                        {
                            try
                            {
                                texte = texte.Remove(0, 5);
                                char[] sep = new char[1];
                                sep[0] = '§';
                                string[] msg = texte.Split(sep);
                                int id = (int)Convert.ToInt32(msg[0]);
                                this.dispatcher.Game.ShowAction(id, msg[1]);
                            }
                            catch { }
							continue;
						}

						if(texte.StartsWith("loose "))
						{
                            try
                            {
                                texte = texte.Remove(0, 6);
                                int id = (int)Convert.ToInt32(texte);
                                if (id == dispatcher.Game.Player.Id)
                                {
                                    MyMsgBox box = new MyMsgBox(Language.GetOutOfMoneyEvents(), Language.GetOutOfMoneyEvents(), this.dispatcher.Form);
                                    box.Show();
                                    object[] p = new object[1];
                                    p[0] = this.dispatcher.Game.Player.ShowCard1;
                                    this.dispatcher.Game.Player.ShowCard1.Invoke(new MakeVisibleHandler(this.dispatcher.Form.MakeInVisible), p);
                                    p[0] = this.dispatcher.Game.Player.ShowCard2;
                                    this.dispatcher.Game.Player.ShowCard1.Invoke(new MakeVisibleHandler(this.dispatcher.Form.MakeInVisible), p);

                                    dispatcher.Form.ResetCard();
                                }
                                else
                                {
                                    MyMsgBox box = new MyMsgBox(Language.GetPlayerIsOUtofMoneyTitle(), dispatcher.Game.Names(id) + " " + Language.GetOutOfMoneyEvents(),this.dispatcher.Form);
                                    box.Show();
                                    this.dispatcher.Game.MakeInVisible(this.dispatcher.Game.GetPlayer(id).ShowCard1);
                                    this.dispatcher.Game.MakeInVisible(this.dispatcher.Game.GetPlayer(id).ShowCard2);
                                }
                            }
                            catch { }
							continue;
						}
						if(texte.StartsWith("game "))
						{
                            try
                            {
                                texte = texte.Remove(0, 5);
                                char[] sep = new char[1];
                                sep[0] = ' ';
                                string[] msg = texte.Split(sep);

                                for (int i = 0; i < msg.Length; i++)
                                {

                                    dispatcher.Game.InGame(i, (int)Convert.ToInt32(msg[i]));
                                }
                            }
                            catch { }
							continue;    
						}
						if(texte.StartsWith("round "))
						{
                            try
                            {
                                texte = texte.Remove(0, 6);
                                char[] sep = new char[1];
                                sep[0] = ' ';
                                string[] msg = texte.Split(sep);

                                for (int i = 0; i < msg.Length; i++)
                                {
                                    dispatcher.Game.InRound(i, (int)Convert.ToInt32(msg[i]));

                                }
                                this.dispatcher.Form.HideCard();
                            }
                            catch { }
							continue;
						}
						if(texte.StartsWith("names "))
						{
                            try
                            {
                                texte = texte.Remove(0, 6);
                                char[] sep = new char[1];
                                sep[0] = '§';
                                string[] msg = texte.Split(sep);
                                dispatcher.Game.NbrPlayerSinceBegin = (int)Convert.ToInt32(msg[0]);
                                for (int i = 1; i <= (int)Convert.ToInt32(msg[0]); i++)
                                {
                                    dispatcher.Game.Names(i - 1, msg[i]);
                                    this.dispatcher.Game.GetPlayer(i - 1).Name = msg[i];
                                }
                                this.dispatcher.Game.ShowNameInBox();
                            }
                            catch { }
							continue;
						}
						if(texte.StartsWith("cards "))
						{
                            try
                            {
                                texte = texte.Remove(0, 6);
                                char[] sep = new char[1];
                                sep[0] = ' ';
                                string[] msg = texte.Split(sep);
                                int id = (int)Convert.ToInt32(msg[0]);
                                string card2 = msg[2];
                                char[] supp = new char[1];
                                supp[0] = '\0';
                                //card2=card2.Substring(0,4);
                                card2 = card2.TrimEnd(supp);
                                this.dispatcher.Form.ShowCards(id, msg[1], card2);
                            }
                            catch { }
							continue;
						}
						if(texte.StartsWith("stats"))
						{
                            try
                            {
                                if (this.dispatcher.Form.Stats != null)
                                    this.dispatcher.Form.Stats.Close();
                                this.dispatcher.Form.Stats = new Stats(this.dispatcher.Game);
                                texte = texte.Remove(0, 7);
                                char[] sep = new char[1];
                                sep[0] = '§';
                                string[] msg = texte.Split(sep);
                                if (this.dispatcher.Form.Stats.StatsStock != null)
                                    this.dispatcher.Form.Stats.StatsStock.Clear();
                                else
                                    this.dispatcher.Form.Stats.StatsStock = new ArrayList(100);
                                this.dispatcher.Form.Stats.StatsStock.AddRange(msg);
                                this.dispatcher.Form.Stats.RefreshMeNet();
                            }
                            catch { }
							continue;
							
							
						}
						if(texte.StartsWith("refresh"))
						{
							if(this.dispatcher.Form.Odds.Visible)
								this.dispatcher.Form.Odds.ComputeOdds();
							continue;
						}
						if(texte.StartsWith("save"))
                        {
                            try
                            {
                                texte = texte.Remove(0, 4);
                                char[] sep = new char[1];
                                sep[0] = '§';
                                string[] msg = texte.Split(sep);
                                this.dispatcher.Profil.GamesPlayed++;
                                if (msg[0].Equals("1"))
                                    this.dispatcher.Profil.AllIn++;
                                if (msg[1].Equals("1"))
                                    this.dispatcher.Profil.AllInWon++;
                                if (msg[2].Equals("1"))
                                    this.dispatcher.Profil.GamesWon++;
                                if (msg[3].Equals("1"))
                                    this.dispatcher.Profil.PayedFlop++;
                                if (msg[4].Equals("1"))
                                    this.dispatcher.Profil.Showdowns++;
                                if (msg[6].Equals("1"))
                                    this.dispatcher.Profil.WonWithoutShow++;
                                int take = (int)Convert.ToInt16(msg[5]);
                                this.dispatcher.Profil.TakeDowns += take;
                                long money = (long)Convert.ToInt32(msg[7]);
                                this.dispatcher.Profil.MoneyWon += money;
                                this.dispatcher.Profil.Save();
                            }
                            catch { }
                            continue;
						}
					}
				}		
			}
			else
			{
				dispatcher.Form.GameEvents.AddOwnDia("host not found\n");
			}
            UpdateForm();
			//this.dispatcher.Form.Update();
			
		}
        public void UpdateForm() {

            object[] p = new object[1];
            p[0] = this.dispatcher.Form;
            this.dispatcher.Form.Invoke(new DelegateFormUpdate(UpdateForm2), p);

        }
        private void UpdateForm2(Control c) {
            this.dispatcher.Form.Update();
        
        }

        private delegate void DelegateFormUpdate(Control c);
		public string Ip
		{
			get{return ip;}
			set{ip=value;}
		}
		public int Port
		{
			get{return port;}
			set{port=value;}
		}
		public int Nbr
		{
			get{return this.nbr_socket;}
			
		}
		public void SendToServer(string texte)
		{
			if(texte.CompareTo("")==0)
			{
				return;
			}
			try 
			{
				if(ns != null) // on regarde si l'objet est créé ou non
				{
					//tableau de bytes pour recevoir les donnée du serveur
					Byte[] outbytes = System.Text.Encoding.Unicode.GetBytes(texte.ToCharArray());
					lock(ns)
					{
						// reception des données du serveur
						ns.Write(outbytes,0,outbytes.Length);
					}
				}
                //else // si l'objet n'est pas crée
                //{
                //    MyMsgBox box=new MyMsgBox("Not connected to host");
                //    box.Show();
                //}
			}
			catch//(Exception e) // en cas d'erreur
			{
				stop = false;
				if(clientsocket!=null)
					clientsocket.Close();
				if(ns!=null)
					ns.Close();
			
			}
		}
		public bool IsConnected()
		{
			return connected;
		}
		public Thread Threadconnect()
		{
			return threadconnect;
		}
		public Thread Th
		{
			get {return th;}
		}
		public TcpListener SockEc()
		{
			return socket_ecoute;
		}
		
		public void WaitForOtherPlayers(bool b)
		{
		
			wait=b;
		}
		private Thread threadconnect;
		private bool connected=false;
		private int port = 2564;
		private bool wait=true;
		private string ip="";
		private bool stop = true;
        /// <summary>
        /// stop all communication 
        /// </summary>
        public void Stop() {

            stop = false;
            wait = false;
        }
		private Socket[] mySockets;
		private int nbr_socket=0;
		private TcpListener socket_ecoute;
		private Dispatcher dispatcher;
		private Thread th;
		private NetworkStream ns;
		private TcpClient clientsocket;
		private bool everdo=true;
	}
}
