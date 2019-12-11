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
            //Employee employee1 = new Employee() { FirstName = "Sample", LastName = "Student" };
            //employee1.Id = 100;
            //employee1.SayName();

            //IQuittable qEmployee = new Employee() { FirstName = "John", LastName = "Quitter", Id = 100 };
            //qEmployee.Quit();
            ////shouldn't I be able to see that the Id has changed to -1? 
            ////the employee1 object is of type "IQuittable", but was instantiated as a new "Employee"
            ////even though I gave this employee a name and an Id, I can't access that Id (emplyee1.Id DNE)

            //Employee employee2 = new Employee() { FirstName = "Sample", LastName = "Student", Id = 101 };

            //bool areSameEmployee = (employee1 == employee2);
            //Console.WriteLine("It is " + areSameEmployee + " that our two employees are the same person.");

            ////assignment 131
            //GenericEmployee<string> empOne = new GenericEmployee<string>();
            //GenericEmployee<int> empTwo = new GenericEmployee<int>();
            //List<string> thingsOne = new List<string>() { "11", "12", "13" };
            //List<int> thingsTwo = new List<int>() { 21, 22, 23 };
            //empOne.Things = thingsOne;
            //empTwo.Things = thingsTwo;
            ////can't loop through both things but this is my idea of maybe how to do it
            ////List<object> employees = new List<object>() { empOne, empTwo };
            ////foreach (object employee in employees)
            ////{
            ////    foreach (object thing in employee.Things)
            ////    {
            ////        Console.WriteLine(thing);
            ////    }
            ////}
            ////instead just made two for loops...
            //foreach (string thing in empOne.Things)
            //{
            //    Console.WriteLine(thing);
            //}
            //foreach (int thing in empTwo.Things)
            //{
            //    Console.WriteLine(thing);
            //}


            //assignment 140
            List<string> firstNames = new List<string>()
            {
                "Joe", "Joe", "Alex", "Brittany", "Charlie", "Doug", "Eric", "Felicia", "Grace", "Harry"
            };
            List<string> lastNames = new List<string>()
            {
                "Abernathy", "Boggs", "Cunningham", "Dickinson", "Edwards", "Fowley", "Gates", "Hendrick", "Johnson", "Karlile"
            };
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < 10; i++)
            {
                Employee emp = new Employee
                {
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    Id = i + 1
                };
                employees.Add(emp);
            }

            List<Employee> joes = new List<Employee>();

            ////build joes using a foreach
            //foreach (Employee emp in employees)
            //{
            //    if (emp.FirstName == "Joe")
            //    {
            //        joes.Add(emp);
            //    }
            //}

            //build joes using a lambda expression instead

            joes = employees.Where(x => x.FirstName == "Joe").ToList();

            //print joes
            Console.WriteLine("Employees with first name Joe:");
            foreach (Employee joe in joes)
            {
                Console.WriteLine(joe.FirstName + " " + joe.LastName + ", Id: " + joe.Id);
            }

            //another lambda
            List<Employee> bigEmps = new List<Employee>();
            bigEmps = employees.Where(x => x.Id > 5).ToList();

            //print bigEmps
            Console.WriteLine("Employees having Id greater than 5:");
            foreach (Employee bigEmp in bigEmps)
            {
                Console.WriteLine(bigEmp.FirstName + " " + bigEmp.LastName + ", Id: " + bigEmp.Id);
            }

            Console.Read();
        }
    }
}
