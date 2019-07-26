using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace Test.Core
{
    [TestClass]
    public class UtilityTest
    {
        readonly Random rand = new Random();

        [TestMethod]
        public void Swap()
        {
            {
                var (a, b) = (1, 2);
                StardustDL.Algorithms.Utility.Swap(ref a, ref b);
                Assert.AreEqual(2, a);
                Assert.AreEqual(1, b);
            }
            {
                List<int> lst = new List<int> { 1, 2 };
                StardustDL.Algorithms.Utility.Swap(lst, 0, 1);
                CollectionAssert.AreEqual(new[] { 2, 1 }, lst);
            }
            {
                Dictionary<int, int> lst = new Dictionary<int, int>
                {
                    [0] = 1,
                    [1] = 2,
                };
                StardustDL.Algorithms.Utility.Swap(lst, 0, 1);
                Assert.AreEqual(2, lst[0]);
                Assert.AreEqual(1, lst[1]);
            }
        }
    }
}
