using System;


namespace ConsoleApp5
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Gimme a number");

            //load cutter with entered number
            Cutter cutter = new Cutter
                {
                    Value = Convert.ToInt32(Console.ReadLine())
                };

            //Cut without out parameters
            cutter.Cut();
            Console.WriteLine(cutter.Value);

            //Overloaded Cut() by adding out parameters
            cutter.Cut(out int again, out int againAgain);
            Console.WriteLine(cutter.Value);
            Console.WriteLine(again);
            Console.WriteLine(againAgain);

            Console.ReadLine();
        }
    }
}
