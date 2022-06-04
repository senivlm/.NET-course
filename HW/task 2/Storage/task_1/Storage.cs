using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class Storage
    {
        private List<Product> products;

        public Product this[int ind]
        {
            get
            {
                return products[ind];
            }
            set
            {
                products[ind] = value;
            }
        }
        public Storage()
        {
            products = new List<Product>();
        }
        public Storage(List<Product> _products)
        {
            products = new List<Product>();
            this.products = _products;
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void ReadFromConsole()
        {
            Console.WriteLine(
                "------------------------------------\n" +
                "Enter products as\n" +
                "d name price weight expiration_days\n" +
                "m name price weight category\n" +
                "To finish inputting enter empty line\n" +
                "------------------------------------");
            string str = Console.ReadLine();
            while(str != "")
            {
                char[] delim = { ' ' };
                string[] arr = str.Split(delim, 2);
                if (arr.Length == 1)
                {
                    Console.WriteLine("Invalid data!");
                    str = Console.ReadLine();
                    continue;
                }
                if (arr[0] == "d")
                {
                    DairyProduct product = new DairyProduct();
                    try
                    {
                        product.Read(arr[1]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid data!");
                    }
                    products.Add(product);
                    
                }
                else
                {
                    Meat product = new Meat();
                    try
                    {
                        product.Read(arr[1]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid data!");
                    }
                products.Add(product);

                }
                str = Console.ReadLine();
            }

        }
        public void WriteToConsole()
        {
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }
        public void ChangePrices(int percent)
        {
            foreach (Product item in products)
            {
                item.ChangePrice(percent);
            }
        }
        public Storage SelectMeat()
        {
            var allMeat = products.Where(i => i.GetType().Equals(typeof(Meat))).ToList();
            return new Storage(allMeat);
        }
    }
}
