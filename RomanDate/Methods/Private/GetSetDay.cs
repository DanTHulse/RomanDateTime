using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private RomanSetDays GetSetDay()
        {
            var day = this.DateTimeData.Day;
            var cMonth = this.CalendarMonth;

            if (day.Between(cMonth.Kalendae, cMonth.Nonae, false) || day == cMonth.Nonae)
                return RomanSetDays.GetRomanSetDay(SetDays.Nonae);
            else if (day.Between(cMonth.Nonae, cMonth.Idus, false) || day == cMonth.Idus)
                return RomanSetDays.GetRomanSetDay(SetDays.Idus);

            return RomanSetDays.GetRomanSetDay(SetDays.Kalendae);
        }
    }
}
