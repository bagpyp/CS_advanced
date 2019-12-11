using System;
using System.Collections.Generic;
using System.Linq;

namespace TwentyOne
{
    class Program
    {
        static void Main()
        {
            //Deck deck = new Deck();
            //foreach (Card card in deck.Cards)
            //{
            //    Console.WriteLine(card.Face + " of " + card.Suit);
            //}
            Console.WriteLine("Welcome to the Grand Hotel and Casino.\n" +
                "Let's start by you telling me your name.");
            string playerName = Console.ReadLine();

            Console.WriteLine("How much money did you bring with you today?");
            int bank = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hello, {0}. Would you like to play a game of 21?", playerName);
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes" || answer == "y" || answer == "yeah" || answer == "ya")
            {
                Player player = new Player(playerName, bank);
                Game game = new TwentyOneGame();
                game += player;
                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    game.Play();
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }

            Console.WriteLine("Feel free to look around the casino. Bye for now!");
            Console.ReadLine();
        }
    }
}
