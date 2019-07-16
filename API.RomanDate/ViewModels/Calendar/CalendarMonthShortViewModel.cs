using System.Text.Json.Serialization;
using API.RomanDate.ViewModels.Base;

namespace API.RomanDate.ViewModels.Calendar
{
    public class CalendarMonthShortViewModel
    {
        public int Number { get; set; }
        public string Month { get; set; } = "";

        [JsonPropertyName("_navigation")]
        public Navigation? Navigation { get; set; }
    }
}
