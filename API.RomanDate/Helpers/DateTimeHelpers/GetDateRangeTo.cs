using System;
using System.Collections.Generic;
using System.Linq;

namespace API.RomanDate.Helpers
{
    public static partial class DateTimeHelpers
    {
        /// <summary>
        /// Gets a range of dates between the provided dates
        /// </summary>
        /// <param name="date">The start date of the range</param>
        /// <param name="toDate">The end date of the range</param>
        /// <param name="inclusive">Whether the range should be inclusive, if True, the provided dates are included in the range</param>
        /// <returns>A list of dates between the two provided dates</returns>
        public static IEnumerable<DateTime> GetDateRangeTo(this DateTime date, DateTime toDate, bool inclusive = false)
        {
            var dateList = new List<DateTime>();

            var range = Enumerable.Range(0, new TimeSpan(toDate.Ticks - date.Ticks).Days);

            dateList = range.Select(s => date.Date.AddDays(s)).ToList();

            if (inclusive)
            {
                dateList.Add(toDate);
            }

            return dateList;
        }
    }
}
