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

        public RomanDateTime GetCurrentDate() => RomanDateTime.Now;

        public RomanDateTime GetRomanDate(Eras era, DateTime date) => new RomanDateTime(date, era);
    }
}