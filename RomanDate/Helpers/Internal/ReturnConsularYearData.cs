using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;

namespace RomanDate.Helpers
{
    public static partial class RomanDateHelpers
    {
        internal static ConsularDate ReturnConsularYearData(int aucYear)
        {
            var data = LoadConsularData();

            var item = data.FirstOrDefault(f => f.Id == aucYear);

            return item;
        }
    }
}