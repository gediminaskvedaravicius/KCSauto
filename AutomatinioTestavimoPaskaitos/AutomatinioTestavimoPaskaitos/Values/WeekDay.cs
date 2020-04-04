using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatinioTestavimoPaskaitos.Values
{
    public class WeekDay
    {
        public static WeekDay MONDAY = new WeekDay("Monday");
        public static WeekDay TUESDAY = new WeekDay("Tuesday");
        public static WeekDay WEDNESDAY = new WeekDay("Wednesday");
        public static WeekDay THURSDAY = new WeekDay("Thursday");
        public static WeekDay FRIDAY = new WeekDay("Friday");
        public static WeekDay SATURDAY = new WeekDay("Saturday");
        public static WeekDay SUNDAY = new WeekDay("Sunday");

        public string day;

        public WeekDay(string day)
        {
            this.day = day;
        }

    }
}
