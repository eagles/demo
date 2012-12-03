using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BubbleSort.Test
{
    /// <summary>
    ///This is a test class for BubbleSortV3Test and is intended
    ///to contain all BubbleSortV3Test Unit Tests
    ///</summary>
    [TestClass]
    public class BubbleSortV3Test
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
            BubbleSortV3 target = new BubbleSortV3(); 
            List<int> list = new List<int>(); 
            target.Init(list, 20);
            int low = 10;
            int high = 15; 
            List<int> actual;
            actual = target.Sort(list, low, high);

            // Verify if the list is ascending from low position to high position
            for (int i = low; i < (high - 1); i++)
            {
                Assert.IsTrue(actual[i] <= actual[i + 1]);
            }
        }

        /// <summary>
        ///A test for Sort
        ///</summary>
        [TestMethod()]
        public void SortTestWithoutRange()
        {
            BubbleSortV3 target = new BubbleSortV3();
            List<int> list = new List<int>();
            target.Init(list, 20);
 
            List<int> actual;
            actual = target.Sort(list);

            // Verify if the list is ascending from low position to high position
            for (int i = 0; i < list.Count - 1; i++)
            {
                Assert.IsTrue(actual[i] <= actual[i + 1]);
            }
        }
    }
}
