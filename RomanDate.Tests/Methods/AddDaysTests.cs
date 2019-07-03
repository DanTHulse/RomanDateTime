using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;

namespace RomanDate.Tests
{
    public partial class RomanDateTimeTests
    {
        [TestMethod]
        public void AddDays_AddsToRomanDate()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);
            var newDate = romanDate.AddDays(1);

            var expected = new RomanDateTime(2019, 1, 2, 12);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddDays_CorrectlyCrossesToADEra()
        {
            var romanDate = new RomanDateTime(1, 12, 31, Eras.BC);
            var newDate = romanDate.AddDays(1);

            var expected = new RomanDateTime(1, 1, 1);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddDays_CorrectlyCrossesToBCEra()
        {
            var romanDate = new RomanDateTime(1, 1, 1);
            var newDate = romanDate.AddDays(-1);

            var expected = new RomanDateTime(1, 12, 31, Eras.BC);

            Assert.AreEqual(expected, newDate);
        }
    }
}