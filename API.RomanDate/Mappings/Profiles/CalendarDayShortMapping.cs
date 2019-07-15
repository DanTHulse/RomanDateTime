using API.RomanDate.Models.Calendar;
using API.RomanDate.ViewModels.Calendar;

namespace API.RomanDate.Mappings.Profiles
{
    public class CalendarDayShortMapping : ModelMapper<CalendarDayShort, CalendarDayShortViewModel>
    {
        public CalendarDayShortMapping()
        {
            RegisterMap(dest => dest.CommonEraDate, src => src.CommonEraDate.ToString("dd/MM"));
            RegisterMap(dest => dest.IsNundinae, src => src.IsNundinae);
            RegisterMap(dest => dest.NundinalLetter, src => src.NundinalLetter.ToString());
            RegisterMap(dest => dest.Day, src => src.Day);
        }
    }
}
