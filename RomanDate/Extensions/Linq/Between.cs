﻿using System;

namespace RomanDate.Extensions
{
    internal static partial class LinqEx
    {
        internal static bool Between<T>(this T value, T from, T to, bool inclusive = true) where T : IComparable<T>
        {
            if (inclusive)
                return value.CompareTo(from) >= 0 && value.CompareTo(to) <= 0;
            else
                return value.CompareTo(from) > 0 && value.CompareTo(to) < 0;
        }
    }
}