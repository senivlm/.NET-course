using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Quarters
    {
        First = 1,
        Second,
        Third,
        Fourth
    }
    internal class HouseReport:IReader
    {
        private Quarters quarterNumber;
        List<QuarterReport> quarterReports;
        public HouseReport()
        {
            quarterReports = new();
        }
        public HouseReport(List<QuarterReport> _qr, Quarters q_numb)
        {
            quarterReports = new();
            foreach (QuarterReport q in _qr)
                quarterReports.Add(q);
        }
        public void ReadFromStreamReader(StreamReader reader)
        {
            quarterNumber = (Quarters)Int32.Parse(reader.ReadLine());
            int numberOfFlats = Int32.Parse(reader.ReadLine());
            for (int i = 0; i < numberOfFlats; i++)
            {
                QuarterReport qr = new();
                qr.ReadFromStreamReader(reader);
                quarterReports.Add(qr);
            }
        }
        public override string ToString()
        {
            string str =  ((int)quarterNumber).ToString() + "\n";
            foreach (var el in quarterReports)
                str += el.ToString() + "\n";
            return str;
        }
        public void PrintToFileSrteam(StreamWriter writer)
        {
            writer.Write(this.ToString());
        }
    }
}
