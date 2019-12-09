﻿using System;
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

        //create a method (outside of main) for shuffling the deck
        public void Shuffle(int times = 1)
        {
            //shuffle the deck "times" times (default = 1)
            for (int i = 0; i < times; i++)
            {

                //instantiate a temporary list to store cards
                List<Card> tempList = new List<Card>();
                Random random = new Random();

                //pop and push random cards from initial deck
                while (this.Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, this.Cards.Count);
                    tempList.Add(this.Cards[randomIndex]);
                    this.Cards.RemoveAt(randomIndex);
                }
                this.Cards = tempList;
            }
        }

    }
}
