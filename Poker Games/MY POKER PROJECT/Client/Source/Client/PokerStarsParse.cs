using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Parse
{
    public struct player
    {
        public string name;
        public string pos;
        public string stack;
    }
    public abstract class GenericParse
    {
        protected List<String> hand;
         //partial void Head();
        public bool isTournament = false;
        public bool playMoney = false;
        public string TournamentNumber;
        public string HandNumber;
        public string GameType;
        public string Level;
        public string smallBlind;
        public string bigBlind;
        public string tableName;
        public string buttonPos;
        public string tableSize;
        public List<player> players;
    }
    class PokerStarsParse:GenericParse
    {
        //string tournament = @"^PokerStars Hand #(\d+): Tournament #(\d+),\S*USD\s+(\w*)\s+-\s+Level (\w) \((\d+)/(\d+)\)\s*-\S*";
        //string zoom       = @"^PokerStars Zoom Hand #(\d+):\s+(\S+)\s+\((\w+)/(\w+)\)\s*-\S*";
        //string other      = @"^PokerStars Hand #(\d+):\s+(\w+)\s+\((\w+)/(\w+)\)\s*-\S*";
        // PokerStars Hand #115554758779: Tournament #903713096, $0.02+$0.00 USD Hold'em No Limit - Level I (25/50) - 2014/05/01 9:19:16 BRT [2014/05/01 8:19:16 ET]
        // PokerStars Zoom Hand #115554605612:  Hold'em No Limit ($0.01/$0.02) - 2014/05/01 9:13:58 BRT [2014/05/01 8:13:58 ET]
        // PokerStars Hand #116418192855:  Hold'em Limit (10/20) - 2014/05/19 20:20:08 BRT [2014/05/19 19:20:08 ET]
        //string zoom       = @"^PokerStars Zoom Hand #(\d+):\s+(\S+)\s+\((\w+)/(\w+)\)\s*-\S*";

        
        

        public PokerStarsParse(List<String> Hand)
        {
            players = new List<player>();
            hand = Hand;
            Head();
            Table();
            Players();
            //do something
        }
        private void Players()
        {
            // Seat 1: flatron19 (1500 in chips) 
            string seat = @"^Seat\s+(?<pos>\d):\s+(?<name>.+)\s+\((?<stack>.+)\sin chips\).*";
            Match m;
            for (int i = 0; i < Convert.ToInt32(tableSize); i++) {
                m = Regex.Match(hand[2 + i], seat);
                if (m.Success)
                {
                    player p = new player();
                    p.name = m.Groups["name"].Value;
                    p.pos = m.Groups["pos"].Value;
                    p.stack = m.Groups["stack"].Value;
                    players.Add(p);
                }
            }
        }
        private void Table()
        {
            // Table '896006531 1' 9-max Seat #1 is the button
            // Table 'Fennia II' 6-max (Play Money) Seat #5 is the button
            // Table '903713096 85' 9-max Seat #1 is the button
            // Table 'Donati' 6-max Seat #1 is the button
            string table = @"^Table '(?<tableName>.+)'\s+(?<tableSize>\d)-max\s+Seat\s+#(?<buttonPos>\d)\sis the button";
            string tablePlay = @"^Table '(?<tableName>.+)'\s+(?<tableSize>\d)-max.*Seat\s+#(?<buttonPos>\d)\sis the button";
            string playMoneyStr = @".*Play Money.*";
            Match m;
            if (Regex.IsMatch(hand[1], playMoneyStr))
            {
                playMoney = true;
                m = Regex.Match(hand[1], tablePlay);
                tableName = m.Groups["tableName"].Value;
                tableSize = m.Groups["tableSize"].Value;
                buttonPos = m.Groups["buttonPos"].Value;
            }
            else
            {
                m = Regex.Match(hand[1], table);
                tableName = m.Groups["tableName"].Value;
                tableSize = m.Groups["tableSize"].Value;
                buttonPos = m.Groups["buttonPos"].Value;
            }
        }
        private void Head()
        {
            string tournament = @"^PokerStars Hand #(?<handNumber>\d+): Tournament #(?<tournamentNumber>\d+),.*USD\s+(?<gameType>.+)\s+-\s+Level (?<level>\w+)\s+\((?<smallBlind>\S+)/(?<bigBlind>\S+)\)\s*-\.*";
            string zoom = @"^PokerStars Zoom Hand #(?<handNumber>\d+):\s+(?<gameType>.+)\s+\((?<smallBlind>\S+)/(?<bigBlind>\S+)\)\s*-\.*";
            string other = @"^PokerStars Hand #(?<handNumber>\d+):\s+(?<gameType>.+)\s+\((?<smallBlind>\d+)/(?<bigBlind>\d+)\)\s*-\S*";

            Match m;
            if (Regex.IsMatch(hand[0], tournament))
            {
                isTournament = true;
                m = Regex.Match(hand[0], tournament);
                HandNumber = m.Groups["handNumber"].Value;
                TournamentNumber = m.Groups["tournamentNumber"].Value;
                GameType = m.Groups["gameType"].Value;
                Level = m.Groups["level"].Value;
                smallBlind = m.Groups["smallBlind"].Value;
                bigBlind = m.Groups["bigBlind"].Value;
            }
            else if (Regex.IsMatch(hand[0], zoom))
            {
                isTournament = false;
                m = Regex.Match(hand[0], zoom);
                HandNumber = m.Groups["handNumber"].Value;
                GameType = m.Groups["gameType"].Value;
                smallBlind = m.Groups["smallBlind"].Value;
                bigBlind = m.Groups["bigBlind"].Value;
                
            }
            else if (Regex.IsMatch(hand[0], other))
            {
                isTournament = false;
                m = Regex.Match(hand[0], other);
                HandNumber = m.Groups["handNumber"].Value;

                GameType = m.Groups["gameType"].Value;
                smallBlind = m.Groups["smallBlind"].Value;
                bigBlind = m.Groups["bigBlind"].Value;
            }
            else
                return;
        }
    }
}
// file struct
// PokerStars Hand #115554758779: Tournament #903713096, $0.02+$0.00 USD Hold'em No Limit - Level I (25/50) - 2014/05/01 9:19:16 BRT [2014/05/01 8:19:16 ET]
// PokerStars Zoom Hand #115554605612:  Hold'em No Limit ($0.01/$0.02) - 2014/05/01 9:13:58 BRT [2014/05/01 8:13:58 ET]
// PokerStars Hand #116418192855:  Hold'em Limit (10/20) - 2014/05/19 20:20:08 BRT [2014/05/19 19:20:08 ET]

