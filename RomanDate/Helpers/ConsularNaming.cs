using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using RomanDate.Definitions;
using RomanDate.Enums;

namespace RomanDate.Helpers
{
    public static class ConsularNaming
    {
        public static ConsularDate ReturnConsularYearData(int aucYear)
        {
            var data = LoadData();

            var item = data.FirstOrDefault(f => f.Id == aucYear);

            return item;
        }

        public static string ParseConsularYear(ConsularDate data)
        {
            var cPrior = data.Magistrates.FirstOrDefault(f => f.Type == Magistrates.ConsulPrior);
            var cPosterior = data.Magistrates.FirstOrDefault(f => f.Type == Magistrates.ConsulPosterior);

            var s = $"The {data.Type} of {cPrior.ShortName} and {cPosterior.ShortName}";

            return "";
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