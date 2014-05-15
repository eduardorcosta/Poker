using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PokerGame
{
    public partial class ControlPanel : UserControl
    {
        private Bitmap surface;
        private Graphics device;
        Bitmap controlsImage;

        public ControlPanel()
        {
            InitializeComponent();
            
            // init canvas
            this.mainCanvas.BackColor = System.Drawing.Color.Transparent;
            this.mainCanvas.Location = new System.Drawing.Point(0, 0);
            this.mainCanvas.SendToBack();
            surface = new Bitmap(this.Size.Width, this.Size.Height);
            mainCanvas.Image = surface;
            device = Graphics.FromImage(surface);
            // end canvas
            
            // add background
            controlsImage = new Bitmap(global::PokerGame.Properties.Resources.face);
            device.DrawImage(controlsImage, 0, 0);


            this.BackColor = System.Drawing.Color.White;
            //Control panel
            //System.Drawing.Point control_P = new System.Drawing.Point(400, 425);
            
            
            

            /*
            // Help na posicao
            System.Drawing.Point button1ImagePos = new System.Drawing.Point(75 - 8, 44 - 8);
            button1.BackColor = System.Drawing.Color.Pink;
            Rectangle bordaB1 = button1Rectangle;
            bordaB1.Offset(button1Location.X+1,button1Location.Y+1);
            device.DrawRectangle(new Pen(System.Drawing.Color.Violet, 1), bordaB1);
            device.SmoothingMode = SmoothingMode.AntiAlias;
            
            //device.DrawPath(new Pen(System.Drawing.Color.Red,3),g_path1);
            device.DrawEllipse(new Pen(System.Drawing.Color.Wheat, 1), bordaB1);
            
            System.Drawing.Point button1ImagePos = new System.Drawing.Point(75 - 8, 44 - 8);
            device.DrawImage(resume, button1ImagePos);
            device.SmoothingMode = SmoothingMode.AntiAlias;
            */

            //Play Button
            //drawButton1();

            // Backward Button
            //drawButton0();
            drawButton(button0, global::PokerGame.Properties.Resources.backward, new System.Drawing.Point(52, 71),false);
            drawButton(button1, global::PokerGame.Properties.Resources.resume, new System.Drawing.Point(101, 71), false);
            drawButton(button2, global::PokerGame.Properties.Resources.reset, new System.Drawing.Point(146,71),false);


/*
            // Stop Button
            System.Drawing.Drawing2D.GraphicsPath g_path2 = new System.Drawing.Drawing2D.GraphicsPath();
            g_path2.AddEllipse(5, 5, 30, 30);
            button2.Region = new Region(g_path2);
            */
            // Forward Button
            System.Drawing.Drawing2D.GraphicsPath g_path3 = new System.Drawing.Drawing2D.GraphicsPath();
            g_path3.AddEllipse(5, 5, 30, 30);
            button3.Region = new Region(g_path3);


            // backward Hand Button
            System.Drawing.Drawing2D.GraphicsPath g_path4 = new System.Drawing.Drawing2D.GraphicsPath();
            g_path4.AddEllipse(5, 5, 30, 30);
            button4.Region = new Region(g_path4);


            // Forward Hand Button
            System.Drawing.Drawing2D.GraphicsPath g_path5 = new System.Drawing.Drawing2D.GraphicsPath();
            g_path5.AddEllipse(5, 5, 30, 30);
            button5.Region = new Region(g_path5);
        }
        private void drawButton(Button buttonI,Bitmap buttonBitmap,Point middlePos, Boolean debug)
        {
            // sempre comeca no 0,0 pois eh no controle
            buttonI.Location = new Point(0, 0);
            // no tamanho do controle sempre
            Size buttonControlSize = controlsImage.Size;
            buttonI.Size = buttonControlSize;


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
            canvas.DrawImage(controlsImage, new Point(0, 0));
            if (!debug)
                buttonI.BackgroundImage = surface;

            //Point backwardPos = new Point(23 - 2, 55 - 3);//73,42);
            //Rectangle button0Location = new Rectangle(initialPos, new Size(55, 37));
            Point cornerPosition = new Point(middlePos.X - buttonHoleSize.Width / 2, middlePos.Y - buttonHoleSize.Height / 2);
            Rectangle buttonHole = new Rectangle(cornerPosition, buttonHoleSize);//new Size(55, 37));
            GraphicsPath g_path = new GraphicsPath();
            
            //g_path.AddEllipse(5, 5, 30, 30);
            //g_path.AddEllipse(button0Location);
            
            g_path.AddRectangle(buttonHole);
            buttonI.Region = new Region(g_path);
            buttonI.BringToFront();
            
            if (debug)
                buttonI.BackColor = Color.Cyan;
            if (!debug)
                canvas.DrawImage(buttonBitmap,cornerPosition); //global::PokerGame.Properties.Resources.backward, resumePos);

        }
        private void drawButton0()
        {
            //Bitmap resume = new Bitmap(global::PokerGame.Properties.Resources.resume);
            Size backwardButtonSize = controlsImage.Size;

            //button0.BackColor = System.Drawing.Color.Blue ;
            System.Drawing.Point resumePos = new System.Drawing.Point(20, 50);
            //button0.Location = resumePos;
            button0.Location = new Point(0, 0);
            button0.Size = backwardButtonSize;
            Bitmap surfaceButton0 = new Bitmap(backwardButtonSize.Width, backwardButtonSize.Height);// mainCanvas.Image = surface;
            Graphics deviceButton0 = Graphics.FromImage(surfaceButton0);
            deviceButton0.DrawImage(controlsImage, new Point(0, 0));
            button0.BackgroundImage = surfaceButton0;
            Point backwardPos = new Point(23 - 2, 55 - 3);//73,42);
            Rectangle button0Location = new Rectangle(backwardPos, new Size(55, 37));

            System.Drawing.Drawing2D.GraphicsPath g_path = new System.Drawing.Drawing2D.GraphicsPath();
            //g_path.AddEllipse(5, 5, 30, 30);
            //g_path.AddEllipse(button0Location);
            g_path.AddRectangle(button0Location);
            button0.Region = new Region(g_path);
            button0.BringToFront();
            //button0.BackColor = Color.Cyan;
            deviceButton0.DrawImage(global::PokerGame.Properties.Resources.backward, resumePos);

        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Button 1 ";// +e.ToString;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void drawButton1()
        {
            //PLAY BUTTON

            //button1.Location = Point.Add(control_P, play_pos);// new System.Drawing.Point(control_P);
            /*
                        System.Drawing.Rectangle newRectangle = roundButton.ClientRectangle;

                        // Decrease the size of the rectangle.
                        newRectangle.Inflate(-10, -10);

                        // Draw the button's border.
                        e.Graphics.DrawEllipse(System.Drawing.Pens.Black, newRectangle);

                        // Increase the size of the rectangle to include the border.
                        newRectangle.Inflate(1, 1);

                        // Create a circle within the new rectangle.
                        buttonPath.AddEllipse(newRectangle);
            */



            //button1.BackColor = Color.Transparent;


            /*
            
             // muito feio mas mas eh um vetor
            System.Drawing.Size playSize = new System.Drawing.Size(53, 53);
            System.Drawing.Point playPos_shift = new System.Drawing.Point(4,3);
            //button1.Margin.All(0);//// = 0;        
            //button1.Location = playPos;// new System.Drawing.Point(40, 68);//(0, 0);// play_pos;
            //button1.Size = new System.Drawing.Size(100, 100);
            //button1.Size = new System.Drawing.Size(playSize.Width, playSize.Height);// playSize;// new System.Drawing.Size(100, 100);//327,114);
            */


            // new location and size
            Bitmap resume = new Bitmap(global::PokerGame.Properties.Resources.resume);
            Size resumeButtonSize = resume.Size;
            resumeButtonSize.Width = resumeButtonSize.Width / 3 + 1; // tres frames
            resumeButtonSize.Height = resumeButtonSize.Height + 1; // tres frames

            Point playPos = new Point(76 - 2, 45 - 3);//73,42);
            Point button1Location = new Point(playPos.X - 9, playPos.Y - 9); // offset da sprite
            button1.Location = button1Location;
            button1.Size = resumeButtonSize;
            Rectangle button1Rectangle = button1.ClientRectangle;
            //button1Rectangle.Offset(3, 3);
            button1Rectangle.Inflate(-8, -8);



            // draw path
            System.Drawing.Drawing2D.GraphicsPath g_path1 = new System.Drawing.Drawing2D.GraphicsPath();
            g_path1.AddEllipse(button1Rectangle);

            // Image Of Button
            button1.BackColor = Color.DarkGray;  //color..Pink;
            //resume.
            //resume.SelectActiveFrame(System.Drawing.Imaging.FrameDimension(
            button1.Image = resume;
            button1.Region = new Region(g_path1);
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            Graphics.FromImage(resume).SmoothingMode = SmoothingMode.AntiAlias;
            //button1.Visible = false;
            //button1.Enabled = true;
            
        }
    }
}
