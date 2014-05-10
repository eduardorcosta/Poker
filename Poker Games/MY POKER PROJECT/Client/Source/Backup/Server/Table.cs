using System;
using System.Collections.Generic;
using System.Threading;

namespace Server
{
    class Table
    {
        string name;
        int size;
        CircularLinkedList<Client> players;
        List<Client> spectators;
        List<Client> waitingplayers;
        int blind;
        Deck deck;
        int pot = 0;
        int bet = 0;
        string com;
        string history = "";
        int count;
        Node<Client> button;
        Node<Client> last;
        Node<Client> playerturn;
        Card[] community = new Card[5];
        Thread game;

        public Table(string Name, int Size, int SmallBlind)
        {
            name = Name;
            size = Size;
            players = new CircularLinkedList<Client>();
            spectators = new List<Client>();
            waitingplayers = new List<Client>();
            blind = SmallBlind;
        }

        public int FindNextSeat()
        {
            for (int i = 0; i < size; i++)
            {
                bool check = true;
                foreach (Client p in players)
                    if (p.Position == i)
                        check = false;
                foreach (Client p in waitingplayers)
                    if (p.Position == i)
                        check = false;
                if (check)
                    return i;
            }
            return 0;
        }

        public void Add(Client p)
        {
            p.Position = FindNextSeat();
            waitingplayers.Add(p);
            Inform("Joined$" + p.Position + "$" + p.Name + "$" + p.Money + "$");
            if (waitingplayers.Count + players.Count > 1)
                if (game == null)
                {
                    game = new Thread(Game);
                    game.Start();
                }
                else if (!game.IsAlive)
                {
                    game = new Thread(Game);
                    game.Start();
                }
            try
            {
                string rec;
                while ((rec = p.Reader.ReadLine()) != "Stand$")
                    if (playerturn.Value == p)
                        com = rec;
                spectators.Add(p);
            }
            catch
            {
                if (playerturn.Value == p)
                {
                    com = "Fold$";
                    Thread.Sleep(500);
                }
                p.Disconnect();
            }
            finally
            {
                if (p.Pocket[0].Value != 0)
                    deck.Add(p.Pocket);
                Remove(p);
            }
        }

        public void Remove(Client p)
        {
            if (waitingplayers.Contains(p))
                waitingplayers.Remove(p);
            else
                players.Remove(p);
            Inform("Left$" + p.Position + "$");
            if (game != null)
                if (game.IsAlive && players.Count + waitingplayers.Count < 2)
                    game.Abort();
        }

        public void Spectate(Client s)
        {
            string tmp = null;
            foreach (Client p in players)
                tmp += "Sitting$" + p.Position + "$" + p.Name + "$" + (p.Money + p.InRoundMoney) + "$@";
            foreach (Client p in waitingplayers)
                tmp += "Joined$" + p.Position + "$" + p.Name + "$" + p.Money + "$@";
            s.Writer.WriteLine(tmp);
            s.Writer.WriteLine(history);
            spectators.Add(s);
            try
            {
                string rec;
                while ((rec = s.Reader.ReadLine()) != "Leave$")
                    if (rec == "Sit$")
                        if (players.Count + waitingplayers.Count < size && s.Money > 10 * blind)
                        {
                            spectators.Remove(s);
                            Add(s);
                        }
                s.Writer.WriteLine("Removed$");
            }
            catch
            {
                s.Disconnect();
            }
            finally
            {
                spectators.Remove(s);
            }
        }

