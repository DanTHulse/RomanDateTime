using API.RomanDate.Infrastructure;
using API.RomanDate.Services.Interfaces;
using RomanDate.Enums;

namespace API.RomanDate.Services
{
    public class NavigationService : INavigationService
    {
        private readonly AppSettings _config;
        private readonly string _baseUrl;

        public NavigationService(AppSettings config)
        {
            this._config = config;
            this._baseUrl = this._config.ApiBaseUrl;
        }

        public string NextYear(Eras era, int year)
            => $"{this._baseUrl}/dates/{era}/{year}/";

        public string PrevYear(Eras era, int year)
            => $"{this._baseUrl}/dates/{era}/{year}/";

        public string NextMonth(Eras era, int year, Months month)
            => $"{this._baseUrl}/dates/{era}/{year}/{month}/";

        public string PrevMonth(Eras era, int year, Months month)
            => $"{this._baseUrl}/dates/{era}/{year}/{month}/";

        public string NextDay(Eras era, int year, Months month, int day)
            => $"{this._baseUrl}/dates/{era}/{year}/{month}/{day}/";

        public string PrevDay(Eras era, int year, Months month, int day)
            => $"{this._baseUrl}/dates/{era}/{year}/{month}/{day}/";

        public string YearRef(Eras era, int year)
            => $"{this._baseUrl}/dates/{era}/{year}";

        public string MonthRef(Eras era, int year, Months month)
            => $"{this._baseUrl}/dates/{era}/{year}/{month}/";

        public string DayRef(Eras era, int year, Months month, int day)
            => $"{this._baseUrl}/dates/{era}/{year}/{month}/{day}/";
    }
}
