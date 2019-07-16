using System;
using System.Linq;
using API.RomanDate.Helpers;
using API.RomanDate.Models.Calendar;
using API.RomanDate.Services.Interfaces;
using RomanDate;
using RomanDate.Enums;
using RomanDate.Helpers.RomanDate;
using RomanDate.Helpers.RomanNumerals;

namespace API.RomanDate.Services
{
    public class CalendarService : ICalendarService
    {
        public CalendarService()
        {

        }

        public CalendarYear ReturnCalendarYear(Eras era, int year)
        {
            var months = EnumHelpers.EnumToList<Months>();
            var romanDate = new RomanDateTime(year, era);

            return new CalendarYear
            {
                AucYear = RomanNumerals.ToInt(romanDate.AucYear),
                AucYearNumerals = romanDate.AucYear,
                Year = year,
                YearNumerals = romanDate.Year,
                ConsularYear = "",
                Era = era,
                Months = months.Select(s => new CalendarMonth
                {
                    Year = year,
                    Month = s,
                    Era = era
                })
            };
        }

        public CalendarMonth ReturnCalendarMonth(Eras era, int year, Months month)
        {
            var calendarMonthStart = new DateTime(year, (int)month, 1);
            var calendarMonthEnd = calendarMonthStart.EndOfMonth();

            var dates = calendarMonthStart.GetDateRangeTo(calendarMonthEnd, inclusive: true);

            var romanDates = dates.Select(s => (roman: new RomanDateTime(s, era), common: s));

            return new CalendarMonth
            {
                Month = month,
                Year = year,
                YearNumerals = romanDates.First().roman.Year,
                AucYear = RomanNumerals.ToInt(romanDates.First().roman.AucYear),
                AucYearNumerals = romanDates.First().roman.AucYear,
                Era = era,
                Days = romanDates.Select(s => new CalendarDay
                {
                    CommonEraDate = s.common.Date,
                    Era = era,
                    NundinalLetter = s.roman.NundinalLetter,
                    IsNundinae = s.roman.IsNundinae(),
                    Day = s.roman.ToString("z").Trim()
                })
            };
        }

        public CalendarDay ReturnCalendarDay(Eras era, int year, Months month, int day)
        {
            var romanDate = new RomanDateTime(year, (int)month, day, era);

            return new CalendarDay
            {
                AucYear = RomanNumerals.ToInt(romanDate.AucYear),
                AucYearNumerals = romanDate.AucYear,
                Year = RomanNumerals.ToInt(romanDate.Year),
                YearNumerals = romanDate.Year,
                Day = romanDate.Day,
                Month = romanDate.ActualMonth,
                IsNundinae = romanDate.IsNundinae(),
                NundinalLetter = romanDate.NundinalLetter
            };
        }
    }
}
