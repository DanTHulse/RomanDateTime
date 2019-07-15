using System;
using NodaTime;
using RomanDate.Enums;
using RomanDate.Extensions.Maths;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private NundinalLetters GetNundinalLetter()
        {
            var year = this.DateTimeData.YearOfEra;

            var startPosition = (NundinalLetters)MathEx.Modulo(year, 8);

            var daysFromStart = Math.Abs(this.DateTimeData.Minus(new LocalDateTime(this.DateTimeData.Year, 1, 1, 0, 0)).Days);
            var daysFromCycle = MathEx.Modulo(((daysFromStart + (int)startPosition) - 1), 8);

            if (daysFromCycle > 8)
                daysFromCycle -= 8;

            var cyclePosition = (NundinalLetters)daysFromCycle;

            return cyclePosition;
        }
    }
}