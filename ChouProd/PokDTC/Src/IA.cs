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
using System.Collections;
namespace poker
{
    /// <summary>
    /// virtual player
    /// </summary>
    public class IA : Player
    {
        /// <summary>
        /// indique si le joueur est un tricheur 
        /// </summary>
        private bool cheater = true;

        public bool Cheater
        {
            get { return cheater; }
            set { cheater = value; }
        }

        private const int DTC_8 = 1;
        private const int DTC_9 = 2;
        private const int DTC_10 = 3;
        private const int DTC_11 = 4;
        private const int DTC_12 = 5;
        private const int Drunken = 0;
        private int bot_type = 0;

        public int Bot_type
        {
            get { return bot_type; }
            set { bot_type = value; //Name = name + "_" + value; 
            }
        }
        /// <summary>
        /// create a new virtual player 
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="intel">intel not implemented</param>
        /// <param name="aggr">aggressivity not implemented</param>
        /// <param name="chan">chance not implemented </param>
        /// <param name="euro"> starting money</param>
        /// <param name="j"> game</param>
        /// <param name="i"> id </param>
        /// <param name="cheater">  indique si le joeur est un tricheur  </param>
        public IA(string name, int intel, int aggr, int chan, long euro, Game j, int i, bool cheater)
        {

            Id = i;
            this.name = name;
            intelligence = intel;
            aggressivite = aggr;
            chance = chan;
            money = new Pot(euro);
            this.ownpot = new Pot(0);
            this.totalRaise = new Pot(0);
            this.hand = new Hand();
            this.game = j;
            this.cheater = cheater;
            odds = new Odds(this.game);
            this.ownChrono.Game = j;
            ownChrono.InitTimeLeft = this.game.Dispatcher.GameData.Time2Mind;
            ownChrono.TimeLeft = ownChrono.InitTimeLeft;
            this.ownChrono.Start();
        }

        public override void SendPrivateCard() { }

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
        /// make the virtual player play
        /// </summary>

        public override void Play()
        {   //changed
            if (this.game.GamePause)
            {
                this.game.Dispatcher.Form.GameEvents.AddDia("Game Paused\n");
            }
            else
            Thread.Sleep(this.game.GameSpeed * 1000);

            while (this.game.GamePause)
            { Thread.Sleep(500); }
            this.game.ActualizeMinMax(this.id);
            int todo = 0;

            this.game.Dispatcher.Form.MakeBlinkingGroupBox();
            this.ownChrono.HavePlayed = true;
            int paf = 0;

            if (this.Hand.Card1 == null)
            {
                this.Fold();
                throw new Exception("pas de cartes\n");
                return;
            }
            Random rdm = new Random((int)DateTime.Now.Ticks);
            if (cheater)
            {

                todo = letsCheat();

                switch (todo)
                {
                    case 0: //fold 
                        if (this.game.CurrentRaise.Money - this.ownpot.Money == 0)
                            this.Check();
                        else this.Fold();
                        break;
                    case 1: if (this.game.CurrentRaise.Money != 0) this.Call();
                        else
                            this.BetRaise(this.game.GameData.Min);

                        break;
                    case 2: if (this.game.CurrentRaise.Money != 0) this.Call();
                        else
                            this.BetRaise(this.game.GameData.Min);

                        break;

                    case 3:
                        this.BetRaise(this.game.GameData.Min * 2);

                        break;
                    case 4:
                        this.BetRaise(this.game.GameData.Min * 3);

                        break;
                    default: this.Allin(); break;


                }

            }
            else
            {
                //to do  change function depending on Bot_type


                switch (Bot_type)
                {
                    case DTC_8: SeekWhatToDoScrVersion(); break;
                    case DTC_9: SeekWhatToDoDTC_9(); break;
                    case DTC_10: SeekWhatToDoDTC_10(); break;
                    case DTC_11: SeekWhatToDoDTC_11(); break;
                    default: SeekWhatToDoDrunkenPlayer(); break;
                }
            }
            this.ownChrono.HavePlayed = false; ;
            //stop clignotement
            this.game.Dispatcher.Form.ReinitGroupBox();
            int p = game.NextPlayer();
            if (p == -1)
            {
                game.ContinueRound();
            }
            else
            {
                game.CurrentPlayer = p;
                game.GetPlayer(game.CurrentPlayer).Play();
            }
            
        }
        //IA  un peu plus évolué 
        private void SeekWhatToDoDTC_9()
        {
            //mettre les regles ici
            switch (this.game.CurrentTurn)
            {
                case 0: SeekWhatToDoDTC_9_PreFlop(); break;
                default: SeekWhatToDoDTC_9_PostFlop(); break;
            }



        }
        private void SeekWhatToDoDTC_10()
        {
            //mettre les regles ici
            switch (this.game.CurrentTurn)
            {
                case 0: SeekWhatToDoDTC_10_PreFlop(); break;
                default: SeekWhatToDoDTC_10_PostFlop(); break;
            }



        }
        private void SeekWhatToDoDTC_11()
        {
            //mettre les regles ici
            switch (this.game.CurrentTurn)
            {
                case 0: SeekWhatToDoDTC_11_PreFlop(); break;
                default: SeekWhatToDoDTC_11_PostFlop(); break;
            }



        }
        private void SeekWhatToDoDTC_12()
        {
            //mettre les regles ici
            switch (this.game.CurrentTurn)
            {
                case 0: SeekWhatToDoDTC_12_PreFlop(); break;
                default: SeekWhatToDoDTC_12_PostFlop(); break;
            }



        }
        /// <summary>
     ///  gere les grosses relances
     /// </summary>
     /// <returns>   true si action has been taken</returns>
        private bool DoIhaveToPayAllin()
        {
            if (this.game.CurrentRaise.Money - this.ownpot.Money > this.Money.Money * 4 / 5)
            {
                //paye avec AA  AK  KK
                if (this.privateCardsType == 1 || (this.privateCardsType == 4 && this.hand.Card1.Color == this.hand.Card2.Color) || (this.privateCardsType == 2 && this.hand.Card1.Value >= 13))
                {
                    this.Allin();
                    return true;


                }
                else {
                    //on profile le gars pour voir si c'est serieux 
                    if (this.game.GetPlayer(this.game.LastRaiser).Profil.IsAggPreFlop() && this.game.GetPlayer(this.game.LastRaiser).Profil.HandsPlayed >=5 )
                    {
                        if (this.privateCardsType <= 5 && this.privateCardsType != 3 )
                        {

                            int allinNbr = this.game.NbPlayerAllin();
                            if (allinNbr > 0)
                            {
                                double res = this.game.MainPot.Money / (double)allinNbr;

                                // on ne joue pas si trop de monde all in 
                                if (res < 3.0 / 2.0 * (this.money.Money + this.ownpot.Money))
                                {
                                    return false;
                                }
                            }
                            this.Allin();
                            return true;


                        }

                    }
                    else { this.Fold(); return true; }
                
                
                }

            }

            return false;
        
        }

        /// <summary>
        /// mega aggr  
        /// </summary>
        private void SeekWhatToDoDTC_10_PostFlop()
        {
            Odds odds = new Odds(this.game);
            odds.Player = this;
            int won = odds.ComputeStats();
          

            //DETECTER LES GROSSES CARTES QUI CASSENT LES PAIRES SERVIES  A K J  Q   
            //il faudrait differer les turn et river
            if ((this.privateCardsType == 3 || this.privateCardsType == 2 || this.privateCardsType == 1))
            { 
                        int cardHigher=0;
                        int sameCards= 0;
                            
                        if (this.game.Board.Flop1.Value > this.Hand.Card1.Value)
                            cardHigher++;
                        if (this.game.Board.Flop2.Value > this.Hand.Card1.Value)
                            cardHigher++;
                        if (this.game.Board.Flop3.Value > this.Hand.Card1.Value)
                            cardHigher++;

                        if (this.game.Board.Flop1.Value == this.Hand.Card1.Value)
                            sameCards++;
                        if (this.game.Board.Flop2.Value == this.Hand.Card1.Value)
                            sameCards++;
                        if (this.game.Board.Flop3.Value == this.Hand.Card1.Value)
                            sameCards++;

                        if (this.game.Board.Turn != null)
                        {
                            if (this.game.Board.Turn.Value > this.Hand.Card1.Value)
                                cardHigher++;

                            if (this.game.Board.Turn.Value == this.Hand.Card1.Value)
                                sameCards++;
                        }
                        if (this.game.Board.River != null)
                        {

                            if (this.game.Board.River.Value > this.Hand.Card1.Value)
                                cardHigher++;
                            if (this.game.Board.River.Value == this.Hand.Card1.Value)
                                sameCards++;
                        }

                        if (cardHigher > 1 && sameCards==0)
                        { 
                        // alert mode total
                            if (this.game.CurrentRaise.Money == 0)
                            {
                                this.Check();
                                return;
                            }
                            else {
                                if (this.game.CurrentRaise.Money < 3 * this.game.GameData.BigBlind)
                                {
                                    if (this.game.CurrentTurn == 1)
                                    {
                                        this.BetRaise(3 * this.game.GameData.BigBlind);
                                        return;
                                    }
                                    else
                                    {
                                        //faire caller si pas assez d'argent 
                                        if (this.game.CurrentRaise.Money - this.ownpot.Money <= 3 * this.game.GameData.BigBlind)
                                        {
                                            this.Allin();
                                            return;

                                        }

                                        this.Fold();
                                        return;
                                    }
                                     
                                   
                                }
                                else {
                                    //faire caller si pas assez d'argent 
                                    if (this.game.CurrentRaise.Money - this.ownpot.Money < 3 * this.game.GameData.BigBlind)
                                    {
                                        this.Call();
                                        return;

                                    }
                                    this.Fold();
                                    return;
                                }
                            }
                        }
                            //notre paire est belle
                        if (this.game.CurrentRaise.Money >=3 * this.game.GameData.BigBlind)
                        {
                            this.Call() ;
                            return;
                        }
                        //notre paire est belle
                        if (this.game.CurrentRaise.Money < 3 * this.game.GameData.BigBlind)
                        {
                            this.BetRaise(1 / 3 * this.game.MainPot.Money);
                            return;
                        }   
                        
            } //fin etude paire
            if (this.Profil.IsAttacking && this.game.Dispatcher.Analyser.TetesDetection >= 1 && this.game.CurrentRaise.Money == 0)
            {
                this.BetRaise((long) (1.0/2.0 * this.game.CurrentRaise.Money));
                return;
            }

            if (Cote.IsCoteOk(this.game, this))
            {
                if (this.Game.CurrentRaise.Money == 0 || Cote.computeDiffCote(this.game, this) >= 0.4)
                {
                    this.BetRaise((long)(this.game.MainPot.Money / 2));
                    return;
                }
                else
                {
                    if (this.game.CurrentTurn == 1 && this.game.CurrentRaise.Money < this.money.Money / 2)
                    {
                        this.BetRaise((long)(this.game.MainPot.Money / 3));
                        return;
                    }
                    else
                    {
                        if (Cote.computeDiffCote(this.game, this) < 0.2)
                        {
                            if (this.game.CurrentRaise.Money - this.ownpot.Money <= 3 * this.game.GameData.BigBlind)
                            {
                                this.Allin();
                                return;

                            }
                            this.Fold();
                            return;

                        }

                    }
                }
            }

            if (this.game.CurrentRaise.Money == 0)
            {
                this.Check();
                return;

            }
            //faire caller si pas assez d'argent 
           if (this.game.CurrentRaise.Money-this.ownpot.Money <= 3*  this.game.GameData.BigBlind)
           {
               this.Call();
               return;

            }

            this.Fold();
        }


