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
        private RomanMonths GetReferenceMonth()
        {
            if (this.DateTimeData.Day != 1 && this.RomanSetDay.SetDay == SetDays.Kalendae)
                return RomanMonths.GetRomanMonth(this.CalendarMonth.Month.Next());

            return this.CalendarMonth;
        }
    }
}