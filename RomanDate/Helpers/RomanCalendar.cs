using System;
using System.Collections.Generic;
using NodaTime;

namespace RomanDate.Helpers
{
    public static class RomanCalendar
    {
        public static IEnumerable<RomanDateTime> GetMonthOfDates(int year, int month)
        {
            var daysInMonth = CalendarSystem.Gregorian.GetDaysInMonth(year, month);
            var coll = new List<RomanDateTime>();

            for (var x = 0; x < daysInMonth; x++)
            {
                coll.Add(new RomanDateTime(year, month, x + 1));
            }

            return coll;
        }
    }
}