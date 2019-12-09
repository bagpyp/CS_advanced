using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate and assign new 52-card deck
            Deck deck = new Deck();
            deck = Shuffle(deck);

            //view deck and its count
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }
            Console.WriteLine(deck.Cards.Count);
            Console.ReadLine();
        }

        //create a method (outside of main) for shuffling the deck
        public static Deck Shuffle(Deck deck)
        {
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
            return deck;
            
        }
    }
}
