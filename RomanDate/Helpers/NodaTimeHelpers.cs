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
    }
}