        /// <summary>
        /// grd frere de la 9, joue la position  en volant les blinds , tout en gardant un jeu fort 
        /// ne va pas payer n'importe quel tapis => profiling de joueur
        /// </summary>
        private void SeekWhatToDoDTC_10_PreFlop()
        {
            double statwon;
            double floor = 0; //limite de paiement

            if (this.Hand.Card1 == null)

            {

                this.Fold();
                return;
            
            }
            if (Cote.IsAlert(this.game, this) && (privateCardsType < 6 || privateCardsType == 7))
            {
                this.Allin();
                return;
            }

            //gere les grosses relances
            if (DoIhaveToPayAllin())
                return;



            if (this.Hand.Card1.Color == this.Hand.Card2.Color)
                statwon = KnownStats.statSuited[KnownStats.GetInd(this.Hand.Card1.ValueR), KnownStats.GetInd(this.Hand.Card2.ValueR), this.game.NbrPlayerInGame - 2, 0];

            else

                statwon = KnownStats.statUnSuited[KnownStats.GetInd(this.Hand.Card1.ValueR), KnownStats.GetInd(this.Hand.Card2.ValueR), this.game.NbrPlayerInGame - 2, 0];


            switch (this.game.NbrPlayerInGame)
            {
                case 10: floor = 16.0; break;
                case 9: floor = 16.0; break;
                case 8: floor = 18.0; break;
                case 7: floor = 19.0; break;
                case 6: floor = 22.0; break;
                case 5: floor = 25.0; break;
                case 4: floor = 30.0; break;
                case 3: floor = 40.0; break;
                case 2: floor = 50.0; break;

            }

            if (TryToStealBlind())
                return;

            if (statwon >= floor)
            {
                if (this.game.CurrentRaise.Money - this.ownpot.Money <= this.Money.Money / 5)
                {
                    this.BetRaise(4 * this.game.GameData.BigBlind);
                    return;
                }
                else {

                    if (this.game.CurrentRaise.Money - this.ownpot.Money <= this.Money.Money / 3)
                    {
                        this.Call();
                        return;
                    }
                   
                
                }
                


            }
            else
            {
                if (this.game.CurrentRaise.Money - this.ownpot.Money <this.game.GameData.BigBlind)
                {
                    this.Call();
                    return;
                } 
            }



            switch (privateCardsType)
            { //AQ AT 
                case 5: if (this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                    {
                        this.BetRaise(this.game.Dispatcher.GameData.BigBlind * 3);
                        return;

                    }
                    else {

                        if (Cote.IsCoteOk(this.game, this))
                        {
                            this.Call();
                            return;
                        }
                
                    }

                    break;


                case 4:
                case 1:
                case 2: if (Cote.IsCoteOk(this.game, this))
                    {
                        if (this.game.CurrentRaise.Money != 0)
                        {
                            this.BetRaise(this.game.CurrentRaise.Money * 3);
                            return;
                        }
                        else
                        {
                            this.BetRaise(this.game.CurrentBB * 5);
                            return;
                        }

                    }
                    else
                    {
                        if (this.game.CurrentRaise.Money >= this.game.CurrentBB * 3)
                        {
                            this.Call();
                            return;
                        }
                        else
                        {
                            this.BetRaise(this.game.CurrentBB * 3);
                            return;
                        }
                    }
                    break;
                case 3:
                    if (this.game.NbrPlayerInGame <= 6 && this.Hand.Card1.ValueR >= 9)
                    {
                        if (this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                        {
                            this.BetRaise(this.game.Dispatcher.GameData.BigBlind * 3);
                            return;

                        }
                        else
                        {

                            this.Call();
                            return;
                        }

                    }
                    else
                    {

                        if (this.game.NbrPlayerInGame <= 4)
                        {

                            this.Call();

                        }



                    } break;

                case 8: if (Cote.IsCoteOk(this.game, this) && this.game.NbrPlayerInGame <= 6)
                    {
                        this.Call(); return;
                    }
                    break;

                case 7:
                case 6:
                    if (Cote.IsCoteOk(this.game, this) && this.game.NbrPlayerInGame <= 4)
                    {
                        this.Call(); return;
                    }
                    break;
                default: break;


            }
            //limp de la SB  sur joueur looze
            if (this.game.CurrentRaise.Money == this.game.GameData.BigBlind && this.ownpot.Money == this.game.GameData.SmallBlind && this.game.GetPlayer((int)this.game.CurrentBB).Profil.PercentageRaisePreFlop() < 20)
            {

                this.Call();
                return;
            }



            this.Fold();
        }
        /// <summary>
        /// action to steal blinds if in position and get some correct cards
        /// </summary>
        /// <returns> action done? </returns>
        private bool TryToStealBlind()
        {
            //en position SB *
            if (this.id == this.game.CurrentSB && this.game.Pot.Money <= this.game.Dispatcher.GameData.BigBlind + this.game.Dispatcher.GameData.SmallBlind)
            {     
                    if (this.game.GetPlayer(this.game.CurrentBB).Profil.GetTransfertFlop() < 30)
                    {
                        if (this.privateCardsType <= 7)
                        {
                            this.BetRaise(3 * this.game.Dispatcher.GameData.BigBlind);
                            return true;
                        }
                    }
            }

           //en position de dealer
            if (this.id == this.game.CurrentDealer && this.game.Pot.Money <= this.game.Dispatcher.GameData.BigBlind +this.game.Dispatcher.GameData.SmallBlind)
            {

                if (this.game.GetPlayer(this.game.CurrentSB).Profil.GetTransfertFlop() < 30)
                {


                    if (this.game.GetPlayer(this.game.CurrentBB).Profil.GetTransfertFlop() < 30)
                    {

                        if (this.privateCardsType <= 7)
                        {
                            this.BetRaise(3 * this.game.Dispatcher.GameData.BigBlind);
                            return true;
                        }


                    }


                }

            }


            return false;
        }

        /// <summary>
        /// on vole les blinds  sur des joueurs passifs en position SB BB Dealer et avant dealer  si on a M 10
        /// </summary>
        /// <returns></returns>
        private bool TryToStealBlindAggr()
        {
            int nbr = this.game.WhatIsTheNumberOfPlayerBehindMe();

            if (this.Money.Money / this.game.Dispatcher.GameData.BigBlind < 10)
                return false;

            if (this.Profil.HandsPlayed <= 3)
                return false;

            if (  this.game.MainPot.Money >= 5*this.game.Dispatcher.GameData.BigBlind )
                return false;

            if (this.game.CurrentRaise.Money > this.game.Dispatcher.GameData.BigBlind)
                return false;

            //on peut leur voler les blinds
            if (this.IsEveryBodyInGamePassiv())
            {
                if (this.Profil.IsAggPreFlop())
                    return false;


                Random rnd = new Random((int)DateTime.Now.Ticks);
                if(1==rnd.Next(1,3))
                this.BetRaise(2 * this.game.CurrentRaise.Money);
                else
                this.BetRaise(3 * this.game.CurrentRaise.Money);
                return true;
            }



            return false;
        }
        /// <summary>
        /// base sur la 10 mais moins folle sur les relances,joue la position  en volant les blinds , tout en gardant un jeu fort 
        /// ne va pas payer n'importe quel tapis => profiling de joueur
        /// </summary>
        private void SeekWhatToDoDTC_11_PreFlop()
        {
            double statwon;
            double floor = 0; //limite de paiement


            //fait tapis si on a un M petit et une main a peu pres correct
            if (Cote.IsAlert(this.game, this) && (privateCardsType < 6 || privateCardsType == 7))
            {
                this.Allin();
                return;
            }
            
            if (TryToStealBlindAggr())
                return;

            //gere les grosses relances
            if (DoIhaveToPayAllin())
                return;



            if (this.Hand.Card1.Color == this.Hand.Card2.Color)
                statwon = KnownStats.statSuited[KnownStats.GetInd(this.Hand.Card1.ValueR), KnownStats.GetInd(this.Hand.Card2.ValueR), this.game.NbrPlayerInGame - 2, 0];

            else

                statwon = KnownStats.statUnSuited[KnownStats.GetInd(this.Hand.Card1.ValueR), KnownStats.GetInd(this.Hand.Card2.ValueR), this.game.NbrPlayerInGame - 2, 0];


            switch (this.game.NbrPlayerInGame)
            {
                case 10: floor = 16.0; break;
                case 9: floor = 16.0; break;
                case 8: floor = 18.0; break;
                case 7: floor = 19.0; break;
                case 6: floor = 22.0; break;
                case 5: floor = 25.0; break;
                case 4: floor = 30.0; break;
                case 3: floor = 40.0; break;
                case 2: floor = 50.0; break;

            }
          //si bonne main 
            if (statwon >= floor)
            {
                if (this.game.CurrentRaise.Money ==this.game.Dispatcher.GameData.BigBlind)
                {
                    this.BetRaise(4 * this.game.GameData.BigBlind);
                    return;
                }
                if (this.game.CurrentRaise.Money <= 3*this.game.Dispatcher.GameData.BigBlind)
                {
                    this.BetRaise(3 * this.game.GameData.BigBlind);
                    return;
                }

                if (this.game.CurrentRaise.Money - this.ownpot.Money <= this.Money.Money / 6.0)
                {
                    this.Call();
                    return;
                }
  
            }
            else
            {
                //si on a pas la cote mais que ca coute pas tres cher  et qu'il ya pas de gars aggr on joue looze
                if (this.game.CurrentRaise.Money - this.ownpot.Money <= this.game.GameData.BigBlind && this.game.WhatIsTheNumberOfPlayerBehindMe()<4 && this.profil.HandsPlayed >=5 && IsEveryBodyInGamePassiv())
                {
                    //pas une bonne main mais on joue loose vu le profil des joueurs apres
                    this.Call();
                    return;
                }
            }



            switch (privateCardsType)
            { //AQ AT 
                case 5: if (this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                    {
                        this.BetRaise(this.game.Dispatcher.GameData.BigBlind * 3);
                        return;

                    }
                    else
                    {

                        if (Cote.IsCoteOk(this.game, this))
                        {
                            this.Call();
                            return;
                        }

                    }

                    break;


                case 4:
                case 1:
                case 2: if (Cote.IsCoteOk(this.game, this))
                    {
                        if (this.game.CurrentRaise.Money != 0)
                        {
                            this.BetRaise(this.game.CurrentRaise.Money * 3);
                            return;
                        }
                        else
                        {
                            this.BetRaise(this.game.CurrentBB * 4);
                            return;
                        }

                    }
                    else
                    {
                        if (this.game.CurrentRaise.Money >= this.game.CurrentBB * 3)
                        {
                            this.Call();
                            return;
                        }
                        else
                        {
                            this.BetRaise(this.game.CurrentBB * 3);
                            return;
                        }
                    }
                    break;
                case 3:
                    if (this.game.NbrPlayerInGame <= 6 && this.Hand.Card1.ValueR >= 9)
                    {
                        if (this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                        {
                            this.BetRaise(this.game.Dispatcher.GameData.BigBlind * 3);
                            return;

                        }
                        else
                        {
                          //VERIF ICI 

                            this.Fold();
                            //this.Call();
                            return;
                        }

                    }
                    else
                    {

                        if (this.game.NbrPlayerInGame <= 4 && this.Hand.Card1.ValueR >= 6)
                        {
                            if (this.game.CurrentRaise.Money < this.game.Dispatcher.GameData.BigBlind * 3)
                            {
                                this.BetRaise(this.game.Dispatcher.GameData.BigBlind * 3);
                                return;
                            }
                            else {

                                this.Call();
                                return;
                            
                            
                            }

                        }
                        else{



                            if (this.game.CurrentRaise.Money < this.game.Dispatcher.GameData.BigBlind * 3)

                            {
                                this.Call();
                                return;
                            
                            }
                        
                        }



                    } break;

                case 8: if (Cote.IsCoteOk(this.game, this) && this.game.NbrPlayerInGame <= 6)
                    {
                        this.Call(); return;
                    }
                    break;

                case 7:
                case 6:
                    if (Cote.IsCoteOk(this.game, this) && this.game.NbrPlayerInGame <= 4)
                    {
                        this.Call(); return;
                    }
                    break;
                default: break;


            }
            //limp de la SB  sur joueur looze
            if (this.game.CurrentRaise.Money == this.game.GameData.BigBlind && this.ownpot.Money == this.game.GameData.SmallBlind && this.game.GetPlayer((int)this.game.CurrentBB).Profil.PercentageRaisePreFlop() < 20)
            {

                this.Call();
                return;
            }



            this.Fold();
        }
        private void SeekWhatToDoDTC_11_PostFlop()
        {
            Odds odds = new Odds(this.game);
            odds.Player = this;
            int won = odds.ComputeStats();


            //DETECTER LES GROSSES CARTES QUI CASSENT LES PAIRES SERVIES  A K J Q   
            //il faudrait differer les turn et river
            if ((this.privateCardsType == 3 || this.privateCardsType == 2 || this.privateCardsType == 1))
            {
                int cardHigher = 0;
                int sameCards = 0;

                if (this.game.Board.Flop1.Value > this.Hand.Card1.Value)
                    cardHigher++;
                if (this.game.Board.Flop2.Value > this.Hand.Card1.Value)
                    cardHigher++;
                if (this.game.Board.Flop3.Value > this.Hand.Card1.Value)
                    cardHigher++;

                if (this.game.Board.Flop1.Value == this.Hand.Card1.Value)
                    sameCards++;
                if (this.game.Board.Flop2.Value == this.Hand.Card1.Value)
                    sameCards++;
                if (this.game.Board.Flop3.Value == this.Hand.Card1.Value)
                    sameCards++;

                if (this.game.Board.Turn != null)
                {
                    if (this.game.Board.Turn.Value > this.Hand.Card1.Value)
                        cardHigher++;

                    if (this.game.Board.Turn.Value == this.Hand.Card1.Value)
                        sameCards++;
                }
                if (this.game.Board.River != null)
                {

                    if (this.game.Board.River.Value > this.Hand.Card1.Value)
                        cardHigher++;
                    if (this.game.Board.River.Value == this.Hand.Card1.Value)
                        sameCards++;
                }

                if (cardHigher >= 1 && sameCards == 0)
                {
                    // alert mode total
                    if (this.game.CurrentRaise.Money == 0)
                    {
                        this.Check();
                        return;
                    }
                    else
                    {
                        if (this.game.CurrentRaise.Money < 3 * this.game.GameData.BigBlind)
                        {
                            //on attaque une fausse relance à la turn
                            if (this.game.CurrentTurn == 1)
                            {
                                this.BetRaise(2 * this.game.GameData.BigBlind);
                                return;
                            }
                            else
                            {
                                //faire caller si pas assez d'argent 
                                if (this.game.CurrentRaise.Money - this.ownpot.Money < this.game.GameData.BigBlind)
                                {
                                    this.Allin();
                                    return;

                                }

                                this.Fold();
                                return;
                            }
                        }
                        else
                        {
                          
                            this.Fold();
                            return;
                        }
                      
                    }
                }
                //la paire est belle (je parle de cartes)
                if (this.game.CurrentRaise.Money > 3 * this.game.GameData.BigBlind)
                {
                    if (Cote.IsCoteOk(this.game, this))
                    {
                        this.BetRaise((long)(1.0 / 2.0) * this.game.MainPot.Money);
                        return;
                    }
                    else {
                        this.Fold();
                        return;
                    
                    }
                   
                }
                //notre paire est belle( je parle de cartes)
                if (this.game.CurrentRaise.Money <= 3 * this.game.GameData.BigBlind)
                {
                    this.BetRaise((long)(1.0 / 2.0)* this.game.MainPot.Money);
                    return;
                }

            }




            if (Cote.IsCoteOk(this.game, this))
            {
                //grosse cote 
                if (Cote.computeDiffCote(this.game, this) >= 0.4)
                {
                    //pas de mise on check ou on bourrine
                       
                    if (this.Game.CurrentRaise.Money == 0)
                    {
                        Random rnd = new Random((int) DateTime.Now.Ticks);

                        int pif = rnd.Next(1, 3);

                        if (pif == 1)
                        {
                            this.Check();
                            return;
                        
                        }
                        if (this.game.MainPot.Money  > 3 * this.game.Dispatcher.GameData.BigBlind)
                        { 
                           //value bet
                            this.BetRaise((long)(this.game.MainPot.Money / 2));
                            return;
                        }
                        else
                        {
                            this.BetRaise(5 * this.game.Dispatcher.GameData.BigBlind);
                            return;
                        }
                    }
                    else{

                        if (this.game.CurrentRaise.Money> 5 * this.game.Dispatcher.GameData.BigBlind)
                        {
                            if (won > 50)
                            {
                                this.BetRaise(this.game.CurrentRaise.Money);
                            }
                            else
                            {
                                if (won > 30)
                                {
                                    this.Call();
                                }
                                else {
                                    this.Fold();
                                }
                            }
                            return;
                        }
                        else
                        {
                            this.BetRaise(5 * this.game.Dispatcher.GameData.BigBlind);
                            return;
                        }
                    
                    }
                }
                else //cote moyenne
                {


                    if (this.game.CurrentRaise.Money == 0)
                    {

                        if (IsOtherPassivFlop())
                        {

                            this.BetRaise(this.game.Dispatcher.GameData.BigBlind * 3);
                            return;


                        }
                        else {

                            this.Check();
                            return;
                        
                        }
                    }





                    if (this.game.CurrentTurn == 1 && this.game.CurrentRaise.Money < this.money.Money / 2)
                    {
                        if (won > 30)
                        {
                            if (this.game.CurrentRaise.Money < this.game.Dispatcher.GameData.BigBlind * 3)
                                this.BetRaise((long)(this.game.MainPot.Money / 4));
                            else {

                                this.Call();
                            
                            }
                            return;
                        }
                    }
                    else
                    {
                        if (Cote.computeDiffCote(this.game, this) < 0.2)
                        {
                            if (this.game.CurrentTurn > 1)
                            {
                                this.Fold();
                                return;
                            
                            }
                            if (this.game.CurrentRaise.Money - this.ownpot.Money  < 1.0/6.0 * this.Money.Money && this.game.CurrentRaise.Money - this.ownpot.Money < 3 * this.game.GameData.BigBlind)
                            {
                                this.Call();
                                return;

                            }
                            this.Fold();
                            return;

                        }

                    }
                }
            }
            else {
                if (!IsSomeoneAllin() && this.Profil.HandsPlayed >=5)
                {
                    if (this.Profil.IsAttacking && this.game.CurrentRaise.Money == 0 && IsOtherPassivFlop())
                    {
                        this.BetRaise(3 * this.game.GameData.BigBlind);
                        return;


                    }
                }
                //if (this.Profil.IsAttacking && this.game.Dispatcher.Analyser.TetesDetection >= 1 && this.game.CurrentRaise.Money == 0)
                //{
                //    this.BetRaise((long)(1.0 / 2.0 * this.game.MainPot.Money));
                //    return;
                //}

            
            }

            if (this.game.CurrentRaise.Money == 0)
            {
                this.Check();
                return;

            }
            ////faire caller si pas assez d'argent 
            //if (this.game.CurrentRaise.Money - this.ownpot.Money <= 3 * this.game.GameData.BigBlind)
            //{
            //    this.Call();
            //    return;

            //}

            this.Fold();
        }

        private void SeekWhatToDoDTC_12_PreFlop()
        {
            double statwon;
            double floor = 0; //limite de paiement


            //fait tapis si on a un M petit et une main a peu pres correct
            if (Cote.IsAlert(this.game, this) && (privateCardsType < 6 || privateCardsType == 7))
            {
                this.Allin();
                return;
            }

            if (TryToStealBlindAggr())
                return;

            //gere les grosses relances
            if (DoIhaveToPayAllin())
                return;



            if (this.Hand.Card1.Color == this.Hand.Card2.Color)
                statwon = KnownStats.statSuited[KnownStats.GetInd(this.Hand.Card1.ValueR), KnownStats.GetInd(this.Hand.Card2.ValueR), this.game.NbrPlayerInGame - 2, 0];

            else

                statwon = KnownStats.statUnSuited[KnownStats.GetInd(this.Hand.Card1.ValueR), KnownStats.GetInd(this.Hand.Card2.ValueR), this.game.NbrPlayerInGame - 2, 0];


            switch (this.game.NbrPlayerInGame)
            {
                case 10: floor = 16.0; break;
                case 9: floor = 16.0; break;
                case 8: floor = 18.0; break;
                case 7: floor = 19.0; break;
                case 6: floor = 22.0; break;
                case 5: floor = 25.0; break;
                case 4: floor = 30.0; break;
                case 3: floor = 40.0; break;
                case 2: floor = 50.0; break;

            }
            //si bonne main 
            if (statwon >= floor)
            {
                if (this.game.CurrentRaise.Money == this.game.Dispatcher.GameData.BigBlind)
                {
                    this.BetRaise(4 * this.game.GameData.BigBlind);
                    return;
                }
                if (this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                {
                    this.BetRaise(3 * this.game.GameData.BigBlind);
                    return;
                }

                if (this.game.CurrentRaise.Money - this.ownpot.Money <= this.Money.Money / 6.0)
                {
                    this.Call();
                    return;
                }

            }
            else
            {
                //si on a pas la cote mais que ca coute pas tres cher  et qu'il ya pas de gars aggr on joue looze
                if (this.game.CurrentRaise.Money - this.ownpot.Money <= this.game.GameData.BigBlind && this.game.WhatIsTheNumberOfPlayerBehindMe() < 4 && this.profil.HandsPlayed >= 5 && IsEveryBodyInGamePassiv())
                {
                    //pas une bonne main mais on joue loose vu le profil des joueurs apres
                    this.Call();
                    return;
                }
            }



            switch (privateCardsType)
            { //AQ AT 
                case 5: if (this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                    {
                        this.BetRaise(this.game.Dispatcher.GameData.BigBlind * 3);
                        return;

                    }
                    else
                    {

                        if (Cote.IsCoteOk(this.game, this))
                        {
                            this.Call();
                            return;
                        }

                    }

                    break;


                case 4:
                case 1:
                case 2: if (Cote.IsCoteOk(this.game, this))
                    {
                        if (this.game.CurrentRaise.Money != 0)
                        {
                            this.BetRaise(this.game.CurrentRaise.Money * 3);
                            return;
                        }
                        else
                        {
                            this.BetRaise(this.game.CurrentBB * 4);
                            return;
                        }

                    }
                    else
                    {
                        if (this.game.CurrentRaise.Money >= this.game.CurrentBB * 3)
                        {
                            this.Call();
                            return;
                        }
                        else
                        {
                            this.BetRaise(this.game.CurrentBB * 3);
                            return;
                        }
                    }
                    break;
                case 3:
                    if (this.game.NbrPlayerInGame <= 6 && this.Hand.Card1.ValueR >= 9)
                    {
                        if (this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                        {
                            this.BetRaise(this.game.Dispatcher.GameData.BigBlind * 3);
                            return;

                        }
                        else
                        {
                            //VERIF ICI 

                            this.Fold();
                            //this.Call();
                            return;
                        }

                    }
                    else
                    {

                        if (this.game.NbrPlayerInGame <= 4 && this.Hand.Card1.ValueR >= 6)
                        {
                            if (this.game.CurrentRaise.Money < this.game.Dispatcher.GameData.BigBlind * 3)
                            {
                                this.BetRaise(this.game.Dispatcher.GameData.BigBlind * 3);
                                return;
                            }
                            else
                            {

                                this.Call();
                                return;


                            }

                        }
                        else
                        {



                            if (this.game.CurrentRaise.Money < this.game.Dispatcher.GameData.BigBlind * 3)
                            {
                                this.Call();
                                return;

                            }

                        }



                    } break;

                case 8: if (Cote.IsCoteOk(this.game, this) && this.game.NbrPlayerInGame <= 6)
                    {
                        this.Call(); return;
                    }
                    break;

                case 7:
                case 6:
                    if (Cote.IsCoteOk(this.game, this) && this.game.NbrPlayerInGame <= 4)
                    {
                        this.Call(); return;
                    }
                    break;
                default: break;


            }
            //limp de la SB  sur joueur looze
            if (this.game.CurrentRaise.Money == this.game.GameData.BigBlind && this.ownpot.Money == this.game.GameData.SmallBlind && this.game.GetPlayer((int)this.game.CurrentBB).Profil.PercentageRaisePreFlop() < 20)
            {

                this.Call();
                return;
            }



            this.Fold();
        }
        private void SeekWhatToDoDTC_12_PostFlop()
        {
            Odds odds = new Odds(this.game);
            odds.Player = this;
            int won = odds.ComputeStats();


            //DETECTER LES GROSSES CARTES QUI CASSENT LES PAIRES SERVIES  A K J Q   
            //il faudrait differer les turn et river
            if ((this.privateCardsType == 3 || this.privateCardsType == 2 || this.privateCardsType == 1))
            {
                int cardHigher = 0;
                int sameCards = 0;

                if (this.game.Board.Flop1.Value > this.Hand.Card1.Value)
                    cardHigher++;
                if (this.game.Board.Flop2.Value > this.Hand.Card1.Value)
                    cardHigher++;
                if (this.game.Board.Flop3.Value > this.Hand.Card1.Value)
                    cardHigher++;

                if (this.game.Board.Flop1.Value == this.Hand.Card1.Value)
                    sameCards++;
                if (this.game.Board.Flop2.Value == this.Hand.Card1.Value)
                    sameCards++;
                if (this.game.Board.Flop3.Value == this.Hand.Card1.Value)
                    sameCards++;

                if (this.game.Board.Turn != null)
                {
                    if (this.game.Board.Turn.Value > this.Hand.Card1.Value)
                        cardHigher++;

                    if (this.game.Board.Turn.Value == this.Hand.Card1.Value)
                        sameCards++;
                }
                if (this.game.Board.River != null)
                {

                    if (this.game.Board.River.Value > this.Hand.Card1.Value)
                        cardHigher++;
                    if (this.game.Board.River.Value == this.Hand.Card1.Value)
                        sameCards++;
                }

                if (cardHigher >= 1 && sameCards == 0)
                {
                    // alert mode total
                    if (this.game.CurrentRaise.Money == 0)
                    {
                        this.Check();
                        return;
                    }
                    else
                    {
                        if (this.game.CurrentRaise.Money < 3 * this.game.GameData.BigBlind)
                        {
                            //on attaque une fausse relance à la turn
                            if (this.game.CurrentTurn == 1)
                            {
                                this.BetRaise(2 * this.game.GameData.BigBlind);
                                return;
                            }
                            else
                            {
                                //faire caller si pas assez d'argent 
                                if (this.game.CurrentRaise.Money - this.ownpot.Money < this.game.GameData.BigBlind)
                                {
                                    this.Allin();
                                    return;

                                }

                                this.Fold();
                                return;
                            }
                        }
                        else
                        {

                            this.Fold();
                            return;
                        }

                    }
                }
                //la paire est belle (je parle de cartes)
                if (this.game.CurrentRaise.Money > 3 * this.game.GameData.BigBlind)
                {
                    if (Cote.IsCoteOk(this.game, this))
                    {
                        this.Call();// BetRaise((long)(1.0 / 2.0) * this.game.MainPot.Money);
                        return;
                    }
                    else
                    {
                        this.Fold();
                        return;

                    }

                }
                //notre paire est belle( je parle de cartes)
                if (this.game.CurrentRaise.Money <= 3 * this.game.GameData.BigBlind)
                {
                    this.BetRaise((long)(1.0 / 2.0) * this.game.MainPot.Money);
                    return;
                }

            }




            if (Cote.IsCoteOk(this.game, this))
            {
                //grosse cote 
                if (Cote.computeDiffCote(this.game, this) >= 0.4)
                {
                    //pas de mise on check ou on bourrine
                    Random rnd = new Random((int)DateTime.Now.Ticks);
                    if (this.Game.CurrentRaise.Money == 0)
                    {
                       

                        int pif = rnd.Next(1, 3);

                        if (pif == 1)
                        {
                            this.Check();
                            return;

                        }
                      
                        if (this.game.MainPot.Money > 3 * this.game.Dispatcher.GameData.BigBlind)
                        {
                            //value bet
                            this.BetRaise((long)(this.game.MainPot.Money / 2));
                            return;
                        }
                        else
                        {
                            this.BetRaise(5 * this.game.Dispatcher.GameData.BigBlind);
                            return;
                        }
                    }
                    else
                    {

                        if (this.game.CurrentRaise.Money > 5 * this.game.Dispatcher.GameData.BigBlind)
                        {
                            if (won > 50)
                            {
                                
                                    this.BetRaise(this.game.CurrentRaise.Money);
                               
                            }
                            else
                            {
                                if (won > 30 && this.game.CurrentTurn==1)
                                {
                                    
                                        this.Call();
                                   
                                }
                                else
                                {
                                    this.Fold();
                                }
                            }
                            return;
                        }
                        else
                        {
                            this.BetRaise(5 * this.game.Dispatcher.GameData.BigBlind);
                            return;
                        }

                    }
                }
                else //cote moyenne
                {


                    if (this.game.CurrentRaise.Money == 0)
                    {

                        if (IsOtherPassivFlop())
                        {

                            this.BetRaise(this.game.Dispatcher.GameData.BigBlind * 3);
                            return;


                        }
                        else
                        {

                            this.Check();
                            return;

                        }
                    }





                    if (this.game.CurrentTurn == 1 && this.game.CurrentRaise.Money < this.money.Money / 2)
                    {
                        if (won > 30)
                        {
                            if (this.game.CurrentRaise.Money < this.game.Dispatcher.GameData.BigBlind * 3)
                                this.BetRaise((long)(this.game.MainPot.Money / 4));
                            else
                            {

                                this.Call();

                            }
                            return;
                        }
                    }
                    else
                    {
                        if (Cote.computeDiffCote(this.game, this) < 0.2)
                        {
                            if (this.game.CurrentTurn > 1)
                            {
                                this.Fold();
                                return;

                            }
                            if (this.game.CurrentRaise.Money - this.ownpot.Money < 1.0 / 6.0 * this.Money.Money && this.game.CurrentRaise.Money - this.ownpot.Money < 3 * this.game.GameData.BigBlind)
                            {
                                this.Call();
                                return;

                            }
                            this.Fold();
                            return;

                        }

                    }
                }
            }
            else
            {
                if (!IsSomeoneAllin() && this.Profil.HandsPlayed >= 5)
                {
                    if (this.Profil.IsAttacking && this.game.CurrentRaise.Money == 0 && IsOtherPassivFlop())
                    {
                        this.BetRaise(3 * this.game.GameData.BigBlind);
                        return;


                    }
                }
                //if (this.Profil.IsAttacking && this.game.Dispatcher.Analyser.TetesDetection >= 1 && this.game.CurrentRaise.Money == 0)
                //{
                //    this.BetRaise((long)(1.0 / 2.0 * this.game.MainPot.Money));
                //    return;
                //}


            }

            if (this.game.CurrentRaise.Money == 0)
            {
                this.Check();
                return;

            }
            ////faire caller si pas assez d'argent 
            //if (this.game.CurrentRaise.Money - this.ownpot.Money <= 3 * this.game.GameData.BigBlind)
            //{
            //    this.Call();
            //    return;

            //}

            this.Fold();
        }
        private bool IsSomeoneAllin()
        {
            for (int i = 0; i < this.game.NbrPlayerSinceBegin ; i++)
            {
                if (this.game.InRound(i)==1)
                {

                    if (this.game.GetPlayer(i).IsAllin)
                        return true;
                }
            }
            return false;
        }
        private bool IsOtherPassivFlop()
        {
            bool passiv = true;

            for (int i = 0; i < this.game.NbrPlayerSinceBegin && passiv; i++)
            { 
                if(this.game.InRound(i)==1 && this.game.GetPlayer(i).Profil.PayedFlop>2)
                {

                    passiv = passiv && !this.game.GetPlayer(i).Profil.IsAggFlop() && this.game.GetPlayer(i).Profil.GetTransfertFlop() < 20;
                }
          
            
            }
                return passiv;
        
        }
        /// <summary>
        /// not implemented
        /// </summary>
        private void SeekWhatToDoDTC_11_Turn()
        {
            Odds odds = new Odds(this.game);
            odds.Player = this;
            int won = odds.ComputeStats();


            //DETECTER LES GROSSES CARTES QUI CASSENT LES PAIRES SERVIES  A K J  Q   
            //il faudrait differer les turn et river
            if ((this.privateCardsType == 3 || this.privateCardsType == 2 || this.privateCardsType == 1))
            {
                int cardHigher = 0;
                int sameCards = 0;

                if (this.game.Board.Flop1.Value > this.Hand.Card1.Value)
                    cardHigher++;
                if (this.game.Board.Flop2.Value > this.Hand.Card1.Value)
                    cardHigher++;
                if (this.game.Board.Flop3.Value > this.Hand.Card1.Value)
                    cardHigher++;

                if (this.game.Board.Flop1.Value == this.Hand.Card1.Value)
                    sameCards++;
                if (this.game.Board.Flop2.Value == this.Hand.Card1.Value)
                    sameCards++;
                if (this.game.Board.Flop3.Value == this.Hand.Card1.Value)
                    sameCards++;

                if (this.game.Board.Turn != null)
                {
                    if (this.game.Board.Turn.Value > this.Hand.Card1.Value)
                        cardHigher++;

                    if (this.game.Board.Turn.Value == this.Hand.Card1.Value)
                        sameCards++;
                }
                if (this.game.Board.River != null)
                {

                    if (this.game.Board.River.Value > this.Hand.Card1.Value)
                        cardHigher++;
                    if (this.game.Board.River.Value == this.Hand.Card1.Value)
                        sameCards++;
                }

                if (cardHigher >= 1 && sameCards == 0)
                {
                    // alert mode total
                    if (this.game.CurrentRaise.Money == 0)
                    {
                        this.Check();
                        return;
                    }
                    else
                    {
                        if (this.game.CurrentRaise.Money < 3 * this.game.GameData.BigBlind)
                        {
                            if (this.game.CurrentTurn == 1)
                            {
                                this.BetRaise(3 * this.game.GameData.BigBlind);
                                return;
                            }
                            else
                            {
                                //faire caller si pas assez d'argent 
                                if (this.game.CurrentRaise.Money - this.ownpot.Money < this.game.GameData.BigBlind)
                                {
                                    this.Call();
                                    return;

                                }

                                this.Fold();
                                return;
                            }
                        }
                        else
                        {
                            //faire caller si pas assez d'argent 
                            if (this.money.Money < 3 * this.game.GameData.BigBlind)
                            {
                                this.Allin();
                                return;

                            }
                            this.Fold();
                            return;
                        }
                    }
                }
                //notre paire est belle
                if (this.game.CurrentRaise.Money >= 3 * this.game.GameData.BigBlind)
                {
                    this.Call();
                    return;
                }
                //notre paire est belle
                if (this.game.CurrentRaise.Money < 3 * this.game.GameData.BigBlind)
                {
                    this.BetRaise((long)(1.0 / 4.0) * this.game.MainPot.Money);
                    return;
                }

            }


            if (Cote.IsCoteOk(this.game, this))
            {
                if (this.Game.CurrentRaise.Money == 0 || Cote.computeDiffCote(this.game, this) >= 0.4)
                {
                    this.BetRaise((long)(this.game.MainPot.Money / 2));
                    return;
                }
                else
                {
                    if (this.game.CurrentTurn == 1 && this.game.CurrentRaise.Money < this.money.Money / 2)
                    {
                        this.BetRaise((long)(this.game.MainPot.Money / 3));
                        return;
                    }
                    else
                    {
                        if (Cote.computeDiffCote(this.game, this) < 0.2)
                        {
                            if (this.game.CurrentRaise.Money - this.ownpot.Money <= 3 * this.game.GameData.BigBlind)
                            {
                                this.Allin();
                                return;

                            }
                            this.Fold();
                            return;

                        }

                    }
                }
            }
            else
            {

                ////fin etude paire
                //if (this.Profil.IsAttacking && this.game.Dispatcher.Analyser.TetesDetection >= 1 && this.game.CurrentRaise.Money == 0)
                //{
                //    this.BetRaise((long)(1.0 / 2.0 * this.game.MainPot.Money));
                //    return;
                //}


            }

            if (this.game.CurrentRaise.Money == 0)
            {
                this.Check();
                return;

            }
            //faire caller si pas assez d'argent 
            if (this.game.CurrentRaise.Money - this.ownpot.Money <= 3 * this.game.GameData.BigBlind)
            {
                this.Call();
                return;

            }

            this.Fold();
        }
        /// <summary>
        /// non implemented
        /// </summary>

        private void SeekWhatToDoDTC_11_River()
        {
            Odds odds = new Odds(this.game);
            odds.Player = this;
            int won = odds.ComputeStats();


            //DETECTER LES GROSSES CARTES QUI CASSENT LES PAIRES SERVIES  A K J  Q   
            //il faudrait differer les turn et river
            if ((this.privateCardsType == 3 || this.privateCardsType == 2 || this.privateCardsType == 1))
            {
                int cardHigher = 0;
                int sameCards = 0;

                if (this.game.Board.Flop1.Value > this.Hand.Card1.Value)
                    cardHigher++;
                if (this.game.Board.Flop2.Value > this.Hand.Card1.Value)
                    cardHigher++;
                if (this.game.Board.Flop3.Value > this.Hand.Card1.Value)
                    cardHigher++;

                if (this.game.Board.Flop1.Value == this.Hand.Card1.Value)
                    sameCards++;
                if (this.game.Board.Flop2.Value == this.Hand.Card1.Value)
                    sameCards++;
                if (this.game.Board.Flop3.Value == this.Hand.Card1.Value)
                    sameCards++;

                if (this.game.Board.Turn != null)
                {
                    if (this.game.Board.Turn.Value > this.Hand.Card1.Value)
                        cardHigher++;

                    if (this.game.Board.Turn.Value == this.Hand.Card1.Value)
                        sameCards++;
                }
                if (this.game.Board.River != null)
                {

                    if (this.game.Board.River.Value > this.Hand.Card1.Value)
                        cardHigher++;
                    if (this.game.Board.River.Value == this.Hand.Card1.Value)
                        sameCards++;
                }

                if (cardHigher >= 1 && sameCards == 0)
                {
                    // alert mode total
                    if (this.game.CurrentRaise.Money == 0)
                    {
                        this.Check();
                        return;
                    }
                    else
                    {
                        if (this.game.CurrentRaise.Money < 3 * this.game.GameData.BigBlind)
                        {
                            if (this.game.CurrentTurn == 1)
                            {
                                this.BetRaise(3 * this.game.GameData.BigBlind);
                                return;
                            }
                            else
                            {
                                //faire caller si pas assez d'argent 
                                if (this.game.CurrentRaise.Money - this.ownpot.Money < this.game.GameData.BigBlind)
                                {
                                    this.Call();
                                    return;

                                }

                                this.Fold();
                                return;
                            }
                        }
                        else
                        {
                            //faire caller si pas assez d'argent 
                            if (this.money.Money < 3 * this.game.GameData.BigBlind)
                            {
                                this.Allin();
                                return;

                            }
                            this.Fold();
                            return;
                        }
                    }
                }
                //notre paire est belle
                if (this.game.CurrentRaise.Money >= 3 * this.game.GameData.BigBlind)
                {
                    this.Call();
                    return;
                }
                //notre paire est belle
                if (this.game.CurrentRaise.Money < 3 * this.game.GameData.BigBlind)
                {
                    this.BetRaise((long)(1.0 / 4.0) * this.game.MainPot.Money);
                    return;
                }

            }


            if (Cote.IsCoteOk(this.game, this))
            {
                if (this.Game.CurrentRaise.Money == 0 || Cote.computeDiffCote(this.game, this) >= 0.4)
                {
                    this.BetRaise((long)(this.game.MainPot.Money / 2));
                    return;
                }
                else
                {
                    if (this.game.CurrentTurn == 1 && this.game.CurrentRaise.Money < this.money.Money / 2)
                    {
                        this.BetRaise((long)(this.game.MainPot.Money / 3));
                        return;
                    }
                    else
                    {
                        if (Cote.computeDiffCote(this.game, this) < 0.2)
                        {
                            if (this.game.CurrentRaise.Money - this.ownpot.Money <= 3 * this.game.GameData.BigBlind)
                            {
                                this.Allin();
                                return;

                            }
                            this.Fold();
                            return;

                        }

                    }
                }
            }
            else
            {

                ////fin etude paire
                //if (this.Profil.IsAttacking && this.game.Dispatcher.Analyser.TetesDetection >= 1 && this.game.CurrentRaise.Money == 0)
                //{
                //    this.BetRaise((long)(1.0 / 2.0 * this.game.MainPot.Money));
                //    return;
                //}


            }

            if (this.game.CurrentRaise.Money == 0)
            {
                this.Check();
                return;

            }
            //faire caller si pas assez d'argent 
            if (this.game.CurrentRaise.Money - this.ownpot.Money <= 3 * this.game.GameData.BigBlind)
            {
                this.Call();
                return;

            }

            this.Fold();
        }
        /// <summary>
        /// indique si les joueurs en jeu sont passiv en preflop
        /// </summary>
        /// <returns></returns>
        private bool IsEveryBodyInGamePassiv()
        {
            bool passiv = true;
            

            for (int i = 0; i < this.game.NbrPlayerSinceBegin && passiv; i++)
            {
                if(this.game.InRound(i)==1)
                passiv = passiv && !this.game.GetPlayer(i).Profil.IsAggPreFlop();
            
            }

            return passiv;
        }
        /// <summary>
        /// va jouer si il est attaquant  s'il faut ouvrir et qu'il ya  au moins une tete
        /// si il a la cote,  il protege sa main en gars de forte main ,
        /// fold si il a une cote pas suffisante  diff < 0.2
        /// </summary>
        private void SeekWhatToDoDTC_9_PostFlop()
        {
            Odds odds = new Odds(this.game);
            odds.Player = this;
            int won = odds.ComputeStats();
            //value bet au flop
            if (this.Profil.IsAttacking && won > 20 && this.game.CurrentTurn == 1 && this.game.CurrentRaise.Money == 0)
            {
                this.BetRaise(this.game.MainPot.Money / 2);
                return;
            }

            if (this.Profil.IsAttacking && won > 30 && this.game.CurrentTurn == 2 && this.game.CurrentRaise.Money == 0)
            {
                this.BetRaise(this.game.MainPot.Money / 2);
                return;
            }
            if (this.Profil.IsAttacking && won > 40 && this.game.CurrentTurn == 3 && this.game.CurrentRaise.Money == 0)
            {
                this.BetRaise(this.game.MainPot.Money / 2);
                return;
            }
            //  if (this.game.Dispatcher.Analyser.StraightDetection && this.Profil.IsAttacking && this.game.CurrentRaise.Money >= this.game.CurrentBB*3)
            //{
            //     this.Fold();
            //     return;
            //}

            if (Cote.IsCoteOk(this.game, this))
            {
                if (this.Game.CurrentRaise.Money == 0 || Cote.computeDiffCote(this.game, this) >= 0.4)
                {
                    this.BetRaise((long)(this.game.MainPot.Money / 2));
                    return;
                }
                else
                {
                    if (this.game.CurrentTurn == 1 && this.game.CurrentRaise.Money < this.money.Money / 2)
                    {
                        this.BetRaise((long)(this.game.MainPot.Money / 3)); return;
                    }
                    else
                    {
                        if (Cote.computeDiffCote(this.game, this) < 0.2)
                        {
                            if (this.game.CurrentRaise.Money - this.ownpot.Money < this.game.Dispatcher.GameData.BigBlind)
                            {
                                this.Allin();
                                return;
                            }


                            this.Fold();
                            return;

                        }

                    }
                }
            }
            //faire caller si pas assez d'argent 
            //if (this.game.CurrentRaise < 3 * this.game.GameData.BigBlind)
            //{ 
            //this.BetRaise(

            //}

            this.Fold();
        }

        /// <summary>
        /// ne joue que des mains solides, peut peter un all in qd < 5 
        /// attake le coup qd  il a la cote
        /// </summary>

        private void SeekWhatToDoDTC_9_PreFlop()
        {
            double statwon;
            double floor = 0;
            if (Cote.IsAlert(this.game, this) && (privateCardsType < 6 || privateCardsType == 7))
            {
                this.Allin();
                return;
            }

            if (this.Hand.Card1 == null || this.Hand.Card2 == null)
            {
                this.Fold();
                return;
            }
            if (this.Hand.Card1.Color == this.Hand.Card2.Color)
                statwon = KnownStats.statSuited[KnownStats.GetInd(this.Hand.Card1.ValueR), KnownStats.GetInd(this.Hand.Card2.ValueR), this.game.NbrPlayerInGame - 2, 0];

            else

                statwon = KnownStats.statUnSuited[KnownStats.GetInd(this.Hand.Card1.ValueR), KnownStats.GetInd(this.Hand.Card2.ValueR), this.game.NbrPlayerInGame - 2, 0];


            switch (this.game.NbrPlayerInGame)
            {
                case 10: floor = 17.0; break;
                case 9: floor = 18.0; break;
                case 8: floor = 19.0; break;
                case 7: floor = 20.0; break;
                case 6: floor = 23.0; break;
                case 5: floor = 25.0; break;
                case 4: floor = 30.0; break;
                case 3: floor = 40.0; break;
                case 2: floor = 50.0; break;

            }


            if (statwon >= floor)
            {
                if (this.game.CurrentRaise.Money <= 3 * this.game.GameData.BigBlind)
                {
                    this.BetRaise(3 * this.game.GameData.BigBlind);
                    return;
                }


            }
            else
            {

                this.Fold();
                return;
            }



            switch (privateCardsType)
            { //AQ AT 
                case 5: if (this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                    {
                        this.BetRaise(this.game.Dispatcher.GameData.BigBlind * 3);
                        return;

                    }

                    break;


                case 4:
                case 1:
                case 2: if (Cote.IsCoteOk(this.game, this))
                    {
                        if (this.game.CurrentRaise.Money != 0)
                        {
                            this.BetRaise(this.game.CurrentRaise.Money * 3);
                            return;
                        }
                        else
                        {
                            this.BetRaise(this.game.CurrentBB * 3);
                            return;
                        }

                    }
                    else
                    {
                        if (this.game.CurrentRaise.Money >= this.game.CurrentBB * 3)
                        {
                            this.Call();
                            return;
                        }
                        else
                        {
                            this.BetRaise(this.game.CurrentBB * 3);
                            return;
                        }
                    }
                    break;
                case 3:
                    if (this.game.NbrPlayerInGame <= 6 && this.Hand.Card1.ValueR >= 9)
                    {
                        if (this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                        {
                            this.BetRaise(this.game.Dispatcher.GameData.BigBlind * 3);
                            return;

                        }
                        else
                        {

                            this.Call();
                            return;
                        }

                    }
                    else
                    {

                        if (this.game.NbrPlayerInGame <= 4)
                        {

                            this.Call();

                        }



                    } break;

                case 8: if (Cote.IsCoteOk(this.game, this) && this.game.NbrPlayerInGame <= 6)
                    {
                        this.Call(); return;
                    }
                    break;

                case 7:
                case 6:
                    if (Cote.IsCoteOk(this.game, this) && this.game.NbrPlayerInGame <= 4)
                    {
                        this.Call(); return;
                    }
                    break;
                default: break;


            }
            //limp de la SB  sur joueur looze
            if (this.game.CurrentRaise.Money == this.game.GameData.BigBlind && this.ownpot.Money == this.game.GameData.SmallBlind && this.game.GetPlayer((int)this.game.CurrentBB).Profil.PercentageRaisePreFlop() < 20)
            {

                this.Call();
                return;
            }



            this.Fold();
        }
        /// <summary>
        /// random player
        /// </summary>
        private void SeekWhatToDoDrunkenPlayer()
        {
            Random rdm = new Random((int)DateTime.Now.Ticks);
            Random rdm2 = new Random((int)DateTime.Now.Ticks);
            int pif = rdm.Next(1, 10);
            if (pif == 8 || pif == 10)
                this.BetRaise(rdm2.Next(1, 4) * (this.game.CurrentRaise.Money - this.ownpot.Money));
            else
            {
                if (pif == 9)
                {
                    this.Allin();
                }
                else
                {
                    if (pif <= 4)
                        this.Call();
                    else
                    {

                        this.Fold();

                    }
                }

            }

        }
        /// <summary>
        /// Make the cheater evaluates others hands
        /// </summary>
        private int letsCheat()
        {
            this.game.computeOdds(true);
            Random rdm = new Random((int)DateTime.Now.Ticks);
            int eval = this.game.ProbsTab[this.id];
            int max = eval;
            int max2 = 0;
            for (int i = 0; i < this.game.NbrPlayerSinceBegin; i++)
            {
                if (i == this.id) continue;
                if (max < this.game.ProbsTab[i])
                {
                    max = this.game.ProbsTab[i];
                    max2 = max;
                }
                else
                {
                    if (max2 < this.game.ProbsTab[i])
                    {
                        max2 = this.game.ProbsTab[i];

                    }
                }

            }



            if (1 < (double)max / (double)eval && (double)max / (double)eval < 1.5)
            {
                // pas favori mais de pas bcp 
                if (this.game.CurrentTurn == 0 || this.game.CurrentTurn == 1)
                    return 1;
                else return 0;


            }

            if (1 < (double)max / (double)eval)
            {

                return 0;


            }
            int paf;
            if (eval == max && 2 < (double)max / (double)max2)
            {

                paf = rdm.Next(0, 5);
                if (paf == 3)
                    return 3;
                else return 2;
            }

            if (eval == max && 1 < (double)max / (double)max2)
            {

                return 2;
            }




            return 1;

        }
        public int GetIntell()
        {

            return intelligence;
        }
        public int GetAggr()
        {

            return aggressivite;
        }
        public int GetChance()
        {

            return chance;
        }
        public void SetIntell(int inte)
        {
            intelligence = inte;
        }
        public void SetAgg(int ag)
        {
            aggressivite = ag;
        }
        public void SetChance(int ch)
        {
            chance = ch;
        }
        private int Max(Card c1, Card c2)
        {
            if (c1.Value == 1) return 14;
            else return c1.Value > c2.Value ? c1.Value : c2.Value;


        }

        /// <summary>
        /// IA version scenario POSTFLOP
        /// </summary>
        /// <returns>0 fold  1  call/bet  2 raise   3  raise double  4 raise triple  5 allin  </returns>
        public int SeekWhatToDoPostFlop()
        {
            //on extrait les données de la partie
            this.game.Dispatcher.Analyser.Analyse();
            Random rd = new Random((int)DateTime.Now.Ticks);
            int won = 0;

            //case game < 4
            if (this.game.NbrPlayerInGame <= 4)
            {
                double statwon;
                if (this.Hand.Card1.Color == this.Hand.Card2.Color)
                    statwon = KnownStats.statSuited[KnownStats.GetInd(this.Hand.Card1.ValueR), KnownStats.GetInd(this.Hand.Card2.ValueR), this.game.NbrPlayerInGame - 2, 0];

                else

                    statwon = KnownStats.statUnSuited[KnownStats.GetInd(this.Hand.Card1.ValueR), KnownStats.GetInd(this.Hand.Card2.ValueR), this.game.NbrPlayerInGame - 2, 0];

                switch (this.game.NbrPlayerInGame)
                {


                    case 2: if (statwon > 50) return 5;

                        if (this.game.CurrentRaise.Money <= this.game.Dispatcher.GameData.BigBlind && (statwon > 45))
                        {
                            return 4;

                        }
                        if (this.game.CurrentRaise.Money == 3 * this.game.Dispatcher.GameData.BigBlind && (statwon > 45))
                        {
                            return 1;

                        }

                        if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind && (statwon > 45))
                        {
                            return 0;

                        }
                        if (this.game.CurrentRaise.Money < this.game.Dispatcher.GameData.BigBlind)
                        {
                            return 1;

                        }
                        return 0;
                    case 3: if (statwon > 50) return 5;

                        if (this.game.CurrentRaise.Money <= this.game.Dispatcher.GameData.BigBlind && (statwon > 30))
                        {
                            return 4;

                        }
                        if (this.game.CurrentRaise.Money == 3 * this.game.Dispatcher.GameData.BigBlind && (statwon > 30))
                        {
                            return 1;

                        }

                        if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind && (statwon > 30))
                        {
                            return 0;

                        }
                        if (this.game.CurrentRaise.Money < this.game.Dispatcher.GameData.BigBlind)
                        {
                            return 1;

                        }
                        return 0;
                    default: if (statwon > 50) return 5;

                        if (this.game.CurrentRaise.Money <= this.game.Dispatcher.GameData.BigBlind && (statwon > 25))
                        {
                            return 4;

                        }
                        if (this.game.CurrentRaise.Money == 3 * this.game.Dispatcher.GameData.BigBlind && (statwon > 25))
                        {
                            return 1;

                        }

                        if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind && (statwon > 25))
                        {
                            return 0;

                        }
                        if (this.game.CurrentRaise.Money < this.game.Dispatcher.GameData.BigBlind)
                        {
                            return 1;

                        }

                        return 0;


                }


            }
            switch (this.privateCardsType)
            {
                //AA
                case 1:
                    if (this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection <= 1)
                        return 1;

                    if (this.game.Dispatcher.Analyser.FlushAlert >= 3 && this.game.CurrentRaise.Money >= 3 * this.game.Dispatcher.GameData.BigBlind)
                    {
                        if (rd.Next() % 2 == 0)
                            return 0;
                        return 5;
                    }
                    if (this.game.Dispatcher.Analyser.StraightDetection && this.game.CurrentRaise.Money >= 3 * this.game.Dispatcher.GameData.BigBlind)
                    {
                        if (rd.Next() % 2 == 0)
                            return 0;
                        return 5;
                    }
                    if (this.game.CurrentRaise.Money >= this.money.Money)
                        return 5;

                    return 1;



                //KK <-> TT
                case 2:

                    if (this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection == 0)
                        return 1;

                    if (this.game.CurrentRaise.Money == 0)
                        return 3;
                    if (this.game.Dispatcher.Analyser.FlushAlert >= 3 && this.game.CurrentRaise.Money >= 3 * this.game.Dispatcher.GameData.BigBlind)
                    {
                        if (rd.Next() % 2 == 0)
                            return 0;
                        return 5;
                    }
                    if (this.game.Dispatcher.Analyser.StraightDetection && this.game.CurrentRaise.Money >= 3 * this.game.Dispatcher.GameData.BigBlind)
                    {
                        if (rd.Next() % 2 == 0)
                            return 0;
                        return 5;
                    }


                    if (this.game.CurrentRaise.Money <= 2 * this.game.Dispatcher.GameData.BigBlind)
                        return 2;
                    if (this.game.CurrentRaise.Money >= 2 * this.game.Dispatcher.GameData.BigBlind && this.game.Dispatcher.Analyser.TetesDetection == 0)
                        return 5;
                    if (this.game.CurrentRaise.Money >= this.money.Money)
                        return 5;

                    return 0;



                // 99  <-> 22
                case 3:
                    won = ComputeOdds();
                    if (won > 30 && this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection == 0 && this.game.CurrentRaise.Money == 0)
                        return 4;
                    if (this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection >= 1 && this.game.CurrentRaise.Money != 0)
                        return 0;
                    if (this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection >= 1 && this.game.CurrentRaise.Money == 0)
                        return 1;

                    // to do regardez la proba de gagner si ct un flop moyen  <=3 *bb
                    if (this.game.Dispatcher.Analyser.FlopValue < 3)
                    {

                        if (won >= 30)
                            return 2;
                        else
                        {
                            if (this.game.CurrentRaise.Money == 0)
                                return 3;
                            else
                            {
                                if (this.game.CurrentRaise.Money <= 2 * this.game.Dispatcher.GameData.BigBlind)
                                    return 1;
                                else return 0;
                            }
                        }


                    }
                    if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind)
                        return 0;

                    if (won <= 10)
                        return 0;
                    return 1;

                //AK
                case 4://allin si short of stake
                    if (this.money.Money <= this.game.Dispatcher.Analyser.MoneyAverage / 2.0)
                        return 5;
                    if (this.game.Dispatcher.Analyser.FlopValue < 3)
                    {
                        won = ComputeOdds();
                        if (won >= 30)
                            return 1;
                        else
                        {
                            if (this.game.CurrentRaise.Money == 0)
                                return 2;
                            else
                            {
                                if (this.game.CurrentRaise.Money <= 2 * this.game.Dispatcher.GameData.BigBlind)
                                    return 1;
                                else return 0;
                            }
                        }


                    }
                    if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind)
                        return 0;
                    return 1;


                //A   Q<->10
                case 5:
                    won = ComputeOdds();
                    if (this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection == 0 && this.game.CurrentRaise.Money == 0)
                        return 4;
                    if (this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection >= 1 && this.game.CurrentRaise.Money != 0 && won < 10)
                        return 0;
                    if (this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection >= 1 && this.game.CurrentRaise.Money == 0)
                        return 2;

                    // to do regardez la proba de gagner si ct un flop moyen  
                    if (this.game.Dispatcher.Analyser.FlopValue < 3)
                    {

                        if (won >= 30)
                            return 2;
                        else
                        {
                            if (this.game.CurrentRaise.Money == 0)
                                return 3;
                            else
                            {
                                if (this.game.CurrentRaise.Money <= 2 * this.game.Dispatcher.GameData.BigBlind)
                                    return 1;
                                else return 0;
                            }
                        }


                    }
                    if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind && won < 30)
                        return 0;

                    return 1;

                //A  9<->2
                case 6:
                    won = ComputeOdds();
                    if (this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection == 0)
                        return 4;
                    if (this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection >= 1 && this.game.CurrentRaise.Money != 0 && won < 10)
                        return 0;
                    if (this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection >= 1 && this.game.CurrentRaise.Money == 0)
                        return 2;
                    if (won >= 30 && this.game.CurrentRaise.Money == 0)
                        return 2;
                    // to do regardez la proba de gagner si ct un flop moyen  
                    if (this.game.Dispatcher.Analyser.FlopValue < 3)
                    {

                        if (won >= 30)
                            return 2;
                        else
                        {
                            if (this.game.CurrentRaise.Money == 0)
                                return 3;
                            else
                            {
                                if (this.game.CurrentRaise.Money <= 2 * this.game.Dispatcher.GameData.BigBlind)
                                    return 1;
                                else return 0;
                            }
                        }


                    }
                    if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind && won < 30)
                        return 0;

                    return 1;


                // 2 cards >=10
                case 7:
                    won = ComputeOdds();

                    if (won >= 30 && this.game.CurrentRaise.Money == 0 && this.game.Dispatcher.Analyser.FlopValue <= 3)
                        return 3;

                    if (won >= 30 && this.game.CurrentRaise.Money >= 3 * this.game.Dispatcher.GameData.BigBlind)
                        return 1;
                    if (won <= 30 && this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                        return 2;
                    if (won <= 30 && this.game.CurrentRaise.Money >= 3 * this.game.Dispatcher.GameData.BigBlind)
                        return 0;

                    if (won <= 25)
                        return 0;
                    return 1;

                //suited connector
                case 8:
                    won = ComputeOdds();
                    if (won > 30 && this.game.Dispatcher.Analyser.FlopValue >= 3)
                        return 2;

                    if (won > 30)
                        return 2;

                    return 0;

                //others
                case 9:
                    won = ComputeOdds();
                    if (won > 30 && this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection == 0)
                        return 1;
                    if (this.game.Dispatcher.Analyser.FlopValue >= 3 && this.game.Dispatcher.Analyser.TetesDetection >= 1)
                        return 0;
                    if (won > 60 && this.game.CurrentRaise.Money >= 3 * this.game.Dispatcher.GameData.BigBlind)
                        return 3;
                    if (won > 30 && this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                        return 3;

                    return 0;

            }
            return 0;
        }

        /// <summary>
        /// IA version scenario PREFLOP
        /// </summary>
        /// <returns>0 fold  1  call/bet  2 raise   3  raise double  4 raise triple  5 allin  </returns>
        public int SeekWhatToDoPreFlop()
        {
            //on extrait les données de la partie
            this.game.Dispatcher.Analyser.Analyse();
            Random rd = new Random((int)DateTime.Now.Ticks);
            //case game < 4
            if (this.game.NbrPlayerInGame <= 4)
            {
                double statwon = KnownStats.statUnSuited[KnownStats.GetInd(this.Hand.Card1.ValueR), KnownStats.GetInd(this.Hand.Card2.ValueR), this.game.NbrPlayerInGame - 2, 0];
                if (this.Hand.Card1.Color == this.Hand.Card2.Color)
                    statwon += 3.5;
                switch (this.game.NbrPlayerInGame)
                {


                    case 2: if (statwon > 50) return 5;

                        if (this.game.CurrentRaise.Money <= this.game.Dispatcher.GameData.BigBlind && (statwon > 45))
                        {
                            return 4;

                        }
                        if (this.game.CurrentRaise.Money == 3 * this.game.Dispatcher.GameData.BigBlind && (statwon > 45))
                        {
                            return 1;

                        }

                        if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind && (statwon > 45))
                        {
                            return 0;

                        }
                        if (this.game.CurrentRaise.Money == this.game.Dispatcher.GameData.BigBlind)
                        {
                            return 1;

                        }
                        return 0;
                    case 3: if (statwon > 50) return 5;

                        if (this.game.CurrentRaise.Money <= this.game.Dispatcher.GameData.BigBlind && (statwon > 30))
                        {
                            return 4;

                        }
                        if (this.game.CurrentRaise.Money == 3 * this.game.Dispatcher.GameData.BigBlind && (statwon > 30))
                        {
                            return 1;

                        }

                        if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind && (statwon > 30))
                        {
                            return 0;

                        }
                        if (this.game.CurrentRaise.Money == this.game.Dispatcher.GameData.BigBlind)
                        {
                            return 1;

                        }
                        return 0;
                    default: if (statwon > 50) return 5;

                        if (this.game.CurrentRaise.Money <= this.game.Dispatcher.GameData.BigBlind && (statwon > 25))
                        {
                            return 4;

                        }
                        if (this.game.CurrentRaise.Money == 3 * this.game.Dispatcher.GameData.BigBlind && (statwon > 25))
                        {
                            return 1;

                        }

                        if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind && (statwon > 25))
                        {
                            return 0;

                        }
                        if (this.game.CurrentRaise.Money == this.game.Dispatcher.GameData.BigBlind)
                        {
                            return 1;

                        }
                        return 0;


                }


            }
            switch (this.privateCardsType)
            {
                //AA
                case 1:
                    if (this.game.CurrentRaise.Money == this.game.Dispatcher.GameData.BigBlind)
                        if (rd.Next() % 2 == 0)
                            return 5;
                        else return 1;

                    if (this.game.CurrentRaise.Money >= 3 * this.game.Dispatcher.GameData.BigBlind)
                        return 1;

                    return 4;



                //KK <-> TT
                case 2:
                    if (rd.Next() % 2 == 0)
                        return 5;
                    else return 4;



                // 99  <-> 22
                case 3:
                    //allin si short of stake
                    if (this.money.Money <= this.game.Dispatcher.Analyser.MoneyAverage / 2.0)
                        return 5;
                    //enchere trop chere
                    if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind && this.game.NbrPlayerInRound >= 3)
                        return 0;
                    if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind && this.game.NbrPlayerInRound < 3 && this.money.Money >= 1.5 * this.game.CurrentRaise.Money)
                        return 5;

                    if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind && this.game.NbrPlayerInRound < 3)
                        return 0;

