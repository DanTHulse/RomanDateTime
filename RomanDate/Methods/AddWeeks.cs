using System;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of Roman weeks to the value of this instance
        /// </summary>
        /// <remarks>A Roman week is 8 days long so +1 weeks is the same as +8 days</remarks>
        /// <param name="weeks">A whole number of Roman weeks, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddWeeks(int weeks)
        {
            return new RomanDateTime(this.DateTimeData.PlusDays((weeks * 8)));
        }
    }
}