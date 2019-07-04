using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate.Helpers
{
    public static partial class RomanDateHelpers
    {
        /// <summary>
        /// Returns an instance of <see cref="RomanDateTime"/> that represents the date of the previous sacred day from the current instance
        /// </summary>
        /// <param name="date">The instance of <see cref="RomanDateTime"/>.</param>
        /// <param name="setDay">The set day that is desired, if left null the previous sequential set day is used</param>
        /// <returns>A new instance of <see cref="RomanDateTime"/> representing the previous set day specified</returns>
        public static RomanDateTime PreviousSetDay(this RomanDateTime date, SetDays? setDay = null)
        {
            var dateTime = date.DateTimeData;
            var currSetDay = date.RomanSetDay.SetDay;
            var daysUntil = date.DaysUntilSetDay.GetValueOrDefault();
            var prevMonth = RomanMonths.GetRomanMonth(((Months)dateTime.Month).Previous());
            var currMonth = RomanMonths.GetRomanMonth((Months)dateTime.Month);

            if (setDay.HasValue)
            {
                if (setDay.Value == SetDays.Kalendae)
                {
                    if (currSetDay == SetDays.Kalendae && daysUntil == 0)
                    {
                        if (prevMonth.Month == Months.December)
                            dateTime = dateTime.PlusYears(-1);
                        return new RomanDateTime(dateTime.Year, (int)prevMonth.Month, 1);
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
                        return new RomanDateTime(dateTime.Year, (int)prevMonth.Month, prevMonth.Nonae);
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
                        return new RomanDateTime(dateTime.Year, (int)prevMonth.Month, prevMonth.Idus);
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
                        return new RomanDateTime(dateTime.Year, (int)prevMonth.Month, prevMonth.Idus);
                    }
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Idus);
                }
                if (currSetDay == SetDays.Nonae)
                    return new RomanDateTime(dateTime.Year, dateTime.Month, 1);
                else
                    return new RomanDateTime(dateTime.Year, dateTime.Month, currMonth.Nonae);
            }
        }
    }
}