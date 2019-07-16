using API.RomanDate.Controllers;
using API.RomanDate.Mappings.Interfaces;
using API.RomanDate.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace API.RomanDate.Tests.Controllers
{
    [TestClass]
    public class DatesControllerTests
    {
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ICalendarService> _mockCalendarService = new Mock<ICalendarService>();

        private DatesController _sut;

        [TestInitialize]
        public void Init() => this._sut = new DatesController(this._mockMapper.Object, this._mockCalendarService.Object);
    }
}
