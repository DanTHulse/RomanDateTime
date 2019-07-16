using API.RomanDate.Models.Calendar;
using API.RomanDate.ViewModels.Calendar;

namespace API.RomanDate.Mappings.Profiles.Calendar
{
    public class CalendarMonthShortMapping : ModelMapper<CalendarMonthShort, CalendarMonthShortViewModel>
    {
        public CalendarMonthShortMapping()
        {
            this.RegisterMap(dest => dest.Month, src => src.Month.ToString());
        }
    }
}
