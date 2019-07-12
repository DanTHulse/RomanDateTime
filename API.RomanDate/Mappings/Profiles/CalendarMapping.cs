using API.RomanDate.Models;
using API.RomanDate.ViewModels;

namespace API.RomanDate.Mappings.Profiles
{
    public class CalendarMapping : ModelMapper<Calendar, CalendarViewModel>
    {
        public CalendarMapping()
        {
            RegisterMap(dest => dest.CalendarMonth, src => src.CalendarMonth.ToString());
            RegisterMap(dest => dest.Year, src => $"{src.Year} {src.Era}");
        }
    }
}
