using Microsoft.VisualStudio.TestTools.UnitTesting;
using StardustDL.Algorithms.Sequences;
using System;

namespace Test.Sequences
{
    [TestClass]
    public class Stack
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
    }
}
