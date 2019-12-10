using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class GenericEmployee<T> : Person
    {
        public int Id { get; set; }
        public List<T> Things { get; set; }

    }
}
