using System;
using System.Collections.Generic;

namespace TwentyOne
{
    class Program
    {
        static void Main()
        {
            //insantiate a new ame of 21
            Game game = new TwentyOneGame();
            
            //instantiate the list of players of this game
            game.Players = new List<Player>();

            //create a player and add it to the game (overflow +)
            Player player = new Player() { Name = "Robbie" };
            game += player;
            
            game.ListPlayers();
            Console.ReadLine();

            //instantiate and assign new 52-card deck
            Deck deck = new Deck();
            //Shuffle deck
            deck.Shuffle();

            //view deck and its count
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }
            
            Console.ReadLine();
        }
    }
}
