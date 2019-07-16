using System.Text.Json.Serialization;
using API.RomanDate.ViewModels.Base;

namespace API.RomanDate.ViewModels.Calendar
{
    public class CalendarDayShortViewModel
    {
        public string CommonEraDate { get; set; } = "";
        public string NundinalLetter { get; set; } = "";
        public bool IsNundinae { get; set; }
        public string Day { get; set; } = "";

        [JsonPropertyName("_navigation")]
        public Navigation? Navigation { get; set; }
    }
}
