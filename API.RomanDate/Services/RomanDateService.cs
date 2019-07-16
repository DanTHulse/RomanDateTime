using System.Collections.Generic;
using API.RomanDate.Helpers;
using API.RomanDate.Models.Calendar;
using API.RomanDate.Services.Interfaces;
using RomanDate;
using RomanDate.Enums;
using RomanDate.Helpers.RomanDate;
using RomanDate.Helpers.RomanNumerals;

namespace API.RomanDate.Services
{
    public class RomanDateService : IRomanDateService
    {
        public RomanDateService()
        {

        }

        public CalendarDay GetCurrentDate()
        {
            var romanDate = RomanDateTime.Now;

            return new CalendarDay
            {
                AucYear = RomanNumerals.ToInt(romanDate.AucYear),
                Year = RomanNumerals.ToInt(romanDate.Year),
                Day = romanDate.Day,
                Month = romanDate.ActualMonth,
                IsNundinae = romanDate.IsNundinae(),
                NundinalLetter = romanDate.NundinalLetter
            };
        }

        public CalendarDay GetRomanDate(Eras era, int year, Months month, int day)
        {
            var romanDate = new RomanDateTime(year, (int)month, day, era);

            return new CalendarDay
            {
                AucYear = RomanNumerals.ToInt(romanDate.AucYear),
                Year = RomanNumerals.ToInt(romanDate.Year),
                Day = romanDate.Day,
                Month = romanDate.ActualMonth,
                IsNundinae = romanDate.IsNundinae(),
                NundinalLetter = romanDate.NundinalLetter
            };
        }

        public IEnumerable<Months> GetRomanMonths() => EnumHelpers.EnumToList<Months>();
    }
}