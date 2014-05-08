using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poker
{
    public abstract class Player : GameResetInterface
    {
        public event EventHandler Move;

        public String Name { get; set; }
        public int Stack { get; set; }
        public int stepBet { get; set; }
        public int roundBet { get; set; }
        public bool WaitForNextHand = false;
        public bool AllIn = false;
        public Combination cards;
        public List<Card> hand;

        public Timer timer;
        protected GameControl game;

        public void setHand(Card c1, Card c2)
        {
            if (hand.Count != 0) hand.Clear();
            hand.Add(c1);
            hand.Add(c2);
            hand.Sort();
        }
        public static List<Card> getHand(Player p) { return p.hand; }
        public void foldcards()
        {
            cards.CleanCombination();
            hand.Clear();
        }
        public void TakeBestCards(List<Card> tablecards)
        {
            List<Card> allcards = new List<Card>(7);
            allcards.AddRange(tablecards);
            allcards.AddRange(hand);

            if (tablecards.Count > 3)
            {
                Combination buffer;

                if (allcards.Count == 6)
                {
                    buffer = new Combination();
                    for (int i = 0; i < 5; i++) buffer.InsertCard(allcards[i]);
                    buffer = buffer.ImproveIfPossible(allcards[5]);
                    cards.CleanCombination();
                    cards.InsertCard(buffer.GetCards());
                    buffer = null;
                }
                else
                {
                    Combination strongest = new Combination(cards.GetCards());
                    int j = 1;
                    for (int i = 0; i < allcards.Count - 1; i++)
                    {
                        while (i + j < allcards.Count)
                        {
                            buffer = new Combination();
                            for (int k = 0; k < allcards.Count; k++)
                            {
                                if ((k != i) && (k != j)) buffer.InsertCard(allcards[k]);
                            }
                            if (Combination.Compare(buffer, strongest) > 0)
                            {
                                strongest.CleanCombination();
                                strongest.InsertCard(buffer.GetCards());
                            }
                            buffer = null;
                            j++;
                        }
                    }
                    List<Card> leftcards = new List<Card>();
                    foreach (Card c in allcards)
                        if (!strongest.GetCards().Contains(c)) leftcards.Add(c);
                    strongest = strongest.ImproveIfPossible(leftcards[0]);
                    strongest = strongest.ImproveIfPossible(leftcards[1]);
                    cards.InsertCard(strongest.GetCards());
                }


            }
            else
            {
                List<Card> buffer = new List<Card>(5);
                buffer = cards.GetCards();
                for (int i = 0; i < allcards.Count; i++)
                    if (!buffer.Contains(allcards[i])) cards.InsertCard(allcards[i]);
            }

        }

        public Player(String _name, int _stack, GameControl _game)
        {
            timer = new Timer();
            cards = new Combination();
            hand = new List<Card>(2);

            game = _game;
            Name = _name;
            Stack = _stack;
            Subscribe(game);
        }

        public abstract void table_BatonMoved(object sender, EventArgs e);
        public void OnMove(MoveEventArgs e)
        {
            EventHandler move = Move;
            if (move != null) move(this, e);
        }

        #region Члены GameResetInterface

        public void Unsubscribe(GameControl game)
        {
            game.DeliveryBatonToPlayer -= new EventHandler(table_BatonMoved);
            timer.Enabled = false;
        }

        public void Subscribe(GameControl game)
        {
            game.DeliveryBatonToPlayer += new EventHandler(table_BatonMoved);
        }

        public void ReInitialize()
        {
            cards.CleanCombination();
            hand.Clear();
        }

        #endregion
    }

    public class Human : Player
    {
        public Human(String _name, int _stack, GameControl game)
            : base(_name, _stack, game)
        {
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Enabled = false;
            OnMove(new MoveEventArgs(Movements.Check, 0, this));
        }

        public override void table_BatonMoved(object sender, EventArgs e)
        {
            UpdateControlsArgs args = e as UpdateControlsArgs;
            if ((this == args.player) && (args.player.AllIn))
            {
                if (timer.Enabled == true) return;
                else timer.Enabled = true;
                timer.Interval = 1000;
                timer.Start();
            }
        }
    }

    class AIPlayer : Player
    {
        private int toCall = 0;
        private int sblind = 0;
        public AIPlayer(String _name, int _stack, GameControl game)
            : base(_name, _stack, game)
        { timer.Tick += new EventHandler(timer_Tick); }

        public override void table_BatonMoved(object sender, EventArgs e)
        {
            UpdateControlsArgs args = e as UpdateControlsArgs;
            if (this == args.player)
            {
                Random random = new Random();
                toCall = args.toCall;
                sblind = args.sblind;
                if (timer.Enabled == true) return;
                else timer.Enabled = true;
                timer.Interval = random.Next(1, 5) * 1000;
                timer.Start();
            }
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Enabled = false;
            MakeMove();
        }
        public void MakeMove()
        {
            int move = 0;
            if (game.table.cards.Count == 0)
            {
                double k = AnalizeHand() + AnalizeMoves();
                move = (k < 2.25) ? ((k > 1.25) ? 2 : 0) : 3;
            }
            else
            {
                double k = AnalizeCombination() + AnalizeMoves();
                move = (k < 2.25) ? ((k > 1.25) ? 2 : 0) : 3;
            }
            if (AllIn) move = 1;
            switch (move)
            {
                case 0:
                    {
                        if (toCall != 0) OnMove(new MoveEventArgs(Movements.Fold, 0, this));
                        else OnMove(new MoveEventArgs(Movements.Check, 0, this));
                        break;
                    }
                case 1:
                    {
                        if ((toCall == stepBet) || (Stack == 0))
                            OnMove(new MoveEventArgs(Movements.Check, 0, this));
                        else OnMove(new MoveEventArgs(Movements.Call, toCall - stepBet, this));
                        break;
                    }
                case 2:
                    {
                        if (toCall != stepBet)
                            if (toCall < Stack)
                                OnMove(new MoveEventArgs(Movements.Call, toCall - stepBet, this));
                            else OnMove(new MoveEventArgs(Movements.Call, Stack, this));
                        else OnMove(new MoveEventArgs(Movements.Check, 0, this));
                        break;
                    }
                case 3:
                    {
                        if (toCall < Stack - sblind * 3 * 2)
                            OnMove(new MoveEventArgs(Movements.Raise, toCall - stepBet + sblind * 3 * 2, this));
                        else OnMove(new MoveEventArgs(Movements.Call, Stack, this));

                        break;
                    }
            }
        }
        private double AnalizeHand()
        {
            bool pair = false;
            bool suited = false;
            bool connected = false;
            bool monster = false;
            hand.Sort();
            double result = 0;

            if (hand[0] == hand[1]) pair = true;
            else
            {
                if ((int)hand[0].Rank - (int)hand[1].Rank <= 2) connected = true;
                if (hand[0].Suit == hand[1].Suit) suited = true;
            }

            if (pair)
            {
                if (hand[0].Rank >= Ranks.Six)
                    if (hand[0].Rank >= Ranks.J) monster = true;
                    else result = 0.7 + (double)hand[0].Rank / 52;
            }
            else if (suited && connected)
            {
                if (hand[0].Rank == Ranks.A) monster = true;
                else if (hand[0].Rank >= Ranks.Ten) result = 0.5 + (int)hand[0].Rank / 52;
                else result = 0.5 + (double)hand[0].Rank / 52;
            }
            else
            {
                if ((hand[0].Rank == Ranks.A) && (hand[1].Rank >= Ranks.J)) result = 1;
                else if ((hand[0].Rank >= Ranks.J) && (hand[1].Rank >= Ranks.Ten)) result = 0.3 + (int)hand[1].Rank / 52;
                else result = (double)hand[0].Rank / 52 + (double)hand[1].Rank / 52;
            }

            if (monster) result = 1.5;
            return result;
        }
        private double AnalizeMoves()
        {

            Movements move = game.table.gamelog.getMove(0).move;
            int timesCall = (game.table.gamelog.CountMoves(Movements.Call, true));
            int timesRaise = (game.table.gamelog.CountMoves(Movements.Raise, true));

            if (move == Movements.Call) return 1.5/timesCall;
            if (move == Movements.Raise) return 0.75 / timesRaise;
            if (move == Movements.BigBlind) return 1;
            if (move == Movements.Check) return 1.1;
            return 0;
        }
        private double AnalizeCombination()
        {
            double result = 0;
            Combination test = new Combination(game.table.cards);
            test.CountCombination();
            test.Rebuild();
            bool wettable = Combination.Compare(cards, test) <= 0;
            switch (cards.combination)
            {
                case Combinations.StreightFlash: 
                    {
                        if (!wettable) result = 1.5;
                        else result = 1;
                        break; 
                    }
                case Combinations.Kare:
                    {
                        if (!wettable) result = 1.5;
                        else result = 1;
                        break;
                    }
                case Combinations.FullHouse:
                    {
                        if (!wettable) result = 1.4;
                        else result = 0.9;
                        break;
                    }
                case Combinations.Flash:
                    {
                        if (!wettable) result = 1.3;
                        else result = 0.8;
                        break;
                    }
                case Combinations.Streight:
                    {
                        if (!wettable) result = 1.2;
                        else result = 0.7;
                        break;
                    }
                case Combinations.Tree:
                    {
                        if (!wettable) result = 1.1;
                        else result = 0.6;
                        break;
                    }
                case Combinations.TwoPairs:
                    {
                        if (!wettable) result = 1;
                        else result = 0.5;
                        break;
                    }
                case Combinations.Pair:
                    {
                        if (!wettable) result = 0.8;
                        else result = 0.3;
                        break;
                    }
                case Combinations.HighCard:
                    {
                        if (!wettable) result = 0.6;
                        else result = 0.1;
                        break;
                    }
            }
            return result;
        }


    }
}
