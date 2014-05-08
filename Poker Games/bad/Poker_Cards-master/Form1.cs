using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker_Cards
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aceSpadesBox_Click(object sender, EventArgs e)
        {
            answerLabel.Text = "Ace of Spades";
        }

        private void queenHeartsBox_Click(object sender, EventArgs e)
        {
            answerLabel.Text = "Queen of Hearts";
        }

        private void blackJokerBox_Click(object sender, EventArgs e)
        {
            answerLabel.Text = "The Black Joker";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tenClubsBox_Click(object sender, EventArgs e)
        {
            answerLabel.Text = "Ten of Clubs";
        }

        private void threeDiamondsBox_Click(object sender, EventArgs e)
        {
            answerLabel.Text = "Three of Diamonds";
        }
    }
}
