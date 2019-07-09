using System;
using API.RomanDate.Services.Interfaces;
using RomanDate;
using RomanDate.Enums;

namespace API.RomanDate.Services
{
    public class RomanDateService : IRomanDateService
    {
        public RomanDateService()
        {

        }

        public RomanDateTime GetCurrentDate(bool aucEra = false) => RomanDateTime.Now;

        public RomanDateTime GetRomanDate(DateTime date, Eras era) => new RomanDateTime(date, era);
    }
}