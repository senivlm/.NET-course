using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visiting_the_website
{
    internal class Visiting
    {
        string id;
        Time time;
        public Visiting()
        {
            id = "";
            time = new Time();
        }
        public Visiting(string _id, Time _time)
        {
            id = _id;
            time = _time;
        }

    }
}
