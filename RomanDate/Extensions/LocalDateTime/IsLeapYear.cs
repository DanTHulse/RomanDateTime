using NodaTime;
using RomanDate.Extensions.Maths;

namespace RomanDate.Extensions
{
    internal static partial class LocalDateTimeEx
    {
        internal static bool IsLeapYear(this LocalDateTime value)
        {
            if (MathEx.Modulo(value.Year, 400) == 0)
                return true;
            else if (MathEx.Modulo(value.Year, 100) == 0)
                return false;
            else if (MathEx.Modulo(value.Year, 4) == 0)
                return true;
            return false;
        }
    }
}
