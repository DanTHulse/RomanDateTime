using API.RomanDate.Helpers.UrlHelpers;
using API.RomanDate.Models.Calendar;
using API.RomanDate.ViewModels.Base;
using API.RomanDate.ViewModels.Calendar;

namespace API.RomanDate.Mappings.Profiles.Calendar
{
    public class CalendarDayMapping : ModelMapper<CalendarDay, CalendarDayViewModel>
    {
        public CalendarDayMapping()
        {
            this.RegisterMap(dest => dest.Month, src => src.Month.ToString());
            this.RegisterMap(dest => dest.Year, src => src.YearNumerals);
            this.RegisterMap(dest => dest.AucYear, src => src.AucYearNumerals);
            this.RegisterMap(dest => dest.NundinalLetter, src => src.NundinalLetter.ToString());
            this.RegisterMap(dest => dest.Events, src => src.Events);
            this.RegisterMap(dest => dest.Navigation, src => new Navigation
            {
                MonthRef = UrlNavigation.MonthRef(src.Era, src.Year, src.Month),
                YearRef = UrlNavigation.YearRef(src.Era, src.Year)
            });
        }
    }
}
