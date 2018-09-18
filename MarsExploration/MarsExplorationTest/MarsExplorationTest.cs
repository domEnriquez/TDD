using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsExplorationTest
{
    [TestFixture]
    public class MarsExplorationTest
    {
        private void assertCountAlteredLetters(string str, int exp)
        {
            Assert.AreEqual(exp, countAlteredLetters(str), "Failed: " + str);
        }

        [Test]
        public void nothing()
        {
            assertCountAlteredLetters(string.Empty, 0);
            assertCountAlteredLetters(null, 0);
            assertCountAlteredLetters("SOS", 0);
            assertCountAlteredLetters("AOS", 1);
            assertCountAlteredLetters("ABS", 2);
            assertCountAlteredLetters("SOSSOS", 0);
            assertCountAlteredLetters("SOSSOA", 1);
            assertCountAlteredLetters("SOSAOA", 2);
            assertCountAlteredLetters("ABCDEF", 6);
            assertCountAlteredLetters("AODCSA", 5);
        }

        private int countAlteredLetters(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            return countNotS(str) + countNotO(str);
        }

        private static int countNotS(string str)
        {
            int counter = 0;
            int inc = 2;

            for (int i = 0; i < str.Length; i += inc)
            {
                if (str[i] != 'S')
                    counter++;

                if (i != 0)
                    inc = oneOrTwo(inc);
            }

            return counter;
        }

        private static int oneOrTwo(int inc)
        {
            if (inc == 2)
                inc = 1;
            else inc = 2;

            return inc;
        }

        private static int countNotO(string str)
        {
            int counter = 0;

            for (int i = 1; i < str.Length; i += 3)
                if (str[i] != 'O')
                    counter++;
            return counter;
        }


    }
}
