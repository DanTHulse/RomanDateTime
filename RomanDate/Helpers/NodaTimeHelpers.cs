using System;
using NodaTime;
using RomanDate.Enums;

namespace RomanDate.Helpers
{
    public static class NodaTimeHelpers
    {
        public static LocalDateTime ToLocalDateTime(this DateTime date, Eras era = Eras.AD)
        {
            if (era == Eras.BC)
            {
                var year = (date.Year - 1) == 0 ? 0 : -(date.Year - 1);
                return new LocalDateTime(year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
            }

            return new LocalDateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
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