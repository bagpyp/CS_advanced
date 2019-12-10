using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        
        static void Main()
        {
            try
            {
                Console.WriteLine("What Day of the Week is it?");
                Day day;
                Enum.TryParse(Console.ReadLine(), out day);
                Console.WriteLine(day + ", huh");
            }
            catch (Exception)
            {
                Console.WriteLine("Don't be cheeky!");
            }
            Console.ReadLine();
        }
        public enum Day
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}
