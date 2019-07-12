using System.Collections.Generic;
using API.RomanDate.Infrastructure.IoC;
using API.RomanDate.Models;
using RomanDate.Enums;
using static RomanDate.Definitions.RomanMagistrates;

namespace API.RomanDate.Services.Interfaces
{
    public interface IMagistratesService : ISingleton
    {
        IEnumerable<MagistratesFull> GetAllMagistrates(Office office = Office.NotSet);
        IEnumerable<Magistrate>? GetMagistratesForYear(Eras era, int year);
        IEnumerable<Magistrate>? GetRulingMagistratesForYear(Eras era, int year);
    }
}
