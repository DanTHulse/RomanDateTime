using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Helpers;

namespace RomanDate.Helpers
{
    public static class RomanDateTimeHelpers
    {
        public static bool IsNundinae(this RomanDateTime date)
        {
            var dateTime = date.DateTimeData;
            var startPosition = (NundinalLetters) (dateTime.YearOfEra % 8);
            var enumList = EnumHelpers.EnumToList<NundinalLetters>();

            var checkDates = new List<NundinalLetters>
            {
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 1, 1, 0, 0), startPosition),
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 1, 5, 0, 0), startPosition),
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 2, 5, 0, 0), startPosition),
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 3, 7, 0, 0), startPosition),
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 4, 5, 0, 0), startPosition),
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 5, 7, 0, 0), startPosition),
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 6, 5, 0, 0), startPosition),
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 7, 7, 0, 0), startPosition),
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 8, 5, 0, 0), startPosition),
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 9, 5, 0, 0), startPosition),
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 10, 7, 0, 0), startPosition),
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 11, 5, 0, 0), startPosition),
                CheckNundialLetter(dateTime, new LocalDateTime(dateTime.Year, 12, 5, 0, 0), startPosition),
                };

                var result = enumList.Where(p => !checkDates.Any(p2 => p2 == p)).ToList();

                if (result.Any())
                {
                return result.First() == date.NundinalLetter;
            }

            var countResult = checkDates.GroupBy(i => i).OrderBy(g => g.Count()).Select(g => g.Key).ToList();

            return countResult.First() == date.NundinalLetter;
        }

        public static RomanDateTime NextSetDay(this RomanDateTime date, SetDays? setDay = null)
        {
            var dateTime = date.DateTimeData;
            var daysToAdd = date.DaysUntilSetDay.Value != 0 ? date.DaysUntilSetDay.Value - 1 : 0;
            var currSetDay = date.SetDay.SetDay;
            var nextMonth = RomanMonths.GetRomanMonth(((Months) dateTime.Month).Next());
            var currMonth = RomanMonths.GetRomanMonth((Months) dateTime.Month);

            if (setDay.HasValue)
            {
                if ((setDay.Value == currSetDay && daysToAdd == 0) || (setDay.Value < currSetDay))
                {
                    if (nextMonth.Month == Months.Ianuarius)
                        dateTime = dateTime.PlusYears(1);

                    if (setDay.Value == SetDays.Kalendae)
                        return new RomanDateTime(dateTime.Year, (int) nextMonth.Month, 1);
                    if (setDay.Value == SetDays.Nonae)
                        return new RomanDateTime(dateTime.Year, (int) nextMonth.Month, nextMonth.Nonae);
                    if (setDay.Value == SetDays.Idus)
                        return new RomanDateTime(dateTime.Year, (int) nextMonth.Month, nextMonth.Idus);
                }
                else if (setDay.Value > currSetDay)
                {
                    if (setDay.Value == SetDays.Nonae)
                        return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae);
                    if (setDay.Value == SetDays.Idus)
                        return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus);
                }
            }

            if (daysToAdd == 0)
            {
                if (currSetDay == SetDays.Kalendae)
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae);
                if (currSetDay == SetDays.Nonae)
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus);
                if (currSetDay == SetDays.Idus)
                {
                    if (nextMonth.Month == Months.Ianuarius)
                        dateTime = dateTime.PlusYears(1);
                    return new RomanDateTime(dateTime.Year, (int) nextMonth.Month, 1);
                }
            }

            return date.AddDays(daysToAdd);
        }

        public static RomanDateTime PreviousSetDay(this RomanDateTime date, SetDays? setDay = null)
        {
            var dateTime = date.DateTimeData;
            var currSetDay = date.SetDay.SetDay;
            var daysUntil = date.DaysUntilSetDay.Value;
            var prevMonth = RomanMonths.GetRomanMonth(((Months) dateTime.Month).Previous());
            var currMonth = RomanMonths.GetRomanMonth((Months) dateTime.Month);

            if (setDay.HasValue)
            {
                if (setDay.Value == SetDays.Kalendae)
                {
                    if (currSetDay == SetDays.Kalendae && daysUntil == 0)
                    {
                        if (prevMonth.Month == Months.December)
                            dateTime = dateTime.PlusYears(-1);
                        return new RomanDateTime(dateTime.Year, (int) prevMonth.Month, 1);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, 1);
                }
                if (setDay.Value == SetDays.Nonae)
                {
                    if ((currSetDay == SetDays.Kalendae && daysUntil == 0) ||
                        (currSetDay == SetDays.Nonae && daysUntil >= 0))
                    {
                        if (prevMonth.Month == Months.December)
                            dateTime = dateTime.PlusYears(-1);
                        return new RomanDateTime(dateTime.Year, (int) prevMonth.Month, prevMonth.Nonae);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae);
                }
                else
                {
                    if ((currSetDay == SetDays.Kalendae && daysUntil == 0) ||
                        (currSetDay == SetDays.Nonae && daysUntil >= 0) ||
                        (currSetDay == SetDays.Idus && daysUntil >= 0))
                    {
                        if (prevMonth.Month == Months.December)
                            dateTime = dateTime.PlusYears(-1);
                        return new RomanDateTime(dateTime.Year, (int) prevMonth.Month, prevMonth.Idus);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus);
                }
            }
            else
            {
                if (currSetDay == SetDays.Kalendae)
                {
                    if (daysUntil == 0)
                    {
                        if (prevMonth.Month == Months.December)
                            dateTime = dateTime.PlusYears(-1);
                        return new RomanDateTime(dateTime.Year, (int) prevMonth.Month, prevMonth.Idus);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus);
                }
                if (currSetDay == SetDays.Nonae)
                    return new RomanDateTime(dateTime.Year, dateTime.Month, 1);
                else
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae);
            }
        }

        private static NundinalLetters CheckNundialLetter(LocalDateTime from, LocalDateTime to, NundinalLetters startPosition)
        {
            var daysFromStart = Math.Abs(to.Minus(new LocalDateTime(from.Year, 1, 1, 0, 0)).Days);
            var daysFromCycle = (((daysFromStart + (int) startPosition)) % 8);

            return (NundinalLetters) daysFromCycle;
        }
    }
}