                    //enchere pas assez chere
                    if (this.game.CurrentRaise.Money == this.game.Dispatcher.GameData.BigBlind)
                        return 4;

                    return 1;



                //AK
                case 4://allin si short of stake
                    if (this.money.Money <= this.game.Dispatcher.Analyser.MoneyAverage / 2.0)
                        return 5;
                    if (this.game.CurrentRaise.Money > 3 * this.game.Dispatcher.GameData.BigBlind)
                        return 5;

                    else
                        return 4;


                //A   Q<->10
                case 5:
                    //allin si short of stake
                    if (this.money.Money <= this.game.Dispatcher.Analyser.MoneyAverage / 2.0)
                        return 5;
                    if (this.game.CurrentRaise.Money > 4 * this.game.Dispatcher.GameData.BigBlind)
                        return 0;
                    if (this.game.CurrentRaise.Money == this.game.Dispatcher.GameData.BigBlind)
                        return 4;
                    if (this.game.CurrentRaise.Money <= this.game.Dispatcher.GameData.BigBlind)
                        return 2;
                    return 1;

                //A  9<->2
                case 6: //allin si short of stake
                    if (this.money.Money <= this.game.Dispatcher.Analyser.MoneyAverage / 2.0)
                        return 5;
                    if (this.game.CurrentRaise.Money <= 2 * this.game.Dispatcher.GameData.BigBlind)
                        return 1;

