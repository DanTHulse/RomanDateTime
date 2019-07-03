using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;

namespace RomanDate.Tests
{
    public partial class RomanDateTimeTests
    {
        [TestMethod]
        public void AddHours_AddsToRomanDate()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);
            var newDate = romanDate.AddHours(1);

            var expected = new RomanDateTime(2019, 1, 1, 13);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddHours_CorrectlyCrossesToADEra()
        {
            var romanDate = new RomanDateTime(1, 12, 31, 23, Eras.BC);
            var newDate = romanDate.AddHours(1);

            var expected = new RomanDateTime(1, 1, 1, 0);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddHours_CorrectlyCrossesToBCEra()
        {
            var romanDate = new RomanDateTime(1, 1, 1, 0);
            var newDate = romanDate.AddHours(-1);

            var expected = new RomanDateTime(1, 12, 31, 23, Eras.BC);

            Assert.AreEqual(expected, newDate);
        }
    }
}