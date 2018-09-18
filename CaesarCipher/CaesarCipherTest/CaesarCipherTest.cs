using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipherTest
{
    [TestFixture]
    public class CaesarCipherTest
    {
        private const int LETTERS_COUNT = 26;

        private void assertEncrypt(string actual, int k, string exp)
        {
            if(actual == null)
                Assert.AreEqual(exp, encryptString(0, actual, k), "Failed: " + actual);
            else
                Assert.AreEqual(exp, encryptString(actual.Length, actual, k), "Failed: " + actual);
        }

        [Test]
        public void canEncrypt()
        {
            assertEncrypt(null, 0,string.Empty);
            assertEncrypt(string.Empty, 0,string.Empty);
            assertEncrypt(" ", 1, " ");
            assertEncrypt("a", 1, "b");
            assertEncrypt(" a ", 1, " b ");
            assertEncrypt("ab", 2, "cd");
            assertEncrypt("a.b-c,d", 3, "d.e-f,g");
            assertEncrypt("a", 30, "e");
            assertEncrypt("a", 53, "b");
            assertEncrypt("b", 30, "f");
            assertEncrypt("z", 1, "a");
            assertEncrypt("A", 30, "E");
            assertEncrypt("A", 53, "B");
            assertEncrypt("A.a@B-.b", 53, "B.b@C-.c");
        }

        private string encryptString(int strLen, string str, int cipherIndex)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            StringBuilder strB = new StringBuilder(str);

            for (int i = 0; i < strLen; i++)
                if (letter(strB[i]))
                    if (lowercaseLetter(strB[i]))
                        strB[i] = encryptLetter(strB[i], cipherIndex, 'a', 'z');
                    else
                        strB[i] = encryptLetter(strB[i], cipherIndex, 'A', 'Z');

            return strB.ToString();
        }

        private char encryptLetter(char letter, int cipherIndex, char firstLetter, char lastLetter)
        {
            int encrypted = letter + cipherIndex;

            while (lastLetter < encrypted)
            {
                cipherIndex = (encrypted) - (lastLetter);
                encrypted = (firstLetter-1) + cipherIndex;
            }

            return (char)(encrypted);
        }

        private bool lowercaseLetter(char c)
        {
            return c >= 'a' && c <= 'z';
        }

        private bool letter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }
    }
}
