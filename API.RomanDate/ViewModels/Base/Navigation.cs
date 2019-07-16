using System;
using Newtonsoft.Json;

namespace API.RomanDate.ViewModels.Base
{
    public class Navigation
    {
        [JsonProperty("_nextYear", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? NextYear { get; set; }

        [JsonProperty("_prevMonth", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? PrevYear { get; set; }

        [JsonProperty("_nextMonth", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? NextMonth { get; set; }

        [JsonProperty("_prevMonth", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? PrevMonth { get; set; }

        [JsonProperty("_nextDay", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? NextDay { get; set; }

        [JsonProperty("_prevDay", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? PrevDay { get; set; }

        [JsonProperty("_year", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? YearRef { get; set; }

        [JsonProperty("_month", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? MonthRef { get; set; }

        [JsonProperty("_day", NullValueHandling = NullValueHandling.Ignore)]
        public Uri? DayRef { get; set; }
    }
}
