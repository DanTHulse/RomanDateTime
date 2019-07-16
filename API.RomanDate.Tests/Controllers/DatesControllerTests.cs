using System;
using API.RomanDate.Controllers;
using API.RomanDate.Mappings.Interfaces;
using API.RomanDate.Models.Calendar;
using API.RomanDate.Services.Interfaces;
using API.RomanDate.ViewModels.Calendar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace API.RomanDate.Tests.Controllers
{
    [TestClass]
    public class DatesControllerTests
    {
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<IRomanDateService> _mockRomanDateService = new Mock<IRomanDateService>();
        private readonly Mock<ICalendarService> _mockCalendarService = new Mock<ICalendarService>();

        private DatesController _sut;

        [TestInitialize]
        public void Init() => this._sut = new DatesController(this._mockMapper.Object, this._mockRomanDateService.Object, this._mockCalendarService.Object);

        [TestMethod]
        public void Current_ReturnsOk()
        {
            this._mockRomanDateService.Setup(s => s.GetCurrentDate()).Returns(new CalendarDay());
            this._mockMapper.Setup(s => s.Map<CalendarDayViewModel>(It.IsAny<object>())).Returns(new CalendarDayViewModel());

            var result = this._sut.Current();

            this._mockRomanDateService.Verify(v => v.GetCurrentDate(), Times.Once);
            this._mockMapper.Verify(v => v.Map<CalendarDayViewModel>(It.IsAny<object>()), Times.Once);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Current_MappingIssue_ThrowsException()
        {
            this._mockRomanDateService.Setup(s => s.GetCurrentDate()).Returns(new CalendarDay());
            this._mockMapper.Setup(s => s.Map<CalendarDayViewModel>(It.IsAny<object>())).Returns((CalendarDayViewModel)null);

            Assert.ThrowsException<ArgumentNullException>(() => this._sut.Current());

            this._mockRomanDateService.Verify(v => v.GetCurrentDate(), Times.Once);
            this._mockMapper.Verify(v => v.Map<CalendarDayViewModel>(It.IsAny<object>()), Times.Once);
        }
    }
}
