using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsPerfectSquare;

namespace IsPerfectSquareUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution IsPerfectSquare = new Solution();
            Assert.AreEqual(true, IsPerfectSquare.IsPerfectSquare(16));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution IsPerfectSquare = new Solution();
            Assert.AreEqual(false, IsPerfectSquare.IsPerfectSquare(14));
        }
    }
}
