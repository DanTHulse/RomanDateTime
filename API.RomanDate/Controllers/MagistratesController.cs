using System.Collections.Generic;
using API.RomanDate.Controllers.Base;
using API.RomanDate.Mappings.Interfaces;
using API.RomanDate.Services.Interfaces;
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
        public ActionResult<IEnumerable<object>> GetAllMagistrates()
        {
            var magistrates = this._magistratesService.GetAllMagistrates();

            return this.Ok(magistrates);
        }

        [HttpGet("{office}")]
        public ActionResult<IEnumerable<object>> GetAllMagistratesForOffice([FromRoute]Office office)
        {
            var magistrates = this._magistratesService.GetAllMagistratesForOffice(office);

            return this.Ok(magistrates);
        }

        [HttpGet("{era}/{year}")]
        public ActionResult<IEnumerable<object>> GetMagistratesForYear([FromRoute]Eras era, [FromRoute]int year)
        {
            var magistrates = this._magistratesService.GetMagistratesForYear(era, year);

            return this.Ok(magistrates);
        }

        [HttpGet("{era}/{year}/ruling")]
        public ActionResult<IEnumerable<object>> GetRulingMagistratesForYear([FromRoute]Eras era, [FromRoute]int year)
        {
            var magistrates = this._magistratesService.GetRulingMagistratesForYear(era, year);

            return this.Ok(magistrates);
        }

        [HttpPost("{era}/{year}")]
        public ActionResult<IEnumerable<object>> PostMagistrateDataForYear([FromRoute]Eras era, [FromRoute]int year, [FromBody]object data)
        {
            var magistrates = this._magistratesService.InsertMagistrateDataForYear(era, year, data);

            return this.Ok(magistrates);
        }

        [HttpPatch("{era}/{year}")]
        public ActionResult<IEnumerable<object>> UpdateMagistrateDataForYear([FromRoute]Eras era, [FromRoute]int year, [FromBody]object data)
        {
            var magistrates = this._magistratesService.UpdateMagistrateDataForYear(era, year, data);

            return this.Ok(magistrates);
        }
    }
}
