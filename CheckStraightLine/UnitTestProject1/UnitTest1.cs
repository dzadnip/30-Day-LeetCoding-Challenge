using CheckStraightLine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution Solution = new Solution();
            int[][] coordinates = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 4, 5 },
                new int[] { 5, 6 },
                new int[] { 6, 7 }
            };
            Assert.AreEqual(true, Solution.CheckStraightLine(coordinates));            
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution Solution = new Solution();
            int[][] coordinates = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, 2 },
                new int[] { 3, 4 },
                new int[] { 4, 5 },
                new int[] { 5, 6 },
                new int[] { 7, 7 }
            };
            Assert.AreEqual(false, Solution.CheckStraightLine(coordinates));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution Solution = new Solution();
            int[][] coordinates = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 4, 5 },
                new int[] { 5, 6 },
                new int[] { 6, 7 }
            };
            Assert.AreEqual(true, Solution.CheckStraightLine2(coordinates));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution Solution = new Solution();
            int[][] coordinates = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, 2 },
                new int[] { 3, 4 },
                new int[] { 4, 5 },
                new int[] { 5, 6 },
                new int[] { 7, 7 }
            };
            Assert.AreEqual(false, Solution.CheckStraightLine2(coordinates));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution Solution = new Solution();
            int[][] coordinates = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 4, 5 },
                new int[] { 5, 6 },
                new int[] { 6, 7 }
            };
            Assert.AreEqual(true, Solution.CheckStraightLine3(coordinates));
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution Solution = new Solution();
            int[][] coordinates = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, 2 },
                new int[] { 3, 4 },
                new int[] { 4, 5 },
                new int[] { 5, 6 },
                new int[] { 7, 7 }
            };
            Assert.AreEqual(false, Solution.CheckStraightLine3(coordinates));
        }
    }
}