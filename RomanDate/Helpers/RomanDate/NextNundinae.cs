using System;

namespace RomanDate.Helpers.RomanDate
{
    public static partial class RomanDateHelpers
    {
        /// <summary>
        /// Returns an instance of <see cref="RomanDateTime"/> that represents the date of the next nundinae date from the current instance
        /// </summary>
        /// <param name="date">The instance of <see cref="RomanDateTime"/>.</param>
        /// <returns>A new instance of <see cref="RomanDateTime"/> representing the next nundinae (market day)</returns>
        public static RomanDateTime NextNundinae(this RomanDateTime date)
        {
            var dateTime = date.DateTimeData;
            var nundinae = ReturnNundinaeForYear(dateTime);

            var daysUntil = (int)nundinae - (int)date.NundinalLetter;

            return date.AddDays(daysUntil <= 0 ? 8 - Math.Abs(daysUntil) : daysUntil);
        }
    }
}