using System;
using System.Collections.Generic;

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate and assign new 52-card deck
            Deck deck = new Deck();
            //deck = Shuffle(deck: deck, times: 10);
            deck = Shuffle(deck, out int timesShuffled, 3);

            //view deck and its count
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }
            Console.WriteLine(deck.Cards.Count + " cards shuffled {0} times.", timesShuffled);
            Console.ReadLine();
        }

        //create a method (outside of main) for shuffling the deck
        public static Deck Shuffle(Deck deck, out int timesShuffled, int times = 1)
        {
            timesShuffled = 0;
            //shuffle the deck "times" times (default = 1)
            for (int i = 0; i < times; i++)
            {
                //increase count of timesShuffled
                timesShuffled++;
                //instantiate a temporary list to store cards
                List<Card> tempList = new List<Card>();
                Random random = new Random();

                //pop and push random cards from initial deck
                while (deck.Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, deck.Cards.Count);
                    tempList.Add(deck.Cards[randomIndex]);
                    deck.Cards.RemoveAt(randomIndex);
                }
                deck.Cards = tempList;
            }
            return deck;
        }
    }
}
