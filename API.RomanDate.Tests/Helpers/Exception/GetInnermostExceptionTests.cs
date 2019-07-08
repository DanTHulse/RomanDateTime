using System;
using API.RomanDate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API.RomanDate.Tests.Helpers.Exceptions
{
    public partial class ExceptionHelperTests
    {
        [TestMethod]
        public void GetInnermostException_GetsTheInnermostException()
        {
            this.TestException = new Exception("Test Exception", new Exception("Test Inner Exception"));
            Assert.AreEqual(this.TestException.InnerException, this.TestException.GetInnermostException());
        }

        [TestMethod]
        public void GetInnermostException_GetsTheTopLevelExceptionIfNoInnerExceptions()
        {
            this.TestException = new Exception("Test Exception");
            Assert.AreEqual(this.TestException, this.TestException.GetInnermostException());
        }
    }
}
