namespace RomanDate.Definitions
{
    public class RomanCalendarModel
    {
        public int DayNumber { get; set; }
        public string NundinalLetter { get; set; }
        public bool IsNundinae { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Era { get; set; }
        public RomanDateTime RomanDateTime { get; set; }
    }

    public class CalendarData
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}