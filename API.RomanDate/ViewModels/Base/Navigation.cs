using System.Text.Json.Serialization;

namespace API.RomanDate.ViewModels.Base
{
    public class Navigation
    {
        [JsonPropertyName("_nextYear")]
        public string? NextYear { get; set; }

        [JsonPropertyName("_prevYear")]
        public string? PrevYear { get; set; }

        [JsonPropertyName("_nextMonth")]
        public string? NextMonth { get; set; }

        [JsonPropertyName("_prevMonth")]
        public string? PrevMonth { get; set; }

        [JsonPropertyName("_nextDay")]
        public string? NextDay { get; set; }

        [JsonPropertyName("_prevDay")]
        public string? PrevDay { get; set; }

        [JsonPropertyName("_year")]
        public string? YearRef { get; set; }

        [JsonPropertyName("_month")]
        public string? MonthRef { get; set; }

        [JsonPropertyName("_day")]
        public string? DayRef { get; set; }
    }
}
