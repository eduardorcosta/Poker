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
///to do correct the takedownTurn takeTurnFlop takeDownPreFlop takeDownRiver
///
namespace poker
{
    /// <summary>
    /// Describe the current profile player, profiling feature
    /// </summary>
    public class CurrentProfil
    {

       
        private int showdowns = 0;
        private int allins = 0;
        private int allinsWon = 0;

        private long moneyWon = 0;
        private int won = 0;
        private int takedowns = 0;
        private int wonWithoutShow = 0;
        private bool payed = false;
        private int takedownTurn = 0;
        private bool iswinner = false;
        private bool show = false;

        private bool isAttacking = false;

        private int nbBetFlop = 0;

        public int NbBetFlop
        {
            get { return nbBetFlop; }
            set { nbBetFlop = value; }
        }
        private int nbBetTurn = 0;

        public int NbBetTurn
        {
            get { return nbBetTurn; }
            set { nbBetTurn = value; }
        }
        private int nbBetRiver = 0;

        public int NbBetRiver
        {
            get { return nbBetRiver; }
            set { nbBetRiver = value; }
        }

        public double PercentageCallFlop()
        {
            return (double)this.nbCallFlop * 100.0 / this.payedFlop;
        
        }
        public double PercentageCallRiver()
        {
            return (double)this.nbCallRiver * 100.0 / this.payedRiver;

        }
        public double PercentageCallTurn()
        {
            return (double)this.nbCallTurn * 100.0 / this.payedTurn;

        }


        public double PercentageCheckFlop()
        {
            return (double)this.nbCheckFlop * 100.0 / this.payedFlop;

        }
        public double PercentageCheckRiver()
        {
            return (double)this.nbCheckRiver * 100.0 / this.payedRiver;

        }
        public double PercentageCheckTurn()
        {
            return (double)this.nbCheckTurn * 100.0 / this.payedTurn;

        }


        public double PercentageReRaiseFlop()
        {
            return (double)this.nbReRaiseFlop * 100.0 / this.payedFlop;

        }
        public double PercentageReRaiseRiver()
        {
            return (double)this.nbReRaiseRiver * 100.0 / this.payedRiver;

        }
        public double PercentageReRaiseTurn()
        {
            return (double)this.nbReRaiseTurn * 100.0 / this.payedTurn;

        }

        public bool IsAggPreFlop()
        {
            double res = (double)((this.NbRaisePreflop + this.NbReRaisePreflop) * 100.0 / this.handsPlayed);

            return 40.0 < res;
        
        }
        public bool IsAggFlop()
        {
            return 40.0 < ((this.nbRaiseFlop + this.NbReRaiseFlop +this.nbBetFlop )* 100.0 / this.handsPlayed);

        }
        public bool IsAggTurn()
        {
            return 40.0 < ((this.nbRaiseTurn + this.NbReRaiseTurn + this.nbBetTurn) * 100.0 / this.handsPlayed);

        }
        public bool IsAggRiver()
        {
            return 50.0 < ((this.nbRaiseRiver + this.NbReRaiseRiver + this.nbBetRiver) * 100.0 / this.handsPlayed);

        }
        public double PercentageRaiseFlop()
        {
            return(double)this.nbRaiseFlop * 100.0 / this.payedFlop;

        }

        public double PercentageRaisePreFlop()
        {
            return (double)this.nbRaisePreflop * 100.0 / this.handsPlayed;

        }

        public double PercentageRaiseRiver()
        {
            return (double)this.nbRaiseRiver * 100.0 / this.payedRiver;

        }
        public double PercentageRaiseTurn()
        {
            return (double)this.nbRaiseTurn * 100.0 / this.payedTurn;

        }

        public bool IsAttacking
        {
            get { return isAttacking; }
            set { isAttacking = value; }
        }
        private int handsPlayed = 0;

        private int nbFoldPreflop = 0;

        public int NbFoldPreflop
        {
            get { return nbFoldPreflop; }
            set { nbFoldPreflop = value; }
        }
        private int nbFoldFlop = 0;

        public int NbFoldFlop
        {
            get { return nbFoldFlop; }
            set { nbFoldFlop = value; }
        }
        private int nbFoldTurn = 0;
        public int NbFoldTurn
        {
            get { return nbFoldTurn; }
            set { nbFoldTurn = value; }
        }
        private int nbFoldRiver = 0;
        public int NbFoldRiver
        {
            get { return nbFoldRiver; }
            set { nbFoldRiver = value; }
        }
        private int nbCallPreflop = 0;

