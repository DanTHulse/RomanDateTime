using API.RomanDate.Helpers.UrlHelpers;
using API.RomanDate.Models.Calendar;
using API.RomanDate.ViewModels.Base;
using API.RomanDate.ViewModels.Calendar;

namespace API.RomanDate.Mappings.Profiles.Calendar
{
    public class CalendarMonthShortMapping : ModelMapper<CalendarMonth, CalendarMonthShortViewModel>
    {
        public CalendarMonthShortMapping()
        {
            this.RegisterMap(dest => dest.Month, src => src.Month.ToString());
            this.RegisterMap(dest => dest.Number, src => (int)src.Month);
            this.RegisterMap(dest => dest.Navigation, src => new Navigation
            {
                MonthRef = UrlNavigation.MonthRef(src.Era, src.Year, src.Month),
            });
        }
    }
}
