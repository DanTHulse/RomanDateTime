using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate.Definitions
{
    public struct ConsularDate
    {
        public int Id { get; set; }

        [JsonProperty("type")]
        public YearOf YearOf { get; set; }

        public IEnumerable<Magistrate> Magistrates { get; set; }

        public string? Override { get; set; }

        internal static ConsularDate Get(int aucYear) => ReturnConsularYearData(aucYear);

        /// <summary>
        /// Gets the ruling Magistrates (i.e. the highest ranked Magistrates) elected for this year
        /// </summary>
        public IEnumerable<Magistrate> RulingMagistrates => this.YearOf switch
        {
            YearOf.Consulship => this.Magistrates.Where(w => w.Office.In(Office.ConsulPrior, Office.ConsulPosterior, Office.ConsulSuffectus)),
            YearOf.Tribunship => this.Magistrates.Where(w => w.Office == Office.Tribune),
            YearOf.Dictatorship => this.Magistrates.Where(w => w.Office == Office.Dictator),
            YearOf.Decemvirate => this.Magistrates.Where(w => w.Office == Office.Decemvir),
            _ => new List<Magistrate>()
        };

        /// <summary>
        /// Gets the Magistrates elected for the given year by the office they held
        /// </summary>
        /// <param name="office">The office the elected magistrate held</param>
        /// <returns>A list of <see cref="Magistrate"/> for the specified office elected that year</returns>
        public IEnumerable<Magistrate> GetMagistrates(Office office) => this.Magistrates.Where(w => w.Office == office);

        private static ConsularDate ReturnConsularYearData(int aucYear)
        {
            return _Load().FirstOrDefault(f => f.Id == aucYear);

            static IEnumerable<ConsularDate> _Load()
            {
                using var r = new StreamReader("./ConsularData/ConsularDates.json");
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<ConsularDate>>(json);

                return items;
            }
        }

        internal string ParseConsularYear()
        {
            if (!string.IsNullOrEmpty(this.Override))
                return this.Override;

            var sb = new StringBuilder($"Year of the {this.YearOf.GetDescription()} of ");

            if (this.YearOf == YearOf.Dictatorship)
            {
                _ = sb.Append(this.GetMagistrates(Office.Dictator).First().ShortName);
            }
            else if (this.YearOf == YearOf.Tribunship)
            {
                var tribuni = this.GetMagistrates(Office.Tribune);
                _ = sb.Append($"{string.Join(", ", tribuni.Take(tribuni.Count() - 1).Select(s => s.ShortName))}, and {tribuni.Last().ShortName}");
            }
            else if (this.YearOf == YearOf.Consulship)
            {
                _ = sb.Append(this.GetMagistrates(Office.ConsulPrior).First().ShortName);

                var consulPosterior = this.GetMagistrates(Office.ConsulPosterior).FirstOrDefault();

                if (consulPosterior != null)
                    _ = sb.Append($" and {consulPosterior.ShortName}");
                else
                    _ = sb.Append(" without colleague");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Details on the Magistrate
        /// </summary>
        public class Magistrate
        {
            /// <summary>
            /// The full Latin styled name of the Magistrate
            /// </summary>
            public string FullName { get; set; } = "";

            /// <summary>
            /// A shortened name for the Magistrate
            /// </summary>
            public string ShortName { get; set; } = "";

            /// <summary>
            /// The office that the Magistrate was elected to / assumed 
            /// </summary>
            [JsonProperty("type")]
            public Office Office { get; set; }
        }
    }
}