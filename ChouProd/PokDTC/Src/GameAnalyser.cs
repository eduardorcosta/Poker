
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
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace poker
{
    public class GameAnalyser
    {

        private int flopValue;  //  0   <=BB      ---- 1   BB <->2xBB  -------2   3 xBB  --------3      >3xBB

        public int FlopValue
        {
            get { return flopValue; }
            set { flopValue = value; }
        }
        //private int communityCardsNature;//  4 flush ,  5 tetes , 6 quinte, 7 autres

        private int communityCardsNatureFlop;//  0   <=BB      ---- 1   BB <->2xBB  -------2   3 xBB  --------3      >3xBB
        private int communityCardsNatureTurn;//  0   <=BB      ---- 1   BB <->2xBB  -------2   3 xBB  --------3      >3xBB
        private int communityCardsNatureRiver;//  0   <=BB      ---- 1   BB <->2xBB  -------2   3 xBB  --------3      >3xBB
        private int flushAlert; //nbr max repetition couleur

        public int FlushAlert
        {
            get { return flushAlert; }
            set { flushAlert = value; }
        }
        private int tetesDetection; //nbr de tetes (>10) 

        public int TetesDetection
        {
            get { return tetesDetection; }
            set { tetesDetection = value; }
        }
        private bool straightDetection; //  vois si une quinte est possible

        public bool StraightDetection
        {
            get { return straightDetection; }
            set { straightDetection = value; }
        }
        private bool RealstraightDetection;// quinte présente

        public bool RealstraightDetection1
        {
            get { return RealstraightDetection; }
            set { RealstraightDetection = value; }
        }
        private Game game;
        private long moneyAverage;

        public long MoneyAverage
        {
            get { return moneyAverage; }
            set { moneyAverage = value; }
        }
        public GameAnalyser(Game g)
        {
            this.game = g;
        }

        public void Analyse()
        {
            long accuMoney=0;
            for (int i = 0; i < this.game.NbrPlayerSinceBegin; i++)
            {
                if (this.game.InGame(i) == 1)
                    accuMoney += this.game.GetPlayer(i).Money.Money + this.game.GetPlayer(i).OwnPot.Money;
            }
            moneyAverage = accuMoney / this.game.NbrPlayerInGame;
            switch (this.game.CurrentTurn)
            {//preflop
                case 0: 
                    if (this.game.CurrentRaise.Money == this.game.GameData.BigBlind)
                        flopValue = 0;
                    else {

                        if ( this.game.CurrentRaise.Money <= 2 * this.game.GameData.BigBlind)
                            flopValue = 1;
                        else
                        {
                            if ( this.game.CurrentRaise.Money == 3 * this.game.GameData.BigBlind)
                                flopValue = 2;
                            else
                            {

                                flopValue = 3;  
                            }

                        }
                }

                    
                    
                        break;
                    //flop
                    case 1: this.communityCardsNatureFlop = AnalyseCommunity(); break;
                    //Turn
                    case 2: this.communityCardsNatureTurn = AnalyseCommunity(); break;
               //river
                    default: this.communityCardsNatureRiver = AnalyseCommunity(); break;
            
            }
        
        
        }

        private int AnalyseCommunity()
        {

            ArrayList cards = new ArrayList(10);
            switch (this.game.CurrentTurn)
            {
                case 0: //rien à faire
                        break; 
                case 1: cards.Add(this.game.Board.Flop1); cards.Add(this.game.Board.Flop2); cards.Add(this.game.Board.Flop3);
                   
                    break;
                case 2: cards.Add(this.game.Board.Flop1); cards.Add(this.game.Board.Flop2); cards.Add(this.game.Board.Flop3);
                    cards.Add(this.game.Board.Turn);
                    break;
                default: cards.Add(this.game.Board.Flop1); cards.Add(this.game.Board.Flop2); cards.Add(this.game.Board.Flop3);
                    cards.Add(this.game.Board.Turn); cards.Add(this.game.Board.River);
                    break;
            }

            AnalyseHeads(cards);
            AnalyseFlush(cards);
            AnalyseStraight(cards);
            if (this.game.CurrentRaise.Money >= this.game.GameData.BigBlind)
               return 0;
            else
            {

                if (this.game.CurrentRaise.Money <= 2 * this.game.GameData.BigBlind)
                   return 1;
                else
                {
                    if (this.game.CurrentRaise.Money == 3 * this.game.GameData.BigBlind)
                        return 2;
                    else
                    {

                        return 3;
                    }

                }
            }


        }

        private void AnalyseStraight(ArrayList cards)
        {
            cards.Sort(new CardComparer());
            if (((Card)(cards[cards.Count - 1])).ValueR == 1)
            {
                cards.Insert(0, cards[cards.Count - 1]);
            }

            //ici on a une panachée de carte bouclant sur l'as 
            this.straightDetection =false;
            this.RealstraightDetection = false;
            int accu = 0;
            int max_accu=0;

            int old = ((Card)cards[0]).ValueR;
            //on compte les cartes qui se suivent
        for(int i =1 ; i < cards.Count;i++)
        {

            if ((((Card)cards[i]).ValueR == 1 && old==13) ||((Card)cards[i]).ValueR == old + 1)
            {
                accu++;
                max_accu=Math.Max(accu, max_accu);
            }
            else
            {

                if (((Card)cards[i]).ValueR > old)
                    accu = 0;
            }
        
        }
            switch(this.game.CurrentTurn){
               
                case 1: if (accu == 3) this.straightDetection = true; break;
                case 2: if (accu >= 4) this.straightDetection = true; break;
                case 3: if (accu >= 4) this.straightDetection = true; if (accu == 5) this.RealstraightDetection = true; break;
        }

        }

        private void AnalyseFlush(ArrayList cards)
        {
            int nbr_spade = 0;
            int nbr_diamond = 0;
            int nbr_heart = 0;
            int nbr_club = 0;

            foreach (Card c in cards)
            {
                switch (c.AbsColor)
                {
                    case 1:  nbr_heart++; break;
                    case 2:  nbr_diamond++; break;
                    case 3:  nbr_spade++; break;
                    default: nbr_club++; break;
                }
            }

           flopValue= max4(nbr_heart, nbr_club, nbr_diamond, nbr_spade);
        }

        private int max4(int nbr_heart, int nbr_club, int nbr_diamond, int nbr_spade)
        {
         return  Math.Max( Math.Max(nbr_heart,  nbr_club), Math.Max(nbr_diamond,  nbr_spade) );
        }

        private void AnalyseHeads(ArrayList cards)
        {
            tetesDetection = 0;
            foreach (Card c in cards)
            {
                if (c.ValueR >= 11 || c.ValueR == 1)
                    tetesDetection++;
            }
        }


        
    }
}
