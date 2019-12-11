using System;

namespace ConsoleApp9
{
    class Program
    {
        static void Main()
        {
            Number number = new Number() { Amount = 12.45m };
            Console.WriteLine(number.Amount);
        }


        public struct Number
        {
            public decimal Amount { get; set; }
        }

    }
}
