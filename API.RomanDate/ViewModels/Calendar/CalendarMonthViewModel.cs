using System.Collections.Generic;
using API.RomanDate.Models.Base;

namespace API.RomanDate.ViewModels.Calendar
{
    public class CalendarMonthViewModel
    {
        public string Month { get; set; } = "";
        public string Year { get; set; } = "";
        public string AucYear { get; set; } = "";
        public string Era { get; set; } = "";
        public IEnumerable<CalendarDayShortViewModel> Days { get; set; } = new List<CalendarDayShortViewModel>();
        public NavigationModel _Navigation { get; set; } = new NavigationModel();
    }
}
