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

        [TestMethod]
        public void ToNextSetDay_ReturnsNextSetDay()
        {
            var nextFromKalendae = new RomanDateTime(2019, 1, 2).NextSetDay();
            var nextFromNonae = new RomanDateTime(2019, 1, 6).NextSetDay();
            var nextFromIdus = new RomanDateTime(2019, 1, 16).NextSetDay();

            Assert.AreEqual(new DateTime(2019, 1, 5), nextFromKalendae.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 1, 13), nextFromNonae.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 2, 1), nextFromIdus.ToDateTime().DateTime);
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

            Assert.AreEqual(new DateTime(2019, 2, 1), nextKalendae.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 2, 5), nextNonae.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 2, 13), nextIdus.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 1, 13), nextIdusFromKalendae.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 2, 1), nextKalendaeFromNonae.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 2, 5), nextNonaeFromIdus.ToDateTime().DateTime);
        }

        [TestMethod]
        public void ToPreviousSetDay_ReturnsPreviousSetDay()
        {
            var prevFromKalendae = new RomanDateTime(2019, 1, 17).PreviousSetDay();
            var prevFromNonae = new RomanDateTime(2019, 1, 4).PreviousSetDay();
            var prevFromIdus = new RomanDateTime(2019, 1, 12).PreviousSetDay();

            Assert.AreEqual(new DateTime(2019, 1, 13), prevFromKalendae.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 1, 1), prevFromNonae.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 1, 5), prevFromIdus.ToDateTime().DateTime);
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

            Assert.AreEqual(new DateTime(2019, 1, 1), prevKalendae.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2018, 12, 5), prevNonae.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2018, 12, 13), prevIdus.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 1, 5), prevNonaeFromKalendae.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2018, 12, 13), prevIdusFromNonae.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 1, 1), prevKalendaeFromIdus.ToDateTime().DateTime);
        }

        [TestMethod]
        public void ToNextSetDay_RoundTrip()
        {
            var kalRoundNext = new RomanDateTime(2019, 2, 1).NextSetDay().NextSetDay().NextSetDay();
            var nonRoundNext = new RomanDateTime(2019, 2, 5).NextSetDay().NextSetDay().NextSetDay();
            var idusRoundNext = new RomanDateTime(2019, 2, 13).NextSetDay().NextSetDay().NextSetDay();

            Assert.AreEqual(new DateTime(2019, 3, 1), kalRoundNext.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 3, 7), nonRoundNext.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 3, 15), idusRoundNext.ToDateTime().DateTime);
        }

        [TestMethod]
        public void ToPreviousSetDay_RoundTrip()
        {
            var kalRoundPrev = new RomanDateTime(2019, 3, 1).PreviousSetDay().PreviousSetDay().PreviousSetDay();
            var nonRoundPrev = new RomanDateTime(2019, 3, 7).PreviousSetDay().PreviousSetDay().PreviousSetDay();
            var idusRoundPrev = new RomanDateTime(2019, 3, 15).PreviousSetDay().PreviousSetDay().PreviousSetDay();

            Assert.AreEqual(new DateTime(2019, 2, 1), kalRoundPrev.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 2, 5), nonRoundPrev.ToDateTime().DateTime);
            Assert.AreEqual(new DateTime(2019, 2, 13), idusRoundPrev.ToDateTime().DateTime);
        }

        [TestMethod]
        public void ToNextDay_CorrectlyCrossesToADEra()
        {
            var kalNext = new RomanDateTime(1, 12, 1, Eras.BC).NextSetDay(SetDays.Kalendae);
            var nonNext = new RomanDateTime(1, 12, 5, Eras.BC).NextSetDay(SetDays.Nonae);
            var idusNext = new RomanDateTime(1, 12, 13, Eras.BC).NextSetDay(SetDays.Idus);

            Assert.AreEqual(new DateTime(1, 1, 1), kalNext.ToDateTime().DateTime);
            Assert.AreEqual(Eras.AD, kalNext.ToDateTime().Era);
            Assert.AreEqual(new DateTime(1, 1, 5), nonNext.ToDateTime().DateTime);
            Assert.AreEqual(Eras.AD, nonNext.ToDateTime().Era);
            Assert.AreEqual(new DateTime(1, 1, 13), idusNext.ToDateTime().DateTime);
            Assert.AreEqual(Eras.AD, idusNext.ToDateTime().Era);
        }

        [TestMethod]
        public void ToPreviousSetDay_CorrectlyCrossesToBCEra()
        {
            var kalNext = new RomanDateTime(1, 1, 1).PreviousSetDay(SetDays.Kalendae);
            var nonNext = new RomanDateTime(1, 1, 5).PreviousSetDay(SetDays.Nonae);
            var idusNext = new RomanDateTime(1, 1, 13).PreviousSetDay(SetDays.Idus);

            Assert.AreEqual(new DateTime(1, 12, 1), kalNext.ToDateTime().DateTime);
            Assert.AreEqual(Eras.BC, kalNext.ToDateTime().Era);
            Assert.AreEqual(new DateTime(1, 12, 5), nonNext.ToDateTime().DateTime);
            Assert.AreEqual(Eras.BC, nonNext.ToDateTime().Era);
            Assert.AreEqual(new DateTime(1, 12, 13), idusNext.ToDateTime().DateTime);
            Assert.AreEqual(Eras.BC, idusNext.ToDateTime().Era);
        }
    }
}