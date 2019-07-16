using System;
using API.RomanDate.Infrastructure.IoC;
using RomanDate.Enums;

namespace API.RomanDate.Services.Interfaces
{
    public interface INavigationService : ITransient
    {
        Uri NextYear(Eras era, int year);
        Uri PrevYear(Eras era, int year);
        Uri NextMonth(Eras era, int year, Months month);
        Uri PrevMonth(Eras era, int year, Months month);
        Uri NextDay(Eras era, int year, Months month, int day);
        Uri PrevDay(Eras era, int year, Months month, int day);
        Uri YearRef(Eras era, int year);
        Uri MonthRef(Eras era, int year, Months month);
        Uri DayRef(Eras era, int year, Months month, int day);
    }
}
