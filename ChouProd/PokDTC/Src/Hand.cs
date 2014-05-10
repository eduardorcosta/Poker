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
using System.Collections;
using System.Windows.Forms;
namespace poker
{
    /// <summary>
    /// Describe hand combination 
    /// </summary>
    public class Hand
    {
        public Hand() { }
        /// <summary>
        /// build a hand with 7 cards 
        /// </summary>
        /// <param name="p1">private card 1 </param>
        /// <param name="p2">private card 2 </param>
        /// <param name="cc">the board</param>
        public Hand(Card p1, Card p2, CommunityCards cc)
        {
            card1 = p1;
            card2 = p2;
            card3 = cc.Flop1;
            card4 = cc.Flop2;
            card5 = cc.Flop3;
            card6 = cc.Turn;
            card7 = cc.River;
        }
        /// <summary>
        /// build a hand with 7 cards , order doesn't mind
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="c3"></param>
        /// <param name="c4"></param>
        /// <param name="c5"></param>
        public Hand(Card p1, Card p2, Card c1, Card c2, Card c3, Card c4, Card c5)
        {
            card1 = p1;
            card2 = p2;
            card3 = c1;
            card4 = c2;
            card5 = c3;
            card6 = c4;
            card7 = c5;

        }
        /// <summary>
        /// build a 2 private cards hand 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public Hand(Card p1, Card p2)
        {
            card1 = p1;
            card2 = p2;


        }
        /// <summary>
        /// build a hand with private and flop cards
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="c3"></param>
        public Hand(Card p1, Card p2, Card c1, Card c2, Card c3)
        {
            card1 = p1;
            card2 = p2;
            card3 = c1;
            card4 = c2;
            card5 = c3;
        }
        /// <summary>
        /// build a hand with private flop and turn cards
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="c3"></param>
        /// <param name="c4"></param>
        public Hand(Card p1, Card p2, Card c1, Card c2, Card c3, Card c4)
        {
            card1 = p1;
            card2 = p2;
            card3 = c1;
            card4 = c2;
            card5 = c3;
            card6 = c4;
        }
        //seeking for cards repeating (pair /three of /four of/full house)
        /// <summary>
        /// return Max value between 2 simple value (Ace =1) but Ace is the greatest 
        ///
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>14 if ace, normal value otherwise</returns>
        private int Max(int a, int b)
        {
            if (a == 1) return 14;
            if (b == 1) return 14;
            if (a > b) return a; else return b;
        }
        /// <summary>
        /// detect four of a kind, change hand properties if necessary
        /// </summary>
        /// <returns>true if four of a kind</returns>
        public bool IsFour()
        {

            //paireX indik le nombre de fois k'une carte est répétée
            int paire1 = 0;
            int paire2 = 0;
            int paire3 = 0;
            int paire4 = 0;
            int paire5 = 0;
            int paire6 = 0;
           // ArrayList liste;
            int c1 = card1.Value;
            int c2 = card2.Value;
            int b1 = card3.Value;
            int b2 = card4.Value;
            int b3 = card5.Value;
            int b4 = card6.Value;
            int b5 = card7.Value;
            if (c1 == c2)
            {
                paire1++;
            }
            if (c1 == b1)
            {
                paire1++;
            }
            if (c1 == b2)
                paire1++;
            if (c1 == b3)
                paire1++;
            if (c1 == b4)
                paire1++;
            if (c1 == b5)
                paire1++;

            if (c2 != c1)
            {
                if (c2 == b1)
                {
                    paire2++;
                }
                if (c2 == b2)
                {
                    paire2++;
                }
                if (c2 == b3)
                {
                    paire2++;
                }
                if (c2 == b4)
                {
                    paire2++;
                }
                if (c2 == b5)
                {
                    paire2++;
                }
            }
            if (b1 == b2)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;


            }
            if (b1 == b3)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b1 == b4)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b1 == b5)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b2 == b3)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }
            if (b2 == b4)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }
            if (b2 == b5)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }

            if (b3 == b4)
            {
                if (c1 != b3 && b3 != c2 && b1 != b3 && b3 != b2)
                    paire5++;

            }
            if (b3 == b5)
            {
                if (c1 != b3 && b3 != c2 && b1 != b3 && b3 != b2)
                    paire5++;

            }

            if (b4 == b5)
            {
                if (c1 != b4 && b4 != c2 && b1 != b4 && b4 != b2 && b4 != b3)
                    paire6++;

            }

            if (paire1 == 3 || paire2 == 3 || paire3 == 3 || paire4 == 3)
            {
                int max = 0;
                if (paire1 == 3)
                {
                    max = Max(c1, max);

                }
                if (paire2 == 3)
                {
                    max = Max(c2, max);
                }
                if (paire3 == 3)
                {
                    max = Max(b1, max);
                }
                if (paire4 == 3)
                {
                    max = Max(b2, max);
                }
                if (max == 14) max = 1;
                hand1 = new Card(1, max);
                hand2 = new Card(2, max);
                hand3 = new Card(3, max);
                hand4 = new Card(4, max);
                this.combiId = FOUR;
                combiName = "Four of " + hand1.Name + "s";
                return true;


            }
            else
            {
                return false;
            }


        }
        /// <summary>
        /// detect four house, change hand properties if necessary
        /// </summary>
        /// <returns>true if true :o) </returns>
        public bool IsFull()
        {
            //paireX is the number of time a card is repeated
            int paire1 = 0;
            int paire2 = 0;
            int paire3 = 0;
            int paire4 = 0;
            int paire5 = 0;
            int paire6 = 0;
            //ArrayList liste;
            int c1 = card1.Value;
            int c2 = card2.Value;
            int b1 = card3.Value;
            int b2 = card4.Value;
            int b3 = card5.Value;
            int b4 = card6.Value;
            int b5 = card7.Value;
            if (c1 == c2)
            {
                paire1++;
            }
            if (c1 == b1)
            {
                paire1++;
            }
            if (c1 == b2)
                paire1++;
            if (c1 == b3)
                paire1++;
            if (c1 == b4)
                paire1++;
            if (c1 == b5)
                paire1++;

            if (c2 != c1)
            {
                if (c2 == b1)
                {
                    paire2++;
                }
                if (c2 == b2)
                {
                    paire2++;
                }
                if (c2 == b3)
                {
                    paire2++;
                }
                if (c2 == b4)
                {
                    paire2++;
                }
                if (c2 == b5)
                {
                    paire2++;
                }
            }
            if (b1 == b2)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;


            }
            if (b1 == b3)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b1 == b4)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b1 == b5)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b2 == b3)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }
            if (b2 == b4)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }
            if (b2 == b5)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }

            if (b3 == b4)
            {
                if (c1 != b3 && b3 != c2 && b1 != b3 && b3 != b2)
                    paire5++;

            }
            if (b3 == b5)
            {
                if (c1 != b3 && b3 != c2 && b1 != b3 && b3 != b2)
                    paire5++;

            }

            if (b4 == b5)
            {
                if (c1 != b4 && b4 != c2 && b1 != b4 && b4 != b2 && b4 != b3)
                    paire6++;

            }
            if ( //type 3 + 2 
                    (
                    (paire1 == 2 || paire2 == 2 || paire3 == 2 || paire4 == 2 || paire5 == 2) &&
                    (paire1 == 1 || paire2 == 1 || paire3 == 1 || paire4 == 1 || paire5 == 1 || paire6 == 1)
                    )
                    ||
                    (
                    //type 3 + 3

                    (paire1 == 2 &&( paire2 == 2 || paire3 == 2 || paire4 == 2 || paire5 == 2))
                    ||
                     (paire2 == 2 && (paire1 == 2 || paire3 == 2 || paire4 == 2 || paire5 == 2))
                    ||
                     (paire3 == 2 && (paire2 == 2 || paire1 == 2 || paire4 == 2 || paire5 == 2))
                    ||
                      (paire4 == 2 && (paire2 == 2 || paire3 == 2 || paire1 == 2 || paire5 == 2))
                    ||
                      (paire4 == 5 && (paire2 == 2 || paire3 == 2 || paire1 == 2 || paire1 == 2))
                    )

                    
                    
                )
                
            {
                int maxB = 0;
                int maxP = 0;
                if (paire1 == 2)
                    maxB = Max(c1, maxB);
                if (paire2 == 2)
                    maxB = Max(c2, maxB);
                if (paire3 == 2)
                    maxB = Max(b1, maxB);
                if (paire4 == 2)
                    maxB = Max(b2, maxB);
                if (paire5 == 2)
                    maxB = Max(b3, maxB);

                if (paire1 == 1)
                {
                    if (Max(c1, maxP) != maxB)
                        maxP = Max(c1, maxP);
                }
                if (paire2 == 1)
                {
                    if (Max(c2, maxP) != maxB)
                        maxP = Max(c2, maxP);
                }
                if (paire3 == 1)
                {
                    if (Max(b1, maxP) != maxB)
                        maxP = Max(b1, maxP);
                }
                if (paire4 == 1)
                {
                    if (Max(b2, maxP) != maxB)
                        maxP = Max(b2, maxP);
                }

                if (paire5 == 1)
                {
                    if (Max(b3, maxP) != maxB)
                        maxP = Max(b3, maxP);
                }

                if (paire6 == 1)
                {
                    if (Max(b4, maxP) != maxB)
                        maxP = Max(b4, maxP);
                }
                //seek three of 
                Card aux1 = new Card(1, maxB);
                Card aux2 = new Card(2, maxB);
                Card aux3 = new Card(3, maxB);
                Card aux4 = new Card(4, maxB);
                ArrayList arr = new ArrayList(10);
                int count = 1;
                arr.Add(card1);
                arr.Add(card2);
                arr.Add(card3);
                arr.Add(card4);
                arr.Add(card5);
                arr.Add(card6);
                arr.Add(card7);
                if (aux1.Exists(arr))
                {
                    hand1 = aux1;
                    count++;
                }
                if (aux2.Exists(arr))
                {
                    if (count == 1)
                        hand1 = aux2;
                    else
                        hand2 = aux2;
                    count++;
                }
                if (aux3.Exists(arr))
                {
                    switch (count)
                    {
                        case 1: hand1 = aux3; break;
                        case 2: hand2 = aux3; break;
                        default: hand3 = aux3; break;

                    }
                    count++;
                }
                if (aux4.Exists(arr))
                {
                    switch (count)
                    {
                        case 1: hand1 = aux4; break;
                        case 2: hand2 = aux4; break;
                        default: hand3 = aux4; break;

                    }
                    count++;
                }
                if (maxP == 0)
                {


                    //this.combiId=THREE;
                    //this.combiName="Three of " + hand1.Name;

                    return false; //brelan

                }
                //seek for pair 
                Card aux11 = new Card(1, maxP);
                Card aux22 = new Card(2, maxP);
                Card aux33 = new Card(3, maxP);
                Card aux44 = new Card(4, maxP);

                count = 1;

                if (aux11.Exists(arr))
                {
                    hand4 = aux11;
                    count++;
                }
                if (aux22.Exists(arr))
                {
                    if (count == 1)
                        hand4 = aux22;
                    else
                        hand5 = aux22;
                    count++;
                }
                if (aux33.Exists(arr))
                {
                    switch (count)
                    {
                        case 1: hand4 = aux33; break;
                        case 2: hand5 = aux33; break;

                    }
                    count++;
                }
                if (aux44.Exists(arr))
                {
                    switch (count)
                    {
                        case 1: hand4 = aux44; break;
                        case 2: hand5 = aux44; break;


                    }
                    count++;
                }
                this.combiId = FULL;
                this.combiName = "Full House " + hand1.Name + "s over " + hand4.Name + "s";

                return true; //full
            }
            else
            { return false; }




        }
        /// <summary>
        /// detect three of a kind, change hand properties if necessary
        /// </summary>
        /// <returns>true if true :o) </returns>
        public bool IsThree()
        {


            int paire1 = 0;
            int paire2 = 0;
            int paire3 = 0;
            int paire4 = 0;
            int paire5 = 0;
            int paire6 = 0;
            //ArrayList liste;
            int c1 = card1.Value;
            int c2 = card2.Value;
            int b1 = card3.Value;
            int b2 = card4.Value;
            int b3 = card5.Value;
            int b4 = card6.Value;
            int b5 = card7.Value;
            if (c1 == c2)
            {
                paire1++;
            }
            if (c1 == b1)
            {
                paire1++;
            }
            if (c1 == b2)
                paire1++;
            if (c1 == b3)
                paire1++;
            if (c1 == b4)
                paire1++;
            if (c1 == b5)
                paire1++;

            if (c2 != c1)
            {
                if (c2 == b1)
                {
                    paire2++;
                }
                if (c2 == b2)
                {
                    paire2++;
                }
                if (c2 == b3)
                {
                    paire2++;
                }
                if (c2 == b4)
                {
                    paire2++;
                }
                if (c2 == b5)
                {
                    paire2++;
                }
            }
            if (b1 == b2)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;


            }
            if (b1 == b3)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b1 == b4)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b1 == b5)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b2 == b3)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }
            if (b2 == b4)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }
            if (b2 == b5)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }

            if (b3 == b4)
            {
                if (c1 != b3 && b3 != c2 && b1 != b3 && b3 != b2)
                    paire5++;

            }
            if (b3 == b5)
            {
                if (c1 != b3 && b3 != c2 && b1 != b3 && b3 != b2)
                    paire5++;

            }

            if (b4 == b5)
            {
                if (c1 != b4 && b4 != c2 && b1 != b4 && b4 != b2 && b4 != b3)
                    paire6++;

            }
            if ((paire1 == 2 || paire2 == 2 || paire3 == 2 || paire4 == 2 || paire5 == 2))
            {
                int maxB = 0;
                if (paire1 == 2)
                    maxB = Max(c1, maxB);
                if (paire2 == 2)
                    maxB = Max(c2, maxB);
                if (paire3 == 2)
                    maxB = Max(b1, maxB);
                if (paire4 == 2)
                    maxB = Max(b2, maxB);
                if (paire5 == 2)
                    maxB = Max(b3, maxB);


                //seek three of 
                Card aux1 = new Card(1, maxB);
                Card aux2 = new Card(2, maxB);
                Card aux3 = new Card(3, maxB);
                Card aux4 = new Card(4, maxB);
                ArrayList arr = new ArrayList(10);
                int count = 1;
                arr.Add(card1);
                arr.Add(card2);
                arr.Add(card3);
                arr.Add(card4);
                arr.Add(card5);
                arr.Add(card6);
                arr.Add(card7);
                if (aux1.Exists(arr))
                {
                    hand1 = aux1;
                    count++;
                }
                if (aux2.Exists(arr))
                {
                    if (count == 1)
                        hand1 = aux2;
                    else
                        hand2 = aux2;
                    count++;
                }
                if (aux3.Exists(arr))
                {
                    switch (count)
                    {
                        case 1: hand1 = aux3; break;
                        case 2: hand2 = aux3; break;
                        default: hand3 = aux3; break;

                    }
                    count++;
                }
                if (aux4.Exists(arr))
                {
                    switch (count)
                    {
                        case 1: hand1 = aux4; break;
                        case 2: hand2 = aux4; break;
                        default: hand3 = aux4; break;

                    }
                    count++;
                }



                this.combiId = THREE;
                this.combiName = "Three of " + hand1.Name + "s";

                return true; //brelan

            }
            else
            { return false; }






        }
        /// <summary>
        /// detect two pairs, change hand properties if necessary
        /// </summary>
        /// <returns>true if true :o) </returns>
        public bool IsTwoPair()
        {

            int paire1 = 0;
            int paire2 = 0;
            int paire3 = 0;
            int paire4 = 0;
            int paire5 = 0;
            int paire6 = 0;

            int c1 = card1.Value;
            int c2 = card2.Value;
            int b1 = card3.Value;
            int b2 = card4.Value;
            int b3 = card5.Value;
            int b4 = card6.Value;
            int b5 = card7.Value;
            if (c1 == c2)
            {
                paire1++;
            }
            if (c1 == b1)
            {
                paire1++;
            }
            if (c1 == b2)
                paire1++;
            if (c1 == b3)
                paire1++;
            if (c1 == b4)
                paire1++;
            if (c1 == b5)
                paire1++;

            if (c2 != c1)
            {
                if (c2 == b1)
                {
                    paire2++;
                }
                if (c2 == b2)
                {
                    paire2++;
                }
                if (c2 == b3)
                {
                    paire2++;
                }
                if (c2 == b4)
                {
                    paire2++;
                }
                if (c2 == b5)
                {
                    paire2++;
                }
            }
            if (b1 == b2)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;


            }
            if (b1 == b3)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b1 == b4)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b1 == b5)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b2 == b3)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }
            if (b2 == b4)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }
            if (b2 == b5)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }

            if (b3 == b4)
            {
                if (c1 != b3 && b3 != c2 && b1 != b3 && b3 != b2)
                    paire5++;

            }
            if (b3 == b5)
            {
                if (c1 != b3 && b3 != c2 && b1 != b3 && b3 != b2)
                    paire5++;

            }

            if (b4 == b5)
            {
                if (c1 != b4 && b4 != c2 && b1 != b4 && b4 != b2 && b4 != b3)
                    paire6++;

            }
            //to do faire tous les cas possibles....sinon ca peut etre autre chose
            if (paire1 >= 1 && paire2 >= 1
                ||
                paire1 >= 1 && paire3 >= 1
                ||
                paire1 >= 1 && paire4 >= 1
                ||
                paire1 >= 1 && paire5 >= 1
                ||
                paire1 >= 1 && paire6 >= 1
                ||
                paire2 >= 1 && paire3 >= 1
                ||
                paire2 >= 1 && paire4 >= 1
                ||
                paire2 >= 1 && paire5 >= 1
                ||
                paire2 >= 1 && paire6 >= 1
                ||
                paire3 >= 1 && paire4 >= 1
                ||
                paire3 >= 1 && paire5 >= 1
                ||
                paire3 >= 1 && paire6 >= 1
                ||
                paire4 >= 1 && paire5 >= 1
                ||
                paire4 >= 1 && paire6 >= 1
                ||
                paire5 >= 1 && paire6 >= 1




                //paire1+paire2+paire3+paire4+paire5+paire6>=2
                )
            {
                ArrayList list = new ArrayList(6);
                if (paire1 >= 1)
                    list.Add((c1 == 1) ? 14 : c1);
                if (paire2 >= 1)
                    list.Add((c2 == 1) ? 14 : c2);
                if (paire3 >= 1)
                    list.Add((b1 == 1) ? 14 : b1);
                if (paire4 >= 1)
                    list.Add((b2 == 1) ? 14 : b2);
                if (paire5 >= 1)
                    list.Add((b3 == 1) ? 14 : b3);
                if (paire6 >= 1)
                    list.Add((b4 == 1) ? 14 : b4);
                list.Sort();


                Card aux1 = new Card(1, (int)list[list.Count - 1]);
                Card aux2 = new Card(2, (int)list[list.Count - 1]);
                Card aux3 = new Card(3, (int)list[list.Count - 1]);
                Card aux4 = new Card(4, (int)list[list.Count - 1]);
                ArrayList arr = new ArrayList(10);
                int count = 1;
                arr.Add(card1);
                arr.Add(card2);
                arr.Add(card3);
                arr.Add(card4);
                arr.Add(card5);
                arr.Add(card6);
                arr.Add(card7);

                if (aux1.Exists(arr))
                {
                    hand1 = aux1;
                    count++;
                }
                if (aux2.Exists(arr))
                {
                    if (count == 1)
                        hand1 = aux2;
                    else
                        hand2 = aux2;
                    count++;
                }
                if (aux3.Exists(arr))
                {
                    switch (count)
                    {
                        case 1: hand1 = aux3; break;
                        case 2: hand2 = aux3; break;
                        default: break;

                    }
                    count++;
                }
                if (aux4.Exists(arr))
                {
                    switch (count)
                    {
                        case 1: hand1 = aux4; break;
                        case 2: hand2 = aux4; break;
                        default: break;

                    }

                }
                count = 1;
                Card aux11 = new Card(1, (int)list[list.Count - 2]);
                Card aux22 = new Card(2, (int)list[list.Count - 2]);
                Card aux33 = new Card(3, (int)list[list.Count - 2]);
                Card aux44 = new Card(4, (int)list[list.Count - 2]);
                if (aux11.Exists(arr))
                {
                    hand3 = aux11;
                    count++;
                }
                if (aux22.Exists(arr))
                {
                    if (count == 1)
                        hand3 = aux22;
                    else
                        hand4 = aux22;
                    count++;
                }
                if (aux33.Exists(arr))
                {
                    switch (count)
                    {
                        case 1: hand3 = aux33; break;
                        case 2: hand4 = aux33; break;
                        default: break;
                    }
                    count++;
                }
                if (aux44.Exists(arr))
                {
                    switch (count)
                    {
                        case 1: hand3 = aux44; break;
                        case 2: hand4 = aux44; break;
                        default: break;
                    }

                }

                this.combiId = TWOPAIRS;
                this.combiName = Language.Get2PairLabel()+ " "+ hand1.Name + "s and " + hand3.Name + "s";
                return true;

            }
            else
            { return false; }

        }
        /// <summary>
        /// detect simple pair, change hand properties if necessary
        /// </summary>
        /// <returns>true if true :o) </returns>
        public bool IsPair()
        {

            //paireX indik le nombre de fois k'une carte est répétée
            int paire1 = 0;
            int paire2 = 0;
            int paire3 = 0;
            int paire4 = 0;
            int paire5 = 0;
            int paire6 = 0;
            ArrayList liste;
            int c1 = card1.Value;
            int c2 = card2.Value;
            int b1 = card3.Value;
            int b2 = card4.Value;
            int b3 = card5.Value;
            int b4 = card6.Value;
            int b5 = card7.Value;
            if (c1 == c2)
            {
                paire1++;
            }
            if (c1 == b1)
            {
                paire1++;
            }
            if (c1 == b2)
                paire1++;
            if (c1 == b3)
                paire1++;
            if (c1 == b4)
                paire1++;
            if (c1 == b5)
                paire1++;

            if (c2 != c1)
            {
                if (c2 == b1)
                {
                    paire2++;
                }
                if (c2 == b2)
                {
                    paire2++;
                }
                if (c2 == b3)
                {
                    paire2++;
                }
                if (c2 == b4)
                {
                    paire2++;
                }
                if (c2 == b5)
                {
                    paire2++;
                }
            }
            if (b1 == b2)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;


            }
            if (b1 == b3)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b1 == b4)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b1 == b5)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b2 == b3)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }
            if (b2 == b4)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }
            if (b2 == b5)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }

            if (b3 == b4)
            {
                if (c1 != b3 && b3 != c2 && b1 != b3 && b3 != b2)
                    paire5++;

            }
            if (b3 == b5)
            {
                if (c1 != b3 && b3 != c2 && b1 != b3 && b3 != b2)
                    paire5++;

            }

            if (b4 == b5)
            {
                if (c1 != b4 && b4 != c2 && b1 != b4 && b4 != b2 && b4 != b3)
                    paire6++;

            }
            if (paire1 + paire2 + paire3 + paire4 + paire5 + paire6 >= 1)
            {



                liste = new ArrayList(7);
                if (paire1 >= 1)
                    liste.Add((c1 == 1) ? 14 : c1);
                if (paire2 >= 1)
                    liste.Add((c2 == 1) ? 14 : c2);
                if (paire3 >= 1)
                    liste.Add((b1 == 1) ? 14 : b1);
                if (paire4 >= 1)
                    liste.Add((b2 == 1) ? 14 : b2);
                if (paire5 >= 1)
                    liste.Add((b3 == 1) ? 14 : b3);
                if (paire6 >= 1)
                    liste.Add((b4 == 1) ? 14 : b4);
                liste.Sort();
                Card aux1 = new Card(1, (int)liste[liste.Count - 1]);
                Card aux2 = new Card(2, (int)liste[liste.Count - 1]);
                Card aux3 = new Card(3, (int)liste[liste.Count - 1]);
                Card aux4 = new Card(4, (int)liste[liste.Count - 1]);
                ArrayList arr = new ArrayList(10);
                int count = 1;
                arr.Add(card1);
                arr.Add(card2);
                arr.Add(card3);
                arr.Add(card4);
                arr.Add(card5);
                arr.Add(card6);
                arr.Add(card7);

                if (aux1.Exists(arr))
                {
                    hand1 = aux1;
                    count++;
                }
                if (aux2.Exists(arr))
                {
                    if (count == 1)
                        hand1 = aux2;
                    else
                        hand2 = aux2;
                    count++;
                }
                if (aux3.Exists(arr))
                {
                    switch (count)
                    {
                        case 1: hand1 = aux3; break;
                        case 2: hand2 = aux3; break;


                    }
                    count++;
                }
                if (aux4.Exists(arr))
                {
                    switch (count)
                    {
                        case 1: hand1 = aux4; break;
                        case 2: hand2 = aux4; break;


                    }
                    count++;
                }
                this.combiId = PAIR;
                this.HandName = Language.GetPairLabel() + "  " + hand1.Name + "s";
                return true;
            }
            else return false;

        }
        /// <summary>
        /// detect the best combination of a hand ( no straight or flush)
        /// </summary>
        private void IsCombi()
        {
            //paireX indik le nombre de fois k'une carte est répétée
            int paire1 = 0;
            int paire2 = 0;
            int paire3 = 0;
            int paire4 = 0;
            int paire5 = 0;
            int paire6 = 0;
            ArrayList liste;
            if (card1 == null)
                Console.WriteLine("buuuuuuuuuuuuuug");
            if (card3 == null || card6==null)
                return;
            int c1 = card1.Value;
            int c2 = card2.Value;
            int b1 = card3.Value;
            int b2 = card4.Value;
            int b3 = card5.Value;
            int b4 = card6.Value;
            int b5 = card7.Value;
            if (c1 == c2)
            {
                paire1++;
            }
            if (c1 == b1)
            {
                paire1++;
            }
            if (c1 == b2)
                paire1++;
            if (c1 == b3)
                paire1++;
            if (c1 == b4)
                paire1++;
            if (c1 == b5)
                paire1++;

            if (c2 != c1)
            {
                if (c2 == b1)
                {
                    paire2++;
                }
                if (c2 == b2)
                {
                    paire2++;
                }
                if (c2 == b3)
                {
                    paire2++;
                }
                if (c2 == b4)
                {
                    paire2++;
                }
                if (c2 == b5)
                {
                    paire2++;
                }
            }
            if (b1 == b2)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;


            }
            if (b1 == b3)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b1 == b4)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b1 == b5)
            {
                if (c1 != b1 && b1 != c2)
                    paire3++;
            }
            if (b2 == b3)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }
            if (b2 == b4)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }
            if (b2 == b5)
            {
                if (c1 != b2 && b2 != c2 && b1 != b2)
                    paire4++;
            }

            if (b3 == b4)
            {
                if (c1 != b3 && b3 != c2 && b1 != b3 && b3 != b2)
                    paire5++;

            }
            if (b3 == b5)
            {
                if (c1 != b3 && b3 != c2 && b1 != b3 && b3 != b2)
                    paire5++;

            }

            if (b4 == b5)
            {
                if (c1 != b4 && b4 != c2 && b1 != b4 && b4 != b2 && b4 != b3)
                    paire6++;

            }

            if (paire1 == 3 || paire2 == 3 || paire3 == 3 || paire4 == 3)
            {
                int max = 0;
                if (paire1 == 3)
                {
                    max = Max(c1, max);

                }
                if (paire2 == 3)
                {
                    max = Max(c2, max);
                }
                if (paire3 == 3)
                {
                    max = Max(b1, max);
                }
                if (paire4 == 3)
                {
                    max = Max(b2, max);
                }
                if (max == 14) max = 1;
                hand1 = new Card(1, max);
                hand2 = new Card(2, max);
                hand3 = new Card(3, max);
                hand4 = new Card(4, max);
                this.combiId = FOUR;
                combiName = Language.GetFourOfLabel()+ " " + hand1.Name + "s";
                return;


            }
            else
            {
                if (
                    //type 3 + 2 
                    (
                    (paire1 == 2 || paire2 == 2 || paire3 == 2 || paire4 == 2 || paire5 == 2) &&
                    (paire1 == 1 || paire2 == 1 || paire3 == 1 || paire4 == 1 || paire5 == 1 || paire6 == 1)
                    )
                    ||
                    (
                    //type 3 + 3

                    (paire1 == 2 &&( paire2 == 2 || paire3 == 2 || paire4 == 2 || paire5 == 2))
                    ||
                     (paire2 == 2 && (paire1 == 2 || paire3 == 2 || paire4 == 2 || paire5 == 2))
                    ||
                     (paire3 == 2 && (paire2 == 2 || paire1 == 2 || paire4 == 2 || paire5 == 2))
                    ||
                      (paire4 == 2 && (paire2 == 2 || paire3 == 2 || paire1 == 2 || paire5 == 2))
                    ||
                      (paire5 == 2 && (paire2 == 2 || paire3 == 2 || paire1 == 2 || paire4 == 2))
                    )

                    
                    
                    )
                {
                    int maxB = 0;
                    int maxP = 0;

                   //looking for best three of a kind
                    if (paire1 == 2)
                        maxB = Max(c1, maxB);
                    if (paire2 == 2)
                        maxB = Max(c2, maxB);
                    if (paire3 == 2)
                        maxB = Max(b1, maxB);
                    if (paire4 == 2)
                        maxB = Max(b2, maxB);
                    if (paire5 == 2)
                        maxB = Max(b3, maxB);

                    //looking for best two of a kind
                    if (paire1 >= 1)
                    {
                        if (Max(c1, maxP) != maxB)
                            maxP = Max(c1, maxP);
                    }
                    if (paire2 >= 1)
                    {
                        if (Max(c2, maxP) != maxB)
                            maxP = Max(c2, maxP);
                    }
                    if (paire3 >= 1)
                    {
                        if (Max(b1, maxP) != maxB)
                            maxP = Max(b1, maxP);
                    }
                    if (paire4 >= 1)
                    {
                        if (Max(b2, maxP) != maxB)
                            maxP = Max(b2, maxP);
                    }

                    if (paire5 >= 1)
                    {
                        if (Max(b3, maxP) != maxB)
                            maxP = Max(b3, maxP);
                    }

                    if (paire6 == 1)
                    {
                        if (Max(b4, maxP) != maxB)
                            maxP = Max(b4, maxP);
                    }
                    //seek three of 
                    Card aux1 = new Card(1, maxB);
                    Card aux2 = new Card(2, maxB);
                    Card aux3 = new Card(3, maxB);
                    Card aux4 = new Card(4, maxB);
                    ArrayList arr = new ArrayList(10);
                    int count = 1;
                    arr.Add(card1);
                    arr.Add(card2);
                    arr.Add(card3);
                    arr.Add(card4);
                    arr.Add(card5);
                    arr.Add(card6);
                    arr.Add(card7);
                    if (aux1.Exists(arr))
                    {
                        hand1 = aux1;
                        count++;
                    }
                    if (aux2.Exists(arr))
                    {
                        if (count == 1)
                            hand1 = aux2;
                        else
                            hand2 = aux2;
                        count++;
                    }
                    if (aux3.Exists(arr))
                    {
                        switch (count)
                        {
                            case 1: hand1 = aux3; break;
                            case 2: hand2 = aux3; break;
                            default: hand3 = aux3; break;

                        }
                        count++;
                    }
                    if (aux4.Exists(arr))
                    {
                        switch (count)
                        {
                            case 1: hand1 = aux4; break;
                            case 2: hand2 = aux4; break;
                            default: hand3 = aux4; break;

                        }
                        count++;
                    }
                    if (maxP == 0)
                    {


                        this.combiId = THREE;
                        this.combiName = Language.GetThreeOfLabel()+" " + hand1.Name;

                        return; //brelan

                    }
                    //seek for pair 
                    Card aux11 = new Card(1, maxP);
                    Card aux22 = new Card(2, maxP);
                    Card aux33 = new Card(3, maxP);
                    Card aux44 = new Card(4, maxP);

                    count = 1;

                    if (aux11.Exists(arr))
                    {
                        hand4 = aux11;
                        count++;
                    }
                    if (aux22.Exists(arr))
                    {
                        if (count == 1)
                            hand4 = aux22;
                        else
                            hand5 = aux22;
                        count++;
                    }
                    if (aux33.Exists(arr))
                    {
                        switch (count)
                        {
                            case 1: hand4 = aux33; break;
                            case 2: hand5 = aux33; break;

                        }
                        count++;
                    }
                    if (aux44.Exists(arr))
                    {
                        switch (count)
                        {
                            case 1: hand4 = aux44; break;
                            case 2: hand5 = aux44; break;


                        }
                        count++;
                    }
                    this.combiId = FULL;
                    this.combiName = Language.GetFullHouseLabel() +" "+ hand1.Name + "s over " + hand4.Name + "s";

                    return; //full
                }
                else
                {
                    if ((paire1 == 2 || paire2 == 2 || paire3 == 2 || paire4 == 2 || paire5 == 2))
                    {
                        int maxB = 0;
                        if (paire1 == 2)
                            maxB = Max(c1, maxB);
                        if (paire2 == 2)
                            maxB = Max(c2, maxB);
                        if (paire3 == 2)
                            maxB = Max(b1, maxB);
                        if (paire4 == 2)
                            maxB = Max(b2, maxB);
                        if (paire5 == 2)
                            maxB = Max(b3, maxB);


                        //seek three of 
                        Card aux1 = new Card(1, maxB);
                        Card aux2 = new Card(2, maxB);
                        Card aux3 = new Card(3, maxB);
                        Card aux4 = new Card(4, maxB);
                        ArrayList arr = new ArrayList(10);
                        int count = 1;
                        arr.Add(card1);
                        arr.Add(card2);
                        arr.Add(card3);
                        arr.Add(card4);
                        arr.Add(card5);
                        arr.Add(card6);
                        arr.Add(card7);
                        if (aux1.Exists(arr))
                        {
                            hand1 = aux1;
                            count++;
                        }
                        if (aux2.Exists(arr))
                        {
                            if (count == 1)
                                hand1 = aux2;
                            else
                                hand2 = aux2;
                            count++;
                        }
                        if (aux3.Exists(arr))
                        {
                            switch (count)
                            {
                                case 1: hand1 = aux3; break;
                                case 2: hand2 = aux3; break;
                                default: hand3 = aux3; break;

                            }
                            count++;
                        }
                        if (aux4.Exists(arr))
                        {
                            switch (count)
                            {
                                case 1: hand1 = aux4; break;
                                case 2: hand2 = aux4; break;
                                default: hand3 = aux4; break;

                            }
                            count++;
                        }



                        this.combiId = THREE;
                        this.combiName = Language.GetThreeOfLabel()+" " + hand1.Name + "s";

                        return; //brelan

                    }
                    else
                    {
                        if (paire1 + paire2 + paire3 + paire4 + paire5 + paire6 >= 2)
                        {
                            ArrayList list = new ArrayList(6);
                            if (paire1 == 1)
                                list.Add((c1 == 1) ? 14 : c1);
                            if (paire2 == 1)
                                list.Add((c2 == 1) ? 14 : c2);
                            if (paire3 == 1)
                                list.Add((b1 == 1) ? 14 : b1);
                            if (paire4 == 1)
                                list.Add((b2 == 1) ? 14 : b2);
                            if (paire5 == 1)
                                list.Add((b3 == 1) ? 14 : b3);
                            if (paire6 == 1)
                                list.Add((b4 == 1) ? 14 : b4);
                            list.Sort();


                            Card aux1 = new Card(1, (int)list[list.Count - 1]);
                            Card aux2 = new Card(2, (int)list[list.Count - 1]);
                            Card aux3 = new Card(3, (int)list[list.Count - 1]);
                            Card aux4 = new Card(4, (int)list[list.Count - 1]);
                            ArrayList arr = new ArrayList(10);
                            int count = 1;
                            arr.Add(card1);
                            arr.Add(card2);
                            arr.Add(card3);
                            arr.Add(card4);
                            arr.Add(card5);
                            arr.Add(card6);
                            arr.Add(card7);

                            if (aux1.Exists(arr))
                            {
                                hand1 = aux1;
                                count++;
                            }
                            if (aux2.Exists(arr))
                            {
                                if (count == 1)
                                    hand1 = aux2;
                                else
                                    hand2 = aux2;
                                count++;
                            }
                            if (aux3.Exists(arr))
                            {
                                switch (count)
                                {
                                    case 1: hand1 = aux3; break;
                                    case 2: hand2 = aux3; break;
                                    default: break;

                                }
                                count++;
                            }
                            if (aux4.Exists(arr))
                            {
                                switch (count)
                                {
                                    case 1: hand1 = aux4; break;
                                    case 2: hand2 = aux4; break;
                                    default: break;

                                }

                            }
                            count = 1;
                            Card aux11 = new Card(1, (int)list[list.Count - 2]);
                            Card aux22 = new Card(2, (int)list[list.Count - 2]);
                            Card aux33 = new Card(3, (int)list[list.Count - 2]);
                            Card aux44 = new Card(4, (int)list[list.Count - 2]);
                            if (aux11.Exists(arr))
                            {
                                hand3 = aux11;
                                count++;
                            }
                            if (aux22.Exists(arr))
                            {
                                if (count == 1)
                                    hand3 = aux22;
                                else
                                    hand4 = aux22;
                                count++;
                            }
                            if (aux33.Exists(arr))
                            {
                                switch (count)
                                {
                                    case 1: hand3 = aux33; break;
                                    case 2: hand4 = aux33; break;
                                    default: break;
                                }
                                count++;
                            }
                            if (aux44.Exists(arr))
                            {
                                switch (count)
                                {
                                    case 1: hand3 = aux44; break;
                                    case 2: hand4 = aux44; break;
                                    default: break;
                                }

                            }

                            this.combiId = TWOPAIRS;
                            this.combiName = Language.Get2PairLabel()+"  " + hand1.Name + "s and " + hand3.Name + "s";
                            return;

                        }
                        else
                        {

                            if (paire1 + paire2 + paire3 + paire4 + paire5 + paire6 == 1)
                            {



                                liste = new ArrayList(7);
                                if (paire1 == 1)
                                    liste.Add((c1 == 1) ? 14 : c1);
                                if (paire2 == 1)
                                    liste.Add((c2 == 1) ? 14 : c2);
                                if (paire3 == 1)
                                    liste.Add((b1 == 1) ? 14 : b1);
                                if (paire4 == 1)
                                    liste.Add((b2 == 1) ? 14 : b2);
                                if (paire5 == 1)
                                    liste.Add((b3 == 1) ? 14 : b3);
                                if (paire6 == 1)
                                    liste.Add((b4 == 1) ? 14 : b4);
                                liste.Sort();
                                Card aux1 = new Card(1, (int)liste[liste.Count - 1]);
                                Card aux2 = new Card(2, (int)liste[liste.Count - 1]);
                                Card aux3 = new Card(3, (int)liste[liste.Count - 1]);
                                Card aux4 = new Card(4, (int)liste[liste.Count - 1]);
                                ArrayList arr = new ArrayList(10);
                                int count = 1;
                                arr.Add(card1);
                                arr.Add(card2);
                                arr.Add(card3);
                                arr.Add(card4);
                                arr.Add(card5);
                                arr.Add(card6);
                                arr.Add(card7);

                                if (aux1.Exists(arr))
                                {
                                    hand1 = aux1;
                                    count++;
                                }
                                if (aux2.Exists(arr))
                                {
                                    if (count == 1)
                                        hand1 = aux2;
                                    else
                                        hand2 = aux2;
                                    count++;
                                }
                                if (aux3.Exists(arr))
                                {
                                    switch (count)
                                    {
                                        case 1: hand1 = aux3; break;
                                        case 2: hand2 = aux3; break;


                                    }
                                    count++;
                                }
                                if (aux4.Exists(arr))
                                {
                                    switch (count)
                                    {
                                        case 1: hand1 = aux4; break;
                                        case 2: hand2 = aux4; break;


                                    }
                                    count++;
                                }
                                this.combiId = PAIR;
                                this.HandName = Language.GetPairLabel()+ "  " + hand1.Name + "s";
                                return;
                            }
                        }
                    }
                }
            }
            liste = new ArrayList(10);
            liste.Add(card1);
            liste.Add(card2);
            liste.Add(card3);
            liste.Add(card4);
            liste.Add(card5);
            liste.Add(card6);
            liste.Add(card7);
            liste.Sort(new CardComparer());
            hand5 = (Card)liste[liste.Count - 1];
            hand4 = (Card)liste[liste.Count - 2];
            hand3 = (Card)liste[liste.Count - 3];
            hand2 = (Card)liste[liste.Count - 4];
            hand1 = (Card)liste[liste.Count - 5];
            this.combiId = HIGH;
            this.combiName = hand5.Name + " High";
            return;
        }


        /// <summary>
        /// detect a flush 
        /// </summary>
        /// <returns></returns>
        public bool IsFlush()
        {
            int pique, trefle, coeur, carreau;
            pique = trefle = coeur = carreau = 0;
            if (card3 == null || card6==null)
                return false;
            int c1 = card1.AbsColor;
            int c2 = card2.AbsColor;
            int b1 = card3.AbsColor;
            int b2 = card4.AbsColor;
            int b3 = card5.AbsColor;
            int b4 = card6.AbsColor;
            int b5 = card7.AbsColor;
            int ccc1 = card1.Value;
            int ccc2 = card2.Value;
            int bbb1 = card3.Value;
            int bbb2 = card4.Value;
            int bbb3 = card5.Value;
            int bbb4 = card6.Value;
            int bbb5 = card7.Value;
            int maxca = 0;
            int maxco = 0;
            int maxp = 0;
            int maxt = 0;
            ArrayList listSpade = new ArrayList(6);
            ArrayList listClub = new ArrayList(6);
            ArrayList listDiamond = new ArrayList(6);
            ArrayList listHeart = new ArrayList(6);
            switch (c1)
            {

                case 2: carreau++; maxca = Max(maxca, ccc1); listDiamond.Add(card1); break;
                case 3: pique++; maxp = Max(maxp, ccc1); listSpade.Add(card1); break;
                case 4: trefle++; maxt = Max(maxt, ccc1); listClub.Add(card1); break;
                case 1: coeur++; maxco = Max(maxco, ccc1); listHeart.Add(card1); break;

            }

            switch (c2)
            {

                case 2: carreau++; maxca = Max(maxca, ccc2); listDiamond.Add(card2); break;
                case 3: pique++; maxp = Max(maxp, ccc2); listSpade.Add(card2); break;
                case 4: trefle++; maxt = Max(maxt, ccc2); listClub.Add(card2); break;
                case 1: coeur++; maxco = Max(maxco, ccc2); listHeart.Add(card2); break;

            }

            switch (b1)
            {

                case 2: carreau++; maxca = Max(maxca, bbb1); listDiamond.Add(card3); break;
                case 3: pique++; maxp = Max(maxp, bbb1); listSpade.Add(card3); break;
                case 4: trefle++; maxt = Max(maxt, bbb1); listClub.Add(card3); break;
                case 1: coeur++; maxco = Max(maxco, bbb1); listHeart.Add(card3); break;

            }

            switch (b2)
            {
                case 2: carreau++; maxca = Max(maxca, bbb2); listDiamond.Add(card4); break;
                case 3: pique++; maxp = Max(maxp, bbb2); listSpade.Add(card4); break;
                case 4: trefle++; maxt = Max(maxt, bbb2); listClub.Add(card4); break;
                case 1: coeur++; maxco = Max(maxco, bbb2); listHeart.Add(card4); break;

            }

            switch (b3)
            {

                case 2: carreau++; maxca = Max(maxca, bbb3); listDiamond.Add(card5); break;
                case 3: pique++; maxp = Max(maxp, bbb3); listSpade.Add(card5); break;
                case 4: trefle++; maxt = Max(maxt, bbb3); listClub.Add(card5); break;
                case 1: coeur++; maxco = Max(maxco, bbb3); listHeart.Add(card5); break;

            }

            switch (b4)
            {

                case 2: carreau++; maxca = Max(maxca, bbb4); listDiamond.Add(card6); break;
                case 3: pique++; maxp = Max(maxp, bbb4); listSpade.Add(card6); break;
                case 4: trefle++; maxt = Max(maxt, bbb4); listClub.Add(card6); break;
                case 1: coeur++; maxco = Max(maxco, bbb4); listHeart.Add(card6); break;


            }
            switch (b5)
            {

                case 2: carreau++; maxca = Max(maxca, bbb5); listDiamond.Add(card7); break;
                case 3: pique++; maxp = Max(maxp, bbb5); listSpade.Add(card7); break;
                case 4: trefle++; maxt = Max(maxt, bbb5); listClub.Add(card7); break;
                case 1: coeur++; maxco = Max(maxco, bbb5); listHeart.Add(card7); break;

            }

            if (pique >= 5)
            {
                //if (this.combiId == STRAIGHT) { return true; }
                this.combiId = FLUSH;
                Card max = new Card(3, maxp);
                this.combiName = max.Name + " high " + Language.GetFlushLabel();
                listSpade.Sort(new CardComparer());
                int length = listSpade.Count;
                hand1 = (Card)listSpade[length - 5];
                hand2 = (Card)listSpade[length - 4];
                hand3 = (Card)listSpade[length - 3];
                hand4 = (Card)listSpade[length - 2];
                hand5 = (Card)listSpade[length-1];
                return true;
            }
            if (trefle >= 5)
            {
                // if (this.combiId == STRAIGHT) { return true; }
                this.combiId = FLUSH;
                Card max = new Card(4, maxt);
                this.combiName = max.Name + " high " + Language.GetFlushLabel();
                listClub.Sort(new CardComparer());
                int length = listClub.Count;
                hand1 = (Card)listClub[length - 5];
                hand2 = (Card)listClub[length - 4];
                hand3 = (Card)listClub[length - 3];
                hand4 = (Card)listClub[length - 2];
                hand5 = (Card)listClub[length - 1];
                return true;
            }
            if (carreau >= 5)
            {
                //  if (this.combiId == STRAIGHT) { return true; }
                this.combiId = FLUSH;
                Card max = new Card(2, maxca);
                this.combiName = max.Name + " high " + Language.GetFlushLabel();
                listDiamond.Sort(new CardComparer());
                int length = listDiamond.Count;
                hand1 = (Card)listDiamond[length - 5];
                hand2 = (Card)listDiamond[length - 4];
                hand3 = (Card)listDiamond[length - 3];
                hand4 = (Card)listDiamond[length - 2];
                hand5 = (Card)listDiamond[length - 1];
                return true;
            }
            if (coeur >= 5)
            {
                //if (this.CombiId == STRAIGHT) { return true; }
                this.combiId = FLUSH;
                Card max = new Card(1, maxco);
                this.combiName = max.Name + " high "+Language.GetFlushLabel();
                listHeart.Sort(new CardComparer());

                int length = listHeart.Count;
                hand1 = (Card)listHeart[length - 5];
                hand2 = (Card)listHeart[length - 4];
                hand3 = (Card)listHeart[length - 3];
                hand4 = (Card)listHeart[length - 2];
                hand5 = (Card)listHeart[length - 1];
                return true;
            }
            else return false;
        }
        /// <summary>
        /// detect the greater straight
        /// </summary>
        /// <returns></returns>
        public bool IsStraight()
        {

            //classer par ordre
            //regarder si on peut en extraire une sous suite de 5 éléments 
            int prec;
            int hightcard = 0;

            ////
            ///
            ArrayList study = new ArrayList(8);
            ArrayList straight = new ArrayList(7);
            if (card3 == null || card6==null)
                return false;
            study.Add(card1);
            study.Add(card2);
            study.Add(card3);
            study.Add(card4);
            study.Add(card5);
            study.Add(card6);
            study.Add(card7);
            study.Sort(new CardComparer());
            prec = (int)((Card)study[study.Count - 1]).Value;
            if (prec == 14)
            {

                study.Insert(0, study[study.Count - 1]);
                //	straight.Add(study[0]);

            }
            straight.Add(study[study.Count - 1]);
            hightcard = prec;
            for (int j = study.Count - 1; j >= 0; j--)
            {
                if (prec - 1 == (int)((Card)study[j]).Value || (prec - 1 == 1 && (int)((Card)study[j]).Value == 14))
                {

                    straight.Add(study[j]);
                    if (straight.Count == 5) break;
                }
                else
                {
                    if (prec != (int)((Card)study[j]).Value)
                    {

                        if (straight.Count < 5)
                        {//no straight detected

                            straight.Clear();
                            hightcard = (int)((Card)study[j]).Value;
                            straight.Add(study[j]);
                        }
                        else
                            break;

                    }

                }

                prec = (int)((Card)study[j]).Value;

            }
            if (straight.Count == 5)
            {

                hand5 = (Card)straight[straight.Count - 5];
                hand4 = (Card)straight[straight.Count - 4];
                hand3 = (Card)straight[straight.Count - 3];
                hand2 = (Card)straight[straight.Count - 2];
                hand1 = (Card)straight[straight.Count - 1];
                this.combiId = STRAIGHT;
                this.combiName = "high " + hand5.Name + " straight ";

                return true;


            }
            else return false;


        }
        /// <summary>
        /// detectthe greater straightflush
        /// </summary>
        /// <returns></returns>
        public bool IsStraightFlush()
        {
            //got a straigth and a flush 
            //let's try all combinaison 
            //got the straight in the handX, if return == false mustdo a IsFlush again with a CombId =1;  
            ArrayList arr = new ArrayList(10);
            arr.Add(card1);
            arr.Add(card2);
            arr.Add(card3);
            arr.Add(card4);
            arr.Add(card5);
            arr.Add(card6);
            arr.Add(card7);



            //let's try 9 kind of straight
            for (int j = 0; j <= 9; j++)
            {
                bool aux = true;
                //loop on color 
                int i = 1;
                for (i = 1; i <= 4; i++)
                { 
                    aux = new Card(i, 14 - j).Exists(arr);
                    aux &= new Card(i, 13 - j).Exists(arr);
                    aux &= new Card(i, 12 - j).Exists(arr);
                    aux &= new Card(i, 11 - j).Exists(arr);
                    aux &= new Card(i, 10 - j).Exists(arr);
                    if (aux) break;
                }
                if (aux)
                {

                    hand5 = new Card(i, 14 - j);
                    hand4 = new Card(i, 13 - j);
                    hand3 = new Card(i, 12 - j);
                    hand2 = new Card(i, 11 - j);
                    hand1 = new Card(i, 10 - j);

                    this.combiId = STRAIGHTFLUSH;
                    if (hand5.Value == 1 || hand5.Value == 14)
                    {



                        this.combiName = Language.GetRoyalStraightFlushLabel();


                    }
                    else combiName = hand5.Name + " High " +Language.GetStraightFlushLabel();
                    return true;
                }

            }

            return false;
            /* dead code
            for (int i = 1; i < 5; i++)
            {
                bool aux = true;
                aux = new Card(i, hand1.Value).Exists(arr);
                aux &= new Card(i, hand2.Value).Exists(arr);
                aux &= new Card(i, hand3.Value).Exists(arr);
                aux &= new Card(i, hand4.Value).Exists(arr);
                aux &= new Card(i, hand5.Value).Exists(arr);

                if (aux == true)
                {
                    hand1 = new Card(i, hand1.Value);
                    hand2 = new Card(i, hand2.Value);
                    hand3 = new Card(i, hand3.Value);
                    hand4 = new Card(i, hand4.Value);
                    hand5 = new Card(i, hand5.Value);
                    this.combiId = STRAIGHTFLUSH;
                    if (hand5.Value == 1 || hand5.Value == 14)
                    {



                        this.combiName = "Royal Straight Flush";


                    }
                    else combiName = hand5.Name + " High" + " Straight Flush";
                    return true;


                }
            }
            return false;
             * */
        }
        /// <summary>
        /// evaluate the hand and complete it if necessary with kicker
        /// </summary>
        public void EvaluateHand()
        {
            IsCombi();
            bool straightFlush = false;
            bool q = IsStraight();
            bool c = IsFlush();
            if (q && c) straightFlush = IsStraightFlush();
            /*
             else c = IsFlush();
             if (q && !straightFlush)
             {
                 this.combiId = STRAIGHT;
                 c = IsFlush();
             }
             * */
            CompleteHand();
        }
        /// <summary>
        /// outdated
        /// </summary>
        public void EvaluateHand2()
        {

            bool straightFlush = false;
            bool q = IsStraight();
            bool c;
            if (q) straightFlush = IsStraightFlush();
            else c = IsFlush();
            if (q && !straightFlush)
            {
                this.combiId = STRAIGHT;
                c = IsFlush();
            }
            CompleteHand();
        }

        /// <summary>
        /// give kicker and sort hand for HIGH and FLUSH 
        /// </summary>
        private void CompleteHand()
        {
            switch (this.combiId)
            {
                case HIGH: SortCards(); break;
                case FLUSH: SortCards(); break;
                case PAIR: Complete(3); break;
                case TWOPAIRS: Complete(1); break;
                case THREE: Complete(2); break;
                case FOUR: Complete(1); break;
                default: break;


            }
            return;
        }
        /// <summary>
        /// sort cards to set hand1 the best (Ace for example ou king)
        /// </summary>
        private void SortCards()
        {
            if(hand1==null)
            return;
            ArrayList hand = new ArrayList(5);      // this.hand1   
            hand.Add(hand1);
            hand.Add(hand2);
            hand.Add(hand3);
            hand.Add(hand4);
            hand.Add(hand5);
            hand.Sort(new CardComparer());

            hand1 = (Card)hand[0];
            hand2 = (Card)hand[1];
            hand3 = (Card)hand[2];
            hand4 = (Card)hand[3];
            hand5 = (Card)hand[4];


        }
        /// <summary>
        /// complete with correct kickers
        /// </summary>
        /// <param name="t">nombers of kicker</param>
        private void Complete(int t)
        { //this function will complete a hand with t kicker(s)
            ArrayList list = new ArrayList(8);
            ArrayList handList = new ArrayList(6);
            //build the combinaison best hand  
            if (hand1 != null)
            {
                handList.Add(hand1);
                if (hand2 != null)
                    handList.Add(hand2);
                if (hand3 != null)
                    handList.Add(hand3);
                if (hand4 != null)
                    handList.Add(hand4);
                if (hand5 != null)
                    handList.Add(hand5);
            }

            //sort all 7 cards available
            //if (card1.ValueR == 1)
            //    card1.Value = 14;
            //if (card2.ValueR == 1)
            //    card2.Value = 14;
            //if (card3.ValueR == 1)
            //    card3.Value = 14;
            //if (card4.ValueR == 1)
            //    card4.Value = 14;
            //if (card5.ValueR == 1)
            //    card5.Value = 14;
            //if (card6.ValueR == 1)
            //    card6.Value = 14;
            //if (card6.ValueR == 1)
            //    card6.Value = 14;
            list.Add(card1);
            list.Add(card2);
            list.Add(card3);
            list.Add(card4);
            list.Add(card5);
            list.Add(card6);
            list.Add(card7);
            list.Sort(new CardComparer());
            //complete the hand with the hightest rank card
            switch (t)
            {
                case 1:
                    for (int i = 6; i >= 0; i--)
                    {
                        if (!((Card)list[i]).Exists(handList))
                        {
                            hand5 = ((Card)list[i]);
                            break;
                        }
                    }; break;
                case 2:
                    for (int i = 6; i >= 0; i--)
                    {
                        if (!((Card)list[i]).Exists(handList))
                        {
                            hand5 = ((Card)list[i]);
                            break;
                        }
                    };
                    handList.Add(hand5);
                    for (int i = 6; i >= 0; i--)
                    {
                        if (!((Card)list[i]).Exists(handList))
                        {
                            hand4 = ((Card)list[i]);
                            break;
                        }
                    }; break;
                case 3:
                    for (int i = 6; i >= 0; i--)
                    {
                        if (!((Card)list[i]).Exists(handList))
                        {
                            hand5 = ((Card)list[i]);
                            break;
                        }
                    };
                    handList.Add(hand5);
                    for (int i = 6; i >= 0; i--)
                    {
                        if (!((Card)list[i]).Exists(handList))
                        {
                            hand4 = ((Card)list[i]);
                            break;
                        }
                    };
                    handList.Add(hand4);
                    for (int i = 6; i >= 0; i--)
                    {
                        if (!((Card)list[i]).Exists(handList))
                        {
                            hand3 = ((Card)list[i]);
                            break;
                        }
                    }; break;
                default:

                    hand5 = (Card)list[4];
                    hand4 = (Card)list[3];
                    hand3 = (Card)list[2];
                    hand2 = (Card)list[1];
                    hand1 = (Card)list[0];
                    break;
            }
        }
        /// <summary>
        /// give the ID of the actual greater combinaison detected 
        /// </summary>
        public int CombiId
        {
            get { return combiId; }
        }
        /// <summary>
        /// set the flop
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Flop(Card a, Card b, Card c)
        {
            this.card3 = a;
            this.card4 = b;
            this.card5 = c;
        }
        /// <summary>
        /// set the turn
        /// </summary>
        /// <param name="a"></param>
        public void Turn(Card a)
        {
            this.card6 = a;

        }
        /// <summary>
        /// set the river
        /// </summary>
        /// <param name="a"></param>
        public void River(Card a)
        {
            this.card7 = a;

        }
        /// <summary>
        /// comparaison between Hand , last card it's the greater 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >(Hand a, Hand b)
        {
            if (a.CombiId < b.CombiId) return false;
            if (a.CombiId > b.CombiId) return true;
            switch (a.CombiId)
            {
                case FLUSH:
                case HIGH:


                    if (a.hand5.Value > b.hand5.Value)
                        return true;
                    else
                        if (a.hand5.Value < b.hand5.Value)
                            return false;
                        else
                            if (a.hand4.Value > b.hand4.Value)
                                return true;

                            else
                                if (a.hand4.Value < b.hand4.Value)
                                    return false;

                                else
                                    if (a.hand3.Value > b.hand3.Value)
                                        return true;

                                    else
                                        if (a.hand3.Value < b.hand3.Value)
                                            return false;

                                        else
                                            if (a.hand2.Value > b.hand2.Value)
                                                return true;

                                            else
                                                if (a.hand2.Value < b.hand2.Value)
                                                    return false;
                                                else
                                                    if (a.hand1.Value > b.hand1.Value)
                                                        return true;

                                                    else
                                                        if (a.hand1.Value < b.hand1.Value)
                                                        return false;
                    break;

                case PAIR: if (a.hand1.Value > b.hand1.Value)
                        return true;
                    else
                        if (a.hand1.Value < b.hand1.Value)
                            return false;
                        else
                            if (a.hand5.Value > b.hand5.Value)
                                return true;

                            else
                                if (a.hand5.Value < b.hand5.Value)
                                    return false;

                                else
                                    if (a.hand4.Value > b.hand4.Value)
                                        return true;

                                    else
                                        if (a.hand4.Value < b.hand4.Value)
                                            return false;
                                        else
                                            if (a.hand3.Value > b.hand3.Value)
                                                return true;

                                            else
                                                if (a.hand3.Value < b.hand3.Value)
                                                return false;

                break;
                case TWOPAIRS: if (a.hand1.Value > b.hand1.Value)
                        return true;
                    else
                        if (a.hand1.Value < b.hand1.Value)
                            return false;
                        else
                            if (a.hand3.Value > b.hand3.Value)
                                return true;

                            else
                                if (a.hand3.Value < b.hand3.Value)
                                    return false;

                                else
                                    if (a.hand5.Value > b.hand5.Value)
                                        return true;

                                    else
                                        if (a.hand5.Value < b.hand5.Value)
                                        return false;
                break;

                case THREE: if (a.hand1.Value > b.hand1.Value)
                        return true;
                    else
                        if (a.hand1.Value < b.hand1.Value)
                            return false;
                        else
                            if (a.hand5.Value > b.hand5.Value)
                                return true;

                            else
                                if (a.hand5.Value < b.hand5.Value)
                                    return false;
                                else
                                    if (a.hand4.Value > b.hand4.Value)
                                        return true;

                                    else
                                        if (a.hand4.Value < b.hand4.Value)
                                        return false;

                break;

                case FOUR: if (a.hand1.Value > b.hand1.Value)
                        return true;
                    else
                        if (a.hand1.Value < b.hand1.Value)
                            return false;
                        else
                            if (a.hand5.Value > b.hand5.Value)
                                return true;
                    if (a.hand5.Value < b.hand5.Value)
                        return false;
                    break;
                case STRAIGHTFLUSH:
                case STRAIGHT: if (a.hand5.Value > b.hand5.Value)
                        return true;
                    else
                        if (a.hand5.Value < b.hand5.Value)
                        return false;

                break;
                case FULL: if (a.hand1.Value > b.hand1.Value)
                        return true;
                    else
                        if (a.hand1.Value < b.hand1.Value)
                            return false;
                        else
                            if (a.hand4.Value > b.hand4.Value)
                                return true;

                            else
                                if (a.hand4.Value < b.hand4.Value)
                                    return false; break;
                default: Console.WriteLine("bug a l'evaluation  de la main "); break;





            }

            return false;//
         
        }
        public static bool operator >=(Hand a, Hand b)
        {
            return (a == b || a > b);
        }
        public static bool operator <(Hand a, Hand b)
        {
            return !(a >= b);
        }
        public static bool operator <=(Hand a, Hand b)
        {
            return !(a > b);
        }
        public static bool operator ==(Hand a, Hand b)
        {
            try
            {
                if ((object)a == null && (object)b == null) return true;
                if ((object)b == null) return false;
                if ((object)a == null) return false;
                if (a.combiId != b.combiId) return false;
                return (a.hand1.Value == b.hand1.Value &&
                    a.hand2.Value == b.hand2.Value &&
                    a.hand3.Value == b.hand3.Value &&
                    a.hand4.Value == b.hand4.Value &&
                    a.hand5.Value == b.hand5.Value);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        public static bool operator !=(Hand a, Hand b)
        {
            return !(a == b);
        }

        public Card Hand1
        {
            get { return hand1; }
            set { hand1 = value; }

        }
        public Card Hand2
        {
            get { return hand2; }
            set { hand2 = value; }

        }
        public Card Hand3
        {
            get { return hand3; }
            set { hand3 = value; }

        }
        public Card Hand4
        {
            get { return hand4; }
            set { hand4 = value; }

        }
        public Card Hand5
        {
            get { return hand5; }
            set { hand5 = value; }

        }
        public string HandName
        {
            get { return combiName; }
            set { combiName = value; }
        }
        public Card Card1
        {
            get { return card1; }
            set { card1 = value; }

        }
        public Card Card2
        {
            get { return card2; }
            set { card2 = value; }

        }

        private string combiName;
        /// <summary>
        /// hands hierarchy  
        /// </summary>
        private const int HIGH = 0;
        private const int PAIR = 1;
        private const int TWOPAIRS = 2;
        private const int THREE = 3;
        private const int FOUR = 7;
        private const int STRAIGHT = 4;
        private const int FULL = 6;
        private const int FLUSH = 5;
        private const int STRAIGHTFLUSH = 8;

        private int combiId = 0;//identify the combinaison 

        private Card hand1 = null;
        private Card hand2 = null;
        private Card hand3 = null;
        private Card hand4 = null;
        private Card hand5 = null;


        private Card card1 = null;
        private Card card2 = null;
        private Card card3 = null;
        private Card card4 = null;
        private Card card5 = null;
        private Card card6 = null;
        private Card card7 = null;
    }
}
