using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;
using RomanDate.Helpers.RomanDate;

namespace RomanDate.Tests.Helpers.RomanDate
{
    public partial class RomanDateTimeHelperTests
    {
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
    }
}