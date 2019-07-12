using API.RomanDate.Infrastructure.IoC;
using API.RomanDate.Models;
using RomanDate.Enums;

namespace API.RomanDate.Services.Interfaces
{
    public interface ICalendarService : ITransient
    {
        Calendar ReturnCalendarMonth(Eras era, int year, Months month);
    }
}
