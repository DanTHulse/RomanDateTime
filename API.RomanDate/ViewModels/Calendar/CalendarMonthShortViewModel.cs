using API.RomanDate.ViewModels.Base;

namespace API.RomanDate.ViewModels.Calendar
{
    public class CalendarMonthShortViewModel
    {
        public int Number { get; set; }
        public string Month { get; set; } = "";
        public Navigation _Navigation { get; set; } = new Navigation();
    }
}
