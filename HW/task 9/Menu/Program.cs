using System;
using System.Collections.Generic;

namespace Menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = WorkWithFile.ReadMenu(new StreamReader(@"D:\.NET course\Menu\Menu\Menu.txt"));
            Console.WriteLine(menu.ToString());
            PriceKurant prices = WorkWithFile.ReadPriceKurant(new StreamReader(@"D:\.NET course\Menu\Menu\Prices.txt"));
            Console.WriteLine(prices);
            double total = 0;
            // тут треба перевірку, чи порахований результат
            MenuService.TryGetMenuTotalSum(menu, prices, out total);
            Console.WriteLine(total);
        }
    }
}
