using System;
using System.Collections.Generic;
using System.Linq;

namespace TwentyOne
{
    class Program
    {
        static void Main()
        {
            Deck deck = new Deck();
            deck.Shuffle(3);

            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }
            Console.ReadLine();
        }
    }
}
