using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;
using RomanDate.Helpers;
namespace RomanDate.Tests.Helpers
{
    [TestClass]
    public class RomanDateTimeHelperTests
    {
        [TestMethod]
        public void IsNundinae_ReturnsTrueIfMarketDay()
        {
            var result = new RomanDateTime(2018, 1, 15); // Market day for 2018 is H

            Assert.IsTrue(result.IsNundinae());
        }

        [TestMethod]
        public void IsNundinae_ReturnsDalseIfNotMarketDay()
        {
            var result = new RomanDateTime(2018, 1, 8); // Market day for 2018 is H

            Assert.IsFalse(result.IsNundinae());
        }

        [TestMethod]
        public void ToNextSetDay_ReturnsNextSetDay()
        {
            var nextFromKalendae = new RomanDateTime(2019, 1, 2).ToNextSetDay();
            var nextFromNonae = new RomanDateTime(2019, 1, 6).ToNextSetDay();
            var nextFromIdus = new RomanDateTime(2019, 1, 16).ToNextSetDay();

            Assert.AreEqual(new DateTime(2019, 1, 5), nextFromKalendae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 1, 13), nextFromNonae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 2, 1), nextFromIdus.ToDateTime());
        }

        [TestMethod]
        public void ToNextSetDay_ReturnsNextSpecifiedSetDay()
        {
            var nextKalendae = new RomanDateTime(2019, 1, 1).ToNextSetDay(SetDays.Kalendae);
            var nextNonae = new RomanDateTime(2019, 1, 5).ToNextSetDay(SetDays.Nonae);
            var nextIdus = new RomanDateTime(2019, 1, 13).ToNextSetDay(SetDays.Idus);
            var nextIdusFromKalendae = new RomanDateTime(2019, 1, 1).ToNextSetDay(SetDays.Idus);
            var nextKalendaeFromNonae = new RomanDateTime(2019, 1, 5).ToNextSetDay(SetDays.Kalendae);
            var nextNonaeFromIdus = new RomanDateTime(2019, 1, 13).ToNextSetDay(SetDays.Nonae);

            Assert.AreEqual(new DateTime(2019, 2, 1), nextKalendae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 2, 5), nextNonae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 2, 13), nextIdus.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 1, 13), nextIdusFromKalendae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 2, 1), nextKalendaeFromNonae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 2, 5), nextNonaeFromIdus.ToDateTime());
        }

        [TestMethod]
        public void ToPreviousSetDay_ReturnsPreviousSetDay()
        {
            var prevFromKalendae = new RomanDateTime(2019, 1, 17).ToPreviousSetDay();
            var prevFromNonae = new RomanDateTime(2019, 1, 4).ToPreviousSetDay();
            var prevFromIdus = new RomanDateTime(2019, 1, 12).ToPreviousSetDay();

            Assert.AreEqual(new DateTime(2019, 1, 13), prevFromKalendae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 1, 1), prevFromNonae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 1, 5), prevFromIdus.ToDateTime());
        }

        [TestMethod]
        public void ToPreviousSetDay_ReturnsPreviousSpecifiedSetDay()
        {
            var prevKalendae = new RomanDateTime(2019, 1, 17).ToPreviousSetDay(SetDays.Kalendae);
            var prevNonae = new RomanDateTime(2019, 1, 2).ToPreviousSetDay(SetDays.Nonae);
            var prevIdus = new RomanDateTime(2019, 1, 12).ToPreviousSetDay(SetDays.Idus);
            var prevNonaeFromKalendae = new RomanDateTime(2019, 1, 16).ToPreviousSetDay(SetDays.Nonae);
            var prevIdusFromNonae = new RomanDateTime(2019, 1, 4).ToPreviousSetDay(SetDays.Idus);
            var prevKalendaeFromIdus = new RomanDateTime(2019, 1, 12).ToPreviousSetDay(SetDays.Kalendae);

            Assert.AreEqual(new DateTime(2019, 1, 1), prevKalendae.ToDateTime());
            Assert.AreEqual(new DateTime(2018, 12, 5), prevNonae.ToDateTime());
            Assert.AreEqual(new DateTime(2018, 12, 13), prevIdus.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 1, 5), prevNonaeFromKalendae.ToDateTime());
            Assert.AreEqual(new DateTime(2018, 12, 13), prevIdusFromNonae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 1, 1), prevKalendaeFromIdus.ToDateTime());
        }
    }
}