using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Helpers;
using System.ComponentModel;
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
            Second = 2,
            [Description("ThirdValue")]
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
    }
}
