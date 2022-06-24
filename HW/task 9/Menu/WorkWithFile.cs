using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal static class WorkWithFile
    {
        public static Menu ReadMenu(StreamReader reader)
        {
            Menu menu = new Menu();
            while(!reader.EndOfStream)
            {
                menu.AddDish(ReadDish(reader));
            }
            return menu;
        }
        public static Dish ReadDish(StreamReader reader)
        {
            string str = reader.ReadLine();
            Dish dish = new Dish(str);
            str = reader.ReadLine();
            while((str != "")&&(str!=null))
            {
                try
                {
                    string[] arr = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    dish.AddIngredient(arr[0], Int32.Parse(arr[1]));
                }
                catch (Exception ex)
                {
                    throw new Exception();
                    continue;

                }
                str = reader.ReadLine();
            }
            //try//the last line
            //{
            //    string[] arr = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //    dish.AddIngredient(arr[0], Int32.Parse(arr[1]));
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception();
            //}
            return dish;
        }
        public static PriceKurant ReadPriceKurant(StreamReader reader)
        {
            PriceKurant prices = new PriceKurant();

            while (!reader.EndOfStream)
            {
                string[] arr = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                prices.AddPrice(arr[0], Int32.Parse(arr[1]));
            }
            return prices;
        }
        public static void PrintToConsole(Menu menu)
        {
            Console.WriteLine(menu);
        }
        public static void PrintToConsole(Dish dish)
        {
            Console.WriteLine(dish);
        }
    }
}
