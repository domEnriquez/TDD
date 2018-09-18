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
    public class SumOfEvenFibonacciTest
    {
        private SumOfEvenFibonacci soef;

        [SetUp]
        public void Setup()
        {
            soef = new SumOfEvenFibonacci();
        }

        [Test]
        public void canGetSumOfFibonacci()
        {
            assertSumOfEvenFiboWhichDoesNotExceed(1, 0);
            assertSumOfEvenFiboWhichDoesNotExceed(2, 2);
            assertSumOfEvenFiboWhichDoesNotExceed(3, 2);
            assertSumOfEvenFiboWhichDoesNotExceed(15, 10);
            assertSumOfEvenFiboWhichDoesNotExceed(20, 10);
            assertSumOfEvenFiboWhichDoesNotExceed(55, 44);
        }

        private void assertSumOfEvenFiboWhichDoesNotExceed(BigInteger bound, BigInteger exp)
        {
            Assert.AreEqual(exp, soef.getSumOfEvenFibNumWhichDoesNotExceed(bound));
        }
    }
}
