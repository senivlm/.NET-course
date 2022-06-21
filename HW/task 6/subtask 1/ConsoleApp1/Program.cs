using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        const double uah_kwh = 1.5;


        static void Main(string[] args)
        {
            HouseReport report = new HouseReport();
            try
            {
                report.ReadFromStreamReader(new StreamReader(@"D:\.NET course\Electricity accounting\ConsoleApp1\input.txt"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Try to enter new input file :");
                string path = Console.ReadLine();
                try
                {
                    report.ReadFromStreamReader(new StreamReader(path));
                }
                catch (Exception exeprion)
                {
                    Console.WriteLine(exeprion.Message);
                    return;
                }
            }
            Console.WriteLine(report.ToString());
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(@"D:\.NET course\Electricity accounting\ConsoleApp1\output.txt");
                report.PrintToFileSrteam(writer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Try to enter new output file :");
                string path = Console.ReadLine();
                try
                {
                    writer = new StreamWriter(path);
                    report.PrintToFileSrteam(writer);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            
            
            int num = 2;
            Console.WriteLine($"Report number {num + 1}");
            Console.WriteLine(report[num]);
            Console.WriteLine("Max electricity arrears");
            Console.WriteLine( report.MaxElectricityArrears(uah_kwh));
            Console.WriteLine("No electricity was used in :");
            foreach (var item in report.ZeroUsing())
            {
                Console.WriteLine(item.Info);
            }
            Console.WriteLine("Total :");
            foreach (var item in report.QuarterPayments(uah_kwh))
            {
                Console.WriteLine(item.Key.Info + "\t" + item.Value);
            }
            Console.WriteLine("Days from last meter reading : ");
            foreach (var item in report.DaysFromLastReading())
            {
                Console.WriteLine(item.Key.Info + "\t" + item.Value);
            }
        }
    }
}