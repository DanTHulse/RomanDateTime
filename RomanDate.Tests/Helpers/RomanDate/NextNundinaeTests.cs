using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Helpers.RomanDate;

namespace RomanDate.Tests.Helpers.RomanDate
{
    public partial class RomanDateTimeHelperTests
    {
        [TestMethod]
        public void ToNextNundinae_ReturnsNextMarketDayInWeek()
        {
            var date = new RomanDateTime(2018, 1, 16).NextNundinae(); // Market day for 2018 is B

            var expected = new RomanDateTime(2018, 1, 17);

            Assert.AreEqual(expected, date);
        }

        [TestMethod]
        public void ToNextNundinae_ReturnsNextMarketDayNextWeek()
        {
            var date = new RomanDateTime(2018, 1, 18).NextNundinae(); // Market day for 2018 is B

            var expected = new RomanDateTime(2018, 1, 25);

            Assert.AreEqual(expected, date);
        }

        [TestMethod]
        public void ToNextNundinae_ReturnsNextMarketDayOnMarketDay()
        {
            var date = new RomanDateTime(2018, 1, 17).NextNundinae(); // Market day for 2018 is B

            var expected = new RomanDateTime(2018, 1, 25);

            Assert.AreEqual(expected, date);
        }
    }
}