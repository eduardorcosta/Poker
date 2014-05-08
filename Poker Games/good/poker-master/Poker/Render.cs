using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Poker
{
    class Render : GameResetInterface
    {
        public MainForm mainform;
        private GameControl game;

        private void game_UpdateCards(object sender, EventArgs e)
        {
            if (game.table.cards.Count == 0)
            {
                mainform.pbMyCard1.Visible = true;
                mainform.pbMyCard2.Visible = true;
                mainform.pbAICard1.Visible = true;
                mainform.pbAICard2.Visible = true;
                mainform.pbTableCard1.Visible = true;
                mainform.pbTableCard2.Visible = true;
                mainform.pbTableCard3.Visible = true;
                mainform.pbTableCard4.Visible = true;
                mainform.pbTableCard5.Visible = true;

                mainform.pbTableCard1.BackgroundImage = (Image)Poker.Properties.Resources.Rubashka;
                mainform.pbTableCard2.BackgroundImage = (Image)Poker.Properties.Resources.Rubashka;
                mainform.pbTableCard3.BackgroundImage = (Image)Poker.Properties.Resources.Rubashka;
                mainform.pbTableCard4.BackgroundImage = (Image)Poker.Properties.Resources.Rubashka;
                mainform.pbTableCard5.BackgroundImage = (Image)Poker.Properties.Resources.Rubashka;

                mainform.pbAICard1.BackgroundImage = (Image)Poker.Properties.Resources.Rubashka;
                mainform.pbAICard2.BackgroundImage = (Image)Poker.Properties.Resources.Rubashka;

                mainform.pbMyCard1.BackgroundImage = (Image)Poker.Properties.Resources.ResourceManager.GetObject(game.table.mainplayer.hand[0].ToString());
                mainform.pbMyCard2.BackgroundImage = (Image)Poker.Properties.Resources.ResourceManager.GetObject(game.table.mainplayer.hand[1].ToString());
            }
            else
            {
                for (int i = 0; i < game.table.cards.Count; i++)
                {
                    if (i == 0)
                    {
                        mainform.pbTableCard1.BackgroundImage = (Image)Poker.Properties.Resources.ResourceManager.GetObject(game.table.cards[i].ToString());
                        continue;
                    }
                    if (i == 1)
                    {
                        mainform.pbTableCard2.BackgroundImage = (Image)Poker.Properties.Resources.ResourceManager.GetObject(game.table.cards[i].ToString());
                        continue;
                    }
                    if (i == 2)
                    {
                        mainform.pbTableCard3.BackgroundImage = (Image)Poker.Properties.Resources.ResourceManager.GetObject(game.table.cards[i].ToString());
                        continue;
                    }
                    if (i == 3)
                    {
                        mainform.pbTableCard4.BackgroundImage = (Image)Poker.Properties.Resources.ResourceManager.GetObject(game.table.cards[i].ToString());
                        continue;
                    }
                    if (i == 4)
                    {
                        mainform.pbTableCard5.BackgroundImage = (Image)Poker.Properties.Resources.ResourceManager.GetObject(game.table.cards[i].ToString());
                        continue;
                    }
                }
                if ((game.table.gamelog.getMove(0).move == Movements.WinHandsUp)||(game.table.mainplayer.AllIn))
                {
                    Player p = game.table.players.Last(x => !(x is Human));
                    int k = game.table.players.IndexOf(p);
                    mainform.pbAICard1.BackgroundImage = (Image)Poker.Properties.Resources.ResourceManager.GetObject(game.table.players[k].hand[0].ToString());
                    mainform.pbAICard2.BackgroundImage = (Image)Poker.Properties.Resources.ResourceManager.GetObject(game.table.players[k].hand[1].ToString());
                    if (game.table.gamelog.getMove(0).move == Movements.WinHandsUp) 
						MessageBox.Show(game.table.gamelog.getMove(0).player.Name + " ganhou a mao, reunio " + game.table.gamelog.getMove(0).player.cards.ToString() + "!", "vitoria!");
                }
            }
        }
        private void game_LostUpdateControls(object sender, EventArgs e)
        {
            mainform.lbGameLog.Items.Insert(0, game.table.gamelog.getMove(0).ToString());
            mainform.labelStack0.Text = game.table.mainplayer.Stack.ToString();
            if (game.table.players[0] is Human)
                mainform.labelStack1.Text = game.table.players[1].Stack.ToString();
            else mainform.labelStack1.Text = game.table.players[0].Stack.ToString();
			mainform.labelBank.Text = "Banco: " + game.table.Bank.ToString();

			mainform.labelTabelMyBet.Text = "taxa: " + game.table.mainplayer.stepBet.ToString();
            if (game.table.players[0] is Human)
				mainform.labelTableAIBet.Text = "taxa: " + game.table.players[1].stepBet.ToString();
			else mainform.labelTableAIBet.Text = "taxa: " + game.table.players[0].stepBet.ToString();

            MoveEventArgs args = e as MoveEventArgs;
            if ((args.move == Movements.NewHand)
                || (args.move == Movements.SmallBlind)
                || (args.move == Movements.BigBlind))
                return;

            if (((int)args.move < 4) && (args.player is Human))
            {
                mainform.mytime.Visible = false;
                mainform.labelYourMove.Visible = false;
                mainform.buttonFold.Enabled = false;
                mainform.buttonCheck.Enabled = false;
                mainform.buttonCall.Enabled = false;
                mainform.buttonRaise.Enabled = false;
                mainform.trackbarBet.Enabled = false;
                mainform.trackbarBet.Value = mainform.trackbarBet.Minimum;
                mainform.labelMyBet.Text = mainform.trackbarBet.Minimum.ToString();
                mainform.pbMainPlayer.Image = Poker.Properties.Resources.waiting;
                mainform.pbAI1.Image = Poker.Properties.Resources.active;
            }
        }
        private void game_ReceiveUpdateControls(object sender, EventArgs e)
        {
            UpdateControlsArgs args = e as UpdateControlsArgs;
            if (!args.player.AllIn)
            {
				mainform.labelTabelMyBet.Text = "taxa: " + game.table.mainplayer.stepBet.ToString();
                if (game.table.players[0] == game.table.mainplayer)
					mainform.labelTableAIBet.Text = "taxa: " + game.table.players[1].stepBet.ToString();
				else mainform.labelTableAIBet.Text = "taxa: " + game.table.players[0].stepBet.ToString();

                if (game.table.HowMuchToCall() == game.table.mainplayer.stepBet)
                {
                    mainform.buttonCheck.Enabled = true;
                }
                else
                {
                    mainform.buttonCall.Enabled = true;
                    mainform.buttonFold.Enabled = true;
                }
                mainform.buttonRaise.Enabled = true;
                mainform.buttonRaise.Enabled = true;
                if (game.table.mainplayer.Stack >= game.table.sblind * 6)
                    mainform.trackbarBet.Minimum = (game.table.sblind * 6);
                else mainform.trackbarBet.Minimum = game.table.mainplayer.Stack;
                mainform.trackbarBet.Value = mainform.trackbarBet.Minimum;
                mainform.trackbarBet.Maximum = game.table.mainplayer.Stack;
                mainform.trackbarBet.Enabled = true;
                mainform.pbAI1.Image = Poker.Properties.Resources.waiting;
                mainform.pbMainPlayer.Image = Poker.Properties.Resources.active;


                mainform.mytime.Visible = true;
                mainform.mytime.Value = 30;
                mainform.labelYourMove.Visible = true;
                mainform.playersTime.Enabled = true;
                mainform.playersTime.Interval = 1000;
                mainform.playersTime.Start();

            }
        }
        private void game_GameBegin(object sender, EventArgs e)
        {
            if (game.table.players[0] is Human)
            {
                mainform.labelMainPlayer.Text = game.table.players[0].Name;
                mainform.labelPlayer2.Text = game.table.players[1].Name;
                mainform.labelStack0.Text = game.table.players[0].Stack.ToString();
                mainform.labelStack1.Text = game.table.players[1].Stack.ToString();
            }
            else
            {
                mainform.labelMainPlayer.Text = game.table.players[1].Name;
                mainform.labelPlayer2.Text = game.table.players[0].Name;
                mainform.labelStack0.Text = game.table.players[1].Stack.ToString();
                mainform.labelStack1.Text = game.table.players[0].Stack.ToString();
            }

            mainform.labelTableAIBet.Show();
            mainform.labelTabelMyBet.Show();
            mainform.labelBank.Show();
            mainform.pbDilerButton.Show();
            mainform.pbBank.Show();
            if (game.table.players[0] is Human) mainform.pbAI1.Image = Poker.Properties.Resources.active;
        }
        private void playersTime_Tick(object sender, EventArgs e)
        {
            if (mainform != null)
            {
                if (mainform.mytime.Value > 0) mainform.mytime.Value--;
                else
                {
                    mainform.playersTime.Stop();
                    mainform.playersTime.Enabled = false;
                    if ((game.table.gamelog.getMove(0).move != Movements.Win) && ((game.table.gamelog.getMove(0).move != Movements.WinHandsUp)))
                        game.table.mainplayer.OnMove(new MoveEventArgs(Movements.Fold, 0, game.table.mainplayer));
                }
            }
        }
        private void game_DilerUpdate(object sender, EventArgs e)
        {
            if (game.table.players[1] is Human) mainform.pbDilerButton.Location = new System.Drawing.Point(460, 60);
            else mainform.pbDilerButton.Location = new System.Drawing.Point(300, 230);
        }

        public Render(GameControl _game, MainForm _mainform)
        {
            game = _game;
            mainform = _mainform;
        }

        #region Члены GameResetInterface

        public void Unsubscribe(GameControl game)
        {
            game.GameBegin -= new EventHandler(game_GameBegin);
            game.ReceiveUpdateControls -= new EventHandler(game_ReceiveUpdateControls);
            game.LostUpdateControls -= new EventHandler(game_LostUpdateControls);
            game.UpdateCards -= new EventHandler(game_UpdateCards);
            game.DilerUpdate -= new EventHandler(game_DilerUpdate);
            mainform.playersTime.Tick -= new EventHandler(playersTime_Tick);
        }

        public void Subscribe(GameControl game)
        {
            game.GameBegin += new EventHandler(game_GameBegin);
            game.ReceiveUpdateControls += new EventHandler(game_ReceiveUpdateControls);
            game.LostUpdateControls += new EventHandler(game_LostUpdateControls);
            game.UpdateCards += new EventHandler(game_UpdateCards);
            game.DilerUpdate += new EventHandler(game_DilerUpdate);
            mainform.playersTime.Tick += new EventHandler(playersTime_Tick);
        }

        public void ReInitialize() { }

        #endregion
    }
}
