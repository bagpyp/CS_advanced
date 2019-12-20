using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstSampleApp
{
    public class Employee
    {
        public Employee()
        {

        }
        [Key]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
    }
}
