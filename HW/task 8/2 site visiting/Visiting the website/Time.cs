using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visiting_the_website
{
    enum DayOfWeek
    {
        Monday, 
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    internal class Time
    {
        private TimeSpan timeSpan;
        private DayOfWeek day;

        public TimeSpan TimeSpan
        { get { return timeSpan; } }
        public DayOfWeek DayOfWeek
        { get { return day; } }
        public Time()
        {
            timeSpan = new TimeSpan();
            day = DayOfWeek.Monday;
            
        }
        public Time(TimeSpan _timespan, DayOfWeek _day)
        {
            timeSpan = _timespan;
            day = _day;
        }
    }
    
}
