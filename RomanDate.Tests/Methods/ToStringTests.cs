using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanDate.Tests
{
    public partial class RomanDateTimeTests
    {
        [TestMethod]
        public void ToFormattedString_ReturnsCorrectElements()
        {
            var romanDate = new RomanDateTime(2018, 1, 17);

            var time = romanDate.ToString("t");
            var hour = romanDate.ToString("h");
            var vigila = romanDate.ToString("v");
            var shortPrefix = romanDate.ToString("p");
            var fullPrefix = romanDate.ToString("P");
            var daysUntil = romanDate.ToString("d");
            var shortSetDay = romanDate.ToString("sx");
            var fullSetDay = romanDate.ToString("Sx");
            var shortMonth = romanDate.ToString("m");
            var fullMonth = romanDate.ToString("M");
            var year = romanDate.ToString("y");
            var aucYear = romanDate.ToString("Yx");
            var era = romanDate.ToString("e");
            var calDay = romanDate.ToString("Dx");
            var nundinal = romanDate.ToString("Dn");
            var shortCalMonth = romanDate.ToString("cx");
            var fullCalMonth = romanDate.ToString("Cx");

            Assert.AreEqual("Vigila Tertia", time);
            Assert.AreEqual("hora noctis VII", hour);
            Assert.AreEqual("Vigila Tertia", vigila);
            Assert.AreEqual("a.d.", shortPrefix);
            Assert.AreEqual("ante diem", fullPrefix);
            Assert.AreEqual("XVI", daysUntil);
            Assert.AreEqual("Kal.", shortSetDay);
            Assert.AreEqual("Kalendas", fullSetDay);
            Assert.AreEqual("Feb.", shortMonth);
            Assert.AreEqual("Februarias", fullMonth);
            Assert.AreEqual("MMXVIII", year);
            Assert.AreEqual("MMDCCLXXI", aucYear);
            Assert.AreEqual("AD", era);
            Assert.AreEqual("XVII", calDay);
            Assert.AreEqual("B", nundinal);
            Assert.AreEqual("Ian.", shortCalMonth);
            Assert.AreEqual("Ianuarius", fullCalMonth);
        }
    }
}