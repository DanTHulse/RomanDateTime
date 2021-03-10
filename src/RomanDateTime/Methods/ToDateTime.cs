using System;
using RomanDateTime.Enums;

namespace RomanDateTime
{
    public partial struct RomanDateTime
    {
        public (DateTime DateTime, Eras Era) ToDateTime()
        {
            var date = this.DateTimeData;
            var dateTime = new DateTime(date.YearOfEra, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);

            return (dateTime, date.Year <= 0 ? Eras.BC : Eras.AD);
        }
    }
}