using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Helpers.RomanNumerals;

namespace RomanDate.Tests
{
    public partial class RomanNumeralsTests
    {
        [TestMethod]
        public void ToInt_Subtractive_ReturnsValueInInteger()
        {
            var i2000 = RomanNumerals.ToInt("MM");
            var i721 = RomanNumerals.ToInt("DCCXXI");
            var i1999 = RomanNumerals.ToInt("MCMXCIX");
            var i1764 = RomanNumerals.ToInt("MDCCLXIV");
            var i4853 = RomanNumerals.ToInt("MMMMDCCCLIII");
            var i202 = RomanNumerals.ToInt("CCII");

            Assert.AreEqual(2000, i2000);
            Assert.AreEqual(721, i721);
            Assert.AreEqual(1999, i1999);
            Assert.AreEqual(1764, i1764);
            Assert.AreEqual(4853, i4853);
            Assert.AreEqual(202, i202);
        }

        [TestMethod]
        public void ToInt_Additive_ReturnsValueInInteger()
        {
            var i1999 = RomanNumerals.ToInt("MDCCCCLXXXXVIIII");
            var i1764 = RomanNumerals.ToInt("MDCCLXIIII");

            Assert.AreEqual(1999, i1999);
            Assert.AreEqual(1764, i1764);
        }
    }
}