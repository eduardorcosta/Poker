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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
namespace poker
{
    /// <summary>
    /// Show informations about the game
    /// </summary>
    public class  GameEvents
    {
        //auto scroll down
        const int WM_VSCROLL = 0x0115;
        const int SB_BOTTOM = 7;
        private delegate void MyDelegate(Control c);
        public GameEvents(RichTextBox d, Form1 f)
        {
            richTextBox = d;
            form = f;
        }
        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lparam);
        public void ChangeColor(Color color)
        {
            try
            {
                swap_color = color;
                Object[] p = new object[1];
                p[0] = this.richTextBox;
                this.richTextBox.Invoke(new MyDelegate(ChangeColorInvoke), p);
            }
            catch { }
            //this.richTextBox.ForeColor=color;
        }
        private Color swap_color;
        private void ChangeColorInvoke(Control c)
        {

            ((RichTextBox)c).SelectionColor = swap_color;
        }
        /// <summary>
        /// add text to everybox  
        /// </summary>
        /// <param name="st"></param>
        public void AddDia(string st)
        {
            try
            {
                if (st.Contains("♥") || st.Contains("♠") || st.Contains("♣") || st.Contains("♦"))
                {
                    WriteWithColor(st);
                    if (st.Contains("\n"))
                        this.AddOwnDia("\n");
                }
                else
                    AddOwnDia(st);
                //form.HtmlOutput().AddSomeText(st);
                //form.HtmlOutput().DrawIt();
                if (!this.form.Dispatcher.Communication.IsConnected())
                {
                    form.Dispatcher.Communication.SendBroadCast("{dia " + st);
                }
            }
            catch { }
        }
        /// <summary>
        /// write with some color according cards symbol
        /// Spade black 
        /// Heart Red
        /// Diamond Blue 
        /// trefle Green
        /// </summary>
        /// <param name="st"></param>
        private void WriteWithColor(string st)
        {
            string[] split = st.Trim().Split(new char[] { ' ' });

            for (int i = 0; i < split.Length - 1; i = i + 2)
            { 
            
            string cardsValue=split[i];
            string cardsSymbol = split[i + 1];

            if (cardsSymbol == "♥")
            {
                this.ChangeColor(Color.Red);
            }
            if (cardsSymbol == "♠")
            {
                this.ChangeColor(Color.Black);
            }
            if (cardsSymbol == "♣")
            {
                this.ChangeColor(Color.Green);
            }
            if (cardsSymbol == "♦")
            {
                this.ChangeColor(Color.Blue);
            }

            st=cardsValue + " " + cardsSymbol + " ";
            text_tmp = st;
            object[] p = new object[1];
            p[0] = this.richTextBox;
           
            richTextBox.Invoke(new DelegateRichBox(AddOwnDiaInvoke), p);
            

            
            }
            this.ChangeColor(Color.Black);
            
            
        }
        private delegate void DelegateRichBox(Control c);
        private string text_tmp = "";
        /// <summary>
        /// add text to his own windows
        /// </summary>
        /// <param name="st"></param>
        public void AddOwnDia(string st)
        {
            if (form.Stop) return;
            try
            {
                if (st.Contains("♥") || st.Contains("♠") || st.Contains("♣") || st.Contains("♦"))
                {
                    WriteWithColor(st);
                    if (st.Contains("\n"))
                        this.AddOwnDia("\n");
                    return;
                }
                //form.HtmlOutput().AddSomeText(st);
                //form.HtmlOutput().DrawIt();



                text_tmp = st;
                object[] p = new object[1];
                p[0] = this.richTextBox;
                if (st.Contains(Language.GetLastHandEvents()))
                    ChangeColor(Color.Red);
                richTextBox.Invoke(new DelegateRichBox(AddOwnDiaInvoke), p);
                ChangeColor(Color.Black);
            }
            catch { }
        }


