using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindJudge;

namespace FindJudgeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution FindJudge = new Solution();
            
            int n = 2;

            int[][] trust = new int[][]
            {
                new int[] {1,2}
            };

            Assert.AreEqual(2, FindJudge.FindJudge(n, trust));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution FindJudge = new Solution();
            
            int n = 3;

            int[][] trust = new int[][]
            {
                new int[] {1,3},
                new int[] {2,3}
            };

            Assert.AreEqual(3, FindJudge.FindJudge(n, trust));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution FindJudge = new Solution();
            int n = 3;

            int[][] trust = new int[][]
            {
                new int[] {1,3},
                new int[] {2,3},
                new int[] {3,1}
            };

            Assert.AreEqual(-1, FindJudge.FindJudge(n, trust));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution FindJudge = new Solution();
            int n = 3;

            int[][] trust = new int[][]
            {
                new int[] {1,2},
                new int[] {2,3}
            };

            Assert.AreEqual(-1, FindJudge.FindJudge(n, trust));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution FindJudge = new Solution();
            int n = 4;

            int[][] trust = new int[][]
            {
                new int[] {1,3},
                new int[] {1,4},
                new int[] {2,3},
                new int[] {2,4},
                new int[] {4,3}
            };

            Assert.AreEqual(3, FindJudge.FindJudge(n, trust));
        }
    }
}
