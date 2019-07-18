using System;
using RomanDate.Enums;

namespace RomanDate.Definitions
{
    public struct RomanEvents
    {
        public string Event { get; set; }
        public DateTime? Date { get; set; }
        public EventType Type { get; set; }
        public Months? MonthOfEvent { get; set; }
    }
}
