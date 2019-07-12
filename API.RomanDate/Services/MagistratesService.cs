using System;
using System.Collections.Generic;
using System.Linq;
using API.RomanDate.Helpers.Enum;
using API.RomanDate.Helpers.RomanDate;
using API.RomanDate.Models;
using API.RomanDate.Services.Interfaces;
using API.RomanDate.ViewModels;
using RomanDate.Definitions;
using RomanDate.Enums;
using static RomanDate.Definitions.RomanMagistrates;

namespace API.RomanDate.Services
{
    public class MagistratesService : IMagistratesService
    {
        private readonly IEnumerable<RomanMagistrates> _romanMagistrates;

        public MagistratesService()
        {
            this._romanMagistrates = GetAll();
        }

        public IEnumerable<MagistratesFull> GetAllMagistrates(Office office = Office.NotSet)
        {
            return (this._romanMagistrates
                .SelectMany(s => s.GetMagistrates(office)))
                .GroupBy(grp => grp.FullName)
                .Select(se => new MagistratesFull
                {
                    Name = se.Key,
                    ElectedOffices = se.Select(e => new ElectedOffice
                    {
                        Office = e.Office.GetDescription(),
                        YearElected = RomanDateHelpers.ConvertToCommonEraString(e.AucYear.GetValueOrDefault())
                    })
                }).ToList();
        }

        public IEnumerable<Magistrate>? GetMagistratesForYear(Eras era, int year)
        {
            var aucYear = RomanDateHelpers.ConvertToAucEra(era, year);
            return Get(aucYear).GetMagistrates(Office.NotSet);
        }

        public IEnumerable<Magistrate>? GetRulingMagistratesForYear(Eras era, int year)
        {
            var aucYear = RomanDateHelpers.ConvertToAucEra(era, year);
            return Get(aucYear).GetRulingMagistrates();
        }

        public IEnumerable<MagistrateViewModel> InsertMagistrateDataForYear(Eras era, int year, object data)
            => throw new NotImplementedException();

        public IEnumerable<MagistrateViewModel> UpdateMagistrateDataForYear(Eras era, int year, object data)
            => throw new NotImplementedException();
    }
}
