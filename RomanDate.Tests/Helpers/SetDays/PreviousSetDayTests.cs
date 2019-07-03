using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;
using RomanDate.Helpers;

namespace RomanDate.Tests.Helpers
{
    public partial class RomanDateTimeHelperTests
    {
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