using API.RomanDate.Infrastructure.IoC;
using RomanDate.Enums;

namespace API.RomanDate.Services.Interfaces
{
    public interface INavigationService : ITransient
    {
        string NextYear(Eras era, int year);
        string PrevYear(Eras era, int year);
        string NextMonth(Eras era, int year, Months month);
        string PrevMonth(Eras era, int year, Months month);
        string NextDay(Eras era, int year, Months month, int day);
        string PrevDay(Eras era, int year, Months month, int day);
        string YearRef(Eras era, int year);
        string MonthRef(Eras era, int year, Months month);
        string DayRef(Eras era, int year, Months month, int day);
    }
}
