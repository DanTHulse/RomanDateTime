using System.Collections.Generic;
using System.Linq;
using API.RomanDate.Controllers.Base;
using API.RomanDate.Mappings.Interfaces;
using API.RomanDate.Services.Interfaces;
using API.RomanDate.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RomanDate.Enums;

namespace API.RomanDate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MagistratesController : BaseController
    {
        private readonly IMagistratesService _magistratesService;

        public MagistratesController(IMapper mapper,
            IMagistratesService magistratesService)
            : base(mapper)
        {
            this._magistratesService = magistratesService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<MagistrateViewModel>> GetAllMagistrates()
        {
            var magistrates = this._magistratesService.GetAllMagistrates();

            return this.Ok<MagistrateViewModel>(magistrates);
        }

        [HttpGet("{office}")]
        public ActionResult<IEnumerable<MagistrateViewModel>> GetAllMagistratesForOffice([FromRoute]Office office)
        {
            var magistrates = this._magistratesService.GetAllMagistrates(office);

            return this.Ok<MagistrateViewModel>(magistrates);
        }

        [HttpGet("{era}/{year}")]
        public ActionResult<IEnumerable<MagistrateViewModel>> GetMagistratesForYear([FromRoute]Eras era, [FromRoute]int year)
        {
            var magistrates = this._magistratesService.GetMagistratesForYear(era, year);

            if (magistrates != null && magistrates.Any())
                return this.Ok<MagistrateSimpleViewModel>(magistrates);
            else if (magistrates == null)
                return this.NotFound($"No Magistrate data found for the year: {year} {era}");
            else
                return this.NoContent();
        }

        [HttpGet("ruling/{era}/{year}")]
        public ActionResult<IEnumerable<MagistrateViewModel>> GetRulingMagistratesForYear([FromRoute]Eras era, [FromRoute]int year)
        {
            var magistrates = this._magistratesService.GetRulingMagistratesForYear(era, year);

            if (magistrates != null && magistrates.Any())
                return this.Ok<MagistrateSimpleViewModel>(magistrates);
            else if (magistrates == null)
                return this.NotFound($"No Magistrate data found for the year: {year} {era}");
            else
                return this.NoContent();
        }

        [HttpPost("{era}/{year}")]
        public ActionResult<IEnumerable<MagistrateViewModel>> PostMagistrateDataForYear([FromRoute]Eras era, [FromRoute]int year, [FromBody]object data)
        {
            var magistrates = this._magistratesService.InsertMagistrateDataForYear(era, year, data);

            return this.Ok<MagistrateViewModel>(magistrates);
        }

        [HttpPatch("{era}/{year}")]
        public ActionResult<IEnumerable<MagistrateViewModel>> UpdateMagistrateDataForYear([FromRoute]Eras era, [FromRoute]int year, [FromBody]object data)
        {
            var magistrates = this._magistratesService.UpdateMagistrateDataForYear(era, year, data);

            return this.Ok<MagistrateViewModel>(magistrates);
        }
    }
}
