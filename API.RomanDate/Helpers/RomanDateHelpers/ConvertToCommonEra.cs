using System;
using RomanDate.Enums;

namespace API.RomanDate.Helpers
{
    public static partial class RomanDateHelpers
    {
        public static string ConvertToCommonEraString(int year)
            => $"{ConvertToCommonEra(year).year} {ConvertToCommonEra(year).era}";

        public static (int year, Eras era) ConvertToCommonEra(int year)
            => year > 753 ? (year - 753, Eras.AD) : (Math.Abs(year - 752), Eras.BC);
    }
}
