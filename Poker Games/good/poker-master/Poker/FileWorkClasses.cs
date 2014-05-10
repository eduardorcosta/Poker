using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Poker
{
    class Saver
    {
        MainForm mainform;
        GameControl game;


        public Saver(MainForm form, GameControl _game)
        {
            mainform = form;
            game = _game;
            mainform.SaveGame += new EventHandler(mainform_SaveGame);
            mainform.saver.FileOk += new System.ComponentModel.CancelEventHandler(saver_FileOk);
        }

        protected void mainform_SaveGame(object sender, EventArgs e)
        {
			if (game.table == null) System.Windows.Forms.MessageBox.Show("Salvo Jogo!", "Jogue mas nao inciado!");
            else mainform.saver.ShowDialog();
        }

        protected void saver_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mainform.playersTime.Enabled)
            {
                mainform.playersTime.Stop();
                mainform.playersTime.Enabled = false;
            }
            using (BinaryWriter stream = new BinaryWriter(mainform.saver.OpenFile()))
            {
                stream.Write(game.table.mainplayer.Name); // Имя игрока
                if (game.table.players[0] is Human) // Стэк компьютера
                    stream.Write((UInt32)game.table.players[1].Stack);
                else stream.Write((UInt32)game.table.players[0].Stack);

                stream.Write((UInt32)game.table.mainplayer.Stack);// Стэк игрока
                stream.Write(game.table.players[0] is Human); //Игрок - диллер?

                List<Record> towrite = game.table.gamelog.CreateSaveInformation();
                foreach (Record r in towrite)
                {
                    stream.Write(r.player.Name);
                    stream.Write(r.move.ToString());
                    stream.Write((UInt32)r.sum);
                }
            }
			mainform.lbGameLog.Items.Insert(0, "Jogo Salvo em mao atual!");
            mainform.saver.Reset();
        }
    }

    class Loader
    {
        protected GameControl game;
        protected MainForm mainform;

        public Loader(MainForm form, GameControl _game)
        {
            game = _game;
            mainform = form;
            mainform.loader.FileOk += new System.ComponentModel.CancelEventHandler(loader_FileOk);
        }

        protected void loader_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

            using (BinaryReader stream = new BinaryReader(mainform.loader.OpenFile()))
            {
                String playerName = stream.ReadString();
                int AIStack = 0, playerStack = 0;
                bool isDiller = true;
                try
                {
                    AIStack = (int)stream.ReadUInt32();
                    playerStack = (int)stream.ReadUInt32();
                    isDiller = stream.ReadBoolean();
                }
                catch
                {
                    return;
                }

                if (game.table == null)
                    game.table = new Table(2, playerName, ((AIStack + playerStack) / 2), game);
                else
                {
                    game.table.mainplayer.Name = playerName;
                    mainform.Unsubscribe(game);
                    mainform.ReInitialize();
                    mainform.Subscribe(game);
                }
                game.table.players[0].Stack = playerStack;
                game.table.players[1].Stack = AIStack;
                if (!isDiller) game.table.NewDiller();
                game.Subscribe(game);

                String buffer = "";
                int sum = 0;
                while (stream.PeekChar() != -1)
                {
                    playerName = stream.ReadString();
                    buffer = stream.ReadString();
                    sum = (int)stream.ReadUInt32();
                    game.table.gamelog.records.Add(new Record(game.table.gamelog.StringToMovement(buffer), sum, game.table.WhoIs(playerName)));
                }
                foreach (Record rec in game.table.gamelog.records)
                    mainform.lbGameLog.Items.Insert(0, rec.ToString());
                game.OnGameBegin(new EventArgs());
                game.table.NewHand();
            }
        }
    }
}
