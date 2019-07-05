using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using RomanDate.Definitions;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private ConsularDate ReturnConsularYearData(int aucYear)
        {
            return _Load().FirstOrDefault(f => f.Id == aucYear);

            static IEnumerable<ConsularDate> _Load()
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
}