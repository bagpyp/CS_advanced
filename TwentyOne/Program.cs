using System;
using System.Collections.Generic;

namespace TwentyOne
{
    class Program
    {
        static void Main()
        {
            TwentyOneGame game = new TwentyOneGame();
            game.Players = new List<string>() { "Robbie", "Heather", "Louis" };
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
