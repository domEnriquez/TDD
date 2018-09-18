using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator;

namespace PigLatinTranslatorTests
{
    [TestFixture]
    public class PigTranslatorTests
    {
        private PigLatinTranslator pl; 

        [SetUp]
        public void Setup()
        {
            pl = new PigLatinTranslator();
        }

        private void assertPigLatin(string actual, string translated)
        {
            Assert.AreEqual(translated, pl.translate(actual));
        }

        [Test]
        public void translateToPigLatin()
        {
            assertPigLatin(null, "");
            assertPigLatin("", "");
            assertPigLatin("x", "xay");
            assertPigLatin(" x  ", "xay");
            assertPigLatin("at", "taay");
            assertPigLatin("hello", "ellohay");
            assertPigLatin("at home", "taay omehay");
            assertPigLatin("the quick brown fox", "hetay uickqay rownbay oxfay");
        }
    }
}
