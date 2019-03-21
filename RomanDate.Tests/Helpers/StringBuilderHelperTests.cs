using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Helpers;

namespace RomanDate.Tests.Helpers
{
    [TestClass]
    public class StringBuilderHelperTests
    {
        private StringBuilder sb;

        [TestInitialize]
        public void Init()
        {
            sb = new StringBuilder();
        }

        [TestMethod]
        public void AppendIf_AppendsToStringIfConditionIsMet()
        {
            var str = "Test String";
            var cond = true;

            sb.AppendIf(str, cond);

            Assert.AreEqual(str, sb.ToString());
        }

        [TestMethod]
        public void AppendIf_DoesNotAppendToStringIfConditionIsNotMet()
        {
            var str = "Test String";
            var cond = false;

            sb.AppendIf(str, cond);

            Assert.AreEqual("", sb.ToString());
        }

        [TestMethod]
        public void AppendRepeat_AppendsStringNumberOfTimesSpecified()
        {
            var str = "Test String";
            var times = 3;

            sb.AppendRepeat(str, times);

            Assert.AreEqual("Test StringTest StringTest String", sb.ToString());
        }

        [TestMethod]
        public void AppendRepeat_DoesNotAppendsStringIfZero()
        {
            var str = "Test String";
            var times = 0;

            sb.AppendRepeat(str, times);

            Assert.AreEqual("", sb.ToString());
        }

        [TestMethod]
        public void AppendIfRepeat_AppendsStringNumberOfTimesSpecifiedIfConditionIsMet()
        {
            var str = "Test String";
            var times = 3;
            var cond = true;

            sb.AppendIfRepeat(str, cond, times);

            Assert.AreEqual("Test StringTest StringTest String", sb.ToString());
        }

        [TestMethod]
        public void AppendIfRepeat_DoesNotAppendStringIfConditionIsNotMet()
        {
            var str = "Test String";
            var times = 3;
            var cond = false;

            sb.AppendIfRepeat(str, cond, times);

            Assert.AreEqual("", sb.ToString());
        }

        [TestMethod]
        public void AppendIfRepeat_DoesNotAppendStringIfZero()
        {
            var str = "Test String";
            var times = 0;
            var cond = true;

            sb.AppendIfRepeat(str, cond, times);

            Assert.AreEqual("", sb.ToString());
        }
    }
}