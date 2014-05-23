using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Parse
{
    public class HandParse
    {
        private List<String> hand;
        private string PokerStars = @"^PokerStars\s";
                                           
        public GenericParse genericParse;
        public HandParse(List<String> Hand)
        {
            hand = Hand;
            if(Regex.IsMatch(Hand[0],PokerStars))
                genericParse = new PokerStarsParse(hand);    
        
        }
    }
}

// handParser 
//
// site type 
// hand number
// game type - 
// game values
// tournament ?? Level
// date
// number of players
// button seat #
// 
// players
//  positions,names,stacks,cards
// 
// actions
//
// player [street] [posts,said,call,fold,raise,all in] [value]
//
// streets
// street [cards]
//
// sumary
//
//
//
