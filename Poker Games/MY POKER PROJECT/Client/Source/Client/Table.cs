using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing;

namespace PokerGame
{
    class Table
    {
        int button;
        int bb;
        Player[] players = new Player[9];

        /// <summary>
        /// Todo: Melhorar
        /// </summary>
        //VoidDelegate ProcessDelegate;
        //delegate void VoidDelegate(string a);

        Game _game;

        public Table(Game game,Graphics device)
        {
            _game = game;
            players[8] = new Player(device, 175, 51);
            players[7] = new Player(device,34, 102);
            players[6] = new Player(device,0, 199);
            players[5] = new Player(device,63, 321);
            players[4] = new Player(device,316,359);
            players[3] = new Player(device,554,321);
            players[2] = new Player(device,623, 199);
            players[1] = new Player(device,545,102);
            players[0] = new Player(device,398,51);
            for (int i = 0; i < Convert.ToInt32(_game.currHand.tableSize); i++)
            {
                players[i].Name=_game.currHand.players[i].name;
                players[i].Stack=_game.currHand.players[i].stack;
            }
            game.Log.Clear();
            game.Log.AppendText(_game.currHand.tableName + " " + _game.currHand.tableSize + " max");
            /*
            for (int i = 0; i < players.Length-1; i++)
            {
                game.Controls.Add(players[i].NameAsControl);
                players[i].NameAsControl.BringToFront();
                game.Controls.Add(players[i].MoneyAsControl);
                players[i].MoneyAsControl.BringToFront();
                game.Controls.Add(players[i].HoleCard0);
                players[i].HoleCard0.BringToFront();
                game.Controls.Add(players[i].HoleCard1);
                players[i].HoleCard1.BringToFront();
                game.Controls.Add(players[i].Button);
                players[i].Button.BringToFront();
                game.Controls.Add(players[i].Action);
                players[i].Action.BringToFront();
            }/*
            string p = I.Read();
            for (int i = 0; p.IndexOf('@') != -1; i++)
            {
                Process(p.Substring(0, p.IndexOf('@')));
                p = p.Remove(0, p.IndexOf('@') + 1);
            }
            string h = I.Read();
            for (int i = 0; h.IndexOf('@') != -1; i++)
            {
                Process(h.Substring(0, h.IndexOf('@')));
                h = h.Remove(0, h.IndexOf('@') + 1);
            }*/
            
            
            
            
            ///Todo: Melhorar
            //ProcessDelegate = new VoidDelegate(Process);
            //Listener = new Thread(Listen);
            //Listener.Start();

        }
        public void Listen()
        {
            string rec;
            while ((rec = I.Read()) != "Removed$")
                try
                {
                    I.Clean();
                    ///
                    /// Todo: Melhorar
                    /// _game.Invoke(ProcessDelegate, rec);
                    //Thread.Sleep (100);//sleep(1000);
                    //rec = "";
                    Process(rec);
                }
                catch
                {
                }
        }

