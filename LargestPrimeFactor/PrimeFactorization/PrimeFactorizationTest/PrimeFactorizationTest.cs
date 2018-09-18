using NUnit.Framework;
using PrimeFactorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactorizationTest
{
    [TestFixture]
    public class PrimeFactorizationTest
    {
        private PrimeFactor pf;

        [SetUp]
        public void SetUp()
        {
            pf = new PrimeFactor();
        }

        private List<BigInteger> list(params BigInteger[] n)
        {
            return n.ToList();
        }

        [Test]
        public void canGetPrimeFactors()
        {
            assertPrimeFactors(0, list());
            assertPrimeFactors(1, list());
            assertPrimeFactors(2, list(2));
            assertPrimeFactors(3, list(3));
            assertPrimeFactors(4, list(2, 2));
            assertPrimeFactors(5, list(5));
            assertPrimeFactors(6, list(2, 3));
            assertPrimeFactors(7, list(7));
            assertPrimeFactors(8, list(2, 2, 2));
            assertPrimeFactors(9, list(3, 3));
            assertPrimeFactors(10, list(2, 5));
            assertPrimeFactors(2 * 2 * 3 * 3 * 5 * 7 * 11 * 11 * 13, list(2, 2, 3, 3, 5, 7, 11, 11, 13));
        }

        [Test]
        public void canGetLargestPrimeFactor()
        {
            assertLargestPrimeFactor(0, -1);
            assertLargestPrimeFactor(1, -1);
            assertLargestPrimeFactor(2, 2);
            assertLargestPrimeFactor(3, 3);
            assertLargestPrimeFactor(4, 2);
            assertLargestPrimeFactor(5, 5);
            assertLargestPrimeFactor(6, 3);
            assertLargestPrimeFactor(1981980, 13);
        }

        private void assertLargestPrimeFactor(BigInteger num, BigInteger expected)
        {
            Assert.AreEqual(expected, pf.getLargestPrimeFactor(num));
        }

        private void assertPrimeFactors(int num, List<BigInteger> exp)
        {
            Assert.AreEqual(exp, pf.getPrimeFactors(num));
        }
    }
}
