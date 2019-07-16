using System.Collections.Generic;
using RomanDate.Enums;

namespace API.RomanDate.Models.Calendar
{
    public class CalendarMonth
    {
        public Months Month { get; set; }
        public int Year { get; set; }
        public string YearNumerals { get; set; } = "";
        public Eras Era { get; set; }
        public int AucYear { get; set; }
        public string AucYearNumerals { get; set; } = "";
        public IEnumerable<CalendarDay> Days { get; set; } = new List<CalendarDay>();
    }
}
