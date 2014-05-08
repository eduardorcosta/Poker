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
using System.Data;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;

// les cartes sont dans un deck,cartes numérotées de 1 à 52
//  1  AS    11 J   12 Q  13 K
//  de 1 à 13  valeur normale   couleur coeur
//  de 14 à 26     pour valeur -13 couleur carreau
//  de 27 à 39     pour valeur -26 couleur pique
//  de 40 à 52     pour valeur -39 couleur trèfle  
// combi valeur de 8(quinte flush) à 0 (simple)

// players  tableau des joueurs de taille nbrPlayerSinceBegin
// playerInRound  tableau de taille nbrPlayerSinceBegin, indiquant si le players i est dans la partie
//playerInGame idem sauf pour les joueurs avec encore du fric
/*
 * 	case 2:return "diamond ";
				case 3:return "spade ";
				case 4:return "club ";
				case 1:return "heart ";
				*/


namespace poker
{
    /// <summary>
    /// Class to play at Texas Hold'em  
    /// </summary>
    /// 

    public class Game
    {
        private int time2wait = 0;
        /// <summary>
        /// Pause the game when local player has to play 
        /// </summary>
        private bool gamePause = false;

        /// <summary>
        /// tell if the game must be paused
        /// </summary>
        public bool GamePause
        {
            get { return gamePause; }
            set { gamePause = value; }
        }
        public int GameSpeed
        {
            get { return time2wait; }
            set { time2wait = value; }
        }
        private ChronoTimer playerChrono ;
        private int[] probsTab;

        private int formerRaiser = -1;

        public int FormerRaiser
        {
            get { return formerRaiser; }
            set { formerRaiser = value; }
        }
        public int[] ProbsTab
        {
            get { return probsTab; }
            set { probsTab = value; }
        }
        
        private bool anteJustPaid;
        private bool cardDealt = false;
        private bool blindsMusteBeChanged = true;
        private void ComputeBlinds() 
        { 
            
            //if(!dispatcher.GameData.AggrMode.AggressiveModeBool)
            //return;
        if (blindsMusteBeChanged)
        {
            blindsMusteBeChanged = false; ;
            if (this.dispatcher.GameData.AggrMode.AggressiveModeBool) {

                this.GameData.Ante = this.blindsStruc.getAggrAnte();
                this.GameData.SmallBlind = this.blindsStruc.getAggrBlind();
                this.GameData.BigBlind = this.blindsStruc.getAggrBigBlind();
            
            
            }
            else
            {
                this.GameData.Ante = this.blindsStruc.getAnte();
                this.GameData.SmallBlind = this.blindsStruc.getBlind();
                this.GameData.BigBlind = this.blindsStruc.getBigBlind();
            }
            dispatcher.Form.GameEvents.AddDia(Language.GetBlindsChangedEvents() + "\n");

             this.dispatcher.Form.SendGameData();
           
        
        }

        #region former engine
        ////les anciennes valeurs
           //long sb= this.GameData.SmallBlind;
           //long bb= this.GameData.BigBlind;
           //long ant = this.GameData.Ante;
           //int nbplayers = this.NbrPlayerInGame;
           ////les nouvelles valeurs
           //long newsb, newbb, newant;
           // //la moyenne
           //long mean;
            

           //mean = (long) (this.GameData.Money * this.nbrPlayerSinceBegin / nbplayers);

           // // BB =  10 ieme de la moyenne
           //newbb =(long) ( mean / 10);
           //newsb = (long) (newbb / 2);
           //newant = (long)(newsb / 2);


           // //on arrondit les valeurs à 1000
           //if (newbb > 1000)
           //{
              
           //    double nbb = ((double)newbb) / 1000.0;
           //   if (nbb != (double)((long)(newbb) / 1000))
           //    {
           //       long a= newbb / 1000;
           //        long diff = (long) (nbb*1000) - a*1000;
           //        if (diff > 0)
           //        {
           //            newbb += 1000 - diff ;
           //            //while (newbb % 2 != 0)
           //            //    newbb--;
           //            newsb = (long)(newbb / 2);
           //        }
           //    }
           
           
           //}

           // if(ant==0)
           //     newant=0;

           // if (newbb != bb) 
           // {
           //     this.Dispatcher.GameData.BigBlind = newbb;
           //     this.dispatcher.GameData.SmallBlind = newsb;
           //     this.dispatcher.GameData.Ante = newant;

           //     this.CurrentSB = newsb;
           //     this.currentBB = newbb;
           //     dispatcher.Form.GameEvents.AddDia(Language.GetBlindsChangedEvents()+"\n");
             
           //     this.dispatcher.Form.SendGameData();

        // } 

        #endregion



    }

     /// <summary>
     /// Calcul de stats en fct de cartes connus 
     /// </summary>
        public void computeOdds(bool cheat) {

            //Thread th = new ThreadStart(new Thread(oddsThread));
            //th.Start();
            oddsThread( cheat);
        
        }

        Odds odds;

        public Odds Odds
        {
            get { return odds; }
            set { odds = value; }
        }
        private void oddsThread(bool cheat) 
        {
            
             odds = new Odds(this);
            ArrayList players = new ArrayList(10);
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
                players.Add(this.players[i]);

            ProbsTab = odds.CompareHands(players,cheat);
        
        
        }
        public bool CardDealt
        {

            get { return this.cardDealt; }
        }
        public void MakeInvisibleArr(Control[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                this.MakeInVisible(arr[i]);
            }

        }


        //gestion des noms des IAS
        IANames IA_names;

        /// <summary>
        /// build a game
        /// </summary>
        /// <param name="dis"></param>
        /// <param name="nbr">socket number</param>
        public Game(Dispatcher dis, int nbr)//nbr nombre de sockets
           
        {
          
            dispatcher = dis;
            dis.Game = this;
            int p = dis.GameData.Nbr;
            money = new long[10];
            if (GameData.AggrMode.AggressiveModeBool)
                nbr = 0; // pas de connexion reseau en survival
            nbr_socket = nbr;
            pot = new Pot(0);
            deck = new Deck();
            currentRaise = new Pot(0);
            board = new CommunityCards();
            this.totalRaise = new Pot(0);
            nbrPlayerInGame = p;
            playerInGame = new int[p];
            nbrPlayerInRound = p;
            playerInRound = new int[p];
            dis.Form.HideAll();
            nbrPlayerSinceBegin = p;
            players = new Player[p];
            //local host is in position
            this.player = new LocalPlayer(dispatcher.GameData.Name, dispatcher.GameData.Money, this, 0);
            players[0] = this.player;


            RequestInfo();

            IA_names = new IANames();
            CreateIA();
            for (int i = 0; i < p; i++)
            {
                playerInGame[i] = 1;
                playerInRound[i] = 1;
            }
            //add
            dispatcher.Form.SetPlayer(player);
            dispatcher.Form.Setlabel1(players[0].Money.Money);//?? pas a sa place
            //set correct box to players
            SetInfo();
            //fill money and name infos into that
            FillInfo();
            ActualizeGame();
            ActualizeRound();
            ActualizeNames();
        }


        private void AnotherLevelInSurvival()
        {
            IA_names.EmptyAlreadyKnown();
            this.player.Money.Money = this.GameData.Money;
            this.nbrPlayerInGame = this.NbrPlayerInRound = this.nbrPlayerInRoundWithMoney = this.nbrPlayerSinceBegin;
            CreateIA();
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                playerInGame[i] = 1;
                playerInRound[i] = 1;
            }
            //add
            dispatcher.Form.SetPlayer(player);
            dispatcher.Form.Setlabel1(players[0].Money.Money);
            //set correct box to players
            SetInfo();
            //fill money and name infos into that
            FillInfo();
            ActualizeGame();
            ActualizeRound();
            ActualizeNames();
            this.blindsStruc.State = 0;
            blindsMusteBeChanged = true;
            this.dispatcher.Form.ChronoCtr1.ChangeStruct(this.blindsStruc.getAggrAnte()+"/"+this.blindsStruc.getAggrBlind() + "/" + this.blindsStruc.getAggrBigBlind());
            this.dispatcher.Form.ChronoCtr1.InitChrono(this);   
        
        }
        //to do mettre un invoke
        /// <summary>
        /// display all information 
        /// </summary>
        private void FillInfo()
        {
            for (int i = 0; i < this.NbrPlayerSinceBegin; i++)
            {
                Addtext(players[i].MoneyLabel, players[i].Money.Money.ToString() + "$");
               // players[i].MoneyLabel.Text = players[i].Money.Money.ToString() + "$";
                if (players[i].Name.CompareTo(players[i].Box.Text) != 0)
                    Addtext(players[i].Box, players[i].Name);
            }
        }

