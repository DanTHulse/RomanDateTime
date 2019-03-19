using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Helpers;

namespace RomanDate.Tests.Helpers
{
    [TestClass]
    public class StringHelperTests
    {
        private string _testString;

        [TestMethod]
        public void Left_ReturnsCorrectSubString()
        {
            _testString = "This is a test string";

            var leftString = _testString.Left(4);

            Assert.AreEqual("This", leftString);
        }

        [TestMethod]
        public void Left_ReturnsStringIfSmallerThanMaxLength()
        {
            _testString = "Thi";

            var leftString = _testString.Left(4);

            Assert.AreEqual("Thi", leftString);
        }

        [TestMethod]
        public void Left_ReturnsEmptyString()
        {
            _testString = "";

            var leftString = _testString.Left(4);

            Assert.IsTrue(string.IsNullOrEmpty(leftString));
        }
    }
}
