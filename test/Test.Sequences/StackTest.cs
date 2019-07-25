using Microsoft.VisualStudio.TestTools.UnitTesting;
using StardustDL.Algorithms.Sequences;
using System;
using System.Linq;

namespace Test.Sequences
{
    [TestClass]
    public class StackTest
    {
        [DataTestMethod]
        [DataRow(typeof(Stack<int>))]
        public void Generic(Type type)
        {
            var S = (IStack<int>)Activator.CreateInstance(type);
            S.Clear();
            Assert.AreEqual(0, S.Count);
            S.Push(1);
            Assert.AreEqual(1, S.Count);
            Assert.AreEqual(1, S.Top);
            Assert.AreEqual(1, S.Pop());
            Assert.AreEqual(0, S.Count);
        }

        [TestMethod]
        public void Stack()
        {
            var q1 = new System.Collections.Generic.Stack<int>();
            IStack<int> q2 = new StardustDL.Algorithms.Sequences.Stack<int>();
            int n = 100;
            var rand = new Random();
            foreach (int t in Enumerable.Range(0, n))
            {
                int v = rand.Next();
                q1.Push(v);
                q2.Push(v);
                Assert.AreEqual(q1.Peek(), q2.Top);
            }

            foreach (int t in Enumerable.Range(0, n))
                Assert.AreEqual(q1.Pop(), q2.Pop());
        }
    }
}
