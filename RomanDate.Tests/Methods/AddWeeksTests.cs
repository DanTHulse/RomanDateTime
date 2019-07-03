using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;

namespace RomanDate.Tests
{
    public partial class RomanDateTimeTests
    {
        [TestMethod]
        public void AddWeeks_AddsToRomanDate()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);
            var newDate = romanDate.AddWeeks(1);

            var expected = new RomanDateTime(2019, 1, 9, 12);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddWeeks_CorrectlyCrossesToADEra()
        {
            var romanDate = new RomanDateTime(1, 12, 24, Eras.BC);
            var newDate = romanDate.AddWeeks(1);

            var expected = new RomanDateTime(1, 1, 1);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddWeeks_CorrectlyCrossesToBCEra()
        {
            var romanDate = new RomanDateTime(1, 1, 1);
            var newDate = romanDate.AddWeeks(-1);

            var expected = new RomanDateTime(1, 12, 24, Eras.BC);

            Assert.AreEqual(expected, newDate);
        }
    }
}