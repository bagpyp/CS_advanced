using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class Deck
    {
        public Deck()
        {
            //create a list of cards (pre-instantiated below)
            //
            Cards = new List<Card>();

            //two sets to cross
            List<string> suits = new List<string>()
            {
                "Spades", "Hearts", "Clubs", "Diamonds"
            };
            List<string> faces = new List<string>()
            {
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten",
                "Jack",
                "Queen",
                "King",
                "Ace"
            };
            
            //iterate to build deck
            foreach (string suit in suits)
            {
                foreach (string face in faces)
                {
                    Card card = new Card()
                    {
                        Suit = suit,
                        Face = face,
                    };
                    Cards.Add(card);
                }
            }

            //

        }

        //instantiate the list of cards, property of Deck, outside of constructor
        public List<Card> Cards { get; set; }

    }
}
