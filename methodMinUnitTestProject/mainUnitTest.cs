using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using programForUnitTest;

namespace methodMinUnitTestProject
{
    [TestClass]
    public class mainUnitTest
    {
        [TestMethod]
        public void minTest796Returned6()
        {
            int min = Program.min(7, 9, 6);
            Assert.AreEqual(6, min);
        }

        [TestMethod]
        public void minTest000Returned0()
        {
            int min = Program.min(0, 0, 0);
            Assert.AreEqual(0, min);
        }

        [TestMethod]
        public void minTestNegativeNumbers754Returned7()
        {
            int min = Program.min(-7, -5, -4);
            Assert.AreEqual(-7, min);
        }
    }
}
