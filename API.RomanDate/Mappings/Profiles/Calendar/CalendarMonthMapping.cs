using API.RomanDate.Models.Calendar;
using API.RomanDate.ViewModels.Calendar;

namespace API.RomanDate.Mappings.Profiles.Calendar
{
    public class CalendarMonthMapping : ModelMapper<CalendarMonth, CalendarMonthViewModel>
    {
        public CalendarMonthMapping()
        {
            this.RegisterMap(dest => dest.Month, src => src.Month.ToString());
            this.RegisterMap(dest => dest.Era, src => src.Era.ToString());
            this.RegisterMap(dest => dest.Days, src => src.Days);
        }
    }
}
