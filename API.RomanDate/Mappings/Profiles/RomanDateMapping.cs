using API.RomanDate.ViewModels;
using AutoMapper;
using RomanDate;

namespace API.RomanDate.Mappings.Profiles
{
    public class RomanDateMapping : Profile
    {
        public RomanDateMapping()
        {
            _ = this.CreateMap<RomanDateTime, RomanDateViewModel>()
                .ForMember(dest => dest.Month, o => o.MapFrom(src => src.Month.ToString()))
                .ForMember(dest => dest.CalendarMonth, o => o.MapFrom(src => src.ActualMonth.ToString()))
                .ForMember(dest => dest.RulingMagistrates, o => o.MapFrom(src => src.Magistrates.RulingMagistrates));
        }
    }
}
