using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;
using RomanDate.Helpers;

namespace RomanDate.Tests.Helpers
{
    public partial class RomanDateTimeHelperTests
    {
        [TestMethod]
        public void ToPreviousNundinae_ReturnsPreviousMarketDayInWeek()
        {
            var date = new RomanDateTime(2018, 1, 18).PreviousNundinae(); // Market day for 2018 is B

            var expected = new RomanDateTime(2018, 1, 17);

            Assert.AreEqual(expected, date);
        }

        [TestMethod]
        public void ToPreviousNundinae_ReturnsPreviousMarketDayPreviousWeek()
        {
            var date = new RomanDateTime(2018, 1, 16).PreviousNundinae(); // Market day for 2018 is B

            var expected = new RomanDateTime(2018, 1, 9);

            Assert.AreEqual(expected, date);
        }

        [TestMethod]
        public void ToPreviousNundinae_ReturnsPreviousMarketDayOnMarketDay()
        {
            var date = new RomanDateTime(2018, 1, 17).PreviousNundinae(); // Market day for 2018 is B

            var expected = new RomanDateTime(2018, 1, 9);

            Assert.AreEqual(expected, date);
        }
    }
}