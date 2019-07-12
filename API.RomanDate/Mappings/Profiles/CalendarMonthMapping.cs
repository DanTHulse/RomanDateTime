using API.RomanDate.Models;
using API.RomanDate.ViewModels;

namespace API.RomanDate.Mappings.Profiles
{
    public class CalendarMonthMapping : ModelMapper<CalendarMonth, CalendarMonthViewModel>
    {
        public CalendarMonthMapping()
        {
            RegisterMap(dest => dest.CommonEraDate, src => src.CommonEraDate.ToString("dd/MM"));
            RegisterMap(dest => dest.IsNundinae, src => src.IsNundinae);
            RegisterMap(dest => dest.NundinalLetter, src => src.NundinalLetter.ToString());
            RegisterMap(dest => dest.RomanDay, src => src.RomanDay);
        }
    }
}
