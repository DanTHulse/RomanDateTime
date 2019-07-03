using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;

namespace RomanDate.Tests
{
    public partial class RomanDateTimeTests
    {
        [TestMethod]
        public void AddYears_AddsToRomanDate()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);
            var newDate = romanDate.AddYears(1);

            var expected = new RomanDateTime(2020, 1, 1, 12);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddYears_CorrectlyCrossesToADEra()
        {
            var romanDate = new RomanDateTime(1, 1, 1, Eras.BC);
            var newDate = romanDate.AddYears(1);

            var expected = new RomanDateTime(1, 1, 1);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddYears_CorrectlyCrossesToBCEra()
        {
            var romanDate = new RomanDateTime(1, 1, 1);
            var newDate = romanDate.AddYears(-1);

            var expected = new RomanDateTime(1, 1, 1, Eras.BC);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddYears_CorrectlyCrossesToADEraMultipleYears()
        {
            var romanDate = new RomanDateTime(1, 1, 1, Eras.BC);
            var newDate = romanDate.AddYears(10);

            var expected = new RomanDateTime(10, 1, 1);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddYears_CorrectlyCrossesToBCEraMultipleYears()
        {
            var romanDate = new RomanDateTime(1, 1, 1);
            var newDate = romanDate.AddYears(-10);

            var expected = new RomanDateTime(10, 1, 1, Eras.BC);

            Assert.AreEqual(expected, newDate);
        }
    }
}