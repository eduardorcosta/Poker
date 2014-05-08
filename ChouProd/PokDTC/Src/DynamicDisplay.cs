using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace poker
{
    /// <summary>
    /// scale up to make all fit on poker table 
    /// </summary>
    class DynamicDisplay
    {
        public static Form1 mainW;

        public DynamicDisplay(Form1 form)
        {

            mainW = form;
        }

        private delegate void DelegateAjob(Control c);
        /// <summary>
        /// real size of background
        /// </summary>
        public static int REAL_SIZE_X = 1280;
        public static int REAL_SIZE_Y = 1024;

        /// <summary>
        /// current size of background
        /// </summary>
        public static int CURRENT_SIZE_X = 1280;
        public static int CURRENT_SIZE_Y = 1024;
        /// <summary>
        /// transform  value into a fit screen one ( according to X)
        /// </summary>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        private int RatioX(int value)
        {
            double val= (double)CURRENT_SIZE_X * value/ (double) REAL_SIZE_X;
            return (int) val;
        }
        /// <summary>
        /// transform  value into a fit screen one ( according to Y)
        /// </summary>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        private int RatioY(int value)
        {
            double val = (double)CURRENT_SIZE_Y * value / (double)REAL_SIZE_Y;
            return (int)val;
        }

        public void ChangeDisplayCards()
        {
            ChangeCard0Size();
            ChangeCard1Size();
            ChangeCard2Size();
            ChangeCard3Size();
            ChangeCard4Size();
        
        
        }

        private void ChangeCard0Size()
        {
            mainW.Invoke(new DelegateAjob(ChangeCard0SizeInvoke), new object[] { mainW });
        }
        private void ChangeCard0SizeInvoke(Control c)
        {
            mainW.PictureBox4.Location = new Point(RatioX(446), RatioY(384));

        }
        private void ChangeCard1Size()
        {
            mainW.Invoke(new DelegateAjob(ChangeCard1SizeInvoke), new object[] { mainW });
        }
        private void ChangeCard1SizeInvoke(Control c)
        {
            mainW.PictureBox3.Location = new Point(RatioX(536), RatioY(384));

        }
        private void ChangeCard2Size()
        {
            mainW.Invoke(new DelegateAjob(ChangeCard2SizeInvoke), new object[] { mainW });
        }
        private void ChangeCard2SizeInvoke(Control c)
        {
            mainW.PictureBox5.Location = new Point(RatioX(626), RatioY(384));

        }
        private void ChangeCard3Size()
        {
            mainW.Invoke(new DelegateAjob(ChangeCard3SizeInvoke), new object[] { mainW });
        }
        private void ChangeCard3SizeInvoke(Control c)
        {
            mainW.PictureBox6.Location = new Point(RatioX(716), RatioY(384));

        }
        private void ChangeCard4Size()
        {
            mainW.Invoke(new DelegateAjob(ChangeCard4SizeInvoke), new object[] { mainW });
        }
        private void ChangeCard4SizeInvoke(Control c)
        {
            mainW.PictureBox7.Location = new Point(RatioX(806), RatioY(384));

        }
        public void ChangeDisplayTable()
        { 
        
        ChangePlayer0Size();
        ChangePlayer1Size();
        ChangePlayer2Size();
        ChangePlayer3Size();
        ChangePlayer4Size();
        ChangePlayer5Size();
        ChangePlayer6Size();
        ChangePlayer7Size();
        ChangePlayer8Size();
        ChangePlayer9Size();
        
        }
        /// <summary>
        /// call into an Invoke
        /// </summary>
        public  void ChangePlayer0Size()
        {
            mainW.Invoke(new DelegateAjob(ChangePlayer0SizeInvoke), new object[] { mainW });
        }

        private void ChangePlayer0SizeInvoke(Control c)
        {
            mainW.PictureBox51.Location = new Point(RatioX(325), RatioY(419));
            mainW.PictureBox9.Location = new Point(RatioX(257), RatioY(429));
            mainW.PictureBox10.Location = new Point(RatioX(265), RatioY(429));



        }

        public void ChangePlayer1Size()
        {
            mainW.Invoke(new DelegateAjob(ChangePlayer1SizeInvoke), new object[] { mainW });
        }

        private void ChangePlayer1SizeInvoke(Control c)
        {
            mainW.PictureBox18.Location = new Point(RatioX(367), RatioY(337));
            mainW.PictureBox11.Location = new Point(RatioX(292), RatioY(319));
            mainW.PictureBox12.Location = new Point(RatioX(300), RatioY(319));



        }

        public void ChangePlayer2Size()
        {
            mainW.Invoke(new DelegateAjob(ChangePlayer2SizeInvoke), new object[] { mainW });
        }

        private void ChangePlayer2SizeInvoke(Control c)
        {
            mainW.PictureBox23.Location = new Point(RatioX(457), RatioY(296));
            mainW.PictureBox15.Location = new Point(RatioX(435), RatioY(228));
            mainW.PictureBox16.Location = new Point(RatioX(443), RatioY(228));



        }
        public void ChangePlayer3Size()
        {
            mainW.Invoke(new DelegateAjob(ChangePlayer3SizeInvoke), new object[] { mainW });
        }

        private void ChangePlayer3SizeInvoke(Control c)
        {
            mainW.PictureBox24.Location = new Point(RatioX(575), RatioY(262));
            mainW.PictureBox22.Location = new Point(RatioX(592), RatioY(218));
            mainW.PictureBox21.Location = new Point(RatioX(600), RatioY(218));



        }
        public void ChangePlayer4Size()
        {
            mainW.Invoke(new DelegateAjob(ChangePlayer4SizeInvoke), new object[] { mainW });
        }

        private void ChangePlayer4SizeInvoke(Control c)
        {
            mainW.PictureBox27.Location = new Point(RatioX(782), RatioY(296));
            mainW.PictureBox29.Location = new Point(RatioX(827), RatioY(239));
            mainW.PictureBox30.Location = new Point(RatioX(835), RatioY(239));



        }

        public void ChangePlayer5Size()
        {
            mainW.Invoke(new DelegateAjob(ChangePlayer5SizeInvoke), new object[] { mainW });
        }

        private void ChangePlayer5SizeInvoke(Control c)
        {
            mainW.PictureBox28.Location = new Point(RatioX(904), RatioY(357));
            mainW.PictureBox36.Location = new Point(RatioX(965), RatioY(316));
            mainW.PictureBox35.Location = new Point(RatioX(973), RatioY(316));
        }

        public void ChangePlayer6Size()
        {
            mainW.Invoke(new DelegateAjob(ChangePlayer6SizeInvoke), new object[] { mainW });
        }

        private void ChangePlayer6SizeInvoke(Control c)
        {
            mainW.PictureBox34.Location = new Point(RatioX(909), RatioY(462));
            mainW.PictureBox41.Location = new Point(RatioX(996), RatioY(486));
            mainW.PictureBox42.Location = new Point(RatioX(1003), RatioY(486));
        }


        public void ChangePlayer7Size()
        {
            mainW.Invoke(new DelegateAjob(ChangePlayer7SizeInvoke), new object[] { mainW });
        }

        private void ChangePlayer7SizeInvoke(Control c)
        {
            mainW.PictureBox39.Location = new Point(RatioX(818), RatioY(538));
            mainW.PictureBox47.Location = new Point(RatioX(875), RatioY(603));
            mainW.PictureBox48.Location = new Point(RatioX(883), RatioY(603));
        }

        public void ChangePlayer8Size()
        {
            mainW.Invoke(new DelegateAjob(ChangePlayer8SizeInvoke), new object[] { mainW });
        }

        private void ChangePlayer8SizeInvoke(Control c)
        {
            mainW.PictureBox44.Location = new Point(RatioX(598), RatioY(555));
            mainW.PictureBox53.Location = new Point(RatioX(598), RatioY(618));
            mainW.PictureBox54.Location = new Point(RatioX(606), RatioY(618));
        }
        public void ChangePlayer9Size()
        {
            mainW.Invoke(new DelegateAjob(ChangePlayer9SizeInvoke), new object[] { mainW });
        }

        private void ChangePlayer9SizeInvoke(Control c)
        {
            mainW.PictureBox45.Location = new Point(RatioX(363), RatioY(521));
            mainW.PictureBox59.Location = new Point(RatioX(293), RatioY(556));
            mainW.PictureBox60.Location = new Point(RatioX(301), RatioY(556));
        }
    }
}
