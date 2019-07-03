using System;
using System.Text;
using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Helpers;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private NundinalLetters GetNundinalLetter()
        {
            var year = this.DateTimeData.YearOfEra;

            var startPosition = (NundinalLetters)(year % 8);

            var daysFromStart = Math.Abs(this.DateTimeData.Minus(new LocalDateTime(this.DateTimeData.Year, 1, 1, 0, 0)).Days);
            var daysFromCycle = (((daysFromStart + (int)startPosition) - 1) % 8);

            if (daysFromCycle > 8)
                daysFromCycle -= 8;

            var cyclePosition = (NundinalLetters)daysFromCycle;

            return cyclePosition;
        }

        private string GetRomanDayString(bool shorten = false)
        {
            var sb = new StringBuilder();
            var rMonth = this.ReferenceMonth;
            var sDay = this.RomanSetDay;
            var dPrefix = this.RomanDayPrefix;

            sb.Append($"{(shorten ? dPrefix.Short : dPrefix.Long)} ");

            if (this.DaysUntilSetDay > 2)
                sb.Append($"{this.DaysUntilSetDay.ToRomanNumerals()} ");

            if (this.DaysUntilSetDay == 0)
                sb.Append($"{(shorten ? sDay.Short : sDay.Ablative)} ");
            else
                sb.Append($"{(shorten ? sDay.Short : sDay.Accusative)} ");

            if (this.DaysUntilSetDay > 2)
                sb.Append($"{(shorten ? rMonth.Short : rMonth.Accusative)}");
            else
                sb.Append($"{(shorten ? rMonth.Short : rMonth.Ablative)}");

            return sb.ToString().TrimStart();
        }

        private string GetRomanYear()
        {
            return this.DateTimeData.YearOfEra.ToRomanNumerals();
        }

        private string GetAucYear()
        {
            var auc = 753;
            var year = (auc += this.DateTimeData.Year);
            return year <= 0 ? "" : year.ToRomanNumerals();
        }

        private string GetTime(bool hour = false)
        {
            var cMonth = this.CalendarMonth;
            var current = this.DateTimeData.TimeAsFraction();
            var dayHours = 0;
            var nightHours = 0;

            for (var x = 0; current > 0.1; x++)
            {
                if (x < 6 || x.Between(18, 23))
                {
                    nightHours++;
                    current -= cMonth.HourLengthNight;
                }
                else if (x.Between(6, 17))
                {
                    dayHours++;
                    current -= cMonth.HourLengthDay;
                }
            }

            if ((nightHours > 0 && dayHours == 0) || nightHours > 6)
            {
                if (nightHours.Between(7, 9))
                    return hour ? $"hora noctis {(nightHours - 6).ToRomanNumerals()}" : $"Vigila Prima";
                if (nightHours.Between(10, 12))
                    return hour ? $"hora noctis {(nightHours - 6).ToRomanNumerals()}" : $"Vigila Secunda";
                if (nightHours.Between(1, 3))
                    return hour ? $"hora noctis {(nightHours + 6).ToRomanNumerals()}" : $"Vigila Tertia";
                if (nightHours.Between(4, 6))
                    return hour ? $"hora noctis {(nightHours + 6).ToRomanNumerals()}" : $"Vigila Quarta";
            }
            else if (dayHours != 0)
            {
                return $"hora {dayHours.ToRomanNumerals()}";
            }

            return hour ? $"hora noctis VII" : $"Vigila Tertia";
        }

        private RomanMonths GetReferenceMonth()
        {
            if (this.DateTimeData.Day != 1 && this.RomanSetDay.SetDay == SetDays.Kalendae)
                return RomanMonths.GetRomanMonth(this.CalendarMonth.Month.Next());

            return this.CalendarMonth;
        }

        private RomanDayPrefixes GetDayPrefix()
        {
            var day = this.DateTimeData.Day;
            var leapYear = this.DateTimeData.IsLeapYear();
            var cMonth = this.CalendarMonth;

            if (day.In(new int[] { cMonth.Kalendae, cMonth.Nonae, cMonth.Idus }))
                return new RomanDayPrefixes();
            else if (day.In(new int[]
                {
                    cMonth.Nonae - 1, cMonth.Idus - 1, cMonth.End + (leapYear &&
                        cMonth.Month == Months.Februarius ? 1 : 0)
                }))
                return RomanDayPrefixes.Pridie;
            else if (day == 24 && cMonth.Month == Months.Februarius && leapYear)
                return RomanDayPrefixes.AnteDiemBis;

            return RomanDayPrefixes.AnteDiem;
        }

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

        private RomanMonths GetCalendarMonth()
        {
            if (this.DateTimeData.Month != 0 && this.DateTimeData.Month <= 12)
            {
                return (RomanMonths.GetRomanMonth((Months)this.DateTimeData.Month));
            }

            return default(RomanMonths);
        }

        private ConsularDate GetConsularDate()
        {
            var auc = 753;
            var year = (auc += this.DateTimeData.Year);
            return ConsularNaming.ReturnConsularYearData(year);
        }

        private ElectedMagistrates GetMagistrates()
        {
            if (this.ConsularData != null)
            {
                return new ElectedMagistrates(this.ConsularData);
            }

            return null;
        }

        private string GetConsularYear()
        {
            return this.ConsularData.ParseConsularYear();
        }
    }
}