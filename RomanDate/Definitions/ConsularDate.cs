using System.Collections.Generic;
using RomanDate.Enums;

namespace RomanDate.Definitions
{
    public class ConsularDate
    {
        public int Id { get; set; }
        public YearType Type { get; set; }
        public IEnumerable<Magistrate> Magistrates { get; set; }
    }

    public class Magistrate
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public Magistrates Type { get; set; }
    }
}