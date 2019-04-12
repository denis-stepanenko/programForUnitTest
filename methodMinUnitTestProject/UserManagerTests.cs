using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace programForUnitTest.Tests
{
    [TestClass]
    public class UserManagerTests
    {
        public TestContext TestContext { get; set; }
        UserManager manager = new UserManager();

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", 
            "TestData.xml", 
            "User", 
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void Add_FromXML()
        {
            // Arrange
            string username = (string)TestContext.DataRow["username"];
            string phone = (string)TestContext.DataRow["phone"];
            string email = (string)TestContext.DataRow["email"];

            // Act
            try
            {
                manager.Add(username, phone, email);
            } 
            //Assert
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
