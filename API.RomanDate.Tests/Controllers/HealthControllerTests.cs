using API.RomanDate.Controllers.Base;
using API.RomanDate.Mappings.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace API.RomanDate.Tests.Controllers
{
    [TestClass]
    public class HealthControllerTests
    {
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private HealthController _sut;

        [TestInitialize]
        public void Init() => this._sut = new HealthController(this._mockMapper.Object);

        [TestMethod]
        public void Ping_ReturnsOk()
        {
            var result = this._sut.Ping();

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }
    }
}
