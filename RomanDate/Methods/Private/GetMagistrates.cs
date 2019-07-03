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
        private ElectedMagistrates GetMagistrates()
        {
            if (this.ConsularData != null)
            {
                return new ElectedMagistrates(this.ConsularData);
            }

            return null;
        }
    }
}