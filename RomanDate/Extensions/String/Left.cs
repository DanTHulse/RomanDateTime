using System;

namespace RomanDate.Extensions
{
    internal static partial class StringEx
    {
        internal static string Left(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength ? value : value.Substring(0, maxLength));
        }
    }
}
