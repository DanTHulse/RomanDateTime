using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;
using RomanDate.Helpers.RomanNumerals;

namespace RomanDate.Tests
{
    public partial class RomanNumeralsTests
    {
        [TestMethod]
        public void ToRomanNumerals_Subtractive_ReturnsIntInNumerals()
        {
            var i1991 = 1991.ToRomanNumerals();
            var i2018 = 2018.ToRomanNumerals();
            var i4853 = 4853.ToRomanNumerals();
            var i202 = 202.ToRomanNumerals();
            var i1764 = 1764.ToRomanNumerals();

            Assert.AreEqual("MCMXCI", i1991);
            Assert.AreEqual("MMXVIII", i2018);
            Assert.AreEqual("MMMMDCCCLIII", i4853);
            Assert.AreEqual("CCII", i202);
            Assert.AreEqual("MDCCLXIV", i1764);
        }

        [TestMethod]
        public void ToRomanNumerals_Additive_ReturnsIntInNumerals()
        {
            var i1991 = 1991.ToRomanNumerals(NumeralStyles.Additive);
            var i2018 = 2018.ToRomanNumerals(NumeralStyles.Additive);
            var i4853 = 4853.ToRomanNumerals(NumeralStyles.Additive);
            var i202 = 202.ToRomanNumerals(NumeralStyles.Additive);
            var i1764 = 1764.ToRomanNumerals(NumeralStyles.Additive);

            Assert.AreEqual("MDCCCCLXXXXI", i1991);
            Assert.AreEqual("MMXVIII", i2018);
            Assert.AreEqual("MMMMDCCCLIII", i4853);
            Assert.AreEqual("CCII", i202);
            Assert.AreEqual("MDCCLXIIII", i1764);
        }
    }
}