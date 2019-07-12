using System;
using API.RomanDate.Controllers;
using API.RomanDate.Mappings.Interfaces;
using API.RomanDate.Services.Interfaces;
using API.RomanDate.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RomanDate;
using RomanDate.Enums;

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
            this._mockRomanDateService.Setup(s => s.GetCurrentDate()).Returns(new RomanDateTime());
            this._mockMapper.Setup(s => s.Map<RomanDateViewModel>(It.IsAny<object>())).Returns(new RomanDateViewModel());

            var result = this._sut.Current();

            this._mockRomanDateService.Verify(v => v.GetCurrentDate(), Times.Once);
            this._mockMapper.Verify(v => v.Map<RomanDateViewModel>(It.IsAny<object>()), Times.Once);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Current_MappingIssue_ThrowsException()
        {
            this._mockRomanDateService.Setup(s => s.GetCurrentDate()).Returns(new RomanDateTime());
            this._mockMapper.Setup(s => s.Map<RomanDateViewModel>(It.IsAny<object>())).Returns((RomanDateViewModel)null);

            Assert.ThrowsException<ArgumentNullException>(() => this._sut.Current());

            this._mockRomanDateService.Verify(v => v.GetCurrentDate(), Times.Once);
            this._mockMapper.Verify(v => v.Map<RomanDateViewModel>(It.IsAny<object>()), Times.Once);
        }

        [TestMethod]
        public void GetRomanDateTime_ReturnsOk()
        {
            this._mockRomanDateService.Setup(s => s.GetRomanDate(It.IsAny<Eras>(), It.IsAny<DateTime>())).Returns(new RomanDateTime());
            this._mockMapper.Setup(s => s.Map<RomanDateViewModel>(It.IsAny<object>())).Returns(new RomanDateViewModel());

            var result = this._sut.GetRomanDateTime(It.IsAny<Eras>(), It.IsAny<DateTime>());

            this._mockRomanDateService.Verify(v => v.GetRomanDate(It.IsAny<Eras>(), It.IsAny<DateTime>()), Times.Once);
            this._mockMapper.Verify(v => v.Map<RomanDateViewModel>(It.IsAny<object>()), Times.Once);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetRomanDateTime_MappingIssue_ThrowsException()
        {
            this._mockRomanDateService.Setup(s => s.GetRomanDate(It.IsAny<Eras>(), It.IsAny<DateTime>())).Returns(new RomanDateTime());
            this._mockMapper.Setup(s => s.Map<RomanDateViewModel>(It.IsAny<object>())).Returns((RomanDateViewModel)null);

            Assert.ThrowsException<ArgumentNullException>(() => this._sut.GetRomanDateTime(It.IsAny<Eras>(), It.IsAny<DateTime>()));

            this._mockRomanDateService.Verify(v => v.GetRomanDate(It.IsAny<Eras>(), It.IsAny<DateTime>()), Times.Once);
            this._mockMapper.Verify(v => v.Map<RomanDateViewModel>(It.IsAny<object>()), Times.Once);
        }
    }
}
