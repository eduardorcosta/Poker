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
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;

namespace poker
{

    /// <summary>
    /// Description résumée de Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;

        public System.Windows.Forms.PictureBox PictureBox3
        {
            get { return pictureBox3; }
            set { pictureBox3 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox4;

        public System.Windows.Forms.PictureBox PictureBox4
        {
            get { return pictureBox4; }
            set { pictureBox4 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox5;

        public System.Windows.Forms.PictureBox PictureBox5
        {
            get { return pictureBox5; }
            set { pictureBox5 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox6;

        public System.Windows.Forms.PictureBox PictureBox6
        {
            get { return pictureBox6; }
            set { pictureBox6 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox7;

        public System.Windows.Forms.PictureBox PictureBox7
        {
            get { return pictureBox7; }
            set { pictureBox7 = value; }
        }
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuItem menuItem4;
        private IContainer components;
        const int WM_VSCROLL = 0x0115;
        const int SB_BOTTOM = 7;
        /// <summary>
        /// version de pokdtc 
        /// </summary>
        public const float prog_version = 0.869F;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuItem menuItem6;

        private System.Windows.Forms.GroupBox Player0;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;

        public System.Windows.Forms.PictureBox PictureBox11
        {
            get { return pictureBox11; }
            set { pictureBox11 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox12;

        public System.Windows.Forms.PictureBox PictureBox12
        {
            get { return pictureBox12; }
            set { pictureBox12 = value; }
        }
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox15;

        public System.Windows.Forms.PictureBox PictureBox15
        {
            get { return pictureBox15; }
            set { pictureBox15 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox16;

        public System.Windows.Forms.PictureBox PictureBox16
        {
            get { return pictureBox16; }
            set { pictureBox16 = value; }
        }
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.PictureBox pictureBox19;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox21;

        public System.Windows.Forms.PictureBox PictureBox21
        {
            get { return pictureBox21; }
            set { pictureBox21 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox22;

        public System.Windows.Forms.PictureBox PictureBox22
        {
            get { return pictureBox22; }
            set { pictureBox22 = value; }
        }
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.PictureBox pictureBox25;
        private System.Windows.Forms.PictureBox pictureBox26;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox29;

        public System.Windows.Forms.PictureBox PictureBox29
        {
            get { return pictureBox29; }
            set { pictureBox29 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox30;

        public System.Windows.Forms.PictureBox PictureBox30
        {
            get { return pictureBox30; }
            set { pictureBox30 = value; }
        }
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.PictureBox pictureBox31;
        private System.Windows.Forms.PictureBox pictureBox32;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox35;

        public System.Windows.Forms.PictureBox PictureBox35
        {
            get { return pictureBox35; }
            set { pictureBox35 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox36;

        public System.Windows.Forms.PictureBox PictureBox36
        {
            get { return pictureBox36; }
            set { pictureBox36 = value; }
        }
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.PictureBox pictureBox37;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox38;
        private System.Windows.Forms.PictureBox pictureBox41;

        public System.Windows.Forms.PictureBox PictureBox41
        {
            get { return pictureBox41; }
            set { pictureBox41 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox42;

        public System.Windows.Forms.PictureBox PictureBox42
        {
            get { return pictureBox42; }
            set { pictureBox42 = value; }
        }
        private System.Windows.Forms.GroupBox groupBox30;
        private System.Windows.Forms.PictureBox pictureBox43;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox47;

        public System.Windows.Forms.PictureBox PictureBox47
        {
            get { return pictureBox47; }
            set { pictureBox47 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox48;

        public System.Windows.Forms.PictureBox PictureBox48
        {
            get { return pictureBox48; }
            set { pictureBox48 = value; }
        }
        private System.Windows.Forms.GroupBox groupBox33;
        private System.Windows.Forms.PictureBox pictureBox49;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pictureBox50;
        private System.Windows.Forms.PictureBox pictureBox53;

        public System.Windows.Forms.PictureBox PictureBox53
        {
            get { return pictureBox53; }
            set { pictureBox53 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox54;

        public System.Windows.Forms.PictureBox PictureBox54
        {
            get { return pictureBox54; }
            set { pictureBox54 = value; }
        }
        private System.Windows.Forms.GroupBox groupBox36;
        private System.Windows.Forms.PictureBox pictureBox55;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox pictureBox59;

        public System.Windows.Forms.PictureBox PictureBox59
        {
            get { return pictureBox59; }
            set { pictureBox59 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox60;

        public System.Windows.Forms.PictureBox PictureBox60
        {
            get { return pictureBox60; }
            set { pictureBox60 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox46;
        private System.Windows.Forms.PictureBox pictureBox58;
        private System.Windows.Forms.PictureBox pictureBox33;
        private System.Windows.Forms.PictureBox pictureBox40;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.PictureBox pictureBox18;

        public System.Windows.Forms.PictureBox PictureBox18
        {
            get { return pictureBox18; }
            set { pictureBox18 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox23;

        public System.Windows.Forms.PictureBox PictureBox23
        {
            get { return pictureBox23; }
            set { pictureBox23 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox24;

        public System.Windows.Forms.PictureBox PictureBox24
        {
            get { return pictureBox24; }
            set { pictureBox24 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox27;

        public System.Windows.Forms.PictureBox PictureBox27
        {
            get { return pictureBox27; }
            set { pictureBox27 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox28;

        public System.Windows.Forms.PictureBox PictureBox28
        {
            get { return pictureBox28; }
            set { pictureBox28 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox34;

        public System.Windows.Forms.PictureBox PictureBox34
        {
            get { return pictureBox34; }
            set { pictureBox34 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox39;

        public System.Windows.Forms.PictureBox PictureBox39
        {
            get { return pictureBox39; }
            set { pictureBox39 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox44;

        public System.Windows.Forms.PictureBox PictureBox44
        {
            get { return pictureBox44; }
            set { pictureBox44 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox45;

        public System.Windows.Forms.PictureBox PictureBox45
        {
            get { return pictureBox45; }
            set { pictureBox45 = value; }
        }
        private System.Windows.Forms.PictureBox pictureBox51;

        public System.Windows.Forms.PictureBox PictureBox51
        {
            get { return pictureBox51; }
            set { pictureBox51 = value; }
        }

        public System.Windows.Forms.PictureBox PictureBox10
        {
            get { return pictureBox10; }
            set { pictureBox10 = value; }
        }

        public System.Windows.Forms.PictureBox PictureBox9
        {
            get { return pictureBox9; }
            set { pictureBox9 = value; }
        }
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.PictureBox pictureBox52;
        private Stats stats;
        private MediaPlayer mediaPlayer1;
        private MenuItem menuItem9;
        private MenuItem menuItem15;
        private MenuItem menuItem16;
        private Label labelSurv;
        private Button buttonTripleRaise;
        private MenuItem menuItem17;
        private Admin admin1;
        private MenuItem menuItem19;
        private MenuItem menuItem20;
        private MenuItem menuItem21;
        private MenuItem menuItem22;
        private MenuItem menuItem23;
        private MenuItem menuItem24;
        private Button buttonBetPot;
        private ChronoCtr chronoCtr1;
        private MenuItem menuItem25;
        private MenuItem menuItem26;
        private MenuItem menuItem27;
        private MenuItem menuItem28;
        private MenuItem menuItem18;
        private MenuItem menuItem29;
        private MenuItem menuItem30;
        private MenuItem menuItem31;
        private MenuItem menuItem32;
        private CheckBox checkBoxCheck;
        private CheckBox checkBoxAutoFold;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private MenuItem menuItem33;

        public ChronoCtr ChronoCtr1
        {
            get { return chronoCtr1; }
            set { chronoCtr1 = value; }
        }
        private Label labelAggr;
        /// <summary>
        /// update label nbr of takedown
        /// </summary>
        /// <param name="take"></param>
        public void SetAggr(int take)
        {

            this.SetText("Takedowns: " + take + " ", this.labelAggr);
        }
        /// <summary>
        /// update laeb survi et aggr to NULL
        /// </summary>
        public void ResetSurviAggr()
        {

            this.SetText("", this.labelAggr);
            this.SetText("", this.labelSurv);
        }
        /// <summary>
        /// update level
        /// </summary>
        /// <param name="level"></param>
        public void SetSurvi(int level)
        {
            this.SetText("Level: " + level, this.labelSurv);
        }
        const int SB_ENDSCROLL = 8;
        /// <summary>
        /// not utilized yet willuse WMP instead
        /// </summary>
        /// <param name="lpszName"></param>
        /// <param name="hModule"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern bool PlaySound(string lpszName, int hModule, int dwFlags);

/// <summary>
/// outdated
/// </summary>
        private void MakeTransparent()
        {
            Bitmap bitmap = new Bitmap(this.pictureBox18.Image);
            bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
            this.pictureBox18.Image = bitmap;
            this.pictureBox51.Image = bitmap;
            this.pictureBox45.Image = bitmap;
            this.pictureBox23.Image = bitmap;
            this.pictureBox24.Image = bitmap;
            this.pictureBox27.Image = bitmap;
            this.pictureBox28.Image = bitmap;
            this.pictureBox39.Image = bitmap;
            this.pictureBox34.Image = bitmap;
            this.pictureBox44.Image = bitmap;



        }
        public bool PlaySound(string str)
        {
            return PlaySound(str, 0, 1);

        }

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string test)
        {
       
            //
            // Requis pour la prise en charge du Concepteur Windows Forms
            //
            InitializeComponent();
            //
            // TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
            //
            //this.HideChoice();
          
            this.Icon = new System.Drawing.Icon(Application.StartupPath + "\\pokDTC.ico");
            namesOfChatter = new string[11];
            namesOfChatterBeforeGame = new string[11];
            this.pictureBox8.Controls.AddRange(new Control[]{this.groupBox10,/*this.groupBox12,this.groupBox4,this.groupBox1,*/this.Player0,
															this.groupBox21,this.groupBox15,this.groupBox24,this.groupBox27,this.groupBox18,this.groupBox30,this.groupBox33,this.groupBox36,
             
			    this.groupBox2,
                this.splitContainer1,
				this.pictureBox1,
				this.pictureBox2,
                this.pictureBox3,
                this.pictureBox4,
                this.pictureBox5,
                this.pictureBox6,
                this.pictureBox7,
				this.pictureBox9,
				this.pictureBox10,
				this.pictureBox11,
                this.pictureBox12,
                this.pictureBox13,
                this.pictureBox14,
			    this.pictureBox15,
                this.pictureBox16,
                this.pictureBox17,
                this.pictureBox18,
                this.pictureBox19,
                this.pictureBox20,
                this.pictureBox21,
                this.pictureBox22,
                this.pictureBox23,
                this.pictureBox24,
                this.pictureBox25,
                this.pictureBox26,
                this.pictureBox27,
                this.pictureBox28,
				this.pictureBox29,
				this.pictureBox30,
                this.pictureBox31,
                this.pictureBox32,
                this.pictureBox33,
                this.pictureBox34,
                this.pictureBox35,
                this.pictureBox36,
                this.pictureBox37,
				this.pictureBox38,
                this.pictureBox39,
                this.pictureBox40,
				this.pictureBox41,
				this.pictureBox42,
                this.admin1,
                chronoCtr1,
                this.labelAggr,
                this.labelSurv,
                this.pictureBox43,
                this.pictureBox44,
                this.pictureBox45,
                this.pictureBox46,
                this.pictureBox47,
				this.pictureBox48,
                this.pictureBox49,
                this.pictureBox50,
                this.pictureBox51,
                this.pictureBox52,
                this.pictureBox53,
                this.pictureBox54,
                this.pictureBox55,
                this.pictureBox58,
                this.pictureBox59,
                this.pictureBox60
               
															});



            

            chat = new Chat(richTextBox2, richTextBox1, this);
            gameEvents = new GameEvents(this.richTextBox4, this);

            GameData gameData = new GameData(1, 1, 2, 100, 0, 10, Environment.UserName);

            dispatcher = new Dispatcher(this, gameData);
            ComInOut comInOut = new ComInOut(dispatcher);
            dispatcher.Communication = comInOut;
            this.Player0.Text = this.GetMyName();

            notifyIcon1 = new NotifyIcon();
            notifyIcon1.Icon = new System.Drawing.Icon(Application.StartupPath + "\\pokDTC.ico");
            notifyIcon1.Visible = true;
            notifyIcon1.Text = "PokDTC";


            if (allowspeaker)
                dispatcher.Speaker = new AutoSpeech();
            admin1.Dispatcher = this.dispatcher;
            dispatcher.Admin = admin1;

           //MakeTransparent();
           


        }
        private NotifyIcon notifyIcon1;
        /// <summary>
        /// allow speaker to comment party
        /// </summary>
        private bool allowspeaker = false;
        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lparam);

        public void SetValide(bool b)
        {
            valid = b;
        }
        public int SendToWindows(IntPtr hWnd, uint Msg, uint wParam, uint lparam)
        {

            return SendMessage(hWnd, Msg, wParam, lparam);

        }


        /// <summary>
        /// show BB button
        /// </summary>
        public void ShowBBbutton()
        {
            try
            {
                int currentPlayer = this.dispatcher.Game.CurrentBB;

                PictureBox box = WhatIsMyButtonBox(currentPlayer);

                box.Invoke(new DelegateAddtext(ShowBBbuttonInvoke), new object[] { box });
            }
            catch { }
        }
        /// <summary>
        /// show SB button
        /// </summary>
        public void ShowSBbutton()
        {
            try
            {
                int currentPlayer = this.dispatcher.Game.CurrentSB;

                PictureBox box = WhatIsMyButtonBox(currentPlayer);

                box.Invoke(new DelegateAddtext(ShowSBbuttonInvoke), new object[] { box });
            }
            catch{}
        
        
        }
        /// <summary>
        /// return button picture boc of player id
        /// </summary>
        /// <param name="id_player"></param>
        /// <returns></returns>
        public PictureBox WhatIsMyButtonBox(int id_player)
        {

            switch (id_player)
            {

                case 0: return this.pictureBox51;
                case 1: return this.pictureBox18;
                case 2: return this.pictureBox23;
                case 3: return this.pictureBox24;
                case 4: return this.pictureBox27;
                case 5: return this.pictureBox28;
                case 6: return this.pictureBox34;
                case 7: return this.pictureBox39;
                case 8: return this.pictureBox44;
                default: return this.pictureBox45;

            
            
            }
        
        
        
        
        }

        /// <summary>
        /// show dealer button
        /// </summary>
        public void ShowDealerbutton()
        {
            try
            {
                int currentPlayer = this.dispatcher.Game.CurrentDealer;

                PictureBox box = WhatIsMyButtonBox(currentPlayer);


                box.Invoke(new DelegateAddtext(ShowDEALERbuttonInvoke), new object[] { box });
            }
            catch { }
        }


        private void ShowBBbuttonInvoke(Control c)
        {

            ((PictureBox)c).Image = poker.Properties.Resources.BB;
            ((PictureBox)c).Visible = true;
        }
        private void ShowSBbuttonInvoke(Control c)
        {

            ((PictureBox)c).Image = poker.Properties.Resources.SB;

            ((PictureBox)c).Visible = true;
        
        }
        private void ShowDEALERbuttonInvoke(Control c)
        {

            ((PictureBox)c).Image = poker.Properties.Resources.DEALER;
            ((PictureBox)c).Visible = true;
        }
        /// <summary>
        /// start the game 
        /// </summary>
        /// 
        public void Start()
        {

            valid = false;
            if (dispatcher.Game != null && dispatcher.Game.Odds != null)
            {
                try
                {
                    dispatcher.Game.Odds.Close();
                }
                catch { }
            }
            Game game = new Game(dispatcher, this.dispatcher.Communication.Nbr);
            dispatcher.Game = game;
            this.loopingBlink = true;
            LaunchBlinkMode();
            this.dispatcher.Game.Stopgame = false;
            this.menuItem24.Enabled = true;
            dispatcher.Analyser = new GameAnalyser(game);
            game.CurrentDealer = new Random((int)DateTime.Now.Ticks).Next(0, this.dispatcher.Game.NbrPlayerSinceBegin - 1);
            miniInfo = new MiniInfo(this.listBox1, game);
            //	stats = new Stats(game);
            this.ResetSurviAggr();
            if (this.dispatcher.Communication.Nbr > 0)
            {
                dispatcher.Admin.ShowMe();
                this.menuItem18.Enabled = false; //pause
            }
            else
            {
                dispatcher.Admin.HideMe();
                this.menuItem18.Enabled = true;//pause
            }


            game.IncreaseBlinds1 = dispatcher.GameData.TimeIncrease != -1;
            this.dispatcher.GameData.NbreOfGame = 0;
            game.Start();
        }

        /// <summary>
        /// hide menu item at the end of game, Invoke
        /// </summary>
        public void HideAtEndOfGame()
        {
            try
            {
                this.Invoke(new DelegateAddtext(HideAtEndOfGameInvoke), new object[] { this });
            }
            catch { }

        }


      
        public void HideAtEndOfGameInvoke(Control c)
        {
            if (this.Odds != null)
            {
                this.Odds.Invoke(new DelegateAddtext(MakeInVisible), new object[] { this.Odds });
                
            }
            if (this.Stats != null)
                this.Stats.Invoke(new DelegateAddtext(MakeInVisible), new object[] { this.Stats });
                
            this.menuItem18.Enabled = false;
           

        }
        /// <summary>
        /// hide cards and names
        /// </summary>
        /// 
        public void HideAll()
        {


            this.dispatcher.Game.MakeInvisibleArr(new Control[]{/*this.groupBox12,this.groupBox4,this.groupBox1,*/this.Player0,
																this.groupBox21,this.groupBox15,this.groupBox24,this.groupBox27,this.groupBox18,this.groupBox30,this.groupBox33,this.groupBox36,
																this.pictureBox4,this.pictureBox5,this.pictureBox6,this.pictureBox7,
																this.groupBox2,
																this.pictureBox1,
																this.pictureBox2,this.pictureBox52,
																this.pictureBox9,
																this.pictureBox10,
																this.pictureBox11,
																this.pictureBox12,
																this.pictureBox15,
																this.pictureBox16,
																this.pictureBox21,
																this.pictureBox22,
																this.pictureBox29,
																this.pictureBox30,
																this.pictureBox35,
																this.pictureBox36,
																this.pictureBox41,
																this.pictureBox42,
																this.pictureBox47,
																this.pictureBox48,
																this.pictureBox54,
																this.pictureBox53,
																this.pictureBox59,
																this.pictureBox60,this.pictureBox49,
																   this.pictureBox50,
				this.pictureBox33,
				this.pictureBox40,
				this.pictureBox20,
				this.pictureBox19,
				this.pictureBox26,
				this.pictureBox46,
				this.pictureBox43,
				this.pictureBox55,
				this.pictureBox58,
				this.pictureBox25,
				this.pictureBox2,
				this.pictureBox1,
				this.pictureBox13,
				this.pictureBox14,
				this.pictureBox32,
				this.pictureBox31,
				this.pictureBox38,
				this.pictureBox37
			});
        }
        public TrackBar TrackBar1
        {

            get { return this.trackBar1; }
        }
        public TextBox TextBox1
        {

            get { return this.textBox1; }
        }
        public void ResetCard()
        {
            this.card1 = "";
            this.card2 = "";
            this.card3 = "";
            this.card4 = "";
            this.card5 = "";
            this.card6 = "";
            this.card7 = "";
            this.SetCard1();
            this.SetCard2();
            this.SetCard3();
            this.SetCard4();
            this.SetCard5();
            this.SetCard6();
            this.SetCard7();

        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }
            catch (Exception)
            {
                return;
            }
        }

        #region Code généré par le Concepteur Windows Form
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox38 = new System.Windows.Forms.PictureBox();
            this.pictureBox31 = new System.Windows.Forms.PictureBox();
            this.pictureBox32 = new System.Windows.Forms.PictureBox();
            this.pictureBox46 = new System.Windows.Forms.PictureBox();
            this.pictureBox43 = new System.Windows.Forms.PictureBox();
            this.pictureBox37 = new System.Windows.Forms.PictureBox();
            this.pictureBox40 = new System.Windows.Forms.PictureBox();
            this.pictureBox33 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox58 = new System.Windows.Forms.PictureBox();
            this.pictureBox55 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.pictureBox25 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBoxCheck = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoFold = new System.Windows.Forms.CheckBox();
            this.buttonBetPot = new System.Windows.Forms.Button();
            this.buttonTripleRaise = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox52 = new System.Windows.Forms.PictureBox();
            this.labelSurv = new System.Windows.Forms.Label();
            this.labelAggr = new System.Windows.Forms.Label();
            this.pictureBox51 = new System.Windows.Forms.PictureBox();
            this.pictureBox45 = new System.Windows.Forms.PictureBox();
            this.pictureBox44 = new System.Windows.Forms.PictureBox();
            this.pictureBox39 = new System.Windows.Forms.PictureBox();
            this.pictureBox34 = new System.Windows.Forms.PictureBox();
            this.pictureBox28 = new System.Windows.Forms.PictureBox();
            this.pictureBox27 = new System.Windows.Forms.PictureBox();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.pictureBox23 = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.Player0 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox50 = new System.Windows.Forms.PictureBox();
            this.pictureBox49 = new System.Windows.Forms.PictureBox();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.pictureBox59 = new System.Windows.Forms.PictureBox();
            this.pictureBox60 = new System.Windows.Forms.PictureBox();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox53 = new System.Windows.Forms.PictureBox();
            this.pictureBox54 = new System.Windows.Forms.PictureBox();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox47 = new System.Windows.Forms.PictureBox();
            this.pictureBox48 = new System.Windows.Forms.PictureBox();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox41 = new System.Windows.Forms.PictureBox();
            this.pictureBox42 = new System.Windows.Forms.PictureBox();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox35 = new System.Windows.Forms.PictureBox();
            this.pictureBox36 = new System.Windows.Forms.PictureBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox29 = new System.Windows.Forms.PictureBox();
            this.pictureBox30 = new System.Windows.Forms.PictureBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem31 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.menuItem27 = new System.Windows.Forms.MenuItem();
            this.menuItem28 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.mediaPlayer1 = new poker.MediaPlayer();
            this.chronoCtr1 = new poker.ChronoCtr();
            this.admin1 = new poker.Admin();
            this.menuItem33 = new System.Windows.Forms.MenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            this.Player0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox49)).BeginInit();
            this.groupBox36.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox60)).BeginInit();
            this.groupBox33.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox54)).BeginInit();
            this.groupBox30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox48)).BeginInit();
            this.groupBox27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox42)).BeginInit();
            this.groupBox24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox36)).BeginInit();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox30)).BeginInit();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.pictureBox38);
            this.panel1.Controls.Add(this.pictureBox31);
            this.panel1.Controls.Add(this.pictureBox32);
            this.panel1.Controls.Add(this.pictureBox46);
            this.panel1.Controls.Add(this.pictureBox43);
            this.panel1.Controls.Add(this.pictureBox37);
            this.panel1.Controls.Add(this.pictureBox40);
            this.panel1.Controls.Add(this.pictureBox33);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox58);
            this.panel1.Controls.Add(this.pictureBox55);
            this.panel1.Controls.Add(this.pictureBox13);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox14);
            this.panel1.Controls.Add(this.pictureBox19);
            this.panel1.Controls.Add(this.pictureBox20);
            this.panel1.Controls.Add(this.pictureBox26);
            this.panel1.Controls.Add(this.pictureBox25);
            this.panel1.Controls.Add(this.chronoCtr1);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.pictureBox17);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.admin1);
            this.panel1.Controls.Add(this.pictureBox52);
            this.panel1.Controls.Add(this.labelSurv);
            this.panel1.Controls.Add(this.labelAggr);
            this.panel1.Controls.Add(this.pictureBox51);
            this.panel1.Controls.Add(this.pictureBox45);
            this.panel1.Controls.Add(this.pictureBox44);
            this.panel1.Controls.Add(this.pictureBox39);
            this.panel1.Controls.Add(this.pictureBox34);
            this.panel1.Controls.Add(this.pictureBox28);
            this.panel1.Controls.Add(this.pictureBox27);
            this.panel1.Controls.Add(this.pictureBox24);
            this.panel1.Controls.Add(this.pictureBox23);
            this.panel1.Controls.Add(this.pictureBox18);
            this.panel1.Controls.Add(this.Player0);
            this.panel1.Controls.Add(this.pictureBox50);
            this.panel1.Controls.Add(this.pictureBox49);
            this.panel1.Controls.Add(this.groupBox36);
            this.panel1.Controls.Add(this.pictureBox59);
            this.panel1.Controls.Add(this.pictureBox60);
            this.panel1.Controls.Add(this.groupBox33);
            this.panel1.Controls.Add(this.pictureBox53);
            this.panel1.Controls.Add(this.pictureBox54);
            this.panel1.Controls.Add(this.groupBox30);
            this.panel1.Controls.Add(this.pictureBox47);
            this.panel1.Controls.Add(this.pictureBox48);
            this.panel1.Controls.Add(this.groupBox27);
            this.panel1.Controls.Add(this.pictureBox41);
            this.panel1.Controls.Add(this.pictureBox42);
            this.panel1.Controls.Add(this.groupBox24);
            this.panel1.Controls.Add(this.pictureBox35);
            this.panel1.Controls.Add(this.pictureBox36);
            this.panel1.Controls.Add(this.groupBox21);
            this.panel1.Controls.Add(this.pictureBox29);
            this.panel1.Controls.Add(this.pictureBox30);
            this.panel1.Controls.Add(this.groupBox18);
            this.panel1.Controls.Add(this.pictureBox21);
            this.panel1.Controls.Add(this.pictureBox22);
            this.panel1.Controls.Add(this.groupBox15);
            this.panel1.Controls.Add(this.pictureBox16);
            this.panel1.Controls.Add(this.pictureBox15);
            this.panel1.Controls.Add(this.pictureBox11);
            this.panel1.Controls.Add(this.pictureBox12);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.pictureBox10);
            this.panel1.Controls.Add(this.pictureBox9);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.groupBox10);
            this.panel1.Controls.Add(this.pictureBox8);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox38
            // 
            resources.ApplyResources(this.pictureBox38, "pictureBox38");
            this.pictureBox38.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox38.Name = "pictureBox38";
            this.pictureBox38.TabStop = false;
            // 
            // pictureBox31
            // 
            resources.ApplyResources(this.pictureBox31, "pictureBox31");
            this.pictureBox31.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox31.Name = "pictureBox31";
            this.pictureBox31.TabStop = false;
            // 
            // pictureBox32
            // 
            resources.ApplyResources(this.pictureBox32, "pictureBox32");
            this.pictureBox32.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox32.Name = "pictureBox32";
            this.pictureBox32.TabStop = false;
            // 
            // pictureBox46
            // 
            resources.ApplyResources(this.pictureBox46, "pictureBox46");
            this.pictureBox46.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox46.Name = "pictureBox46";
            this.pictureBox46.TabStop = false;
            // 
            // pictureBox43
            // 
            resources.ApplyResources(this.pictureBox43, "pictureBox43");
            this.pictureBox43.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox43.Name = "pictureBox43";
            this.pictureBox43.TabStop = false;
            // 
            // pictureBox37
            // 
            resources.ApplyResources(this.pictureBox37, "pictureBox37");
            this.pictureBox37.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox37.Name = "pictureBox37";
            this.pictureBox37.TabStop = false;
            // 
            // pictureBox40
            // 
            resources.ApplyResources(this.pictureBox40, "pictureBox40");
            this.pictureBox40.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox40.Name = "pictureBox40";
            this.pictureBox40.TabStop = false;
            // 
            // pictureBox33
            // 
            resources.ApplyResources(this.pictureBox33, "pictureBox33");
            this.pictureBox33.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox33.Name = "pictureBox33";
            this.pictureBox33.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox58
            // 
            resources.ApplyResources(this.pictureBox58, "pictureBox58");
            this.pictureBox58.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox58.Name = "pictureBox58";
            this.pictureBox58.TabStop = false;
            // 
            // pictureBox55
            // 
            resources.ApplyResources(this.pictureBox55, "pictureBox55");
            this.pictureBox55.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox55.Name = "pictureBox55";
            this.pictureBox55.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox13, "pictureBox13");
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox14, "pictureBox14");
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox19
            // 
            resources.ApplyResources(this.pictureBox19, "pictureBox19");
            this.pictureBox19.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.TabStop = false;
            // 
            // pictureBox20
            // 
            resources.ApplyResources(this.pictureBox20, "pictureBox20");
            this.pictureBox20.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.TabStop = false;
            // 
            // pictureBox26
            // 
            resources.ApplyResources(this.pictureBox26, "pictureBox26");
            this.pictureBox26.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox26.Name = "pictureBox26";
            this.pictureBox26.TabStop = false;
            // 
            // pictureBox25
            // 
            resources.ApplyResources(this.pictureBox25, "pictureBox25");
            this.pictureBox25.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox25.Name = "pictureBox25";
            this.pictureBox25.TabStop = false;
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.richTextBox1);
            this.groupBox4.Controls.Add(this.richTextBox2);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.BackColor = System.Drawing.Color.LightGray;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            // 
            // richTextBox2
            // 
            resources.ApplyResources(this.richTextBox2, "richTextBox2");
            this.richTextBox2.AutoWordSelection = true;
            this.richTextBox2.BackColor = System.Drawing.Color.LightGray;
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox2_KeyPress);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackgroundImage = global::poker.Properties.Resources.buttonB_up;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Name = "button2";
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.checkBoxCheck);
            this.groupBox1.Controls.Add(this.checkBoxAutoFold);
            this.groupBox1.Controls.Add(this.buttonBetPot);
            this.groupBox1.Controls.Add(this.buttonTripleRaise);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.groupBox11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // checkBoxCheck
            // 
            resources.ApplyResources(this.checkBoxCheck, "checkBoxCheck");
            this.checkBoxCheck.Name = "checkBoxCheck";
            this.checkBoxCheck.UseVisualStyleBackColor = true;
            this.checkBoxCheck.CheckedChanged += new System.EventHandler(this.checkBoxCheck_CheckedChanged);
            // 
            // checkBoxAutoFold
            // 
            resources.ApplyResources(this.checkBoxAutoFold, "checkBoxAutoFold");
            this.checkBoxAutoFold.Name = "checkBoxAutoFold";
            this.checkBoxAutoFold.UseVisualStyleBackColor = true;
            this.checkBoxAutoFold.CheckedChanged += new System.EventHandler(this.checkBoxAutoFold_CheckedChanged);
            // 
            // buttonBetPot
            // 
            resources.ApplyResources(this.buttonBetPot, "buttonBetPot");
            this.buttonBetPot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonBetPot.Name = "buttonBetPot";
            this.buttonBetPot.UseVisualStyleBackColor = false;
            this.buttonBetPot.MouseLeave += new System.EventHandler(this.buttonBetPot_MouseLeave);
            this.buttonBetPot.Click += new System.EventHandler(this.buttonBetPot_Click);
            this.buttonBetPot.MouseEnter += new System.EventHandler(this.buttonBetPot_MouseEnter);
            // 
            // buttonTripleRaise
            // 
            resources.ApplyResources(this.buttonTripleRaise, "buttonTripleRaise");
            this.buttonTripleRaise.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonTripleRaise.Name = "buttonTripleRaise";
            this.buttonTripleRaise.UseVisualStyleBackColor = false;
            this.buttonTripleRaise.MouseLeave += new System.EventHandler(this.buttonTripleRaise_MouseLeave);
            this.buttonTripleRaise.Click += new System.EventHandler(this.buttonTripleRaise_Click);
            this.buttonTripleRaise.MouseEnter += new System.EventHandler(this.buttonTripleRaise_MouseEnter);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Name = "label4";
            // 
            // trackBar1
            // 
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.BackColor = System.Drawing.Color.LightGray;
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.trackBar1.LargeChange = 50;
            this.trackBar1.Maximum = 15000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.SmallChange = 50;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button7.Name = "button7";
            this.button7.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            this.button7.Click += new System.EventHandler(this.button7_Click);
            this.button7.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button6.Name = "button6";
            this.button6.MouseLeave += new System.EventHandler(this.button6_MouseLeave);
            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button6.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Name = "button5";
            this.button5.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Name = "button4";
            this.button4.MouseLeave += new System.EventHandler(this.button4_MouseLeave);
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.MouseEnter += new System.EventHandler(this.button4_MouseEnter);
            // 
            // groupBox11
            // 
            resources.ApplyResources(this.groupBox11, "groupBox11");
            this.groupBox11.Controls.Add(this.label3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox12
            // 
            resources.ApplyResources(this.groupBox12, "groupBox12");
            this.groupBox12.BackColor = System.Drawing.Color.Transparent;
            this.groupBox12.Controls.Add(this.richTextBox4);
            this.groupBox12.Controls.Add(this.mediaPlayer1);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.TabStop = false;
            this.groupBox12.Enter += new System.EventHandler(this.groupBox12_Enter);
            // 
            // richTextBox4
            // 
            this.richTextBox4.AllowDrop = true;
            resources.ApplyResources(this.richTextBox4, "richTextBox4");
            this.richTextBox4.BackColor = System.Drawing.Color.LightGray;
            this.richTextBox4.ForeColor = System.Drawing.Color.Black;
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            resources.ApplyResources(this.pictureBox7, "pictureBox7");
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox17
            // 
            resources.ApplyResources(this.pictureBox17, "pictureBox17");
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            resources.ApplyResources(this.pictureBox6, "pictureBox6");
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            resources.ApplyResources(this.pictureBox5, "pictureBox5");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox52
            // 
            this.pictureBox52.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox52, "pictureBox52");
            this.pictureBox52.Name = "pictureBox52";
            this.pictureBox52.TabStop = false;
            // 
            // labelSurv
            // 
            resources.ApplyResources(this.labelSurv, "labelSurv");
            this.labelSurv.BackColor = System.Drawing.Color.Transparent;
            this.labelSurv.ForeColor = System.Drawing.Color.Red;
            this.labelSurv.Name = "labelSurv";
            // 
            // labelAggr
            // 
            resources.ApplyResources(this.labelAggr, "labelAggr");
            this.labelAggr.BackColor = System.Drawing.Color.Transparent;
            this.labelAggr.ForeColor = System.Drawing.Color.Red;
            this.labelAggr.Name = "labelAggr";
            // 
            // pictureBox51
            // 
            this.pictureBox51.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox51.Image = global::poker.Properties.Resources.SB1;
            resources.ApplyResources(this.pictureBox51, "pictureBox51");
            this.pictureBox51.Name = "pictureBox51";
            this.pictureBox51.TabStop = false;
            // 
            // pictureBox45
            // 
            resources.ApplyResources(this.pictureBox45, "pictureBox45");
            this.pictureBox45.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox45.Name = "pictureBox45";
            this.pictureBox45.TabStop = false;
            // 
            // pictureBox44
            // 
            resources.ApplyResources(this.pictureBox44, "pictureBox44");
            this.pictureBox44.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox44.Name = "pictureBox44";
            this.pictureBox44.TabStop = false;
            // 
            // pictureBox39
            // 
            resources.ApplyResources(this.pictureBox39, "pictureBox39");
            this.pictureBox39.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox39.Name = "pictureBox39";
            this.pictureBox39.TabStop = false;
            // 
            // pictureBox34
            // 
            resources.ApplyResources(this.pictureBox34, "pictureBox34");
            this.pictureBox34.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox34.Name = "pictureBox34";
            this.pictureBox34.TabStop = false;
            // 
            // pictureBox28
            // 
            resources.ApplyResources(this.pictureBox28, "pictureBox28");
            this.pictureBox28.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox28.Name = "pictureBox28";
            this.pictureBox28.TabStop = false;
            // 
            // pictureBox27
            // 
            resources.ApplyResources(this.pictureBox27, "pictureBox27");
            this.pictureBox27.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox27.Image = global::poker.Properties.Resources.BB;
            this.pictureBox27.Name = "pictureBox27";
            this.pictureBox27.TabStop = false;
            // 
            // pictureBox24
            // 
            resources.ApplyResources(this.pictureBox24, "pictureBox24");
            this.pictureBox24.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.TabStop = false;
            // 
            // pictureBox23
            // 
            resources.ApplyResources(this.pictureBox23, "pictureBox23");
            this.pictureBox23.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox23.Name = "pictureBox23";
            this.pictureBox23.TabStop = false;
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox18, "pictureBox18");
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.TabStop = false;
            // 
            // Player0
            // 
            this.Player0.BackColor = System.Drawing.Color.Transparent;
            this.Player0.Controls.Add(this.label1);
            this.Player0.Controls.Add(this.label8);
            resources.ApplyResources(this.Player0, "Player0");
            this.Player0.ForeColor = System.Drawing.Color.White;
            this.Player0.Name = "Player0";
            this.Player0.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // pictureBox50
            // 
            resources.ApplyResources(this.pictureBox50, "pictureBox50");
            this.pictureBox50.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox50.Name = "pictureBox50";
            this.pictureBox50.TabStop = false;
            // 
            // pictureBox49
            // 
            resources.ApplyResources(this.pictureBox49, "pictureBox49");
            this.pictureBox49.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox49.Name = "pictureBox49";
            this.pictureBox49.TabStop = false;
            // 
            // groupBox36
            // 
            resources.ApplyResources(this.groupBox36, "groupBox36");
            this.groupBox36.BackColor = System.Drawing.Color.Transparent;
            this.groupBox36.Controls.Add(this.label23);
            this.groupBox36.Controls.Add(this.label19);
            this.groupBox36.ForeColor = System.Drawing.Color.White;
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.TabStop = false;
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // pictureBox59
            // 
            resources.ApplyResources(this.pictureBox59, "pictureBox59");
            this.pictureBox59.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox59.Name = "pictureBox59";
            this.pictureBox59.TabStop = false;
            // 
            // pictureBox60
            // 
            resources.ApplyResources(this.pictureBox60, "pictureBox60");
            this.pictureBox60.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox60.Name = "pictureBox60";
            this.pictureBox60.TabStop = false;
            // 
            // groupBox33
            // 
            resources.ApplyResources(this.groupBox33, "groupBox33");
            this.groupBox33.BackColor = System.Drawing.Color.Transparent;
            this.groupBox33.Controls.Add(this.label22);
            this.groupBox33.Controls.Add(this.label17);
            this.groupBox33.ForeColor = System.Drawing.Color.White;
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.TabStop = false;
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // pictureBox53
            // 
            resources.ApplyResources(this.pictureBox53, "pictureBox53");
            this.pictureBox53.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox53.Name = "pictureBox53";
            this.pictureBox53.TabStop = false;
            // 
            // pictureBox54
            // 
            resources.ApplyResources(this.pictureBox54, "pictureBox54");
            this.pictureBox54.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox54.Name = "pictureBox54";
            this.pictureBox54.TabStop = false;
            // 
            // groupBox30
            // 
            resources.ApplyResources(this.groupBox30, "groupBox30");
            this.groupBox30.BackColor = System.Drawing.Color.Transparent;
            this.groupBox30.Controls.Add(this.label21);
            this.groupBox30.Controls.Add(this.label15);
            this.groupBox30.ForeColor = System.Drawing.Color.White;
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.TabStop = false;
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // pictureBox47
            // 
            resources.ApplyResources(this.pictureBox47, "pictureBox47");
            this.pictureBox47.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox47.Name = "pictureBox47";
            this.pictureBox47.TabStop = false;
            // 
            // pictureBox48
            // 
            resources.ApplyResources(this.pictureBox48, "pictureBox48");
            this.pictureBox48.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox48.Name = "pictureBox48";
            this.pictureBox48.TabStop = false;
            // 
            // groupBox27
            // 
            resources.ApplyResources(this.groupBox27, "groupBox27");
            this.groupBox27.BackColor = System.Drawing.Color.Transparent;
            this.groupBox27.Controls.Add(this.label20);
            this.groupBox27.Controls.Add(this.label13);
            this.groupBox27.ForeColor = System.Drawing.Color.White;
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.TabStop = false;
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // pictureBox41
            // 
            resources.ApplyResources(this.pictureBox41, "pictureBox41");
            this.pictureBox41.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox41.Name = "pictureBox41";
            this.pictureBox41.TabStop = false;
            // 
            // pictureBox42
            // 
            resources.ApplyResources(this.pictureBox42, "pictureBox42");
            this.pictureBox42.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox42.Name = "pictureBox42";
            this.pictureBox42.TabStop = false;
            // 
            // groupBox24
            // 
            resources.ApplyResources(this.groupBox24, "groupBox24");
            this.groupBox24.BackColor = System.Drawing.Color.Transparent;
            this.groupBox24.Controls.Add(this.label18);
            this.groupBox24.Controls.Add(this.label12);
            this.groupBox24.ForeColor = System.Drawing.Color.White;
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.TabStop = false;
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // pictureBox35
            // 
            resources.ApplyResources(this.pictureBox35, "pictureBox35");
            this.pictureBox35.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox35.Name = "pictureBox35";
            this.pictureBox35.TabStop = false;
            // 
            // pictureBox36
            // 
            resources.ApplyResources(this.pictureBox36, "pictureBox36");
            this.pictureBox36.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox36.Name = "pictureBox36";
            this.pictureBox36.TabStop = false;
            // 
            // groupBox21
            // 
            resources.ApplyResources(this.groupBox21, "groupBox21");
            this.groupBox21.BackColor = System.Drawing.Color.Transparent;
            this.groupBox21.Controls.Add(this.label16);
            this.groupBox21.Controls.Add(this.label10);
            this.groupBox21.ForeColor = System.Drawing.Color.White;
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.TabStop = false;
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // pictureBox29
            // 
            resources.ApplyResources(this.pictureBox29, "pictureBox29");
            this.pictureBox29.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox29.Name = "pictureBox29";
            this.pictureBox29.TabStop = false;
            // 
            // pictureBox30
            // 
            resources.ApplyResources(this.pictureBox30, "pictureBox30");
            this.pictureBox30.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox30.Name = "pictureBox30";
            this.pictureBox30.TabStop = false;
            // 
            // groupBox18
            // 
            resources.ApplyResources(this.groupBox18, "groupBox18");
            this.groupBox18.BackColor = System.Drawing.Color.Transparent;
            this.groupBox18.Controls.Add(this.label14);
            this.groupBox18.Controls.Add(this.label7);
            this.groupBox18.ForeColor = System.Drawing.Color.White;
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.TabStop = false;
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // pictureBox21
            // 
            resources.ApplyResources(this.pictureBox21, "pictureBox21");
            this.pictureBox21.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.TabStop = false;
            // 
            // pictureBox22
            // 
            resources.ApplyResources(this.pictureBox22, "pictureBox22");
            this.pictureBox22.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.TabStop = false;
            // 
            // groupBox15
            // 
            resources.ApplyResources(this.groupBox15, "groupBox15");
            this.groupBox15.BackColor = System.Drawing.Color.Transparent;
            this.groupBox15.Controls.Add(this.label11);
            this.groupBox15.Controls.Add(this.label6);
            this.groupBox15.ForeColor = System.Drawing.Color.White;
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.TabStop = false;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // pictureBox16
            // 
            resources.ApplyResources(this.pictureBox16, "pictureBox16");
            this.pictureBox16.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.TabStop = false;
            // 
            // pictureBox15
            // 
            resources.ApplyResources(this.pictureBox15, "pictureBox15");
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox11, "pictureBox11");
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox12, "pictureBox12");
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox10, "pictureBox10");
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox9, "pictureBox9");
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.TabStop = false;
            // 
            // listBox1
            // 
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.Name = "listBox1";
            // 
            // groupBox10
            // 
            resources.ApplyResources(this.groupBox10, "groupBox10");
            this.groupBox10.BackColor = System.Drawing.Color.Transparent;
            this.groupBox10.Controls.Add(this.label2);
            this.groupBox10.ForeColor = System.Drawing.Color.White;
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // pictureBox8
            // 
            resources.ApplyResources(this.pictureBox8, "pictureBox8");
            this.pictureBox8.Image = global::poker.Properties.Resources.newUI_E;
            this.pictureBox8.InitialImage = null;
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.TabStop = false;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem7,
            this.menuItem4,
            this.menuItem13,
            this.menuItem14,
            this.menuItem17,
            this.menuItem31,
            this.menuItem5,
            this.menuItem9,
            this.menuItem33});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            resources.ApplyResources(this.menuItem1, "menuItem1");
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem6});
            resources.ApplyResources(this.menuItem2, "menuItem2");
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            resources.ApplyResources(this.menuItem3, "menuItem3");
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            resources.ApplyResources(this.menuItem6, "menuItem6");
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem12});
            resources.ApplyResources(this.menuItem7, "menuItem7");
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem10,
            this.menuItem11});
            resources.ApplyResources(this.menuItem8, "menuItem8");
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 0;
            resources.ApplyResources(this.menuItem10, "menuItem10");
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 1;
            resources.ApplyResources(this.menuItem11, "menuItem11");
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 1;
            resources.ApplyResources(this.menuItem12, "menuItem12");
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            resources.ApplyResources(this.menuItem4, "menuItem4");
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 4;
            resources.ApplyResources(this.menuItem13, "menuItem13");
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 5;
            resources.ApplyResources(this.menuItem14, "menuItem14");
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 6;
            resources.ApplyResources(this.menuItem17, "menuItem17");
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem31
            // 
            this.menuItem31.Index = 7;
            this.menuItem31.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem15,
            this.menuItem20,
            this.menuItem25,
            this.menuItem24,
            this.menuItem18,
            this.menuItem32});
            resources.ApplyResources(this.menuItem31, "menuItem31");
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 0;
            this.menuItem15.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem16,
            this.menuItem19});
            resources.ApplyResources(this.menuItem15, "menuItem15");
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 0;
            this.menuItem16.RadioCheck = true;
            resources.ApplyResources(this.menuItem16, "menuItem16");
            this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.Checked = true;
            this.menuItem19.Index = 1;
            this.menuItem19.RadioCheck = true;
            resources.ApplyResources(this.menuItem19, "menuItem19");
            this.menuItem19.Select += new System.EventHandler(this.menuItem19_Select);
            this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 1;
            this.menuItem20.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem21,
            this.menuItem22,
            this.menuItem23});
            resources.ApplyResources(this.menuItem20, "menuItem20");
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 0;
            resources.ApplyResources(this.menuItem21, "menuItem21");
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 1;
            resources.ApplyResources(this.menuItem22, "menuItem22");
            this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 2;
            resources.ApplyResources(this.menuItem23, "menuItem23");
            this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 2;
            this.menuItem25.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem26,
            this.menuItem27,
            this.menuItem28});
            resources.ApplyResources(this.menuItem25, "menuItem25");
            // 
            // menuItem26
            // 
            this.menuItem26.Checked = true;
            this.menuItem26.Index = 0;
            this.menuItem26.RadioCheck = true;
            resources.ApplyResources(this.menuItem26, "menuItem26");
            this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click);
            // 
            // menuItem27
            // 
            this.menuItem27.Index = 1;
            this.menuItem27.RadioCheck = true;
            resources.ApplyResources(this.menuItem27, "menuItem27");
            this.menuItem27.Click += new System.EventHandler(this.menuItem27_Click);
            // 
            // menuItem28
            // 
            this.menuItem28.Index = 2;
            this.menuItem28.RadioCheck = true;
            resources.ApplyResources(this.menuItem28, "menuItem28");
            this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
            // 
            // menuItem24
            // 
            resources.ApplyResources(this.menuItem24, "menuItem24");
            this.menuItem24.Index = 3;
            this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click_1);
            // 
            // menuItem18
            // 
            resources.ApplyResources(this.menuItem18, "menuItem18");
            this.menuItem18.Index = 4;
            this.menuItem18.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem29,
            this.menuItem30});
            this.menuItem18.RadioCheck = true;
            this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 0;
            this.menuItem29.RadioCheck = true;
            resources.ApplyResources(this.menuItem29, "menuItem29");
            this.menuItem29.Click += new System.EventHandler(this.menuItem29_Click);
            // 
            // menuItem30
            // 
            this.menuItem30.Checked = true;
            this.menuItem30.Index = 1;
            this.menuItem30.RadioCheck = true;
            resources.ApplyResources(this.menuItem30, "menuItem30");
            this.menuItem30.Click += new System.EventHandler(this.menuItem30_Click);
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 5;
            resources.ApplyResources(this.menuItem32, "menuItem32");
            this.menuItem32.Click += new System.EventHandler(this.menuItem32_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 8;
            this.menuItem5.RadioCheck = true;
            resources.ApplyResources(this.menuItem5, "menuItem5");
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 9;
            resources.ApplyResources(this.menuItem9, "menuItem9");
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click_1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox12);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            // 
            // mediaPlayer1
            // 
            this.mediaPlayer1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mediaPlayer1, "mediaPlayer1");
            this.mediaPlayer1.Name = "mediaPlayer1";
            // 
            // chronoCtr1
            // 
            this.chronoCtr1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            resources.ApplyResources(this.chronoCtr1, "chronoCtr1");
            this.chronoCtr1.BackColor = System.Drawing.Color.Transparent;
            this.chronoCtr1.ChronoTimer = null;
            this.chronoCtr1.Name = "chronoCtr1";
            // 
            // admin1
            // 
            this.admin1.BackColor = System.Drawing.Color.Transparent;
            this.admin1.Dispatcher = null;
            resources.ApplyResources(this.admin1, "admin1");
            this.admin1.Name = "admin1";
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 10;
            resources.ApplyResources(this.menuItem33, "menuItem33");
            this.menuItem33.Click += new System.EventHandler(this.menuItem33_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            this.Player0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox49)).EndInit();
            this.groupBox36.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox60)).EndInit();
            this.groupBox33.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox54)).EndInit();
            this.groupBox30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox48)).EndInit();
            this.groupBox27.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox42)).EndInit();
            this.groupBox24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox36)).EndInit();
            this.groupBox21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox30)).EndInit();
            this.groupBox18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            this.groupBox15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        ///
        [STAThread]
        static void Main()
        {
            //TestClass test = new TestClass();
            //test.LaunchTirageMain(1000);
            
            //test.LaunchTirageMain(5000);

            //test.LaunchTirageMain(10000);
            //test.LaunchTirageMain(50000);
            //test.LaunchTirageMain(100000);
            //test.LaunchTirageMain(1000000);
            //test.LauchStatTest(100);
            //test.LauchStatTest(1000);
            //test.LauchStatTest(10000);
            //test.LauchStatTest(100000);
            //test.LauchStatTest(1000000);
            
            Form1 form = new Form1("pokdtc");

            Application.Run(form);
        }


        public bool GetValid()
        {
            if (valid) { return true; };
            return this.valid;
        }
        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }
        //for network player
        public void ShowCards(int i, string c1, string c2)
        {
            if (c1 == "")
            {
                this.dispatcher.Game.MakeVisible(this.dispatcher.Game.GetPlayer(i).ShowCard1);
                this.dispatcher.Game.MakeVisible(this.dispatcher.Game.GetPlayer(i).ShowCard2);



            }
            else
            {
                this.dispatcher.Game.GetPlayer(i).ShowCard1.Image = new Bitmap(Application.StartupPath + "\\cards\\" + c1 + ".png");
                this.dispatcher.Game.GetPlayer(i).ShowCard2.Image = new Bitmap(Application.StartupPath + "\\cards\\" + c2 + ".png");
                this.dispatcher.Game.MakeVisible(this.dispatcher.Game.GetPlayer(i).ShowCard1);
                this.dispatcher.Game.MakeVisible(this.dispatcher.Game.GetPlayer(i).ShowCard2);
            }
        }
        /// <summary>
        /// show cards of everybody in game
        /// </summary>
        public void SeeCards()
        {
            object[] p = new object[1];

            p[0] = this.dispatcher.Game.GetPlayer(0).ShowCard1;
            this.dispatcher.Game.GetPlayer(0).ShowCard1.Invoke(new MakeVisibleHandler(this.MakeVisible), p);
            p[0] = this.dispatcher.Game.GetPlayer(0).ShowCard2;
            this.dispatcher.Game.GetPlayer(0).ShowCard2.Invoke(new MakeVisibleHandler(this.MakeVisible), p);

            for (int i = 0; i < this.dispatcher.GameData.Nbr; i++)
            {
                if (this.dispatcher.Game.InRound(i) == 1)
                {
                    p[0] = this.dispatcher.Game.GetPlayer(i).HiddenCard1;
                    this.dispatcher.Game.GetPlayer(i).HiddenCard1.Invoke(new MakeVisibleHandler(this.MakeVisible), p);
                    p[0] = this.dispatcher.Game.GetPlayer(i).HiddenCard2;
                    this.dispatcher.Game.GetPlayer(i).HiddenCard2.Invoke(new MakeVisibleHandler(this.MakeVisible), p);



                }
                else
                {

                    p[0] = this.dispatcher.Game.GetPlayer(i).HiddenCard1;
                    this.dispatcher.Game.GetPlayer(i).HiddenCard1.Invoke(new MakeVisibleHandler(this.MakeInVisible), p);
                    p[0] = this.dispatcher.Game.GetPlayer(i).HiddenCard2; this.dispatcher.Game.GetPlayer(i).HiddenCard2.Invoke(new MakeVisibleHandler(this.MakeInVisible), p);


                }

            }
        }
        /// <summary>
        /// outdated
        /// </summary>
        public void ShowDealer()
        {
            int deal = this.dispatcher.Game.CurrentDealer;


        }
        /// <summary>
        /// hide face down cards for player i
        /// </summary>
        /// <param name="i"></param>
        public void HideCard(int i)
        {

            this.dispatcher.Game.MakeInVisible(this.dispatcher.Game.GetPlayer(i).HiddenCard1);

            this.dispatcher.Game.MakeInVisible(this.dispatcher.Game.GetPlayer(i).HiddenCard2);


        }
        /// <summary>
        /// hide face up cards
        /// </summary>
        /// <param name="i"></param>
        public void HideCards(int i)
        {

            this.dispatcher.Game.MakeInVisible(this.dispatcher.Game.GetPlayer(i).ShowCard1);

            this.dispatcher.Game.MakeInVisible(this.dispatcher.Game.GetPlayer(i).ShowCard2);


        }
        /// <summary>
        /// hide every body cards
        /// </summary>
        public void HideCard()
        {
            for (int i = 0; i < this.dispatcher.Game.NbrPlayerSinceBegin; i++)
            {
                if (this.dispatcher.Game.InRound(i) == 1)
                {
                    this.dispatcher.Game.GetPlayer(i).HideCard();
                }
                else HideCard(i);
                //	this.dispatcher.Game.MakeInVisible(this.dispatcher.Game.GetPlayer(i).HiddenCard1);

                //	this.dispatcher.Game.MakeInVisible(this.dispatcher.Game.GetPlayer(i).HiddenCard2);
            }

        }

        /// <summary>
        /// get raise amount
        /// </summary>
        /// <returns></returns>
        public long GetTextBox1()
        {
            return (long)Convert.ToUInt32(textBox1.Text);
        }
        /// <summary>
        /// change your money 
        /// </summary>
        /// <param name="a"></param>
        public void Setlabel1(long a)
        {
            //label1.Text=a.ToString() + "$";


            object[] p = new object[1];

            txt_swap = a.ToString() + "$";
            p[0] = label1;
            try
            {
                label1.Invoke(new DelegateAddtext(AddTextInvoke), p);
            }
            catch { }
        }

        /// <summary>
        /// display when you loose the game
        /// </summary>
        public void Looze()
        {
            ResetCard();
            //to do a changer 

            MyMsgBox mybox = new MyMsgBox("Money", Language.GetNotEnoughMoneyEvents(), this.dispatcher.Form);
            this.Dispatcher.Form.Launch = false;
            mybox.Show();
        }
        /// <summary>
        /// change absolute value to simple value to do mettre en static dans Card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private string GetValueCard(string card)
        {
            if (card.CompareTo("") == 0)
                return "";
            int val = (int)Convert.ToInt32(card);
            while (!(val <= 13))
                val -= 13;

            return val.ToString();
        }
        /// <summary>
        /// get absolute color of an absolute card value, to do mettre en static dans Card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private string GetColor(string card)
        {
            if (card.CompareTo("") == 0)
                return "";
            int val = (int)Convert.ToInt32(card);
            if (val >= 40) return "t";
            if (val >= 27) return "p";
            if (val >= 14) return "ca";
            else return "co";
        }
        /// <summary>
        /// display the card1
        /// </summary>
        public void SetCard1()
        {
            string val = GetValueCard(card1);
            string col = GetColor(card1);
            if (card1.CompareTo("") == 0) pictureBox1.Image = null;
            else
            {
                try
                {
                    object[] p = new object[1];
                    p[0] = this.dispatcher.Game.Player.ShowCard1;
                    this.dispatcher.Game.Player.ShowCard1.Image = new Bitmap(Application.StartupPath + "\\cards\\" + val + col + ".png");

                    this.dispatcher.Game.Player.ShowCard1.Invoke(new MakeVisibleHandler(MakeVisible), p);
                }
                catch { }
            }
        }
        /// <summary>
        /// show correct information for each player and show his cards 
        /// </summary>
        /// <param name="pl"></param>
        public void BuildVisualInfos(Player pl)
        {
            switch (pl.Id)
            {
                case 0: pl.Box = this.Player0;
                    pl.ShowCard1 = this.pictureBox1;
                    pl.ShowCard2 = this.pictureBox2;
                    pl.HiddenCard1 = this.pictureBox10;
                    pl.HiddenCard2 = this.pictureBox9;
                    pl.MoneyLabel = this.label1;
                    pl.Dealer = this.pictureBox51;
                    pl.Action = this.label8;


                    break;
                case 1: pl.Box = this.groupBox2;
                    pl.ShowCard1 = this.pictureBox13;
                    pl.ShowCard2 = this.pictureBox14;
                    pl.HiddenCard1 = this.pictureBox11;
                    pl.HiddenCard2 = this.pictureBox12;
                    pl.MoneyLabel = this.label5;
                    pl.Dealer = this.pictureBox18;
                    pl.Action = this.label9;
                    break;
                case 2: pl.Box = this.groupBox15;
                    pl.ShowCard1 = this.pictureBox40;
                    pl.ShowCard2 = this.pictureBox33;
                    pl.HiddenCard1 = this.pictureBox16;
                    pl.HiddenCard2 = this.pictureBox15;
                    pl.MoneyLabel = this.label6;
                    pl.Dealer = this.pictureBox23;
                    pl.Action = this.label11;
                    break;
                case 3: pl.Box = this.groupBox18;
                    pl.ShowCard1 = this.pictureBox20;
                    pl.ShowCard2 = this.pictureBox19;
                    pl.HiddenCard1 = this.pictureBox21;
                    pl.HiddenCard2 = this.pictureBox22;
                    pl.MoneyLabel = this.label7;
                    pl.Dealer = this.pictureBox24;
                    pl.Action = this.label14;
                    break;
                case 4: pl.Box = this.groupBox21;
                    pl.ShowCard1 = this.pictureBox25;
                    pl.ShowCard2 = this.pictureBox26;
                    pl.HiddenCard1 = this.pictureBox29;
                    pl.HiddenCard2 = this.pictureBox30;
                    pl.MoneyLabel = this.label10;
                    pl.Dealer = this.pictureBox27;
                    pl.Action = this.label16;
                    break;
                case 5: pl.Box = this.groupBox24;
                    pl.ShowCard1 = this.pictureBox32;
                    pl.ShowCard2 = this.pictureBox31;
                    pl.HiddenCard1 = this.pictureBox35;
                    pl.HiddenCard2 = this.pictureBox36;
                    pl.MoneyLabel = this.label12;
                    pl.Dealer = this.pictureBox28;
                    pl.Action = this.label18;
                    break;
                case 6: pl.Box = this.groupBox27;
                    pl.ShowCard1 = this.pictureBox38;
                    pl.ShowCard2 = this.pictureBox37;
                    pl.HiddenCard1 = this.pictureBox42;
                    pl.HiddenCard2 = this.pictureBox41;
                    pl.MoneyLabel = this.label13;
                    pl.Dealer = this.pictureBox34;
                    pl.Action = this.label20;
                    break;
                case 7: pl.Box = this.groupBox30;
                    pl.ShowCard1 = this.pictureBox43;
                    pl.ShowCard2 = this.pictureBox46;
                    pl.HiddenCard1 = this.pictureBox48;
                    pl.HiddenCard2 = this.pictureBox47;
                    pl.MoneyLabel = this.label15;
                    pl.Dealer = this.pictureBox39;
                    pl.Action = this.label21;
                    break;
                case 8: pl.Box = this.groupBox33;
                    pl.ShowCard1 = this.pictureBox49;
                    pl.ShowCard2 = this.pictureBox50;
                    pl.HiddenCard1 = this.pictureBox53;
                    pl.HiddenCard2 = this.pictureBox54;
                    pl.MoneyLabel = this.label17;
                    pl.Dealer = this.pictureBox44;
                    pl.Action = this.label22;
                    break;
                case 9: pl.Box = this.groupBox36;
                    pl.ShowCard1 = this.pictureBox58;
                    pl.ShowCard2 = this.pictureBox55;
                    pl.HiddenCard1 = this.pictureBox59;
                    pl.HiddenCard2 = this.pictureBox60;
                    pl.MoneyLabel = this.label19;
                    pl.Dealer = this.pictureBox45;
                    pl.Action = this.label23;
                    break;
                default: break;

            }
            object[] p = new object[1];
            p[0] = pl.Box;

            pl.Box.Invoke(new MakeVisibleHandler(this.MakeVisible), p);
            p[0] = pl.HiddenCard1;
            pl.HiddenCard1.Invoke(new MakeVisibleHandler(this.MakeVisible), p);
            p[0] = pl.HiddenCard2;
            pl.HiddenCard2.Invoke(new MakeVisibleHandler(this.MakeVisible), p);

        }
        /// <summary>
        /// display the card2
        /// </summary>
        public void SetCard2()
        {

            string val = GetValueCard(card2);
            string col = GetColor(card2);
            if (card2.CompareTo("") == 0)
                pictureBox2.Image = null;
            else
            {
                try
                {
                    object[] p = new object[1];
                    p[0] = this.dispatcher.Game.Player.ShowCard2;
                    this.dispatcher.Game.Player.ShowCard2.Image = new Bitmap(Application.StartupPath + "\\cards\\" + val + col + ".png");
                    //pictureBox2.Visible=true;
                    this.dispatcher.Game.Player.ShowCard2.Invoke(new MakeVisibleHandler(MakeVisible), p);
                }
                catch (Exception exception){ }
            }
        }
        /// <summary>
        /// display the card3
        /// </summary>
        public void SetCard3()
        {

            string val = GetValueCard(card3);
            string col = GetColor(card3);
            if (card3.CompareTo("") == 0) pictureBox3.Image = null;
            else
            {
                try
                {
                    object[] p = new object[1];
                    p[0] = pictureBox4;
                    pictureBox4.Image = new Bitmap(Application.StartupPath + "\\cards\\" + val + col + ".png");
                    //pictureBox3.Visible=true;
                    pictureBox4.Invoke(new MakeVisibleHandler(MakeVisible), p);
                }
                catch { }
            }
        }
        /// <summary>
        /// display the card4
        /// </summary>
        public void SetCard4()
        {
            try
            {
                string val = GetValueCard(card4);
                string col = GetColor(card4);
                if (card4.CompareTo("") == 0) pictureBox4.Image = null;
                else
                {
                    object[] p = new object[1];
                    p[0] = pictureBox3;
                    pictureBox3.Image = new Bitmap(Application.StartupPath + "\\cards\\" + val + col + ".png");
                    //pictureBox4.Visible=true;
                    pictureBox3.Invoke(new MakeVisibleHandler(MakeVisible), p);
                }
            }
            catch { }
        }
        /// <summary>
        /// display the card5
        /// </summary>
        public void SetCard5()
        {
            try
            {
                string val = GetValueCard(card5);
                string col = GetColor(card5);
                if (card5.CompareTo("") == 0) pictureBox5.Image = null;
                else
                {
                    object[] p = new object[1];
                    p[0] = pictureBox5;
                    pictureBox5.Image = new Bitmap(Application.StartupPath + "\\cards\\" + val + col + ".png");
                    //pictureBox5.Visible=true;
                    pictureBox5.Invoke(new MakeVisibleHandler(MakeVisible), p);
                }
            }
            catch { }
        }
        /// <summary>
        /// display the card6
        /// </summary>
        public void SetCard6()
        {
            try
            {
                string val = GetValueCard(card6);
                string col = GetColor(card6);
                if (card6.CompareTo("") == 0) pictureBox6.Image = null;
                else
                {
                    object[] p = new object[1];
                    p[0] = pictureBox6;
                    pictureBox6.Image = new Bitmap(Application.StartupPath + "\\cards\\" + val + col + ".png");
                    //pictureBox6.Visible=true;
                    pictureBox6.Invoke(new MakeVisibleHandler(MakeVisible), p);

                }
            }
            catch { }
        }
        /// <summary>
        /// display the card7
        /// </summary>
        public void SetCard7()
        {
            try
            {
                string val = GetValueCard(card7);
                string col = GetColor(card7);
                if (card7.CompareTo("") == 0) pictureBox7.Image = null;
                else
                {
                    object[] p = new object[1];
                    p[0] = pictureBox7;
                    pictureBox7.Image = new Bitmap(Application.StartupPath + "\\cards\\" + val + col + ".png");
                    //pictureBox7.Visible=true;
                    pictureBox7.Invoke(new MakeVisibleHandler(MakeVisible), p);
                }


            }
            catch { }
        }
        /// <summary>
        /// set local player
        /// </summary>
        /// <param name="player"></param>
        public void SetPlayer(Player player)
        {
            pl = player;
        }

        private MediaList media;
        public MediaList Media
        {

            get { return media; }
        }
        public void RefreshMe(Control c)
        {

            this.Refresh();
            this.Update();
        }

        public void RefreshMe()
        {
            try
            {
                object[] p = new object[1];
                p[0] = this;
                this.Invoke(new MakeVisibleHandler(RefreshMe), p);
            }
            catch { }

        }
        private void Form1_Load(object sender, System.EventArgs e)
        {



            this.Hide();
            /*  TEST RANDOM 
            MyRandom rd1 = new MyRandom();
int a;
            int test =1000000;
            long[] listeCard = new long[52];
            for (int i=0;i<=test;i++)
            {
                a = rd1.getRandomNumber();
                listeCard[a]++;
            
            }

double error = 0;
         double denom = 0;
            double ratio = 1 / 52;
          
            for (int i=0;i<52;i++)
            {
                denom += System.Math.Abs(((double)listeCard[i] / (double)test - 1.0 / 52.0)) * System.Math.Abs((double)(listeCard[i] / (double)test - 1.0 / 52.0));
            }
            error = denom/52.0 ;
*/

            string currentCulture = System.Globalization.CultureInfo.CurrentUICulture.ToString();
            Language.ChangeCurrentLanguage(currentCulture);
            this.Translation();
            media = new MediaList(this.mediaPlayer1);
            Welcome welcome = new Welcome(this);


            welcome.Show();

            DynamicDisplay.CURRENT_SIZE_X = pictureBox8.Size.Width;
            DynamicDisplay.CURRENT_SIZE_Y = pictureBox8.Size.Height;
            DynamicDisplay.mainW = this;
            DynamicDisplay display = new DynamicDisplay(this);
            display.ChangeDisplayTable();
            display.ChangeDisplayCards();
            //launch thread for blinking
           
            //le son a été degagé  voir si on en rajoute un autre
            //this.mediaPlayer1.PlaySoundASynchronous(Application.StartupPath + "//MEDIA//intro//nameofthegame.wav");

            //Hand hand = new Hand(new Card(3, 14),
            //    new Card(1, 5),
            //    new Card(1, 2),
            //    new Card(2, 2),
            //    new Card(3, 2),
            //    new Card(2, 14),
            //    new Card(1, 14));
            //hand.EvaluateHand();

            //Hand hand2 = new Hand(new Card(1, 11),
            //  new Card(2, 7),
            //   new Card(1, 2),
            //    new Card(2, 2),
            //    new Card(3, 2),
            //    new Card(2, 14),
            //    new Card(1, 14));
            //hand2.EvaluateHand();

            //if (hand > hand2)
            //    return;
            //return;
            //media.AllIn();
            //media.AllIn();
            //media.AllIn();
            //media.AllIn();

            //this.mediaPlayer1.PlaySound(p);
            //this.mediaPlayer1.PlaySound(p);
            //this.mediaPlayer1.PlaySound(p);
            //this.mediaPlayer1.PlaySound(p);
            //this.mediaPlayer1.PlaySound(p);
          //  this.richTextBox4.Text=("♠");
        }

    
        /// <summary>
        /// display properties window
        /// </summary>
        public void ShowProperties()
        {
            if (this.dispatcher.GameData.AggrMode.AggressiveModeBool)
            {
                MessageBox.Show(this, Language.GetCannotEditEvents());
                return;
            }
            PropertiesGame prop = new PropertiesGame(dispatcher, launch);
            prop.Show();

        }
        /// <summary>
        /// basic delegate 
        /// </summary>
        /// <param name="control"></param>
        public delegate void MakeVisibleHandler(Control control);

        public void MakeInVisible(Control control)
        {

            control.Visible = false;
        }
        public void MakeVisible(Control control)
        {

            control.Visible = true;
            control.Enabled = true;
           

        }
        /// <summary>
        /// outdated
        /// </summary>
        /// <param name="control"></param>
        public void FillMoney(Control control)
        {

            control.Text = "23333333$";
        }
        private bool swap_bool;
        public void MakeVisibleInvoke(Control c, bool b)
        {

            swap_bool = b;
            try
            {
                object[] p = new object[1];
                p[0] = c;
                c.Invoke(new DelegateAddtext(MakeShow), p);
            }
            catch { }

        }
        /// <summary>
        /// updated
        /// </summary>
        /// <param name="control"></param>
        public void MakeShow(Control control)
        {

            //this.showHand.DrawCards();
            control.Visible = swap_bool;
        }
        /// <summary>
        /// outdated
        /// </summary>
        /// <param name="i"></param>
        public void FillInfo(int i)
        {

            object[] p = new object[1];

            p[0] = this.dispatcher.Game.GetPlayer(i).MoneyLabel;
            this.dispatcher.Game.GetPlayer(i).MoneyLabel.Invoke(new MakeVisibleHandler(FillMoney), p);
            p[0] = this.dispatcher.Game.GetPlayer(i).Box;
            //this.dispatcher.Game.GetPlayer(i).Box.Invoke(new MakeVisibleHandler(FillName), p);

        }
        /// <summary>
        /// hide or show all in button
        /// </summary>
        /// <param name="b"></param>
        public void SetVisibilityAllin(bool b)
        {
            try
            {
                object[] p = new object[1];
                p[0] = button4;
                if (b) button4.Invoke(new MakeVisibleHandler(MakeVisible), p);
                else button4.Invoke(new MakeVisibleHandler(MakeInVisible), p);
                //this.button4.Visible=b;
            }
            catch { return; }

        }
        /// <summary>
        /// hide or show call button
        /// </summary>
        /// <param name="b"></param>
        public void SetVisibilityCall(bool b)
        {
            try
            {
                object[] p = new object[1];
                p[0] = button6;
                if (b)
                    button6.Invoke(new MakeVisibleHandler(MakeVisible), p);
                else
                    button6.Invoke(new MakeVisibleHandler(MakeInVisible), p);
                //this.button6.Visible=b;


            }
            catch { return; }
        }
        /// <summary>
        /// hide or show fold button
        /// </summary>
        /// <param name="b"></param>
        public void SetVisibilityFold(bool b)
        {
            try
            {
                object[] p = new object[1];

                p[0] = button7;
                if (b)
                    button7.Invoke(new MakeVisibleHandler(MakeVisible), p);
                else
                    button7.Invoke(new MakeVisibleHandler(MakeInVisible), p);
                //	this.button7.Visible=b;
            }
            catch { return; }
        }
        /// <summary>
        /// hide or show raise button
        /// </summary>
        public void SetVisibilityRaise(bool b)
        {
            try
            {
                object[] p = new object[1];
                if (b)
                {

                    p[0] = button5;
                    button5.Invoke(new MakeVisibleHandler(MakeVisible), p);
                    //this.button5.Visible=b;

                    p[0] = textBox1;
                    textBox1.Invoke(new MakeVisibleHandler(MakeVisible), p);

                    if (this.dispatcher.GameData.Type == 1)
                    {
                        p[0] = this.buttonTripleRaise;
                        buttonTripleRaise.Invoke(new MakeVisibleHandler(MakeVisible), p);
                    }
                    if (this.dispatcher.GameData.Type == 1)
                    {
                        p[0] = this.buttonBetPot;
                        buttonBetPot.Invoke(new MakeVisibleHandler(MakeVisible), p);
                    }
                    p[0] = label4;
                    label4.Invoke(new MakeVisibleHandler(MakeVisible), p);

                    p[0] = textBox1;
                    textBox1.Invoke(new MakeVisibleHandler(SetTextBox1), p);
                    p[0] = this.trackBar1;
                    this.trackBar1.Invoke(new MakeVisibleHandler(MakeVisible), p);
                
                    if(!this.richTextBox2.Focused)
                    this.textBox1.Focus();


                }
                else
                {



                    p[0] = button5;
                    button5.Invoke(new MakeVisibleHandler(MakeInVisible), p);
                    //this.button5.Visible=b;

                    p[0] = textBox1;
                    textBox1.Invoke(new MakeVisibleHandler(MakeInVisible), p);
                    //this.textBox1.Visible=b;

                    p[0] = this.buttonTripleRaise;
                    buttonTripleRaise.Invoke(new MakeVisibleHandler(MakeInVisible), p);
                    p[0] = this.buttonBetPot;
                    buttonBetPot.Invoke(new MakeVisibleHandler(MakeInVisible), p);
                    p[0] = label4;
                    label4.Invoke(new MakeVisibleHandler(MakeInVisible), p);
                
                    //this.label4.Visible=b;
                    p[0] = this.trackBar1;
                    this.trackBar1.Invoke(new MakeVisibleHandler(MakeInVisible), p);





                }
            }
            catch { return; }

        }

        public void UnCheckMe(Control c)
        {

            ((CheckBox)c).Checked = false;

            
        
        }

        public void CheckMe(Control c)
        {

           

             ((CheckBox)c).Checked = true;

        }
        public bool IsAutoFold()
        {

            return this.checkBoxAutoFold.Checked;
        }

        public bool IsAutoCall()
        {

            return this.checkBoxCheck.Checked;
        }
        /// <summary>
        /// show minimal raise
        /// </summary>
        /// <param name="control"></param>
        public void SetTextBox1(Control control)
        {

            control.Text = this.dispatcher.GameData.Min.ToString();

        }
        /// <summary>
        /// hide raise call all in 
        /// </summary>
        public void HideChoice()
        {

            SetVisibilityFold(false);
            SetVisibilityCall(false);
            SetVisibilityAllin(false);
            SetVisibilityRaise(false);


        }
        /// <summary>
        /// let's init the chrono to client
        /// </summary>
        public void SendInitChronoToClient()
        {
            this.dispatcher.Communication.SendBroadCast("{chronoinit");

        }

        /// <summary>
        /// send game information to party
        /// </summary>
        public void SendGameData()
        {

            string msg = "{gamedata ";
            msg += this.dispatcher.GameData.Ante + " ";
            msg += this.dispatcher.GameData.SmallBlind + " ";
            msg += this.dispatcher.GameData.BigBlind + " ";
            msg += this.dispatcher.GameData.Type + " ";

            msg += this.dispatcher.GameData.Max + " ";
            msg += this.dispatcher.GameData.Nbr + " ";
            msg += this.dispatcher.GameData.Money + " ";
            msg += this.dispatcher.GameData.Min + " ";
            msg += this.dispatcher.GameData.Time2Mind + " ";
            msg += this.dispatcher.GameData.TimeIncrease;

            this.dispatcher.Communication.SendBroadCast(msg);

        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            if (!launch)
            {
                if (this.dispatcher.Profil != null)
                {

                    launch = true;
                    this.dispatcher.Communication.WaitForOtherPlayers(false);

                    if (this.launchServ)
                        Dispatcher.GameData.AggrMode.AggressiveModeBool = false;

                    SendGameData();

                    Start();
                }
                else MessageBox.Show(this, Language.GetPleaseLoadEvents());
            }
            else MessageBox.Show(this, Language.GetAnotherGameEvents());
        }
        private string txt_swap;
        private delegate void DelegateAddtext(Control c);
        private void AddTextInvoke(Control c)
        {

            c.Text = txt_swap;

        }
        /// <summary>
        /// show pot value
        /// </summary>
        /// <param name="s"></param>
        public void Setlabel2(string s)
        {
            txt_swap = s;

            object[] p = new object[1];

            txt_swap = s+"$";
            p[0] = label2;
            try
            {
                label2.Invoke(new DelegateAddtext(AddTextInvoke), p);
            }
            catch { }



        }
        /// <summary>
        /// value for calling
        /// </summary>
        /// <param name="s"></param>
        public void Setlabel3(string s)
        {

            txt_swap = s;

            object[] p = new object[1];

            txt_swap = s;
            p[0] = label3;
            try
            {
                label3.Invoke(new DelegateAddtext(AddTextInvoke), p);
            }
            catch { }

        }

        public void SetText(string txt, Control c)
        {
            txt_swap = txt;

            object[] p = new object[1];

            txt_swap = txt;
            p[0] = c;
            try
            {
                c.Invoke(new DelegateAddtext(AddTextInvoke), p);
            }
            catch { }

        }

        public ListBox ListBox1
        {
            get { return this.listBox1; }
            set { this.listBox1 = value; }
        }
        /// <summary>
        /// show the hidden picture
        /// </summary>
        public void Connerie()
        {
            this.dispatcher.Game.MakeVisible(this.pictureBox17);
            Thread.Sleep(10000);
            this.dispatcher.Game.MakeInVisible(this.pictureBox17);
        }




        private void menuItem3_Click(object sender, System.EventArgs e)
        {

            System.Windows.Forms.DialogResult dlg;
            if (launchServ)
            {
                dlg = MessageBox.Show(this, Language.GetServerAlreayEvents(), Language.GetResetEvents(), System.Windows.Forms.MessageBoxButtons.YesNo);
                switch (dlg)
                {
                    case System.Windows.Forms.DialogResult.No: return;
                    default: break;

                }

            }

            //destroy old
            dispatcher.Communication.MySockets = new Socket[dispatcher.GameData.Nbr];
            Server serv = new Server(this);
            serv.Show();

        }




        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                loopingBlink = false;
                this.makeItBlink = false;
                try
                {
                    if (this.blinkingThread != null)
                        this.blinkingThread.Abort();
                }
                catch{}
                this.notifyIcon1.Visible = false;
                this.GameEvents.AddDia(Language.GetConnectionLostEvents() + "\n");
               
                try
                {
                    if (this.dispatcher.Game.Gameplaying != null)
                    {

                        this.dispatcher.Game.Gameplaying.Abort();
                    }
                }
                catch { }
                try
                {
                    this.Player.OwnChrono.EndOfgame = true;
                    this.chronoCtr1.ChronoTimer.EndOfgame = true;

                    for (int i = 0; i < 10; i++)
                    {

                        this.Dispatcher.Game.GetPlayer(i).OwnChrono.EndOfgame = true;
                    
                    }
                }
                catch { }
                try
                {

                    this.dispatcher.Communication.SendToServer("{exit " + this.Player.Id);
                }
                catch { }
                this.Stop = true;
                if (this.dispatcher.Communication.Th != null)
                    this.dispatcher.Communication.Th.Abort();
                if (this.dispatcher.Communication.Threadconnect() != null)
                {
                    this.dispatcher.Communication.SockEc().Stop();
                    this.dispatcher.Communication.Threadconnect().Abort();

                }
                for (int k = 0; k < this.nbr_socket; k++)
                {
                    if (dispatcher.Communication.MySockets != null && dispatcher.Communication.GetSocket(k) != null)
                        dispatcher.Communication.GetSocket(k).Close();
                }
                if (dispatcher.Communication != null)
                    dispatcher.Communication.Stop();
            }
            catch { }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            chat.AddText();
        }

        public void SetMyName(string name)
        {
            dispatcher.GameData.Name = name;
        }

        public string GetMyName()
        {
            return dispatcher.GameData.Name;
        }
        public void SetGroupeBox2(string newn)
        {

            this.Player0.Text = newn;
        }

        private void menuItem4_Click(object sender, System.EventArgs e)
        {
            if (this.dispatcher.GameData.AggrMode.AggressiveModeBool && this.launch)
            {
                MessageBox.Show(this, Language.GetCannotEditEvents());
                return;
            }
            PropertiesGame prop = new PropertiesGame(dispatcher, launch);
            prop.Show();
        }

        private void menuItem5_Click(object sender, System.EventArgs e)
        {
            Infos info = new Infos();
            info.Show();
        }
        public Chat Chat
        {
            get { return chat; }
            set { chat = value; }
        }
        public GameEvents GameEvents
        {
            get { return gameEvents; }
            set { gameEvents = value; }

        }
        public Dispatcher Dispatcher
        {
            get { return dispatcher; }
            set { dispatcher = value; }

        }


        private void textBox1_TextChanged_1(object sender, System.EventArgs e)
        {

        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
        /// <summary>
        /// fold
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button7_Click(object sender, System.EventArgs e)
        {
            this.button7.BackgroundImage = poker.Properties.Resources.buttonB_down;
            Thread th = new Thread(new ThreadStart(FoldPostClick));
           // th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void FoldPostClick()
        {
            pl.Fold();
            if (dispatcher.Communication.IsConnected())
            {
                this.dispatcher.Game.GetPlayer(this.dispatcher.Game.CurrentPlayer).OwnChrono.HavePlayed = false;
                this.dispatcher.Form.MakeItBlink = false;
                this.ReinitGroupBox();
               
                return;

            }
            pl.Next();
        }
        /// <summary>
        /// call or check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button6_Click(object sender, System.EventArgs e)
        {
            this.button6.BackgroundImage = poker.Properties.Resources.buttonB_down;
            Thread th = new Thread(new ThreadStart(CallorCheck));
           // th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void CallorCheck()
        {
            if (pl.OwnPot.Money < dispatcher.Game.CurrentRaise.Money)
                pl.Call();
            else
                pl.Check();
            if (dispatcher.Communication.IsConnected())
            {
                this.dispatcher.Game.Player.OwnChrono.HavePlayed = false;
                this.dispatcher.Form.MakeItBlink = false;
                return;

            }
            pl.Next();
        }


        public void MakeItClikALlin()
        {

            button4_Click(null, null);
        }
        /// <summary>
        /// all in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, System.EventArgs e)
        {
            this.button4.BackgroundImage = poker.Properties.Resources.buttonB_down;
            Thread th = new Thread(new ThreadStart(AllInPostClick));
            //th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void AllInPostClick()
        {
            pl.Allin();
            if (dispatcher.Communication.IsConnected())
            {
                this.dispatcher.Game.Player.OwnChrono.HavePlayed = false;
                this.dispatcher.Form.MakeItBlink = false;
                return;

            }
            pl.Next();
        }
        //bet raise
        private void button5_Click(object sender, System.EventArgs e)
        {
            this.button5.BackgroundImage = poker.Properties.Resources.buttonB_down;
            Thread th = new Thread(new ThreadStart(BetRaisePostClick));
          //  th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void BetRaisePostClick()
        {
            long mise = 0;
            if (dispatcher.GameData.Type == 3)
                switch (dispatcher.Game.CurrentTurn)
                {
                    case 0:
                    case 1: mise = dispatcher.GameData.Min; break;
                    case 2:
                    case 3: mise = dispatcher.GameData.Max; break;
                }
            else
            {
                //tester si c légitime
                try
                {
                    mise = (long)Convert.ToInt32(this.textBox1.Text);
                }
                catch
                {
                    MessageBox.Show(null, Language.GetDoNotDoTHatEvents(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mise = 0;

                }
            }
            pl.BetRaise(mise);
            //changed
            dispatcher.Game.ActualizeMinMax(this.dispatcher.Game.CurrentPlayer);
            if (dispatcher.Communication.IsConnected())
            {
                this.dispatcher.Game.Player.OwnChrono.HavePlayed = false;
                MakeItBlink = false;
			
                return;

            }
            pl.Next();
        }
        private int min_swap;
        private int max_swap;

        /// <summary>
        /// apply min and max to the trackball
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void ChangeScroll(long min, long max)
        {
            try
            {
                min_swap = (int)min;
                max_swap = (int)max;
                object[] p = new object[1];
                p[0] = this.trackBar1;
                this.trackBar1.Invoke(new DelegateAddtext(ChangeScrollInvoke), p);
            }
            catch { }

        }
        private void ChangeScrollInvoke(Control c)
        {

            ((TrackBar)c).Maximum = max_swap;

            ((TrackBar)c).Minimum = min_swap;


        }

        public void ChangeScrollValue(int val)
        {

            value_swap = val;
            object[] p = new object[1];
            p[0] = this.trackBar1;
            this.trackBar1.Invoke(new DelegateAddtext(ChangeScrollValue), p);

        }
        private int value_swap;
        public int Value_swap
        {


            set { this.value_swap = value; }
        }
        private void ChangeScrollValue(Control c)
        {
            if (((TrackBar)c).Maximum < this.value_swap)
                this.value_swap = ((TrackBar)c).Maximum;

            ((TrackBar)c).Value = value_swap;




        }
        private void trackBar1_Scroll(object sender, System.EventArgs e)
        {
            this.dispatcher.Game.Addtext(this.textBox1, this.trackBar1.Value.ToString());

        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (Char.IsControl(c) == false)
                if (Char.IsDigit(c) == false)
                    e.Handled = true;
        }

        public string Card1
        {
            get { return card1; }
            set { card1 = value; }

        }
        public string Card2
        {
            get { return card2; }
            set { card2 = value; }

        }
        public string Card3
        {
            get { return card3; }
            set { card3 = value; }

        }
        public string Card4
        {
            get { return card4; }
            set { card4 = value; }

        }
        public string Card5
        {
            get { return card5; }
            set { card5 = value; }

        }
        public string Card6
        {
            get { return card6; }
            set { card6 = value; }

        }
        public string Card7
        {
            get { return card7; }
            set { card7 = value; }

        }
        public MiniInfo MiniInfo
        {
            get { return miniInfo; }
            set { miniInfo = value; }

        }
        public Player Player
        {
            get { return pl; }

        }
        public bool Launch
        {
            
            set
            {
                try
                {
                    launch = value;
                    if (launch == false)
                        chronoCtr1.Invoke(new MakeVisibleHandler(this.MakeInVisible), new object[] { this.chronoCtr1 });
                }
                catch { }
            }
            get { return launch; }

        }
        public bool LaunchServ
        {
            set { launchServ = value; }
            get { return launchServ; }

        }
        private Chat chat;
        private GameEvents gameEvents;
        private Dispatcher dispatcher;
        private string[] namesOfChatterBeforeGame;
        private string[] namesOfChatter = null;
        private int nbr_socket = 0;
        private bool valid;
        private MiniInfo miniInfo;
        private string card1;
        private string card2;
        private string card3;
        private string card4;
        private string card5;
        private string card6;
        private string card7;
        private Player pl;
        public ShowHand showHand;
        private bool launch = false;
        private bool launchServ = false;

        private void menuItem6_Click(object sender, System.EventArgs e)
        {

            Connexion con = new Connexion(this.dispatcher);
            con.Show();
        }

        private void menuItem8_Click(object sender, System.EventArgs e)
        {

        }

        private void menuItem10_Click(object sender, System.EventArgs e)
        {
            //create a new profil for local player 
            Edit edit = new Edit("Create");
            edit.Show();
        }

        private void menuItem13_Click(object sender, System.EventArgs e)
        {
            if (this.dispatcher.Game == null) return;
            //Stats n=new Stats(this.dispatcher.Game);
            if (stats != null)
            {
                
            }
            else {
                Stats n = new Stats(this.dispatcher.Game);
            
            }
            stats.Show();
            stats.RefreshMe();
            

        }
        //odds
        private void menuItem14_Click(object sender, System.EventArgs e)
        {
            if (this.dispatcher.Game == null) return;
            if (odds != null)
            {
                MessageBox.Show(this, Language.GetCloseOtherWEvents());
                return;
            }
            odds = new Odds(this.dispatcher.Game.Player, this.dispatcher.Game, this);


            odds.Show();
            odds.Location = new Point(10, 10);
            odds.Visible = true;
        }

        private Odds odds;
        public Odds Odds
        {
            get { return odds; }
            set { odds = value; }
        }

        public Stats Stats
        {
            get { return stats; }
            set { stats = value; }
        }


        private void menuItem12_Click(object sender, System.EventArgs e)
        {
            Edit edit = new Edit("");
            edit.Show();
        }


        public void DisposeAvatar()
        {
            if (this.pictureBox52.Image != null)

                this.pictureBox52.Image.Dispose();

        }
        /// <summary>
        /// show private avatar
        /// </summary>
        public void ShowPicture()
        {
            if (this.dispatcher.Profil.Avatar != "")
            {
                try
                {
                    this.pictureBox52.Image = new Bitmap(this.dispatcher.Profil.Avatar);

                    this.dispatcher.Form.MakeVisibleInvoke(this.pictureBox52, true);
                }
                catch { }
            }
        }
        private void menuItem9_Click(object sender, System.EventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void groupBox12_Enter(object sender, System.EventArgs e)
        {

        }
        /// <summary>
        /// to do  recode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_SizeChanged(object sender, System.EventArgs e)
        {
            //int x = this.Size.Width;
            //this.groupBox12.Size = new System.Drawing.Size(this.groupBox1.Location.X - this.groupBox12.Location.X, 160);
            //this.groupBox4.Location = new System.Drawing.Point(this.groupBox1.Location.X + this.groupBox1.Size.Width, this.groupBox4.Location.Y);
            //this.groupBox4.Size = new System.Drawing.Size(this.Size.Width - this.groupBox12.Width - this.groupBox1.Size.Width, 160);
            //float a = (float)this.Size.Width * (float)0.284;
            //float b = (float)this.Size.Height * (float)0.31;
            //this.pictureBox3.Location = new Point((int)a, (int)b);
            //this.pictureBox4.Location = new Point((int)a + 100, (int)b);
            //this.pictureBox5.Location = new Point((int)a + 200, (int)b);
            //this.pictureBox6.Location = new Point((int)a + 300, (int)b);
            //this.pictureBox7.Location = new Point((int)a + 400, (int)b);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private bool stop = false;
        public bool Stop
        {
            get { return stop; }
            set { stop = true; }
        }
        private void UpdateInvoke(Control c)
        {


            c.Update();
        }
        public void UpdateInvoke()
        {
            try
            {
                object[] p = new object[1];


                p[0] = this;
                this.Invoke(new DelegateAddtext(UpdateInvoke), p);
            }
            catch { }


        }

        private void menuItem9_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(this, Language.GetAlreadyBoredEvents(), Language.GetQuestionEvents(), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                this.Close();

        }

        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.richTextBox2.Text == "" || this.richTextBox2.Text == "\\n")
                    return;
                e.Handled = true;

                this.button2_Click(sender, e);
            }
        }

        private void menuItem16_Click(object sender, EventArgs e)
        {
            this.menuItem16.Checked = !this.menuItem16.Checked;
            this.allowspeaker = this.menuItem16.Checked;
            if (this.allowspeaker)
                dispatcher.Speaker = new AutoSpeech();
            else
                dispatcher.Speaker = null;
        }
        /// <summary>
        /// triple raise
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTripleRaise_Click(object sender, EventArgs e)
        {
            buttonTripleRaise.BackgroundImage = poker.Properties.Resources.buttonB_down;
            Thread th = new Thread(new ThreadStart(TripleRaisePostFlop));
            //th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void TripleRaisePostFlop()
        {
            //to do etude    argent à ce tour *3
            long total;
            if (this.dispatcher.Game.CurrentRaise.Money == 0)
                total = dispatcher.GameData.BigBlind * 3;
            else
                total = this.dispatcher.Game.CurrentRaise.Money * 3;

            long mise = 0;
            if (dispatcher.GameData.Type == 3)
                switch (dispatcher.Game.CurrentTurn)
                {
                    case 0:
                    case 1: mise = dispatcher.GameData.Min; break;
                    case 2:
                    case 3: mise = dispatcher.GameData.Max; break;
                }
            else
            {
                //tester si c légitime
                try
                {

                    mise = total - (this.dispatcher.Game.CurrentRaise.Money - this.dispatcher.Game.GetPlayer(this.dispatcher.Game.CurrentPlayer).OwnPot.Money);

                    if (mise < 0)
                        throw new Exception("mise neg");
                }
                catch
                {
                    MessageBox.Show(this, Language.GetDoNotDoTHatEvents(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mise = 0;

                }
            }
            pl.BetRaise(mise);
            //changed
            dispatcher.Game.ActualizeMinMax(this.dispatcher.Game.CurrentPlayer);
            if (dispatcher.Communication.IsConnected())
            {
                this.dispatcher.Game.Player.OwnChrono.HavePlayed = false;
                this.dispatcher.Form.MakeItBlink = false;
                return;

            }
            pl.Next();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {




        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {

                    case Keys.ShiftKey | Keys.LButton | Keys.Control:
                        if (!this.richTextBox2.Focused && !this.richTextBox4.Focused && !this.richTextBox1.Focused)
                        {
                            if (this.button7.Visible || this.button2.Focused)
                            {

                                buttonTripleRaise_Click(new object(), new EventArgs());

                            };
                        } break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //empeche d'appuyer deux fois
        private bool blockCheck = false;
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.richTextBox2.Focused || this.button2.Focused)
                return;

            if (this.button7.Visible && !blockCheck)
            {
                blockCheck = true;
                char c = e.KeyChar;
                if (Char.IsWhiteSpace(c))
                {

                    button6_Click(sender, e);

                    e.Handled = true;

                }

                if (c == 97) //a
                {
                    if (button4.Visible)
                    {
                        button4_Click(sender, e);

                        e.Handled = true;
                    }

                }
                if (c == 99) //check call
                {
                    if (button6.Visible)
                    {
                        button6_Click(sender, e);

                        e.Handled = true;
                    }

                }
                if (c == 102)//fold
                {
                    if (button7.Visible)
                    {
                        button7_Click(sender, e);

                        e.Handled = true;
                    }

                }
                if (c == 114)//raise bet   R
                {
                    if (button5.Visible)
                    {
                        button5_Click(sender, e);

                        e.Handled = true;
                    }

                }
                if (c == 107)//triple raise    R
                {
                    if (this.buttonTripleRaise.Visible)
                    {
                        this.buttonTripleRaise_Click(sender, e);

                        e.Handled = true;
                    }

                }
            }
            blockCheck = false;

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            return;
        }
        //ouverture du menu avec les perfs liées au profil
        private void menuItem17_Click(object sender, EventArgs e)
        {

            Edit ed = new Edit("", this.dispatcher.Profil, this);
            if (this.dispatcher.Profil != null)
                ed.Show();

        }


        private void admin1_Load(object sender, EventArgs e)
        {

        }

        private void menuItem19_Click(object sender, EventArgs e)
        {

            this.menuItem19.Checked = !this.menuItem19.Checked;
            this.Media.AllowVoices = this.menuItem19.Checked;
        }

        private void menuItem19_Select(object sender, EventArgs e)
        {



        }

        private void menuItem11_Click(object sender, EventArgs e)
        {

        }


        public void Translation()
        {
            //button translation
            Control[] p = new Control[1];

            txt_swap = Language.GetTripleRaiseButton();
            p[0] = (Button)this.buttonTripleRaise;
            try { p[0].Invoke(new DelegateAddtext(AddTextInvoke), p); }
            catch { }


            txt_swap = Language.GetAllInButton();
            p[0] = (Button)this.button4;
            try { p[0].Invoke(new DelegateAddtext(AddTextInvoke), p); }
            catch { }

            txt_swap = Language.GetFoldButton();
            p[0] = (Button)this.button7;
            try { p[0].Invoke(new DelegateAddtext(AddTextInvoke), p); }
            catch { }

            txt_swap = Language.GetCallButton();
            p[0] = this.button6;
            try { p[0].Invoke(new DelegateAddtext(AddTextInvoke), p); }
            catch { }

            txt_swap = Language.GetSendButton();
            p[0] = (Button)this.button2;
            try { p[0].Invoke(new DelegateAddtext(AddTextInvoke), p); }
            catch { }

            txt_swap = Language.GetRaiseButton();
            p[0] = this.button5;
            try { p[0].Invoke(new DelegateAddtext(AddTextInvoke), p); }
            catch { }

            //groupBox translation
            txt_swap = Language.GetValueForCallingTitle();
            p[0] = this.groupBox11;
            try { p[0].Invoke(new DelegateAddtext(AddTextInvoke), p); }
            catch { }

            txt_swap = Language.GetYourChoiceTitle();
            p[0] = this.groupBox1;
            try { p[0].Invoke(new DelegateAddtext(AddTextInvoke), p); }
            catch { }

            txt_swap = Language.GetGameEventsTitle();
            p[0] = this.groupBox12;
            try { p[0].Invoke(new DelegateAddtext(AddTextInvoke), p); }
            catch { }

            txt_swap = Language.GetChatTitle();
            p[0] = this.groupBox4;
            try { p[0].Invoke(new DelegateAddtext(AddTextInvoke), p); }
            catch { }
            TranslationMenu();
            if(this.admin1!=null)
            this.admin1.TranslationAdmin();
        }

        private void TranslationMenu()
        {

            //menu item translation

            this.menuItem1.Text = Language.GetNewGameMenu();
            this.menuItem2.Text = Language.GetNetOrLanGameMenu();
            this.menuItem24.Text = Language.GetLastHandEvents();
            this.menuItem3.Text = Language.GetCreateServerMenu();
            this.menuItem6.Text = Language.GetConnectServerMenu();
            this.menuItem7.Text = Language.GetProfilMenu();
            this.menuItem8.Text = Language.GetNewProfilMenu();
            this.menuItem12.Text = Language.GetEditProfilMenu();
            this.menuItem10.Text = Language.GetLocalPlayerMenu();
            this.menuItem11.Text = Language.GetVirtualPlayerMenu();
            this.menuItem4.Text = Language.GetPropertiesMenu();
            this.menuItem13.Text = Language.GetStatsMenu();
            this.menuItem14.Text = Language.GetOddsMenu();
            this.menuItem15.Text = Language.GetSoundOptionMenu();
            this.menuItem16.Text = Language.GetSpeakerMenu();
            this.menuItem19.Text = Language.GetVoicesMenu();
            this.menuItem17.Text = Language.GetOwnDataMenu();
            this.menuItem20.Text = Language.GetLanguageMenu();
            this.menuItem9.Text = Language.GetExitMenu();
            this.menuItem25.Text = Language.GetSpeedMenu();
            this.menuItem26.Text = Language.GetFastestMenu();
            this.menuItem27.Text = Language.GetMediumMenu();
            this.menuItem28.Text = Language.GetSlowestMenu();
            this.menuItem5.Text = Language.GetAboutMenu();




        }
        //english selection
        private void menuItem21_Click(object sender, EventArgs e)
        {
            Language.CurrentLanguage = Language.ENG1;
            Translation();
        }
        //french
        private void menuItem22_Click(object sender, EventArgs e)
        {
            Language.CurrentLanguage = Language.FR1;
            Translation();
        }
        //german
        private void menuItem23_Click(object sender, EventArgs e)
        {
            Language.CurrentLanguage = Language.DE1;
            Translation();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void menuItem24_Click(object sender, EventArgs e)
        {

        }

        private void menuItem24_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.dispatcher.Game == null)
                    return;

                this.dispatcher.Form.HideChildWindows();
                DialogResult res = MessageBox.Show(Language.GetLastHandBox(), "", MessageBoxButtons.YesNo);

                if (res == DialogResult.Yes)
                {
                    this.dispatcher.Game.Stopgame = true;
                    this.menuItem24.Enabled = false;
                    this.dispatcher.Form.gameEvents.AddDia(Language.GetLastHandEvents() + "\n");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void HideChildWindows()
        {
            try
            {
                if (this.Odds != null)
                {
                    this.Odds.Invoke(new DelegateAddtext(MakeInVisible), new object[] { this.Odds });

                }
                if (this.Stats != null)
                    this.Stats.Invoke(new DelegateAddtext(MakeInVisible), new object[] { this.Stats });
            }
            catch { }
               
        }

        /// <summary>
        ///  bet/raise pot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBetPot_Click(object sender, EventArgs e)
        {
            this.buttonBetPot.BackgroundImage = poker.Properties.Resources.buttonB_down;
            Thread th = new Thread(new ThreadStart(BetPotPostClick));
           //th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void BetPotPostClick()
        {
            long total;

            long mise = this.dispatcher.Game.Pot.Money - (this.dispatcher.Game.CurrentRaise.Money);


            if (dispatcher.GameData.Type == 3)
                switch (dispatcher.Game.CurrentTurn)
                {
                    case 0:
                    case 1: mise = dispatcher.GameData.Min; break;
                    case 2:
                    case 3: mise = dispatcher.GameData.Max; break;
                }
            else
            {
                //tester si c légitime
                //try
                //{

                //    mise = total - (this.dispatcher.Game.CurrentRaise.Money - this.dispatcher.Game.GetPlayer(this.dispatcher.Game.CurrentPlayer).OwnPot.Money);

                //    if (mise < 0)
                //        throw new Exception("mise neg");
                //}
                //catch
                //{
                //    MessageBox.Show(this, Language.GetDoNotDoTHatEvents(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    mise = 0;

                //}
            }
            pl.BetRaise(mise);
            //changed
            dispatcher.Game.ActualizeMinMax(this.dispatcher.Game.CurrentPlayer);
            if (dispatcher.Communication.IsConnected())
            {
                this.dispatcher.Game.Player.OwnChrono.HavePlayed = false;
                this.dispatcher.Form.MakeItBlink = false;
                return;

            }
            pl.Next();
        }


        public bool IsFastGame()
        {
            return this.menuItem26.Checked;

        }
        public bool IsMediumGame()
        {
            return this.menuItem27.Checked;

        }
        public bool IsLowGame()
        {
            return this.menuItem28.Checked;

        }
        private void menuItem26_Click(object sender, EventArgs e)
        {

            this.menuItem26.Checked = !this.menuItem26.Checked;


            if (this.menuItem26.Checked)
            {

                this.menuItem28.Checked = false;
                this.menuItem27.Checked = false;

                if (this.dispatcher.Game != null)
                    this.dispatcher.Game.GameSpeed = 0;
            }
        }

        private void menuItem27_Click(object sender, EventArgs e)
        {
            this.menuItem27.Checked = !this.menuItem27.Checked;


            if (this.menuItem27.Checked)
            {
                this.menuItem28.Checked = false;
                this.menuItem26.Checked = false;
                if (this.dispatcher.Game != null)
                    this.dispatcher.Game.GameSpeed = 2;
            }
        }

        private void menuItem28_Click(object sender, EventArgs e)
        {
            this.menuItem28.Checked = !this.menuItem28.Checked;


            if (this.menuItem28.Checked)
            {
                this.menuItem27.Checked = false;
                this.menuItem26.Checked = false;
                if (this.dispatcher.Game != null)

                    this.dispatcher.Game.GameSpeed = 5;

            }
        }

       

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            this.button5.BackgroundImage = poker.Properties.Resources.buttonB_over;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            this.button5.BackgroundImage = poker.Properties.Resources.buttonB_up;
        }

        private void buttonTripleRaise_MouseEnter(object sender, EventArgs e)
        {
            this.buttonTripleRaise.BackgroundImage = poker.Properties.Resources.buttonB_over;
       
        }

        private void buttonTripleRaise_MouseLeave(object sender, EventArgs e)
        {
            this.buttonTripleRaise.BackgroundImage = poker.Properties.Resources.buttonB_up;
        
        }

        private void buttonBetPot_MouseEnter(object sender, EventArgs e)
        {
            this.buttonBetPot.BackgroundImage = poker.Properties.Resources.buttonB_over;
        }

        private void buttonBetPot_MouseLeave(object sender, EventArgs e)
        {
            this.buttonBetPot.BackgroundImage = poker.Properties.Resources.buttonB_up;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            this.button7.BackgroundImage = poker.Properties.Resources.buttonB_over;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            this.button7.BackgroundImage = poker.Properties.Resources.buttonB_up;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            this.button6.BackgroundImage = poker.Properties.Resources.buttonB_over;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            this.button6.BackgroundImage = poker.Properties.Resources.buttonB_up;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            this.button4.BackgroundImage = poker.Properties.Resources.buttonB_over;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.button4.BackgroundImage = poker.Properties.Resources.buttonB_up;
        }

        private void menuItem18_Click(object sender, EventArgs e)
        {
          
        }

        //select OFF
        private void menuItem30_Click(object sender, EventArgs e)
        {
            if (this.dispatcher != null && this.dispatcher.Game != null)
            {
                if (this.Launch && ((this.dispatcher.Communication == null || this.dispatcher.Communication.MySockets == null) || this.dispatcher.Communication.MySockets.Length == 0))
                {
                    this.menuItem30.Checked = !this.menuItem30.Checked;
                    this.menuItem29.Checked = !this.menuItem30.Checked;

                    this.dispatcher.Game.GamePause = this.menuItem29.Checked;
                    if (this.dispatcher.Game.GamePause)
                    {
                        GameEvents.AddDia("Game will be paused to next player\n");
                    }
                }
            }
            else{

                this.menuItem29.Checked = false;
                this.menuItem30.Checked = true;
            
            }
        }
        //select ON
        private void menuItem29_Click(object sender, EventArgs e)
        {
            if (this.dispatcher != null && this.dispatcher.Game != null)
            {
                if (this.Launch && ((this.dispatcher.Communication == null || this.dispatcher.Communication.MySockets ==null  )||this.dispatcher.Communication.MySockets.Length == 0))
                {
                    this.menuItem29.Checked = !this.menuItem29.Checked;
                    this.menuItem30.Checked = !this.menuItem29.Checked;
                    this.dispatcher.Game.GamePause = this.menuItem29.Checked;
                    if (this.dispatcher.Game.GamePause)
                    {
                        GameEvents.AddDia("Game will be paused to next player\n");
                    }
                }

            }
            else
            {

                this.menuItem29.Checked = false;
                this.menuItem30.Checked = true;

            }
        }
        public void LaunchBlinkMode()
        {
            try
            {

                if (blinkingThread != null && blinkingThread.IsAlive)
                {
                    blinkingThread.Abort();
                    Thread.Sleep(1000);
                }

                blinkingThread = new Thread(new ThreadStart(MakeBlinkingGroupBoxLoop));
                blinkingThread.Name = "Blink";
                blinkingThread.Priority = ThreadPriority.Lowest;
                blinkingThread.Start();
            }
            catch { }
        
        
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            DynamicDisplay.CURRENT_SIZE_X = pictureBox8.Size.Width;
            DynamicDisplay.CURRENT_SIZE_Y = pictureBox8.Size.Height;
            DynamicDisplay.mainW = this;
            DynamicDisplay display = new DynamicDisplay(this);
            display.ChangeDisplayTable();
            display.ChangeDisplayCards();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
           
        }
        private bool loopingBlink=true;

/// <summary>
/// Fait clignoter le groupBox du joueur en cours
/// </summary>
        public void MakeBlinkingGroupBoxLoop()
        {
            try{
            
              
                int id ;
               
                bool first = true;
                while (loopingBlink)
                {
                    if (this.dispatcher.Game == null || this.Launch == false)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    id = this.dispatcher.Game.CurrentPlayer;
                   if(makeItBlink)
                   {
                      
                        try
                        {
                            this.Invoke(new DelegateAddtext(MakeBlinkingGroupBoxInvoke), new object[] { WhatIsMyGroupBox(id) });
                        }
                        catch { return; }

                      //  Application.DoEvents();

                        if (!first)
                            Thread.Sleep(1000);

                        first = false;
                    }else{
                        this.Invoke(new DelegateAddtext(MakeBlinkingSpeGroupBoxInvoke), new object[] { WhatIsMyGroupBox(id) });
               
                       Thread.Sleep(1000);
                   }

                }
               
                //Application.DoEvents();
            }
            catch { }
        
        }
        public void MakeBlinkingSpeGroupBoxInvoke(Control c)
        {
            ((GroupBox)c).ForeColor = Color.White;
        }
        Thread blinkingThread;
        public void MakeBlinkingGroupBox()
        {
            makeItBlink = false;

            if(!this.dispatcher.Communication.IsConnected())
            this.dispatcher.Communication.SendBroadCast("{currentp " + this.dispatcher.Game.CurrentPlayer);
            //everyBody In White
        ReinitGroupBox();
        makeItBlink = true;

           
        
        }

        private int blinkPlayer = 0;
        public void MakeBlinkingGroupBoxInvoke(Control c)
        {
          

            GroupBox gB = (GroupBox)c;
            if (!makeItBlink)
                gB.ForeColor = Color.White;
            else
            {
                if (gB.ForeColor == Color.White)
                    gB.ForeColor = Color.Red;
                else
                {
                    gB.ForeColor = Color.White;

                }
            }
               

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">player</param>
        /// <returns> groupbox of player a</returns>
        private GroupBox WhatIsMyGroupBox(int current_player)
        {
            GroupBox gB;
            switch (current_player)
            {
                case 0: gB = this.Player0; break;
                case 1: gB = this.groupBox2; break;
                case 2: gB = this.groupBox15; break;
                case 3: gB = this.groupBox18; break;
                case 4: gB = this.groupBox21; break;
                case 5: gB = this.groupBox24; break;
                case 6: gB = this.groupBox27; break;
                case 7: gB = this.groupBox30; break;
                case 8: gB = this.groupBox33; break;
                default: gB = this.groupBox36; break;


            }
            return gB;
        }

        private bool makeItBlink = true;

        public bool MakeItBlink
        {
            get { return makeItBlink; }
            set { makeItBlink = value; }
        }


        /// <summary>
        /// display all groupBox into White
        /// </summary>
        public void ReinitGroupBox()
        {
            try
            {
                this.makeItBlink = false;
                WhatIsMyGroupBox(0).Invoke(new DelegateAddtext(ReinitGroupBoxInvoke), new object[] { WhatIsMyGroupBox(0) });
                return;
            }
            catch { }
          

        }

        /// <summary>
        /// non used
        /// </summary>
        /// <param name="c"></param>
        public void ReinitGroupBoxInvoke(Control c)
        {
           for(int i=0;i<10;i++)
           {
               GroupBox gB = WhatIsMyGroupBox(i);
              
                gB.ForeColor = Color.White;

            }
           
            this.Update();
        }

        internal void UnCheckRadio()
        {
            if (this.dispatcher.Game.GetPlayer(this.dispatcher.Game.CurrentPlayer).GetType().ToString().Contains("LocalPlayer"))
            {
                object[] p = new object[1];
                p[0] = this.checkBoxCheck;
                this.checkBoxCheck.Invoke(new MakeVisibleHandler(this.UnCheckMe), p);
                p[0] = checkBoxAutoFold;
                
                this.checkBoxAutoFold.Invoke(new MakeVisibleHandler(this.UnCheckMe), p);


            }
        }
        /// <summary>
        /// export game events into TXT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem32_Click(object sender, EventArgs e)
        {
            if (this.richTextBox4.Text == "")
                return;
            HideAtEndOfGame();
            DialogResult res = MessageBox.Show("Do you want to export game events data into a file?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.Yes || res == DialogResult.OK)

            {
               SaveFileDialog openfile = new SaveFileDialog();

                DialogResult resFile= openfile.ShowDialog();
            

                if (resFile == DialogResult.No || resFile == DialogResult.None || resFile == DialogResult.Retry)
                    return;

                if (resFile == DialogResult.OK)
                {
                    string st = openfile.FileName;
                    FileInfo file = new FileInfo(st);

                    StreamWriter stream = new StreamWriter(st, true, Encoding.Unicode);
                    stream.Write(this.richTextBox4.Text);
                    stream.Flush();
                    stream.Close();
                }
            
            
            }

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.button2.BackgroundImage = poker.Properties.Resources.buttonB_up;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.button2.BackgroundImage = poker.Properties.Resources.buttonB_over;
       
        }

        private void checkBoxAutoFold_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxAutoFold.Checked)
            {

                this.checkBoxCheck.Checked = false;
            }
        }

        private void checkBoxCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxCheck.Checked)
            {

                this.checkBoxAutoFold.Checked = false;
            }
        }

        private void menuItem33_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.WorkingDirectory = Application.StartupPath;
            p.StartInfo.Arguments = Application.StartupPath +"\\DOc\\PokDTC_User_doc.pdf";
            p.Start();
        }

     


      
    }
}
