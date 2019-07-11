using API.RomanDate.Models;
using API.RomanDate.ViewModels;

namespace API.RomanDate.Mappings.Profiles
{
    public class MagistratesFullMapping : ModelMapper<MagistratesFull, MagistrateViewModel>
    {
        public MagistratesFullMapping()
        {
            RegisterMap(dest => dest.ElectedOffices, src => src.ElectedOffices);
        }
    }
}
