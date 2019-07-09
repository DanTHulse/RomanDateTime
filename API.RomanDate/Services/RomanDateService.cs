using API.RomanDate.Services.Interfaces;
using RomanDate;

namespace API.RomanDate.Services
{
    public class RomanDateService : IRomanDateService
    {
        public RomanDateService()
        {
            
        }

        public RomanDateTime GetCurrentDate(bool aucEra = false) => RomanDateTime.Now;
    }
}