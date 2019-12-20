using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Casino
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }


        public void Deal(List<Card> Hand)
        {
            Console.WriteLine(Deck.Cards.First().ToString() + "\n");
            string card = string.Format(Deck.Cards.First().ToString() + "\n");
            Hand.Add(Deck.Cards.First());
            //log dealt cards to text file, example dir
            using (StreamWriter file = new StreamWriter(@"C:\Users\rober\CS\advanced\TwentyOne\Logs\log.txt", append: true))
            {
                file.WriteLine(DateTime.Now);
                file.WriteLine(card);
            }
            Deck.Cards.RemoveAt(0);
        }
    }
}
