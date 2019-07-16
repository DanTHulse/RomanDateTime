using System.Collections.Generic;
using API.RomanDate.Infrastructure.IoC;
using API.RomanDate.Models.Calendar;
using RomanDate.Enums;

namespace API.RomanDate.Services.Interfaces
{
    public interface IRomanDateService : ITransient
    {
        CalendarDay GetCurrentDate();
        CalendarDay GetRomanDate(Eras era, int year, Months month, int day);
        IEnumerable<Months> GetRomanMonths();
    }
}
