using API.RomanDate.Helpers;
using API.RomanDate.ViewModels;
using static RomanDate.Definitions.RomanMagistrates;

namespace API.RomanDate.Mappings.Profiles
{
    public class MagistratesSimpleMapping : ModelMapper<Magistrate, MagistrateSimpleViewModel>
    {
        public MagistratesSimpleMapping()
        {
            this.RegisterMap(dest => dest.Name, src => src.FullName);
            this.RegisterMap(dest => dest.Office, src => src.Office.GetDescription());
        }
    }
}
