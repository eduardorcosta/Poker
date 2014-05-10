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
	/// Class to describe and use money
	/// </summary>
	public class Pot
	{

		public Pot()
		{
			
			money=0;
		}
		public Pot(long val)
		{
			
			money=val;
		}
		public void  AddMoney(long val){
		
		money+=val;
		}
		public void  RemoveMoney(long val)
		{
		
			money-=val;
		}
		public void ResetMoney(){
		
		money=0;
		}
		
		private long money;
		public long Money{
			get{return money;}
			set{money=value;}		
		}
	}
}
