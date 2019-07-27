using Microsoft.VisualStudio.TestTools.UnitTesting;
using StardustDL.Algorithms.Sequences;
using System;
using System.Linq;
using StardustDL.Algorithms;
using StardustDL.Algorithms.Collections.Heaps;

namespace Test.Sequences
{
    [TestClass]
    public class QueueTest
    {
        [DataTestMethod]
        [DataRow(typeof(Queue<int>))]
        [DataRow(typeof(Deque<int>))]
        [DataRow(typeof(MonotoneQueue<int>))]
        [DataRow(typeof(PriorityQueue<int>))]
        public void Generic(Type type)
        {
            IQueue<int> S = (IQueue<int>)Activator.CreateInstance(type);
            S.Clear();
            Assert.AreEqual(0, S.Count);
            S.Enqueue(1);
            Assert.AreEqual(1, S.Count);
            Assert.AreEqual(1, S.Front);
            Assert.AreEqual(1, S.Dequeue());
            Assert.AreEqual(0, S.Count);
        }

        [TestMethod]
        public void Queue()
        {
            System.Collections.Generic.Queue<int> q1 = new System.Collections.Generic.Queue<int>();
            IQueue<int> q2 = new Queue<int>();
            int n = 100;
            Random rand = new Random();
            foreach (int t in Enumerable.Range(0, n))
            {
                int v = rand.Next();
                q1.Enqueue(v);
                q2.Enqueue(v);
                Assert.AreEqual(q1.Peek(), q2.Front);
            }

            foreach (int t in Enumerable.Range(0, n))
            {
                Assert.AreEqual(q1.Dequeue(), q2.Dequeue());
            }
        }

        [TestMethod]
        public void Deque()
        {
            Deque<int> q2 = new Deque<int>();
            q2.Enqueue(1);
            q2.Enqueue(2);
            q2.EnqueueHead(3);
            Assert.AreEqual(3, q2.Dequeue());
            q2.EnqueueHead(4);
            Assert.AreEqual(2, q2.Last);
            Assert.AreEqual(2, q2.DequeueTail());
            Assert.AreEqual(1, q2.DequeueTail());
            Assert.AreEqual(4, q2.Dequeue());
        }

        [TestMethod]
        public void MonotoneQueue()
        {
            int[] list = new int[] { 1, 5, 3, 7, 9 };
            MonotoneQueue<int> q = new MonotoneQueue<int>();
            q.Clear();
            foreach (int v in list)
            {
                q.Enqueue(v);
            }

            Assert.AreEqual(1, q.Dequeue());
            Assert.AreEqual(3, q.Dequeue());
            Assert.AreEqual(7, q.Dequeue());
            Assert.AreEqual(9, q.Dequeue());
            Assert.AreEqual(0, q.Count);
        }
    }

    [TestClass]
    public class SparseTableTest
    {
        Random rand = new Random();

        [TestMethod]
        public void Base()
        {
            int n = 100;
            int[] seq = new int[n];
            rand.NextInts(seq);
            SparseTable<int> q1 = new SparseTable<int>(seq);
            int mini(int l, int r)
            {
                int ans = seq[l];
                for (int i = l + 1; i < r; i++) if (seq[i] < ans) ans = seq[i];
                return ans;
            }
            for (int i = 0; i < n; i++)
            {
                int l = rand.Next(n - 1);
                int r = rand.Next(l + 1, n);
                Assert.AreEqual(mini(l, r), q1[l..r]);
            }
        }
    }
}
