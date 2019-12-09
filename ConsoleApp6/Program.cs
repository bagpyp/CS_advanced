using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main()
        {
            Employee employee = new Employee() { FirstName = "Sample", LastName = "Student" };
            employee.SayName();

            Console.Read();
        }
    }
}
