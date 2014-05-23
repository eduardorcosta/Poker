using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace PokerGame
{
    class Player
    {
		int pos = 0;
        //Label name = new Label();
        //Label money = new Label();
		PictureBox holeCard0 = new PictureBox();
		PictureBox holeCard1  = new PictureBox();
        //PictureBox button = new PictureBox();
        //PictureBox action = new PictureBox();
        Graphics _device;
        Point sitPos;
        Bitmap seat = global::PokerGame.Properties.Resources.seat;
        Bitmap avatar = global::PokerGame.Properties.Resources.default_avatar;
        Bitmap border = global::PokerGame.Properties.Resources.border;
        Bitmap status = global::PokerGame.Properties.Resources.status;
        private PictureBox mainCanvas = new PictureBox();
        string name;
        string stack;
        
        private void DrawSit(int x,int y){
            using (Bitmap surface = new Bitmap(200,80))
            using (Graphics canvas = Graphics.FromImage(surface))
            {
                //canvas.FillRectangle(new SolidBrush(Color.Red),0,0,200,80);
                
                canvas.DrawImage(seat, 0, 0);
                canvas.DrawImage(avatar, +17, +17);
                canvas.DrawImage(border, 17, 17);
                canvas.DrawImage(status, seat.Size.Width / 2 - 17, seat.Size.Height / 2 - 17 / 2);
                
                _device.DrawImage(surface, sitPos);
            }
        }

        public Player(Graphics device, int x, int y)
        {
            _device = device;
            sitPos = new Point(x, y);
            DrawSit(x,y);
            //device.DrawImage(global::PokerGame.Properties.Resources.seat, x, y);
        }
        public string Name
        {
            get { return name; }
            set { 
                name = value;
                _device.DrawString(name, new Font("Arial", 16), new SolidBrush(Color.Yellow), sitPos.X + 70, sitPos.Y + 20);
            }
        }

        public int Money
        {
            get { return int.Parse(stack); }
            set { 
                stack = value.ToString();
                _device.DrawString(stack, new Font("Arial", 16), new SolidBrush(Color.White), sitPos.X + 70, sitPos.Y + 40);
            }
        }
        public string  Stack
        {
            get { return stack; }
            set { 
                stack = value;
                _device.DrawString(stack, new Font("Arial", 16), new SolidBrush(Color.White), sitPos.X + 70, sitPos.Y + 40);
            }
        }
        /*
        public Player(int x, int y) // 249,60 | 86, 126 | 87, 309 | 249, 373 | 483, 373 | 667, 309 | 667, 126 | 483, 60
        {
            name.BackColor = System.Drawing.Color.Transparent;
            name.ForeColor = System.Drawing.Color.White;
            name.Location = new System.Drawing.Point(x, y);
            name.Size = new System.Drawing.Size(35, 13);
            name.Text = "Open";
            name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            name.BringToFront();


            money.BackColor = System.Drawing.Color.Transparent;
            money.ForeColor = System.Drawing.Color.White;
            money.Location = new System.Drawing.Point(x + 2, y + 13);
            money.Size = new System.Drawing.Size(31, 13);
            money.Text = "Seat";
            money.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            money.BringToFront();

            ((System.ComponentModel.ISupportInitialize)(holeCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(holeCard0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(action)).BeginInit();

            holeCard0.BackColor = System.Drawing.Color.Transparent;
            holeCard0.Location = new System.Drawing.Point(x - 33, y - 57);
            holeCard0.Size = new System.Drawing.Size(48, 54);
            holeCard0.Visible = false;
            holeCard0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			holeCard0.BackgroundImage = Image.FromFile("Data/back.jpg");
            holeCard0.BringToFront();


            holeCard1.BackColor = System.Drawing.Color.Transparent;
            holeCard1.Location = new System.Drawing.Point(x + 20, y - 57);
            holeCard1.Size = new System.Drawing.Size(48, 54);
            holeCard1.Visible = false;
            holeCard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			holeCard1.BackgroundImage = Image.FromFile("Data/back.jpg");

            button.BackColor = System.Drawing.Color.Transparent;
            button.Location = new System.Drawing.Point(x + 58, y + 12);
            button.Size = new System.Drawing.Size(15, 14);
            button.Visible = false;
            button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button.BackgroundImage = global::PokerGame.Properties.Resources.chip_d; 
                //Image.FromFile("Data"+Path.DirectorySeparatorChar+ "chip-d.png");

            action.BackColor = System.Drawing.Color.Transparent;
            action.Location = new System.Drawing.Point(x + 7, y + 33);
            action.Size = new System.Drawing.Size(20, 5);
            action.Visible = false;
			action.Image = Image.FromFile("Data/action.gif");

            ((System.ComponentModel.ISupportInitialize)(action)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(holeCard0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(holeCard1)).EndInit();
        }*/
        /*
        public string Name
        {
            get { return name.Text; }
            set { name.Text = value; }
        }

        public int Money
        {
            get { return int.Parse(money.Text); }
            set { money.Text = value + ""; }
        }

        public Label NameAsControl
        {
            get { return name; }
        }

        public Label MoneyAsControl
        {
            get { return money; }
        }
        */
        public PictureBox HoleCard0
        {
            get { return holeCard0; }
		}

		public PictureBox HoleCard1
        {
            get { return holeCard1; }
        }
        /*
        public PictureBox Button
        {
            get { return button; }
        }

        public PictureBox Action
        {
            get { return action; }
        }
        */
		public int Posintion
		{
			get { return pos; }
			set { pos = Posintion; }
		}
    }
}
