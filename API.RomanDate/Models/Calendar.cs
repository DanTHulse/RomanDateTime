using System.Collections.Generic;
using RomanDate.Enums;

namespace API.RomanDate.Models
{
    public class Calendar
    {
        public Months CalendarMonth { get; set; }
        public int Year { get; set; }
        public Eras Era { get; set; }
        public IEnumerable<CalendarMonth> CalendarDays { get; set; } = new List<CalendarMonth>();
    }
}
