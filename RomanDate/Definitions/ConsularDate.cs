using System.Collections.Generic;
using Newtonsoft.Json;
using RomanDate.Enums;

namespace RomanDate.Definitions
{
    internal class ConsularDate
    {
        public int Id { get; set; }
        [JsonProperty("type")]
        public YearOf YearOf { get; set; } 
        public IEnumerable<Magistrate> Magistrates { get; set; }
        public string Override { get; set; }
    }
}