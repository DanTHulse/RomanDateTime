using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanDate.Helpers
{
    public static class LinqHelpers
    {
        public static bool Between<T>(this T value, T from, T to, bool inclusive = true) where T : IComparable<T>
        {
            if (inclusive)
                return value.CompareTo(from) >= 0 && value.CompareTo(to) <= 0;
            else
                return value.CompareTo(from) > 0 && value.CompareTo(to) < 0;
        }

        public static bool In<T>(this T value, IEnumerable<T> list)
        {
            return list.Contains(value);
        }
    }
}
