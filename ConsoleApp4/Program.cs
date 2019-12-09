using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Add Five Or...!");
            Console.WriteLine("Enter a number to have Five added to.");
            int input1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("If you'd like me to add a different number to " + input1
                + ", enter it now. Otherwise, press Enter and I'll show you what you've got!");
            string input2 = Console.ReadLine();

            Test test = new Test();
            if (input2 == "")
            {
                Console.WriteLine("5 plus " + input1 + " equals " + test.AddFiveOr(input1));
            }
            else
            {
                Console.WriteLine(input1 + " plus " + input2 + " equals " + test.AddFiveOr(input1, Convert.ToInt32(input2)));
            }

            Console.ReadLine();
        }
    }
}
