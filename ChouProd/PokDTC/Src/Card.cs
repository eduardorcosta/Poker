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

/*
          2 "diamond";
  		 3 "spade";
  			 4: "club";
  			 1 "heart";
 */
using System;
using System.Collections;
namespace poker
{
	/// <summary>
	/// Card class, use to describe a playing card with Value and color 
	/// </summary>
	public class Card
	{
		public Card()
		{
			
		}
        /// <summary>
        /// Build a card
        /// </summary>
        /// <param name="color">id of color 2 "diamond";    				 3 "spade";			 4: "club";     				 1 "heart";</param>
        /// <param name="valueCard">value of the card , Ace = 1 or 14  </param>
		public Card(int color,int valueCard)
		{
			if(valueCard==14) valueCard=1;
			absoluteValue=ColorAndValueToAbs(color,valueCard);
			cardValue=(valueCard==1)?14:valueCard;
			this.absoluteColor=color;
			NameTheCard();
		}
        /// <summary>
        /// Build a card
        /// </summary>
        /// <param name="c">value ,Ace = 1 or 14 </param>
		public Card(int c)
		{
			absoluteValue=c;
			absoluteColor=TransCardIntoColor(c);
			cardValue=(TransCardIntoValue(c)==1)?14:TransCardIntoValue(c);
			NameTheCard();
		}
        /// <summary>
        /// true if a card belong to the arraylist
        /// </summary>
        /// <param name="arr">an array of card</param>
        /// <returns>true if belonged  false otherwise</returns>
		public bool Exists(ArrayList arr){
		
		
			for(int i=0;i<arr.Count;i++){
		
				
				if(((Card) arr[i]).AbsValue==this.AbsValue) return true;
			} 
			return false;		
		}

        /// <summary>
        /// compute the absolute value of a card    between 1 and 52 
        /// </summary>
        /// <param name="color">id color</param>
        /// <param name="valueCard">value of the card</param>
        /// <returns>absolute value   between 1 and 52</returns>
		private int ColorAndValueToAbs(int color,int valueCard)
		{


			//  de 1 à 13  valeur normale   couleur coeur
			//  de 14 à 26     pour valeur -13 couleur carreau
			//  de 27 à 39     pour valeur -26 couleur pique
			//  de 40 à 52     pour valeur -39 couleur trèfle  
//					case 2:return "diamond";
//				case 3:return "spade";
//				case 4:return "club";
//				case 1:return "heart";
			int offset=0;
			switch (color){
				case 2:offset=13;break;
			    case 3:offset=26;break;
				case 4:offset=39;break;
				case 1:offset=0;break;
			
			}
			return (offset+valueCard);

		}

        public string CompleteName()
        { 
            switch(this.AbsColorL)
            {
                case "ca": return name + " " + Language.GetOf() + " " + Language.GetDiamondsEvents();
                case "co": return name + " " + Language.GetOf() + " " + Language.GetHeartsEvents();
                case "p": return name + " " + Language.GetOf() + " " + Language.GetSpadesEvents();
            
            
            
            }
        
         return  name + " " + Language.GetOf() + " " + Language.GetClubsEvents();
        
        }

        /// <summary>
        /// give a name to the card
        /// </summary>
		private void NameTheCard()
		{
		
		
			switch (cardValue)
			{
				case 1:
				case 14:name="Ace";break;
				case 13:name="King";break;
				case 12:name="Queen";break;
				case 11:name="Jack";break;
				case 2:name="Deuce";break;
				default:name=cardValue.ToString();break;
			
			
			}
			switch (absoluteColor)
			{
				case 2:color= Language.GetDiamondEvents();absoluteColorL="ca";break;
				case 3:color= Language.GetSpadeEvents();absoluteColorL="p";break;
				case 4:color= Language.GetClubEvents();absoluteColorL="t";break;
				case 1:color= Language.GetHeartEvents();absoluteColorL="co";break;
				default:throw new Exception("color unknown");
			
			
			
			}
		}
        /// <summary>
        /// translate absolute value into .Value one 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
		private int TransCardIntoValue(int c)
		{
			while(!(c<=13))
				c-=13;
			return c;
		}
        /// <summary>
        /// translate absolute value into color one
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
		private int TransCardIntoColor(int c)
		{
			if (c<=13) return 1;
			if (c<=26) return 2;
			if (c<=39) return 3;
			return 4;
		}
		private string name="";
		private string color="";
		private int cardValue=0; //2->14
		private int absoluteValue=0;//1->52
		private int absoluteColor=0;//1->4
	private string absoluteColorL="";
        /// <summary>
        /// get the name of the card
        /// </summary>
		public string Name
		{
			get{return name;}
		
		}
        /// <summary>
        /// get absolute value
        /// </summary>
		public int AbsValue
		{
			get{return this.absoluteValue;}
		
		}
        /// <summary>
        ///  get or set the value of card  with Ace=14 
        /// </summary>
		public int Value
		{
			get{ return cardValue;}
			set{cardValue=value;}
		
		}
        /// <summary>
        /// get or set the value of card  with Ace=1 
        /// </summary>
		public int ValueR
		{
			get{ if (cardValue==14 ) return 1 ;else return cardValue;}
			set{cardValue=value;}
		
		}
        /// <summary>
        /// get the color name
        /// </summary>
		public string Color
		{
			get{return color;}
		
		}
        /// <summary>
        /// get the id of a Color   2 "diamond";
        ///				 3 "spade";
        ///				 4: "club";
        ///				 1 "heart";
        /// </summary>
		public int AbsColor
		{
			get{return absoluteColor;}
		
		}
        /// <summary>
        /// get   color abreviation   ca  diamond 
        ///                           p spade
        ///                           t club
        ///                           co hearth
        /// </summary>
		public string AbsColorL
		{
			get{return absoluteColorL;}
		
		}
        /// <summary>
        /// egality test with simple value  test   ( Ace =1) 
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
		public static bool operator ==(Card c1,Card c2){
		
			if((object) c1 == null &&  (object) c2 == null) return true;

				if((object) c1 != null &&  (object) c2 == null) return false;
			return c1.Value==c2.Value;
		}

		public static bool operator !=(Card c1,Card c2)
		{
           		
			return !(c1==c2);
		}
        /// <summary>
        /// simple Value test
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
		public static bool operator <(Card c1,Card c2){
			return c1.Value<c2.Value;
		}
        /// <summary>
        /// simple value test
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
		public static bool operator >(Card c1,Card c2)
		{
			return c1.Value>c2.Value;
		}
	
	}
}
