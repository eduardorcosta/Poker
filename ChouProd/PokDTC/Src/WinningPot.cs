using System;
using System.Collections;
using System.Text;

namespace poker
{
    class WinningPot
    {
        private long amount_pot = 0;
        private bool lonely = true;

        public bool Lonely
        {
            get { return lonely; }
            set { lonely = value; }
        }
        public long Amount_pot
        {
            get { return amount_pot; }
            set { amount_pot = value; }
        }
        private long amount_2_win = 0;

        public long Amount_2_win
        {
            get { return amount_2_win; }
            set { amount_2_win = value; }
        }
        private ArrayList candidate;

        public ArrayList Candidate
        {
            get { return candidate; }
            set { candidate = value; }
        }
        private ArrayList winners;

        public ArrayList Winners
        {
            get { return winners; }
            set { winners = value; }
        }

        public WinningPot() {


            candidate = new ArrayList();
            winners = new ArrayList();
        }

    }
}