        public void Game()
        {
            try
            {
                deck = new Deck();
                AddToGame();
                Button();
                Inform("Button$" + button.Value.Position + "$");
                button = button.Previous;
                while (true)
                {
                    deck.Shuffle();
                    AddToGame();
                    foreach (Client p in players)
                    {
                        p.Hefresh = 0;
                        if (p.Money < 4 * blind)
                            p.Writer.WriteLine("Kick$");
                    }
                    history = null;
                    Collect();
                    Thread.Sleep(1000);
                    button = button.Next;
                    Inform("Dealer$" + button.Value.Position + "$");
                    Deal();
                    last = button.Next.Next;
                    playerturn = button.Next.Next.Next;
                    count = players.Count;
                    Blinds();
                    bet = 2 * blind;
                    do
                    {
                        PlayerMove(playerturn.Value);
                    } while (last.Next != playerturn || count > 1);
                    if ((count = players.Count) < 2) { EarlyWin(); continue; }
                    Collect();
                    Flop();
                    last = button;
                    playerturn = button.Next;
                    bet = 0;
                    do
                    {
                        PlayerMove(playerturn.Value);
                    } while (last.Next != playerturn || count > 1);
                    if ((count = players.Count) < 2) { EarlyWin(); continue; }
                    Collect();
                    Turn();
                    last = button;
                    playerturn = button.Next;
                    bet = 0;
                    do
                    {
                        PlayerMove(playerturn.Value);
                    } while (last.Next != playerturn || count > 1);
                    if ((count = players.Count) < 2) { EarlyWin(); continue; }
                    Collect();
                    River();
                    last = button;
                    playerturn = button.Next;
                    bet = 0;
                    do
                    {
                        PlayerMove(playerturn.Value);
                    } while (last.Next != playerturn || count > 1);
                    if ((count = players.Count) < 2) { EarlyWin(); continue; }
                    Collect();
                    Showdown();
                    Thread.Sleep(2000);
                }
            }
            catch (ThreadAbortException)
            {
                EarlyWin();
                waitingplayers.Add(players.Head.Value);
                players.Clear();
            }
        }

        public void AddToGame()
        {
            foreach (Client p in waitingplayers)
                players.AddLast(p);
            waitingplayers.Clear();
        }

        public void Button()
        {
            Random rand = new Random();
            button = players.Head;
            for (int i = rand.Next(players.Count); i > 0; i--)
                button = button.Next;
        }

        public void Blinds()
        {
            button.Next.Value.Money -= blind;
            button.Next.Value.InRoundMoney += blind;
            pot += blind;
            Inform("SmallBlind$" + button.Next.Value.Position + "$" + blind + "$");
            button.Next.Next.Value.Money -= 2*blind;
            button.Next.Next.Value.InRoundMoney += 2*blind;
            pot += 2 * blind;
            Inform("BigBlind$" + button.Next.Next.Value.Position + "$" + 2*blind + "$");
        }

        public void Deal()
        {
            foreach (Client p in players)
            {
                p.Pocket[0] = deck.Draw();
                p.Writer.WriteLine("Pocket$0$" + p.Pocket[0]);
                p.Pocket[1] = deck.Draw();
                p.Writer.WriteLine("Pocket$1$" + p.Pocket[1]);
            }
        }

        public void Flop()
        {
            community[0] = deck.Draw();
            community[1] = deck.Draw();
            community[2] = deck.Draw();
            Inform("Community$0$" + community[0]);
            Inform("Community$1$" + community[1]);
            Inform("Community$2$" + community[2]);
        }

        public void Turn()
        {
            community[3] = deck.Draw();
            Inform("Community$3$" + community[3]);
        }

        public void River()
        {
            community[4] = deck.Draw();
            Inform("Community$4$" + community[4]);
        }

        public void Showdown()
        {
            foreach (Client p in players)
            {
                Inform("Hand$" + p.Position + "$" + p.Pocket[0] + p.Pocket[1]);
                p.Hefresh = pot - p.Hefresh;
            }
            while (true)
            {
                Card[] tmp = Comparison.BestPossibleHand(players.Head.Value.Pocket, community);
                Client winner = players.Head.Value;
                foreach (Client i in players)
                {
                    Card[] candidate = Comparison.CompareHands(
                        tmp,
                        Comparison.BestPossibleHand(i.Pocket, community));
                    if (tmp != candidate)
                    {
                        tmp = candidate;
                        winner = i;
                    }
                }
                if (winner.Hefresh < 0)
                {
                    players.Remove(winner);
                    waitingplayers.Add(winner);
                }
                else if (pot - winner.Hefresh > 0)
                {
                    Thread.Sleep(6000);
                    Inform("SidePot$" + winner.Position + "$" + winner.Hefresh + "$");
                    winner.Money += winner.Hefresh;
                    pot -= winner.Hefresh;
                    players.Remove(winner);
                    waitingplayers.Add(winner);
                    foreach (Client p in players)
                        p.Hefresh -= winner.Hefresh;
                }
                else
                {
                    Thread.Sleep(6000);
                    winner.Money += pot;
                    Inform("Win$" + winner.Position + "$" + pot + "$");
                    break;
                }
            }

            foreach (Client i in players)
                deck.Add(i.Pocket);
            foreach (Client i in waitingplayers)
                if (i.Pocket[0].Value != 0)
                    deck.Add(i.Pocket);
            deck.Add(this.community);
            Array.Clear(community, 0, 5);
            pot = 0;
            history = "";
        }

