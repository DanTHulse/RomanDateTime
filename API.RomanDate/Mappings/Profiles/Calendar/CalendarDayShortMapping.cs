using API.RomanDate.Models.Calendar;
using API.RomanDate.ViewModels.Calendar;

namespace API.RomanDate.Mappings.Profiles.Calendar
{
    public class CalendarDayShortMapping : ModelMapper<CalendarDayShort, CalendarDayShortViewModel>
    {
        public CalendarDayShortMapping()
        {
            this.RegisterMap(dest => dest.CommonEraDate, src => src.CommonEraDate.ToString("dd/MM"));
            this.RegisterMap(dest => dest.NundinalLetter, src => src.NundinalLetter.ToString());
        }
    }
}
