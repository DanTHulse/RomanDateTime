using System;
using System.Text;
using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Extensions;
using RomanDate.Helpers;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private RomanSetDays GetSetDay()
        {
            var day = this.DateTimeData.Day;
            var leapYear = this.DateTimeData.IsLeapYear();
            var cMonth = this.CalendarMonth;

            if (day.Between(cMonth.Kalendae, cMonth.Nonae, false) || day == cMonth.Nonae)
                return RomanSetDays.Nonae;
            else if (day.Between(cMonth.Nonae, cMonth.Idus, false) || day == cMonth.Idus)
                return RomanSetDays.Idus;

            return RomanSetDays.Kalendae;
        }
    }
}