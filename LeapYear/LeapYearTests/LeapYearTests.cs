using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapYearTests
{
    [TestFixture]
    public class LeapYearTests
    {
        private void assertIsLeapYear(int year, bool exp)
        {
            Assert.AreEqual(exp, LeapYear.IsLeapYear(year));
        }

        [Test]
        public void canDetermineIfLeapYear()
        {
            assertIsLeapYear(0, false);
            assertIsLeapYear(4, true);
            assertIsLeapYear(1, false);
            assertIsLeapYear(40, true);
            assertIsLeapYear(100, false);
            assertIsLeapYear(104, true);
            assertIsLeapYear(200, false);
            assertIsLeapYear(400, true);
            assertIsLeapYear(1600, true);
            assertIsLeapYear(1700, false);
            assertIsLeapYear(1900, false);
            assertIsLeapYear(1996, true);
            assertIsLeapYear(2000, true);
            assertIsLeapYear(2001, false);
            assertIsLeapYear(2400, true);
            assertIsLeapYear(2600, false);
        }

    }
}
