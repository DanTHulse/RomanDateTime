using System;
using API.RomanDate.Models.Base;
using RomanDate.Enums;

namespace API.RomanDate.Models.Calendar
{
    public class CalendarDayShort
    {
        public DateTime CommonEraDate { get; set; }
        public NundinalLetters NundinalLetter { get; set; }
        public bool IsNundinae { get; set; }
        public string Day { get; set; }
        public NavigationModel _Navigation { get; set; } = new NavigationModel();
    }
}
