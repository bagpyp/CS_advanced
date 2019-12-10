using System;


namespace ConsoleApp5
{
    class Program
    {
        static void Main()
        {
            //using static class:
            Console.WriteLine(Info.info);

            //2. In the Main() method, instantiate that class.
            Cutter cutter = new Cutter();


            //3.Have the user enter a number.Call the method on that number. 
                //Display the output to the screen. 
                //It should be the entered number, divided by two.
            Console.WriteLine("Gimme a number");
            int number = Convert.ToInt32(Console.ReadLine());
            cutter.Cut(number);

            //using method with out-parameters:

            Console.WriteLine("Gimme another");
            number = Convert.ToInt32(Console.ReadLine());
            cutter.Cut(number, out int again);
            Console.WriteLine("and again: " + again);

            Console.ReadLine();

        }
    }
}
