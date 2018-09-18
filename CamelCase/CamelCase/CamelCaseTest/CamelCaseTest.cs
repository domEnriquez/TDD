using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelCaseTest
{
    [TestFixture]
    public class CamelCaseTest
    {
        [Test]
        public void canCountWords()
        {
            assertCountWords(null, 0);
            assertCountWords(string.Empty, 0);
            assertCountWords(" ", 0);
            assertCountWords("a", 1);
            assertCountWords("at", 1);
            assertCountWords("atThe", 2);
            assertCountWords("iAmAChamp", 4);
        }

        private void assertCountWords(string actual, int exp)
        {
            Assert.AreEqual(exp, countWords(actual), "Failed input: " + actual);
        }

        private int countWords(string s)
        {
            if(string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                return 0;

            int count = 1;

            for (int i = 0; i < s.Length; i++)
                if (Char.IsUpper(s[i]))
                    count++;

            return count;
        }
    }
}
