using System;
using System.Text;
using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Extensions;
using RomanDate.Helpers;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private NundinalLetters GetNundinalLetter()
        {
            var year = this.DateTimeData.YearOfEra;

            var startPosition = (NundinalLetters)(year % 8);

            var daysFromStart = Math.Abs(this.DateTimeData.Minus(new LocalDateTime(this.DateTimeData.Year, 1, 1, 0, 0)).Days);
            var daysFromCycle = (((daysFromStart + (int)startPosition) - 1) % 8);

            if (daysFromCycle > 8)
                daysFromCycle -= 8;

            var cyclePosition = (NundinalLetters)daysFromCycle;

            return cyclePosition;
        }
    }
}