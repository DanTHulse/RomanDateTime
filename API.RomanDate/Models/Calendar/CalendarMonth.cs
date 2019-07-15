using System.Collections.Generic;
using API.RomanDate.Models.Base;
using RomanDate.Enums;

namespace API.RomanDate.Models.Calendar
{
    public class CalendarMonth
    {
        public Months Month { get; set; }
        public int Year { get; set; }
        public Eras Era { get; set; }
        public IEnumerable<CalendarDayShort> Days { get; set; } = new List<CalendarDayShort>();
        public NavigationModel _Navigation { get; set; } = new NavigationModel();
    }
}
