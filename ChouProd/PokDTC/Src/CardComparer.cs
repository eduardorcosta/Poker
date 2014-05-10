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
using System.Globalization;

namespace poker
{
	/// <summary>
	/// Class allowing card sorting
	/// </summary>
	public class CardComparer:IComparer
	{
		public CardComparer()
		{
		
		}
        /// <summary>
        /// allow cards comparaison with simple value (Ace =14) 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>0 if egality ,-1 if a less than b ,1 otherwise  </returns>
		public  int Compare(object a,object b){
            if (a == null || b == null)
                return -1;
		 if (((Card) a).Value==((Card) b).Value) return 0;
			if(((Card) a).Value>((Card) b).Value) return 1;
			return -1;
		
		}
	}
}