        public void AddDia(string st, Color color)
        {
            ChangeColor(color);

            AddDia(st);
            ChangeColor(Color.Black);
        }
        //private Image CropImage(Image img, Rectangle cropArea)
        //{
        //    Bitmap bmInit = new Bitmap(img);
        //    Bitmap bmFinal = new Bitmap(cropArea.Width, cropArea.Height,bmInit.PixelFormat);

        //    int PixelSize = 4; // Pixelsize for a jpeg image


        //        BitmapData init = bmInit.LockBits(new Rectangle(0, 0, bmInit.Width, bmInit.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmInit.PixelFormat);

        //        BitmapData final = bmFinal.LockBits(new Rectangle(0, 0, bmFinal.Width, bmFinal.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmFinal.PixelFormat);
        //    unsafe{
        //        for (int y = cropArea.Top; y < cropArea.Bottom; y++)
        //        {
        //            byte* initRow = (byte*)init.Scan0 + (y * init.Stride);
        //            byte* finalRow = (byte*)final.Scan0 + ((y - cropArea.Top) * final.Stride);

        //            for (int x = cropArea.Left; x < cropArea.Right; x++)
        //            {
        //                finalRow[(x - cropArea.Left) * PixelSize + 1] = initRow[x * PixelSize + 1];
        //                finalRow[(x - cropArea.Left) * PixelSize + 2] = initRow[x * PixelSize + 2];
        //                finalRow[(x - cropArea.Left) * PixelSize] = initRow[x * PixelSize];
        //            }
        //        }
        //}
        //        bmInit.UnlockBits(init);
        //        bmFinal.UnlockBits(final);

        //    return (Image)bmFinal;
        //}

        public void AddPicture(Card[] c,bool  everybody)
        {
            if (c == null || c[0] == null || (c.Length>1 && c[1] == null))
                return;


            string[] list = new string[c.Length];
            string text2send = "";
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = c[i].ValueR.ToString() + c[i].AbsColorL.ToString();

                string color = c[i].AbsColorL.ToString();

                if (color == "p")
                    text2send = text2send + (" " + c[i].Name + " ♠");
                if (color == "t")
                    text2send = text2send + (" " + c[i].Name + " ♣");

                if (color == "ca")
                {
                    ChangeColor(Color.Red);
                    text2send = text2send + (" " + c[i].Name + " ♦");
                    ChangeColor(Color.Black);

                }
                if (color == "co")
                {
                    ChangeColor(Color.Red);
                    text2send = text2send + (" " + c[i].Name + " ♥");
                    ChangeColor(Color.Black);

                }
              
                //form.HtmlOutput().AddImage(c[i]);
            }

            if (everybody)
                AddDia(text2send);
            else {

                AddOwnDia(text2send);
            }

            //   a elever si juste HTML
            //AddPicture(list);

        }

        
        /// <summary>
        /// outdated
        /// </summary>
        Bitmap[] crops;
        /// <summary>
        /// outdated
        /// </summary>
        private void oleThread()
        {
            Clipboard.Clear();
            for (int i = 0; i < crops.Length; i++)
            {

                Clipboard.SetData(DataFormats.Bitmap, crops[i]);

                try
                {
                    object[] p = new object[1];
                    p[0] = this.richTextBox;
                    this.richTextBox.Invoke(new DelegateRichBox(Paste), p);
                }
                catch (Exception ex) { return; }
            }
            return;
        }

        private void Paste(Control c)
        {
            this.richTextBox.ReadOnly = false;
            this.richTextBox.Paste();

            this.richTextBox.ReadOnly = true;

        }
        private delegate void DelegateControl(Control c);

        private bool readOnly;
        private void AddOwnDiaInvoke(Control c)
        {

            if (text_tmp == "")
                return;
            if (text_tmp == " ")
                return;
            if (text_tmp == "\\n")
                return;
            this.richTextBox.AppendText(text_tmp);


            SendMessage(this.richTextBox.Handle, WM_VSCROLL, SB_BOTTOM, 0);



        }
        private RichTextBox richTextBox;
        private Form1 form;
    }
}
