using Fibonacci;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciTest
{
    [TestFixture]
    public class FirstHundredFibonacciTest
    {
        private FibonacciRange fr;

        [SetUp]
        public void Setup()
        {
            fr = new FibonacciRange();
        }

        private void assertFibonacciRange(int range, List<BigInteger> expected)
        {
            Assert.AreEqual(expected, fr.getFibonacciRange(range));
        }

        private List<BigInteger> list(params BigInteger[] n)
        {
            return n.ToList();
        }

        [Test]
        public void canGetFibonacciRange()
        {
            assertFibonacciRange(0, list());
            assertFibonacciRange(1, list(0));
            assertFibonacciRange(2, list(0,1));
            assertFibonacciRange(3, list(0, 1, 1));
            assertFibonacciRange(4, list(0, 1, 1, 2));
            assertFibonacciRange(7, list(0, 1, 1, 2, 3, 5, 8));
        }
    }
}
