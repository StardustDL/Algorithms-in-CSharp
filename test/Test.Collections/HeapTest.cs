using Microsoft.VisualStudio.TestTools.UnitTesting;
using StardustDL.Algorithms;
using StardustDL.Algorithms.Collections.Heaps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Collections
{
    [TestClass]
    public class HeapTest
    {
        Random rand = new Random();

        [DataTestMethod]
        [DataRow(typeof(BinaryHeap<int>))]
        [DataRow(typeof(LeftistTree<int>))]
        public void Generic(Type type)
        {
            var heap = (IHeap<int>)Activator.CreateInstance(type);
            int length = 1000;
            int[] list = new int[length];
            rand.NextInts(list);
            var count = new SortedDictionary<int, int>();
            var set = new SortedSet<int>();
            foreach (int v in list.Take(length / 2))
            {
                if (set.Contains(v)) count[v]++;
                else
                {
                    count.Add(v, 1);
                    set.Add(v);
                }
                heap.Push(v);
                Assert.AreEqual(set.Min, heap.Top, "push");
            }
            while (set.Count > 1)
            {
                if (count[set.Min] == 1)
                {
                    count.Remove(set.Min);
                    set.Remove(set.Min);
                }
                else
                {
                    count[set.Min]--;
                }
                heap.Pop();
                Assert.AreEqual(set.Min, heap.Top, "pop");
            }
            Assert.AreEqual(set.Min, heap.Top, "end");
            Assert.AreEqual(set.Count, heap.Count, "end");
        }
    }
}
