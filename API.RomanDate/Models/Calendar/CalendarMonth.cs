using System.Collections.Generic;
using RomanDate.Enums;

namespace API.RomanDate.Models.Calendar
{
    public class CalendarMonth
    {
        public Months Month { get; set; }
        public string Year { get; set; } = "";
        public string AucYear { get; set; } = "";
        public Eras Era { get; set; }
        public IEnumerable<CalendarDayShort> Days { get; set; } = new List<CalendarDayShort>();
    }
}
