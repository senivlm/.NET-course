using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class CheckDecor : IViewerBuy
    {
        public void ViewerBuy(Buy buy)
        {
            Console.WriteLine("*****************");
            Console.WriteLine(buy);
            Console.WriteLine("*****************");

        }
    }
}
