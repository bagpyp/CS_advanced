using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class RootFinder
    {
        public int Find(int input)
        {
            int result = Convert.ToInt32(Math.Sqrt(input));
            return result;
        }

        public int Find(decimal input)
        {
            int result = Convert.ToInt32(Math.Sqrt(decimal.ToDouble(input)));
            return result;
        }

        public int Find(string input)
        {
            int result = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(input)));
            return result;
        }



    }
}
