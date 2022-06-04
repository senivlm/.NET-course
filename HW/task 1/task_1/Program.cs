using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Buy buy = new Buy();
            Console.WriteLine(buy);
            Product product = new Product("banana", 40, 600);
            Console.WriteLine(product);
            Buy buy1 = new Buy(product);
            Check.Print(buy1);
            Buy buy2 = new Buy(new Product("shugar", 60, 1000), 3);
            Check.Print(buy2);
        }
       
    }
}