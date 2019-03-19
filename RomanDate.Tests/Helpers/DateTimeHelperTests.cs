using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Helpers;
using System;

namespace RomanDate.Tests.Helpers
{
    [TestClass]
    public class DateTimeHelperTests
    {
        [TestMethod]
        public void StartOfMonth_ReturnsTheStartOfTheMonth()
        {
            var date = new DateTime(2019, 1, 23, 12, 44, 19); // January 23rd 2019 - 12:44.19

            var newDate = date.StartOfMonth();

            var expectedDate = new DateTime(2019, 1, 1, 0, 0, 0); // January 1st 2019 - 00:00.00
            Assert.AreEqual(expectedDate, newDate);
        }

        [TestMethod]
        public void TimeAsFraction_ReturnsTimeAsAFractionOfHour()
        {
            var date = new DateTime(2019, 12, 31, 12, 44, 19); // December 31st 2019 - 12:44.19
            var fraction = date.TimeAsFraction();

            Assert.AreEqual(12.73, fraction);
        }

        [TestMethod]
        public void IsLeapYear_ReturnsTrueIfLeapYear()
        {
            var date = new DateTime(2020, 1, 23, 12, 44, 19); // January 23rd 2020 - 12:44.19

            Assert.IsTrue(date.IsLeapYear());
        }

        [TestMethod]
        public void IsLeapYear_ReturnsFalseIfNotLeapYear()
        {
            var date = new DateTime(2019, 1, 23, 12, 44, 19); // January 23rd 2019 - 12:44.19

            Assert.IsFalse(date.IsLeapYear());
        }
    }
}