// hand # game type, value date
//
// table
// Table '903713096 85' 9-max Seat #1 is the button
// table 'name' numbers of seats -max Seat #pos of button
//
// Seat 1: flatron19 (1500 in chips) 
// seat number: player name (stack) $cash or chips
//
//flatron19: posts the ante 10
//player: post ante value
//
//*** HOLE CARDS ***
// game init !!!
//
//Dealt to eduardorcost [7c Jh] 
// Hero !!! cards
//
// norikdjan999: raises 1440 to 1490 and is all-in
// actions: call, fold, raise, and all-in
//
//*** FLOP *** [5c 2c 2h]
//*** TURN *** [5c 2c 2h] [9s]
//*** RIVER *** [5c 2c 2h 9s] [5d]
// flop turn and river is the same
//
//*** SHOW DOWN ***
//
//kanev.l: shows [Ts Js] (two pair, Fives and Deuces)
//norikdjan999: shows [Ah Qc] (two pair, Fives and Deuces - Ace kicker)
//norikdjan999 collected 3170 from pot
//kanev.l finished the tournament in 927th place
//
//
//*** SUMMARY ***
//Total pot 3170 | Rake 0 
// total pot value | rake value
//
//Board [5c 2c 2h 9s 5d]
//final board
//
//Seat 1: flatron19 (button) folded before Flop (didn't bet)
// every seat!!