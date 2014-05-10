
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
using System.Collections;
namespace poker
{
    public partial class Admin : UserControl
    {
        private delegate void UpdateComboBox(Control c);
        public Admin()
        {
            InitializeComponent();
        }
        Dispatcher dispatcher;

        public Dispatcher Dispatcher
        {
            get { return dispatcher; }
            set { dispatcher = value; }
        }
        public Admin(Dispatcher disp)
        {
            InitializeComponent();
            Translation();
            dispatcher = disp;
            ArrayList localplayer = new ArrayList(4);
            if (this.dispatcher.Game == null)
                return;
            this.comboBox1.Items.Clear();
            for (int i = 0; i < this.dispatcher.Game.NbrPlayerSinceBegin; i++)
            {
                if(this.dispatcher.Game.GetPlayer(i).GetType().ToString().Contains("Network"))
                    this.comboBox1.Items.Add(this.dispatcher.Game.GetPlayer(i).Name);
            }
           
        
        }
        private string txt_swap;
        private delegate void DelegateAddtext(Control c);
        private void AddTextInvoke(Control c)
        {

            c.Text = txt_swap;

        }
        /// <summary>
        /// modifie la langue du control
        /// </summary>
        public void TranslationAdmin()
        {
            object[] p = new object[1];
            p[0] = this;
           txt_swap=Language.GetKickButton();
           this.button1.Invoke(new DelegateAddtext(AddTextInvoke), p);


        }
        private void Translation()
        {
            this.button1.Text = Language.GetKickButton();


        }
        public void Actualize(Control c)
        {
            if (this.dispatcher.Game == null)
                return;
            this.comboBox1.Text = "";
            ArrayList localplayer = new ArrayList(4);
            this.comboBox1.Items.Clear();
            for (int i = 0; i < this.dispatcher.Game.NbrPlayerSinceBegin; i++)
            {
                if (this.dispatcher.Game.GetPlayer(i).GetType().ToString().Contains("Network"))
                    this.comboBox1.Items.Add(this.dispatcher.Game.GetPlayer(i).Name);
            }
        
        }
        public void ShowMe(Control c)
        {
            Actualize(c);
            this.Visible = true;

        }
        public void HideMe(Control c)
        {

            this.Visible = false;

        }
        public void ShowMe()
        {

          
            object[] p = new object[1];
            p[0] = this;
            this.comboBox1.Invoke(new UpdateComboBox(ShowMe), p);

        }
        public void HideMe()
        {

            object[] p = new object[1];
            p[0] = this;
            this.comboBox1.Invoke(new UpdateComboBox(HideMe), p);

        }
        public void Actualize(Dispatcher disp)
        {
             dispatcher = disp;
         object[] p= new object[1];
         p[0] = this.comboBox1;
         this.comboBox1.Invoke(new UpdateComboBox(Actualize), p);
        
        
        }
        /// <summary>
        /// kick le player et le remplace par une IA
        /// </summary>
        /// <param name="id"></param>
        public void KickPlayer(int id)
        {


           

            IA newIA = new IA(dispatcher.Game.GetPlayer(id).Name + "_BOT", 34, 45, 43, dispatcher.Game.GetPlayer(id).Money.Money, dispatcher.Game, id, false);
            newIA.Box = dispatcher.Game.GetPlayer(id).Box;
            newIA.Action = dispatcher.Game.GetPlayer(id).Action;
            newIA.Dealer = dispatcher.Game.GetPlayer(id).Dealer;
            newIA.Hand = dispatcher.Game.GetPlayer(id).Hand;
            newIA.HasCheck = dispatcher.Game.GetPlayer(id).HasCheck;
            newIA.HiddenCard1 = dispatcher.Game.GetPlayer(id).HiddenCard1;
            newIA.HiddenCard2 = dispatcher.Game.GetPlayer(id).HiddenCard2;
            newIA.IsAllin = dispatcher.Game.GetPlayer(id).IsAllin;
            newIA.MoneyLabel = dispatcher.Game.GetPlayer(id).MoneyLabel;
            newIA.OwnPot = dispatcher.Game.GetPlayer(id).OwnPot;
            newIA.Profil = dispatcher.Game.GetPlayer(id).Profil;
            newIA.ShowCard1 = dispatcher.Game.GetPlayer(id).ShowCard1;
            newIA.ShowCard2 = dispatcher.Game.GetPlayer(id).ShowCard2;
            newIA.TotalRaise = dispatcher.Game.GetPlayer(id).TotalRaise;
            string name = dispatcher.Game.GetPlayer(id).Name;
            dispatcher.Game.SetPlayer(newIA);
            this.dispatcher.Communication.SendBroadCast("{msg " + name + " has been kicked, an AI should take his place");

            dispatcher.Form.Chat.AddChat("player " + dispatcher.Game.GetPlayer(Convert.ToInt16(id)).Name + " has been kicked, a bot will take his place");
                                           
        
        
        
        
        }

     
        //KICK   , on va kicker le player  1 + num deka liste 
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == -1)
                return;

            int toKick = this.comboBox1.SelectedIndex;
            
            for (int i = 1; i < this.dispatcher.Game.NbrPlayerSinceBegin; i++)
            {
                if (this.dispatcher.Game.GetPlayer(i).GetType().ToString().Contains("Network"))
                {
                    
                    if (this.dispatcher.Game.GetPlayer(i).Name==this.comboBox1.SelectedItem.ToString())
                    {
                        if (this.dispatcher.Game.CurrentPlayer == i)
                        {
                            ((NetworkPlayer)dispatcher.Game.GetPlayer(i)).FinishToPlay(false, "fold", 0);

                        }
                        KickPlayer(i);
                        Actualize(this.dispatcher);
                        if (this.comboBox1.Items.Count == 0)
                            HideMe();
                        return;
                    }
                
                }
            }

        }
        
    }
}
