using System;
using API.RomanDate.Controllers.Base;
using API.RomanDate.Mappings.Interfaces;
using API.RomanDate.Services.Interfaces;
using API.RomanDate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IRomanDateService _romanDateService;

        public DatesController(IMapper mapper,
            IRomanDateService romanDateService)
        {
            this._mapper = mapper;
            this._romanDateService = romanDateService;
        }

        [HttpGet("current")]
        public ActionResult<RomanDateViewModel> Current()
        {
            var date = this._romanDateService.GetCurrentDate();
            var mapped = this._mapper.Map<RomanDateViewModel>(date);

            return this.Ok(mapped);
        }

        [HttpGet()]
        public ActionResult<object> GetRomanDateTime([FromQuery]DateTime? date = null)
        {
            return this.Ok();
        }
    }
}
