using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visiting_the_website
{
    internal class WebsiteStatistics
    {
        Dictionary<string, List<Time>> visitings;
        public WebsiteStatistics()
        {
            visitings = new Dictionary<string, List<Time>>();
        }
        public WebsiteStatistics(Dictionary<string, List<Time>> dict)
        {
            visitings = new Dictionary<string, List<Time>>();
            foreach (var (key, value) in dict)
            {
                visitings[key] = value;
            }
        }
        public void ReadFromStreamReader(StreamReader reader)
        {
            visitings.Clear();
            while (!reader.EndOfStream)
            {
                string[] arr = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] hour = arr[1].Split(':');
                try
                {
                    Time time = new Time(new TimeSpan(Int32.Parse(hour[0]), Int32.Parse(hour[1]), Int32.Parse(hour[2])), Enum.Parse<DayOfWeek>(arr[2]));
                    if (!visitings.Keys.Contains(arr[0]))
                        visitings.Add(arr[0], new List<Time>() { time });
                    else
                        visitings[arr[0]].Add(time);
                }
                catch (Exception ex)
                { continue; }
            }
        }
        public Dictionary<string, int> StatisticOfCustomers()
        {
            Dictionary<string, int> statistic = new Dictionary<string, int>();
            foreach (var (key, value) in visitings)
            {
                statistic.Add(key, value.Count);
            }
            return statistic;
        }
        public Dictionary<string, string> StatisticOfDays()
        {
            Dictionary<string, string> statistic = new Dictionary<string, string>();
            foreach (var (key, value) in visitings)
            {
                statistic[key] = value
                       .GroupBy(i => i.DayOfWeek)
                       .OrderByDescending(grp => grp.Count())
                       .First().Key.ToString();
            }
            return statistic;
        }
        public Dictionary<string, int> StatisticOfHours()
        { 
            Dictionary<string, int> statistic = new Dictionary<string, int>();
            foreach (var (key, value) in visitings)
            {
                statistic[key] = value
                       .GroupBy(i => i.TimeSpan.Hours)
                       .OrderByDescending(grp => grp.Count())
                       .First().Key;
            }
            return statistic;
        }
        public IEnumerable<KeyValuePair<DayOfWeek,int>> AllDaysStatistic()
        {
            Dictionary<DayOfWeek, int> statistic = new Dictionary<DayOfWeek, int>();
            foreach (var (key, value) in visitings)
                foreach (var day in value)
                {
                    if (!statistic.ContainsKey(day.DayOfWeek))
                        statistic.Add(day.DayOfWeek, 1);
                    else
                        statistic[day.DayOfWeek] += 1;
                }
            return statistic.Where(m => (m.Value == statistic.Max(i => i.Value)));
        }
    }
}
