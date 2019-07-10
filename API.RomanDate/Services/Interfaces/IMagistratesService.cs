using System.Collections.Generic;
using API.RomanDate.Infrastructure.IoC;
using RomanDate.Enums;

namespace API.RomanDate.Services.Interfaces
{
    public interface IMagistratesService : ISingleton
    {
        IEnumerable<object> GetAllMagistrates();
        IEnumerable<object> GetAllMagistratesForOffice(Office office);
        IEnumerable<object> GetMagistratesForYear(Eras era, int year);
        IEnumerable<object> GetRulingMagistratesForYear(Eras era, int year);
        IEnumerable<object> InsertMagistrateDataForYear(Eras era, int year, object data);
        IEnumerable<object> UpdateMagistrateDataForYear(Eras era, int year, object data);
    }
}
