using System;
using RomanDate.Enums;

namespace RomanDate.Helpers
{
    internal static class DateTimeEraHelpers
    {
        public static (DateTime DateTime, Eras Era) Deconstruct(this DateTimeEra dateTimeEra)
        {
            return (dateTimeEra.DateTime, dateTimeEra.Era);
        }
    }
}