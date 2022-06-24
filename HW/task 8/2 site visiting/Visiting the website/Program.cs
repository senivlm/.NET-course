using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visiting_the_website
{
    class Program
    {
        static void Main(string[] args)
        {
            WebsiteStatistics statistics = new WebsiteStatistics();
            statistics.ReadFromStreamReader(new StreamReader(@"D:\.NET course\Visiting the website\Visiting the website\input.txt"));
            Console.WriteLine("--------Visitings from customers-------");
            foreach(var (key,value) in statistics.StatisticOfCustomers())
                Console.WriteLine(key + " - " + value);
            Console.WriteLine("--------The most popular hour for each customer-------");
            foreach (var (key, value) in statistics.StatisticOfHours())
                Console.WriteLine(key + " - " + value);
            Console.WriteLine("--------The most popular day for each customer-------");
            foreach (var (key, value) in statistics.StatisticOfDays())
                Console.WriteLine(key + " - " + value);
            Console.WriteLine("--------The most popular days at all-------");

            foreach (var (key, value) in statistics.AllDaysStatistic())
            {
                Console.WriteLine(key + " - " + value);
            }
        }
    }
}