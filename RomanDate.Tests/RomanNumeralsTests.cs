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
            var year1991 = 1991.ToRomanNumerals();
            var year2018 = 2018.ToRomanNumerals();
            var year4853 = 4853.ToRomanNumerals();
            var year202 = 202.ToRomanNumerals();
            var year1764 = 1764.ToRomanNumerals();

            Assert.AreEqual("MCMXCI", year1991);
            Assert.AreEqual("MMXVIII", year2018);
            Assert.AreEqual("MMMMDCCCLIII", year4853);
            Assert.AreEqual("CCII", year202);
            Assert.AreEqual("MDCCLXIV", year1764);
        }

        [TestMethod]
        public void ToRomanNumerals_Additive_ReturnsIntInNumerals()
        {
            var year1991 = 1991.ToRomanNumerals(NumeralStyles.Additive);
            var year2018 = 2018.ToRomanNumerals(NumeralStyles.Additive);
            var year4853 = 4853.ToRomanNumerals(NumeralStyles.Additive);
            var year202 = 202.ToRomanNumerals(NumeralStyles.Additive);
            var year1764 = 1764.ToRomanNumerals(NumeralStyles.Additive);

            Assert.AreEqual("MDCCCCLXXXXI", year1991);
            Assert.AreEqual("MMXVIII", year2018);
            Assert.AreEqual("MMMMDCCCLIII", year4853);
            Assert.AreEqual("CCII", year202);
            Assert.AreEqual("MDCCLXIIII", year1764);
        }

        [TestMethod]
        public void ToInt_Subtractive_ReturnsValueInInteger()
        {
            var twoThousand = RomanNumerals.ToInt("MM");
            var sevenHundredTwentyOne = RomanNumerals.ToInt("DCCXXI");
            var NinteenHundredNinetyNine = RomanNumerals.ToInt("MCMXCIX");
            var SeventeenHundredSixtyFour = RomanNumerals.ToInt("MDCCLXIV");
            var FortyEightHundredFiftyThree = RomanNumerals.ToInt("MMMMDCCCLIII");
            var twoHundredTwo = RomanNumerals.ToInt("CCII");

            Assert.AreEqual(2000, twoThousand);
            Assert.AreEqual(721, sevenHundredTwentyOne);
            Assert.AreEqual(1999, NinteenHundredNinetyNine);
            Assert.AreEqual(1764, SeventeenHundredSixtyFour);
            Assert.AreEqual(4853, FortyEightHundredFiftyThree);
            Assert.AreEqual(202, twoHundredTwo);
        }

        [TestMethod]
        public void ToInt_Additive_ReturnsValueInInteger()
        {
            var NinteenHundredNinetyNine = RomanNumerals.ToInt("MDCCCCLXXXXVIIII");
            var SeventeenHundredSixtyFour = RomanNumerals.ToInt("MDCCLXIIII");

            Assert.AreEqual(1999, NinteenHundredNinetyNine);
            Assert.AreEqual(1764, SeventeenHundredSixtyFour);
        }
    }
}
