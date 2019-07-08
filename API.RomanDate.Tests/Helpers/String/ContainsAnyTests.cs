using API.RomanDate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API.RomanDate.Tests.Helpers.String
{
    public partial class StringHelperTests
    {
        [TestMethod]
        public void ContainsAny_ReturnsTrueIfStringContainsAnyChar()
        {
            this._testString = "http://test.com";

            Assert.IsTrue(this._testString.ContainsAny('/', ':', '.'));
        }

        [TestMethod]
        public void ContainsAny_ReturnsFalseIfStringDoesNotContainAnyChar()
        {
            this._testString = "httptestcom";

            Assert.IsFalse(this._testString.ContainsAny('/', ':', '.'));
        }
    }
}
