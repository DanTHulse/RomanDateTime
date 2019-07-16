using System;
using System.Collections.Generic;
using RomanDate.Enums;

namespace API.RomanDate.Models.Calendar
{
    public class CalendarDay
    {
        public int Year { get; set; }
        public string YearNumerals { get; set; } = "";
        public int AucYear { get; set; }
        public string AucYearNumerals { get; set; } = "";
        public Eras Era { get; set; }
        public int DayNumber { get; set; }
        public string Day { get; set; } = "";
        public DateTime CommonEraDate { get; set; }
        public Months Month { get; set; }
        public NundinalLetters NundinalLetter { get; set; }
        public bool IsNundinae { get; set; }
        public IEnumerable<CalendarEvent> Events { get; set; } = new List<CalendarEvent>();
    }
}
