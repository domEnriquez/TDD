using NumberDissector;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NumberDissectorTest
{
    [TestFixture]
    public class NumberDissectorTest
    {
        private IntDissector intDissector;

        [SetUp]

        public void Setup()
        {
            intDissector = new IntDissector();
        }


        private List<int> list(params int[] n)
        {
            return n.ToList();
        }

        private void canDissectNumber(int num, List<int> dissected)
        {
            intDissector.dissected = new List<int>();
            Assert.AreEqual(dissected, intDissector.dissect(num));
        }

        [Test]
        public void canDissectNumbers()
        {
            canDissectNumber(0, list(0));
            canDissectNumber(1, list(1));
            canDissectNumber(10, list(1, 0));
            canDissectNumber(11, list(1, 1));
            canDissectNumber(33, list(3, 3));
            canDissectNumber(100, list(1, 0, 0));
            canDissectNumber(101, list(1, 0, 1));
            canDissectNumber(1000, list(1, 0, 0, 0));
            canDissectNumber(1001, list(1, 0, 0, 1));
            canDissectNumber(123456, list(1, 2, 3, 4, 5, 6));
        }
    }
}
