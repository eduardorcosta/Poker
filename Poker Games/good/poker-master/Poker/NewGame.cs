using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poker
{
    public partial class NewGame : Form
    {
        public event EventHandler NewGameInit;

        public NewGame()
        {
            InitializeComponent();
        }

        public void OnNewGameInit(GameInitArgs e)
        {
            EventHandler newgameinit = NewGameInit;
            if (newgameinit != null) newgameinit(this, e);
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            Close();
            OnNewGameInit(new GameInitArgs(2, (int)nudInitStack.Value, tbName.Text));
        }
    }

}
