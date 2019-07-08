using System;
using System.Linq;

namespace RomanDate.Extensions
{
    internal static partial class LinqEx
    {
        internal static bool In<T>(this T value, params T[] list) => list.Contains(value);
    }
}