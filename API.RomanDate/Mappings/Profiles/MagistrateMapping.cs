using API.RomanDate.Helpers.Enum;
using API.RomanDate.ViewModels;
using AutoMapper;
using static RomanDate.Definitions.RomanMagistrates;

namespace API.RomanDate.Mappings.Profiles
{
    public class MagistrateMapping : Profile
    {
        public MagistrateMapping()
        {
            _ = this.CreateMap<Magistrate, MagistrateSimpleViewModel>()
                .ForMember(dest => dest.Name, o => o.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Office, o => o.MapFrom(src => src.Office.GetDescription()));
        }
    }
}
