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
using System.Threading ;
using System.Windows.Forms;
namespace poker
{
	/// <summary>
	/// MessagebOx in is pwn thread debug prupose
	/// </summary>
	public class MyMsgBox
	{
        Form1 mainW;
		public MyMsgBox(string t,string d,Form1 f)
		{
			title=t;
			data=d;
            mainW = f;

			//
			// TODO: Add constructor logic here
			//
		}
		
		public void Show(){
           
		Thread th=new Thread(new ThreadStart(Open));
		th.Start();
		
		}
       
		private void Open(){
            try
            {
                object[] p = new object[1];
                p[0] = mainW;

                mainW.Invoke(new DelegateInvok(Open), p);
            }
            catch { }
		

		
		}
        private void Open(Control c)
        {
            MessageBox.Show(mainW, data, title);
        }
        private delegate void DelegateInvok(Control c);
		public string GetTitle(){
		return title;
		}
		public string GetData(){
		
		return data;
		}
		private string title;
		private string data;
	}


}
