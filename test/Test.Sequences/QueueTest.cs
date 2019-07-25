using Microsoft.VisualStudio.TestTools.UnitTesting;
using StardustDL.Algorithms.Sequences;
using System;
using System.Linq;

namespace Test.Sequences
{
    [TestClass]
    public class QueueTest
    {
        [DataTestMethod]
        [DataRow(typeof(Queue<int>))]
        [DataRow(typeof(Deque<int>))]
        public void Generic(Type type)
        {
            var S = (IQueue<int>)Activator.CreateInstance(type);
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
            var q1 = new System.Collections.Generic.Queue<int>();
            IQueue<int> q2 = new StardustDL.Algorithms.Sequences.Queue<int>();
            int n = 100;
            var rand = new Random();
            foreach (int t in Enumerable.Range(0, n))
            {
                int v = rand.Next();
                q1.Enqueue(v);
                q2.Enqueue(v);
                Assert.AreEqual(q1.Peek(), q2.Front);
            }

            foreach (int t in Enumerable.Range(0, n))
                Assert.AreEqual(q1.Dequeue(), q2.Dequeue());
        }

        [TestMethod]
        public void Deque()
        {
            var q2 = new Deque<int>();
            q2.Enqueue(1);
            q2.Enqueue(2);
            q2.EnqueueHead(3);
            Assert.AreEqual(q2.Dequeue(), 3);
            q2.EnqueueHead(4);
            Assert.AreEqual(q2.DequeueTail(), 2);
            Assert.AreEqual(q2.DequeueTail(), 1);
            Assert.AreEqual(q2.Dequeue(), 4);
        }

        [TestMethod]
        public void MonotoneQueue()
        {
            int[] list = new int[] { 1, 5, 3, 7, 9 };
            var q = new MonotoneQueue<int>();
            foreach (int v in list)
                q.Enqueue(v);
            Assert.AreEqual(q.Dequeue(), 1);
            Assert.AreEqual(q.Dequeue(), 3);
            Assert.AreEqual(q.Dequeue(), 7);
            Assert.AreEqual(q.Dequeue(), 9);
            Assert.AreEqual(q.Count, 0);
        }

    }
}
