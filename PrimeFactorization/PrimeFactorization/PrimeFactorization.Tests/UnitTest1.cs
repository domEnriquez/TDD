using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace PrimeFactorization.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void facts()
        {
            arePrimeFactorsCorrect(1, new List<int> { });
            arePrimeFactorsCorrect(2, new List<int> { 2 });
            arePrimeFactorsCorrect(3, new List<int> { 3 });
            arePrimeFactorsCorrect(4, new List<int> { 2 });
            arePrimeFactorsCorrect(10, new List<int> { 2, 5 });
            arePrimeFactorsCorrect(15, new List<int> { 3, 5 });
            arePrimeFactorsCorrect(234, new List<int> { 2, 3, 13 });
            arePrimeFactorsCorrect(1000, new List<int> { 2, 5 });
        }

        private void arePrimeFactorsCorrect(int num, List<int> primeFactors)
        {
            Assert.IsTrue(primeFactors.SequenceEqual(PrimeFactorization.GetPrimeFactors(num)));
        }

        [TestMethod]
        public void primeNumbersTest()
        {
            isPrime(2);
            isPrime(3);
            isPrime(7);
            isPrime(151);
            isPrime(199);
        }

        [TestMethod]
        public void nonPrimeNumbers()
        {
            isNotPrime(4);
            isNotPrime(6);
            isNotPrime(63);
        }

        private void isNotPrime(int num)
        {
            Assert.IsFalse(PrimeFactorization.IsPrime(num));
        }

        private void isPrime(int num)
        {
            Assert.IsTrue(PrimeFactorization.IsPrime(num));
        }

    }
}
