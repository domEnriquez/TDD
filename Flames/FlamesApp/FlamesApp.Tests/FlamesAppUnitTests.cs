using FlamesApp.Extensions;
using NUnit.Framework;

namespace FlamesApp.Tests
{
    [TestFixture]
    public class FlamesAppUnitTests
    {

        private Flames f;

        [SetUp]
        public void Setup()
        {
            f = new Flames();
        }


        [Test]
        public void removeSimilarLettersInNames()
        {
            string name1 = "dominic";
            string name2 = "jeanne";

            string editName1 = name1.RemoveSimilarLettersWith(name2);
            string editName2 = name2.RemoveSimilarLettersWith(name1);

            Assert.AreEqual("domiic", editName1);
            Assert.AreEqual("jeae", editName2);
            Assert.AreEqual(10, editName1.Length + editName2.Length);
        }

        [Test]
        public void returnEmptyStringWhenInputsAreTwoSimilarNames()
        {
            string name1 = "Dominic";
            string name2 = "Dominic";

            string result = f.execute(name1, name2);

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void marriageResult()
        {
            string name1 = "dominic";
            string name2 = "jeanne";

            string result = f.execute(name1, name2);

            Assert.AreEqual("Marriage", result);
        }

        [Test]
        public void friendsResult()
        {
            string name1 = "dom";
            string name2 = "nail";

            string result = f.execute(name1, name2);

            Assert.AreEqual("Friends", result);
        }

        [Test]
        public void loversResult()
        {
            string name1 = "dom";
            string name2 = "nailg";

            string result = f.execute(name1, name2);

            Assert.AreEqual("Lovers", result);
        }

        [Test]
        public void enemyResult()
        {
            string name1 = "dominic";
            string name2 = "jeannes";

            string result = f.execute(name1, name2);

            Assert.AreEqual("Enemy", result);
        }

        [Test]
        public void angerResult()
        {
            string name1 = "dami";
            string name2 = "lanodim";

            string result = f.execute(name1, name2);

            Assert.AreEqual("Anger", result);
        }

        [Test]
        public void soulmatesResult()
        {
            string name1 = "damiwet";
            string name2 = "lanodim";

            string result = f.execute(name1, name2);

            Assert.AreEqual("Soulmates", result);
        }

    }
}
