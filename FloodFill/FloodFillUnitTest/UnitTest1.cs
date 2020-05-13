using Microsoft.VisualStudio.TestTools.UnitTesting;
using FloodFill;

namespace FloodFillUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution FloodFill = new Solution();
            int[][] image = {
                new int[] { 1, 1, 1 },
                new int[] { 1, 1, 0 },
                new int[] { 1, 0, 1 }
            };
            int sr = 1;
            int sc = 1;
            int newColor = 2;

            int[][] expected = {
                new int[] { 2, 2, 2 },
                new int[] { 2, 2, 0 },
                new int[] { 2, 0, 1 }
            };

            int[][] result = FloodFill.FloodFill(image, sr, sc, newColor);

            for (int j = 0; j < result.Length; j += 1)
            {
                for (int k = 0; k < result[j].Length; k += 1)
                {
                    Assert.AreEqual(expected[j][k], result[j][k]);
                }
            }

        }
    }
}
