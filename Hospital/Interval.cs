using Hospital.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    public class Time
    {
        private UInt16 Day { get; }
        private UInt16 Month { get; }
        private UInt16 Year { get; }
        public Time(int Day, int Month, int Year)
        {
            this.Day = Convert.ToUInt16(Day);
            this.Month = Convert.ToUInt16(Month);
            this.Year = Convert.ToUInt16(Year);
        }
    }
    public class Interval
    {
        public Time First_time { get; set; }
        public Time Second_time { get; set; }

    public Interval(Time First_time, Time Second_time)
    {
        this.First_time = First_time;
        this.Second_time = Second_time;
    }
  }
}
