using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDemo.VSTSTest
{
    /// <summary>
    /// Summary description for LogonInfo
    /// </summary>
    [TestClass]
    public class LogonInfoTest
    {
        private string _userId;
        private string _password;

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        
         //Use TestInitialize to run code before running each test 
         [TestInitialize()]
         public void MyTestInitialize()
         {
             _userId = "Jim";
             _password = "P@ssw0rd";
         }
        
         //Use TestCleanup to run code after each test has run
         [TestCleanup()]
         public void MyTestCleanup()
         {
             _userId = String.Empty;
             _password = String.Empty;
         }
        
        #endregion

        /// <summary>
        /// A test for testing the constructor of LogonInfo class
        /// </summary>
        [TestMethod]
        public void LogonConstructorTest()
        {
            LogonInfo logonInfo = new LogonInfo(_userId, _password);

            Assert.AreEqual<string>(_userId, logonInfo.UserId,
               "The UserId was not correctly initialized.");
            Assert.AreEqual<string>(_password, logonInfo.Password,
               "The Password was not correctly initialized.");
        }

        /// <summary>
        /// A test for testing null userid passed into LogonInfo
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
         "A userId of null was inappropriately allowed.")]
        public void NullUserIdPassedTest()
        {
            LogonInfo logonInfo = new LogonInfo(null, "P@ss0word");
        }

        /// <summary>
        /// A test for testing empty userid passed into LogonInfo
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
         "A empty userId was inappropriately allowed.")]
        public void EmptyUserPassedTest()
        {
            LogonInfo logonInfo = new LogonInfo(null, "P@ss0word");
        }

        /// <summary>
        /// A test for updating the given user's password
        /// </summary>
        [TestMethod]
        public void UpdatePasswordTest()
        {
            string newPassword = "P2ssw0rd";

            LogonInfo logonInfo = new LogonInfo(_userId, _password);
            logonInfo.UpdatePassword(newPassword);

            Assert.AreEqual<string>(newPassword, logonInfo.Password);
        }

        [TestMethod]
        [Ignore]
        public void IgnoreTest()
        {
            string newPassword = "P2ssw0rd";

            LogonInfo logonInfo = new LogonInfo(_userId, _password);
            logonInfo.UpdatePassword(newPassword);

            Assert.AreEqual<string>(newPassword, logonInfo.Password);
        }
    }
}
