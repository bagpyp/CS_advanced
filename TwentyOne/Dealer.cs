using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }


        public void Deal(List<Card> Hand)
        {
            Console.WriteLine(Deck.Cards.First().ToString() + "\n");
            Hand.Add(Deck.Cards.First());
            Deck.Cards.RemoveAt(0);
        }
    }
}
