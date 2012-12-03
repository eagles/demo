using System;
using NUnit.Framework;

namespace TestDemo.NUnitTest
{
    [TestFixture]
    public class LogonInfoTest
    {
        private string _userId;
        private string _password;

        [SetUp]
        public void SetUp()
        {
            _userId = "Jim";
            _password = "P@ssw0rd";
        }

        [TearDown]
        public void TearDown()
        {
            _userId = String.Empty;
            _password = String.Empty;
        }

        /// <summary>
        /// A test for testing the constructor of LogonInfo class
        /// </summary>
        [Test]
        public void LogonConstructorTest()
        {
            LogonInfo logonInfo = new LogonInfo(_userId, _password);

            Assert.AreEqual(_userId, logonInfo.UserId,
               "The UserId was not correctly initialized.");
            Assert.AreEqual(_password, logonInfo.Password,
               "The Password was not correctly initialized.");
        }

        /// <summary>
        /// A test for testing null userid passed into LogonInfo
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void NullUserIdPassedTest()
        {
            LogonInfo logonInfo = new LogonInfo(null, "P@ss0word");
        }

        /// <summary>
        /// A test for testing empty userid passed into LogonInfo
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyUserPassedTest()
        {
            LogonInfo logonInfo = new LogonInfo("", "P@ss0word");
        }

        /// <summary>
        /// A test for updating the given user's password
        /// </summary>
        [Test]
        public void UpdatePasswordTest()
        {
            string newPassword = "P2ssw0rd";

            LogonInfo logonInfo = new LogonInfo(_userId, _password);
            logonInfo.UpdatePassword(newPassword);

            Assert.AreEqual(newPassword, logonInfo.Password);
        }

        [Test]
        [Ignore]
        public void IgnoredTest()
        {
            string newPassword = "P2ssw0rd";

            LogonInfo logonInfo = new LogonInfo(_userId, _password);
            logonInfo.UpdatePassword(newPassword);

            Assert.AreEqual(newPassword, logonInfo.Password);
        }
    }
}
