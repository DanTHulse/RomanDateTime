using System.Collections.Generic;
using API.RomanDate.Infrastructure.IoC;
using API.RomanDate.ViewModels;
using RomanDate.Enums;

namespace API.RomanDate.Services.Interfaces
{
    public interface IMagistratesService : ISingleton
    {
        IEnumerable<MagistrateViewModel> GetAllMagistrates();
        IEnumerable<MagistrateViewModel> GetAllMagistratesForOffice(Office office);
        IEnumerable<MagistrateViewModel> GetMagistratesForYear(Eras era, int year);
        IEnumerable<MagistrateViewModel> GetRulingMagistratesForYear(Eras era, int year);
        IEnumerable<MagistrateViewModel> InsertMagistrateDataForYear(Eras era, int year, object data);
        IEnumerable<MagistrateViewModel> UpdateMagistrateDataForYear(Eras era, int year, object data);
    }
}
