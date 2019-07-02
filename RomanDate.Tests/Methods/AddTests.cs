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

        [TestMethod]
        public void Add_AddsAllToRomanDate()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);
            var newDate = romanDate.AddYears(1).AddMonths(3).AddDays(14).AddHours(-3);

            var expected = new RomanDateTime(2020, 4, 15, 9);

            Assert.AreEqual(expected, newDate);
        }
    }
}