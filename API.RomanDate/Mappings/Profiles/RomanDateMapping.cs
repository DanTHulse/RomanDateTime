using API.RomanDate.ViewModels;
using RomanDate;
using RomanDate.Helpers.RomanDate;

namespace API.RomanDate.Mappings.Profiles
{
    public class RomanDateMapping : ModelMapper<RomanDateTime, RomanDateViewModel>
    {
        public RomanDateMapping()
        {
            RegisterMap(dest => dest.Month, src => src.Month.ToString());
            RegisterMap(dest => dest.CalendarMonth, src => src.ActualMonth.ToString());
            RegisterMap(dest => dest.NundinalLetter, src => src.NundinalLetter.ToString());
            RegisterMap(dest => dest.IsNundinae, src => src.IsNundinae());
            RegisterMap(dest => dest.RulingMagistrates, src => src.Magistrates.GetRulingMagistrates());
        }
    }
}
