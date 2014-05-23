using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
//using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using Parse;

namespace PokerGame
{
    public partial class Game : Form
    {

        Bitmap surface;
        Graphics device;
        Bitmap backgroundImage;
        private Bitmap surfaceButton;
        FileParse fileParse;// = new FileParse("SampleHandFile.txt");// = new FileParse();

        Bitmap controlsImage;
        Graphics controlsDevice;
        public GenericParse currHand;
        
        Table table;
        
		//Thread Listener;
        //Lobby lobby;
        
        public Game()//Lobby lobby)
        {
            //this.lobby = lobby;

            InitializeComponent();
            fileParse = new FileParse("SampleHandFile.txt");
            currHand = fileParse.NextHand();
            //hand = new FileParse("SampleHandFile.txt");
            

            //this.mainCanvas.BackColor = System.Drawing.Color.Black;
            this.mainCanvas.BackColor = System.Drawing.Color.Transparent;
            this.mainCanvas.Location = new System.Drawing.Point(0, 0);
            this.mainCanvas.SendToBack();
            this.Community0.BringToFront();

            this.Community0.BackgroundImage = global::PokerGame.Properties.Resources._10_1;
            this.Community0.Visible = true;
            //PictureBox PictureBox2 = new PictureBox();
            //PictureBox2.Image = new Bitmap(global::Client.Properties.Resources.face);
            //PictureBox2.BackColor = System.Drawing.Color.Transparent;
            //PictureBox2.Size = global::Client.Properties.Resources.face.Size;
            //PictureBox2.Location = new System.Drawing.Point(400, 435);
            //PictureBox2.BringToFront();
            //this.Controls.Add(PictureBox2);

            //PictureBox PictureBox1 = new PictureBox();
            //PictureBox1.BackColor = System.Drawing.Color.Transparent;
            //PictureBox1.Image = new Bitmap(global::Client.Properties.Resources.fg_border);
            //PictureBox1.Size = global::Client.Properties.Resources.fg_border.Size;
            //PictureBox1.SendToBack();
            //this.Controls.Add(PictureBox1);

            //set up the form
            this.Text = "Bitmap Drawing Demo";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.
                FixedSingle;
            this.MaximizeBox = false;
            
            
            //this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.controlerCanvas.BringToFront();
            
            
            //create graphics device
            surface = new Bitmap(this.Size.Width, this.Size.Height);
            mainCanvas.Image = surface;
            device = Graphics.FromImage(surface);

            surfaceButton = new Bitmap(this.controlerCanvas.Size.Width, this.controlerCanvas.Size.Height);
            controlerCanvas.Image = surfaceButton;
            controlsDevice = Graphics.FromImage(surfaceButton);

            //load the bitmap
            backgroundImage = new Bitmap(global::PokerGame.Properties.Resources.Metallic_Floor_nova);
            Bitmap tableImage = new Bitmap(global::PokerGame.Properties.Resources.fg_border);

            
            //Bitmap table_image = new Bitmap(global::PokerGame.Properties.Resources.sitgo_table);
            
            //draw the bitmap 
            device.DrawImage(backgroundImage, 0, 0);
            device.DrawImage(tableImage, 0, 0);
            device.DrawImage(global::PokerGame.Properties.Resources.face, 400, 427);

            //controlsDevice.DrawImage(global::PokerGame.Properties.Resources.face, 400,427);//new System.Drawing.Point(400, 427));
                
            //this.controlerCanvas.InitialImage = null;
            //this.controlerCanvas.Location = new System.Drawing.Point(400, 427);
            //this.controlerCanvas.Name = "controlerCanvas";
            //5 .Size = new System.Drawing.Size(327, 114);
            Point button0Point = new Point(52, 71);
            Point button1Point = new Point(101, 71);
            Point button2Point = new Point(146, 71);
            Point button3Point = new Point(191, 71);
            Point button4Point = new Point(262, 71);
            Point button5Point = new Point(293, 83);
            Point.Add(button0Point,new Size(new Point(400,427)));
            /*
            drawButton(button0, global::PokerGame.Properties.Resources.backward, Point.Add(button0Point, new Size(new Point(400, 427))), true);//new System.Drawing.Point(52, 71), false);
            drawButton(button1, global::PokerGame.Properties.Resources.resume, Point.Add(button1Point, new Size(new Point(400, 427))), true);
            drawButton(button2, global::PokerGame.Properties.Resources.reset, Point.Add(button2Point, new Size(new Point(400, 427))), false);
            drawButton(button3, global::PokerGame.Properties.Resources.forward, Point.Add(button3Point, new Size(new Point(400, 427))), false);
            drawButton(button4, global::PokerGame.Properties.Resources.prev, Point.Add(button4Point, new Size(new Point(400, 427))), false);
            drawButton(button5, global::PokerGame.Properties.Resources.next, Point.Add(button5Point, new Size(new Point(400, 427))), false);
             */
            drawButtonI(button0, global::PokerGame.Properties.Resources.backward, button0Point, false);//new System.Drawing.Point(52, 71), false);
            drawButtonI(button1, global::PokerGame.Properties.Resources.resume, button1Point, false);//new System.Drawing.Point(52, 71), false);
            drawButtonI(button2, global::PokerGame.Properties.Resources.reset, button2Point, false);//new System.Drawing.Point(52, 71), false);
            drawButtonI(button3, global::PokerGame.Properties.Resources.forward, button3Point, false);//new System.Drawing.Point(52, 71), false);
            drawButtonI(button4, global::PokerGame.Properties.Resources.prev, button4Point, false);//new System.Drawing.Point(52, 71), false);
            drawButtonI(button5, global::PokerGame.Properties.Resources.next, button5Point, false);//new System.Drawing.Point(52, 71), false);
          /*
            this.button0.BringToFront();
            this.button0.Visible = true;
            this.button0.Location = new Point(100, 100);
            this.button0.BackgroundImage = global::PokerGame.Properties.Resources.backward;
            this.button1.BringToFront();
            this.button1.Visible = true;
            this.button1.Location=new System.Drawing.Point(120,100);
            */
            ///
            /// Todo: Como fazer 
            ///

            //device.DrawImage(controls_image, control_P);

            table = new Table (this,device);
        }
        private void drawButtonI(Button buttonI, Bitmap buttonBitmap, Point middlePos, Boolean debug)
        {
            controlsImage = global::PokerGame.Properties.Resources.face;
            Point zero = new Point(400, 427);
            // sempre comeca no 0,0 pois eh no controle
            buttonI.Location = zero;//new Point(0, 0);
            buttonI.BringToFront();
            // no tamanho do controle sempre
            Size buttonControlSize = controlsImage.Size;
            buttonI.Size = buttonControlSize;
            buttonI.BackColor = Color.Transparent;

            //Bitmap resume = new Bitmap(global::PokerGame.Properties.Resources.resume);

            // abrir um buraco do tamanho do sprite...
            Size buttonHoleSize = buttonBitmap.Size;
            buttonHoleSize.Width = buttonHoleSize.Width / 3 + 1; // tres frames
            buttonHoleSize.Height = buttonHoleSize.Height + 1; // tres frames


            //button0.BackColor = System.Drawing.Color.Blue ;
            //System.Drawing.Point InitialPos = new System.Drawing.Point(20, 50);
            //button0.Location = resumePos;

            Bitmap surface = new Bitmap(buttonControlSize.Width, buttonControlSize.Height);// mainCanvas.Image = surface;
            Graphics canvas = Graphics.FromImage(surface);
            canvas.DrawImage(controlsImage, zero);//new Point(0, 0));
            if (!debug)
                buttonI.BackgroundImage = surface;

            //Point backwardPos = new Point(23 - 2, 55 - 3);//73,42);
            //Rectangle button0Location = new Rectangle(initialPos, new Size(55, 37));
            Point cornerPosition = new Point(middlePos.X - buttonHoleSize.Width / 2, middlePos.Y - buttonHoleSize.Height / 2);
            Rectangle buttonHole = new Rectangle(cornerPosition, buttonHoleSize);//new Size(55, 37));
            GraphicsPath g_path = new GraphicsPath();

            //g_path.AddEllipse(5, 5, 30, 30);
            //g_path.AddEllipse(button0Location);
            buttonHole.Inflate(-10, -10);
            g_path.AddRectangle(buttonHole);
            buttonI.Region = new Region(g_path);
            buttonI.BringToFront();

            if (debug)
                buttonI.BackColor = Color.Cyan;
            if (!debug)
                canvas.DrawImage(buttonBitmap, cornerPosition); //global::PokerGame.Properties.Resources.backward, resumePos);

        }
        
