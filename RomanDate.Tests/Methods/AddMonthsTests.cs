using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;

namespace RomanDate.Tests
{
    public partial class RomanDateTimeTests
    {
        [TestMethod]
        public void AddMonths_AddsToRomanDate()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);
            var newDate = romanDate.AddMonths(1);

            var expected = new RomanDateTime(2019, 2, 1, 12);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddMonths_CorrectlyCrossesToADEra()
        {
            var romanDate = new RomanDateTime(1, 12, 1, Eras.BC);
            var newDate = romanDate.AddMonths(1);

            var expected = new RomanDateTime(1, 1, 1);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddMonths_CorrectlyCrossesToBCEra()
        {
            var romanDate = new RomanDateTime(1, 1, 1);
            var newDate = romanDate.AddMonths(-1);

            var expected = new RomanDateTime(1, 12, 1, Eras.BC);

            Assert.AreEqual(expected, newDate);
        }
    }
}