using API.RomanDate.Models.Base;

namespace API.RomanDate.ViewModels.Calendar
{
    public class CalendarDayShortViewModel
    {
        public string CommonEraDate { get; set; } = "";
        public string NundinalLetter { get; set; } = "";
        public bool IsNundinae { get; set; }
        public string Day { get; set; } = "";
        public NavigationModel _Navigation { get; set; } = new NavigationModel();
    }
}
