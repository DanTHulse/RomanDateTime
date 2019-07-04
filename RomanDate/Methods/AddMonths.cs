using System;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of months to the value of this instance
        /// </summary>
        /// <param name="months">A whole number of months, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddMonths(int months) => new RomanDateTime(this.DateTimeData.PlusMonths(months));
    }
}