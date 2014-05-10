
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

namespace poker
{
    /// <summary>
    /// game properties
    /// </summary>
    public class GameData
    {   ///Game type 
        private const int NOLIMIT = 1;
        private const int POTLIMIT = 2;
        private const int LIMIT = 3;
        //time allowed to mind
        private int time2Mind=60;//big blind

        public int Time2Mind
        {
            get { return time2Mind; }
            set { time2Mind = value; }
        }

        private int timeIncrease=300*3;

        public int TimeIncrease
        {
            get { return timeIncrease; }
            set { timeIncrease = value; }
        }

        private bool hardcoreMode=true;

        public bool HardcoreMode
        {
            get { return hardcoreMode; }
            set { hardcoreMode = value; }
        }
        private long bigBlind;//big blind
        private long smallBlind;//small blind 
        private int type = 1;
        private long min = 0;//minimum of a raise/bet
        private long max = 0;//maximum of a raise/bet 
        private long ante = 0;
        private int nbrplayer = 5;
        private string nameOfLocal;
        private int nbreOfGame = 0;

        public int NbreOfGame
        {
            get { return nbreOfGame; }
            set { nbreOfGame = value; }
        }


        private AggressiveMode aggrMode;

        internal AggressiveMode AggrMode
        {
            get { return aggrMode; }
            set { aggrMode = value; }
        }
        
        private long money = 15000;//start money
        /// <summary>
        /// build game properties
        /// </summary>
        /// <param name="t"> game type</param>
        /// <param name="s"> smal blind</param>
        /// <param name="b">big blind</param>
        /// <param name="ma">start money </param>
        /// <param name="an">ante</param>
        /// <param name="p">number of player</param>
        /// <param name="n">name of player </param>
        public GameData(int t, long s, long b, long ma, long an, int p, string n)
        {
            money = ma;
            type = t;
            min = b;
            max = 2 * b;
            smallBlind = s;
            bigBlind = b;
            ante = an;
            nbrplayer = p;
            nameOfLocal = n;
            this.min = b;
            this.aggrMode = new AggressiveMode(Form1.prog_version.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ty">poker type</param>
        /// <param name="s">small blind</param>
        /// <param name="b">big blind</param>
        /// <param name="an">ante</param>
        /// <param name="p">number of player</param>
        /// <param name="n">name of local</param>
        public GameData(int ty, long s, long b, long an, int p, string n)
        {
            this.min = b;
            type = ty;
            smallBlind = s;
            bigBlind = b;
            ante = an;
            nbrplayer = p;
            nameOfLocal = n;
            this.aggrMode = new AggressiveMode(Form1.prog_version.ToString());

        }
        public string ShowType()
        {
            switch (type)
            {
                case LIMIT: return "Limit";
                case POTLIMIT: return "Pot Limit";
                case NOLIMIT: return "No Limit";
                default: return "Unknown";
            }
        }
        public long Max
        {
            get { return max; }
            set { max = value; }
        }
        public long Min
        {
            get { return min; }
            set { min = value; }
        }
        public long Ante
        {
            get { return ante; }
            set { ante = value; }
        }
        public long SmallBlind
        {
            get { return smallBlind; }
            set { smallBlind = value; }
        }
        public long BigBlind
        {
            get { return bigBlind; }
            set { bigBlind = value; }
        }
        public int Nbr
        {
            get { return this.nbrplayer; }
            set { this.nbrplayer = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Name
        {
            get { return nameOfLocal; }
            set { nameOfLocal = value; }
        }
        public long Money
        {
            get { return money; }
            set { money = value; }
        }

    }
}
