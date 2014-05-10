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
	/// describe the board 
	/// </summary>
	public class CommunityCards
	{
		public CommunityCards()
		{
			
		}
        /// <summary>
        /// build the flop, order not mind
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="f3"></param>
		public CommunityCards(Card f1,Card f2,Card f3)
		{
			flop1=f1;
			flop2=f2;
			flop3=f3;
		}
        /// <summary>
        /// build flop + turn+river
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="f3"></param>
        /// <param name="t"></param>
        /// <param name="r"></param>
		public CommunityCards(Card f1,Card f2,Card f3,Card t,Card r)
		{
			flop1=f1;
			flop2=f2;
			flop3=f3;
			turn=t;
			river=r;
		}
		private Card flop1=null;
		private Card flop2=null;
		private Card flop3=null;
		private Card turn=null;
		private Card river=null;
        /// <summary>
        /// get the card number i of the board 
        /// </summary>
        /// <param name="i">1_3 flop, 4 turn, other river</param>
        /// <returns></returns>
		public Card GetCard(int i){
			switch (i){
				case 1:return this.flop1;
				case 2:return this.flop2;
				case 3:return this.flop3;
				case 4:return this.turn;
				default:return this.river;
			}
		}
        /// <summary>
        /// reset the board 
        /// </summary>
		public void Reset(){
		flop1=flop2=flop3=river=turn=null;
		
		}
        /// <summary>
        /// Build the flop
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="f3"></param>
		public void Flop(Card f1,Card f2,Card f3){
				flop1=f1;
				flop2=f2;
				flop3=f3;
		}
        /// <summary>
        /// get or set the first card of the flop
        /// </summary>
		public Card Flop1{
		
			get{return flop1;}
			set{flop1=value;}
		}
        /// <summary>
        /// get or set the second card of the flop
        /// </summary>
		public Card Flop2
		{
			get{return flop2;}
			set{flop2=value;}
		}
        /// <summary>
        /// get or set the third card of the flop
        /// </summary>
       
		public Card Flop3
		{
		
			get{return flop3;}
			set{flop3=value;}
		}
        /// <summary>
        /// get or set the turn
        /// </summary>
		public Card Turn
		{
		
			get{return turn;}
			set{turn=value;}
		}
        /// <summary>
        /// get or set the river
        /// </summary>
		public Card River
		{
			get{return river;}
			set{river=value;}
		}


	}
}
