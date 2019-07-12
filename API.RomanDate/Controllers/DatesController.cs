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
        private readonly ICalendarService _calendarService;

        public DatesController(IMapper mapper,
            IRomanDateService romanDateService,
            ICalendarService calendarService)
            : base(mapper)
        {
            this._romanDateService = romanDateService;
            this._calendarService = calendarService;
        }

        [HttpGet("current")]
        public ActionResult<RomanDateViewModel> Current()
        {
            var romanDate = this._romanDateService.GetCurrentDate();

            return this.Ok<RomanDateViewModel>(romanDate);
        }

        [HttpGet("{era}/{date}")]
        public ActionResult<RomanDateViewModel> GetRomanDateTime([FromRoute]Eras era, [FromRoute]DateTime date)
        {
            var romanDate = this._romanDateService.GetRomanDate(era, date);

            return this.Ok<RomanDateViewModel>(romanDate);
        }

        [HttpGet("calendar/{era}/{year}/{month}")]
        public ActionResult<CalendarViewModel> GetCalendarMonth([FromRoute]Eras era, [FromRoute]int year, [FromRoute]Months month)
        {
            var calendarMonth = this._calendarService.ReturnCalendarMonth(era, year, month);

            return this.Ok<CalendarViewModel>(calendarMonth);
        }
    }
}
