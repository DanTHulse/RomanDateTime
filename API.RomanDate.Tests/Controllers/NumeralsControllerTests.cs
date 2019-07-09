using API.RomanDate.Controllers;
using API.RomanDate.Mappings.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace API.RomanDate.Tests.Controllers
{
    [TestClass]
    public class NumeralsControllerTests
    {
        private Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private NumeralsController _sut;

        [TestInitialize]
        public void Init()
        {
            _sut = new NumeralsController(_mockMapper.Object);
        }

        [TestMethod]
        public void ConvertToNumerals_ValidNumber_ReturnsOk()
        {
            var result = _sut.ConvertToNumerals(1991);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void ConvertToNumerals_LessThan1_ReturnsBadRequest()
        {
            var result = _sut.ConvertToNumerals(-190);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void ConvertToNumerals_GreaterThan9999_ReturnsBadRequest()
        {
            var result = _sut.ConvertToNumerals(10000);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void ConvertFromNumerals_ValidNumerals_ReturnsOk()
        {
            var result = _sut.ConvertFromNumerals("MCMXCI");

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void ConvertFromNumerals_EmptyString_ReturnsBadRequest()
        {
            var result = _sut.ConvertFromNumerals("");

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void ConvertFromNumerals_InvalidString_ReturnsBadRequest()
        {
            var result = _sut.ConvertFromNumerals("MCTR");

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }
    }
}
