using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private RomanDayPrefixes GetDayPrefix()
        {
            var day = this.DateTimeData.Day;
            var leapYear = this.DateTimeData.IsLeapYear();
            var cMonth = this.CalendarMonth;

            if (day.In(new int[] { cMonth.Kalendae, cMonth.Nonae, cMonth.Idus }))
            {
                return new RomanDayPrefixes();
            }
            else if (day.In(new int[] {cMonth.Nonae - 1,
                                       cMonth.Idus - 1,
                                       cMonth.End + (leapYear && cMonth.Month == Months.Februarius ? 1 : 0)}))
            {
                return RomanDayPrefixes.Pridie;
            }
            else if (day == 24 && cMonth.Month == Months.Februarius && leapYear)
            {
                return RomanDayPrefixes.AnteDiemBis;
            }

            return RomanDayPrefixes.AnteDiem;
        }
    }
}