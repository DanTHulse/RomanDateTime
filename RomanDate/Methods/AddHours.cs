using System;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of hours to the value of this instance
        /// </summary>
        /// <param name="hours">A whole number of hours, can be positive or negative.</param>
        /// <returns>new <see cref="RomanDateTime"/></returns>
        public RomanDateTime AddHours(int hours)
        {
            return new RomanDateTime(this.DateTimeData.PlusHours(hours));
        }
    }
}