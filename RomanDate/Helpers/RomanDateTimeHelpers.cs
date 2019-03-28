using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;

namespace RomanDate.Helpers
{
    /// <summary>
    /// Helper methods for <see cref="RomanDateTime"/>
    /// </summary>
    public static class RomanDateTimeHelpers
    {
        /// <summary>
        /// Determines whether this instance is a nundinae (market day).
        /// </summary>
        /// <remarks>The Nundinae is the market day for the Romans, due to superstitions a nundinae cannot fall 
        /// on a Nonae or on the Kalends of Jan. As a result the letter used for the nundinae changes accordingly to avoid these clashes</remarks>
        /// <param name="date">The instance of <see cref="RomanDateTime"/> to check.</param>
        /// <returns><c>true</c> if the specified date is a nundinae (market day); otherwise, <c>false</c>.</returns>
        public static bool IsNundinae(this RomanDateTime date)
        {
            var dateTime = date.DateTimeData;
            var nundinae = ReturnNundinaeForYear(dateTime);

            return nundinae == date.NundinalLetter;
        }

        /// <summary>
        /// Returns an instance of <see cref="RomanDateTime"/> that represents the date of the next nundinae date from the current instance
        /// </summary>
        /// <param name="date">The instance of <see cref="RomanDateTime"/>.</param>
        /// <returns>A new instance of <see cref="RomanDateTime"/> representing the next nundinae (market day)</returns>
        public static RomanDateTime NextNundinae(this RomanDateTime date)
        {
            var dateTime = date.DateTimeData;
            var nundinae = ReturnNundinaeForYear(dateTime);

            var daysUntil = (int) nundinae - (int) date.NundinalLetter;

            return date.AddDays(daysUntil <= 0 ? 8 - Math.Abs(daysUntil) : daysUntil);
        }

        /// <summary>
        /// Returns an instance of <see cref="RomanDateTime"/> that represents the date of the previous nundinae date from the current instance
        /// </summary>
        /// <param name="date">The instance of <see cref="RomanDateTime"/>.</param>
        /// <returns>A new instance of <see cref="RomanDateTime"/> representing the previous nundinae (market day)</returns>
        public static RomanDateTime PreviousNundinae(this RomanDateTime date)
        {
            var dateTime = date.DateTimeData;
            var nundinae = ReturnNundinaeForYear(dateTime);

            var daysFrom = (int) nundinae - (int) date.NundinalLetter;
            var newDate = date.AddDays(daysFrom >= 0 ? -(8 - Math.Abs(daysFrom)) : daysFrom);
            
            return newDate;
        }

        /// <summary>
        /// Returns an instance of <see cref="RomanDateTime"/> that represents the date of the next sacred day from the current instance
        /// </summary>
        /// <param name="date">The instance of <see cref="RomanDateTime"/>.</param>
        /// <param name="setDay">The set day that is desired, if left null the next sequential set day is used</param>
        /// <returns>A new instance of <see cref="RomanDateTime"/> representing the next set day specified</returns>
        public static RomanDateTime NextSetDay(this RomanDateTime date, SetDays? setDay = null)
        {
            var dateTime = date.DateTimeData;
            var era = date.Era;
            var daysToAdd = date.DaysUntilSetDay.Value != 0 ? date.DaysUntilSetDay.Value - 1 : 0;
            var currSetDay = date.RomanSetDay.SetDay;
            var nextMonth = RomanMonths.GetRomanMonth(((Months) dateTime.Month).Next());
            var currMonth = RomanMonths.GetRomanMonth((Months) dateTime.Month);

            if (setDay.HasValue)
            {
                if ((setDay.Value == currSetDay && daysToAdd == 0) || (setDay.Value < currSetDay))
                {
                    if (nextMonth.Month == Months.Ianuarius)
                    {
                        var changes = dateTime.AdvanceYearEras(era);
                        dateTime = changes.date;
                        era = changes.era;
                    }

                    if (setDay.Value == SetDays.Kalendae)
                        return new RomanDateTime(dateTime.Year, (int) nextMonth.Month, 1, era);
                    if (setDay.Value == SetDays.Nonae)
                        return new RomanDateTime(dateTime.Year, (int) nextMonth.Month, nextMonth.Nonae, era);
                    if (setDay.Value == SetDays.Idus)
                        return new RomanDateTime(dateTime.Year, (int) nextMonth.Month, nextMonth.Idus, era);
                }
                else if (setDay.Value > currSetDay)
                {
                    if (setDay.Value == SetDays.Nonae)
                        return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae, era);
                    if (setDay.Value == SetDays.Idus)
                        return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus, era);
                }
            }