        public void EarlyWin()
        {
            players.Head.Value.Money += pot;
            if (players.Count + waitingplayers.Count > 1)
                Thread.Sleep(2000);
            Inform("Win$" + players.Head.Value.Position + "$" + pot + "$");
            foreach (Client i in players)
                deck.Add(i.Pocket);
            foreach (Client i in waitingplayers)
                if (i.Pocket[0].Value != 0)
                    deck.Add(i.Pocket);
            foreach (Card i in community)
                if (i.Value != 0)
                    deck.Add(i);
            Array.Clear(community, 0, 5);
            pot = 0;
            history = "";
        }

        public void PlayerMove(Client p)
        {
            if (p.Money > 0)
            {
                Thread.Sleep(2000);
                p.Writer.WriteLine("Waiting$" + bet + "$" + p.InRoundMoney + "$");
                Inform("Playing$" + p.Position + "$");
                DateTime starttime = DateTime.Now;
                while (com == null && (DateTime.Now - starttime).Seconds < 15) ;
                try
                {
                    string[] command = new string[2];
                    for (int i = 0; com.IndexOf('$') != -1; i++)
                    {
                        command[i] = com.Substring(0, com.IndexOf('$'));
                        com = com.Remove(0, com.IndexOf('$') + 1);
                    }
                    switch (command[0])
                    {
                        case "Call":
                            if (bet - p.InRoundMoney == 0)
                                Inform("Check$" + p.Position + "$");
                            else
                            {
                                p.Money -= bet - p.InRoundMoney;
                                pot += bet - p.InRoundMoney;
                                Inform("Call$" + p.Position + "$" + (bet - p.InRoundMoney) + "$");
                                p.InRoundMoney = bet;
                            }
                            break;
                        case "Raise":
                            int amount = int.Parse(command[1]);
                            if (p.Money > amount && amount + p.InRoundMoney >= 2 * bet && amount >= 2 * blind)
                            {
                                p.Money -= amount;
                                pot += amount;
                                p.InRoundMoney += amount;
                                bet = p.InRoundMoney;
                                last = playerturn.Previous;
                                Inform("Raise$" + p.Position + "$" + amount + "$" + bet + "$");
                            }
                            else throw new Exception();
                            break;
                        case "AllIn":
                            pot += p.Money;
                            p.InRoundMoney += p.Money;
                            p.Money = 0;
                            if (bet < p.InRoundMoney)
                            {
                                bet = p.InRoundMoney;
                                last = playerturn.Previous;
                            }
                            Inform("AllIn$" + p.Position + "$");
                            break;
                        default:
                            throw new Exception();
                    }
                }
                catch
                {
                    players.Remove(p);
                    waitingplayers.Add(p);
                    Inform("Fold$" + p.Position + "$");
                }
            }
            count--;
            com = null;
            playerturn = playerturn.Next;
        }

        public void Collect()
        {
            foreach (Client n in players)
                foreach (Client i in players)
                    if (n.Money == 0 && i.InRoundMoney > n.InRoundMoney)
                        n.Hefresh += i.InRoundMoney - n.InRoundMoney;
            foreach (Client p in players)
                p.InRoundMoney = 0;
        }

        public void Inform(string a)
        {
            if (a.Substring(0, 4) != "Join" && a.Substring(0, 4) != "Left") // not if Joined or Left
                history += a + "@";
            foreach (Client i in players)
                i.Writer.WriteLine(a);
            foreach (Client i in waitingplayers)
            {
                try { i.Writer.WriteLine(a); }
                catch { continue; }
            }
            foreach (Client i in spectators)
                i.Writer.WriteLine(a);
        }

        public override string ToString()
        {
            return (name + "$" + blind + "/" + 2 * blind + "$" + (players.Count + waitingplayers.Count) + "/" + size + "$");
        }
    }
}