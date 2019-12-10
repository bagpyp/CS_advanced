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
            Employee employee1 = new Employee() { FirstName = "Sample", LastName = "Student" };
            employee1.Id = 100;
            employee1.SayName();

            IQuittable qEmployee = new Employee() { FirstName = "John", LastName = "Quitter", Id = 100 };
            qEmployee.Quit();
            //shouldn't I be able to see that the Id has changed to -1? 
            //the employee1 object is of type "IQuittable", but was instantiated as a new "Employee"
            //even though I gave this employee a name and an Id, I can't access that Id (emplyee1.Id DNE)

            Employee employee2 = new Employee() { FirstName = "Sample", LastName = "Student", Id = 101 };

            bool areSameEmployee = (employee1 == employee2);
            Console.WriteLine("It is " + areSameEmployee + " that our two employees are the same person.");

            Console.Read();
        }
    }
}
