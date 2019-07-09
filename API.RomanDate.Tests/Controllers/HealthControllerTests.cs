using API.RomanDate.Controllers;
using API.RomanDate.Mappings.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace API.RomanDate.Tests.Controllers
{
    [TestClass]
    public class HealthControllerTests
    {
        private Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private HealthController _sut;

        [TestInitialize]
        public void Init()
        {
            _sut = new HealthController(_mockMapper.Object);
        }

        [TestMethod]
        public void Ping_ReturnsOk()
        {
            var result = _sut.Ping();

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }
    }
}
