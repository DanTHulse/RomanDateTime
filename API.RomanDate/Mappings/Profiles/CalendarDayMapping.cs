using API.RomanDate.Models.Calendar;
using API.RomanDate.ViewModels.Calendar;

namespace API.RomanDate.Mappings.Profiles
{
    public class CalendarDayMapping : ModelMapper<CalendarDay, CalendarDayViewModel>
    {
        public CalendarDayMapping()
        {
            RegisterMap(dest => dest.Month, src => src.Month.ToString());
            RegisterMap(dest => dest.NundinalLetter, src => src.NundinalLetter.ToString());
            RegisterMap(dest => dest.IsNundinae, src => src.IsNundinae);
        }
    }
}
