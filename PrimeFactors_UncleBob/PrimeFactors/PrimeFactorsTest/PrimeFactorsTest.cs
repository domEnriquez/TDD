using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactorsTest
{

    [TestFixture]
    public class PrimeFactorsTest
    {
        private List<int> list(params int[] n)
        {
            return n.ToList();
        }
        private void assertPrimeFactors(int n, List<int> primeFactors)
        {
            Assert.AreEqual(primeFactors, of(n));
        }

        [Test]
        public void canFactorIntoPrimes()
        {
            assertPrimeFactors(1, list());
            assertPrimeFactors(2, list(2));
            assertPrimeFactors(3, list(3));
            assertPrimeFactors(4, list(2, 2));
            assertPrimeFactors(5, list(5));
            assertPrimeFactors(6, list(2, 3));
            assertPrimeFactors(7, list(7));
            assertPrimeFactors(8, list(2, 2, 2));
            assertPrimeFactors(9, list(3, 3));
            assertPrimeFactors(2 * 2 * 3 * 3 * 5 * 7 * 11 * 11 * 13, list(2, 2, 3, 3, 5, 7, 11, 11, 13));
        }

        private List<int> of(int n)
        {
            List<int> factors = new List<int>();
            
            for (int divisor = 2; n > 1; divisor++)
                for (; n % divisor == 0; n /= divisor)
                    factors.Add(divisor);

            return factors;
        }

    }
}
