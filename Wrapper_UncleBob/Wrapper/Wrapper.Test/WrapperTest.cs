using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrapper.Test
{
    [TestFixture]
    public class WrapperTest
    {
        private void assertWrap(string s, int width, string expected)
        {
            Assert.AreEqual(expected, wrap(s, width));
        }

        [Test]
        public void shouldWrap()
        {
            assertWrap(null, 1, "");
            assertWrap("", 1, "");
            assertWrap("x", 1, "x");
            assertWrap("xx", 1, "x\r\nx");
            assertWrap("xxx", 1, "x\r\nx\r\nx");
            assertWrap("x x", 1, "x\r\nx");
            assertWrap("x xx", 3, "x\r\nxx");
        }

        private string wrap(string s, int width)
        {
            if (s == null)
                return "";

            if (s.Count() <= width)
                return s;
            else
            {
                int breakPoint = s.LastIndexOf(' ', width);
                if (breakPoint == -1)
                    breakPoint = width;
                return s.Substring(0, breakPoint) + "\r\n" + wrap(s.Substring(breakPoint).Trim(), width);
            }

        }
    }
}
