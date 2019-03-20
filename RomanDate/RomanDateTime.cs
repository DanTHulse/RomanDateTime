using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanDate
{
    public struct RomanDateTime
    {
        public string Year => GetRomanYear();
        public string AucYear => GetRomanYear(true);
        public string Day => GetRomanDayString();
        public NundinalLetters NundinalLetter => GetNundinalLetter();
        public RomanSetDays SetDay => GetSetDay();
        public RomanDayPrefixes DayPrefix => GetDayPrefix();
        public RomanMonths ReferenceMonth => GetReferenceMonth();
        public string Time => GetTime();
        public string Hour => GetTime(true);
        public int? DaysUntilSetDay => _daysUntil == null ? GetDaysUntil() : _daysUntil;

        private int? _daysUntil;
        private RomanMonths CalendarMonth => GetCalendarMonth();

        public static RomanDateTime Now => new RomanDateTime(DateTime.Now);
        public static RomanDateTime MaxValue => new RomanDateTime(DateTime.MaxValue);
        public static RomanDateTime MinValue => new RomanDateTime(DateTime.MinValue);

        private LocalDateTime DateTimeData { get; }

        public RomanDateTime(int year)
        {
            _daysUntil = null;
            DateTimeData = new LocalDateTime(year, 1, 1, 0, 0, CalendarSystem.Gregorian);
        }

        public RomanDateTime(int year, int month)
        {
            _daysUntil = null;
            DateTimeData = new LocalDateTime(year, month, 1, 0, 0, CalendarSystem.Gregorian);
        }
        public RomanDateTime(int year, int month, int day)
        {
            _daysUntil = null;
            DateTimeData = new LocalDateTime(year, month, day, 0, 0, CalendarSystem.Gregorian);
        }

        public RomanDateTime(int year, int month, int day, int hour)
        {
            _daysUntil = null;
            DateTimeData = new LocalDateTime(year, month, day, hour, 0, 0, CalendarSystem.Gregorian);
        }

        public RomanDateTime(DateTime date)
        {
            _daysUntil = null;
            DateTimeData = date.ToLocalDateTime();
        }

        public RomanDateTime(LocalDateTime date)
        {
            _daysUntil = null;
            DateTimeData = date;
        }

        public RomanDateTime AddHours(int hours)
        {
            return new RomanDateTime(DateTimeData.PlusHours(hours));
        }

        public RomanDateTime AddDays(int days)
        {
            return new RomanDateTime(DateTimeData.PlusDays(days));
        }

        public RomanDateTime AddRomanWeeks(int weeks)
        {
            return new RomanDateTime(DateTimeData.PlusDays((weeks * 8)));
        }

        public RomanDateTime AddMonths(int months)
        {
            return new RomanDateTime(DateTimeData.PlusMonths(months));
        }

        public RomanDateTime AddYears(int years)
        {
            return new RomanDateTime(DateTimeData.PlusYears(years));
        }

        public override string ToString()
        {
            return $"{Time}, {Day} {Year}";
        }

        /// <summary>
        /// Formats Roman date time:
        /// > {t} = Time / {h} = hour / {v} = Vigila
        /// > {p/P} = short/full Prefix
        /// > {d} = Days until Set Day 
        /// > {sx/Sx} = short/full Set Day
        /// > {m/M} = short/full Month
        /// > {y/Yx} = AD Year / AUC Year
        /// > {Dx} = Calendar day / {Dn} = Nundinal Letter
        /// > {cx/Cx} = short/full Calendar month
        /// </summary>
        /// <param name="format">The format for the Roman date e.g. {hx, p dx SD, M y}</param>
        public string ToString(string format)
        {
            format = format.Replace("p", "{0}");
            format = format.Replace("P", "{1}");
            format = format.Replace("d", "{2}");
            format = format.Replace("Dx", "{3}");
            format = format.Replace("sx", "{4}");
            format = format.Replace("Sx", "{5}");
            format = format.Replace("m", "{6}");
            format = format.Replace("M", "{7}");
            format = format.Replace("cx", "{8}");
            format = format.Replace("Cx", "{9}");
            format = format.Replace("y", "{10}");
            format = format.Replace("Yx", "{11}");
            format = format.Replace("t", "{12}");
            format = format.Replace("h", "{13}");
            format = format.Replace("v", "{14}");
            format = format.Replace("Dn", "{15}");

            var sdAcc = DaysUntilSetDay != 0;
            var mAcc = DaysUntilSetDay > 1;
            var cMonth = CalendarMonth;
            var rMonth = ReferenceMonth;
            var sDay = SetDay;
            var dPrefix = DayPrefix;
            var vigila = Time.StartsWith("Vigila") ? Time : null;
            var calendarDay = DateTimeData.Day.ToRomanNumerals();

            return String.Format(format,
                dPrefix.Short, dPrefix.Long, DaysUntilSetDay.ToRomanNumerals(), calendarDay,
                sDay.Short, (sdAcc ? sDay.Accusative : sDay.Ablative),
                rMonth.Short, (mAcc ? rMonth.Accusative : rMonth.Ablative),
                cMonth.Short, cMonth.Month.ToString(), Year, AucYear, Time, Hour, vigila,
                NundinalLetter.ToString());
        }

        public DateTime ToDateTime()
        {
            return DateTimeData;
        }

        #region Private Methods

        private NundinalLetters GetNundinalLetter()
        {
            var year = DateTimeData.Year;

            var startPosition = (NundinalLetters)(year % 8);

            var daysFromStart = (DateTimeData - new DateTime(DateTimeData.Year, 1, 1)).Days;
            var daysFromCycle = (((daysFromStart + (int)startPosition) - 1) % 8);

            if (daysFromCycle > 8)
                daysFromCycle -= 8;

            var cyclePosition = (NundinalLetters)daysFromCycle;

            return cyclePosition;
        }

        private string GetRomanDayString(bool shorten = false)
        {
            var sb = new StringBuilder();
            var rMonth = ReferenceMonth;
            var sDay = SetDay;
            var dPrefix = DayPrefix;

            sb.Append($"{(shorten ? dPrefix.Short : dPrefix.Long)} ");

            if (DaysUntilSetDay > 2)
                sb.Append($"{DaysUntilSetDay.ToRomanNumerals()} ");

            if (DaysUntilSetDay == 0)
                sb.Append($"{(shorten ? sDay.Short : sDay.Ablative)} ");
            else
                sb.Append($"{(shorten ? sDay.Short : sDay.Accusative)} ");

            if (DaysUntilSetDay > 2)
                sb.Append($"{(shorten ? rMonth.Short : rMonth.Accusative)}");
            else
                sb.Append($"{(shorten ? rMonth.Short : rMonth.Ablative)}");

            return sb.ToString().TrimStart();
        }

        private string GetRomanYear(bool aucEra = false)
        {
            var year = DateTimeData.Year;

            if (aucEra)
                year += 753;

            return year.ToRomanNumerals();
        }

        private string GetTime(bool hour = false)
        {
            var cMonth = CalendarMonth;
            var current = DateTimeData.TimeAsFraction();
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
            if (DateTimeData.Day != 1 && SetDay.SetDay == SetDays.Kalendae)
                return RomanMonths.GetRomanMonth(CalendarMonth.Month.Next());

            return CalendarMonth;
        }

        private RomanDayPrefixes GetDayPrefix()
        {
            var day = DateTimeData.Day;
            var leapYear = DateTimeData.IsLeapYear();
            var cMonth = CalendarMonth;

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
            var day = DateTimeData.Day;
            var leapYear = DateTimeData.IsLeapYear();
            var cMonth = CalendarMonth;

            if (day.Between(cMonth.Kalendae, cMonth.Nonae, false) || day == cMonth.Nonae)
                return RomanSetDays.Nonae;
            else if (day.Between(cMonth.Nonae, cMonth.Idus, false) || day == cMonth.Idus)
                return RomanSetDays.Idus;

            return RomanSetDays.Kalendae;
        }

        private int GetDaysUntil()
        {
            var day = DateTimeData.Day;
            var leapYear = DateTimeData.IsLeapYear();
            var cMonth = CalendarMonth;

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
            if (DateTimeData.Month != 0 && DateTimeData.Month <= 12)
            {
                return (RomanMonths.GetRomanMonth((Months)DateTimeData.Month));
            }

            return default(RomanMonths);
        }

        #endregion
    }
}
