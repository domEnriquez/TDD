using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LychrelNumbers.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private const int LIMIT = 1000;

        [TestMethod]
        public void Facts()
        {
            isNotLychrel(1, 0, LIMIT);
            isNotLychrel(9, 0, LIMIT);
            isNotLychrel(10, 1, LIMIT);
            isNotLychrel(11, 0, LIMIT);
            isNotLychrel(19, 2, LIMIT);
            isNotLychrel(78, 4, LIMIT);

            // Not yet tested for very big integers
        }

        private void isNotLychrel(int num, int iteration, int limit)
        {
            Assert.AreEqual(iteration, Lychrel.ConvergestAtIteration(num, LIMIT));
        }

        [TestMethod]
        public void IsPalindrome()
        {
            isPalindrome(1);
            isPalindrome(11);
            isPalindrome(121);
            isPalindrome(2112);
        }
        private void isPalindrome(int num)
        {
            Assert.IsTrue(Lychrel.IsPalindrome(num));
        }

        [TestMethod]
        public void IsNotPalindrome()
        {
            isNotPalindrome(2132);
            isNotPalindrome(21343112);
        }

        private void isNotPalindrome(int num)
        {
            Assert.IsFalse(Lychrel.IsPalindrome(num));
        }

        [TestMethod]
        public void Reverse()
        {
            reversed(12, 21);
            reversed(1353, 3531);
        }

        private void reversed(int num, int rev)
        {
            Assert.AreEqual(num, Lychrel.Reverse(rev));
        }

        
    }
}
