using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API.RomanDate.Tests.Helpers.Linq
{
    [TestClass]
    public partial class LinqHelperTests
    {
        private IEnumerable<string> _mockList = new List<string>();
        private IEnumerable<TestObject> _mockObjectList = new List<TestObject>();

        [TestInitialize]
        public void Init()
        {
            this._mockList = new List<string>
            {
                "Item 1",
                "Item New",
                "Objects",
                "Testing",
                "Fool's Gold"
            };

            this._mockObjectList = new List<TestObject>
            {
                new TestObject
                {
                    Id = 1,
                    Name = "Test 1",
                    CreatedAt = DateTime.Now
                },
                new TestObject
                {
                    Id = 1,
                    Name = "Test 123",
                    CreatedAt = DateTime.Now
                },
                new TestObject
                {
                    Id = 2,
                    Name = "Test 22",
                    CreatedAt = DateTime.Now
                },
                new TestObject
                {
                    Id = 2,
                    Name = "Test 21232",
                    CreatedAt = DateTime.Now
                },
                new TestObject
                {
                    Id = 3,
                    Name = "Test 3321",
                    CreatedAt = DateTime.Now
                }
            };
        }

        private class TestObject
        {
            public int Id { get; set; } = 0;
            public string Name { get; set; } = "";
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        }
    }
}
