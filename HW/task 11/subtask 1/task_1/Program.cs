﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    class Program
    {//Де реєстрація на подію?
        static void Main(string[] args)
        {
            Storage shop1 = StorageText.ReadFromFile(@"D:\.NET course\Storage\task_1\input.txt");
            Console.WriteLine("--------First shop--------");
            StorageText.WriteToConsole(shop1);
            Console.WriteLine("--------Second shop--------");
            Storage shop2 = StorageText.ReadFromFile(@"D:\.NET course\Storage\task_1\input2.txt");
            StorageText.WriteToConsole(shop2);
            Console.WriteLine("----------------\nproducts that are in the first store, but not in the second one");
            foreach (var item in shop1.Except(shop2))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------\nСommon products");
            foreach (var item in shop1.Intersection(shop2))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------\nСombining products from two stores");
            foreach (var item in shop1.Union(shop2))
            {
                Console.WriteLine(item);
            }

            /*
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
            
            
            Storage shop = StorageText.ReadFromFile();
            shop.ChangePrices(10);
            Console.WriteLine("After changing of price:");
            StorageText.WriteToConsole(shop);
            var listOfMeat = shop.SelectMeat();
            Console.WriteLine("All meat:");
            StorageText.WriteToConsole(listOfMeat);


            StorageText.EditInvalidData(new DateTime(2022, 6, 10), shop);
            Console.WriteLine("------------");
            StorageText.WriteToConsole(shop);
            */
            /*
            buy = new Buy(meat);
            IViewerBuy check = new CheckDecor();
            check.ViewerBuy(buy);



            Product product1 = new Product("milk", 30, 499);
            Product product2 = new Product("Ailk0", 60, 222);
            Console.WriteLine(product1.CompareTo(product2));

            List<Product> list = new List<Product>(){ new Product("Cheese", 200, 500),product1, product2};
            ComparerByPrice comparer = new ComparerByPrice();
            list.Sort(comparer);
            foreach (var el in list)
            { 
                Console.WriteLine(el);
            }*/











            //@"D:\.NET course\task_1\task_1\output.txt"
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
