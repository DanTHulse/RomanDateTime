using System.Collections.Generic;
using API.RomanDate.Models.Base;
using RomanDate.Enums;

namespace API.RomanDate.Models.Calendar
{
    public class CalendarDay
    {
        public int Year { get; set; }
        public int AucYear { get; set; }
        public string Day { get; set; } = "";
        public Months Month { get; set; }
        public NundinalLetters NundinalLetter { get; set; }
        public bool IsNundinae { get; set; }
        public IEnumerable<CalendarEvent> Events { get; set; } = new List<CalendarEvent>();
        public NavigationModel _Navigation { get; set; } = new NavigationModel();
    }
}
