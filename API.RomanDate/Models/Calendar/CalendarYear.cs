using System.Collections.Generic;
using RomanDate.Enums;

namespace API.RomanDate.Models.Calendar
{
    public class CalendarYear
    {
        public int Year { get; set; }
        public string YearNumerals { get; set; } = "";
        public Eras Era { get; set; }
        public int AucYear { get; set; }
        public string AucYearNumerals { get; set; } = "";
        public string ConsularYear { get; set; } = "";
        public IEnumerable<CalendarMonth> Months { get; set; } = new List<CalendarMonth>();
        public IEnumerable<MagistratesFull> RulingMagistrates { get; set; } = new List<MagistratesFull>();
        public IEnumerable<MagistratesFull> OtherMagistrates { get; set; } = new List<MagistratesFull>();
    }
}