            if (daysToAdd == 0)
            {
                if (currSetDay == SetDays.Kalendae)
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae, era);
                if (currSetDay == SetDays.Nonae)
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus, era);
                if (currSetDay == SetDays.Idus)
                {
                    if (nextMonth.Month == Months.Ianuarius)
                    {
                        var changes = dateTime.AdvanceYearEras(era);
                        dateTime = changes.date;
                        era = changes.era;
                    }
                    return new RomanDateTime(dateTime.Year, (int) nextMonth.Month, 1, era);
                }
            }

            return date.AddDays(daysToAdd);
        }

        /// <summary>
        /// Returns an instance of <see cref="RomanDateTime"/> that represents the date of the previous sacred day from the current instance
        /// </summary>
        /// <param name="date">The instance of <see cref="RomanDateTime"/>.</param>
        /// <param name="setDay">The set day that is desired, if left null the previous sequential set day is used</param>
        /// <returns>A new instance of <see cref="RomanDateTime"/> representing the previous set day specified</returns>
        public static RomanDateTime PreviousSetDay(this RomanDateTime date, SetDays? setDay = null)
        {
            var dateTime = date.DateTimeData;
            var era = date.Era;
            var currSetDay = date.RomanSetDay.SetDay;
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
                        {
                            var changes = dateTime.AdvanceYearEras(era, false);
                            dateTime = changes.date;
                            era = changes.era;
                        }
                        return new RomanDateTime(dateTime.Year, (int) prevMonth.Month, 1, era);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, 1, era);
                }
                if (setDay.Value == SetDays.Nonae)
                {
                    if ((currSetDay == SetDays.Kalendae && daysUntil == 0) ||
                        (currSetDay == SetDays.Nonae && daysUntil >= 0))
                    {
                        if (prevMonth.Month == Months.December)
                        {
                            var changes = dateTime.AdvanceYearEras(era, false);
                            dateTime = changes.date;
                            era = changes.era;
                        }
                        return new RomanDateTime(dateTime.Year, (int) prevMonth.Month, prevMonth.Nonae, era);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae, era);
                }
                else
                {
                    if ((currSetDay == SetDays.Kalendae && daysUntil == 0) ||
                        (currSetDay == SetDays.Nonae && daysUntil >= 0) ||
                        (currSetDay == SetDays.Idus && daysUntil >= 0))
                    {
                        if (prevMonth.Month == Months.December)
                        {
                            var changes = dateTime.AdvanceYearEras(era, false);
                            dateTime = changes.date;
                            era = changes.era;
                        }
                        return new RomanDateTime(dateTime.Year, (int) prevMonth.Month, prevMonth.Idus, era);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus, era);
                }
            }
            else
            {
                if (currSetDay == SetDays.Kalendae)
                {
                    if (daysUntil == 0)
                    {
                        if (prevMonth.Month == Months.December)
                        {
                            var changes = dateTime.AdvanceYearEras(era, false);
                            dateTime = changes.date;
                            era = changes.era;
                        }
                        return new RomanDateTime(dateTime.Year, (int) prevMonth.Month, prevMonth.Idus, era);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus, era);
                }
                if (currSetDay == SetDays.Nonae)
                    return new RomanDateTime(dateTime.Year, dateTime.Month, 1, era);
                else
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae, era);
            }
        }

        private static NundinalLetters ReturnNundinaeForYear(DateTime dateTime)
        {
            var startPosition = (NundinalLetters) (dateTime.Year % 8);
            var enumList = EnumHelpers.EnumToList<NundinalLetters>();
            var checkDates = CheckNundialLetters(dateTime, startPosition);

            var result = enumList.Where(p => !checkDates.Any(p2 => p2 == p)).ToList();

            if (result.Any())
                return result.First();

            var countResult = checkDates.GroupBy(i => i).OrderBy(g => g.Count()).Select(g => g.Key).ToList();

            return countResult.First();
        }

        private static IEnumerable<NundinalLetters> CheckNundialLetters(DateTime from, NundinalLetters startPosition)
        {
            var letters = new List<NundinalLetters>();

            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 1, 1), startPosition));
            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 1, 5), startPosition));
            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 2, 5), startPosition));
            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 3, 7), startPosition));
            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 4, 5), startPosition));
            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 5, 7), startPosition));
            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 6, 5), startPosition));
            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 7, 7), startPosition));
            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 8, 5), startPosition));
            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 9, 5), startPosition));
            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 10, 7), startPosition));
            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 11, 5), startPosition));
            letters.Add(CheckNundialLetter(from, new DateTime(from.Year, 12, 5), startPosition));

            return letters;
        }

        private static NundinalLetters CheckNundialLetter(DateTime from, DateTime to, NundinalLetters startPosition)
        {
            var daysFromStart = Math.Abs((to - new DateTime(from.Year, 1, 1)).Days);
            var daysFromCycle = (((daysFromStart + (int) startPosition)) % 8);

            return (NundinalLetters) daysFromCycle;
        }
    }
}