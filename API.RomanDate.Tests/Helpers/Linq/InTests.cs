using API.RomanDate.Helpers.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API.RomanDate.Tests.Helpers.Linq
{
    public partial class LinqHelperTests
    {
        [TestMethod]
        public void In_ReturnsTrueIfElementInList()
        {
            Assert.IsTrue(1.In(1, 2, 3, 4, 5, 6));
        }

        [TestMethod]
        public void In_ReturnsFalseIfElementNotInList()
        {
            Assert.IsFalse(10.In(1, 2, 3, 4, 5, 6));
        }
    }
}
