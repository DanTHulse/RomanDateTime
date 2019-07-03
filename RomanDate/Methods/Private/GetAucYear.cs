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
        private string GetAucYear()
        {
            var auc = 753;
            var year = (auc += this.DateTimeData.Year);
            return year <= 0 ? "" : year.ToRomanNumerals();
        }
    }
}