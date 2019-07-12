using System.Collections.Generic;

namespace API.RomanDate.ViewModels
{
    public class CalendarViewModel
    {
        public string CalendarMonth { get; set; } = "";
        public string Year { get; set; } = "";
        public IEnumerable<CalendarMonthViewModel> CalendarDays { get; set; } = new List<CalendarMonthViewModel>();
    }
}
