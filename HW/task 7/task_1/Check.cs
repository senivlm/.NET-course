using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class Check:IViewerBuy
    {
        static public void Print(Buy buy)
        {
            Console.WriteLine(buy);
        }

        public void ViewerBuy(Buy buy)
        {
            Console.WriteLine(buy);
        }
    }
}
