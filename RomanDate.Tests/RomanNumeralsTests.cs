using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;

namespace RomanDate.Tests
{
    [TestClass]
    public class RomanNumeralsTests
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
