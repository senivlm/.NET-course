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
        HashSet<ApatrmentReport> quarterReports;
        public HouseReport()
        {
            quarterReports = new();
        }
        public HouseReport(IEnumerable<ApatrmentReport> _qr, Quarters q_numb)
        {
            quarterReports = new();
            foreach (ApatrmentReport q in _qr)
                quarterReports.Add(q);
        }
        public ApatrmentReport this[int i]
        {
            get
            {
                return quarterReports.First(item => item.Appartment == i);
            }
        }
        public void ReadFromStreamReader(StreamReader reader)
        {
            if (reader.EndOfStream)
                throw new Exception("File is empty");
            quarterNumber = (Quarters)Int32.Parse(reader.ReadLine());
            int numberOfFlats = Int32.Parse(reader.ReadLine());
            for (int i = 0; i < numberOfFlats; i++)
            {
                ApatrmentReport qr = new();
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

        public ApatrmentReport MaxElectricityArrears(double uah_kwh)
        {
            /*int max = quarterReports.Max(x => x.QuarterUsing());
            return quarterReports.First(x => x.QuarterUsing() == max);*/
            
            ApatrmentReport max = null;
            int quarterKwh = 0;//використовуємо змінні для збереженя кіловат, щоб не викливати зайвий раз метод QuarterUsing()
            int maxQuarterKwh = 0;
            foreach (var item in quarterReports)
            {
                quarterKwh = item.QuarterUsing();
                if (quarterKwh > maxQuarterKwh)
                {
                    max = item;
                    maxQuarterKwh = quarterKwh;
                }
            }
            return max;
        }
        public List<ApatrmentReport> ZeroUsing()
        {
            return quarterReports.Where(item => item.QuarterUsing() == 0).ToList();
        }
        public Dictionary<ApatrmentReport, double> QuarterPayments(double uah_kwh)
        {
            Dictionary<ApatrmentReport, double> result = new ();
            foreach (var item in quarterReports)
            {
                result[item] = item.QuarterPayment(uah_kwh);
            }
            return result;
        }

        public Dictionary<ApatrmentReport, int> DaysFromLastReading()
        {
            Dictionary<ApatrmentReport, int> result = new ();
            foreach (var item in quarterReports)
            {
                result[item] = (DateTime.Now - item.LastReading).Days;
            }
            return result;
        }

        public static HouseReport operator+(HouseReport first, HouseReport second)
        {
            if(first.quarterNumber != second.quarterNumber)
                return null;
            //HashSet<ApatrmentReport> firstSet = new(first.quarterReports);
            //HashSet<ApatrmentReport> secondSet = new(second.quarterReports);
            return new HouseReport(first.quarterReports.Union(second.quarterReports).ToList(), first.quarterNumber);
            /*
            HouseReport result = new HouseReport();
            return new HouseReport( first.quarterReports.Concat(second.quarterReports).ToList(), first.quarterNumber);
        */
        }
        public static HouseReport operator -(HouseReport first, HouseReport second)
        {
            if (first.quarterNumber != second.quarterNumber)
                return null;
            return new HouseReport(first.quarterReports.Except(second.quarterReports).ToList(), first.quarterNumber);
        }
    }
}
