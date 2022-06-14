using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    internal class QuarterReport:IReader
    {
        private int apartment;
        private string surname;
        private int lastReading;//останні покази лічильника до початку цього кварталу
        private List<Month> months;
        public QuarterReport()
        {
            this.months = new List<Month>();
            surname = "";
        }
        public QuarterReport(int _apartment, string _surname, int _lastReading, List<Month> _months)
        {
            this.apartment = _apartment;
            this.surname = _surname;
            lastReading = _lastReading;
            months = new List<Month>();
            foreach(var el in _months)
                months.Add(el);
        }
        
        public void ReadFromStreamReader(StreamReader reader)
        {
            string[] strArr =  reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            apartment = Int32.Parse(strArr[0]);
            surname = strArr[1];
            lastReading = Int32.Parse(strArr[2]);
            for (int i = 0; i < 3; i++)
            {
                months.Add(new Month(strArr[3 + 2*i], strArr[4 + 2*i]));
            }
        }
        public override string ToString()
        {
            string str = apartment + "\t" + surname + "\t" + lastReading;
            foreach (var el in months)
                str += ",\t" + el.ToString();
            return str;
        }
        public void PrintToFileSrteam(StreamWriter writer)
        {
            writer.WriteLine(this.ToString());
        }
    }

}
