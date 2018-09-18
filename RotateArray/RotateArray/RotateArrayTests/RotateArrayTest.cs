using NUnit.Framework;
using RotateArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArrayTests
{
    [TestFixture]
    public class RotateArrayTest
    {
        private RotateArr rotateArr;

        private void assertRotateArray(List<int> actual, int count, List<int> expected)
        {
            Assert.AreEqual(expected, rotateArr.rotate(actual, count));
        }

        private List<int> list(params int[] n)
        {
            return n.ToList();
        }

        [SetUp]
        public void Setup()
        {
            rotateArr = new RotateArr();
        }

        [Test]
        public void canRotateArray()
        {
            assertRotateArray(null, 1, null);
            assertRotateArray(list(), 1, list());
            assertRotateArray(list(1), 1, list(1));
            assertRotateArray(list(1), 0, list(1));
            assertRotateArray(list(1, 2), 0, list(1,2));
            assertRotateArray(list(1, 2), 1, list(2,1));
            assertRotateArray(list(1, 2, 3, 4, 5, 6), 2, list(3, 4, 5, 6, 1, 2));
            assertRotateArray(list(1, 2, 3, 4, 5, 6), 3, list(4, 5, 6, 1, 2, 3));
        }
    }
}
