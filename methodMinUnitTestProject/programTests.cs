using Microsoft.VisualStudio.TestTools.UnitTesting;
using programForUnitTest;

namespace programForUnitTest.Tests
{
    [TestClass]
    public class programTests
    {
        [TestMethod]
        public void min_796_6returned()
        {
            int expected = 6;
            int actual = Program.min(7, 9, 6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void min_000_0returned()
        {
            int expected = 0;
            int actual = Program.min(0, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void min_negative_numbers_754_7returned()
        {
            int expected = -7;
            int actual = Program.min(-7, -5, -4);

            Assert.AreEqual(expected, actual);
        }
    }
}
