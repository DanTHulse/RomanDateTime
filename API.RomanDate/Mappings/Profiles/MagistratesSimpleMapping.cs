using API.RomanDate.Helpers.Enum;
using API.RomanDate.ViewModels;
using static RomanDate.Definitions.RomanMagistrates;

namespace API.RomanDate.Mappings.Profiles
{
    public class MagistratesSimpleMapping : ModelMapper<Magistrate, MagistrateSimpleViewModel>
    {
        public MagistratesSimpleMapping()
        {
            RegisterMap(dest => dest.Name, src => src.FullName);
            RegisterMap(dest => dest.Office, src => src.Office.GetDescription());
        }
    }
}
