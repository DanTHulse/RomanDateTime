using System;
using System.Collections.Generic;
using API.RomanDate.Services.Interfaces;
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
        public IEnumerable<object> GetAllMagistrates() => throw new NotImplementedException();
        public IEnumerable<object> GetAllMagistratesForOffice(Office office) => throw new NotImplementedException();
        public IEnumerable<object> GetMagistratesForYear(Eras era, int year) => throw new NotImplementedException();
        public IEnumerable<object> GetRulingMagistratesForYear(Eras era, int year) => throw new NotImplementedException();
        public IEnumerable<object> InsertMagistrateDataForYear(Eras era, int year, object data) => throw new NotImplementedException();
        public IEnumerable<object> UpdateMagistrateDataForYear(Eras era, int year, object data) => throw new NotImplementedException();
    }
}