        private void drawButton(Button buttonI, Bitmap buttonBitmap, Point middlePos, Boolean debug)
        {
            controlsImage = global::PokerGame.Properties.Resources.face;
            // sempre comeca no 0,0 pois eh no controle
            buttonI.Location = middlePos;// new Point(300, 100);
            buttonI.Visible = true;
            buttonI.BackgroundImage = buttonBitmap;
            buttonI.BringToFront();
            
            // no tamanho do controle sempre
            Size buttonControlSize = global::PokerGame.Properties.Resources.face.Size;// controlsImage.Size;
            buttonI.Size = buttonControlSize;


            //Bitmap resume = new Bitmap(global::PokerGame.Properties.Resources.resume);

            // abrir um buraco do tamanho do sprite...
            Size buttonHoleSize = buttonBitmap.Size;
            buttonHoleSize.Width = buttonHoleSize.Width / 3 + 1; // tres frames
            buttonHoleSize.Height = buttonHoleSize.Height + 1; // tres frames
            /*

            //button0.BackColor = System.Drawing.Color.Blue ;
            //System.Drawing.Point InitialPos = new System.Drawing.Point(20, 50);
            //button0.Location = resumePos;

            Bitmap surface = new Bitmap(buttonControlSize.Width, buttonControlSize.Height);// mainCanvas.Image = surface;
            Graphics canvas = Graphics.FromImage(surface);
            //canvas.DrawImage(controlsImage, new Point(0, 0));
            if (!debug)
                buttonI.BackgroundImage = surface;

            //Point backwardPos = new Point(23 - 2, 55 - 3);//73,42);
            //Rectangle button0Location = new Rectangle(initialPos, new Size(55, 37));
             */
            Point cornerPosition = new Point(middlePos.X - buttonHoleSize.Width / 2, middlePos.Y - buttonHoleSize.Height / 2);
            Rectangle buttonHole = new Rectangle(cornerPosition, buttonHoleSize);//new Size(55, 37));
            GraphicsPath g_path = new GraphicsPath();

            //g_path.AddEllipse(5, 5, 30, 30);
            //g_path.AddEllipse(button0Location);

            g_path.AddRectangle(buttonHole);
            // buttonI.Region = new Region(g_path);
            /*
            buttonI.BringToFront();

            if (debug)
                buttonI.BackColor = Color.Cyan;
            if (!debug)
                canvas.DrawImage(buttonBitmap, cornerPosition); //global::PokerGame.Properties.Resources.backward, resumePos);
            device.DrawImage(surface,0,0);
             */
        }

