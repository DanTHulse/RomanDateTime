using System.Collections.Generic;

namespace API.RomanDate.ViewModels.Calendar
{
    public class CalendarMonthViewModel
    {
        public string CalendarMonth { get; set; } = "";
        public string Year { get; set; } = "";
        public IEnumerable<CalendarDayShortViewModel> CalendarDays { get; set; } = new List<CalendarDayShortViewModel>();
    }
}
