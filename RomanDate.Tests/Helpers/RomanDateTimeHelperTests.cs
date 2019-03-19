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
            var nextFromKalendae = new RomanDateTime(2019, 1, 2).NextSetDay();
            var nextFromNonae = new RomanDateTime(2019, 1, 6).NextSetDay();
            var nextFromIdus = new RomanDateTime(2019, 1, 16).NextSetDay();

            Assert.AreEqual(new DateTime(2019, 1, 5), nextFromKalendae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 1, 13), nextFromNonae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 2, 1), nextFromIdus.ToDateTime());
        }

        [TestMethod]
        public void ToNextSetDay_ReturnsNextSpecifiedSetDay()
        {
            var nextKalendae = new RomanDateTime(2019, 1, 1).NextSetDay(SetDays.Kalendae);
            var nextNonae = new RomanDateTime(2019, 1, 5).NextSetDay(SetDays.Nonae);
            var nextIdus = new RomanDateTime(2019, 1, 13).NextSetDay(SetDays.Idus);
            var nextIdusFromKalendae = new RomanDateTime(2019, 1, 1).NextSetDay(SetDays.Idus);
            var nextKalendaeFromNonae = new RomanDateTime(2019, 1, 5).NextSetDay(SetDays.Kalendae);
            var nextNonaeFromIdus = new RomanDateTime(2019, 1, 13).NextSetDay(SetDays.Nonae);

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
            var prevFromKalendae = new RomanDateTime(2019, 1, 17).PreviousSetDay();
            var prevFromNonae = new RomanDateTime(2019, 1, 4).PreviousSetDay();
            var prevFromIdus = new RomanDateTime(2019, 1, 12).PreviousSetDay();

            Assert.AreEqual(new DateTime(2019, 1, 13), prevFromKalendae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 1, 1), prevFromNonae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 1, 5), prevFromIdus.ToDateTime());
        }

        [TestMethod]
        public void ToPreviousSetDay_ReturnsPreviousSpecifiedSetDay()
        {
            var prevKalendae = new RomanDateTime(2019, 1, 17).PreviousSetDay(SetDays.Kalendae);
            var prevNonae = new RomanDateTime(2019, 1, 2).PreviousSetDay(SetDays.Nonae);
            var prevIdus = new RomanDateTime(2019, 1, 12).PreviousSetDay(SetDays.Idus);
            var prevNonaeFromKalendae = new RomanDateTime(2019, 1, 16).PreviousSetDay(SetDays.Nonae);
            var prevIdusFromNonae = new RomanDateTime(2019, 1, 4).PreviousSetDay(SetDays.Idus);
            var prevKalendaeFromIdus = new RomanDateTime(2019, 1, 12).PreviousSetDay(SetDays.Kalendae);

            Assert.AreEqual(new DateTime(2019, 1, 1), prevKalendae.ToDateTime());
            Assert.AreEqual(new DateTime(2018, 12, 5), prevNonae.ToDateTime());
            Assert.AreEqual(new DateTime(2018, 12, 13), prevIdus.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 1, 5), prevNonaeFromKalendae.ToDateTime());
            Assert.AreEqual(new DateTime(2018, 12, 13), prevIdusFromNonae.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 1, 1), prevKalendaeFromIdus.ToDateTime());
        }

        [TestMethod]
        public void ToNextSetDay_RoundTrip()
        {
            var kalRoundNext = new RomanDateTime(2019, 2, 1).NextSetDay().NextSetDay().NextSetDay();
            var nonRoundNext = new RomanDateTime(2019, 2, 5).NextSetDay().NextSetDay().NextSetDay();
            var idusRoundNext = new RomanDateTime(2019, 2, 13).NextSetDay().NextSetDay().NextSetDay();

            Assert.AreEqual(new DateTime(2019, 3, 1), kalRoundNext.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 3, 7), nonRoundNext.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 3, 15), idusRoundNext.ToDateTime());
        }

        [TestMethod]
        public void ToPreviousSetDay_RoundTrip()
        {
            var kalRoundPrev = new RomanDateTime(2019, 3, 1).PreviousSetDay().PreviousSetDay().PreviousSetDay();
            var nonRoundPrev = new RomanDateTime(2019, 3, 7).PreviousSetDay().PreviousSetDay().PreviousSetDay();
            var idusRoundPrev = new RomanDateTime(2019, 3, 15).PreviousSetDay().PreviousSetDay().PreviousSetDay();

            Assert.AreEqual(new DateTime(2019, 2, 1), kalRoundPrev.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 2, 5), nonRoundPrev.ToDateTime());
            Assert.AreEqual(new DateTime(2019, 2, 13), idusRoundPrev.ToDateTime());
        }
    }
}