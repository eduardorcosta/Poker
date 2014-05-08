using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poker
{
    public enum Ranks
    {
        A = 14, K = 13, Q = 12, J = 11,
        Ten = 10, Nine = 9, Eight = 8, Seven = 7, Six = 6,
        Five = 5, Four = 4, Tree = 3, Two = 2
    }
    public enum Suits { Hearts, Diamonds, Clubs, Spades }
    public enum Combinations
    {
        Uknown = 0, HighCard = 1, Pair = 2, TwoPairs = 3, Tree = 4,
        Streight = 5, Flash = 6, FullHouse = 7, Kare = 8, StreightFlash = 9
    }
    public enum Movements { Fold = 0, Check = 1, Call = 2, Raise = 3, Win = 4, NewHand = 5, SmallBlind = 6, BigBlind = 7, WinHandsUp = 8, NewStep = 9 }

    public class Table : GameResetInterface
    {
        public event EventHandler HandsUp;
        public event EventHandler BatonMoved;
        public event EventHandler CardsChanged;
        public event EventHandler GameEnd;

        public List<Player> players { get; private set; }
        public List<Card> cards { get; private set; }
        public CardDeck carddeck;
        public int Baton { get; set; }
        public int Bank { get; protected set; }
        public int sblind { get; protected set; }
        public int roundnum { get; protected set; }

        public GameLog gamelog;
        public Human mainplayer;

        public void NewHand()
        {
            players[0].OnMove(new MoveEventArgs(Movements.NewHand, 0, players[0]));
            Baton = 1;
            cards.Clear();
            carddeck.Reset();

            foreach (Player p in players)
            {
                p.setHand(carddeck.TakeNextCard(), carddeck.TakeNextCard());
                p.WaitForNextHand = false;
                p.AllIn = false;
                p.stepBet = 0;
            }
            OnCardsChanged(new EventArgs());

            players[1].OnMove(new MoveEventArgs(Movements.SmallBlind, sblind, players[1]));
            players[0].OnMove(new MoveEventArgs(Movements.BigBlind, sblind * 2, players[0]));

            OnBatonMoved(new ActionEventArgs(players[Baton]));
        }
        public void NewDiller()
        {
            Player buffer = players[0];
            players.RemoveAt(0);
            players.Add(buffer);
        }
        public void NextStep()
        {
            foreach (Player p in players) p.stepBet = 0;
            switch (cards.Count)
            {
                case 0:
                    {
                        cards.Add(carddeck.TakeNextCard());
                        cards.Add(carddeck.TakeNextCard());
                        cards.Add(carddeck.TakeNextCard());
                        mainplayer.OnMove(new MoveEventArgs(Movements.NewStep, 0, mainplayer));
                        break;
                    }
                case 5:
                    {
                        FinishHand();
                        return;
                    }
                default:
                    {
                        cards.Add(carddeck.TakeNextCard());
                        mainplayer.OnMove(new MoveEventArgs(Movements.NewStep, 0, mainplayer));
                        break;
                    }
            }
            OnCardsChanged(new EventArgs());
            foreach (Player p in players) if (!p.WaitForNextHand) p.TakeBestCards(cards);
        }
        public void FinishHand()
        {
            List<Player> winners = new List<Player>();
            Combination comb = new Combination();
            foreach (Player p in players)
                if (!p.WaitForNextHand)
                {
                    p.TakeBestCards(cards);
                    p.cards.Rebuild();
                    if (Combination.Compare(p.cards, comb) > 0) comb = p.cards;
                }

            foreach (Player p in players)
                if ((p.cards == comb) && (!p.WaitForNextHand)) winners.Add(p);

            int winsum = 0;
            if (winners.Count == 1)
            {
                foreach (Player p in winners)
                {
                    if ((cards.Count == 5) && (gamelog.getMove(0).move != Movements.Fold))
                    {
                        if (p.roundBet < Bank / 2)
                        {
                            winsum = p.roundBet * 2;
                            p.Stack += winsum;
                            Bank -= winsum;
                            int k = players.IndexOf(p);
                            if (k == 0) players[1].Stack += Bank;
                            else players[0].Stack += Bank;
                        }
                        else
                        {
                            winsum = Bank;
                            p.Stack += winsum;
                        }
                            p.OnMove(new MoveEventArgs(Movements.WinHandsUp, winsum, p));
                        OnHandsUp(new EventArgs());
                    }
                    else
                    {
                        p.Stack += Bank;
                        p.OnMove(new MoveEventArgs(Movements.Win, Bank, p));
                    }
                }
            }
            else
            {
                players[0].Stack += Bank / 2;
                players[1].Stack += Bank / 2;
                players[0].OnMove(new MoveEventArgs(Movements.WinHandsUp, Bank / 2, players[2]));
                players[1].OnMove(new MoveEventArgs(Movements.WinHandsUp, Bank / 2, players[1]));
            }
            Bank = 0;
            roundnum++;
            if (roundnum % 4 == 0) sblind += 2;
            foreach (Player p in players)
            {
                p.foldcards();
                p.roundBet = 0;
            }
            cards.Clear();

            if ((players[0].Stack == 0)||((players[1].Stack == 0))) { OnGameEnd(new EventArgs()); return; }
            NewDiller();
            NewHand();
        }
        public int HowMuchToCall()
        {
            int result = 0;
            foreach (Player p in players)
                if (!p.WaitForNextHand)
                    if (p.stepBet > result) result = p.stepBet;
            return result;
        }
        public Player WhoIs(string playerName)
        {
            if (players[0].Name == playerName) return players[0];
            else return players[1];
        }
        public Table(int numplay, String _playername, int initstack, GameControl game)
        {
            players = new List<Player>(2);
            cards = new List<Card>(5);
            carddeck = new CardDeck();

            players.Add(new Human(_playername, initstack, game));
            mainplayer = (Human)players[0];
            gamelog = new GameLog();

			players.Add(new AIPlayer("AI Player", initstack, game));
            sblind = 2;
            roundnum = 1;
        }

        private void game_PlayerMoved(object sender, EventArgs e)
        {
            MoveEventArgs moveargs = e as MoveEventArgs;

            if ((moveargs.move != Movements.Win) && (moveargs.move != Movements.WinHandsUp))
            {
                if (moveargs.Sum < moveargs.player.Stack)
                {
                    Bank += moveargs.Sum;
                    moveargs.player.stepBet += moveargs.Sum;
                    moveargs.player.Stack -= moveargs.Sum;
                    moveargs.player.roundBet += moveargs.Sum;
                }
                else
                {
                    Bank += moveargs.player.Stack;
                    moveargs.player.stepBet += moveargs.player.Stack;
                    moveargs.player.roundBet += moveargs.player.Stack;
                    moveargs.player.Stack = 0;
                    if (moveargs.player.Stack == 0) moveargs.player.AllIn = true;
                   
                }
            }

            switch (moveargs.move)
            {
                case Movements.Fold:
                    {
                        moveargs.player.WaitForNextHand = true;
                        break;
                    }
                case Movements.Win:
                    {
					MessageBox.Show(moveargs.player.Name + " ganhou a mao!", "vitoria!");
                        return;
                    }
                case Movements.WinHandsUp:
                    {

                        return;
                    }
                case Movements.NewHand: { return; }
                case Movements.SmallBlind: { return; }
                case Movements.BigBlind: { return; }
            }
        }
        private void game_MoveEnd(object sender, EventArgs e)
        {
            MoveEventArgs moveargs = e as MoveEventArgs;
            if ((int)moveargs.move > 3)
                return;

            if (moveargs.move == Movements.Fold)
            {
                int active = 0;
                foreach (Player p in players) if (p.WaitForNextHand == false) active++;
                if (active == 1)
                {
                    FinishHand();
                    return;
                }
            }

            if (gamelog.getMove(1).player.AllIn)
            {
                moveargs.player.AllIn = true;
                OnHandsUp(new EventArgs());
            }
            bool retry_step = false;
            int toCall = HowMuchToCall();
            if (toCall != 0)
                foreach (Player p in players)
                    if ((p.stepBet != toCall) && (!p.AllIn))
                        retry_step = true;


            if (retry_step)
            {
                for (int i = 0; i < players.Count; i++)
                    if (players[i].stepBet != toCall)
                    {
                        Baton = players.IndexOf(players[i]);
                        break;
                    }
            }
            else
            {
                if (((Baton == 0) && (cards.Count == 0))
                    || ((Baton == 0) && (cards.Count > 0))
                    || ((moveargs.move == Movements.Call) && (gamelog.getMove(1).move == Movements.Raise)))
                {
                    bool flag = (cards.Count == 5);
                    NextStep();
                    if (flag) return;
                    Baton = 1;
                }
                else if (Baton == 1) Baton = 0;
                else Baton = 1;
            }


            if ((gamelog.getMove(0).move != Movements.SmallBlind)
                && (gamelog.getMove(0).move != Movements.WinHandsUp))
                OnBatonMoved(new ActionEventArgs(players[Baton]));

        }

        private void OnCardsChanged(EventArgs e)
        {
            EventHandler cardschanged = CardsChanged;
            if (cardschanged != null) cardschanged(this, e);
        }
        private void OnHandsUp(EventArgs e)
        {
            EventHandler handsup = HandsUp;
            if (handsup != null) handsup(this, e);
        }
        private void OnBatonMoved(ActionEventArgs e)
        {
            EventHandler batonmoved = BatonMoved;
            if (batonmoved != null) batonmoved(this, e);
        }
        private void OnGameEnd(EventArgs e)
        {
            EventHandler end = GameEnd;
            if (end != null) end(this, e);
        }

        #region Члены GameResetInterface

        public void Unsubscribe(GameControl game)
        {
            foreach (Player p in players) p.Unsubscribe(game);
            game.UpdateBank -= new EventHandler(game_PlayerMoved);
            game.MoveEnd -= new EventHandler(game_MoveEnd);
            gamelog.Unsubscribe(game);
        }

        public void Subscribe(GameControl game)
        {
            foreach (Player p in players) p.Subscribe(game);
            game.UpdateBank += new EventHandler(game_PlayerMoved);
            game.MoveEnd += new EventHandler(game_MoveEnd);
            gamelog.Subscribe(game);
        }

        public void ReInitialize()
        {
            players[0].ReInitialize();
            players[1].ReInitialize();
            gamelog.ReInitialize();
            sblind = 2;
            roundnum = 1;
        }

        #endregion


    }
   
}
