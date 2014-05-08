using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Poker
{
    [DataContract]
    public class GameState
    {
        [DataMember(Name = "small_blind")]
        public uint SmallBind { get; set; }

        [DataMember(Name = "current_buy_in")]
        public uint CurrentBuyIn { get; set; }

        [DataMember(Name = "pot")]
        public uint Pot { get; set; }

        [DataMember(Name = "minimum_raise")]
        public uint MinimumRaise { get; set; }

        [DataMember(Name = "dealer")]
        public uint Dealer { get; set; }

        [DataMember(Name = "orbits")]
        public uint Orbits { get; set; }

        [DataMember(Name = "in_action")]
        public uint InAction { get; set; }

        [DataMember(Name = "players")]
        public List<Player> Players { get; set; }

        [DataMember(Name = "community_cards")]
        public List<Card> CommunityCards { get; set; }
    }

    [DataContract]
    public class Player
    {
        [DataMember(Name = "id")]
        public uint Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "version")]
        public string Version { get; set; }

        [DataMember(Name = "stack")]
        public uint Stack { get; set; }

        [DataMember(Name = "bet")]
        public uint Bet { get; set; }
    }

    [DataContract]
    public class Card
    {
        [DataMember(Name = "rank")]
        public string Rank { get; set; }

        [DataMember(Name = "suit")]
        public string Suit { get; set; }
    }
}

