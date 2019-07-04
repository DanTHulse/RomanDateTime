using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanDate.Extensions
{
    internal static partial class LinqEx
    {
        internal static bool In<T>(this T value, IEnumerable<T> list) => list.Contains(value);
    }
}