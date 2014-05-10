using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker
{
    public class Card : IComparable<Card>
    {
        public Ranks Rank { get; protected set; }
        public Suits Suit { get; protected set; }
        public Card(Ranks rank, Suits suit)
        {
            Rank = rank;
            Suit = suit;
        }
        public override string ToString()
        {
            return String.Format("{0}_{1}", Rank, Suit);
        }

        #region Члены IComparable<Card>

        public int CompareTo(Card other)
        {
            if (this.Rank > other.Rank) return -1;
            else if (this.Rank < other.Rank) return 1;
            else return 0;
        }

        #endregion

    }
    public class Combination
    {
        private List<Card> cards = new List<Card>(5);
        public Combinations combination { get; protected set; }

        public void InsertCard(Card card)
        {
            if (cards.Count <= 5) cards.Add(card);
            else return;
            if (cards.Count >= 2) CountCombination();
            Rebuild();
        }
        public void InsertCard(List<Card> _cards)
        {
            this.cards = _cards;
            if (_cards.Count >= 2) CountCombination();
            Rebuild();
        }
        public List<Card> GetCards() { return cards; }
        public Card GetCard(int i) { if (i < 5) return cards[i]; else return null; }
        public void CleanCombination() { cards.Clear(); combination = Combinations.Uknown; }
        public void CountCombination()
        {
            cards.Sort();
            if (cards.Count >= 2)
            {
                bool flash = false;
                bool streight = false;
                bool kare = false;
                bool fullhouse = false;
                bool tree = false;
                bool twopairs = false;
                bool highcard = true;
                bool pair = false;

                int[] len = new int[2] { 1, 0 }; //Для отслеживания двух пар и фулхауса
                int num = 0;

                for (int i = 1; i < cards.Count; i++)
                {
                    if (cards[i].Rank == cards[i - 1].Rank) len[num]++;
                    else
                        if ((len[num] > 1) && (num != 1))
                        {
                            num++;
                            len[num]++;
                        }
                        else if (len[num] <= 1) len[num] = 1;
                }


                //Работаем с полной комбинацией            
                if (cards.Count == 5)
                {
                    //Проверка на флеш
                    flash = true;
                    for (int i = 1; i < cards.Count; i++)
                        if (cards[i].Suit != cards[0].Suit)
                        {
                            flash = false;
                            break;
                        }

                    //Проверка на стрит
                    streight = true;
                    for (int i = 1; i < cards.Count; i++)
                        if ((cards[i - 1].Rank - cards[i].Rank != 1) && (cards[i - 1].Rank - cards[i].Rank != 9))
                        {
                            streight = false;
                            break;
                        }
                }

                if ((len[0] == 2) || (len[1] == 2)) pair = true;
                if ((len[0] == 3) || (len[1] == 3)) tree = true;
                if ((len[0] == 2) && (len[1] == 2)) twopairs = true;
                if (((len[0] == 2) && (len[1] == 3)) || ((len[0] == 3) && (len[1] == 2))) fullhouse = true;
                if (len[0] == 4) kare = true;

                if (streight && flash) { combination = Combinations.StreightFlash; return; }
                if (streight) { combination = Combinations.Streight; return; }
                if (flash) { combination = Combinations.Flash; return; }
                if (kare) { combination = Combinations.Kare; return; }
                if (fullhouse) { combination = Combinations.FullHouse; return; }
                if (twopairs) { combination = Combinations.TwoPairs; return; }
                if (tree) { combination = Combinations.Tree; return; }
                if (pair) { combination = Combinations.Pair; return; }
                if (highcard) { combination = Combinations.HighCard; return; }

            }

            combination = Combinations.Uknown;

        }
        public void Rebuild()
        {
            int i = cards.Count - 1;
            int len = 1;
            int looked = 0;
            int index = i;
            Card card;
            while ((looked < cards.Count) && (i != 0))
            {
                if (cards[i].Rank == cards[i - 1].Rank)
                {
                    i--;
                    len++;
                }
                else if (len > 1)
                {
                    for (int k = 0; k < len; k++)
                    {
                        card = cards[index];
                        cards.Remove(card);
                        cards.Insert(0, card);
                        card = null;
                    }
                    looked += len;
                    len = 1;
                    i = cards.Count - 1;
                    index = i;

                }
                else
                {
                    len = 1;
                    i--;
                    looked++;
                    index--;
                }
            }
            if ((looked < cards.Count) && (len > 1))
            {
                for (int k = 0; k < len; k++)
                {
                    card = cards[index];
                    cards.Remove(card);
                    cards.Insert(0, card);
                    card = null;
                }
            }

            if (this.combination == Combinations.FullHouse)
                if (cards[2].Rank != cards[1].Rank) cards.Reverse();


        }
        public Combination ImproveIfPossible(Card c1)
        {
            Combination buffer = new Combination(cards);
            for (int i = cards.Count - 1; i >= 0; i++)
            {
                if (cards[i] != c1)
                {
                    cards.Remove(cards[i]);
                    cards.Insert(i, c1);
                    break;
                }
            }
            this.CountCombination();
            if (Combination.Compare(this, buffer) < 0)
            {
                this.CleanCombination();
                this.InsertCard(buffer.GetCards());
            }
            return this;
        }

        public Combination()
        {
            combination = Combinations.Uknown;
        }
        public Combination(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++) { this.InsertCard(cards[i]); }
        }

        public static int Compare(Combination x, Combination y)
        {
            if (x.combination > y.combination) return 1;
            else if (x.combination < y.combination) return -1;
            else
            {
                int len = x.cards.Count < y.cards.Count ? x.cards.Count : y.cards.Count;
                for (int i = 0; i < len; i++)
                {
                    if (x.cards[i].Rank > y.cards[i].Rank) return 1;
                    if (x.cards[i].Rank < y.cards[i].Rank) return -1;
                }
                return 0;
            }
        }
        public override string ToString()
        {
            String result = "";
            switch (combination)
            {
                case Combinations.Uknown: { result = ""; break; }
			case Combinations.HighCard: { result = "High Card " + cards[0].Rank.ToString(); break; }
			case Combinations.Pair: { result = "pair " + cards[0].Rank.ToString(); break; }
			case Combinations.TwoPairs: { result = "Two Pairs: " + cards[0].Rank.ToString() + " e " + cards[2].Rank.ToString(); break; }
			case Combinations.Tree: { result = "Set " + cards[0].Rank.ToString(); break; }
			case Combinations.Streight: { result = "Straight " + cards[0].Rank.ToString(); break; }
			case Combinations.FullHouse: { result = "Full House: " + cards[0].Rank.ToString() + " e " + cards[4].Rank.ToString(); break; }
			case Combinations.Flash: { result = "Flush " + cards[0].ToString(); break; }
			case Combinations.Kare: { result = "Four " + cards[0].Rank.ToString(); break; }
			case Combinations.StreightFlash: { result = "Straight Flush " + cards[0].ToString(); break; }

            }
            return result;
        }

    }
    public class CardDeck
    {
        private List<Card> cardsOutOfGame;
        private List<Card> cardsInGame;

        private void Swap(int i, int k)
        {
            Card c1 = cardsOutOfGame[i];
            Card c2 = cardsOutOfGame[k];
            cardsOutOfGame.Remove(c1);
            if (k > i) cardsOutOfGame.Insert(k - 1, c1);
            else cardsOutOfGame.Insert(k + 1, c1);
            cardsOutOfGame.Remove(c2);
            cardsOutOfGame.Insert(i, c2);
        }
        public void Mix()
        {
            Random random = new Random();
            int k = 0;
            for (int i = 0; i < cardsOutOfGame.Count; i++)
            {
                while (true)
                {
                    k = random.Next(1, cardsOutOfGame.Count - 1);
                    if (i != k) break;
                }
                Swap(i, k);
            }

        }
        public Card TakeNextCard()
        {
            Random random = new Random();
            int k = random.Next(0, cardsOutOfGame.Count - 1);
            Card result = new Card(cardsOutOfGame[k].Rank, cardsOutOfGame[k].Suit);
            cardsInGame.Add(cardsOutOfGame[k]);
            cardsOutOfGame.Remove(cardsOutOfGame[k]);
            return result;
        }
        public void Reset()
        {
            cardsOutOfGame.AddRange(cardsInGame);
            cardsInGame.Clear();
            Mix();
        }

        public CardDeck()
        {
            cardsOutOfGame = new List<Card>();
            cardsInGame = new List<Card>();
            for (int i = 2; i < 15; i++)
            {
                cardsOutOfGame.Add(new Card((Ranks)i, Suits.Clubs));
                cardsOutOfGame.Add(new Card((Ranks)i, Suits.Hearts));
                cardsOutOfGame.Add(new Card((Ranks)i, Suits.Diamonds));
                cardsOutOfGame.Add(new Card((Ranks)i, Suits.Spades));
            }
            Mix();
        }

    }
    public class GameLog : GameResetInterface
    {
        public List<Record> records = new List<Record>();

        public void PutRecord(Movements lastmove, int sum, Player player)
        {
            records.Insert(0, new Record(lastmove, sum, player));
        }
        public Record getMove(int i)
        {
            return records[i];
        }
        public List<Record> CreateSaveInformation()
        {
            List<Record> saveinfo = new List<Record>();
            int newhand = 0;
            for (int i = 0; i < records.Count; i++)
                if (records[i].move == Movements.NewHand)
                {
                    newhand = i;
                    break;
                }

            for (int i = records.Count-1, k = 0; i > newhand; i--, k++) saveinfo.Add(records[i]);
            return saveinfo;

        }
        public Movements StringToMovement(string buffer)
        {
            switch (buffer)
            {
                case "Fold": { return Movements.Fold; }
                case "Check": { return Movements.Check; }
                case "Call": { return Movements.Call; }
                case "Raise": { return Movements.Raise; }
                case "NewHand": { return Movements.NewHand; }
                case "SmallBlind": { return Movements.SmallBlind; }
                case "BigBlind": { return Movements.BigBlind; }
                case "Win": { return Movements.Win; }
                case "WinHandsUp": { return Movements.WinHandsUp; }
                case "NewStep": { return Movements.NewStep; }
                default: {return Movements.Fold;}
            }
        }
        public int CountMoves(Movements _move, bool LastRound)
        {
            if (!LastRound)
            {
                int result = 0;
                foreach (Record rec in records) if (rec.move == _move) result++;
                return result;
            }
            else
            {
                int result = 0;
                for (int i = 0; i < records.Count; i++)
                    if (records[i].move == Movements.NewStep) break;
                    else if (records[i].move == _move) result++;
                return result;
            }
        }

        private void game_UpdateLog(object sender, EventArgs e)
        {
            MoveEventArgs args = e as MoveEventArgs;
            if (args.player != null) PutRecord(args.move, args.Sum, args.player);
            else PutRecord(args.move, args.Sum, null);
        }

        #region Члены GameResetInterface

        public void Unsubscribe(GameControl game)
        {
            game.UpdateLog -= new EventHandler(game_UpdateLog);
        }

        public void Subscribe(GameControl game)
        {
            game.UpdateLog += new EventHandler(game_UpdateLog);
        }

        public void ReInitialize()
        {
            records.Clear();
        }

        #endregion
    }
    public class Record
    {
        public Movements move { get; protected set; }
        public int sum { get; protected set; }
        public Player player { get; protected set; }
        public Record() { }
        public Record(Movements lastmove, int _sum, Player _player)
        {
            move = lastmove;
            sum = _sum;
            player = _player;
        }
        public override string ToString()
        {
            String record = "";
            switch ((int)move)
            {
			case 0: { record += player.Name + " caiu;"; break; }
			case 1: { record += player.Name + " cheques;"; break; }
			case 2: { record += player.Name + " suporta até $ " + player.stepBet + " ;"; break; }
			case 3: { record += player.Name + " sobe para $" + player.stepBet + " ;"; break; }
			case 4: { record += player.Name + " vitorias $" + sum + ";"; break; }
			case 5: { record += "-------Novo Acordo!-------"; break; }
			case 6: { record += player.Name + " colocar o small blind $" + sum + " ;"; break; }
			case 7: { record += player.Name + " colocar o big blind $" + sum + " ;"; break; }
			case 8: { record += player.Name + " vitorias $" + sum + ", coleta " + player.cards.ToString(); break; }
			case 9: { record += "-------Uma nova rodada!-------"; break; }
            }
            return record;
        }

    }

}
