using System.Collections.Generic;
using API.RomanDate.Controllers.Base;
using API.RomanDate.Mappings.Interfaces;
using API.RomanDate.Services.Interfaces;
using API.RomanDate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.RomanDate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthsController : BaseController
    {
        private readonly IRomanDateService _romanDateService;

        public MonthsController(IMapper mapper,
            IRomanDateService romanDateService)
            : base(mapper)
        {
            this._romanDateService = romanDateService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<RomanMonthViewModel>> GetRomanMonths()
        {
            var months = this._romanDateService.GetRomanMonths();

            return this.Ok<IEnumerable<RomanMonthViewModel>>(months);
        }
    }
}
