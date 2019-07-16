using System;
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

        public Uri NextYear(Eras era, int year)
            => new Uri($"{this._baseUrl}/dates/{era}/{year}/");

        public Uri PrevYear(Eras era, int year)
            => new Uri($"{this._baseUrl}/dates/{era}/{year}/");

        public Uri NextMonth(Eras era, int year, Months month)
            => new Uri($"{this._baseUrl}/dates/{era}/{year}/{month}/");

        public Uri PrevMonth(Eras era, int year, Months month)
            => new Uri($"{this._baseUrl}/dates/{era}/{year}/{month}/");

        public Uri NextDay(Eras era, int year, Months month, int day)
            => new Uri($"{this._baseUrl}/dates/{era}/{year}/{month}/{day}/");

        public Uri PrevDay(Eras era, int year, Months month, int day)
            => new Uri($"{this._baseUrl}/dates/{era}/{year}/{month}/{day}/");

        public Uri YearRef(Eras era, int year)
            => new Uri($"{this._baseUrl}/dates/{era}/{year}");

        public Uri MonthRef(Eras era, int year, Months month)
            => new Uri($"{this._baseUrl}/dates/{era}/{year}/{month}/");

        public Uri DayRef(Eras era, int year, Months month, int day)
            => new Uri($"{this._baseUrl}/dates/{era}/{year}/{month}/{day}/");
    }
}
