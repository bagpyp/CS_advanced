using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            RootFinder rootFinder = new RootFinder();

            int result = rootFinder.Find(12);
            Console.WriteLine(result);

            result = rootFinder.Find(1212.12m);
            Console.WriteLine(result);

            result = rootFinder.Find("12121212");
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
