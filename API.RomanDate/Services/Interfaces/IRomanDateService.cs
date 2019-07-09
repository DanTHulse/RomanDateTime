using RomanDate;

namespace API.RomanDate.Services.Interfaces
{
    public interface IRomanDateService : IService
    {
        RomanDateTime GetCurrentDate(bool aucEra = false);
    }
}