                    if (this.game.NbrPlayerInGame <= 4)
                    {
                        if (this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                            return 1;


                    }
                    if (this.game.CurrentSB == this.id && this.game.CurrentRaise.Money == this.game.Dispatcher.GameData.BigBlind)
                        return 1;
                    return 0;


                // 2 cards >=10
                case 7: //allin si short of stack
                    if (this.money.Money <= this.game.Dispatcher.Analyser.MoneyAverage / 2.0)
                        return 5;

                    if (this.game.CurrentRaise.Money <= 4 * this.game.Dispatcher.GameData.BigBlind)
                        return 1;

                    if (this.game.NbrPlayerInGame <= 4)
                    {
                        if (this.game.CurrentRaise.Money <= 3 * this.game.Dispatcher.GameData.BigBlind)
                            return 1;


                    }
                    if (this.game.CurrentSB == this.id && this.game.CurrentRaise.Money == this.game.Dispatcher.GameData.BigBlind)
                        return 1;

                    return 0;

                //suited connector
                case 8:
                    if (this.money.Money <= this.game.Dispatcher.Analyser.MoneyAverage / 3.0)
                        return 5;
                    if (this.game.CurrentRaise.Money <= this.game.Dispatcher.GameData.BigBlind)
                        return 1;
                    if (this.game.NbrPlayerInGame <= 4)
                    {
                        if (this.game.CurrentRaise.Money <= 2 * this.game.Dispatcher.GameData.BigBlind)
                            return 1;


                    }
                    if (this.game.CurrentSB == this.id && this.game.CurrentRaise.Money == this.game.Dispatcher.GameData.BigBlind)
                        return 1;
                    return 0;

                //others
                case 9:
                    if ((this.Hand.Card1.ValueR > 10 || this.Hand.Card2.ValueR > 10) && this.game.CurrentRaise.Money - this.TotalRaise.Money <= this.money.Money / 10)
                        return 1;

                    if (this.game.CurrentRaise.Money - this.TotalRaise.Money <= this.money.Money / 20)
                        return 1;
                    if (this.game.CurrentRaise.Money >= 2 * this.game.Dispatcher.GameData.BigBlind)
                        return 0;

                    if (rd.Next(0, 8) == 3)
                        return 1;


                    if (this.game.CurrentSB == this.id && this.game.CurrentRaise.Money == this.game.Dispatcher.GameData.BigBlind)
                        return 1;
                    return 0;


            }
            return 0;
        }
        private Odds odds;
        /// <summary>
        /// return % to win, and compute in object pourcentage to get each hand
        /// </summary>
        /// <returns></returns>
        public int ComputeOdds()
        {
            odds.Player = this;
            return odds.ComputeStats();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void SeekWhatToDoScrVersion()
        {
            int todo = 0;
            switch (this.game.CurrentTurn)
            {
                case 0: todo = SeekWhatToDoPreFlop(); break;
                case 1: todo = SeekWhatToDoPostFlop(); break;
                case 2: todo = SeekWhatToDoPostFlop(); break;
                default: todo = SeekWhatToDoPostFlop(); break;

            }

            switch (todo)
            {
                case 0: //fold 
                    if (this.game.CurrentRaise.Money - this.ownpot.Money == 0)
                        this.Check();
                    else this.Fold();
                    break;
                case 1: if (this.game.CurrentRaise.Money != 0) this.Call();
                    else
                        this.BetRaise(this.game.GameData.Min);

                    break;
                case 2: if (this.game.CurrentRaise.Money != 0) this.Call();
                    else
                        this.BetRaise(this.game.GameData.Min);

                    break;

                case 3:
                    this.BetRaise(this.game.GameData.Min * 2);

                    break;
                case 4:
                    this.BetRaise(this.game.GameData.Min * 3);

                    break;
                default: this.Allin(); break;


            }

        }
        /// <summary>
        /// let's decide what to do 
        /// </summary>
        /// <returns></returns>
        public int SeekWhatToDo()
        {
            int[] list1 = new int[9];  //hand type player wins
            int[] list2 = new int[9];    //others hands	
            int won = 0;
            Deck deck = new Deck();
            if (this.game.CurrentTurn != 0)
            {
                for (int i = 0; i < 5000; i++) //tirage des cartes
                {
                    Card c1 = this.Hand.Card1;
                    Card c2 = this.Hand.Card2;
                    Card b1 = this.Game.Board.Flop1;
                    Card b2 = this.Game.Board.Flop2;
                    Card b3 = this.Game.Board.Flop3;
                    Card b4 = this.Game.Board.Turn;
                    Card b5 = this.Game.Board.River;
                    list1[0] = Max(c1, c2);
                    //reinit du game 
                    deck.Shuffle();
                    deck.RemoveACard(c1);
                    deck.RemoveACard(c2);
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
                    Hand hand = new Hand(c1, c2, b1, b2, b3, b4, b5);
                    hand.EvaluateHand();
                    //compute hand type
                    ArrayList others = new ArrayList(9);

                    for (int e = 0; e < game.NbrPlayerInRound - 1; e++)
                    {
                        Card p1 = new Card(deck.TakeACard());
                        Card p2 = new Card(deck.TakeACard());
                        Hand h = new Hand(p1, p2, b1, b2, b3, b4, b5);
                        h.EvaluateHand();
                        others.Add(h);
                    }
                    bool b = true;
                    foreach (Hand h in others)
                    {
                        if (hand >= h)
                            continue;
                        else { b = false; break; }

                    }
                    if (b) won++;
                    switch (hand.CombiId)
                    {
                        case STRAIGHTFLUSH: list1[8]++; list1[4]++; list1[5]++; break;
                        case FOUR: list1[7]++;
                            list1[1]++;
                            list1[2]++;
                            list1[3]++; break;
                        case FULL: list1[6]++;
                            list1[1]++;
                            list1[2]++;
                            list1[3]++; break;
                        case FLUSH: list1[5]++; break;
                        case STRAIGHT: list1[4]++; break;
                        case THREE: list1[3]++;
                            list1[1]++; break;
                        case TWOPAIRS: list1[1]++;
                            list1[2]++; break;
                        case PAIR: list1[1]++; break;
                        default: break;


                    }

                }
                list1[0] = Max(this.Hand.Card1, this.Hand.Card2);
                for (int i = 0; i < 5000; i++) //tirage des cartes adv
                {
                    Card c1 = null;
                    Card c2 = null;
                    Card b1 = this.Game.Board.Flop1;
                    Card b2 = this.Game.Board.Flop2;
                    Card b3 = this.Game.Board.Flop3;
                    Card b4 = this.Game.Board.Turn;
                    Card b5 = this.Game.Board.River;
                    deck.Shuffle();

                    deck.RemoveACard(this.Hand.Card1);
                    deck.RemoveACard(this.Hand.Card2);
                    if (b1 != (null)) deck.RemoveACard(b1);
                    if (b2 != (null)) deck.RemoveACard(b2);
                    if (b3 != (null)) deck.RemoveACard(b3);
                    if (b4 != (null)) deck.RemoveACard(b4);
                    if (b5 != (null)) deck.RemoveACard(b5);

                    c1 = new Card(deck.TakeACard());
                    c2 = new Card(deck.TakeACard());
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
                    Hand hand = new Hand(c1, c2, b1, b2, b3, b4, b5);
                    hand.EvaluateHand();
                    switch (hand.CombiId)
                    {
                        case STRAIGHTFLUSH: list2[8]++; list2[4]++; list2[5]++; break;
                        case FOUR: list2[7]++;
                            list2[1]++;
                            list2[2]++;
                            list2[3]++; break;
                        case FULL:
                            list2[6]++;
                            list2[1]++;
                            list2[2]++;
                            list2[3]++; break;
                        case FLUSH:
                            list2[5]++; break;
                        case STRAIGHT:
                            list2[4]++; break;
                        case THREE:
                            list2[3]++;
                            list2[1]++; break;
                        case TWOPAIRS:
                            list2[1]++;
                            list2[2]++; break;
                        case PAIR:
                            list2[1]++; break;
                        default: break;


                    }

                }
            }
            //finish to compute 
            if (this.game.CurrentTurn == 0)
            {



                if ((this.Hand.Card1.ValueR + this.Hand.Card2.ValueR == 2) && this.Hand.Card2.ValueR == this.Hand.Card1.ValueR)//AA
                    return 3;
                if ((this.Hand.Card1.ValueR + this.Hand.Card2.ValueR == 28) && this.Hand.Card2.ValueR == this.Hand.Card1.ValueR)//AA
                    return 3;
                if ((this.Hand.Card1.ValueR + this.Hand.Card2.ValueR == 26) && this.Hand.Card2.ValueR == this.Hand.Card1.ValueR)//KK
                    return 3;
                if ((this.Hand.Card1.ValueR + this.Hand.Card2.ValueR == 24) && this.Hand.Card2.ValueR == this.Hand.Card1.ValueR)//QQ
                    return 3;
                if ((this.Hand.Card1.ValueR + this.Hand.Card2.ValueR == 22) && this.Hand.Card2.ValueR == this.Hand.Card1.ValueR)//JJ
                    return 3;
                if ((this.Hand.Card1.ValueR + this.Hand.Card2.ValueR == 27 && this.Hand.Card1.AbsColor == this.Hand.Card2.AbsColor))//AK
                    return 3;

                //paur >= T T 
                if ((this.Hand.Card1.ValueR >= 10) && this.Hand.Card1.ValueR == this.Hand.Card2.ValueR) // > 10 10
                    return 3;
                if (this.Hand.Card1.ValueR == this.Hand.Card2.ValueR) // > 10 10
                    return 2;

                if ((this.Hand.Card1.ValueR + this.Hand.Card2.ValueR >= 20) && this.Hand.Card1.ValueR == this.Hand.Card2.ValueR) // > 10 10
                    return 2;
                if ((this.Hand.Card1.ValueR == 1 || this.Hand.Card2.ValueR == 1) && ((this.Hand.Card1.ValueR >= 10 || this.Hand.Card2.ValueR >= 10)))
                    return 2;
                if ((this.Hand.Card1.ValueR + this.Hand.Card2.ValueR >= 20) && this.Hand.Card1.AbsColor == this.Hand.Card2.AbsColor)
                    return 2;
                if ((this.Hand.Card1.ValueR == 1 || this.Hand.Card2.ValueR == 1) && ((this.Hand.Card1.ValueR >= 7 || this.Hand.Card2.ValueR >= 7)))
                    return 1;
                if ((this.Hand.Card1.ValueR == this.Hand.Card2.ValueR && this.Hand.Card2.ValueR > 7))
                    return 2;
                if ((this.Hand.Card1.ValueR == this.Hand.Card2.ValueR - 1 || this.Hand.Card2.ValueR == this.Hand.Card1.ValueR - 1) && ((this.Hand.Card1.AbsColor == this.Hand.Card2.AbsColor)))
                    return 1;
                if (this.Hand.Card1.ValueR + this.Hand.Card2.ValueR >= 18)
                    return 1;
                if (this.Id == this.game.CurrentSB && this.game.PreviousRaise == this.game.Dispatcher.GameData.BigBlind)
                    return 1;

                return 0;
            }
            if (this.game.CurrentTurn == 1)
            {
                if ((float)100.0f * won / 5000.0f >= 50.0f)
                    return 2;
                if ((float)100.0f * won / 5000.0f >= 30.0f)
                    return 2;

                if ((float)100.0f * won / 5000.0f >= 10.0f)
                    return 1;
                return 0;
            }
            if (this.game.CurrentTurn == 2)
            {
                if ((float)100.0f * won / 5000.0f >= 50.0f)
                    return 2;

                if ((float)100.0f * won / 5000.0f >= 20.0f)
                    return 1;
                return 0;
            }

            if ((float)100.0f * won / 5000.0f >= 50.0f)
                return 3;

            if ((float)100.0f * won / 5000.0f >= 20.0f)
                return 2;
            return 0;

            /*
                        float paire=(list1[1]-list2[1])/5000.0f;
                        float dpaire=(list1[2]-list2[2])/5000.0f;
                        //float high=(list1[0]>list2[0])?1:2;
                        float brelan=(list1[3]-list2[3])/5000.0f;
                        float quinte=(list1[4]-list2[4])/5000.0f;
                        float flush=(list1[5]-list2[5])/5000.0f;
                        float full=(list1[6]-list2[6])/5000.0f;
                        float carre=(list1[7]-list2[7])/5000.0f;
                        float qf=(list1[8]-list2[8])/5000.0f;
  
                        if( qf>0.3) return 3;//2 ->raise 
                        if (carre>0.3) return 3;
                        if (full>0.3) return 3;
                        if(flush>0.3) return 3;
                        if(quinte >0.2 && full>-0.5 && flush>-0.5  && carre>-0.5  ) return 3;//raise
                        if(brelan >0.2 && full >-0.5 && flush>-0.5 && carre>-0.5  )
                                         return 2;
                        if(dpaire>0.2  && full>-0.5 && brelan >-0.5 && flush>-0.5 && carre>-0.5  )
                            return 2;
                        if(((paire>0.2 && Game.CurrentTurn<1) || paire >0.8)  && flush>-0.5 && carre>-0.5  )
                            return 2;
                        if(Game.CurrentTurn<=1 && list1[0]>=11) return 1; //call (ou raise)
                        if(this.Hand.Card1.Value<=7 && this.Hand.Card2.Value<=7)  
                    return 0;
                        else {if (Game.CurrentTurn==0  && (this.Hand.Card1.Value>=10 && this.Hand.Card2.Value>=10)) return 1;}
                        return 0;
                        */

        }
        public bool Bluff
        {
            get { return this.bluff; }
            set { this.bluff = value; }
        }
        private int intelligence;
        private int aggressivite;
        private int chance;
        private bool bluff = false;
        private const int HIGH = 0;
        private const int PAIR = 1;
        private const int TWOPAIRS = 2;
        private const int THREE = 3;
        private const int FOUR = 7;
        private const int STRAIGHT = 4;
        private const int FULL = 6;
        private const int FLUSH = 5;
        private const int STRAIGHTFLUSH = 8;
    }
}
