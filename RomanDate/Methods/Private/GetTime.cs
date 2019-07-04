using RomanDate.Extensions;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private string GetTime(bool hour = false)
        {
            var cMonth = this.CalendarMonth;
            var current = this.DateTimeData.TimeAsFraction();
            var dayHours = 0;
            var nightHours = 0;

            for (var x = 0; current > 0.1; x++)
            {
                if (x < 6 || x.Between(18, 23))
                {
                    nightHours++;
                    current -= cMonth.HourLengthNight;
                }
                else if (x.Between(6, 17))
                {
                    dayHours++;
                    current -= cMonth.HourLengthDay;
                }
            }

            if ((nightHours > 0 && dayHours == 0) || nightHours > 6)
            {
                if (nightHours.Between(7, 9))
                    return hour ? $"hora noctis {(nightHours - 6).ToRomanNumerals()}" : $"Vigila Prima";
                if (nightHours.Between(10, 12))
                    return hour ? $"hora noctis {(nightHours - 6).ToRomanNumerals()}" : $"Vigila Secunda";
                if (nightHours.Between(1, 3))
                    return hour ? $"hora noctis {(nightHours + 6).ToRomanNumerals()}" : $"Vigila Tertia";
                if (nightHours.Between(4, 6))
                    return hour ? $"hora noctis {(nightHours + 6).ToRomanNumerals()}" : $"Vigila Quarta";
            }
            else if (dayHours != 0)
            {
                return $"hora {dayHours.ToRomanNumerals()}";
            }

            return hour ? $"hora noctis VII" : $"Vigila Tertia";
        }
    }
}