using API.RomanDate.ViewModels;
using AutoMapper;
using static RomanDate.Definitions.ConsularDate;

namespace API.RomanDate.Mappings.Profiles
{
    public class MagistrateMapping : Profile
    {
        public MagistrateMapping()
        {
            this.CreateMap<Magistrate, MagistrateViewModel>()
                .ForMember(dest => dest.Name, o => o.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Office, o => o.MapFrom(src => src.Office.ToString()));
        }
    }
}
