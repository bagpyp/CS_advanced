using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        //1. Create a class. In that class, create a void method that takes two integers as parameters. 
            //sHave the method do a math operation on the first integer and display the second integer to the screen.

        //2. In the Main() method of the console app, instantiate the class.

        //3. Call the method in the class, passing in two numbers.

        //4. Call the method in the class, specifying the parameters by name.
        static void Main()
        {
            Dumb dumb = new Dumb();
            dumb.Go(1, 10);
            Console.ReadLine();
            dumb.Go(one: 2, two: 20);
            Console.ReadLine();
        }

    }
}
