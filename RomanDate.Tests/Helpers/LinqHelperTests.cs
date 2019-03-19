using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Helpers;
using System;
using System.Collections.Generic;

namespace RomanDate.Tests.Helpers
{
    [TestClass]
    public class LinqHelperTests
    {
        [TestMethod]
        public void Between_ReturnsTrueIfDateBetweenDates()
        {
            var startDate = new DateTime(2019, 1, 1, 0, 0, 0); // January 1st 2019 - 00:00.00
            var endDate = new DateTime(2019, 1, 10, 0, 0, 0); // January 10th 2019 - 00:00.00

            var middleDate = new DateTime(2019, 1, 5, 0, 0, 0); // January 5th 2019 - 00:00.00

            Assert.IsTrue(middleDate.Between(startDate, endDate));
        }

        [TestMethod]
        public void Between_ReturnsFalseIfDateNotBetweenDates()
        {
            var startDate = new DateTime(2019, 1, 1, 0, 0, 0); // January 1st 2019 - 00:00.00
            var endDate = new DateTime(2019, 1, 10, 0, 0, 0); // January 10th 2019 - 00:00.00

            var middleDate = new DateTime(2019, 1, 15, 0, 0, 0); // January 15th 2019 - 00:00.00

            Assert.IsFalse(middleDate.Between(startDate, endDate));
        }

        [TestMethod]
        public void Between_ReturnsTrueIfIntBetweenInts()
        {
            var startInt = 1;
            var endInt = 10;

            var middleInt = 5;

            Assert.IsTrue(middleInt.Between(startInt, endInt));
        }

        [TestMethod]
        public void Between_ReturnsFalseIfIntNotBetweenInts()
        {
            var startInt = 1;
            var endInt = 10;

            var middleInt = 15;

            Assert.IsFalse(middleInt.Between(startInt, endInt));
        }

        [TestMethod]
        public void In_ReturnsTrueIfElementInList()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6 };

            Assert.IsTrue(1.In(list));
        }

        [TestMethod]
        public void In_ReturnsFalseIfElementNotInList()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6 };

            Assert.IsFalse(10.In(list));
        }
    }
}
