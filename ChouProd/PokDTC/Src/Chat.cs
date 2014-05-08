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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
namespace poker
{
	/// <summary>
	/// Class to chat 
	/// </summary>
	public class Chat
	{
        //autoscroll 
		const int WM_VSCROLL = 0x0115;
		const int SB_BOTTOM = 7;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="box">main discution window</param>
        /// <param name="text">personal window</param>
        /// <param name="f">mainform</param>
		public Chat(RichTextBox box,RichTextBox text,Form1 f)
		{
			richTextBox=text;
			texte=box;
			form=f;
			
		}
        /// <summary>
        /// 
        /// add text to his own window
        /// </summary>
        /// <param name="st"></param>
		public void  AddText(string st )
		{	


			AddOwnChat(st); 

		}
        //send messages to everybody
		public void  AddChat(string msg)
		{	
			
			if(!this.form.Dispatcher.Communication.IsConnected())
			form.Dispatcher.Communication.SendBroadCast("{msg " + msg +"\n");   
			AddOwnChat(msg); 

		}
        /// <summary>
        /// add text of personal box and send it to everybody
        /// </summary>
		public void  AddText()
		{	
			if(this.texte.Text.CompareTo("")==0) 
				return;
            if (this.texte.Text.StartsWith("\\n"))
                return;
			if(this.texte.Text.CompareTo("pokdtc rocks")==0) 
			{	this.texte.ResetText();
				form.Dispatcher.Communication.SendBroadCast("{connerie"); 
				return;
			}
			
			string msg=this.texte.Text;
			this.texte.ResetText();
            //remove forbidden character
			msg=msg.Replace("{"," ");
            msg.Replace("\n", "");
            msg=msg.Trim();
            if (msg == "")
                return;
            //cut too big text
			if (msg.Length>1024)
				msg=msg.Substring(0,1024);
			
			if( this.form.Dispatcher.Communication.IsConnected())
				form.Dispatcher.Communication.SendToServer("{msg " + this.form.Dispatcher.GameData.Name + " : " + msg +"\n"); 
			else 
			{
				form.Dispatcher.Communication.SendBroadCast("{msg " + this.form.Dispatcher.GameData.Name + " : " + msg +"\n");
				AddOwnChat("You have said : " +msg+"\n"); 
			}

		}
        private string txt_swap;
        /// <summary>
        /// add text to his own chat box
        /// </summary>
        /// <param name="st"></param>
		private void AddOwnChat(string st)
		{
            this.txt_swap = st;
            object[] p = new object[1];
            p[0] = this.richTextBox;
            this.richTextBox.Invoke(new AddOwnChatDelegate(AddOwnChatInvoke), p);
            		
		
		}
        private delegate void AddOwnChatDelegate(Control c);
        private void AddOwnChatInvoke(Control c) {

            form.SendToWindows(this.richTextBox.Handle, WM_VSCROLL, SB_BOTTOM, 0);
            if (txt_swap == "")
                return;
            if (txt_swap == " ")
                return;
            if (txt_swap == "\\n")
                return;
            this.richTextBox.AppendText(txt_swap);
        
        }
        /// <summary>
        /// get chat window
        /// </summary>
		public RichTextBox RichTextBox
		{
			get{return richTextBox;}
		}
        /// <summary>
        /// reset chatting text
        /// </summary>
		public void Reset()
		{
			richTextBox.ResetText();
		}

		private RichTextBox richTextBox;//chat area
		private Form1 form;//link with main windows 
		private RichTextBox texte;//zone de saisie

	}
}
