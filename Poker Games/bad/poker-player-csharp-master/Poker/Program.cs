using System;

namespace Poker
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var player = new PokerPlayer();
            player.Start();

            Console.ReadLine();

            player.Stop();
        }
    }
}
