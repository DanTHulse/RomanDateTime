using System.Collections.Generic;
using System.Text.Json.Serialization;
using API.RomanDate.ViewModels.Base;

namespace API.RomanDate.ViewModels.Calendar
{
    public class CalendarMonthViewModel
    {
        public string Month { get; set; } = "";
        public string Year { get; set; } = "";
        public string AucYear { get; set; } = "";
        public string Era { get; set; } = "";
        public IEnumerable<CalendarDayShortViewModel> Days { get; set; } = new List<CalendarDayShortViewModel>();

        [JsonPropertyName("_navigation")]
        public Navigation Navigation { get; set; } = new Navigation();
    }
}
