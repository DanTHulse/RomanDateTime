using RomanDate.Enums;

namespace API.RomanDate.Helpers.UrlHelpers
{
    public static class UrlNavigation
    {
#if DEBUG
        private readonly static string _baseUrl = "https://localhost:44368/api";
#else
        private readonly static string _baseUrl = "https://localhost:44368/api";
#endif

        public static string NextYear(Eras era, int year)
            => $"{_baseUrl}/dates/{era}/{year}/";

        public static string PrevYear(Eras era, int year)
            => $"{_baseUrl}/dates/{era}/{year}/";

        public static string NextMonth(Eras era, int year, Months month)
            => $"{_baseUrl}/dates/{era}/{year}/{month}/";

        public static string PrevMonth(Eras era, int year, Months month)
            => $"{_baseUrl}/dates/{era}/{year}/{month}/";

        public static string NextDay(Eras era, int year, Months month, int day)
            => $"{_baseUrl}/dates/{era}/{year}/{month}/{day}/";

        public static string PrevDay(Eras era, int year, Months month, int day)
            => $"{_baseUrl}/dates/{era}/{year}/{month}/{day}/";

        public static string YearRef(Eras era, int year)
            => $"{_baseUrl}/dates/{era}/{year}";

        public static string MonthRef(Eras era, int year, Months month)
            => $"{_baseUrl}/dates/{era}/{year}/{month}/";

        public static string DayRef(Eras era, int year, Months month, int day)
            => $"{_baseUrl}/dates/{era}/{year}/{month}/{day}/";
    }
}