        /// <summary>
        /// build game without socket
        /// </summary>
        /// <param name="dis"></param>
        public Game(Dispatcher dis)
        {
            playerChrono = new ChronoTimer(this);
            dispatcher = dis;
            players = new Player[10];
            for (int i = 0; i < 10; i++)
            {
                players[i] = new LocalPlayer(dis.GameData.Name, 0, this, i);
            }

            money = new long[10];
            names = new string[10];
            dispatcher.Game = this;
            pot = new Pot(0);
            currentRaise = new Pot(0);
            board = new CommunityCards();
            nbrPlayerInGame = 10;
            playerInGame = new int[10];
            nbrPlayerInRound = 10;
            playerInRound = new int[10];
            nbrPlayerSinceBegin = 10;

        }
        /// <summary>
        /// create IA player if necessary
        /// </summary>
        private void CreateIA()
        {
            bool cheaterChosen = false;
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int id = rnd.Next(dispatcher.GameData.Nbr);
            if (id == 0) id = 1;
            for (int i = nbr_socket + 1; i < dispatcher.GameData.Nbr; i++)
            {
           


                if (i == nbr_socket + 1)
                {
                    if (this.GameData.HardcoreMode)
                    {
                        if (i == id)
                            cheaterChosen = true;
                    }

                    players[i] = new IA(IA_names.pickAname(), 34, 45, 43, dispatcher.GameData.Money, this, i, cheaterChosen);
                    cheaterChosen = false;
                }
                if (i == nbr_socket + 2)
                {
                    if (this.GameData.HardcoreMode)
                    {
                        if (i == id)
                            cheaterChosen = true;
                    }
                    players[i] = new IA(IA_names.pickAname(), 34, 45, 43, dispatcher.GameData.Money, this, i, cheaterChosen);
                    cheaterChosen = false;
                }
                if (i == nbr_socket + 3)
                {
                    if (this.GameData.HardcoreMode)
                    {
                        if (i == id)
                            cheaterChosen = true;
                    }
                    players[i] = new IA(IA_names.pickAname(), 34, 45, 43, dispatcher.GameData.Money, this, i, cheaterChosen);
                    cheaterChosen = false;
                }
                if (i == nbr_socket + 4)
                {
                    if (this.GameData.HardcoreMode)
                    {
                        if (i == id)
                            cheaterChosen = true;
                    }
                    players[i] = new IA(IA_names.pickAname(), 34, 45, 43, dispatcher.GameData.Money, this, i, cheaterChosen);
                    cheaterChosen = false;
                }
                if (i == nbr_socket + 5)
                {
                    if (this.GameData.HardcoreMode)
                    {
                        if (i == id)
                            cheaterChosen = true;
                    }
                    players[i] = new IA(IA_names.pickAname(), 34, 45, 43, dispatcher.GameData.Money, this, i, cheaterChosen);
                    cheaterChosen = false;
                }
                if (i == nbr_socket + 6)
                {
                    if (this.GameData.HardcoreMode)
                    {
                        if (i == id)
                            cheaterChosen = true;
                    }
                    players[i] = new IA(IA_names.pickAname(), 34, 45, 43, dispatcher.GameData.Money, this, i, cheaterChosen);
                    cheaterChosen = false;
                }
                if (i == nbr_socket + 7)
                {
                    if (this.GameData.HardcoreMode)
                    {
                        if (i == id)
                            cheaterChosen = true;
                    }
                    players[i] = new IA(IA_names.pickAname(), 34, 45, 43, dispatcher.GameData.Money, this, i, cheaterChosen);
                    cheaterChosen = false;
                }
                if (i > nbr_socket + 7)
                {
                    if (this.GameData.HardcoreMode)
                    {
                        if (i == id)
                            cheaterChosen = true;
                    }
                    players[i] = new IA(IA_names.pickAname(), 34, 45, 43, dispatcher.GameData.Money, this, i, cheaterChosen);
                    cheaterChosen = false;
                }

                ((IA)players[i]).Bot_type = rnd.Next(1, 5);
                  
              
            }
        }
        /// <summary>
        /// display money of each player
        /// </summary>
        public void ShowMoneyInBox()
        {
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                if (this.InGame(i) == 1)
                {
                    Addtext(this.players[i].MoneyLabel, this.money[i].ToString() + "$");
                }


            }

        }
        /// <summary>
        /// add text with an invoke
        /// </summary>
        /// <param name="c">control </param>
        /// <param name="s">texte to add</param>
        public void Addtext(Control c, string s) {
            try
            {
                object[] p = new object[1];
                txt_swap = s;
                p[0] = c;
                c.Invoke(new DelegateAddtext(AddTextInvoke), p);
            }
            catch { }
        
        }
        private string txt_swap; 
        private delegate void DelegateAddtext(Control c);
        private void AddTextInvoke(Control c) {

            c.Text = txt_swap;
        
        }
        /// <summary>
        /// display player's name
        /// </summary>
        public void ShowNameInBox()
        {
            object[] p = new object[1];
         
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                if (this.players[i].Box.Text.CompareTo(this.names[i]) != 0)
                {
                    txt_swap = this.names[i];
                    p[0] = this.players[i].Box;
                    this.players[i].Box.Invoke(new DelegateAddtext(AddTextInvoke), p);
           

                }


            }

        }
        public void SetMoney(int i, long mo)
        {
            money[i] = mo;

        }
        /// <summary>
        /// set the min raise and max depending on game type depending on the current player
        /// </summary>
        public void ActualizeMinMax()
        {
            switch (dispatcher.GameData.Type)
            {
                case 3: switch (this.currentTurn)
                    {
                        case 0:
                        case 1: dispatcher.GameData.Min = dispatcher.GameData.BigBlind;
                            dispatcher.GameData.Max = dispatcher.GameData.BigBlind; break;
                        default: dispatcher.GameData.Min = 2 * dispatcher.GameData.BigBlind;
                            dispatcher.GameData.Max = 2 * dispatcher.GameData.BigBlind; break;

                    }
                    break;
                case 2: dispatcher.GameData.Min = this.PreviousRaise;
                    dispatcher.GameData.Max = (this.MainPot.Money > this.money[currentPlayer]) ? this.money[currentPlayer] : this.MainPot.Money;
                    break;
                default: dispatcher.GameData.Min = this.PreviousRaise;
                    dispatcher.GameData.Max = this.money[currentPlayer];
                    if (dispatcher.GameData.Max < dispatcher.GameData.Min)
                        dispatcher.GameData.Min = dispatcher.GameData.Max;
                    break;





            }
            dispatcher.Form.ChangeScroll(dispatcher.GameData.Min, dispatcher.GameData.Max);
            
        }
        /// <summary>
        /// set the min raise and max depending on game type depending on the i player
        /// </summary>
        /// <param name="i"></param>
                 public void ActualizeMinMax(int i)
        {
            switch (dispatcher.GameData.Type)
            {
                case 3: switch (this.currentTurn)
                    {
                        case 0:
                        case 1: dispatcher.GameData.Min = dispatcher.GameData.BigBlind;
                            dispatcher.GameData.Max = dispatcher.GameData.BigBlind; break;
                        default: dispatcher.GameData.Min = 2 * dispatcher.GameData.BigBlind;
                            dispatcher.GameData.Max = 2 * dispatcher.GameData.BigBlind; break;

                    }
                    break;
                case 2: dispatcher.GameData.Min = this.PreviousRaise;
                    dispatcher.GameData.Max = (this.MainPot.Money > this.money[i]) ? this.money[i] : this.MainPot.Money;
                    break;
                default: dispatcher.GameData.Min = this.PreviousRaise;
                    dispatcher.GameData.Max = this.money[i];
                    if (dispatcher.GameData.Max < dispatcher.GameData.Min)
                        dispatcher.GameData.Min = dispatcher.GameData.Max;
                    break;





            }
           dispatcher.Form.ChangeScroll(dispatcher.GameData.Min, dispatcher.GameData.Max);
            this.Dispatcher.Form.SendGameData();
        }
        public long GetMoney(int i)
        {
            return money[i];
        }
        public string Names(int i)
        {
            return names[i];
        }
        public int InRound(int i)
        {
            return this.playerInRound[i];
        }
        public int InGame(int i)
        {
            return this.playerInGame[i];
        }
        /// <summary>
        /// ask others players their name
        /// </summary>
        private void RequestInfo()
        {

            for (int i = 0; i < nbr_socket; i++)
            {
                //request user info
                int a = i + 1;
                string message = "{init" + a;
                byte[] buffer = System.Text.Encoding.Unicode.GetBytes(message.ToCharArray());
                // on envoie le texte au client
              
                players[i + 1] = new NetworkPlayer(i + 1, dispatcher.Communication.GetSocket(i), "Network Player", dispatcher.GameData.Money, dispatcher.Form, this);
                dispatcher.Communication.SendToSocket(i, buffer);
                Thread.Sleep(1000); // on attend un peu
            }

        }
        public void SetInfo()
        {
            for (int i = 0; i < this.NbrPlayerSinceBegin; i++)
            {
                this.Dispatcher.Form.BuildVisualInfos(players[i]);

            }

        }
        /// <summary>
        /// save names and actualize to everyboody
        /// </summary>
        public void ActualizeNames()
        {
            string msg = "{names " + this.nbrPlayerSinceBegin.ToString() + "§";
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {

                msg += players[i].Name + "§";
            }
            dispatcher.Communication.SendBroadCast(msg);
        }
        /// <summary>
        /// add money to the pot
        /// </summary>
        /// <param name="p"></param>
        public void AddPot(long p)
        {

            pot.AddMoney(p);
        }
        /// <summary>
        /// pot =0
        /// </summary>
        public void ResetPot()
        {

            pot.ResetMoney();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        public void AddRaise(long r)
        {


            currentRaise.AddMoney(r);
            totalRaise.AddMoney(r);
        }
        public long GetPot()
        {
            return pot.Money;
        }
        /// <summary>
        /// reste raise /turn =0/pot
        /// </summary>
        private void ReInit()
        {
            ResetPot();
            currentRaise.ResetMoney();
            currentTurn = 0;
            
        }
        /// <summary>
        /// get player c
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public Player GetPlayer(int c)
        {

            return players[c];

        }
        /// <summary>
        /// delete player p from round 
        /// </summary>
        /// <param name="p"></param>
        public void ErasePlayerRound(int p)
        {

            playerInRound[p] = 0;
            nbrPlayerInRound--;
            nbrPlayerInRoundWithMoney--;
            dispatcher.Form.GameEvents.AddDia(players[p].Name + " "+Language.GetfoldsEvents() +"\n");
            this.dispatcher.Form.MakeVisibleInvoke(players[p].HiddenCard1, false);
            this.dispatcher.Form.MakeVisibleInvoke(players[p].HiddenCard2, false);

           // players[p].HiddenCard1.Visible = false;
           // players[p].HiddenCard2.Visible = false;
            ActualizeRound();

        }
        /// <summary>
        /// actualize raise /pot /money to broadcast
        /// </summary>
        private void ActualizeData()
        {
            dispatcher.Form.Setlabel1(this.Dispatcher.Form.Player.Money.Money);

            string msg = "{maj" + pot.Money.ToString() + " " + currentRaise.Money + " " + currentTurn;
            ShowMoney();
            for (int i = 0; i < nbrPlayerSinceBegin; i++)
            {
                msg += " " + players[i].Money.Money.ToString();
                this.money[i] = players[i].Money.Money;
            }
            dispatcher.Communication.SendBroadCast(msg);
        }
        /// <summary>
        /// delete a player from the game 
        /// </summary>
        /// <param name="j"></param>
        private void ErasePlayerFromGame(int j)
        {
            this.Dispatcher.Form.Media.Lose(j);
            playerInGame[j] = 0;
            playerInRound[j] = 0;
            nbrPlayerInGame--;
           // nbrPlayerInRound--;
            this.dispatcher.Form.Media.OutOfMoney();
            dispatcher.Form.GameEvents.AddDia(players[j].Name + " "+Language.GetOutOfMoneyEvents()+"\n");
            if (dispatcher.Speaker != null)
            {
                dispatcher.Speaker.Talk(players[j].Name + " "+Language.GetOutOfMoneyEvents() + "\n");
            }
            ActualizeGame();
        }
        //retourne le ou les identifiants du ou des players avec la meilleure main
       /// <summary>
       /// seek best hand(s) 
       /// </summary>
       /// <returns></returns>
        private ArrayList SeekBestPlayer()
        {
            FillInfo();
           // dispatcher.Form.Update();
            ArrayList draw = new ArrayList(10);
            Hand max = null;
            int bestplayer = -1;
            for (int j = 0; j < this.nbrPlayerSinceBegin; j++)
            {
                if (playerInRound[j] == 1)
                {
                    if (max == null || players[j].Hand > max)
                    {
                        max = players[j].Hand;
                        bestplayer = j;
                    }
                }
            }
            draw.Add(bestplayer);//current best Hand   
            //looking for same hand 
            for (int j = 0; j < this.nbrPlayerSinceBegin; j++)
            {
                if (playerInRound[j] == 1 && bestplayer != j)
                    if (players[j].Hand == max)
                    {
                        draw.Add(j);
                    }
            }
            //analyse des cas d'égalité
            return draw;


        }
        /// <summary>
        /// display final hand 
        /// </summary>
        public void ShowFinalBoard()
        {
            string msg = "{dia ";
            msg +=  Language.GetBoardToEvents() +" : ";

            for (int i = 1; i <= 5; i++)
            {
                msg += board.GetCard(i).Name + " ";
                msg += board.GetCard(i).Color;
                if (i != 5)
                    msg += ", ";
                else msg += ".";
        
            }
            msg += "\n";
            dispatcher.Form.GameEvents.AddDia(msg.Remove(0, 5));
            dispatcher.Communication.SendBroadCast(msg);
            this.dispatcher.Form.GameEvents.AddPicture(new Card[] { this.board.Flop1, this.board.Flop2, this.board.Flop3, this.board.Turn, this.board.River },true);
            //this.dispatcher.Form.GameEvents.AddPicture(this.board.Flop2);
            //this.dispatcher.Form.GameEvents.AddPicture(this.board.Flop3);
            //this.dispatcher.Form.GameEvents.AddPicture(this.board.Turn);
            //this.dispatcher.Form.GameEvents.AddPicture(this.board.River);
            this.dispatcher.Form.GameEvents.AddDia("\n");
            this.Dispatcher.Communication.SendBroadCast("{5cards " + this.board.Flop1.ValueR + this.board.Flop1.AbsColorL + " " + this.board.Flop2.ValueR + this.board.Flop2.AbsColorL + " " + this.board.Flop3.ValueR + this.board.Flop3.AbsColorL + " " + this.board.Turn.ValueR + this.board.Turn.AbsColorL + " " + this.board.River.ValueR + this.board.River.AbsColorL);
          
        }
        //evaluate everybody hand
        private void EvaluateFinalHands()
        {

            for (int j = 0; j < nbrPlayerSinceBegin; j++)
            {
                //long valhand=0;
                if (this.playerInRound[j] == 1)
                    players[j].Hand.EvaluateHand();

                //	handList[j]=valhand;


            }

        }
        /// <summary>
        /// seek if someone bettoo many $$$
        /// </summary>
        private void LookingForTooMuchMoney()
        {
            int accu = 0; //si l'accu vaut 1 c'est qu'un mec a trop payé
            int max = -1; //id of the current max betting player
            long second = -1;//second max
            long totalR = 0;//max of bet for a player
            for (int j = 0; j < nbrPlayerSinceBegin; j++)
            {
                //if (playerInRound[j] == 1)
                
                    if (players[j].TotalRaise.Money >= totalR)
                    {
                        second = totalR;
                        totalR = players[j].TotalRaise.Money;
                        max = j;
                    }

                    else second = players[j].TotalRaise.Money > second ? players[j].TotalRaise.Money : second;
            }
            for (int j = 0; j < nbrPlayerSinceBegin; j++)//Is the max player alone?
            {
                if (playerInRound[j] == 1)
                    if (players[j].TotalRaise.Money == totalR)
                    {
                        accu++;
                    }
            }
            if (accu == 1) //One player has put too much money
            {
                //compute the overbetting
                long diff = players[max].TotalRaise.Money - second;
                //return the overbetting to the owner
                players[max].Money.AddMoney(diff);
                //remove it from pot
                pot.RemoveMoney(diff);
         
                //maj of totalraise in game and player object
                players[max].AddTotalRaise(-diff);
                this.totalRaise.Money = second;

            }


        }
        /// <summary>
        /// display survivors cards
        /// </summary>
        public ArrayList ShowSurvivorCards(bool allInShowdown)
        {
            //liste de ceux qui doivent montrer leur main 
            ArrayList showCards = new ArrayList(10);

            //à partir du dernier raiser ou better, on montre les mains des meilleurs avec une boucle 
            //tant qu'une main n'est pas meilleure
            if (playerInRound[lastRaiser] == 0)
            //erreur comment le dernier raiser peut etre hors parti? 
                //en cas de all in ne faisant pas un raise legal et que le last raiser se couche..
            {

                bool change = false;

                if (formerRaiser >= 0 && playerInRound[formerRaiser] != 0)
                {
                    lastRaiser = formerRaiser;
                }
                else{
                // coup d'un allin   (raise pas valide) payé
                if (this.allinNonRaise != -1 && playerInRound[allinNonRaise] != 0)
                {
                    lastRaiser = allinNonRaise;
                }
                }

                //verifie si les corrects sont bonnes
                if (playerInRound[lastRaiser] == 0)

                    lastRaiser = 0;
                for (int i = lastRaiser + 1; !change && i < this.nbrPlayerSinceBegin; i++)
                {
                    if (playerInRound[i] == 1)
                    {
                        lastRaiser = i;
                        change = true;
                    }
                }
                for (int i = 0; !change && i < lastRaiser; i++)
                {
                    if (playerInRound[i] == 1)
                    {
                        lastRaiser = i;
                        change = true;
                    }
                }
            
            }
            Hand best = players[lastRaiser].Hand;
            int boucle = 0;
            for (int i = this.LastRaiser; ; i++)
            {
                if (i == this.LastRaiser) boucle++;
                if (boucle > 1) break;
                if (this.playerInRound[i] == 1)
                {
                    if (!allInShowdown)
                    {
                        if (players[i].Hand < best)
                        {
                            if (!allInShowdown)
                            {
                                this.Dispatcher.Form.GameEvents.AddDia(players[i].Name + " " + Language.GetMucks() + "\n");
                                players[i].Profil.Show = false;
                            }

                            //don't need to show his hand
                            if (i + 1 >= this.NbrPlayerSinceBegin)
                                i = -1;
                            continue;

                        }
                    }
                    Card c1 = players[i].Hand.Card1;
                    Card c2 = players[i].Hand.Card2;
                    showCards.Add(i);
                    players[i].ShowCard1.Image = new Bitmap(Application.StartupPath + "\\cards\\" + c1.ValueR + c1.AbsColorL + ".png");
                    players[i].ShowCard2.Image = new Bitmap(Application.StartupPath + "\\cards\\" + c2.ValueR + c2.AbsColorL + ".png");
                    players[i].Profil.Show = true ;

                    this.dispatcher.Form.MakeVisibleInvoke(players[i].ShowCard2, true);
                    this.dispatcher.Form.MakeVisibleInvoke(players[i].ShowCard1, true);
                    this.Dispatcher.Communication.SendBroadCast("{cards " + i + " " + c1.ValueR + c1.AbsColorL + " " + c2.ValueR + c2.AbsColorL);
                    this.Dispatcher.Form.GameEvents.AddDia(players[i].Name + " " +Language.GetHasEvents()+ " " + players[i].Hand.Card1.CompleteName()+ " "+Language.GetAnd() +" "+
                     players[i].Hand.Card2.CompleteName()  + " " +Language.GetSoItIsAEvents()+ " " + players[i].Hand.HandName + "\n");
                    this.dispatcher.Form.GameEvents.AddPicture(new Card[] { players[i].Hand.Hand1, players[i].Hand.Hand2, players[i].Hand.Hand3, players[i].Hand.Hand4, players[i].Hand.Hand5 },true);
            
                    //this.dispatcher.Form.GameEvents.AddPicture(players[i].Hand.Hand1);
                    //this.dispatcher.Form.GameEvents.AddPicture(players[i].Hand.Hand2);
                    //this.dispatcher.Form.GameEvents.AddPicture(players[i].Hand.Hand3);
                    //this.dispatcher.Form.GameEvents.AddPicture(players[i].Hand.Hand4);
                    //this.dispatcher.Form.GameEvents.AddPicture(players[i].Hand.Hand5);
                    this.Dispatcher.Communication.SendBroadCast("{5cards " + players[i].Hand.Hand1.ValueR + players[i].Hand.Hand1.AbsColorL + " " + players[i].Hand.Hand2.ValueR + players[i].Hand.Hand2.AbsColorL + " " + players[i].Hand.Hand3.ValueR + players[i].Hand.Hand3.AbsColorL + " " + players[i].Hand.Hand4.ValueR + players[i].Hand.Hand4.AbsColorL + " " + players[i].Hand.Hand5.ValueR + players[i].Hand.Hand5.AbsColorL);
                    dispatcher.Form.GameEvents.AddDia("\n-------------------------------------\n");
           
                  

                    Thread.Sleep(1000);
                    if (i + 1 >= this.NbrPlayerSinceBegin)
                        i = -1;

                }
                else
                    if (i + 1 >= this.NbrPlayerSinceBegin)
                        i = -1;
            }
            return showCards;
        }
        /// <summary>
        /// update money lost
        /// </summary>
        private void UpdateMoneyLost()
        {
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                this.players[i].Profil.MoneyWon -= this.player.TotalRaise.Money;
            }
        }
        /// <summary>
        /// upadte money won 
        /// </summary>
        /// <param name="a"></param>
        private void UpdateMoneyWon(long a)
        {

            this.player.Profil.MoneyWon = a;

        }
        /// <summary>
        /// analyze survivors to do correct  ApplyWin(actbest); when splitted or multipot
        /// </summary>
        public void SeekSurvivor()
        {
            this.dispatcher.Form.ReinitGroupBox();
           
            bool allinShowdown = false;
            ShowMoney();
            Card b1, b2, b3, b4, b5;
            ArrayList best;
            ArrayList actbest = new ArrayList(10);//liste des vrais gagnants
            ArrayList valueWon = new ArrayList(10); // liste de l'argent qu'ils ont gagné
            int[] egalite = new int[nbrPlayerInGame];
            long[] handList = new long[nbrPlayerSinceBegin];
          
            for (int k = 0; k < this.nbrPlayerSinceBegin; k++)
            {
                if (this.playerInRound[k] == 1 && this.nbrPlayerInRound != 1)
                {
                   players[k].Profil.Showdowns++;
                }
            }
            //  players have to get private cards
            //if(!privcards)
            if (!this.cardDealt)
                this.DealPrivateCard();

            if ((this.NbrPlayerInRoundWithMoney <= 1 && this.nbrPlayerInRound != 1) || (this.nbrPlayerInRound != 1 && (board.Flop1 == null || board.River == null || board.Turn == null)))
            {
                allinShowdown = true;
                //everybody show his hand
                ShowEveryBodyInGame();
                DisplayOddsShowdown();

                if (board.Flop1 == null)
                {
                    Thread.Sleep(5000);
                    DealFlop();
                   
                    dispatcher.Form.GameEvents.AddDia(Language.GetFlopEvents() + " : " );//+ this.board.Flop1.CompleteName()+ ", " + this.board.Flop2.CompleteName() + ", " + this.board.Flop3.CompleteName()+" \n");
                    dispatcher.Form.GameEvents.AddPicture(new Card[] { this.Board.Flop1, this.Board.Flop2, this.Board.Flop3 },true);
                    //dispatcher.Form.GameEvents.AddDia(" ");
                    //dispatcher.Form.GameEvents.AddPicture(this.Board.Flop2);
                    //dispatcher.Form.GameEvents.AddDia(" ");
                    //dispatcher.Form.GameEvents.AddPicture(this.Board.Flop3);
                    dispatcher.Form.GameEvents.AddDia("\n");
                    DisplayOddsShowdown();
                    //this.dispatcher.Form.RefreshMe();
                    this.dispatcher.Form.Media.Flop();
                    dispatcher.Communication.SendBroadCast("{flop " + dispatcher.Form.Card3 + " " + dispatcher.Form.Card4 + " " + dispatcher.Form.Card5);
           
                    Thread.Sleep(5000);

                }
                    if (board.Turn == null)
                    {
                        DealTurn();
                       
                       
                       this.dispatcher.Form.Media.Turn();
                        dispatcher.Form.GameEvents.AddDia(Language.GetTurnEvents() + " : " );//+ this.board.Turn.CompleteName() + "\n");
                        dispatcher.Form.GameEvents.AddPicture(new Card[] { this.board.Turn },true);
                        dispatcher.Form.GameEvents.AddDia("\n");
                        DisplayOddsShowdown();
                      //  this.dispatcher.Form.RefreshMe();
                        Thread.Sleep(5000);
                    }
                    if (board.River == null)
                    {
                        DealRiver();
                        
                        dispatcher.Form.GameEvents.AddDia(Language.GetRiverEvents() + " : " );//+ this.board.River.CompleteName()+ "\n");
                        dispatcher.Form.GameEvents.AddPicture(new Card[] { this.board.River },true);
                        dispatcher.Form.GameEvents.AddDia("\n");
                        this.dispatcher.Form.Media.River();
                        DisplayOddsShowdown();
                        //this.dispatcher.Form.RefreshMe();
                        
                        Thread.Sleep(5000);
                    }

            }
            b1 = board.Flop1;
            b2 = board.Flop2;
            b3 = board.Flop3;
            b4 = board.Turn;
            b5 = board.River;
            ArrayList showCards=null;
            long[] winners;
            if (this.nbrPlayerInRound != 1)
            {
                //if(!allinShowdown)

                if (board.Flop1 == null)
                    return;
                ShowFinalBoard();
               
                EvaluateFinalHands();
             
                winners=   ComputePots(allinShowdown);

               
            }
            else
            {
                winners = new long[10];
                best = SeekBestPlayer();
                actbest.Add((int)best[0]);
                players[(int)best[0]].Money.AddMoney(pot.Money);
                moneyWon = pot.Money;
                winners[(int) best[0]] = moneyWon;
                valueWon.Add(moneyWon);
                players[(int)best[0]].Profil.MoneyWon = (pot.Money);
                //////////////////
                players[(int)best[0]].Profil.WonWithoutShow++;
                players[(int)best[0]].Profil.Won++;
                players[(int)best[0]].Profil.IsWinner = true;
                players[(int)best[0]].Profil.Show = false;
                if (players[(int)best[0]].IsAllin)
                    players[(int)best[0]].Profil.AllinsWon++;
                dispatcher.Communication.SendBroadCast("{win " + "Winner " + players[bestPlayer].Name+"\n");
                dispatcher.Form.GameEvents.ChangeColor(Color.Red);
                dispatcher.Form.GameEvents.AddDia(players[(int)best[0]].Name + Language.GetWinsOtherFoldEvents()+"\n " + Language.GetAndWonEvents()+ " " + valueWon[0] + "$\n");
                if(dispatcher.Speaker!=null)
                    dispatcher.Speaker.Talk(players[(int)best[0]].Name + Language.GetWinsOtherFoldEvents() + "\n " + Language.GetAndWonEvents() + " " + valueWon[0] + "$\n");
                dispatcher.Form.GameEvents.ChangeColor(Color.Black);
                dispatcher.Form.GameEvents.AddDia("-------------------------------------\n");
                this.Dispatcher.Form.Media.Success((int)best[0]);	
            }
            dispatcher.Form.Setlabel1(players[0].Money.Money);
            this.pot.ResetMoney();
            currentRaise.ResetMoney();
            for (int j = 0; j < nbrPlayerSinceBegin; j++)
            {
                if (playerInGame[j] == 1)
                    if (players[j].Money.Money <= 0)
                    {
                        for (int k = 0; k < nbrPlayerSinceBegin; k++)
                        {
                            if (winners[k] != 0)
                            {
                                players[k].Profil.TakeDowns++;
                                players[k].Profil.TakedownTurn++;
                                //id du player local
                                if (k == 0)
                                {
                                    this.GameData.AggrMode.NumberOfTakeDowns++;
                                    this.dispatcher.Form.Media.TakeDown();
                                }
                            }
                        }
                        dispatcher.Communication.SendBroadCast("{loose " + j);
                        ErasePlayerFromGame(j);
                    }
            }
            bool alreadyLoose = false;
           // this.dispatcher.Form.UpdateInvoke();
           // Application.DoEvents();
          
           
            if (playerInGame[0] == 0 )
            {
                if(!alreadySaidYouHaveLoose)
                dispatcher.Form.Looze();
                alreadyLoose = true;
                alreadySaidYouHaveLoose = true;
            }
            else
                alreadySaidYouHaveLoose = false;

            ActualizeData();
            //change dealer 
            if (currentDealer + 1 > this.nbrPlayerSinceBegin - 1) 
                currentDealer = -1;

            while (this.playerInGame[++currentDealer] == 0)
            { 
                
                if (currentDealer >= this.nbrPlayerSinceBegin - 1)
                    currentDealer = -1;
            }

            //end of game 
            bool continueGame = true;
            WriteNewStats();
            CheckMoney();
            EraseMoneyLooser();
            ComputeMoneyChecking();
            
            if (playerInGame[0] ==0) // TO DO  CHANGE TO STOP  INTO 0
            {
                continueGame = false;
                if (this.GameData.AggrMode.AggressiveModeBool)
                {
                    this.dispatcher.Form.HideAtEndOfGame();
                    dispatcher.Admin.HideMe();
                    QuestionAboutRanking();
                    this.Dispatcher.Form.Launch = false;
                    this.Dispatcher.Form.ChronoCtr1.HideCtr();
                    return;

                }
                else
                {
                    continueGame = false;
                    for (int k = 1; k < this.nbrPlayerSinceBegin; k++)
                    {
                        if (players[k].GetType().ToString().Contains("NetworkPlayer"))
                            continueGame |= (this.playerInGame[k] == 1);


                    }


                    if (!continueGame)
                    {
                       
                        if (!alreadyLoose)
                        {
                            this.dispatcher.Form.HideAtEndOfGame();
                            dispatcher.Admin.HideMe();
                            WhatWasTheCheater();
                            alreadyLoose = true;
                            MyMsgBox msgBox = new MyMsgBox("", Language.GetNotEnoughPlayerEvents(),this.dispatcher.Form);
                            msgBox.Show();
                        }
                        this.Dispatcher.Form.Launch = false;
                        this.Dispatcher.Form.ChronoCtr1.HideCtr();
                        this.dispatcher.Form.HideAtEndOfGame();
                        return;
                    }

                }
            }

            if (this.nbrPlayerInGame == 1)
            {
                // reactualisation de la table
                if (this.GameData.AggrMode.AggressiveModeBool)
                {
                    this.dispatcher.Form.Media.NextLevel();
                    this.GameData.AggrMode.Level++;
                    this.dispatcher.Form.HideAtEndOfGame();
                    MyMsgBox msgBox = new MyMsgBox("",Language.GetAdvanceToNextEvents(this.GameData.AggrMode.NumberOfTakeDowns), this.dispatcher.Form);
                    msgBox.Show();
                    this.AnotherLevelInSurvival();

                }

                else
                {
                    this.dispatcher.Form.HideAtEndOfGame();
                    dispatcher.Admin.HideMe();
                    WhatWasTheCheater();
                    if (!alreadyLoose)
                    {
                        WhatWasTheCheater();
                        MyMsgBox msgBox = new MyMsgBox( "",Language.GetNotEnoughPlayerEvents(),this.dispatcher.Form);
                        msgBox.Show();
                    }
                    this.Dispatcher.Form.Launch = false;
                    this.Dispatcher.Form.ChronoCtr1.HideCtr();
                 
                   
                      return;
                }

            }
                //this.Dispatcher.Form.UpdateInvoke();
                Thread.Sleep(3000);
                dispatcher.Form.GameEvents.AddDia("\n\n\n");
                try
                {
                    if (Stopgame)
                    {
                        this.dispatcher.Form.HideAtEndOfGame();
                        dispatcher.Admin.HideMe();
                        WhatWasTheCheater();
                        this.Dispatcher.Form.Launch = false;
                        if (this.GameData.AggrMode.AggressiveModeBool)
                        {
                            QuestionAboutRanking();
                        }
                        Stopgame = false;
                        
                        MessageBox.Show(Language.GetGameIsOverEvents(),"");
                        this.Dispatcher.Form.ChronoCtr1.HideCtr();
                        return;
                    }

                    
                    //boucle jeu rec ou it
                    gameplaying = new Thread(new ThreadStart(BoucleJeu));
                  //  th.SetApartmentState(ApartmentState.STA);
                   gameplaying.Name = "GamePlaying";
                    gameplaying.Priority = ThreadPriority.Normal;
                    gameplaying.Start();
                    //BoucleJeu();
                }
                catch (Exception exception){

                    MessageBox.Show(exception.ToString());
                }
            
           
        }
        Thread gameplaying;

        public Thread Gameplaying
        {
            get { return gameplaying; }
            set { gameplaying = value; }
        }

        private void WhatWasTheCheater()
        {
            string cheaters = "";
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {

                if (this.players[i].GetType().ToString().Contains("IA"))
                {

                    if (((IA)this.players[i]).Cheater)
                    {


                        cheaters += this.players[i].Name + "\n";
                    
                    }
                }
            
            }
            if(cheaters!="")
            MessageBox.Show("The cheater was :\n" +cheaters, "Cheater detected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        }
        /// <summary>
        /// Display dynamic stats since opponents cards are known
        /// </summary>
        private void DisplayOddsShowdown()
        {
            //compute odds sur carte visible uniquement
             computeOdds(false);
            //display for each player  % to win 
            this.dispatcher.Form.GameEvents.AddDia("Winning or Equality Stats\n", Color.Red);
            for(int i = 0 ; i < this.NbrPlayerSinceBegin;i++)
            {

                if (0 == InRound(i))
                {

                    continue;
                
                }
               double prob = (double) (ProbsTab[i] *100.0/ (double) Odds.TEST);
                if(prob!=0)
                    this.dispatcher.Form.GameEvents.AddDia(players[i].Name + " : " + prob.ToString("###.##") + "%\n", Color.Red);
                else
               this.dispatcher.Form.GameEvents.AddDia(players[i].Name + " : no chance to win\n", Color.BlueViolet);

              
            }
            dispatcher.Form.GameEvents.AddDia("-------------------------------------\n");
           

        }

        private void ShowFinalBoardWhenShowdown()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// /show every body cards 
        /// </summary>
        private void ShowEveryBodyInGame() {
            for (int i = 0; i < this.NbrPlayerSinceBegin; i++)
            {
                if (this.InRound(i) == 0)
                {
                    players[i].Profil.Show = false;
                    continue;
                }

                Card c1 = players[i].Hand.Card1;
                Card c2 = players[i].Hand.Card2;

                if (players[i].Hand.Card1 == null)
                    return;
                players[i].ShowCard1.Image = new Bitmap(Application.StartupPath + "\\cards\\" + c1.ValueR + c1.AbsColorL + ".png");
                players[i].ShowCard2.Image = new Bitmap(Application.StartupPath + "\\cards\\" + c2.ValueR + c2.AbsColorL + ".png");
                players[i].Profil.Show = true;

                this.dispatcher.Form.MakeVisibleInvoke(players[i].ShowCard2, true);
                this.dispatcher.Form.MakeVisibleInvoke(players[i].ShowCard1, true);
                this.Dispatcher.Communication.SendBroadCast("{cards " + i + " " + c1.ValueR + c1.AbsColorL + " " + c2.ValueR + c2.AbsColorL);

                this.Dispatcher.Form.GameEvents.AddDia(players[i].Name + " " + Language.GetHasEvents() + " " + players[i].Hand.Card1.CompleteName() + " " + Language.GetAnd() + " "
                + players[i].Hand.Card2.CompleteName() +  "\n");
                this.Dispatcher.Form.GameEvents.AddPicture(new Card[]{players[i].Hand.Card1,players[i].Hand.Card2},true);
                 
                
                
                dispatcher.Form.GameEvents.AddDia("\n-------------------------------------\n");
                    
            }
        
        }
        /// <summary>
        /// say if the message box of bankrupt already be displayed
        /// </summary>
        private bool alreadySaidYouHaveLoose = false;
        /// <summary>
        /// tentative de correction d un bug
        /// </summary>
        private void EraseMoneyLooser()
        {

           foreach(Player p in this.players)
           {
               if (p.Money.Money <= 0)
               {
                   p.OwnPot.Money = 0;
                   p.TotalRaise.Money = 0;
                   p.IsAllin = false;
                  
               
               }
           
           }

        }

        private void CheckMoney()
        {long accu=0;
        for (int i = 0; i < this.dispatcher.Game.NbrPlayerSinceBegin;i++ )
        {

            if (this.dispatcher.Game.playerInGame[i] == 1)
            {
                accu += this.players[i].Money.Money;

            }

        }
            if(accu!=dispatcher.Game.NbrPlayerSinceBegin*this.GameData.Money)
     return;
        }
        /// <summary>
        /// multipot and pot splitted
        /// 1/ on crée tous les pots existant par les moneybet, meme ceux des joueurs qui ont quitté le round 
        /// 2/ on trie les montants par ordre croissant 
        /// 3/ on inscrit les joueurs dans leur pots respectifs en ne gardant que les meilleurs mains
        /// 4/  on construit les gains relatifs et on calcule le moneyGain 
        /// 5/ on regarde la plus grde main pour voir si il n'y pas un joueur au dessus des uatres nivo gains (un seul gars dasn le pot max)  
        /// 6/ on construit la liste des winners qui à chaque id_player associe un gain total 
        /// 7/ on attribue les gains à chaque gagnant avec affichage 
        /// </summary>
        /// <returns></returns>
        private long[] ComputePots(bool allinShowdown)
        {
           
            long[] winners=null;
           // 1/ on crée tous les pots existant , meme ceux des joueurs qui ont quitté le round 
            ArrayList winningPots = ComputeEtape1();

           // 2/ on trie les montants par ordre croissant 
            winningPots.Sort(new WinningPotComparer());

            //3/ on inscrit les joueurs dans leurs pots respectifs en ne gardant que les meilleurs mains
            winningPots=ComputeEtape3(winningPots);

            // 4/  on construit les gains relatifs et on calcule le moneyGain 
            winningPots=ComputeEtape4(winningPots);

            // 5/ on regarde la plus grde main pour voir si il n'y pas un joueur au dessus des autres nivo gains (un seul gars dans le pot max) 
           winningPots= ComputeEtape5(winningPots);

            //on en profite pour montrer les cartes, le last raiser doit etre a peu pres bon  (  cas   all in     puis allin plus grand  puis couché , le last raiser est le premier allin
           ShowSurvivorCards(allinShowdown);
            // 6/ on construit la liste des winners qui à chaque id_player associe un gain total 
            winners= ComputeEtape6(winningPots);

            // 7/ on attribue les gains à chaque gagnant avec affichage 
            ComputeEtape7(winners);
            return winners;
        }

        private void ComputeEtape7(long[] winners)
        {
           
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                dispatcher.Form.GameEvents.ChangeColor(Color.Red);
                if (winners[i] == 0)
                    continue;

                   if (players[i].IsAllin)
                        players[i].Profil.AllinsWon++;

                    players[i].Profil.Won++;
                    players[i].Profil.IsWinner = true;

                    string hand = players[i].Hand.HandName;

                    players[i].Profil.MoneyWon+= winners[i];

                    players[i].Money.AddMoney(winners[i]);

                    if (players[i].Profil.Show)
                    {
                        dispatcher.Communication.SendBroadCast("{win " + Language.GetWinnerEvents() + " " + players[i].Name + " " + Language.GetWithEvents() + " " + hand + " " + Language.GetAndWonEvents() + " " + winners[i] + "$\n");
                        dispatcher.Form.GameEvents.AddDia(players[i].Name + " " + Language.GetWinsWithEvents() + " " + hand + "\n" + " " + Language.GetAndWonEvents() + " " + winners[i] + "$\n");

                        dispatcher.Form.GameEvents.AddDia("-------------------------------------\n");
                    
                    }
                    else {
                        dispatcher.Communication.SendBroadCast("{win " + Language.GetWinnerEvents() + " " + players[i].Name + " " + Language.GetWonLabel().ToLower() + " " + winners[i] + "$\n");
                        dispatcher.Form.GameEvents.AddDia(players[i].Name + " " + Language.GetWinnerEvents() + " " + players[i].Name + " " + Language.GetWonLabel().ToLower() + " " + winners[i] + "$\n");
                        dispatcher.Form.GameEvents.AddDia("-------------------------------------\n");
                    
                    }     
                if (dispatcher.Speaker != null)
                    dispatcher.Speaker.Talk(players[i].Name + " " + Language.GetWinsWithEvents() + " " + hand + "\n" + " " + Language.GetAndWonEvents() + " " + winners[i] + "$\n");
                        this.Dispatcher.Form.Media.Success(i);

                        this.dispatcher.Form.Media.Money();
            
            
            }
            dispatcher.Form.GameEvents.ChangeColor(Color.Black);
            if (this.playerInRound[this.player.Id] == 1 && winners[this.player.Id] == 0)
            {
                string sent=Language.GetYouHadEvents( this.Player.Hand.Card1, this.Player.Hand.Card2,this.Player.Hand.HandName );
                dispatcher.Form.GameEvents.AddOwnDia(sent);
                dispatcher.Form.GameEvents.AddOwnDia("-------------------------------------\n");
                if (dispatcher.Speaker != null)
                    dispatcher.Speaker.Talk(sent);
            }  
        }

        private long[] ComputeEtape6(ArrayList winningPots)
        {

            long[] winners = new long[10];
            for (int i = 0; i < 10; i++)
            {

                winners[i] = 0;
            }
            bool alreadySplitted = false;
            foreach (WinningPot pot in winningPots)
            {
                if (pot.Winners.Count > 1)
                {
                    if (!alreadySplitted)
                    {
                        this.dispatcher.Form.GameEvents.AddDia(Language.GetPotSplitEvents() + "\n");
                        this.dispatcher.Form.Media.SplitPot();
                        alreadySplitted = true;
                    }
                }
                long amount = (long)pot.Amount_2_win;
                int nbr = pot.Winners.Count;

                for (int i = 0; i < nbr; i++)
                {
                    int winner = (int)pot.Winners[i];
                    winners[winner] +=(long) ( ((long) amount* pot.Candidate.Count) / (double)nbr);
                
                }

                //
                //cas argent perdu du au split
                //
                long part = (long) ((((long)amount * pot.Candidate.Count) / (double)nbr));
                long diff = (long)(amount * pot.Candidate.Count - part * nbr);
                if (diff>0)
                {
                       int min = 10;
                       int id =-1;
                       int dealer = this.CurrentDealer;
                //looking for the guys that is nearest from dealer, when id are > dealer 
                    for (int i = 0; i < nbr; i++)
                    {
                        int winner = (int)pot.Winners[i];
                        double diffId = winner - dealer;
                        if (diffId >= 0 && min > diffId)
                        {

                            min = (int)diffId;
                            id = winner;
                            
                           
                            
                        }


                    }

                    if (id == -1)
                    {
                        min = 0;
                        //looking for the guys that is nearest from dealer, when id are < dealer 
                        for (int i = 0; i < nbr; i++)
                        {
                            int winner = (int)pot.Winners[i];
                            double diffId = winner - dealer;
                            if (diffId < 0 && min < Math.Abs(diffId))
                            {

                                min = (int) Math.Abs(  diffId);
                                id = winner;
                               
                            }


                        }
                    }
                    //attribution gain
                    winners[id] += diff;
                
                }

            }

            return winners;
        }
        /// <summary>
        /// remember all in  raise valid  in order to show hand  
        /// </summary>
        private int allinNonRaise = -1;

        public int AllinNonRaise
        {
            get { return allinNonRaise; }
            set { allinNonRaise = value; }
        }
        private ArrayList ComputeEtape5(ArrayList winningPots)
        {
            if (((WinningPot)winningPots[winningPots.Count - 1]).Lonely)
            { 
            
            //trop percu 
                players[(int)(((WinningPot)winningPots[winningPots.Count - 1]).Winners[0])].Profil.MoneyWon += (((WinningPot)winningPots[winningPots.Count - 1]).Amount_2_win);

                players[(int)(((WinningPot)winningPots[winningPots.Count - 1]).Winners[0])].Money.AddMoney((((WinningPot)winningPots[winningPots.Count - 1]).Amount_2_win));
                //TO DO IL faut changer le raiser si le last raiser est le mec qui a trop donné et qu'il a pas été pas été apres!
                //this.lastRaiser
                if (this.LastRaiser == (int)(((WinningPot)winningPots[winningPots.Count - 1]).Winners[0]) && this.FormerRaiser >= 0)
                {
                    if (this.players[this.FormerRaiser].Id == 1)
                    {
                        int aux = this.LastRaiser;
                        this.LastRaiser = this.FormerRaiser;
                        this.FormerRaiser = aux;

                    }

                }


                dispatcher.Communication.SendBroadCast("{win " + players[(int)(((WinningPot)winningPots[winningPots.Count - 1]).Winners[0])].Name +" "+ Language.GetRecoversHisEvents()+" " + (((WinningPot)winningPots[winningPots.Count - 1]).Amount_2_win) + "$\n");
                dispatcher.Form.GameEvents.AddDia(players[(int)(((WinningPot)winningPots[winningPots.Count - 1]).Winners[0])].Name +" "+ Language.GetRecoversHisEvents() + " "+(((WinningPot)winningPots[winningPots.Count - 1]).Amount_2_win) + "$ \n");

                winningPots.RemoveAt(winningPots.Count - 1);
            }

            return winningPots;
        }

        private ArrayList ComputeEtape4(ArrayList winningPots)
        {
          
            ((WinningPot)winningPots[0]).Amount_2_win = ((WinningPot)winningPots[0]).Amount_pot;
            for (int i = 0; i < winningPots.Count-1; i++)
            {


                ((WinningPot)winningPots[i+1]).Amount_2_win = ((WinningPot)winningPots[i+1]).Amount_pot -((WinningPot)winningPots[i]).Amount_pot ;
            
            }
            return winningPots;
        }

        private ArrayList ComputeEtape3(ArrayList winningPots)
        {
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                foreach (WinningPot pot in winningPots)
                {
                    if (this.players[i].TotalRaise.Money >= (long) pot.Amount_pot)
                    {
                        pot.Candidate.Add(i);
                      
                        if (this.InRound(i) == 1)
                        {  // il faut voir si winners est vide
                            if (pot.Winners.Count == 0)
                            {
                                pot.Winners.Add(i);
                            }
                            else
                            {
                                pot.Lonely = false;
                                int oldWIn = (int)pot.Winners[0];
                                if (this.players[oldWIn].Hand < this.players[i].Hand)
                                {
                                    //new best player
                                    pot.Winners.Clear();
                                    pot.Winners.Add(i);
                                }
                                else
                                {
                                    if (this.players[oldWIn].Hand == this.players[i].Hand)
                                    {
                                        //another best player
                                        pot.Winners.Add(i);
                                    }
                                }
                            }
                        }
                    
                    }
                
                }
            
            }
            return winningPots;
        }

        private ArrayList ComputeEtape1()
        {
            ArrayList winningPots = new ArrayList(10);
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                if (this.InGame(i) == 0)
                    continue;
                
                if (this.players[i].TotalRaise.Money == 0)
                    continue;

                long amount = this.players[i].TotalRaise.Money;
                bool exist = false;
                foreach (WinningPot p in winningPots)
                {
                    if ((long) p.Amount_pot == amount)
                    {
                        exist = true;
                        break;
                    }
                
                }
                if (!exist)
                {
                    WinningPot pot = new WinningPot();
                    pot.Amount_pot =  amount;
                    winningPots.Add(pot);
                }

            }

            return winningPots;
        }

        private void SeekMaxPersoPot()
        {
          long max = 0;
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                if (this.InRound(i) == 1 && this.players[i].TotalRaise.Money > max)
                {
                    max = this.players[i].TotalRaise.Money;
                }
            }
            this.totalRaise.Money = max;
        }
        private long moneyWon;
        /// <summary>
        /// outdated
        /// </summary>
        private void ShowHands()
        {

            object[] p = new object[1];
            p[0] = dispatcher.Form.showHand;
            dispatcher.Form.showHand.Invoke(new Form1.MakeVisibleHandler(dispatcher.Form.MakeShow), p);
        }
      

        private void ComputeMoneyChecking()
        {
            long total=0;
            for (int i = 0; i < this.NbrPlayerSinceBegin; i++)
            {
                total += this.players[i].Money.Money;
            
            }

            if (total != this.dispatcher.GameData.Money * NbrPlayerSinceBegin)
            {

           //  MessageBox.Show("  KKUN A VOLE DE L ARGENT !!!!!," + Environment.NewLine + total + " à la place de " + this.dispatcher.GameData.Money * NbrPlayerSinceBegin);
            
            
            }
        }

        private void SendMail(Control c) {

            try
            {
                MailSender mailsender = new MailSender(path2xorTMP);
                mailsender.Show(this.dispatcher.Form);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        
        }
        private delegate void DelegateFormMail(Control c);
       
        private string path2xorTMP;
        private void QuestionAboutRanking()
        {
            if (!(this.GameData.AggrMode.Level >= 2 || this.GameData.AggrMode.NumberOfTakeDowns > 1))
            {
                MessageBox.Show(Language.GetScoreTooBad());
                return;
            }
            string message = Language.GetRankingFilesGenQuestionToEvents(this.GameData.AggrMode.NumberOfTakeDowns, this.GameData.AggrMode.Level); 
            string caption = Language.GetRankingFilesEvents();
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {

               string name = this.GameData.AggrMode.Save(this.players[0].Name);
               if (name != "")
               {
                   try
                   {
                       path2xorTMP = name;
                       this.dispatcher.Form.Invoke(new DelegateFormMail(SendMail), new object[] { this.dispatcher.Form });
                   }
                   catch (Exception ex)
                   {


                       MessageBox.Show(ex.ToString());
                   }
              
                 
               }


            }

          //remise à zéro du compteur
                    this.GameData.AggrMode.NumberOfTakeDowns=0;
                    this.GameData.AggrMode.Level= 1;
                 
           

        }
        public void MakeVisible(Control c)
        {
            try
            {
                object[] p = new object[1];
                p[0] = c;
                c.Invoke(new Form1.MakeVisibleHandler(this.Dispatcher.Form.MakeVisible), p);
            }
            catch { }

        }
        public void MakeInVisible(Control c)
        {
            try
            {
                object[] p = new object[1];
                p[0] = c;
                c.Invoke(new Form1.MakeVisibleHandler(this.Dispatcher.Form.MakeInVisible), p);
            }
            catch { }

        }

        /// <summary>
        /// number of opponnents that can speak 
        /// </summary>
        /// <returns></returns>
        public int WhatIsTheNumberOfPlayerBehindMe()
        {
            int p = this.NbrPlayerInRoundWithMoney -1;

        

            return p;
        
        }
        /// <summary>
        /// give to everybody in round two cards 
        /// </summary>
        public void DealPrivateCard()
        {
            for (int i = 0; i < nbrPlayerSinceBegin; i++)
            {
                if (1 == playerInRound[i])
                {
                    players[i].Profil.HandsPlayed++;
                    players[i].Hand.Card1 = new Card(deck.TakeACard());
                    players[i].Hand.Card2 = new Card(deck.TakeACard());
                    if (players[i].Hand.Card1 == null || players[i].Hand.Card2 == null)
                        return;
                    MakeVisible(players[i].HiddenCard1);
                    MakeVisible(players[i].HiddenCard2);
                    players[i].SendPrivateCard();
                    if (players[i].Hand.Card1 == null || players[i].Hand.Card2 == null)
                        return;
                    //dispatcher.Form.GameEvents.AddDia(players[i].Name + "  " + players[i].Hand.Card1.Name + "  " + players[i].Hand.Card1.Color + " - " + players[i].Hand.Card2.Name + "  " + players[i].Hand.Card2.Color + "\n");
                    //dispatcher.Form.GameEvents.AddPicture(new Card[] { players[i].Hand.Card1, players[i].Hand.Card2 }, false);
                    //dispatcher.Form.GameEvents.AddDia("\n");
                    players[i].DetectMyCardsType();
                }
                else
                {
                    MakeInVisible(players[i].HiddenCard1);
                    MakeInVisible(players[i].HiddenCard2);
                }
              
               
            }
            if (1 == playerInRound[0]) //to change
            {
                dispatcher.Form.Card1 = players[0].Hand.Card1.AbsValue.ToString();
                dispatcher.Form.Card2 = players[0].Hand.Card2.AbsValue.ToString();
                dispatcher.Form.SetCard1();
                dispatcher.Form.SetCard2();
            
            }
           // dispatcher.Form.UpdateInvoke();
            //this.dispatcher.Form.RefreshMe();
            RefreshOdds();
        }
        /// <summary>
        /// pick a card;
        /// </summary>
        /// <param name="c">0 flop1 -> 4 river</param>
        private void SetCard(int c)
        {
            switch (c)
            {
                case 1: this.board.Flop2 = new Card(deck.TakeACard()); break;
                case 2: this.board.Flop3 = new Card(deck.TakeACard()); break;
                case 3: this.board.Turn = new Card(deck.TakeACard()); break;
                case 4: this.board.River = new Card(deck.TakeACard()); break;
                case 0: this.board.Flop1 = new Card(deck.TakeACard()); break;
            }

        }
        /// <summary>
        /// deals the flop an sends broadcast
        /// </summary>
        public void DealFlop()
        {
            this.dispatcher.Form.ReinitGroupBox();
           
            //do not deal if alone
            if (nbrPlayerInRound <= 1)
                return ;
            if (dispatcher.Speaker != null)
                dispatcher.Speaker.ChangeToSync();
            SetCard(0);
            SetCard(1);
            SetCard(2);
            dispatcher.Form.Card3 = board.Flop1.AbsValue.ToString();
            
            dispatcher.Form.Card4 = board.Flop2.AbsValue.ToString();
            dispatcher.Form.Card5 = board.Flop3.AbsValue.ToString();

            dispatcher.Form.SetCard3();
            dispatcher.Form.SetCard4();
            dispatcher.Form.SetCard5();
         // dispatcher.Form.Update();
            for (int i = 0; i < this.NbrPlayerSinceBegin; i++)
            {
                if (this.playerInRound[i] == 1)
                {
                    players[i].Profil.PayedFlop++;

                    players[i].Profil.Payed = true;
                    players[i].Hand.Flop(board.Flop1, board.Flop2, board.Flop3);
                }

            }
          //  this.dispatcher.Form.RefreshMe();
            if (dispatcher.Speaker != null)
                dispatcher.Speaker.Talk(Language.GetFlopIsEvents() + " " + board.Flop1.CompleteName()+ " . " + board.Flop2.CompleteName() +  ". " + board.Flop3.CompleteName());
            
            RefreshOdds();
        }
        /// <summary>
        /// deals the turn , sends broadcast
        /// </summary>
        public void DealTurn()
        {
            this.dispatcher.Form.ReinitGroupBox();
           
            //do not deal if alone
            if (nbrPlayerInRound <= 1)
                return;
            SetCard(3);
            dispatcher.Form.Card6 = board.Turn.AbsValue.ToString();
            dispatcher.Form.SetCard6();
            dispatcher.Communication.SendBroadCast("{turn " + dispatcher.Form.Card6);
           
           // dispatcher.Form.Update();
            for (int i = 0; i < this.NbrPlayerSinceBegin; i++)
            {
                if (this.playerInRound[i] == 1)
                {
                    players[i].Hand.Turn(board.Turn);
                }

            }
           // this.dispatcher.Form.RefreshMe();
          //  Application.DoEvents();
            if (dispatcher.Speaker != null)
                dispatcher.Speaker.Talk(Language.GetTurnIsEvents() + "      " + board.Turn.Name + "     " + board.Turn.Color);
           
            RefreshOdds();
        }
        /// <summary>
        /// deals the river , sends broadcast
        /// </summary>
        public void DealRiver()
        { //do not deal if alone
            this.dispatcher.Form.ReinitGroupBox();
           
            if (nbrPlayerInRound <= 1)
                return;
            SetCard(4);
            dispatcher.Form.Card7 = board.River.AbsValue.ToString();
            dispatcher.Form.SetCard7();
            dispatcher.Communication.SendBroadCast("{river " + dispatcher.Form.Card7);
           // dispatcher.Form.Update();
       
            for (int i = 0; i < this.NbrPlayerSinceBegin; i++)
            {
                if (this.playerInRound[i] == 1)
                {
                    players[i].Hand.River(board.River);
                }

            }
          //  this.dispatcher.Form.RefreshMe();
           // Application.DoEvents();
            if (dispatcher.Speaker != null)
                dispatcher.Speaker.Talk(Language.GetRiverIsEvents()+"      " + board.River.Name + "       " + board.River.Color);
            RefreshOdds();
        }
        /// <summary>
        /// able dynamic increasing of blinds
        /// </summary>
        private bool increaseBlinds = true;

        public bool IncreaseBlinds1
        {
            get { return increaseBlinds; }
            set { increaseBlinds = value; }
        }
        /// <summary>
        /// make people pay the blind
        /// </summary>
        public void Blind()
        {
            //on augmente les blinds si besoin
            if(increaseBlinds)
            ComputeBlinds();
            //on affiche les blinds
             DisplayBlinds();
             if (currentPlayer == -1)
             {
                 MessageBox.Show("bug smallblind\n");
                 return;
             }
            players[currentPlayer].HasCheck = false;
            if (players[currentPlayer].Money.Money > dispatcher.GameData.SmallBlind)
            {
                players[currentPlayer].Mise(dispatcher.GameData.SmallBlind);
                dispatcher.Form.GameEvents.AddDia(players[currentPlayer].Name + " "+Language.GetPaysSBEvents()+"\n");
                this.ShowAction(currentPlayer, Language.GetPaysSBEvents2()+" " + dispatcher.GameData.SmallBlind +"$");
                currentRaise.Money = (dispatcher.GameData.SmallBlind + dispatcher.GameData.Ante);
                dispatcher.Form.Setlabel2(pot.Money.ToString());
                LastRaiser = currentPlayer;
            }
            else
            {
                long money = players[currentPlayer].Money.Money;
                players[currentPlayer].Allin();

                currentRaise.Money = (dispatcher.GameData.SmallBlind + dispatcher.GameData.Ante);
                FormerRaiser = LastRaiser;
                LastRaiser = currentPlayer;

                //players[currentPlayer].Mise(players[currentPlayer].Money.Money);
                dispatcher.Form.GameEvents.AddDia(players[currentPlayer].Name +" "+ Language.GetPaysPartSBEvents()+"\n");
                this.ShowAction(currentPlayer, Language.GetPaysPartSBEvents() + "\n");
                //	players[currentPlayer].IsAllin=true;	
                dispatcher.Form.Setlabel2(pot.Money.ToString());

            }


        }

        private void DisplayBlinds()
        {


            dispatcher.Form.GameEvents.AddDia(Language.GetSBEvents()+" : $" + this.GameData.SmallBlind+ "\n");
            dispatcher.Form.GameEvents.AddDia(Language.GetBBEvents()+" : $" + this.GameData.BigBlind + "\n");
        }
        /// <summary>
        /// make people pay the bigblind
        /// </summary>
        public void SurBlind()
        {

            if (currentPlayer == -1)
            {
                MessageBox.Show("bug bigblind\n");
                return;
            }
            players[currentPlayer].HasCheck = false;
            FormerRaiser = LastRaiser;
            LastRaiser = currentPlayer;
            if (players[currentPlayer].Money.Money > dispatcher.GameData.BigBlind)
            {
                players[currentPlayer].Mise(dispatcher.GameData.BigBlind);
                currentRaise.Money = (dispatcher.GameData.BigBlind + dispatcher.GameData.Ante);
                dispatcher.GameData.Min = dispatcher.GameData.BigBlind;
                this.PreviousRaise = dispatcher.GameData.BigBlind;
                dispatcher.Form.Setlabel2(pot.Money.ToString());
                this.ShowAction(currentPlayer,Language.GetPaysBBEvents()+ " " + dispatcher.GameData.BigBlind + "$");
            }
            else
            {
                long money = players[currentPlayer].Money.Money;
                this.ShowAction(currentPlayer, Language.GetPaysPartBBEvents()+ " " );
                players[currentPlayer].Allin();
                this.currentRaise.Money = dispatcher.GameData.BigBlind + dispatcher.GameData.Ante;
                dispatcher.Form.Setlabel2(pot.Money.ToString());
            }
            dispatcher.Form.GameEvents.AddDia(players[currentPlayer].Name + " "+Language.GetPaysBBEvents()+"\n");

        }

        /// <summary>
        /// update miniinfo
        /// </summary>
        private void ShowMoney()
        {
            dispatcher.Form.MiniInfo.ResetList();
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                string msg = players[i].Name;
                msg += " " + players[i].Money.Money + "$";

                if (this.playerInGame[i] == 0)
                    msg += " " + Language.GetOutOfGameEvents();
                else if (this.playerInRound[i] == 0)
                    msg += " " + Language.GetFoldButton();

                else if (players[i].Money.Money <= 0)
                    msg += " " +Language.GetAllInButton();
                dispatcher.Form.MiniInfo.SetListBox1(msg);
            }

        }
        private void UpdateState()
        {
            //change player[0]  <-> player
            long diff = this.CurrentRaise.Money - this.Player.TotalRaise.Money;
            if (diff < 0)
                dispatcher.Form.Setlabel3("0");
            else dispatcher.Form.Setlabel3(diff.ToString());
        }

        /// <summary>
        /// i current player to check only 
        /// </summary>
        /// <param name="i"></param>
        public void MakeCurrentPlayerFold(int i)
        {
            //probleme si ya ca, un gars n'a pas été référencé comme ayant fini de jouer 
            if (i != this.currentPlayer)
                return;


            Thread newThread = new Thread(MakeCurrentFold);
     
     //       newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();
        
        
        }

        private void MakeCurrentFold()
        {
            dispatcher.Form.GameEvents.AddDia(players[currentPlayer].Name + " " + "timeout" + "\n");

            if (this.dispatcher.Communication.IsConnected())
            {
                this.player.OwnChrono.HavePlayed = false;
                this.player.Fold();
                this.dispatcher.Form.MakeItBlink = false;
                return;
            }
            if (players[currentPlayer].OwnPot.Money == this.currentRaise.Money)

                players[currentPlayer].Check();
            else
                players[currentPlayer].Fold();


            players[currentPlayer].Next();
        }
        /// <summary>
        /// return the next player to act
        /// </summary>
        /// <returns></returns>
        public int NextPlayer()
        {

          
            players[this.currentPlayer].OwnChrono.HavePlayed = false;
        
          
           
            Random rn = new Random((int)DateTime.Now.Ticks);
            int a = rn.Next(1,10);
            if (a ==5)
            {
                this.dispatcher.Form.Media.Funny(this.CurrentPlayer);
            }
            else
            {
                a = rn.Next(1, 10);
                if (a == 1)
                {
                    this.dispatcher.Form.Media.Insult(this.CurrentPlayer);
                }

            }
           // ActualizeMinMax();
            
            FillInfo();
            this.ActualizeNames();

            ActualizeData();
            UpdateState();
            dispatcher.Form.Setlabel2(pot.Money.ToString());
           // Application.DoEvents();
            if (nbrPlayerInRound <= 1)
                return -1;
            for (int i = currentPlayer + 1; i < nbrPlayerSinceBegin; i++)
            {
                if (playerInRound[i] == 1)
                {
                    if (players[currentPlayer].HasCheck && players[i].HasCheck && this.currentRaise.Money==0)
                    {
                        currentTurn++;
                        return -1;
                    }
                    if (!players[i].IsAllin &&
                         (
                          (players[i].OwnPot.Money == 0 || players[i].OwnPot.Money < currentRaise.Money)
                          ||
                          (this.currentTurn == 0 && i == currentBB && currentRaise.Money <= this.GameData.Ante + this.GameData.BigBlind)
                          ||
                          (this.currentBB == -1 && this.currentSB == -1 && anteJustPaid)
                          )
                        )
                    {

                        return i;
                    }
                }
            }
            for (int i = 0; i < currentPlayer; i++)
            {
                if (playerInRound[i] == 1)
                {
                    if (players[currentPlayer].HasCheck && players[i].HasCheck && this.currentRaise.Money == 0)
                    {
                        currentTurn++;
                        return -1;
                    }
                    if (!players[i].IsAllin &&
                        (
                        (players[i].OwnPot.Money == 0 || players[i].OwnPot.Money < currentRaise.Money)
                        ||
                        (this.currentTurn == 0 && i == currentBB && currentRaise.Money <= this.GameData.Ante + this.GameData.BigBlind)
                        ||
                        (this.currentBB == -1 && this.currentSB == -1 && anteJustPaid)
                        )
                        )
                    {
                        return i;
                    }
                }
            }
            currentTurn++;
            dispatcher.Form.Setlabel2(pot.Money.ToString());
            return -1;

        }

        /// <summary>
        /// begin game 
        /// </summary>
        public void Start()
        {
           
            ReInit();
            if (this.Dispatcher.Form.Stats != null)
                this.Dispatcher.Form.Stats.Close();
            this.Dispatcher.Form.Stats = new Stats(this);
            this.GameData.AggrMode.NumberOfTakeDowns = 0;
            this.GameData.AggrMode.Level = 1;
            InitSpeedMode();
            for (int i = 0; i < nbrPlayerSinceBegin; i++)
            {
                playerInGame[i] = 1;
                playerInRound[i] = 1;
            }
            try
            {
               
                    this.blindsStruc.State = 0;
                    blindsMusteBeChanged = true;
                    this.dispatcher.Form.ChronoCtr1.InitChrono(this);
                    if (this.GameData.TimeIncrease!=-1)
                    {
                        long ante;
                            long sb;
                            long bb;
                            if (this.dispatcher.GameData.AggrMode.AggressiveModeBool)
                            {

                              ante=  this.blindsStruc.getAggrAnte();
                              sb = this.blindsStruc.getAggrBlind();
                              bb = this.blindsStruc.getAggrBigBlind();

                            }
                        else{
                            ante = this.blindsStruc.getAnte();
                            sb = this.blindsStruc.getBlind();
                            bb = this.blindsStruc.getBigBlind();
                            
                            }

                    this.dispatcher.Form.ChronoCtr1.ChangeStruct(ante + "/" + sb+"/"+bb);
                    dispatcher.Form.SendInitChronoToClient();
                    }
                     else {
                    MakeInVisible(this.dispatcher.Form.ChronoCtr1);
                
                     }


                     Thread th = new Thread(new ThreadStart(BoucleJeu));
                    // th.SetApartmentState(ApartmentState.STA);
                     th.Name = "GameRound";
                     th.Priority=ThreadPriority.Normal;
                    th.Start();
            }
            catch { }
        }

        private void InitSpeedMode()
        {
            if (this.dispatcher.Form.IsFastGame())
                this.GameSpeed = 0;
            else
                if (this.dispatcher.Form.IsMediumGame())
                    this.GameSpeed = 2;
            if (this.dispatcher.Form.IsLowGame())
                this.GameSpeed = 5;
        } 
        /// <summary>
        /// INcrease current state of blinds
        /// </summary>
        public void IncreaseBlinds() 
        {
            long ante, sb, bb;
            blindsMusteBeChanged = true;
            this.blindsStruc.IncreaseBlindState();
            if (this.dispatcher.GameData.AggrMode.AggressiveModeBool)
            {

                ante = this.blindsStruc.getAggrAnte();
                sb = this.blindsStruc.getAggrBlind();
                bb = this.blindsStruc.getAggrBigBlind();

            }
            else
            {
                ante = this.blindsStruc.getAnte();
                sb = this.blindsStruc.getBlind();
                bb = this.blindsStruc.getBigBlind();

            }

            this.dispatcher.Form.ChronoCtr1.ChangeStruct(ante + "/" + sb + "/" + bb);
        
        }
        private BlindsStructure blindsStruc = new BlindsStructure();
        /// <summary>
        /// reinit displaying cards
        /// </summary>
        public void ShuffleCard()
        {
            deck.Shuffle();
            dispatcher.Form.Card1 = "";
            dispatcher.Form.Card2 = "";
            dispatcher.Form.Card3 = "";
            dispatcher.Form.Card4 = "";
            dispatcher.Form.Card5 = "";
            dispatcher.Form.Card6 = "";
            dispatcher.Form.Card7 = "";
            dispatcher.Form.SetCard1();
            dispatcher.Form.SetCard2();
            dispatcher.Form.SetCard3();
            dispatcher.Form.SetCard4();
            dispatcher.Form.SetCard5();
            dispatcher.Form.SetCard6();
            dispatcher.Form.SetCard7();
        }
        /// <summary>
        /// erase old player cards
        /// </summary>
        /// <param name="i"></param>
        public void EraseHand(int i)
        {

            players[i].Hand.Card1 = null;
            players[i].Hand.Card2 = null;
            players[i].Hand.Hand1 = null;
            players[i].Hand.Hand2 = null;
            players[i].Hand.Hand3 = null;
            players[i].Hand.Hand4 = null;
            players[i].Hand.Hand5 = null;
            this.MakeInVisible(players[i].ShowCard2);

            this.MakeInVisible(players[i].ShowCard1);
        }
        /// <summary>
        /// erase all old players hands
        /// </summary>
        private void EraseAllHand()
        {
            for (int i = 0; i < this.NbrPlayerSinceBegin; i++)
            {
                EraseHand(i);
                if (this.players[i] is IA) ((IA)this.players[i]).Bluff = false;
            }
        }
        /// <summary>
        /// move the all buttons   (  visible   SD BB dealer and invisible the others)  
        /// </summary>
        public void ShowDealer()
        {
            for (int i = 0; i < this.NbrPlayerSinceBegin; i++)
            {
                if (i == this.CurrentDealer)

                    this.MakeVisible(this.dispatcher.Form.WhatIsMyButtonBox(i));
                else
                    this.MakeInVisible(this.dispatcher.Form.WhatIsMyButtonBox(i));
            }
        }
        
        /// <summary>
        /// erase information about action of a player 
        /// </summary>
        public void EraseAllAction()
        {
            
            for (int i = 0; i < this.NbrPlayerSinceBegin; i++)
            {

                if (this.playerInRound[i] == 0 && this.playerInGame[i] == 1)
                { Addtext(this.players[i].Action, ""); }
                else
                {
                    if (this.playerInRound[i] == 0 && this.playerInGame[i] == 0)
                        Addtext(this.players[i].Action,Language.GetOutOfMoneyEvents());
                    else
                        Addtext(this.players[i].Action, "");
                }
              
            
            }

        }

        public void SetEveryBodyToDefense()
        {

            for (int i = 0; i < this.NbrPlayerSinceBegin; i++)
            {

                this.players[i].Profil.IsAttacking = false;
            
            }
        
        }
        /// <summary>
        /// display player action
        /// </summary>
        /// <param name="i"></param>
        /// <param name="st"></param>
        public void ShowAction(int i, string st)
        {
            if (i == -1)
                return;
            Addtext(this.players[i].Action, st);
            this.Dispatcher.Communication.SendBroadCast("{user " + i + "§" + st);

        }

        
        private bool stopgame = false;

        public bool Stopgame
        {
            get { return stopgame; }
            set { stopgame = value; }
        }
        /// <summary>
        /// game loop
        /// </summary>
        public void BoucleJeu()
        {
            try
            {

                this.dispatcher.GameData.NbreOfGame++;
                stopgame = false;
                dispatcher.Form.GameEvents.AddDia(Language.GetTableHandEvents().Replace("1,", this.GameData.AggrMode.Level + ",") + " " + this.dispatcher.GameData.NbreOfGame + "\n");
                if (this.dispatcher.GameData.AggrMode.AggressiveModeBool)
                {
                    this.dispatcher.Form.SetAggr(this.dispatcher.GameData.AggrMode.NumberOfTakeDowns);
                    this.dispatcher.Form.SetSurvi(this.dispatcher.GameData.AggrMode.Level);
                }

                this.Dispatcher.Form.ShowPicture();
                if (dispatcher.GameData.Type == 3)
                {
                    // this.dispatcher.Form.TrackBar1.Visible = false;
                    this.dispatcher.Form.MakeVisibleInvoke(this.dispatcher.Form.TrackBar1, false);
                    //     this.dispatcher.Form.TextBox1.Text = dispatcher.GameData.BigBlind.ToString();
                    this.Addtext(this.dispatcher.Form.TextBox1, dispatcher.GameData.BigBlind.ToString());

                    this.dispatcher.Form.TextBox1.ReadOnly = true;
                }
                ActualizeNames();
                ShowDealer();
                dispatcher.Communication.SendBroadCast("{reset " + this.CurrentDealer + " " + this.CurrentSB + " " + this.currentBB);

                ShuffleCard();
             
                currentTurn = 0;

                allinNonRaise = -1; // pas de allin foireux
                pot.ResetMoney();
                currentRaise.ResetMoney();
                nbrPlayerInRound = nbrPlayerInGame=0;
                board.Reset();
                
                ActualizeNames();
                for (int i = 0; i < nbrPlayerSinceBegin; i++)
                {
                    if (playerInGame[i] == 1)
                    {
                        playerInRound[i] = 1;
                        nbrPlayerInRound++;
                        nbrPlayerInGame++;
                        players[i].OwnPot.ResetMoney();
                        players[i].Game = this;
                        players[i].IsAllin = false;
                        players[i].ResetTotalRaise();
                        players[i].Hand.Card1 = null;
                        players[i].Hand.Card2 = null;

                    }
                    else playerInRound[i] = 0;
                }
                SetNbrPlayerInRoundWithMoney(-1);
                ActualizeGame();
                ActualizeRound();
                //TO DO Check this
                //dispatcher.Form.SetCard1();
                ContinueRound();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }
        /// <summary>
        /// force the ante
        /// </summary>
        private void PayAnte()
        {
            long ante = this.Dispatcher.GameData.Ante;
            if (ante != 0)
            {
                this.currentRaise.Money = ante;
                for (int k = 0; k < this.nbrPlayerSinceBegin; k++)
                {
                    if (this.playerInGame[k] == 1)
                    {
                        if (players[k].Money.Money <= ante)
                            players[k].Allin();
                        else
                            players[k].Mise(ante);

                    }
                }

                dispatcher.Form.GameEvents.AddDia(Language.GetAnteRpaidEvents()+"\n");
            }

        }
        /// <summary>
        /// new round 
        /// </summary>
        public void ContinueRound()
        {
            //PrintData();
            this.RefreshStats();
           
            //this.EraseAllAction();
            if (this.currentTurn < 1)
                this.EraseAllAction();
            else {

                CheckAction();
            }
            this.Dispatcher.GameData.Min = this.GameData.BigBlind;
            this.PreviousRaise = this.GameData.BigBlind;
                    
            this.Dispatcher.Form.SendGameData();
            if (dispatcher.GameData.Type == 3 && this.currentTurn > 1)
            {
             
                this.dispatcher.Form.MakeVisibleInvoke( this.dispatcher.Form.TrackBar1,false);
                long mise = 2 * dispatcher.GameData.BigBlind;
                this.Addtext(this.dispatcher.Form.TextBox1, mise.ToString());
                this.dispatcher.Form.TextBox1.ReadOnly = true;
            }
          
            //nbrPlayerInRoundWithMoney = 0;
            //NbrPlayerInRound = 0;
            //for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            //{
            //    if (this.playerInRound[i] == 1 && !this.players[i].IsAllin)
            //    {
            //        nbrPlayerInRoundWithMoney++;
            //        NbrPlayerInRound++;
            //    }
            //    else{
            //    if (this.playerInRound[i] == 1 )
            //        NbrPlayerInRound++;
            //    }
            //}
            if (nbrPlayerInRound <= 1 || nbrPlayerInRoundWithMoney <= 1)
            {
                SeekSurvivor();
                return;
            }
           

            this.nbrOfRaise = 0;
            currentRaise.ResetMoney();
            currentPlayer = currentDealer;
            if (currentTurn == 0)
            {

                this.dispatcher.Form.ShowDealerbutton();
                EraseAllHand(); this.cardDealt = false;
                dispatcher.Form.GameEvents.AddDia(players[currentDealer].Name + " "+Language.GetDealsCardsEvents()+"\n");
           

            }

            for (int i = 0; i < nbrPlayerSinceBegin; i++)
            {
                players[i].OwnPot.ResetMoney();
                players[i].HasCheck = false;
            }

            switch (currentTurn)
            {
                case 0:
                    
                    dispatcher.Communication.SendBroadCast("{newturn "); 
                    currentSB = currentBB = -1;
                    PayAnte();
                    anteJustPaid = true;
                    if (this.nbrPlayerInRound == 2)
                    {
                        currentPlayer = NextPlayer();

                    }  //inverse blind when 2 players left
                    lastRaiser = currentPlayer;
                    if (CurrentPlayer == -1)
                        return;
                    currentPlayer = NextPlayer();

                    if (currentPlayer == -1)
                    {
                        SeekSurvivor();
                        return;
                    }
                    currentSB = currentPlayer;
                    anteJustPaid = false;
                    Blind();
                    this.dispatcher.Form.ShowSBbutton();
                    //dispatcher.Form.GameEvents.AddDia("Blind payé \n");
                    lastRaiser = currentPlayer;
                    currentPlayer = NextPlayer();
                    currentBB = currentPlayer;
                    if (currentPlayer == -1)
                    {
                        SeekSurvivor();
                        return;
                    }
                    dispatcher.Communication.SendBroadCast("{BB" + currentBB);
                    dispatcher.Communication.SendBroadCast("{buttons " + this.CurrentDealer + " " + this.CurrentSB + " " + this.currentBB);
                
                    SurBlind();
                    this.dispatcher.Form.ShowBBbutton();
                    DealPrivateCard();
                    this.dispatcher.Form.Media.NewCards();
                   // dispatcher.Form.GameEvents.AddPicture(this.player.Hand.Card2);
                   //// dispatcher.Form.GameEvents.AddDia(" ");
                   // dispatcher.Form.GameEvents.AddPicture(this.player.Hand.Card1);
                    dispatcher.Form.GameEvents.AddPicture(new Card[] { this.player.Hand.Card1, this.player.Hand.Card2},false);
                    
                    dispatcher.Form.GameEvents.AddDia("\n");
                   
                    this.cardDealt = true;
                    if(this.odds!=null && this.odds.Visible)
                    odds.ComputeOdds();
                    break;

                case 1: dispatcher.Communication.SendBroadCast("{newturn ");
                    DealFlop();
                    this.dispatcher.Form.Media.Flop();
                    if (this.odds != null && this.odds.Visible)
                        odds.ComputeOdds();
                    dispatcher.Form.GameEvents.AddDia(Language.GetFlopEvents()+" : " );//+ this.board.Flop1.CompleteName()+ ", " +this.board.Flop2.CompleteName()+ ", "  +this.board.Flop3.CompleteName()+" \n");




                    dispatcher.Form.GameEvents.AddPicture(new Card[]{this.Board.Flop1,this.Board.Flop2,this.Board.Flop3},true);
                    dispatcher.Communication.SendBroadCast("{flop " + dispatcher.Form.Card3 + " " + dispatcher.Form.Card4 + " " + dispatcher.Form.Card5);
           
                    //dispatcher.Form.GameEvents.AddPicture(this.Board.Flop1);
                    //dispatcher.Form.GameEvents.AddDia(" ");
                    //dispatcher.Form.GameEvents.AddPicture(this.Board.Flop2);
                    //dispatcher.Form.GameEvents.AddDia(" ");
                    //dispatcher.Form.GameEvents.AddPicture(this.Board.Flop3);
                  
                   
                    Thread.Sleep(500);
                    dispatcher.Form.GameEvents.AddDia("\n"); 

                    break;

                case 2: dispatcher.Communication.SendBroadCast("{newturn ");
                    DealTurn();
                    if (this.odds != null && this.odds.Visible)
                        odds.ComputeOdds();
                   dispatcher.Form.GameEvents.AddDia(Language.GetTurnEvents()+" : ");// + this.board.Turn.CompleteName()+ "\n");
                   this.dispatcher.Form.Media.Turn();
                   dispatcher.Form.GameEvents.AddPicture(new Card[] { this.board.Turn },true);
                   Thread.Sleep(500);
                   dispatcher.Form.GameEvents.AddDia("\n"); 
                    break;
                case 3: dispatcher.Communication.SendBroadCast("{newturn ");
                    DealRiver();
                    if (this.odds != null && this.odds.Visible)
                        odds.ComputeOdds();
                    this.dispatcher.Form.Media.River();
                    dispatcher.Form.GameEvents.AddDia(Language.GetRiverEvents() + " : ");// + this.board.River.CompleteName()+ "\n");
                    dispatcher.Form.GameEvents.AddPicture(new Card[] { this.board.River },true);
                    Thread.Sleep(500);
                    dispatcher.Form.GameEvents.AddDia("\n"); 
                    break;
                default: SeekSurvivor(); return;
            }
              
            int pl = NextPlayer();
            if (pl != -1)
            {
                currentPlayer = pl;
                players[currentPlayer].Play();
            }
            else
            {
                SeekSurvivor();
                return;
            }
        }
        //vire les actions précédentes
        private void CheckAction()
        {
            for (int i = 0; i<this.NbrPlayerSinceBegin; i++)
            {

                if (this.playerInRound[i] == 0 && this.playerInGame[i] == 1)
                { Addtext(this.players[i].Action, Language.GetFoldButton()); }
                else {
                    if (this.playerInRound[i] == 0 && this.playerInGame[i] == 0)
                        Addtext(this.players[i].Action, Language.GetOutOfMoneyEvents());
                    else
                        Addtext(this.players[i].Action, "");
                }
            
            }
        }



        /// <summary>
        /// compute odds
        /// </summary>
        private void RefreshOdds()
        {

            if (this.dispatcher.Form.Odds != null && this.dispatcher.Form.Odds.Visible == true)
            {

                this.dispatcher.Form.Odds.ComputeOdds();
                this.Dispatcher.Communication.SendBroadCast("{refresh");

            }


        }


        public int GetTypePoker()
        {
            return dispatcher.GameData.Type;
        }
        /// <summary>
        /// send info about player in game 
        /// </summary>
        public void ActualizeGame()
        {
            string msg = "{game";
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                msg += " " + this.playerInGame[i];
            }
            dispatcher.Communication.SendBroadCast(msg);
        }
        /// <summary>
        /// send info about player  in round 
        /// </summary>
        public void ActualizeRound()
        {
            string msg = "{round";
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                msg += " " + this.playerInRound[i];
            }
            this.Dispatcher.Communication.SendBroadCast(msg);

        }


        public void SetType(int a)
        {

            dispatcher.GameData.Type = a;
        }


        public void SetLimit(int a)
        {

            dispatcher.GameData.Max = a;
        }
        public long GetBlind()
        {

            return dispatcher.GameData.SmallBlind;
        }
        public long GetMaxRaise()
        {
            return dispatcher.GameData.Max;
        }
        public long GetMinRaise()
        {
            return dispatcher.GameData.Min;
        }

        public void SetNbrPlayerInRoundWithMoney(int n)
        {
            if (n == -1)
                nbrPlayerInRoundWithMoney = nbrPlayerInRound;
            else
                nbrPlayerInRoundWithMoney--;
        }
        public void ResetTotalRaise()
        {
            totalRaise.ResetMoney();
        }
        public void AddTotalRaise(long a)
        {
            totalRaise.AddMoney(a);
        }

        public void AddOneRelance()
        {
            nbrOfRaise++;
            this.dispatcher.Communication.SendBroadCast("{relance");
        }

        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; } //not used
        }
        public int CurrentTurn
        {
            get { return currentTurn; }
            set { currentTurn = value; } //not used
        }
        public int CurrentDealer
        {
            get { return currentDealer; }
            set { currentDealer = value; } //not used
        }
        public Pot CurrentRaise
        {
            get { return currentRaise; }
            set { currentRaise = value; }
        }
        public int NbrPlayerInGame
        {
            get { return nbrPlayerInGame; }
            set { nbrPlayerInGame = value; }
        }
        public int NbrPlayerInRoundWithMoney
        {
            get { return nbrPlayerInRoundWithMoney; }
            set { nbrPlayerInRoundWithMoney = value; }
        }
        public int NbrPlayerInRound
        {
            get { return nbrPlayerInRound; }
            set { nbrPlayerInRound = value; }
        }

        public Pot MainPot
        {
            get { return pot; }
            set { pot = value; }
        }
        public int NbrPlayerSinceBegin
        {
            get { return nbrPlayerSinceBegin; }
            set { nbrPlayerSinceBegin = value; }
        }
        public Pot TotalRaise
        {
            get { return this.totalRaise; }
            set { totalRaise = value; }
        }
        public int CurrentBB
        {
            get { return currentBB; }
            set { currentBB = value; }
        }
        public int CurrentSB
        {
            get { return currentSB; }
            set { currentSB = value; }
        }
        public int NbrOfRaise
        {
            get { return nbrOfRaise; }
            set { nbrOfRaise = value; }
        }
        public GameData GameData
        {
            get { return dispatcher.GameData; }
            set { dispatcher.GameData = value; }
        }
        public Dispatcher Dispatcher
        {
            get { return dispatcher; }

        }
        public long PreviousRaise
        {
            get { return previousRaise; }
            set { previousRaise = value; }
        }
        public CommunityCards Board
        {
            get { return board; }

        }
        public Player Player
        {
            get { return player; }
            set { player = value; }

        }
        public void InGame(int i, int a)
        {
            this.playerInGame[i] = a;
        }
        public void InRound(int i, int a)
        {
            this.playerInRound[i] = a;
        }
        public void Names(int i, string a)
        {
            this.names[i] = a;
        }
        public int LastRaiser
        {
            get { return this.lastRaiser; }
            set { this.lastRaiser = value; }
        }
        public int SecretRaise
        {
            get { return this.secretRaise; }
            set { this.secretRaise = value; }
        }
        /// <summary>
        /// stocks money information of each players
        /// </summary>
        private long[] money;
        private string[] names;
        private int nbr_socket;
        private Pot pot;

        public Pot Pot
        {
            get { return pot; }
            set { pot = value; }
        }
        private Pot currentRaise; // amount of the last raise 
        private int currentTurn = 0;
        private int currentDealer = 0;
        private int currentPlayer = 0;
        private int nbrPlayerInGame; //number of players with money  
        private int[] playerInGame;//array of players , say if a player is in game or not
        private int nbrPlayerInRound;//idem but for a round
        private int nbrPlayerInRoundWithMoney;
        private int[] playerInRound;//tableau des joueurs encore en lis
        private int nbrPlayerSinceBegin;//explicit  
        private Player[] players;
        public void SetPlayer(Player pl) {

            players[pl.Id] = pl;
        }
        private Deck deck = new Deck();
        private Pot totalRaise = null;
        private int currentBB = 0;
        private int currentSB = 0;
        private int nbrOfRaise = 0;
        private Dispatcher dispatcher;
        private CommunityCards board;
        private long previousRaise = 0;//derniere relance faite
        private Player player;
        private int bestPlayer;
        private int lastRaiser;
        private int secretRaise = 0;
        private void RefreshStats()
        {
            if (this.Dispatcher.Form.Stats == null)
                return;

            else this.Dispatcher.Form.Stats.RefreshMe();

        }
        /// <summary>
        /// debug purpose 
        /// </summary>
        public void PrintData()
        {
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                Console.WriteLine(players[i].Name);
                Console.WriteLine("won=" + players[i].Profil.Won);
                Console.WriteLine("played=" + players[i].Profil.HandsPlayed);
                Console.WriteLine("showdowns=" + players[i].Profil.Showdowns);
                Console.WriteLine("payedFlop=" + players[i].Profil.PayedFlop + "\n");

            }

        }
        /// <summary>
        /// write on disk new stats
        /// </summary>
        private void WriteNewStats()
        {
            Profil pro = this.Dispatcher.Profil;
            CurrentProfil currpro = this.player.Profil;
            updatePro(pro, currpro);
            lock (pro)
            {
                pro.Save();
            }
        }

        /// <summary>
        /// send to the client his new skill
        /// </summary>
        /// <param name="i"></param>
        /// <param name="currentpro"></param>
        private void updateProNet(int i, CurrentProfil currentpro) //profil a distant player
        {
            string st = "{save";
            if (this.GetPlayer(i).IsAllin)
                st += "1"; //pro.AllIn++; //=currentpro.Allins;
            else st += "0";
            if (currentpro.IsWinner && this.player.IsAllin)
                st += "§1";
            else st += "§0";
            if (currentpro.IsWinner)
                st += "§1";
            else st += "§0";

            if (currentpro.Payed)
                st += "§1";
            else st += "§0";

            if (currentpro.Show)
                st += "§1";
            else st += "§0";

            st += "§" + currentpro.TakedownTurn;

            if (this.NbrPlayerInRound == 1 && currentpro.IsWinner)
                st += "§1";
            else st += "§0";
            st += "§" + currentpro.MoneyWon;


            currentpro.Show = false;
            currentpro.IsWinner = false;
            currentpro.MoneyWon = 0;
            currentpro.Payed = false;
            currentpro.TakedownTurn = 0;
            if (this.players[i] is NetworkPlayer)
            {

                ((NetworkPlayer)this.players[i]).SendToClient(st);
            }


        }
        /// <summary>
        /// actualize local profile 
        /// </summary>
        /// <param name="pro"></param>
        /// <param name="currentpro"></param>
        private void updatePro(Profil pro, CurrentProfil currentpro)
        {
            for (int i = 0; i < this.nbrPlayerSinceBegin; i++)
            {
                if (this.players[i] is LocalPlayer)
                    continue;
                else
                    updateProNet(i, this.players[i].Profil);
            }
            if (this.player.IsAllin)
                pro.AllIn++; //=currentpro.Allins;

            if (currentpro.IsWinner && this.player.IsAllin)
                pro.AllInWon++;


            if (currentpro.IsWinner)
                pro.GamesWon++;

            if (currentpro.Payed)
                pro.PayedFlop++;

            if (currentpro.Show)
                pro.Showdowns++;

            pro.TakeDowns += currentpro.TakedownTurn;

            if (this.NbrPlayerInRound == 1 && currentpro.IsWinner)
                pro.WonWithoutShow++;//=currentpro.WonWithoutShow;
            pro.GamesPlayed++;
            pro.MoneyWon += currentpro.MoneyWon;

            currentpro.Show = false;
            currentpro.IsWinner = false;
            currentpro.MoneyWon = 0;
            currentpro.Payed = false;
            currentpro.TakedownTurn = 0;



        }
        /// <summary>
        /// indique le nombre de joueur allin
        /// </summary>
        /// <returns></returns>
        internal int NbPlayerAllin()
        {
            int i = 0;

            for (int p = 0; p < this.nbrPlayerSinceBegin; p++)
            {
                if (this.InRound(p) == 1)
                {
                    if (players[p].IsAllin)
                        i++;
                }
            }

            return i;

        }
    }
}
