using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;

namespace RomanDate.Tests
{
    public partial class RomanDateTimeTests
    {
        [TestMethod]
        public void ToDateTime_ReturnsOriginalDateTimeAD()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);

            var expected = new DateTime(2019, 1, 1, 12, 0, 0);

            Assert.AreEqual(expected, romanDate.ToDateTime().DateTime);
            Assert.AreEqual(Eras.AD, romanDate.ToDateTime().Era);
        }

        [TestMethod]
        public void ToDateTime_ReturnsOriginalDateTimeBC()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12, Eras.BC);

            var expected = new DateTime(2019, 1, 1, 12, 0, 0);

            Assert.AreEqual(expected, romanDate.ToDateTime().DateTime);
            Assert.AreEqual(Eras.BC, romanDate.ToDateTime().Era);
        }
    }
}