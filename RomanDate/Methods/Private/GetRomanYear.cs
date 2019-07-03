using System;
using System.Text;
using NodaTime;
using RomanDate.Definitions;
using RomanDate.Enums;
using RomanDate.Extensions;
using RomanDate.Helpers;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private string GetRomanYear()
        {
            return this.DateTimeData.YearOfEra.ToRomanNumerals();
        }
    }
}