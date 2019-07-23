using System;

namespace API.RomanDate.Helpers
{
    public static partial class DateTimeHelpers
    {
        /// <summary>
        /// Returns the start of the month for the provided DateTime
        /// </summary>
        /// <param name="dateTime">The DateTime to retrieve the start of the month from</param>
        /// <returns>A DateTime representing the start of the month for the provided Date</returns>
        public static DateTime StartOfMonth(this DateTime dateTime) => new DateTime(dateTime.Year, dateTime.Month, 1);
    }
}