        public void Process(string a)
        {
            string[] command = new string[6];
            for (int i = 0; a.IndexOf('$') != -1; i++)
            {
                command[i] = a.Substring(0, a.IndexOf('$'));
                a = a.Remove(0, a.IndexOf('$') + 1);
            }
            if (command[0] == "Joined") // Joined$position$name$money$
            {
                int pos = int.Parse(command[1]);
                players[pos].Posintion = pos;
                players[pos].Name = command[2];
                players[pos].Money = int.Parse(command[3]);
                Write(players[pos].Name + " has joined the table with " + players[pos].Money + "$");
            }
            else if (command[0] == "Sitting") // Sitting$position$name$money$
            {
                int pos = int.Parse(command[1]);
                players[pos].Name = command[2];
                players[pos].Money = int.Parse(command[3]);
                players[pos].HoleCard0.Show();
                players[pos].HoleCard1.Show();
            }
            else if (command[0] == "Left") // Left$position$
            {
                int pos = int.Parse(command[1]);
                Write(players[pos].Name + " has left the table");
                players[pos].Name = "Open";
                //players[pos].MoneyAsControl.Text = "Seat";
                players[pos].HoleCard0.Hide();
                players[pos].HoleCard1.Hide();
                //players[pos].Action.Hide();
            }
            else if (command[0] == "Button") // Button$position$
            {
                int pos = int.Parse(command[1]);
                if (button == 0)
                    Write(players[pos].Name + " has been randomly chosen to be the dealer");
                button = pos;
                //players[button].Button.Show();
            }
            else if (command[0] == "Dealer") // Dealer$position$
            {
                button = int.Parse(command[1]);
                //players[button].Button.Show();
                foreach (Player p in players)
                    if (p.Name != "Open")
                    {
                        p.HoleCard0.Show();
                        p.HoleCard1.Show();
                    }
            }
            else if (command[0] == "SmallBlind") // SmallBlind$position$amount$
            {
                int pos = int.Parse(command[1]);
                int amount = int.Parse(command[2]);
                players[pos].Money -= amount;
                if (players[pos].Name == I.Name)
                    I.Money -= amount;
                _game.Pot.Text = (int.Parse(_game.Pot.Text) + amount) + "";
                Write(players[pos].Name + " has submitted a small blind of " + amount);
            }
            else if (command[0] == "BigBlind") // BigBlind$position$amount$
            {
                int pos = int.Parse(command[1]);
                int amount = int.Parse(command[2]);
                bb = amount;
                players[pos].Money -= amount;
                if (players[pos].Name == I.Name)
                    I.Money -= amount;
                _game.Pot.Text = (int.Parse(_game.Pot.Text) + amount) + "";
                Write(players[pos].Name + " has submitted a big blind of " + amount);
            }/*
            else if (command[0] == "Pocket") // Pocket$id$number(2-14)$shape(1-4)$
            {
				Image Card = Image.FromFile("Data"+Path.DirectorySeparatorChar + int.Parse(command[2]) + "_" + int.Parse(command[3]) + ".gif");
                if (command[1] == "0")
                {
                    Pocket0.BackgroundImage = Card;
                    Pocket0.Show();
                    Write("Pocket Card 1: " + Number(command[2]) + Shape(command[3]));
                }
                else
                {
                    Pocket1.BackgroundImage = Card;
                    Pocket1.Show();
                    Write("Pocket Card 2: " + Number(command[2]) + Shape(command[3]));
                }
            }*/
            else if (command[0] == "Community") // Community$id$number(2-14)$shape(1-4)$
            {
                Image Card = Image.FromFile("Data" + Path.DirectorySeparatorChar + int.Parse(command[2]) + "_" + int.Parse(command[3]) + ".gif");
                switch (command[1])
                {
                    case "0":
                        _game.Community0.BackgroundImage = Card;
                        _game.Community0.Show();
                        Write("Community Card 1: " + Number(command[2]) + Shape(command[3]));
                        break;
                    case "1":
                        _game.Community1.BackgroundImage = Card;
                        _game.Community1.Show();
                        Write("Community Card 2: " + Number(command[2]) + Shape(command[3]));
                        break;
                    case "2":
                        _game.Community2.BackgroundImage = Card;
                        _game.Community2.Show();
                        Write("Community Card 3: " + Number(command[2]) + Shape(command[3]));
                        break;
                    case "3":
                        _game.Community3.BackgroundImage = Card;
                        _game.Community3.Show();
                        Write("Community Card 4: " + Number(command[2]) + Shape(command[3]));
                        break;
                    default:
                        _game.Community4.BackgroundImage = Card;
                        _game.Community4.Show();
                        Write("Community Card 5: " + Number(command[2]) + Shape(command[3]));
                        break;
                }
            }
            else if (command[0] == "Hand") // Hand$position$number(2-14)$shape(1-4)$number(2-14)$shape(1-4)$
            {
                int pos = int.Parse(command[1]);
                players[pos].HoleCard0.BackgroundImage = Image.FromFile("Data" + Path.DirectorySeparatorChar + int.Parse(command[2]) + "_" + int.Parse(command[3]) + ".gif");
                players[pos].HoleCard1.BackgroundImage = Image.FromFile("Data" + Path.DirectorySeparatorChar + int.Parse(command[4]) + "_" + int.Parse(command[5]) + ".gif");
                Write(players[pos].Name + " shows " + Number(command[2]) + Shape(command[3]) + " " + Number(command[4]) + Shape(command[5]));
            }
            else if (command[0] == "Win") // Win$position$pot$
            {
                int pos = int.Parse(command[1]);
                int amount = int.Parse(command[2]);
                players[pos].Money += amount;
                if (players[pos].Name == I.Name)
                    I.Money += amount;
                Write(players[pos].Name + " wins a pot of " + amount + "$");
                _game.Pot.Text = "0";
                foreach (Player p in players)
                {
                    p.HoleCard0.BackgroundImage = Image.FromFile("Data" + Path.DirectorySeparatorChar + "back.jpg");
                    players[pos].HoleCard0.Show();
                    p.HoleCard1.BackgroundImage = Image.FromFile("Data" + Path.DirectorySeparatorChar + "back.jpg");
                    players[pos].HoleCard1.Show();
                    //players[pos].Action.Hide();
                }
                //players[button].Button.Hide();
                _game.HideButtons();
                _game.Community0.Hide();
                _game.Community1.Hide();
                _game.Community2.Hide();
                _game.Community3.Hide();
                _game.Community4.Hide();
                //Pocket0.Hide();
                //Pocket1.Hide();
            }
            else if (command[0] == "SidePot") // SidePot$position$amount
            {
                int pos = int.Parse(command[1]);
                int amount = int.Parse(command[2]);
                players[pos].Money += amount;
                if (players[pos].Name == I.Name)
                    I.Money += amount;
                Write(players[pos].Name + " wins a side pot of " + amount + "$");
                _game.Pot.Text = (int.Parse(_game.Pot.Text) - amount) + "";
            }
            //else if (command[0] == "Playing") // Playing$position
                //players[int.Parse(command[1])].Action.Show();
            else if (command[0] == "Waiting") // Waiting$bet$inroundmoney$
            {
                int bet = int.Parse(command[1]);
                int inround = int.Parse(command[2]);
                int tmp;
                if (bet - inround != 0)
                {
                    //Call.Text = "Call " + (bet - inround);
                    //Raise.Text = "Raise";
                    tmp = 2 * bet - inround;
                }
                else
                {
                    //Call.Text = "Check";
                    //Raise.Text = "Bet";
                    tmp = bb - inround;
                }
                //RaiseAmount.Text = tmp + "";
                //RaiseBar.Minimum = tmp;
                //RaiseBar.Maximum = I.Money;
                //RaiseBar.SmallChange = bb;
                //RaiseBar.LargeChange = 5 * bb;
                _game.ShowButtons();
                if (bet - inround > I.Money)
                {
                    // Call.Text = "All In";
                    //RaiseBar.Hide();
                    //RaiseAmount.Hide();
                    //Raise.Hide();
                }
                else if (tmp > I.Money)
                {
                    //Raise.Text = "All In";
                    //RaiseBar.Hide();
                    //RaiseAmount.Hide();
                }
                //Thread.Sleep(10000);
            }
            else if (command[0] == "Call") // Call$position$amount
            {
                int pos = int.Parse(command[1]);
                int amount = int.Parse(command[2]);
                players[pos].Money -= amount;
                _game.Pot.Text = (int.Parse(_game.Pot.Text) + amount) + "";
                Write(players[pos].Name + " calls and adds " + amount + "$ to the pot");
                //players[pos].Action.Hide();
            }
            else if (command[0] == "Raise") // Raise$position$amount$total
            {
                int pos = int.Parse(command[1]);
                int amount = int.Parse(command[2]);
                players[pos].Money -= amount;
                _game.Pot.Text = (int.Parse(_game.Pot.Text) + amount) + "";
                Write(players[pos].Name + " raises to " + int.Parse(command[3]));
                //players[pos].Action.Hide();
            }
            else if (command[0] == "Fold") // Fold$position$
            {
                int pos = int.Parse(command[1]);
                players[pos].HoleCard0.Hide();
                players[pos].HoleCard1.Hide();
                Write(players[pos].Name + " folds");
                //players[pos].Action.Hide();
            }
            else if (command[0] == "Check") // Check$position$
            {
                Write(players[int.Parse(command[1])].Name + " checks");
                //players[int.Parse(command[1])].Action.Hide();
            }
            else if (command[0] == "AllIn") // Allin$position$
            {
                int pos = int.Parse(command[1]);
                Write(players[pos].Name + " moves All-In");
                //players[pos].Action.Hide();
                _game.Pot.Text = (int.Parse(_game.Pot.Text) + players[pos].Money) + "";
                players[int.Parse(command[1])].Money = 0;
            }

            else if (command[0] == "Kick") // Kick$
            {
                I.Write("Stand$");
                ////Stand.Hide();
                //_game.button0.Show();
            }
        }

        public void Write(string a)
        {
            _game.Log.Text += a + Environment.NewLine;
            _game.Log.SelectionStart = _game.Log.Text.Length;
            _game.Log.ScrollToCaret();
        }

        public char Shape(string a)
        {
            switch (int.Parse(a))
            {
                case 1:
                    return Convert.ToChar(9824);
                case 2:
                    return Convert.ToChar(9829);
                case 3:
                    return Convert.ToChar(9830);
                default:
                    return Convert.ToChar(9827);
            }
        }

        public string Number(string a)
        {
            switch (int.Parse(a))
            {
                case 14:
                    return "A";
                case 13:
                    return "K";
                case 12:
                    return "Q";
                case 11:
                    return "J";
                case 10:
                    return "T";
                default:
                    return a;
            }
        }





    }
}
