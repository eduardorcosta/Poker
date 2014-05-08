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
    public partial class MainForm : Form, GameResetInterface
    {
        public event EventHandler SaveGame;

        public NewGame ngform = new NewGame();
        public Stats stats = new Stats();
        private GameControl game;
        public Timer playersTime = new Timer();

        public MainForm()
        {
            InitializeComponent();
            game = new GameControl(ngform, this);
            Subscribe(game);
        }

        void game_GameEnd(object sender, EventArgs e)
        {
            EndgameArgs args = e as EndgameArgs;
            if (args.result == DialogResult.Yes)
            {
                Unsubscribe(game);
                ReInitialize();
                Subscribe(game);
                ngform.OnNewGameInit(new GameInitArgs(2, (int)ngform.nudInitStack.Value, ngform.tbName.Text));
            }
            else Close();
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void menuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void buttonFold_Click(object sender, EventArgs e)
        {
            game.table.mainplayer.OnMove(new MoveEventArgs(Movements.Fold, 0, game.table.mainplayer));  
        }
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            game.table.mainplayer.OnMove(new MoveEventArgs(Movements.Check, 0, game.table.mainplayer));
        }
        private void buttonCall_Click(object sender, EventArgs e)
        {
            game.table.mainplayer.OnMove(new MoveEventArgs(Movements.Call, game.table.HowMuchToCall() - game.table.mainplayer.stepBet, game.table.mainplayer));
          
        }
        private void buttonRaise_Click(object sender, EventArgs e)
        {
            game.table.mainplayer.OnMove(new MoveEventArgs(Movements.Raise, trackbarBet.Value, game.table.mainplayer));
          
        }
        private void новаяИграToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ngform.ShowDialog();

        }
        private void trackbarBet_ValueChanged(object sender, EventArgs e)
        {
            labelTrackbar.Text = trackbarBet.Value.ToString();
        }
        private void выходToolStripMenuItem2_Click(object sender, EventArgs e)
        {
			DialogResult r = MessageBox.Show("Voce Realmente quer parar de Jogar?", "já deixando?", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK) Close();
        }

        #region Члены GameResetInterface

        public void Unsubscribe(GameControl game)
        {
            game.GameEnd -= new EventHandler(game_GameEnd);
            game.Unsubscribe(game);
        }

        public void Subscribe(GameControl game)
        {
            game.GameEnd += new EventHandler(game_GameEnd);
        }

        public void ReInitialize()
        {
            lbGameLog.Items.Clear();
            this.Invalidate();
            game.ReInitialize();
        }

        #endregion

        private void buttonCall_MouseMove(object sender, MouseEventArgs e)
        {
            if (((Button)sender).Enabled == true)
            {
                labelMyBet.Text = (game.table.HowMuchToCall() - game.table.mainplayer.stepBet).ToString();
            }
        }

        private void buttonCall_MouseLeave(object sender, EventArgs e)
        {
            labelMyBet.Text = trackbarBet.Value.ToString();
        }

        private void сохранитьИгруToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OnSaveGame(new EventArgs());
        }

        public void OnSaveGame(EventArgs e)
        {
            EventHandler save = SaveGame;
            if (save != null) save(this, e);
        }

        private void buttonRaise_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.table.mainplayer.Stack >= game.table.sblind * 6)
                labelMyBet.Text = (game.table.sblind * 6).ToString();
            else labelMyBet.Text = game.table.mainplayer.Stack.ToString();
        }

        private void buttonRaise_MouseLeave(object sender, EventArgs e)
        {
            labelMyBet.Text = trackbarBet.Value.ToString();
        }

        private void загрузитьИгруToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loader.ShowDialog();
        }

        private void статистикаToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (game.table != null)
            {
                stats.labelFolds.Text = game.table.gamelog.CountMoves(Movements.Fold, false).ToString();
                stats.labelRaises.Text = game.table.gamelog.CountMoves(Movements.Raise, false).ToString();
                stats.labelHands.Text = game.table.gamelog.CountMoves(Movements.NewHand, false).ToString();
                stats.labelWins.Text = game.table.gamelog.CountMoves(Movements.Win, false).ToString();
                stats.ShowDialog();
            }
			else MessageBox.Show("Voce Nao jogo!", "As Estatisticas nao estao disponiveis");

        }

        private void справкаToolStripMenuItem2_Click(object sender, EventArgs e)
        {
			//System.Diagnostics.Process.Start(@"/help.chm");
        }
    }
}
