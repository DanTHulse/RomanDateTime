using API.RomanDate.Helpers.Enum;
using API.RomanDate.ViewModels;
using static RomanDate.Definitions.RomanMagistrates;

namespace API.RomanDate.Mappings.Profiles
{
    public class MagistrateMapping : ModelMapper<Magistrate, MagistrateSimpleViewModel>
    {
        public MagistrateMapping()
        {
            RegisterMap(dest => dest.Name, src => src.FullName);
            RegisterMap(dest => dest.Office, src => src.Office.GetDescription());
        }
    }
}
