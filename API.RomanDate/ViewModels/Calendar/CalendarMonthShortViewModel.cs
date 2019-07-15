using API.RomanDate.Models.Base;

namespace API.RomanDate.ViewModels.Calendar
{
    public class CalendarMonthShortViewModel
    {
        public int Number { get; set; }
        public string Month { get; set; } = "";
        public NavigationModel _Navigation { get; set; } = new NavigationModel();
    }
}
