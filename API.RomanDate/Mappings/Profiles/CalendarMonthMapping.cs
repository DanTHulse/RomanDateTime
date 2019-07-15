using API.RomanDate.Models.Calendar;
using API.RomanDate.ViewModels.Calendar;

namespace API.RomanDate.Mappings.Profiles
{
    public class CalendarMonthMapping : ModelMapper<CalendarMonth, CalendarMonthViewModel>
    {
        public CalendarMonthMapping()
        {
            RegisterMap(dest => dest.CalendarMonth, src => src.Month.ToString());
            RegisterMap(dest => dest.Year, src => $"{src.Year} {src.Era}");
        }
    }
}
