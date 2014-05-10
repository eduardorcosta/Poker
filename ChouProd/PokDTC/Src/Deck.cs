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
    /// describe a 52 playing cards deck
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// build a deck
        /// </summary>
        public Deck()
        {
            deck = new int[52];
           // rdm1 = new Random((int)DateTime.Now.Ticks);
            rdm2 = new MyRandom();
            Shuffle();
        }
        /// <summary>
        /// allow all card to be picked
        /// </summary>
        public void Shuffle()
        {

            for (int i = 0; i < 52; i++)
            {
                deck[i] = 1;
            }

        }
        //
        /// <summary>
        /// pick a card available from the actual deck
        /// </summary>
        /// <returns></returns>
        public int TakeACard()
        {
            bool correct = false;
            while (!correct)
            {
                int a = rdm2.getRandomNumber();
                for ( a = 0; a < 10; a++)
                    rdm2.getRandomNumber();
                int card = rdm2.getRandomNumber()+1; // rdm1.Next(1, 52);
                if (deck[card - 1] != 0)
                {
                    correct = true;
                    deck[card - 1] = 0;
                    return card;
                }
            }
            return 0;

        }
        /// <summary>
        /// the deck ,  1 if available, 0 if already piked
        /// </summary>
        private int[] deck;
        private Random rdm1;
        private MyRandom rdm2;
        /// <summary>
        /// remove a card from the deck 
        /// </summary>
        /// <param name="c">card to be removed</param>
        public void RemoveACard(Card c)
        {

            deck[c.AbsValue - 1] = 0;

        }
    }
}
