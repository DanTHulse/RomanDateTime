using System;
using NodaTime;

namespace RomanDate.Helpers
{
    public static class NodaTimeHelpers
    {
        public static LocalDateTime ToLocalDateTime(this DateTime date)
        {
            return new LocalDateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, CalendarSystem.Gregorian);
        }

        public static double TimeAsFraction(this LocalDateTime date)
        {
            double minFraction = date.Minute != 0 ? ((date.Minute / 100.0) / 60.0) * 100.0 : 0.0;

            return Math.Round((date.Hour + minFraction), 2);
        }

        public static bool IsLeapYear(this LocalDateTime value)
        {
            return (DateTime.DaysInMonth(value.Year, 2) == 29);
        }
    }
}