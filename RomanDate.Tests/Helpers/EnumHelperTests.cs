using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Helpers;
using Description = System.ComponentModel.DescriptionAttribute;

namespace RomanDate.Tests.Helpers
{
    [TestClass]
    public class EnumHelperTests
    {
        private enum TestEnum
        {
            [Description("FirstValue")]
            First = 1,
            Second = 2, [Description("ThirdValue")]
            Third = 3
        }

        [TestMethod]
        public void EnumToList_ConvertsEnumToListOfValues()
        {
            var test = EnumHelpers.EnumToList<TestEnum>();

            Assert.IsTrue(test.Contains(TestEnum.First));
            Assert.IsTrue(test.Contains(TestEnum.Second));
            Assert.IsTrue(test.Contains(TestEnum.Third));
        }

        [TestMethod]
        public void Next_ReturnsNextValue()
        {
            var result = TestEnum.First.Next();

            Assert.AreEqual(TestEnum.Second, result);
        }

        [TestMethod]
        public void Next_ReturnsFirstValueIfMaxValue()
        {
            var result = TestEnum.Third.Next();

            Assert.AreEqual(TestEnum.First, result);
        }

        [TestMethod]
        public void Previous_ReturnsPreviousValue()
        {
            var result = TestEnum.Second.Previous();

            Assert.AreEqual(TestEnum.First, result);
        }

        [TestMethod]
        public void Previous_ReturnsLastValueIfMinValue()
        {
            var result = TestEnum.First.Previous();

            Assert.AreEqual(TestEnum.Third, result);
        }
    }
}