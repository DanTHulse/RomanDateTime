using NodaTime;

namespace RomanDate.Extensions
{
    internal static partial class LocalDateTimeEx
    {
        internal static bool IsLeapYear(this LocalDateTime value)
        {
            if ((value.Year % 400) == 0)
                return true;
            else if ((value.Year % 100) == 0)
                return false;
            else if ((value.Year % 4) == 0)
                return true;
            return false;
        }
    }
}
