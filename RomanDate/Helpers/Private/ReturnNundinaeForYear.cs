using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate.Helpers
{
    public static partial class RomanDateHelpers
    {
        private static NundinalLetters ReturnNundinaeForYear(LocalDateTime dateTime)
        {
            var startPosition = (NundinalLetters)(dateTime.YearOfEra % 8);
            var enumList = EnumEx.EnumToList<NundinalLetters>();
            var checkDates = CheckNundialLetters(dateTime, startPosition);

            var result = enumList.Where(p => !checkDates.Any(p2 => p2 == p)).ToList();

            if (result.Any())
                return result.First();

            var countResult = checkDates.GroupBy(i => i).OrderBy(g => g.Count()).Select(g => g.Key).ToList();

            return countResult.First();
        }

        private static IEnumerable<NundinalLetters> CheckNundialLetters(LocalDateTime from, NundinalLetters startPosition)
        {
            var letters = new List<NundinalLetters>
            {
                CheckNundialLetter(from, new LocalDateTime(from.Year, 1, 1, 0, 0), startPosition),
                CheckNundialLetter(from, new LocalDateTime(from.Year, 1, 5, 0, 0), startPosition),
                CheckNundialLetter(from, new LocalDateTime(from.Year, 2, 5, 0, 0), startPosition),
                CheckNundialLetter(from, new LocalDateTime(from.Year, 3, 7, 0, 0), startPosition),
                CheckNundialLetter(from, new LocalDateTime(from.Year, 4, 5, 0, 0), startPosition),
                CheckNundialLetter(from, new LocalDateTime(from.Year, 5, 7, 0, 0), startPosition),
                CheckNundialLetter(from, new LocalDateTime(from.Year, 6, 5, 0, 0), startPosition),
                CheckNundialLetter(from, new LocalDateTime(from.Year, 7, 7, 0, 0), startPosition),
                CheckNundialLetter(from, new LocalDateTime(from.Year, 8, 5, 0, 0), startPosition),
                CheckNundialLetter(from, new LocalDateTime(from.Year, 9, 5, 0, 0), startPosition),
                CheckNundialLetter(from, new LocalDateTime(from.Year, 10, 7, 0, 0), startPosition),
                CheckNundialLetter(from, new LocalDateTime(from.Year, 11, 5, 0, 0), startPosition),
                CheckNundialLetter(from, new LocalDateTime(from.Year, 12, 5, 0, 0), startPosition)
            };

            return letters;
        }

        private static NundinalLetters CheckNundialLetter(LocalDateTime from, LocalDateTime to, NundinalLetters startPosition)
        {
            var daysFromStart = Math.Abs(to.Minus(new LocalDateTime(from.Year, 1, 1, 0, 0)).Days);
            var daysFromCycle = (((daysFromStart + (int)startPosition)) % 8);

            return (NundinalLetters)daysFromCycle;
        }
    }
}