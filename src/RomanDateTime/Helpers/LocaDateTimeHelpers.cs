using System;
using NodaTime;
using RomanDateTime.Enums;

namespace RomanDateTime.Helpers
{
    internal static class LocalDateTimeHelpers
    {
        internal static LocalDateTime ToLocalDateTime(this DateTime date, Eras era = Eras.AD)
        {
            if (era == Eras.BC)
            {
                var year = (date.Year - 1) == 0 ? 0 : date.Year - 1;
                return new LocalDateTime(-year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
            }

            return new LocalDateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }

        internal static LocalDateTime ToLocalDateTime(int year, int month, int day, int hour, Eras era = Eras.AD)
        {
            if (year < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Year must be between 0 - 9999, if you are after BC dates use the optional Era param");
            }

            if (era == Eras.BC)
            {
                var subYear = ((year - 1) == 0 || year == 0) ? 0 : year - 1;
                return new LocalDateTime(-subYear, month, day, hour, 0, 0, 0);
            }

            return new LocalDateTime(year, month, day, hour, 0, 0, 0);
        }

        internal static double TimeAsFraction(this LocalDateTime date)
        {
            var minFraction = date.Minute != 0 ? ((date.Minute / 100.0) / 60.0) * 100.0 : 0.0;

            return Math.Round((date.Hour + minFraction), 2);
        }

        internal static bool IsLeapYear(this LocalDateTime value)
        {
            if ((value.Year % 400) == 0)
            {
                return true;
            }
            else if ((value.Year % 100) == 0)
            {
                return false;
            }
            else if ((value.Year % 4) == 0)
            {
                return true;
            }

            return false;
        }
    }
}
