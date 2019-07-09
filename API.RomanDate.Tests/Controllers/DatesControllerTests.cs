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

        private DatesController _sut;

        [TestInitialize]
        public void Init() => this._sut = new DatesController(_mockMapper.Object, _mockRomanDateService.Object);

        [TestMethod]
        public void Current_ReturnsOk()
        {
            _mockRomanDateService.Setup(s => s.GetCurrentDate()).Returns(new RomanDateTime());
            _mockMapper.Setup(s => s.Map<RomanDateViewModel>(It.IsAny<object>())).Returns(new RomanDateViewModel());

            var result = _sut.Current();

            _mockRomanDateService.Verify(v => v.GetCurrentDate(), Times.Once);
            _mockMapper.Verify(v => v.Map<RomanDateViewModel>(It.IsAny<object>()), Times.Once);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Current_MappingIssue_ThrowsException()
        {
            _mockRomanDateService.Setup(s => s.GetCurrentDate()).Returns(new RomanDateTime());
            _mockMapper.Setup(s => s.Map<RomanDateViewModel>(It.IsAny<object>())).Returns((RomanDateViewModel)null);

            Assert.ThrowsException<ArgumentNullException>(() => _sut.Current());

            _mockRomanDateService.Verify(v => v.GetCurrentDate(), Times.Once);
            _mockMapper.Verify(v => v.Map<RomanDateViewModel>(It.IsAny<object>()), Times.Once);
        }

        [TestMethod]
        public void GetRomanDateTime_ReturnsOk()
        {
            _mockRomanDateService.Setup(s => s.GetRomanDate(It.IsAny<DateTime>(), It.IsAny<Eras>())).Returns(new RomanDateTime());
            _mockMapper.Setup(s => s.Map<RomanDateViewModel>(It.IsAny<object>())).Returns(new RomanDateViewModel());

            var result = _sut.GetRomanDateTime(It.IsAny<DateTime>(), It.IsAny<Eras>());

            _mockRomanDateService.Verify(v => v.GetRomanDate(It.IsAny<DateTime>(), It.IsAny<Eras>()), Times.Once);
            _mockMapper.Verify(v => v.Map<RomanDateViewModel>(It.IsAny<object>()), Times.Once);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetRomanDateTime_MappingIssue_ThrowsException()
        {
            _mockRomanDateService.Setup(s => s.GetRomanDate(It.IsAny<DateTime>(), It.IsAny<Eras>())).Returns(new RomanDateTime());
            _mockMapper.Setup(s => s.Map<RomanDateViewModel>(It.IsAny<object>())).Returns((RomanDateViewModel)null);

            Assert.ThrowsException<ArgumentNullException>(() => _sut.GetRomanDateTime(It.IsAny<DateTime>(), It.IsAny<Eras>()));

            _mockRomanDateService.Verify(v => v.GetRomanDate(It.IsAny<DateTime>(), It.IsAny<Eras>()), Times.Once);
            _mockMapper.Verify(v => v.Map<RomanDateViewModel>(It.IsAny<object>()), Times.Once);
        }
    }
}
