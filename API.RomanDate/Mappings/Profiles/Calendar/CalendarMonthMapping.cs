﻿using API.RomanDate.Helpers.UrlHelpers;
using API.RomanDate.Models.Calendar;
using API.RomanDate.ViewModels.Base;
using API.RomanDate.ViewModels.Calendar;

namespace API.RomanDate.Mappings.Profiles.Calendar
{
    public class CalendarMonthMapping : ModelMapper<CalendarMonth, CalendarMonthViewModel>
    {
        public CalendarMonthMapping()
        {
            this.RegisterMap(dest => dest.Month, src => src.Month.ToString());
            this.RegisterMap(dest => dest.Year, src => src.YearNumerals);
            this.RegisterMap(dest => dest.AucYear, src => src.AucYearNumerals);
            this.RegisterMap(dest => dest.Era, src => src.Era.ToString());
            this.RegisterMap(dest => dest.Days, src => src.Days);
            this.RegisterMap(dest => dest.Navigation, src => new Navigation
            {
                YearRef = UrlNavigation.YearRef(src.Era, src.Year)
            });
        }
    }
}