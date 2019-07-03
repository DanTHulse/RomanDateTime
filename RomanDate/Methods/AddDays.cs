using System;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of days to the value of this instance
        /// </summary>
        /// <param name="days">A whole number of days, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddDays(int days)
        {
            return new RomanDateTime(this.DateTimeData.PlusDays(days));
        }
    }
}