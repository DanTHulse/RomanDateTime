using System.Collections.Generic;
using System.Text.Json.Serialization;
using API.RomanDate.ViewModels.Base;

namespace API.RomanDate.ViewModels.Calendar
{
    public class CalendarYearViewModel
    {
        public string Year { get; set; } = "";
        public string AucYear { get; set; } = "";
        public string Era { get; set; } = "";
        public string ConsularYear { get; set; } = "";
        public IEnumerable<CalendarMonthShortViewModel> Months { get; set; } = new List<CalendarMonthShortViewModel>();
        public IEnumerable<MagistrateViewModel> RulingMagistrates { get; set; } = new List<MagistrateViewModel>();
        public IEnumerable<MagistrateViewModel> OtherMagistrates { get; set; } = new List<MagistrateViewModel>();

        [JsonPropertyName("_navigation")]
        public Navigation? Navigation { get; set; }
    }
}
