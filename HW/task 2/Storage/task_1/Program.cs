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
            Console.WriteLine("weight: " + buy.Weight);
            Meat meat = new Meat("chiсken", 150, 500, Grade.Premium);
            Console.WriteLine(meat);
            DairyProduct product = new DairyProduct("Milk", 30, 400, 5);
            Console.WriteLine(product);
            Console.WriteLine("------------------");
            Check.Print(new Buy(meat));
            Check.Print(new Buy(product));
            Console.WriteLine("------------------");

            meat.Price = 100;
            Console.WriteLine(meat);

            Storage shop = new Storage();
            shop.ReadFromConsole();
            shop.ChangePrices(10);
            Console.WriteLine("After changing of price:");
            shop.WriteToConsole();
            var listOfMeat = shop.SelectMeat();
            Console.WriteLine("All meat:");
            listOfMeat.WriteToConsole();
            /*
d cream 50 200 14
m lamb 300 400 First
d milk 40 300 6
d butter 60 200 30
m beef 200 1000 Premium
             */
        }
       
    }
}