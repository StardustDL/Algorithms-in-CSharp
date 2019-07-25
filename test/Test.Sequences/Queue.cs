using Microsoft.VisualStudio.TestTools.UnitTesting;
using StardustDL.Algorithms.Sequences;
using System;

namespace Test.Sequences
{
    [TestClass]
    public class Queue
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
    }
}
