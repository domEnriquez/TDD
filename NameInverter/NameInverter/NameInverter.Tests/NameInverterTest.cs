using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NameInverter.Tests
{
    [TestFixture]
    public class NameInverterTest
    {
        private void assertInverted(string originalName, string invertedName)
        {
            Assert.AreEqual(invertedName, invertName(originalName));
        }

        [Test]
        public void givenNull_returnEmptyString()
        {
            assertInverted(null, "");
        }


        [Test]
        public void givenEmptyString_returnEmptyString()
        {
            assertInverted("", "");
        }

        [Test]
        public void givenSimpleName_returnSimpleName()
        {
            assertInverted("Name", "Name");
        }

        [Test]
        public void givenASimpleNameWithSpaces_returnSimpleNameWithoutSpaces()
        {
            assertInverted(" Name ", "Name");
        }

        [Test]
        public void givenFirstLast_returnLastFirst()
        {
            assertInverted("First Last", "Last, First");
        }

        [Test]
        public void givenFirstLastWithExtraSpaces_returnLastFirst()
        {
            assertInverted("  First  Last   ", "Last, First");
        }

        [Test]
        public void ignoreHonorifics()
        {
            assertInverted("Mr. First Last", "Last, First");
            assertInverted("Mrs. First Last", "Last, First");
        }

        [Test]
        public void postNominals_stayAtEnd()
        {
            assertInverted("First Last Sr.", "Last, First Sr.");
            assertInverted("First Last BS. Phd.", "Last, First BS. Phd.");
            assertInverted("First Last BS. MS. Phd.", "Last, First BS. MS. Phd.");
        }

        [Test]
        public void integration()
        {
            assertInverted("  Mr.  Dominic   Enriquez  BS.   MS.   Phd. ", "Enriquez, Dominic BS. MS. Phd.");
        }

        private string invertName(string name)
        {
            if (name == null || name.Length <= 0)
                return "";
             else
                return formatName(removeHonorifics(splitNames(name)));
            
        }

        private string formatName(List<string> names)
        {
            if (names.Count() == 1)
                return names[0];
            else
                return formatMultiElementName(names);
        }

        private string formatMultiElementName(List<string> names)
        {
            string lastName = names[1];
            string firstName = names[0];
            string postNominal = getPostNominals(names);
            return string.Format("{0}, {1} {2}", names[1], names[0], postNominal).Trim();
        }

        private static string getPostNominals(List<string> names)
        {
            string postNominal = "";
            if (names.Count() > 2)
            {
                List<string> postNominals = names.GetRange(2, names.Count() - 2);
                foreach (string pn in postNominals)
                    postNominal += pn + " ";
            }

            return postNominal;
        }

        private List<string> removeHonorifics(List<string> names)
        {
            if (names.Count() > 1 && isHonorific(names[0]))
                names.RemoveAt(0);

            return names;
        }

        private static List<string> splitNames(string name)
        {
            return Regex.Split(name.Trim(), @"\s+").ToList();
        }

        private static bool isHonorific(string word)
        {
            return Regex.IsMatch(word, @"\b(Mr|Mrs)\b");
        }

    }
}
