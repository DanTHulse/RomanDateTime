using System;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of years to the value of this instance
        /// </summary>
        /// <param name="years">A whole number of years, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddYears(int years)
        {
            return new RomanDateTime(this.DateTimeData.PlusYears(years));
        }
    }
}