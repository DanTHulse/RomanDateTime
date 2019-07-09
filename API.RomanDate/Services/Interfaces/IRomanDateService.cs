using System;
using RomanDate;
using RomanDate.Enums;

namespace API.RomanDate.Services.Interfaces
{
    public interface IRomanDateService : IService
    {
        RomanDateTime GetCurrentDate(bool aucEra = false);
        RomanDateTime GetRomanDate(DateTime date, Eras era);
    }
}
