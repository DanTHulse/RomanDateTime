using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;
using RomanDate.Helpers.RomanDate;

namespace RomanDate.Tests.Helpers.RomanDate
{
    public partial class RomanDateTimeHelperTests
    {
        [TestMethod]
        public void IsNundinae_ReturnsTrueIfMarketDay()
        {
            var result = new RomanDateTime(2018, 1, 17); // Market day for 2018 is B

            Assert.IsTrue(result.IsNundinae());
        }

        [TestMethod]
        public void IsNundinae_ReturnsDalseIfNotMarketDay()
        {
            var result = new RomanDateTime(2018, 1, 8); // Market day for 2018 is B

            Assert.IsFalse(result.IsNundinae());
        }

        [TestMethod]
        public void IsNundinae_ReturnsTrueIfMarketDayInBCEra()
        {
            var result = new RomanDateTime(45, 1, 21, Eras.BC); // Market day for 45 is A

            Assert.IsTrue(result.IsNundinae());
        }

        [TestMethod]
        public void IsNundinae_ReturnsDalseIfNotMarketDayInBCEra()
        {
            var result = new RomanDateTime(45, 1, 8, Eras.BC); // Market day for 45 is A

            Assert.IsFalse(result.IsNundinae());
        }
    }
}