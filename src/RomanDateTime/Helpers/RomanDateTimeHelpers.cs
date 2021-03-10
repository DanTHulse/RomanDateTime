using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;
using RomanDate.Definitions;
using RomanDateTime.Enums;

namespace RomanDateTime.Helpers
{
    public static class RomanDateTimeHelpers
    {
        public static bool IsNundinae(this RomanDateTime date)
        {
            var dateTime = date.DateTimeData;
            var nundinae = ReturnNundinaeForYear(dateTime);

            return nundinae == date.NundinalLetter;
        }

        public static RomanDateTime NextNundinae(this RomanDateTime date)
        {
            var dateTime = date.DateTimeData;
            var nundinae = ReturnNundinaeForYear(dateTime);

            var daysUntil = (int)nundinae - (int)date.NundinalLetter;

            return date.AddDays(daysUntil <= 0 ? 8 - Math.Abs(daysUntil) : daysUntil);
        }

        public static RomanDateTime PreviousNundinae(this RomanDateTime date)
        {
            var dateTime = date.DateTimeData;
            var nundinae = ReturnNundinaeForYear(dateTime);

            var daysFrom = (int)nundinae - (int)date.NundinalLetter;

            return date.AddDays(daysFrom >= 0 ? -(8 - Math.Abs(daysFrom)) : daysFrom);
        }

        public static RomanDateTime NextSetDay(this RomanDateTime date, PrincipalDays? setDay = null)
        {
            var dateTime = date.DateTimeData;
            var daysToAdd = date.DaysUntilPrincipalDay.Value != 0 ? date.DaysUntilPrincipalDay.Value - 1 : 0;
            var currSetDay = date.RomanSetDay.SetDay;
            var nextMonth = RomanMonths.GetRomanMonth(((Months)dateTime.Month).Next());
            var currMonth = RomanMonths.GetRomanMonth((Months)dateTime.Month);

            if (setDay.HasValue)
            {
                if ((setDay.Value == currSetDay && daysToAdd == 0) || (setDay.Value < currSetDay))
                {
                    if (nextMonth.Month == Months.Ianuarius)
                    {
                        dateTime = dateTime.PlusYears(1);
                    }

                    if (setDay.Value == PrincipalDays.Kalendae)
                    {
                        return new RomanDateTime(dateTime.Year, (int)nextMonth.Month, 1);
                    }

                    if (setDay.Value == PrincipalDays.Nonae)
                    {
                        return new RomanDateTime(dateTime.Year, (int)nextMonth.Month, nextMonth.Nonae);
                    }

                    if (setDay.Value == PrincipalDays.Idus)
                    {
                        return new RomanDateTime(dateTime.Year, (int)nextMonth.Month, nextMonth.Idus);
                    }
                }
                else if (setDay.Value > currSetDay)
                {
                    if (setDay.Value == PrincipalDays.Nonae)
                    {
                        return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae);
                    }

                    if (setDay.Value == PrincipalDays.Idus)
                    {
                        return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus);
                    }
                }
            }

            if (daysToAdd == 0)
            {
                if (currSetDay == PrincipalDays.Kalendae)
                {
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae);
                }

                if (currSetDay == PrincipalDays.Nonae)
                {
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus);
                }

                if (currSetDay == PrincipalDays.Idus)
                {
                    if (nextMonth.Month == Months.Ianuarius)
                    {
                        dateTime = dateTime.PlusYears(1);
                    }

                    return new RomanDateTime(dateTime.Year, (int)nextMonth.Month, 1);
                }
            }

            return date.AddDays(daysToAdd);
        }

        public static RomanDateTime PreviousSetDay(this RomanDateTime date, PrincipalDays? setDay = null)
        {
            var dateTime = date.DateTimeData;
            var currSetDay = date.RomanSetDay.SetDay;
            var daysUntil = date.DaysUntilPrincipalDay.Value;
            var prevMonth = RomanMonths.GetRomanMonth(((Months)dateTime.Month).Previous());
            var currMonth = RomanMonths.GetRomanMonth((Months)dateTime.Month);

            if (setDay.HasValue)
            {
                if (setDay.Value == PrincipalDays.Kalendae)
                {
                    if (currSetDay == PrincipalDays.Kalendae && daysUntil == 0)
                    {
                        if (prevMonth.Month == Months.December)
                        {
                            dateTime = dateTime.PlusYears(-1);
                        }

                        return new RomanDateTime(dateTime.Year, (int)prevMonth.Month, 1);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, 1);
                }
                if (setDay.Value == PrincipalDays.Nonae)
                {
                    if ((currSetDay == PrincipalDays.Kalendae && daysUntil == 0) ||
                        (currSetDay == PrincipalDays.Nonae && daysUntil >= 0))
                    {
                        if (prevMonth.Month == Months.December)
                        {
                            dateTime = dateTime.PlusYears(-1);
                        }

                        return new RomanDateTime(dateTime.Year, (int)prevMonth.Month, prevMonth.Nonae);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae);
                }
                else
                {
                    if ((currSetDay == PrincipalDays.Kalendae && daysUntil == 0) ||
                        (currSetDay == PrincipalDays.Nonae && daysUntil >= 0) ||
                        (currSetDay == PrincipalDays.Idus && daysUntil >= 0))
                    {
                        if (prevMonth.Month == Months.December)
                        {
                            dateTime = dateTime.PlusYears(-1);
                        }

                        return new RomanDateTime(dateTime.Year, (int)prevMonth.Month, prevMonth.Idus);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus);
                }
            }
            else
            {
                if (currSetDay == PrincipalDays.Kalendae)
                {
                    if (daysUntil == 0)
                    {
                        if (prevMonth.Month == Months.December)
                        {
                            dateTime = dateTime.PlusYears(-1);
                        }

                        return new RomanDateTime(dateTime.Year, (int)prevMonth.Month, prevMonth.Idus);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus);
                }
                if (currSetDay == PrincipalDays.Nonae)
                {
                    return new RomanDateTime(dateTime.Year, dateTime.Month, 1);
                }
                else
                {
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae);
                }
            }
        }

        private static NundinalLetters ReturnNundinaeForYear(LocalDateTime dateTime)
        {
            var startPosition = (NundinalLetters)(dateTime.YearOfEra % 8);
            var enumList = EnumHelpers.EnumToList<NundinalLetters>();
            var checkDates = CheckNundialLetters(dateTime, startPosition);

            var result = enumList.Where(p => !checkDates.Any(p2 => p2 == p)).ToList();

            if (result.Any())
            {
                return result.First();
            }

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