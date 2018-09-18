using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReducerTest
{
    [TestFixture]
    public class StringReducerTest
    {
        [Test]
        public void canReduceString()
        {
            assertReducedString(null, string.Empty);
            assertReducedString(string.Empty, string.Empty);
            assertReducedString(" ", string.Empty);
            assertReducedString("a", "a");
            assertReducedString("ab", "ab");
            assertReducedString("  ab ", "ab");
            assertReducedString("aa", string.Empty);
            assertReducedString("aaa", "a");
            assertReducedString("aab", "b");
            assertReducedString("abb", "a");
            assertReducedString("aaabcc", "ab");
            assertReducedString("aaabccddd", "abd");
            assertReducedString("baab", string.Empty);
            assertReducedString("baabccd", "d");
        }

        private void assertReducedString(string actual, string exp)
        {
            Assert.AreEqual(exp, reduceString(actual));
        }

        private string reduceString(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            else
            {
                string trimmed = s.Trim();
                if(trimmed.Count() > 1)
                    for(int index = 0; index < trimmed.Length - 1;)
                    {
                        if (equalAdjacentLetters(trimmed, index))
                        {
                            trimmed = trimmed.Remove(index, 2);
                            if (index != 0)
                                index--;
                        }
                        else
                            index++;
                    }

                return trimmed;
            }
        }

        private static bool equalAdjacentLetters(string trimmed, int i)
        {
            return trimmed[i] == trimmed[i + 1];
        }
    }
}
