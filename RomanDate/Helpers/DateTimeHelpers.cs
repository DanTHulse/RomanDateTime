using System;
using RomanDate.Enums;

namespace RomanDate.Helpers
{
    internal static class DateTimeHelpers
    {
        internal static double TimeAsFraction(this DateTime date)
        {
            double minFraction = date.Minute != 0 ? ((date.Minute / 100.0) / 60.0) * 100.0 : 0.0;

            return Math.Round((date.Hour + minFraction), 2);
        }

        internal static bool IsLeapYear(this DateTime value)
        {
            if ((value.Year % 400) == 0)
                return true;
            else if ((value.Year % 100) == 0)
                return false;
            else if ((value.Year % 4) == 0)
                return true;
            return false;
        }

        internal static (DateTime date, Eras era) AdvanceYearEras(this DateTime value, Eras era, bool forward = true)
        {
            if (era == Eras.AD)
            {
                if (forward)
                    return (value.AddYears(1), Eras.AD);
                else if (!forward && value.Year != 1)
                    return (value.AddYears(-1), Eras.AD);
                else
                    return (value, Eras.BC);
            }
            else
            {
                if (forward && value.Year != 1)
                    return (value.AddYears(-1), Eras.BC);
                else if (!forward)
                    return (value.AddYears(1), Eras.BC);
                else
                    return (value, Eras.AD);
            }
        }
    }
}