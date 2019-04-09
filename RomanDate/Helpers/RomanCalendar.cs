using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;

namespace RomanDate.Helpers
{
    public static class RomanCalendar
    {
        public static IEnumerable<CalendarData> GetMillenia()
        {
            return new List<CalendarData>
            {
                new CalendarData { Name = "1st Millenium", Number = 0 },
                new CalendarData { Name = "2nd Millenium", Number = 1000 },
                new CalendarData { Name = "3rd Millenium", Number = 2000 }
            };
        }

        public static IEnumerable<CalendarData> GetCenturies(int millenium)
        {
            return new List<CalendarData>
            {
                new CalendarData { Name = millenium.ToRomanNumerals(), Number = millenium },
                new CalendarData { Name = (millenium + 100).ToRomanNumerals(), Number = millenium + 100 },
                new CalendarData { Name = (millenium + 200).ToRomanNumerals(), Number = millenium + 200 },
                new CalendarData { Name = (millenium + 300).ToRomanNumerals(), Number = millenium + 300 },
                new CalendarData { Name = (millenium + 400).ToRomanNumerals(), Number = millenium + 400 },
                new CalendarData { Name = (millenium + 500).ToRomanNumerals(), Number = millenium + 500 },
                new CalendarData { Name = (millenium + 600).ToRomanNumerals(), Number = millenium + 600 },
                new CalendarData { Name = (millenium + 700).ToRomanNumerals(), Number = millenium + 700 },
                new CalendarData { Name = (millenium + 800).ToRomanNumerals(), Number = millenium + 800 },
                new CalendarData { Name = (millenium + 900).ToRomanNumerals(), Number = millenium + 900 }
            };
        }

        public static IEnumerable<CalendarData> GetDecades(int century)
        {
            return new List<CalendarData>
            {
                new CalendarData { Name = century.ToRomanNumerals(), Number = century },
                new CalendarData { Name = (century + 10).ToRomanNumerals(), Number = century + 10 },
                new CalendarData { Name = (century + 20).ToRomanNumerals(), Number = century + 20 },
                new CalendarData { Name = (century + 30).ToRomanNumerals(), Number = century + 30 },
                new CalendarData { Name = (century + 40).ToRomanNumerals(), Number = century + 40 },
                new CalendarData { Name = (century + 50).ToRomanNumerals(), Number = century + 50 },
                new CalendarData { Name = (century + 60).ToRomanNumerals(), Number = century + 60 },
                new CalendarData { Name = (century + 70).ToRomanNumerals(), Number = century + 70 },
                new CalendarData { Name = (century + 80).ToRomanNumerals(), Number = century + 80 },
                new CalendarData { Name = (century + 90).ToRomanNumerals(), Number = century + 90 }
            };
        }

        public static IEnumerable<CalendarData> GetYears(int decade)
        {
            return new List<CalendarData>
            {
                new CalendarData { Name = decade.ToRomanNumerals(), Number = decade },
                new CalendarData { Name = (decade + 1).ToRomanNumerals(), Number = decade + 1 },
                new CalendarData { Name = (decade + 2).ToRomanNumerals(), Number = decade + 2 },
                new CalendarData { Name = (decade + 3).ToRomanNumerals(), Number = decade + 3 },
                new CalendarData { Name = (decade + 4).ToRomanNumerals(), Number = decade + 4 },
                new CalendarData { Name = (decade + 5).ToRomanNumerals(), Number = decade + 5 },
                new CalendarData { Name = (decade + 6).ToRomanNumerals(), Number = decade + 6 },
                new CalendarData { Name = (decade + 7).ToRomanNumerals(), Number = decade + 7 },
                new CalendarData { Name = (decade + 8).ToRomanNumerals(), Number = decade + 8 },
                new CalendarData { Name = (decade + 9).ToRomanNumerals(), Number = decade + 9 }
            };
        }

        public static IEnumerable<CalendarData> GetMonths()
        {
            var months = EnumHelpers.EnumToList<Months>();

            return months.Select(s => new CalendarData
            {
                Name = s.ToString(),
                    Number = (int) s
            });
        }

        public static IEnumerable<RomanCalendarModel> GetMonthOfDates(int year, int month)
        {
            var daysInMonth = CalendarSystem.Gregorian.GetDaysInMonth(year, month);
            var coll = new List<RomanDateTime>();

            for (var x = 0; x < daysInMonth; x++)
            {
                coll.Add(new RomanDateTime(year, month, x + 1));
            }

            return coll.Select(s => new RomanCalendarModel
            {
                Day = s.ToString("p d sx"),
                    DayNumber = s.DateTimeData.Day,
                    Era = s.Era.ToString(),
                    IsNundinae = s.IsNundinae(),
                    NundinalLetter = s.NundinalLetter.ToString(),
                    Month = s.Month.ToString(),
                    Year = s.Year,
                    RomanDateTime = s
            });
        }
    }
}