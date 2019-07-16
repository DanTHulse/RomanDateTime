using API.RomanDate.Models.Calendar;
using API.RomanDate.ViewModels.Calendar;

namespace API.RomanDate.Mappings.Profiles.Calendar
{
    public class CalendarDayMapping : ModelMapper<CalendarDay, CalendarDayViewModel>
    {
        public CalendarDayMapping()
        {
            this.RegisterMap(dest => dest.Month, src => src.Month.ToString());
            this.RegisterMap(dest => dest.NundinalLetter, src => src.NundinalLetter.ToString());
            this.RegisterMap(dest => dest.Events, src => src.Events);
        }
    }
}
