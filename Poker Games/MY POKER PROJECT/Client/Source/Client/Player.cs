using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Client
{
    class Player
    {
		int pos = 0;
        Label name = new Label();
        Label money = new Label();
		PictureBox holeCard0 = new PictureBox();
		PictureBox holeCard1  = new PictureBox();
        PictureBox button = new PictureBox();
        PictureBox action = new PictureBox();
        public Player(int x, int y) // 249,60 | 86, 126 | 87, 309 | 249, 373 | 483, 373 | 667, 309 | 667, 126 | 483, 60
        {
            name.BackColor = System.Drawing.Color.Transparent;
            name.ForeColor = System.Drawing.Color.White;
            name.Location = new System.Drawing.Point(x, y);
            name.Size = new System.Drawing.Size(35, 13);
            name.Text = "Open";
            name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            money.BackColor = System.Drawing.Color.Transparent;
            money.ForeColor = System.Drawing.Color.White;
            money.Location = new System.Drawing.Point(x + 2, y + 13);
            money.Size = new System.Drawing.Size(31, 13);
            money.Text = "Seat";
            money.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

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
			button.BackgroundImage = Image.FromFile("Data"+Path.DirectorySeparatorChar+ "chip-d.png");

            action.BackColor = System.Drawing.Color.Transparent;
            action.Location = new System.Drawing.Point(x + 7, y + 33);
            action.Size = new System.Drawing.Size(20, 5);
            action.Visible = false;
			action.Image = Image.FromFile("Data/action.gif");

            ((System.ComponentModel.ISupportInitialize)(action)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(holeCard0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(holeCard1)).EndInit();
        }

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

        public PictureBox HoleCard0
        {
            get { return holeCard0; }
		}

		public PictureBox HoleCard1
        {
            get { return holeCard1; }
        }

        public PictureBox Button
        {
            get { return button; }
        }

        public PictureBox Action
        {
            get { return action; }
        }
		public int Posintion
		{
			get { return pos; }
			set { pos = Posintion; }
		}
    }
}
