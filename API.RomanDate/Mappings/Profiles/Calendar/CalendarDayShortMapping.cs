using API.RomanDate.Helpers.UrlHelpers;
using API.RomanDate.Models.Calendar;
using API.RomanDate.ViewModels.Base;
using API.RomanDate.ViewModels.Calendar;
using RomanDate.Enums;

namespace API.RomanDate.Mappings.Profiles.Calendar
{
    public class CalendarDayShortMapping : ModelMapper<CalendarDay, CalendarDayShortViewModel>
    {
        public CalendarDayShortMapping()
        {
            this.RegisterMap(dest => dest.CommonEraDate, src => src.CommonEraDate.ToString("dd/MM"));
            this.RegisterMap(dest => dest.NundinalLetter, src => src.NundinalLetter.ToString());
            this.RegisterMap(dest => dest.Navigation, src => new Navigation
            {
                DayRef = UrlNavigation.DayRef(src.Era, src.CommonEraDate.Year, (Months)src.CommonEraDate.Month, src.CommonEraDate.Day)
            });

        }
    }
}
