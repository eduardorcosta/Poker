using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poker
{
    public class GameInitArgs : EventArgs
    {
        public int NumberOfPlayers { get; protected set; }
        public int InitStack { get; protected set; }
        public String PlayerName { get; protected set; }

        public GameInitArgs(int _numb, int _stack, String _name)
        {
            NumberOfPlayers = _numb;
            InitStack = _stack;
            PlayerName = _name;
        }
    }

    class UpdateControlsArgs : EventArgs
    {
        public Player player { get; protected set; }
        public int toCall { get; protected set; }
        public int sblind { get; protected set; }
        public UpdateControlsArgs(Player p, int tocall, int blind)
        {
            player = p;
            toCall = tocall;
            sblind = blind;
        }
    }

    public class MoveEventArgs : EventArgs
    {
        public Movements move { get; protected set; }
        public Player player { get; protected set; }
        public int Sum { get; protected set; }

        public MoveEventArgs(Movements _move, int _sum, Player _player)
        {
            move = _move;
            Sum = _sum;
            player = _player;
        }
    }

    public class ActionEventArgs : EventArgs
    {
        public Player player { get; protected set; }
        public ActionEventArgs(Player p)
        {
            player = p;
        }
    }

    class EndgameArgs : EventArgs
    {
        public DialogResult result { get; protected set; }
        public EndgameArgs(DialogResult res)
        {
            result = res;
        }
    }

    public class GameControl : GameResetInterface
    {
        public event EventHandler GameBegin;
        public event EventHandler GameEnd;
        public event EventHandler LostUpdateControls;
        public event EventHandler DilerUpdate;
        public event EventHandler ReceiveUpdateControls;
        public event EventHandler UpdateCards;
        public event EventHandler UpdateLog;
        public event EventHandler UpdateBank;
        public event EventHandler MoveEnd;
        public event EventHandler DeliveryBatonToPlayer;

        public Table table;
        private Render render;
        private Saver gamesaver;
        private Loader loader;
        private NewGame ngform;
        private DialogResult res;

        public GameControl(NewGame form, MainForm mform)
        {
            ngform = form;
            render = new Render(this, mform);
            loader = new Loader(mform, this);
            gamesaver = new Saver(mform, this);
            form.NewGameInit += new EventHandler(form_NewGameInit);
			render.mainform.lbGameLog.Items.Add("Bem Vindo ao Texas Holdem!");
        }

        private void form_NewGameInit(object sender, EventArgs e)
        {
            GameInitArgs args = (GameInitArgs)e;
            if (table == null)
                table = new Table(args.NumberOfPlayers, args.PlayerName, args.InitStack, this);
            else
            {
                table.mainplayer.Name = args.PlayerName;
                render.mainform.Unsubscribe(this);
                render.mainform.ReInitialize();
                render.mainform.Subscribe(this);
            }
            Subscribe(this);
            OnGameBegin(new EventArgs());
            table.NewHand();
        }
        private void table_GameEnd(object sender, EventArgs e)
        {
            res = new DialogResult();
            render.mainform.lbGameLog.Items.Insert(0,"-------------Game over---------------");
			res = MessageBox.Show("Game Over Quer comecar de novo?", "Game over", MessageBoxButtons.YesNo);
            OnGameEnd(new EndgameArgs(res));
        }
        private void table_HandsUp(object sender, EventArgs e)
        {
            OnUpdateCards(new EventArgs());
        }
        private void table_CardsChanged(object sender, EventArgs e)
        {
            OnUpdateCards(new EventArgs());
        }
        private void p_Move(object sender, EventArgs e)
        {
            MoveEventArgs moveargs = e as MoveEventArgs;
            OnUpdateBank(moveargs);
            OnUpdateLog(moveargs);
            if (moveargs.move == Movements.NewHand) OnDilerUpdate(moveargs);
            OnLostUpdateControls(moveargs);
            OnMoveEnd(moveargs);
            
        }
        private void table_BatonMoved(object sender, EventArgs e)
        {

            if (table.players[table.Baton] is Human)
                OnReceiveUpdateControls(new UpdateControlsArgs(table.players[table.Baton], table.HowMuchToCall(), table.sblind));
            OnDeliveryBatonToPlayer(new UpdateControlsArgs(table.players[table.Baton], table.HowMuchToCall(), table.sblind));

        }

        public void OnGameBegin(EventArgs e)
        {
            EventHandler gamebegin = GameBegin;
            if (gamebegin != null) gamebegin(this, e);
        }
        private void OnReceiveUpdateControls(UpdateControlsArgs e)
        {
            EventHandler update = ReceiveUpdateControls;
            if (update != null) update(this, e);
        }
        private void OnLostUpdateControls(MoveEventArgs e)
        {
            EventHandler update = LostUpdateControls;
            if (update != null) update(this, e);
        }
        private void OnUpdateCards(EventArgs e)
        {
            EventHandler update = UpdateCards;
            if (update != null) update(this, e);
        }
        private void OnDeliveryBatonToPlayer(UpdateControlsArgs e)
        {
            EventHandler delivery = DeliveryBatonToPlayer;
            if (delivery != null) delivery(this, e);
        }
        private void OnUpdateBank(MoveEventArgs e)
        {
            EventHandler move = UpdateBank;
            if (move != null) move(this, e);
        }
        private void OnMoveEnd(MoveEventArgs e)
        {
            EventHandler move = MoveEnd;
            if (move != null) move(this, e);
        }
        private void OnUpdateLog(MoveEventArgs e)
        {
            EventHandler update = UpdateLog;
            if (update != null) update(this, e);
        }
        private void OnDilerUpdate(MoveEventArgs e)
        {
            EventHandler update = DilerUpdate;
            if (update != null) update(this, e);
        }
        private void OnGameEnd(EndgameArgs e)
        {
            EventHandler end = GameEnd;
            if (end != null) end(this, e);
        }

        #region Члены GameResetInterface

        public void Unsubscribe(GameControl game)
        {
            render.Unsubscribe(game);
            table.Unsubscribe(game);
            game.table.BatonMoved -= new EventHandler(table_BatonMoved);
            foreach (Player p in game.table.players) p.Move -= new EventHandler(p_Move);
            game.table.CardsChanged -= new EventHandler(table_CardsChanged);
            game.table.HandsUp -= new EventHandler(table_HandsUp);
            game.table.GameEnd -= new EventHandler(table_GameEnd);
        }

        public void Subscribe(GameControl game)
        {
            table.Subscribe(game);
            render.Subscribe(game);
            game.table.BatonMoved += new EventHandler(table_BatonMoved);
            foreach (Player p in game.table.players) p.Move += new EventHandler(p_Move);
            game.table.CardsChanged += new EventHandler(table_CardsChanged);
            game.table.HandsUp += new EventHandler(table_HandsUp);
            game.table.GameEnd += new EventHandler(table_GameEnd);
        }

        public void ReInitialize()
        {
            table.ReInitialize();
            render.ReInitialize();
            table.players[0].Stack = (int)ngform.nudInitStack.Value;
            table.players[1].Stack = (int)ngform.nudInitStack.Value;
        }

        #endregion
    }



}