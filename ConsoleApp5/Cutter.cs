using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Cutter
    {
        public int Value { get; set; }
        
        //method with no out parameters
        public void Cut()
        {
            this.Value /= 2;
        }

        //method that spits out result twice moreover
        public void Cut(out int Again, out int AgainAgain)
        {
            this.Value /= 2;
            Again = this.Value / 2;
            AgainAgain = Again / 2;
        }

    }
}
