using System;
using API.RomanDate.Helpers;
using API.RomanDate.ViewModels;
using RomanDate.Enums;

namespace API.RomanDate.Mappings.Profiles
{
    public class RomanMonthsMapping : ModelMapper<Months, RomanMonthViewModel>
    {
        public RomanMonthsMapping()
        {
            RegisterMap(dest => dest.Number, src => (int)src);
            RegisterMap(dest => dest.Name, src => new DateTime(1, (int)src, 1).ToString("MMMM"));
            RegisterMap(dest => dest.ShortName, src => new DateTime(1, (int)src, 1).ToString("MMM"));
            RegisterMap(dest => dest.LatinName, src => src.ToString());
            RegisterMap(dest => dest.ShortLatinName, src => src.ToString().Left(3));
        }
    }
}
