using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSampleApp
{
    class Program
    {
        static void Main()
        {
            var context = new MyContext();
            var emp = new Employee()
            {
                EmpID = 1,
                EmpName = "King Kong",
                Address = "Skull Island"
            };
            context.Employees.Add(emp);
            context.SaveChanges();
        }
    }
}
