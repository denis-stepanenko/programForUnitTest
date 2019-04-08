using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using programForUnitTest;

namespace methodMinUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void methodMinTest()
        {
            int min = Program.min(7, 9, 6);
            Assert.AreEqual(6, min);
        }
    }
}
