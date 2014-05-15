using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PokerGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            I.Initialize();
            //Table t = new Table(this);
            //t.Text = listView1.SelectedItems[0].SubItems[1].Text + "   " + listView1.SelectedItems[0].SubItems[2].Text;
            //t.Show();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());
            Application.Run(new Game());
        }
    }
}
