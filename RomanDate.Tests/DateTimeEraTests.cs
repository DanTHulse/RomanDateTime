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
    }
}