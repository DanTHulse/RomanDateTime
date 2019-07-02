using System;
using RomanDate.Enums;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        /// <summary>
        /// Converts this instance to a standard <see cref="DateTime"/> as well as the era it represents
        /// </summary>
        /// <returns>A <see cref="ValueTuple"/> containing a <seealso cref="DateTime"/> and <seealso cref="Eras"/></returns>
        public (DateTime DateTime, Eras Era) ToDateTime()
        {
            var date = this.DateTimeData;
            var dateTime = new DateTime(date.YearOfEra, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);

            return (dateTime, date.Year <= 0 ? Eras.BC : Eras.AD);
        }
    }
}