using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoCharacters;

namespace TwoCharactersTest
{
    [TestFixture]
    public class TwoCharactersTest
    {
        private TwoChar twoChar;

        [SetUp]
        public void Setup()
        {
            twoChar = new TwoChar();
        }

        private void assertCountLongestAltChar(string s, int exp)
        {
            Assert.AreEqual(exp, twoChar.countLongestAlternatingChar(s), "Failed: " + s);
        }

        private void assertAltChar(string s, bool exp)
        {
            Assert.AreEqual(exp, twoChar.alternatingChar(s), "Failed: " + s);
        }

        private void assertExtractAltChar(string s, List<string> list)
        {
            CollectionAssert.AreEquivalent(list, twoChar.extractAltCharFrom(s, new List<string>()), "Failed: " + s);
        }

        private List<string> list(params string[] n)
        {
            return n.ToList();
        }

        [Test]
        public void canCountLongestAltChar()
        {
            assertCountLongestAltChar(string.Empty, 0);
            assertCountLongestAltChar("", 0);
            assertCountLongestAltChar(null, 0);
            assertCountLongestAltChar("a", 0);
            assertCountLongestAltChar("ab", 2);
            assertCountLongestAltChar("aa", 0);
            assertCountLongestAltChar("aba", 3);
            assertCountLongestAltChar("abc", 2);
            assertCountLongestAltChar("abca", 3);
            assertCountLongestAltChar("beabeefeab", 5);
            //assertCountLongestAltChar("uyetuppelecblwipdsqabzsvyfaezeqhpnalahnpkdbhzjglcuqfjnzpmbwprelbayyzovkhacgrglrdpmvaexkgertilnfooeazvulykxypsxicofnbyivkthovpjzhpohdhuebazlukfhaavfsssuupbyjqdxwwqlicbjirirspqhxomjdzswtsogugmbnslcalcfaxqmionsxdgpkotffycphsewyqvhqcwlufekxwoiudxjixchfqlavjwhaennkmfsdhigyeifnoskjbzgzggsmshdhzagpznkbahixqgrdnmlzogprctjggsujmqzqknvcuvdinesbwpirfasnvfjqceyrkknyvdritcfyowsgfrevzon", 0);
        }

        [Test]
        public void canTellIfAltChar()
        {
            assertAltChar("a", false);
            assertAltChar("aa", false);
            assertAltChar("ab", true);
            assertAltChar("abc", false);
            assertAltChar("aba", true);
            assertAltChar("abaa", false);
            assertAltChar("abab", true);
            assertAltChar("ababababc", false);
            assertAltChar("ababababa", true);
            assertAltChar("abbabababa", false);
            assertAltChar("aaaaaaaa", false);
            assertAltChar("ababababc", false);
            assertAltChar("abababaca", false);
        }

        [Test]
        public void canExtractAltChar()
        {
            assertExtractAltChar("a", list());
            assertExtractAltChar("ab", list("ab"));
            assertExtractAltChar("aa", list());
            assertExtractAltChar("abc", list("bc","ac","ab"));
            assertExtractAltChar("abca", list("bc", "aca", "aba"));
        }
    }
}
