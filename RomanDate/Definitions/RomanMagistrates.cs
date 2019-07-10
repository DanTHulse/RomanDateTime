using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RomanDate.Enums;
using RomanDate.Extensions;

namespace RomanDate.Definitions
{
    public struct RomanMagistrates
    {
        [JsonProperty("id")]
        internal int? AucYear { get; set; }

        [JsonProperty("type")]
        internal YearOf YearOf { get; set; }

        [JsonProperty]
        internal IEnumerable<Magistrate> Magistrates { get; set; }

        [JsonProperty]
        internal string? Override { get; set; }

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
        /// Gets the Elected magistrates for the given AUC year
        /// </summary>
        /// <param name="aucYear">The AUC year to return consular data for</param>
        /// <returns>A new <see cref="RomanMagistrates"/> record for the AUC year</returns>
        public static RomanMagistrates Get(int aucYear) => ReturnRomanMagistrateDataForYear(aucYear);

        /// <summary>
        /// Gets all Magistrates
        /// </summary>
        /// <returns>A list of all <see cref="RomanMagistrates"/></returns>
        public static IEnumerable<RomanMagistrates> GetAll() => LoadData();

        /// <summary>
        /// Gets the Magistrates elected for the given year by the office they held
        /// </summary>
        /// <param name="office">The office the elected magistrate held</param>
        /// <returns>A list of <see cref="Magistrate"/> for the specified office elected that year</returns>
        public IEnumerable<Magistrate> GetMagistrates(Office office) => this.Magistrates.Where(w => w.Office == office);

        internal string ParseConsularYear()
        {
            if (this.AucYear == null)
                return "";
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

        internal static RomanMagistrates ReturnRomanMagistrateDataForYear(int aucYear) => LoadData().FirstOrDefault(f => f.AucYear == aucYear);

        internal static IEnumerable<RomanMagistrates> LoadData()
        {
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

            using var r = new StreamReader("./MagistrateData/RomanMagistrates.json");
            var json = r.ReadToEnd();
            var items = JsonConvert.DeserializeObject<List<RomanMagistrates>>(json, settings);

            return items;
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