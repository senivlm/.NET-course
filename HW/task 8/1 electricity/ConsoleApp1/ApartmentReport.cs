using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    internal class ApatrmentReport:IReader
    {
        private int apartment;
        private string surname;
        private int firstReading;//останні покази лічильника до початку цього кварталу
        private List<Month> months;
        public ApatrmentReport()
        {
            this.months = new List<Month>();
            surname = "";
        }
        public ApatrmentReport(int _apartment, string _surname, int _fistReading, List<Month> _months)
        {
            this.apartment = _apartment;
            this.surname = _surname;
            firstReading = _fistReading;
            months = new List<Month>();
            foreach(var el in _months)
                months.Add(el);
        }
        
        public DateTime LastReading
        {
            get { return months[months.Count-1].Date; }
        }
        public int Appartment { get { return apartment; } }
        public string Info
        {
            get
            {
                return apartment + " - " + surname;
            }
        }
        public void ReadFromStreamReader(StreamReader reader)
        {
            string[] strArr =  reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            apartment = Int32.Parse(strArr[0]);
            surname = strArr[1];
            firstReading = Int32.Parse(strArr[2]);
            for (int i = 0; i < 3; i++)
            {
                months.Add(new Month(strArr[3 + 2*i], strArr[4 + 2*i]));
            }
        }
        public override string ToString()
        {
            string str = String.Format("{0,-5}", apartment) + String.Format("{0,-15}", surname) + String.Format("{0,-10}", firstReading);
            foreach (var el in months)
                str += "|" + el.ToString();
            return str;
        }
        public void PrintToFileSrteam(StreamWriter writer)
        {
            writer.WriteLine(this.ToString());
        }
        public int QuarterUsing()
        {
            return months[2].MeterReading - firstReading;
        }
        public double QuarterPayment(double uah_kwh)
        {
            return QuarterUsing() * uah_kwh;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if ((obj.GetType()) != typeof(ApatrmentReport))
                return false;
            ApatrmentReport other = (ApatrmentReport)obj;
            if ((other.apartment != apartment) || (other.surname != surname))
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(apartment, surname);
        }
    }

}
