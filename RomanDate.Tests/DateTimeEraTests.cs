using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;

namespace RomanDate.Tests
{
    [TestClass]
    public class DateTimeEraTests
    {
        [TestMethod]
        public void TryAddDays_CorrectlyCrossesToBCEra()
        {
            var date = new DateTimeEra(new DateTime(1, 1, 5), Eras.AD);

            var newDate = date.TryAddDays(-6);

            Assert.AreEqual(30, newDate.DateTime.Day);
            Assert.AreEqual(12, newDate.DateTime.Month);
            Assert.AreEqual(1, newDate.DateTime.Year);
            Assert.AreEqual(Eras.BC, newDate.Era);
        }

        [TestMethod]
        public void TryAddDays_CorrectlyAddsDaysInADEra()
        {
            var date = new DateTimeEra(new DateTime(1, 1, 5), Eras.AD);

            var newDate = date.TryAddDays(6);

            Assert.AreEqual(11, newDate.DateTime.Day);
            Assert.AreEqual(1, newDate.DateTime.Month);
            Assert.AreEqual(1, newDate.DateTime.Year);
            Assert.AreEqual(Eras.AD, newDate.Era);
        }

        [TestMethod]
        public void TryAddDays_CorrectlySubtractsDaysInADEra()
        {
            var date = new DateTimeEra(new DateTime(1, 1, 5), Eras.AD);

            var newDate = date.TryAddDays(-3);

            Assert.AreEqual(2, newDate.DateTime.Day);
            Assert.AreEqual(1, newDate.DateTime.Month);
            Assert.AreEqual(1, newDate.DateTime.Year);
            Assert.AreEqual(Eras.AD, newDate.Era);
        }

        [TestMethod]
        public void TryAddDays_CorrectlyCrossesToADEra()
        {
            var date = new DateTimeEra(new DateTime(1, 12, 31), Eras.BC);

            var newDate = date.TryAddDays(6);

            Assert.AreEqual(6, newDate.DateTime.Day);
            Assert.AreEqual(1, newDate.DateTime.Month);
            Assert.AreEqual(1, newDate.DateTime.Year);
            Assert.AreEqual(Eras.AD, newDate.Era);
        }

        [TestMethod]
        public void TryAddDays_CorrectlyAddsDaysInBCEra()
        {
            var date = new DateTimeEra(new DateTime(1, 2, 11), Eras.BC);

            var newDate = date.TryAddDays(12);

            Assert.AreEqual(23, newDate.DateTime.Day);
            Assert.AreEqual(2, newDate.DateTime.Month);
            Assert.AreEqual(1, newDate.DateTime.Year);
            Assert.AreEqual(Eras.BC, newDate.Era);
        }

        [TestMethod]
        public void TryAddDays_CorrectlyCrossesYearsInBCEra()
        {
            var date = new DateTimeEra(new DateTime(1, 1, 1), Eras.BC);

            var newDate = date.TryAddDays(-6);

            Assert.AreEqual(26, newDate.DateTime.Day);
            Assert.AreEqual(12, newDate.DateTime.Month);
            Assert.AreEqual(2, newDate.DateTime.Year);
            Assert.AreEqual(Eras.BC, newDate.Era);
        }

        [TestMethod]
        public void TryAddDays_CorrectlySubtractsDaysInBCEra()
        {
            var date = new DateTimeEra(new DateTime(1, 1, 11), Eras.BC);

            var newDate = date.TryAddDays(-5);

            Assert.AreEqual(6, newDate.DateTime.Day);
            Assert.AreEqual(1, newDate.DateTime.Month);
            Assert.AreEqual(1, newDate.DateTime.Year);
            Assert.AreEqual(Eras.BC, newDate.Era);
        }
    }
}