        /*
        public Bitmap LoadBitmap(string filename)
        {
            Bitmap bmp = null;
            try
            {
                bmp = new Bitmap(filename);
            }
            catch (Exception ex) { }
            return bmp;
        }
        */

        private static int act = 0;
        private static string[] acoes = {
"@nada1$",
"@nada2$",
"Sitting$0$eduardo$100$",
"Joined$1$teste1a$200$",
"Joined$2$teste2b$400$",
"Joined$3$teste3c$500$", 
"Joined$4$teste4d$500$", 
"Joined$5$teste5e$500$",
"Joined$6$teste6f$500$",
"Joined$7$teste7f$500$",
"Button$1$",
"Dealer$1$",
"SmallBlind$2$25$",
"BigBlind$3$50$",
"Hand$1$14$1$14$2$",
"Hand$2$13$1$13$2$",
"Playing$1$",
"Waiting$50$75$",
"Playing$2$",
"Waiting$50$75$"
        };

        private void Sit_Click(object sender, EventArgs e)
        {
            //I.Write("Sit$");
            if (act < acoes.Length - 1)
            {
                I.Write(acoes[act]);
                act++;
            }
            else
                act = 0;

            //Sit.Hide();
            //Stand.Show();


            ///Todo: Melhorar
           // Invoke(ProcessDelegate, acoes[act]);//I.Read());
            table.Process(acoes[act]);
        }

