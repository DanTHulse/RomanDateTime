using System;

namespace RomanDate.Helpers
{
    internal static class StringHelpers
    {
        internal static string Left(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength ? value : value.Substring(0, maxLength));
        }
    }
}
