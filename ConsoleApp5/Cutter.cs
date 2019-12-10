using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{

    //1. Create a class. 
        //In that class, create a void method that outputs an integer. 
        //Have the method divide the data passed to it by 2.
    class Cutter
    {
        public void Cut(int input)
        {
            int cut = input / 2;
            Console.WriteLine(input + " over two is " + cut);
        }

        //4. Create a method with output parameters. 
        //and 5. Overload a method.
        public void Cut(int input, out int again)
        {
            int cut = input / 2;
            again = cut / 2;
            Console.WriteLine(input + " over two is " + cut);
        }

    }
    //6. Declare a class to be static.    
    static class Info
    {
        public static string info = "This is a cutting program";
    }
}
