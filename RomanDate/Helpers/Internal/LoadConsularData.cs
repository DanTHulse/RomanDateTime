using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;

namespace RomanDate.Helpers
{
    public static partial class RomanDateHelpers
    {
        internal static IEnumerable<ConsularDate> LoadConsularData()
        {
            using (var r = new StreamReader("./ConsularData/ConsularDates.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<ConsularDate>>(json);

                return items;
            }
        }
    }
}