using System;

namespace RomanDateTime
{
    public partial struct RomanDateTime
    {
        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of hours to the value of this instance
        /// </summary>
        /// <param name="hours">A whole number of hours, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddHours(int hours) => new RomanDateTime(this.DateTimeData.PlusHours(hours));

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of days to the value of this instance
        /// </summary>
        /// <param name="days">A whole number of days, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddDays(int days) => new RomanDateTime(this.DateTimeData.PlusDays(days));

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of Roman weeks to the value of this instance
        /// </summary>
        /// <remarks>A Roman week is 8 days long so +1 weeks is the same as +8 days</remarks>
        /// <param name="weeks">A whole number of Roman weeks, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddWeeks(int weeks) => new RomanDateTime(this.DateTimeData.PlusDays((weeks * 8)));

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of months to the value of this instance
        /// </summary>
        /// <param name="months">A whole number of months, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddMonths(int months) => new RomanDateTime(this.DateTimeData.PlusMonths(months));

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of years to the value of this instance
        /// </summary>
        /// <param name="years">A whole number of years, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddYears(int years) => new RomanDateTime(this.DateTimeData.PlusYears(years));
    }
}