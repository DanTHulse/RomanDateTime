using System.Collections.Generic;
using API.RomanDate.Models.Base;
using RomanDate.Enums;

namespace API.RomanDate.Models.Calendar
{
    public class CalendarYear
    {
        public int Year { get; set; }
        public int AucYear { get; set; }
        public Eras Era { get; set; }
        public string ConsularYear { get; set; } = "";
        public IEnumerable<CalendarMonthShort> Months { get; set; } = new List<CalendarMonthShort>();
        public IEnumerable<MagistratesFull> RulingMagistrates { get; set; } = new List<MagistratesFull>();
        public IEnumerable<MagistratesFull> OtherMagistrates { get; set; } = new List<MagistratesFull>();
        public NavigationModel _Navigation { get; set; } = new NavigationModel();
    }
}
