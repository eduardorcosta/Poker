using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;


namespace PokerGame
{
    public partial class Game : Form
    {

        Bitmap surface;
        Graphics device;
        Bitmap image;

        
        
        Table table;
        
		//Thread Listener;
        //Lobby lobby;
        
        public Game()//Lobby lobby)
        {
            //this.lobby = lobby;

            InitializeComponent();

            //this.mainCanvas.BackColor = System.Drawing.Color.Black;
            this.mainCanvas.BackColor = System.Drawing.Color.Transparent;
            this.mainCanvas.Location = new System.Drawing.Point(0, 0);
            this.mainCanvas.SendToBack();
            this.Community0.BringToFront();

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
            //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            
            
            //create graphics device
            surface = new Bitmap(this.Size.Width, this.Size.Height);
            mainCanvas.Image = surface;
            device = Graphics.FromImage(surface);

            //load the bitmap
            image = new Bitmap(global::PokerGame.Properties.Resources.Metallic_Floor_nova);
            Bitmap image2 = new Bitmap(global::PokerGame.Properties.Resources.fg_border);

            //Bitmap table_image = new Bitmap(global::PokerGame.Properties.Resources.sitgo_table);
            
            //draw the bitmap 
            //device.DrawImage(image, 0, 0);
            //device.DrawImage(image2, 0, 0);
            //device.DrawImage(table_image, 0, 0);
            


           

            ///
            /// Todo: Como fazer 
            ///

            //device.DrawImage(controls_image, control_P);

            table = new Table (this);
        }


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
            image.Dispose();

        }

    }
}