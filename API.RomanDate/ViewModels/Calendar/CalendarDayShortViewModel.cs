using API.RomanDate.ViewModels.Base;

namespace API.RomanDate.ViewModels.Calendar
{
    public class CalendarDayShortViewModel
    {
        public string CommonEraDate { get; set; } = "";
        public string NundinalLetter { get; set; } = "";
        public bool IsNundinae { get; set; }
        public string Day { get; set; } = "";
        public Navigation _Navigation { get; set; } = new Navigation();
    }
}
