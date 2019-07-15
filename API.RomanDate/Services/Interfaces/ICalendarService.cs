using API.RomanDate.Infrastructure.IoC;
using API.RomanDate.Models.Calendar;
using RomanDate.Enums;

namespace API.RomanDate.Services.Interfaces
{
    public interface ICalendarService : ITransient
    {
        CalendarMonth ReturnCalendarMonth(Eras era, int year, Months month);
    }
}
