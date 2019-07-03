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
        private int GetDaysUntil()
        {
            var day = this.DateTimeData.Day;
            var leapYear = this.DateTimeData.IsLeapYear();
            var cMonth = this.CalendarMonth;

            if (day.Between(cMonth.Kalendae, cMonth.Nonae, false))
                return (cMonth.InterKalendae + 1) - ((day - cMonth.Kalendae) - 1);
            else if (day.Between(cMonth.Nonae, cMonth.Idus, false))
                return (cMonth.InterNonae + 1) - ((day - cMonth.Nonae) - 1);
            else if (day.Between(cMonth.Idus, cMonth.End + (leapYear &&
                    cMonth.Month == Months.Februarius ? 1 : 0), false))
            {
                var daysBeforeKalendis = (cMonth.InterIdus + 1) - ((day - cMonth.Idus) - 1);

                if (leapYear && cMonth.Month == Months.Februarius && day <= 24)
                    return daysBeforeKalendis;
                if (leapYear && cMonth.Month == Months.Februarius && day > 24)
                    return daysBeforeKalendis + 1;
                else
                    return daysBeforeKalendis;
            }

            return 0;
        }
    }
}