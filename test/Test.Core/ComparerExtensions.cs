using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using StardustDL.Algorithms;
using System;

namespace Test.Core
{
    [TestClass]
    public class ComparerExtensions
    {
        readonly Random rand = new Random();

        [TestMethod]
        public void Semantics()
        {
            var comparer = Comparer<int>.Default;
            for (int i = 0; i < 10; i++)
            {
                int x = rand.Next(), y = rand.Next();
                Assert.AreEqual(x < y, comparer.Smaller(x, y));
                Assert.AreEqual(x <= y, comparer.SmallerEqual(x, y));
                Assert.AreEqual(x > y, comparer.Larger(x, y));
                Assert.AreEqual(x >= y, comparer.LargerEqual(x, y));
            }
        }

        [TestMethod]
        public void Convert()
        {
            var comparer = Comparer<int>.Default;
            {
                var inv = comparer.ToInverse();
                for (int i = 0; i < 10; i++)
                {
                    int x = rand.Next(), y = rand.Next();
                    Assert.AreNotEqual(x < y, inv.Smaller(x, y));
                    Assert.AreNotEqual(x <= y, inv.SmallerEqual(x, y));
                    Assert.AreNotEqual(x > y, inv.Larger(x, y));
                    Assert.AreNotEqual(x >= y, inv.LargerEqual(x, y));
                }
            }
            {
                var eq = comparer.ToEqualityComparer(x => x);
                for (int i = 0; i < 10; i++)
                {
                    int x = rand.Next(3), y = rand.Next(3);
                    Assert.AreEqual(x == y, eq.Equals(x, y));
                }
            }
        }
    }
}