        public int NbCallPreflop
        {
            get { return nbCallPreflop; }
            set { nbCallPreflop = value; }
        }
        private int nbRaisePreflop = 0;

        public int NbRaisePreflop
        {
            get { return nbRaisePreflop; }
            set { nbRaisePreflop = value; }
        }
        private int nbReRaisePreflop = 0;

        public int NbReRaisePreflop
        {
            get { return nbReRaisePreflop; }
            set { nbReRaisePreflop = value; }
        }
        private int nbCheckPreflop = 0;

        public int NbCheckPreflop
        {
            get { return nbCheckPreflop; }
            set { nbCheckPreflop = value; }
        }

        private int payedFlop = 0;
        private int nbCallFlop = 0;

        public int NbCallFlop
        {
            get { return nbCallFlop; }
            set { nbCallFlop = value; }
        }
        private int nbRaiseFlop = 0;

        public int NbRaiseFlop
        {
            get { return nbRaiseFlop; }
            set { nbRaiseFlop = value; }
        }
        private int nbReRaiseFlop = 0;

        public int NbReRaiseFlop
        {
            get { return nbReRaiseFlop; }
            set { nbReRaiseFlop = value; }
        }
        private int nbCheckFlop = 0;

        public int NbCheckFlop
        {
            get { return nbCheckFlop; }
            set { nbCheckFlop = value; }
        }
        private int nbCheckPreFlop = 0;

        public int NbCheckPreFlop
        {
            get { return nbCheckPreFlop; }
            set { nbCheckPreFlop = value; }
        }
        private int payedTurn = 0;

        public int PayedTurn
        {
            get { return payedTurn; }
            set { payedTurn = value; }
        }
        private int nbCallTurn = 0;

        public int NbCallTurn
        {
            get { return nbCallTurn; }
            set { nbCallTurn = value; }
        }
        private int nbRaiseTurn = 0;

        public int NbRaiseTurn
        {
            get { return nbRaiseTurn; }
            set { nbRaiseTurn = value; }
        }
        private int nbReRaiseTurn = 0;

        public int NbReRaiseTurn
        {
            get { return nbReRaiseTurn; }
            set { nbReRaiseTurn = value; }
        }
        private int nbCheckTurn = 0;

        public int NbCheckTurn
        {
            get { return nbCheckTurn; }
            set { nbCheckTurn = value; }
        }

        private int payedRiver = 0;

        public int PayedRiver
        {
            get { return payedRiver; }
            set { payedRiver = value; }
        }
        private int nbCallRiver = 0;

        public int NbCallRiver
        {
            get { return nbCallRiver; }
            set { nbCallRiver = value; }
        }
        private int nbRaiseRiver = 0;

        public int NbRaiseRiver
        {
            get { return nbRaiseRiver; }
            set { nbRaiseRiver = value; }
        }
        private int nbReRaiseRiver = 0;

        public int NbReRaiseRiver
        {
            get { return nbReRaiseRiver; }
            set { nbReRaiseRiver = value; }
        }
        private int nbCheckRiver = 0;

        public int NbCheckRiver
        {
            get { return nbCheckRiver; }
            set { nbCheckRiver = value; }
        }


        private int nbCheckRaise = 0;

        public double GetTransfertFlopTurn()
        {

            return (double)payedTurn * 100.0 / (double)this.handsPlayed;
        }

        public double GetTransfertFlopRiver()
        {

            return (double)payedRiver * 100.0 / (double)this.handsPlayed;
        }

        public double GetTransfertFlop() 
        {

            return (double)payedFlop * 100.0 / (double)this.handsPlayed;
        }

        public double GetTransfertPercFlopTurn()
        {

            return (double)this.payedTurn*100.0 / (double)payedFlop;
        }

