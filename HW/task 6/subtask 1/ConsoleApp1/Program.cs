using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HouseReport report = new HouseReport();
            report.ReadFromStreamReader(new StreamReader(@"D:\.NET course\Electricity accounting\ConsoleApp1\input.txt"));
            Console.WriteLine(report.ToString());
            StreamWriter writer = new StreamWriter(@"D:\.NET course\Electricity accounting\ConsoleApp1\output.txt");
            report.PrintToFileSrteam(writer);
            writer.Close();
            
        }
    }
}