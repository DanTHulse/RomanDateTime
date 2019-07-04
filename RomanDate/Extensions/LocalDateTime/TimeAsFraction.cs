using System;
using NodaTime;

namespace RomanDate.Extensions
{
    internal static partial class LocalDateTimeEx
    {
        internal static double TimeAsFraction(this LocalDateTime date)
        {
            var minFraction = date.Minute != 0 ? ((date.Minute / 100.0) / 60.0) * 100.0 : 0.0;

            return Math.Round((date.Hour + minFraction), 2);
        }
    }
}
