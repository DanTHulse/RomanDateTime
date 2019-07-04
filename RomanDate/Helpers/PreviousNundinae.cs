using System;
using System.Linq;
using NodaTime;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate.Helpers
{
    public static partial class RomanDateHelpers
    {
        /// <summary>
        /// Returns an instance of <see cref="RomanDateTime"/> that represents the date of the previous nundinae date from the current instance
        /// </summary>
        /// <param name="date">The instance of <see cref="RomanDateTime"/>.</param>
        /// <returns>A new instance of <see cref="RomanDateTime"/> representing the previous nundinae (market day)</returns>
        public static RomanDateTime PreviousNundinae(this RomanDateTime date)
        {
            var dateTime = date.DateTimeData;
            var nundinae = ReturnNundinaeForYear(dateTime);

            var daysFrom = (int)nundinae - (int)date.NundinalLetter;

            return date.AddDays(daysFrom >= 0 ? -(8 - Math.Abs(daysFrom)) : daysFrom);
        }
    }
}