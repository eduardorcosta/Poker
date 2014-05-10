using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace poker
{
    public partial class HtmlWindow : UserControl
    {
        const int WM_VSCROLL = 0x0115;
        const int SB_BOTTOM = 7;
        
        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lparam);
       
        public HtmlWindow()
        {
            InitializeComponent();
            handle = this.webBrowserBox.Handle;
           
        }
        private string body;

        private string header = "";
        private string endBody = "";
        private string endOfLine = "<br>";

        private delegate void DelegateDoc(Control c);
        /// <summary>
        /// Affiche les changements effectués
        /// </summary>
        public void DrawIt()
        {
            try
            {
                
                this.webBrowserBox.Invoke(new DelegateDoc(DrawItInvoke), new object[] { this.webBrowserBox });
            }
            catch { }

        }

        public void CarriageReturn()
        {

            body += this.endOfLine;
        
        }
        private void DrawItInvoke(Control c)
        {

         this.webBrowserBox.DocumentText = body;



       

        
        }
        private void ScrollItInvoke(Control c)
        {
            this.webBrowserBox.Select();
            SendKeys.Send("{END}");


        }
        private IntPtr handle ;
        public void ScrollDown()
        {
            try
            {

                this.webBrowserBox.Invoke(new DelegateDoc(ScrollItInvoke), new object[] { this.webBrowserBox });
            }
            catch { }
        }

        public void AddSomeText(string txt)
        {

            if (txt.Contains("\n"))
                txt += this.endOfLine;
          
            body += txt;
     
        }

        public void AddSomeText(string txt,Color color)
        {


        }
        public void AddSomeText(string txt, Color color,Font font)
        {


        }
        public void AddSomeText(string txt, Color color, Font font,int size)
        {


        }

        public void AddImage(Card c)
        {
            AddImage(c.ValueR + c.AbsColorL);
        
        }
        public void AddImage(string txt)
        {
            string balise = "<img src=\"file:\\\\" + Application.StartupPath + "\\miniCards\\" + txt + ".jpg\"";
            Bitmap bmp = new Bitmap(Application.StartupPath + "\\miniCards\\" + txt + ".jpg");

                balise+=" width=\"" +bmp.Width+"\" height=\""+bmp.Height+"\"/>";
                body += balise;

        }
        public  void EraseOutput()
        {
            body = "";
        
        }
        public void ExportMe(string path )
        {
        StreamWriter txt = new StreamWriter(path,true);

        txt.Write(this.webBrowserBox.DocumentText);
        txt.Flush();
        txt.Close();
        }

        private void webBrowserBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            return;
        }

        private void webBrowserBox_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            
        }
    }
}
