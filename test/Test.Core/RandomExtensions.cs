using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using StardustDL.Algorithms;

namespace Test.Core
{
    [TestClass]
    public class RandomExtensions
    {
        readonly Random rand = new Random();

        [TestMethod]
        public void Generator()
        {
            int cntTrue = 0, n = 1000;
            for (int i = 0; i < n; i++)
                cntTrue += rand.NextBoolean() ? 1 : 0;
            Assert.IsTrue(Math.Abs(n - 2 * cntTrue) <= 0.1 * n);
        }

        [TestMethod]
        public void Sequence()
        {
            List<int> lst = new List<int>();
            for (int i = 0; i < 10; i++) lst.Add(i);
            for (int i = 0; i < 10; i++)
            {
                int val = rand.Choice(lst);
                Assert.IsTrue(val >= 0 && val < 10);
                if (val < 5)
                    rand.Shuffle(lst);
            }
        }
    }
}
