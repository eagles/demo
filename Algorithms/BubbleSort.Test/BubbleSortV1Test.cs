using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BubbleSort.Test
{
    /// <summary>
    ///This is a test class for BubbleSortV1Test and is intended
    ///to contain all BubbleSortV1Test Unit Tests
    ///</summary>
    [TestClass]
    public class BubbleSortV1Test
    {
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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for Sort
        ///</summary>
        [TestMethod()]
        public void SortTest()
        {
            BubbleSortV1 target = new BubbleSortV1();
            int[] list = {1, 2, 6, 5, 4, 7};
            int[] expected = { 1, 2, 4, 5, 6, 7 };
            int[] actual;
            actual = target.Sort(list);
            Assert.AreEqual<string>(expected.ToString(), actual.ToString());
        }
    }
}
