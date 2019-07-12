using System;
using RomanDate.Enums;

namespace API.RomanDate.Models
{
    public class CalendarMonth
    {
        public DateTime CommonEraDate { get; set; }
        public NundinalLetters NundinalLetter { get; set; }
        public bool IsNundinae { get; set; }
        public string RomanDay { get; set; } = "";
    }
}
