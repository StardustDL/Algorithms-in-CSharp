using Microsoft.VisualStudio.TestTools.UnitTesting;
using StardustDL.Algorithms;
using StardustDL.Algorithms.Collections;
using StardustDL.Algorithms.Graphs;
using System.Linq;

namespace Test.Collections
{
    [TestClass]
    public class DisjointSetTest
    {
        [TestMethod]
        public void Basic()
        {
            var set = new DisjointSet<int>();
            set.Clear();
            foreach (int v in Enumerable.Range(1, 9)) set.Add(v);
            foreach (int x in Enumerable.Range(1, 9))
                foreach (int y in Enumerable.Range(1, 9))
                    Assert.IsFalse(x != y && set.IsUnited(x, y));
            set.Unite(1, 9);
            Assert.AreEqual(set.Count, 8);
            Assert.IsTrue(set.IsUnited(1, 9));
            set.Unite(2, 7);
            Assert.AreEqual(set.Count, 7);
            Assert.AreEqual(set.ElementCount, 9);
            set.Unite(7, 1);
            Assert.IsTrue(set.IsUnited(2, 9));
            Assert.IsFalse(set.IsUnited(2, 6));

            Assert.AreEqual(set.Count, 6);
            Assert.AreEqual(set.ElementCount, 9);
        }
    }
}
