using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RomanDate.Definitions;
using RomanDate.Enums;

namespace RomanDate.Helpers
{
    internal static class ConsularNaming
    {
        internal static ConsularDate ReturnConsularYearData(int aucYear)
        {
            var data = LoadData();

            var item = data.FirstOrDefault(f => f.Id == aucYear);

            return item;
        }

        internal static string ParseConsularYear(this ConsularDate data)
        {
            if (data != null)
            {
                if (!string.IsNullOrEmpty(data.Override))
                    return data.Override;

                var sb = new StringBuilder();
                sb.Append($"Year of the {data.Type.GetDescription()} of ");

                if (data.Type == YearType.Dictatorship)
                    sb.Append(data.Dictator.ShortName);
                else if (data.Type == YearType.Tribunship)
                    sb.Append($"{string.Join(", ", data.Tribuni.Take(data.Tribuni.Count() - 1).Select(s => s.ShortName))}, and {data.Tribuni.Last().ShortName}");
                else if (data.Type == YearType.Consulship)
                    sb.Append(data.ConsulPrior.ShortName);
                if (data.ConsulPosterior != null)
                    sb.Append($" and {data.ConsulPosterior.ShortName}");
                else
                    sb.Append(" without colleague");

                return sb.ToString();
            }

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