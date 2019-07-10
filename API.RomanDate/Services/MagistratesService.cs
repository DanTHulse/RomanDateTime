using System;
using System.Collections.Generic;
using System.Linq;
using API.RomanDate.Services.Interfaces;
using API.RomanDate.ViewModels;
using RomanDate.Definitions;
using RomanDate.Enums;

namespace API.RomanDate.Services
{
    public class MagistratesService : IMagistratesService
    {
        private readonly IEnumerable<RomanMagistrates> _romanMagistrates;

        public MagistratesService()
        {
            this._romanMagistrates = RomanMagistrates.GetAll();
        }

        // (Return year in which they served in each office)
        public IEnumerable<MagistrateViewModel> GetAllMagistrates()
        {
            var test = this._romanMagistrates.SelectMany(s => s.GetMagistrates(Office.NotSet).GroupBy(grp => grp.FullName));

            return new List<MagistrateViewModel>();
        }

        public IEnumerable<MagistrateViewModel> GetAllMagistratesForOffice(Office office) => throw new NotImplementedException();
        public IEnumerable<MagistrateViewModel> GetMagistratesForYear(Eras era, int year) => throw new NotImplementedException();
        public IEnumerable<MagistrateViewModel> GetRulingMagistratesForYear(Eras era, int year) => throw new NotImplementedException();
        public IEnumerable<MagistrateViewModel> InsertMagistrateDataForYear(Eras era, int year, object data) => throw new NotImplementedException();
        public IEnumerable<MagistrateViewModel> UpdateMagistrateDataForYear(Eras era, int year, object data) => throw new NotImplementedException();
    }
}
