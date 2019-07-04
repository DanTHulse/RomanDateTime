using Newtonsoft.Json;
using RomanDate.Enums;

namespace RomanDate.Definitions
{
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
