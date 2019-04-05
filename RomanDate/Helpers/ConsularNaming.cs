using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using RomanDate.Definitions;

namespace RomanDate.Helpers
{
    public static class ConsularNaming
    {
        public static ConsularDate ReturnConsularYear(int aucYear)
        {
            var data = LoadData();

            var item = data.FirstOrDefault(f => f.Id == aucYear);

            return item;
        }

        private static IEnumerable<ConsularDate> LoadData()
        {
            using(StreamReader r = new StreamReader("./ConsularData/ConsularDates.json"))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<ConsularDate>>(json);

                return items;
            }
        }
    }
}