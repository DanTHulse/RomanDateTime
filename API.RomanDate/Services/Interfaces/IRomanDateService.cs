using System;
using API.RomanDate.Infrastructure.IoC;
using RomanDate;
using RomanDate.Enums;

namespace API.RomanDate.Services.Interfaces
{
    public interface IRomanDateService : ITransient
    {
        RomanDateTime GetCurrentDate();
        RomanDateTime GetRomanDate(Eras era, DateTime date);
    }
}
