using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Definitions;
using RomanDate.Enums;

namespace RomanDate.Tests.Definitions
{
    public partial class RomanMonthsTests
    {
        [TestMethod]
        public void RomanMonths_Conversion()
        {
            var month = (RomanMonths)1;

            Assert.AreEqual(Months.Ianuarius, month.Month);
        }
    }
}
