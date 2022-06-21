using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Month
    {
        private DateTime date;
        private int meterReading;
        public int MeterReading { get { return meterReading; }}
        public Month()
        {
            date = new DateTime();
        }
        public Month(DateTime _date, int _meterReading)
        {
            date = _date;
            meterReading = _meterReading;
        }

        public Month(string _date, string _number)
        {
            string[] arr = _date.Split('.');
            date = new DateTime(2000 + int.Parse(arr[2]), int.Parse(arr[1]), int.Parse(arr[0]));
            meterReading = int.Parse(_number);
        }
        public DateTime Date { get { return date; } }
        public override string ToString()
        {
            return date.ToString("   dd MMMM yy - ") + String.Format("{0,-10}", meterReading);
        }
        public void PrintToFileSrteam(StreamWriter writer)
        {
            writer.WriteLine(this.ToString());
        }
    }
}
