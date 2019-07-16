using System;
using API.RomanDate.Controllers.Base;
using API.RomanDate.Mappings.Interfaces;
using API.RomanDate.Services.Interfaces;
using API.RomanDate.ViewModels.Calendar;
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
        public ActionResult<CalendarDayViewModel> Current()
        {
            var romanDate = this._romanDateService.GetCurrentDate();

            return this.Ok<CalendarDayViewModel>(romanDate);
        }

        [HttpGet("{era}/{year}")]
        public ActionResult<CalendarYearViewModel> GetCalendarYear([FromRoute]Eras era, [FromRoute]int year) => throw new NotImplementedException();

        [HttpGet("{era}/{year}/{month}")]
        public ActionResult<CalendarMonthViewModel> GetCalendarMonth([FromRoute]Eras era, [FromRoute]int year, [FromRoute]Months month)
        {
            var calendarMonth = this._calendarService.ReturnCalendarMonth(era, year, month);

            return this.Ok<CalendarMonthViewModel>(calendarMonth);
        }

        [HttpGet("{era}/{year}/{month}/{day}")]
        public ActionResult<CalendarDayViewModel> GetCalendarDay([FromRoute]Eras era, [FromRoute]int year, [FromRoute]Months month, [FromRoute]int day)
        {
            var romanDate = this._romanDateService.GetRomanDate(era, year, month, day);

            return this.Ok<CalendarDayViewModel>(romanDate);
        }
    }
}
