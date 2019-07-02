using System.Collections.Generic;
using RomanDate.Enums;

namespace RomanDate.Definitions
{
    internal class ConsularDate
    {
        public int Id { get; set; }
        public YearType Type { get; set; }
        public IEnumerable<Magistrate> Magistrates { get; set; }
        public string Override { get; set; }
    }
}