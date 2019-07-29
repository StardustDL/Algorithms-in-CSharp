using Microsoft.VisualStudio.TestTools.UnitTesting;
using StardustDL.Algorithms.Graphs;
using System.Collections.Generic;

namespace Test.Graphs
{
    [TestClass]
    public class ShortPathTest
    {
        [TestMethod]
        public void Basic()
        {
            static void check(IReadOnlyDictionary<int,double> res)
            {
                Assert.AreEqual(0, res[1]);
                Assert.AreEqual(2, res[2]);
                Assert.AreEqual(4, res[3]);
                Assert.AreEqual(3, res[4]);
            }

            IGraph<int, WeightedEdge<int>> G = new DirectedGraph<int, WeightedEdge<int>>();
            {
                G.Vertexes.Add(1);
                G.Vertexes.Add(2);
                G.Vertexes.Add(3);
                G.Vertexes.Add(4);
                G.Edges.Add(new WeightedEdge<int>(1, 2, 2));
                G.Edges.Add(new WeightedEdge<int>(2, 3, 2));
                G.Edges.Add(new WeightedEdge<int>(2, 4, 1));
                G.Edges.Add(new WeightedEdge<int>(1, 3, 5));
                G.Edges.Add(new WeightedEdge<int>(3, 4, 3));
                G.Edges.Add(new WeightedEdge<int>(1, 4, 4));
            }
            check(ShortPath.SingleSourceSparseWithPositiveWeight(G, WeightedEdge<int>.WeightFunc, 1));
            check(ShortPath.SingleSourceDenseWithPositiveWeight(G, WeightedEdge<int>.WeightFunc, 1));
            check(ShortPath.SingleSource(G, WeightedEdge<int>.WeightFunc, 1));
            check(ShortPath.MultiSource(G, WeightedEdge<int>.WeightFunc, 1)[1]);
        }
    }
}
