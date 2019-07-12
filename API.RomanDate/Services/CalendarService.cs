using System;
using System.Linq;
using API.RomanDate.Helpers;
using API.RomanDate.Models;
using API.RomanDate.Services.Interfaces;
using RomanDate;
using RomanDate.Enums;
using RomanDate.Helpers.RomanDate;

namespace API.RomanDate.Services
{
    public class CalendarService : ICalendarService
    {
        public CalendarService()
        {

        }

        public Calendar ReturnCalendarMonth(Eras era, int year, Months month)
        {
            var calendarMonthStart = new DateTime(year, (int)month, 1);
            var calendarMonthEnd = calendarMonthStart.EndOfMonth();

            var dates = calendarMonthStart.GetDateRangeTo(calendarMonthEnd, inclusive: true);

            var romanDates = dates.Select(s => (roman: new RomanDateTime(s, era), common: s));

            return new Calendar
            {
                CalendarMonth = month,
                Year = year,
                Era = era,
                CalendarDays = romanDates.Select(s => new CalendarMonth
                {
                    CommonEraDate = s.common.Date,
                    NundinalLetter = s.roman.NundinalLetter,
                    IsNundinae = s.roman.IsNundinae(),
                    RomanDay = s.roman.ToString("z").Trim()
                })
            };
        }
    }
}
