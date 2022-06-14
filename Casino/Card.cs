using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class Card
    {
        int color;
        String name;
        int value;
        


        public String ToString()
        {
            return $"{color} , {name} , {value}";
        }
    }
}
