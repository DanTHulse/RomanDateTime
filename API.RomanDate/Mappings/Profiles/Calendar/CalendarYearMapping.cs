using API.RomanDate.Models.Calendar;
using API.RomanDate.ViewModels.Calendar;

namespace API.RomanDate.Mappings.Profiles.Calendar
{
    public class CalendarYearMapping : ModelMapper<CalendarYear, CalendarYearViewModel>
    {
        public CalendarYearMapping()
        {
            this.RegisterMap(dest => dest.Era, src => src.Era.ToString());
            this.RegisterMap(dest => dest.Year, src => src.YearNumerals);
            this.RegisterMap(dest => dest.AucYear, src => src.AucYearNumerals);
            this.RegisterMap(dest => dest.Months, src => src.Months);
            this.RegisterMap(dest => dest.RulingMagistrates, src => src.RulingMagistrates);
            this.RegisterMap(dest => dest.OtherMagistrates, src => src.OtherMagistrates);
        }
    }
}
