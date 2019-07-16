using System;

namespace API.RomanDate.Helpers
{
    public static partial class DateTimeHelpers
    {
        /// <summary>
        /// Returns the end of the month for the provided DateTime
        /// </summary>
        /// <param name="dateTime">The DateTime to retrieve the end of the month from</param>
        /// <returns>A DateTime representing the end of the month for the provided Date</returns>
        public static DateTime EndOfMonth(this DateTime dateTime) => new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddMilliseconds(-1);
    }
}
