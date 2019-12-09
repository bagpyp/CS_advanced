using System;
using System.Collections.Generic;


namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            //1. Create a class. In that class, create three methods, each of which will take one integer parameter in and return an integer. 
            //The methods should do some math operation on the received parameter. 
            //Put this class in a separate .cs file in the application.
            //2. In the Main() program, ask the user what number they want to do the math operations on.
            //3. Call each method in turn, passing the user input to the method. Display the returned integer to the screen.

            NorthAmericanCurrency currency = new NorthAmericanCurrency();

            Console.WriteLine("What dollar amount in American do you wish to convert?");
            string input = Console.ReadLine();
            Console.WriteLine(
                "$" + Math.Round(Convert.ToSingle(input), 2) +
                " in pesos is $" +
                Math.Round(currency.USDtoPeso(Convert.ToSingle(input)), 2)
                );
            Console.WriteLine(
                "$" + Math.Round(Convert.ToSingle(input), 2) +
                " in Canadian dollars is $" +
                Math.Round(currency.USDtoCanadian(Convert.ToSingle(input)), 2)
                );
            Console.ReadKey();

        }
    }
}
