
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
using System.IO;
using System.Collections;
using System.Windows.Forms;
namespace poker
{
    /// <summary>
    /// sound loader
    /// </summary>
    public class MediaList
    {
        private bool allowVoices = true;

        public bool AllowVoices
        {
            get { return allowVoices; }
            set { allowVoices = value; }
        }
        MediaPlayer player;
        public MediaList(MediaPlayer p){
           
            path2song = Application.StartupPath + @"/MEDIA/";

            player = p;
        }
        private static string path2song="";

        public void NewCards()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"NewCards/";
            player.PlaySound(Seek(path));

        }
        public void Money()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"Money/";
            player.PlaySound(Seek(path));

        }
        public void Chips()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"Chips/";
            player.PlaySound(Seek(path));

        }
        public void OutOfMoney()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"OutOfMoney/";
            player.PlaySound(Seek(path));

        }
        public void Flop()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"Flop/";
            player.PlaySound(Seek(path));

        }
        public void River()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"River/";
            player.PlaySound(Seek(path));

        }
        public void Turn()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"Turn/";
            player.PlaySound(Seek(path));

        }
        public void TakeDown()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"TakeDown/";
            player.PlaySound(Seek(path));

        }
        public void NextLevel()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"NextLevel/";
            player.PlaySound(Seek(path));

        }
        public void SplitPot()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"SplitPot/";
            player.PlaySound(Seek(path));

        }
        public void Funny()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"FUNNY/";
         player.PlaySound(Seek(path));
          
        }
        public void Insult()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"INSULT/";
            player.PlaySound(Seek(path));

        }
        public void Success()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"SUCCESS/";
            player.PlaySound(Seek(path));

        }
        public void Fold()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"FOLD/";
            player.PlaySound(Seek(path));

        }
        public void Lose()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"LOSE/";
            player.PlaySound(Seek(path));

        }
        public void AllIn()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"ALLIN/";
            player.PlaySound(Seek(path));

        }
        public void Raise()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"RAISE/";
            player.PlaySound(Seek(path));

        }
        public void Call()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"CALL/";
            player.PlaySound(Seek(path));

        }
        public void Check()
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + @"CHECK/";
            player.PlaySound(Seek(path));
         
        }
        public void Funny(int i)
        {
            if (!this.AllowVoices)
                return;
            string path = path2song +   i+@"/FUNNY/";
            player.PlaySound(Seek(path));

        }
        public void Insult(int i)
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + i+@"/INSULT/";
            player.PlaySound(Seek(path));

        }
        public void Success(int i)
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + i + @"/SUCCESS/";
            player.PlaySound(Seek(path));

        }
        public void Fold(int i)
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + i + @"/FOLD/";
            player.PlaySound(Seek(path));

        }
        public void Lose(int i)
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + i + @"/LOSE/";
            player.PlaySound(Seek(path));

        }
        public void AllIn(int i)
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + i + @"/ALLIN/";
            player.PlaySound(Seek(path));

        }
        public void Raise(int i)
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + i + @"/RAISE/";
            player.PlaySound(Seek(path));

        }
        public void Call(int i)
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + i + @"/CALL/";
            player.PlaySound(Seek(path));

        }
        public void Check(int i)
        {
            if (!this.AllowVoices)
                return;
            string path = path2song + i+@"/CHECK/";
            player.PlaySound(Seek(path));

        }
        private string Seek(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
                return"";
            ArrayList list = new ArrayList(50);
          //  FileInfo[] files = dir.GetFiles("*.wma");
          //  foreach(FileInfo f in files){
          //          list.Add(f.FullName);
          //  }
          //files = dir.GetFiles("*.mp3");
          //  foreach (FileInfo f in files)
          //  {
          //      list.Add(f.FullName);
          //  }
            FileInfo[]  files = dir.GetFiles("*.wav");
            foreach (FileInfo f in files)
            {
                list.Add(f.FullName);
            }
           //files = dir.GetFiles("*.mid");
           // foreach (FileInfo f in files)
           // {
           //     list.Add(f.FullName);
           // } 
           // files = dir.GetFiles("*.midi");
           // foreach (FileInfo f in files)
           // {
           //     list.Add(f.FullName);
           // }
            if (list.Count== 0)
                return "";
            Random ran = new Random((int)DateTime.Now.Ticks);
            int a = ran.Next(0, list.Count);
            return list[a].ToString();
        } 

    }

   
}
