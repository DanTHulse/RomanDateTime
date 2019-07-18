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
        private readonly ICalendarService _calendarService;

        public DatesController(IMapper mapper,
            ICalendarService calendarService)
            : base(mapper)
        {
            this._calendarService = calendarService;
        }

        [HttpGet("current")]
        public ActionResult<CalendarDayViewModel> Current()
        {
            var current = this._calendarService.ReturnCurrentDate();

            return this.Ok<CalendarDayViewModel>(current);
        }

        [HttpGet("{era}/{year}")]
        public ActionResult<CalendarYearViewModel> GetCalendarYear([FromRoute]Eras era, [FromRoute]int year)
        {
            var calendarYear = this._calendarService.ReturnCalendarYear(era, year);

            return this.Ok<CalendarYearViewModel>(calendarYear);
        }

        [HttpGet("{era}/{year}/{month}")]
        public ActionResult<CalendarMonthViewModel> GetCalendarMonth([FromRoute]Eras era, [FromRoute]int year, [FromRoute]Months month)
        {
            var calendarMonth = this._calendarService.ReturnCalendarMonth(era, year, month);

            return this.Ok<CalendarMonthViewModel>(calendarMonth);
        }

        [HttpGet("{era}/{year}/{month}/{day}")]
        public ActionResult<CalendarDayViewModel> GetCalendarDay([FromRoute]Eras era, [FromRoute]int year, [FromRoute]Months month, [FromRoute]int day)
        {
            var romanDate = this._calendarService.ReturnCalendarDay(era, year, month, day);

            return this.Ok<CalendarDayViewModel>(romanDate);
        }
    }
}
