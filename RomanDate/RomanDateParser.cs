using System;

namespace RomanDate
{
    internal static class RomanDateParser
    {
        internal static bool TryParse(string value, out RomanDateTime dateTime)
        {
            dateTime = new RomanDateTime();

            return true;
        }
    }
}