using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Helpers;

namespace RomanDate.Helpers
{
    public static class RomanDateTimeHelpers
    {
        public static bool IsNundinae(this RomanDateTime date)
        {
            var dateTime = date.ToDateTime();
            var startPosition = (NundinalLetters) (dateTime.Year % 8);
            var enumList = EnumHelpers.EnumToList<NundinalLetters>();

            var checkDates = new List<NundinalLetters>
            {
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 1, 1), startPosition),
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 1, 5), startPosition),
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 2, 5), startPosition),
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 3, 7), startPosition),
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 4, 5), startPosition),
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 5, 7), startPosition),
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 6, 5), startPosition),
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 7, 7), startPosition),
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 8, 5), startPosition),
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 9, 5), startPosition),
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 10, 7), startPosition),
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 11, 5), startPosition),
                CheckNundialLetter(dateTime, new DateTime(dateTime.Year, 12, 5), startPosition),
                };

                var result = enumList.Where(p => !checkDates.Any(p2 => p2 == p)).ToList();

                if (result.Any())
                {
                return result.First() == date.NundinalLetter;
            }

            var countResult = checkDates.GroupBy(i => i).OrderBy(g => g.Count()).Select(g => g.Key).ToList();

            return countResult.First() == date.NundinalLetter;
        }

        public static RomanDateTime ToNextSetDay(this RomanDateTime date, SetDays? setDay = null)
        {
            return new RomanDateTime();
        }

        public static RomanDateTime ToPreviousSetDay(this RomanDateTime date, SetDays? setDay = null)
        {
            return new RomanDateTime();
        }

        private static NundinalLetters CheckNundialLetter(DateTime from, DateTime to, NundinalLetters startPosition)
        {
            var daysFromStart = (to - new DateTime(from.Year, 1, 1)).Days;
            var daysFromCycle = (((daysFromStart + (int) startPosition)) % 8);

            return (NundinalLetters) daysFromCycle;
        }
    }
}