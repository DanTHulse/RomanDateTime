using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate.Helpers
{
    public static partial class RomanDateHelpers
    {
        /// <summary>
        /// Returns an instance of <see cref="RomanDateTime"/> that represents the date of the next sacred day from the current instance
        /// </summary>
        /// <param name="date">The instance of <see cref="RomanDateTime"/>.</param>
        /// <param name="setDay">The set day that is desired, if left null the next sequential set day is used</param>
        /// <returns>A new instance of <see cref="RomanDateTime"/> representing the next set day specified</returns>
        public static RomanDateTime NextSetDay(this RomanDateTime date, SetDays? setDay = null)
        {
            var dateTime = date.DateTimeData;
            var daysToAdd = date.DaysUntilSetDay.Value != 0 ? date.DaysUntilSetDay.Value - 1 : 0;
            var currSetDay = date.RomanSetDay.SetDay;
            var nextMonth = RomanMonths.GetRomanMonth(((Months)dateTime.Month).Next());
            var currMonth = RomanMonths.GetRomanMonth((Months)dateTime.Month);

            if (setDay.HasValue)
            {
                if ((setDay.Value == currSetDay && daysToAdd == 0) || (setDay.Value < currSetDay))
                {
                    if (nextMonth.Month == Months.Ianuarius)
                        dateTime = dateTime.PlusYears(1);

                    if (setDay.Value == SetDays.Kalendae)
                        return new RomanDateTime(dateTime.Year, (int)nextMonth.Month, 1);
                    if (setDay.Value == SetDays.Nonae)
                        return new RomanDateTime(dateTime.Year, (int)nextMonth.Month, nextMonth.Nonae);
                    if (setDay.Value == SetDays.Idus)
                        return new RomanDateTime(dateTime.Year, (int)nextMonth.Month, nextMonth.Idus);
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
                    return new RomanDateTime(dateTime.Year, (int)nextMonth.Month, 1);
                }
            }

            return date.AddDays(daysToAdd);
        }
    }
}