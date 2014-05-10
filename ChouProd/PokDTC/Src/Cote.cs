
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

namespace poker
{
    class Cote
    {

        /// <summary>
        /// return ratio cote pot
        /// </summary>
        /// <param name="game">game </param>
        /// <param name="pl">   player</param>
        /// <returns>return 1/(c+1)</returns>
        public static double ComputeCotePot(Game game, Player pl)
        {
            long money2paid = game.Pot.Money - pl.TotalRaise.Money;

            return (double)money2paid / (game.Pot.Money+money2paid);
        
        }

        /// <summary>
        /// calcul immediat cote by ratio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pl"></param>
        /// <returns></returns>
        public static double CoteJuste(Game g,Player pl)
        {

            Odds odds = new Odds(g);
            odds.Player = pl;
            int won = odds.ComputeStats();
            double won2= (double)won /100.0;
            return won2;
        
        }
        /// <summary>
        /// says if the cote is positive
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pl"></param>
        /// <returns></returns>
        public static bool IsCoteOk(Game g, Player pl)
        {
            double coteJ = CoteJuste(g, pl);
            double cotePot = ComputeCotePot(g, pl);
            return coteJ >= cotePot;
        
        }
        public static double computeDiffCote(Game g, Player pl)
        {

            return CoteJuste(g, pl) - ComputeCotePot(g, pl);

        }

        public static bool IsAlert(Game g, Player pl)
        {
            return (double) pl.Money.Money /g.GameData.BigBlind <5.0;

        }

    }
}
