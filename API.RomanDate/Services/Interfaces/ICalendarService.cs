using API.RomanDate.Infrastructure.IoC;
using API.RomanDate.Models.Calendar;
using RomanDate.Enums;

namespace API.RomanDate.Services.Interfaces
{
    public interface ICalendarService : ITransient
    {
        CalendarYear ReturnCalendarYear(Eras era, int year);
        CalendarMonth ReturnCalendarMonth(Eras era, int year, Months month);
        CalendarDay ReturnCalendarDay(Eras era, int year, Months month, int day);
    }
}