        public double GetTransfertPercTurnRiver()
        {

            return (double)this.payedRiver * 100.0 / (double)payedTurn;
        }
        public void IncreaseRaise(Game game)
        {
           game.SetEveryBodyToDefense();
            int turn = game.CurrentTurn;
            this.IsAttacking = true;
            switch (turn)
            {
                case 0: this.nbRaisePreflop++; break;
                case 1: this.nbRaiseFlop++; break;
                case 2: this.nbRaiseTurn++; break;
                default: this.nbRaiseRiver++; break;

            }
        
        }
        public void IncreaseCall(Game game)
        {
            int turn = game.CurrentTurn;

            switch (turn)
            {
                case 0: this.nbCallPreflop++; break;
                case 1: this.nbCallFlop++; break;
                case 2: this.nbCallTurn++; break;
                default: this.nbCallRiver++; break;

            }

        }
        public void IncreaseReRaise(Game game)
        {
            game.SetEveryBodyToDefense();
            int turn = game.CurrentTurn;
            this.IsAttacking = true;
            switch (turn)
            {
                case 0: this.nbReRaisePreflop++; break;
                case 1: this.nbReRaiseFlop++; break;
                case 2: this.nbReRaiseTurn++; break;
                default: this.nbReRaiseRiver++; break;

            }

        }
        public void IncreaseFold(Game game)
        {
            int turn = game.CurrentTurn;

            switch (turn)
            {
                case 0: this.nbFoldPreflop++; break;
                case 1: this.nbFoldFlop++; break;
                case 2: this.nbFoldTurn++; break;
                default: this.nbFoldRiver++; break;

            }

        }

        public void IncreaseBet(Game game)
        {
           game.SetEveryBodyToDefense();
            int turn = game.CurrentTurn;
            this.IsAttacking = true;

            switch (turn)
            {
                case 0:  break;
                case 1: this.nbBetFlop++; break;
                case 2: this.nbBetTurn++; break;
                default: this.nbBetRiver++; break;

            }

        }

        public void IncreaseCheck(Game game)
        {
            int turn = game.CurrentTurn;

            switch (turn)
            {
                case 0: this.nbCheckPreFlop++; break;
                case 1: this.nbCheckFlop++; break;
                case 2: this.nbCheckTurn++; break;
                default: this.nbCheckRiver++; break;

            }

        }

        public int NbCheckRaise
        {
            get { return nbCheckRaise; }
            set { nbCheckRaise = value; }
        }

        /// <summary>
        /// get or set  , true if the player has shown his hand
        /// </summary>
        public bool Show
        {
            get { return show; }
            set { show = value; }

        }
        /// <summary>
        /// get or set, number of takedowns at the turn 
        /// </summary>
        public int TakedownTurn
        {
            get { return takedownTurn; }
            set { takedownTurn = value; }

        }
        /// <summary>
        /// get or set,  true if the player won the hand 
        /// </summary>
        public bool IsWinner
        {
            get { return iswinner; }
            set { iswinner = value; }

        }
        /// <summary>
        /// get or set, true if the player payed to see the flop
        /// </summary>
        public bool Payed
        {
            get { return payed; }
            set { payed = value; }

        }
        /// <summary>
        /// get or set, nomber of game won without showing his hand
        /// </summary>
        public int WonWithoutShow
        {
            get { return this.wonWithoutShow; }
            set { this.wonWithoutShow = value; }

        }
        /// <summary>
        /// get or set, all money won (can be negative)
        /// </summary>
        public long MoneyWon
        {
            get { return moneyWon; }
            set { moneyWon = value; }

        }
        /// <summary>
        /// get or set , nomber of takedowns same has takedowwTurn
        /// </summary>
        public int TakeDowns
        {
            get { return this.takedowns; }
            set { this.takedowns = value; }
        }

        public CurrentProfil()
        {
        }
        /// <summary>
        /// get or set number of showdowns
        /// </summary>
        public int Showdowns
        {
            get { return this.showdowns; }
            set { this.showdowns = value; }

        }
        /// <summary>
        /// get or set number of allin
        /// </summary>
        public int Allins
        {
            get { return this.allins; }
            set { this.allins = value; }

        }
        /// <summary>
        /// get or set number of allin won 
        /// </summary>
        public int AllinsWon
        {
            get { return this.allinsWon; }
            set { this.allinsWon = value; }

        }
        /// <summary>
        /// number of flop viewed (payed)
        /// </summary>
        public int PayedFlop
        {
            get { return this.payedFlop; }
            set { this.payedFlop = value; }

        }
        /// <summary>
        /// number of victory
        /// </summary>
        public int Won
        {
            get { return this.won; }
            set { this.won = value; }

        }
        /// <summary>
        /// number of party played
        /// </summary>
        public int HandsPlayed
        {
            get { return this.handsPlayed; }
            set { this.handsPlayed = value; }

        }
    }
}
