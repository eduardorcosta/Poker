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
using System.Windows.Forms;
namespace poker
{
	/// <summary>
	/// Class displaying quick info about player 
	/// </summary>
	public class MiniInfo
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">listbox</param>
        /// <param name="g">game</param>
		public MiniInfo(ListBox list ,Game g)
		{
		    game=g;
			listBox=list;
		}
        /// <summary>
        /// erase list box
        /// </summary>
		public void ResetList()
		{
			while(this.listBox.Items.Count!=0)
			{

                object[] p = new object[1];
                p[0] = listBox;
                try
                {
                    listBox.Invoke(new Delegatelistbox(ListBoxRemove), p);
                }
                catch { break; }
		
			
			}
		}
		public void SetListBox1(string msg)
        {
            try
            {
                txt_swap = msg;
                object[] p = new object[1];
                p[0] = listBox;
                listBox.Invoke(new Delegatelistbox(ListBoxAdd), p);
            }
            catch { }
		}
        private string txt_swap;
        private delegate void Delegatelistbox(ListBox c);
        private void ListBoxAdd(ListBox c) {

            c.Items.Add(txt_swap);
        }
        private void ListBoxRemove(ListBox c)
        {

            c.Items.RemoveAt(0);
        }

        /// <summary>
        /// complete infos
        /// </summary>
		public void ShowMoneyInfo()
		{
			try
			{string msg;
				for(int i=0;i<game.NbrPlayerSinceBegin;i++)
				{
					msg="";
					msg=game.Names(i) +" " + game.GetMoney(i) + "$";
					if(game.InGame(i)==0)
						msg+=" out of the game";
					else if(game.InRound(i)==0)
						msg+=" fold";
					else if(game.GetMoney(i)<=0) 
						msg+= " all in";
				
					this.SetListBox1(msg);
			
			
				}
			}
			catch(Exception )
			{
				return;
			}
		}
				private Game game;
		private ListBox listBox;
	}

}