        private void Call_Click(object sender, EventArgs e)
        {
            /*
            if (Call.Text == "All In")
            {
                I.Write("AllIn$");
                I.Money = 0;
            }
            else
            {
                I.Write("Call$");
                if (Call.Text != "Check")
                    I.Money -= int.Parse(Call.Text.Substring(Call.Text.IndexOf(" ") + 1));
            }
            HideButtons();
             * */
        }

        private void Raise_Click(object sender, EventArgs e)
        {
            /*
            if (int.Parse(RaiseAmount.Text) == I.Money || Raise.Text == "All In")
            {
                I.Write("AllIn$");
                I.Money = 0;
            }
            else
            {
                I.Write("Raise$" + RaiseAmount.Text + "$");
                I.Money -= int.Parse(RaiseAmount.Text);
            }
            HideButtons();
             */
        }

        private void Fold_Click(object sender, EventArgs e)
        {
            I.Write("Fold$");
            HideButtons();
        }

        public void HideButtons()
        {
            //RaiseBar.Hide();
            //Call.Hide();
            //Raise.Hide();
            //Fold.Hide();
            //RaiseAmount.Hide();
        }

        public void ShowButtons()
        {
            //RaiseBar.Show();
            //Call.Show();
            //Raise.Show();
            //Fold.Show();
            //RaiseAmount.Show();
        }

        private void Stand_Click(object sender, EventArgs e)
        {
            I.Write("Fold$");
            Thread.Sleep(500);
            HideButtons();
            I.Write("Stand$");
            //Stand.Hide();
            //button0.Show();
        }

        private void RaiseBar_Scroll(object sender, System.EventArgs e)
        {
            //RaiseAmount.Text = RaiseBar.Value + "";
        }
        private void TableClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*
            if (Fold.Visible)
            {
                I.Write("Fold$");
                Thread.Sleep(500);
            }
             * */
            I.Write("Stand$");
            I.Write("Leave$");
            //lobby.Show();
            device.Dispose();
            surface.Dispose();
            backgroundImage.Dispose();

        }

        private void button0_Click(object sender, EventArgs e)
        {
            Pot.Text = "click - button0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pot.Text = "click - button1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pot.Text = "click - button2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (act < acoes.Length - 1)
            {
                I.Write(acoes[act]);
                act++;
            }
            else
                act = 0;

            //Sit.Hide();
            //Stand.Show();


            ///Todo: Melhorar
            // Invoke(ProcessDelegate, acoes[act]);//I.Read());
            table.Process(acoes[act]);
        }
        //Prev Hand
        private void button4_Click(object sender, EventArgs e)
        {
            currHand = fileParse.PrevHand();
            //Pot.Text = "click - button4";
            if (currHand != null)
            {
                this.Text = "Hand Number # " + currHand.HandNumber;

                button5.Show();
            }
            else
                button4.Hide();
        }

        //Next Hand
        private void button5_Click(object sender, EventArgs e)
        {
            currHand = fileParse.NextHand();
            //Pot.Text = "click - button5";
            if (currHand != null)
            {
                this.Text = "Hand Number # " + currHand.HandNumber;
                button4.Show();
            }
            else
                button5.Hide();
        }





    }
}