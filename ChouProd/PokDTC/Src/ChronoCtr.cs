
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace poker
{
    public partial class ChronoCtr : UserControl
    {
        private delegate void  DelegateText(Control c);
        ChronoTimer chronoTimer;

        public ChronoTimer ChronoTimer
        {
            get { return chronoTimer; }
            set { chronoTimer = value; }
        }
        public ChronoCtr()
        {
            InitializeComponent();
                
        }

                public ChronoCtr(Game g)
        {
            InitializeComponent();
                

        }
        private string twtswap;

        /// <summary>
        /// cache le controle
        /// </summary>
        public void HideCtr()
        {
            try
            {
               
                object[] p = new object[1];
                p[0] = this;


                labelCurrentStruct.Invoke(new DelegateText(Hide), p);
            }
            catch { }
        
        
        }

        private void Hide(Control c)
        {
            this.Visible = false;

        }

        public void ChangeStruct(string txt) 
        {
            try
            {
                twtswap = txt;
                object[] p = new object[1];
                p[0] = this.labelCurrentStruct;


                labelCurrentStruct.Invoke(new DelegateText(ChangeMyText), p);
            }
            catch { }
           
        
        }

        private void ChangeMyText(Control c)
        {

            c.Text = Language.GetCurrentBlinds()  +" " + twtswap;
            this.Visible = true;
        }

        public void InitChrono(Game g) 
        {
            if (chronoTimer == null)
            {
                chronoTimer = new ChronoTimer();
            }
               
                chronoTimer.Type_CHRONO = 0;
                chronoTimer.InitTimeLeft =g.Dispatcher.GameData.TimeIncrease;// *3;// 300; //5min
                chronoTimer.TimeLeft = chronoTimer.InitTimeLeft;
                chronoTimer.Control = labelTime;
                chronoTimer.Game = g;
                chronoTimer.Start();
        
        }
    }
}