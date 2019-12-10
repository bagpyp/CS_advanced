using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    interface IWalkAway
    {
        //.NET Framework supports multiple inheritances of interfaces
        void WalkAway(Player player);
    }
}
