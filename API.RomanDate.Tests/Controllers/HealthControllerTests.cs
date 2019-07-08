using API.RomanDate.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API.RomanDate.Tests.Controllers
{
    [TestClass]
    public class HealthControllerTests
    {
        private HealthController _sut;

        [TestInitialize]
        public void Init()
        {
            _sut = new HealthController();
        }

        [TestMethod]
        public void Ping_ReturnsOk()
        {
            var result = _sut.Ping();

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }
    }
}
