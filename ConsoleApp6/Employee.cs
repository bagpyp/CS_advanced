using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Employee : Person, IQuittable
    {
        public int Id { get; set; }
        public void Quit()
        {
            this.Id = -1;
        }

        public static bool operator== (Employee employee1, Employee employee2)
        {
            return employee1.Id == employee2.Id;
        }
        public static bool operator!= (Employee employee1, Employee employee2)
        {
            return employee1.Id != employee2.Id;
        }
    }
}
