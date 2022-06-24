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

        }
    }
}
