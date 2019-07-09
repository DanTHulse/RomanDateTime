using System;
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
    public class DatesController : BaseController
    {
        private readonly IRomanDateService _romanDateService;

        public DatesController(IMapper mapper,
            IRomanDateService romanDateService)
            : base(mapper)
        {
            this._romanDateService = romanDateService;
        }

        [HttpGet("current")]
        public ActionResult<RomanDateViewModel> Current()
        {
            var romanDate = this._romanDateService.GetCurrentDate();

            return this.Ok<RomanDateViewModel>(romanDate);
        }

        [HttpGet("{date}")]
        public ActionResult<RomanDateViewModel> GetRomanDateTime([FromRoute]DateTime date, [FromQuery]Eras era = Eras.AD)
        {
            var romanDate = this._romanDateService.GetRomanDate(date, era);

            return this.Ok<RomanDateViewModel>(romanDate);
        }
    }
}
