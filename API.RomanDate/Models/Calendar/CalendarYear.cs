using System.Collections.Generic;
using RomanDate.Enums;

namespace API.RomanDate.Models.Calendar
{
    public class CalendarYear
    {
        public string Year { get; set; } = "";
        public string AucYear { get; set; } = "";
        public Eras Era { get; set; }
        public string ConsularYear { get; set; } = "";
        public IEnumerable<CalendarMonthShort> Months { get; set; } = new List<CalendarMonthShort>();
        public IEnumerable<MagistratesFull> RulingMagistrates { get; set; } = new List<MagistratesFull>();
        public IEnumerable<MagistratesFull> OtherMagistrates { get; set; } = new List<MagistratesFull>();
    }
}
