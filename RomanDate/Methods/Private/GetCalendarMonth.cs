using RomanDate.Definitions;
using RomanDate.Enums;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private RomanMonths GetCalendarMonth()
        {
            if (this.DateTimeData.Month != 0 && this.DateTimeData.Month <= 12)
            {
                return (RomanMonths.GetRomanMonth((Months)this.DateTimeData.Month));
            }

            return default(RomanMonths);
        }
    }
}