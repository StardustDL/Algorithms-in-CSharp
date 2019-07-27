using Microsoft.VisualStudio.TestTools.UnitTesting;
using StardustDL.Algorithms.Graphs;

namespace Test.Graphs
{
    [TestClass]
    public class SpanningTreeTest
    {
        [TestMethod]
        public void Minimum()
        {
            IGraph<int, WeightedEdge<int>> G = new DirectedGraph<int, WeightedEdge<int>>();
            {
                G.Vertexes.Add(1);
                G.Vertexes.Add(2);
                G.Vertexes.Add(3);
                G.Edges.Add(new WeightedEdge<int>(1, 2, 1));
                G.Edges.Add(new WeightedEdge<int>(1, 3, 1));
                G.Edges.Add(new WeightedEdge<int>(2 ,3, 2));
            }
            Assert.AreEqual(2, SpanningTree.MinimumByKruskal(G, WeightedEdge<int>.WeightFunc, out var edges));
            Assert.AreEqual(2, edges.Count);
        }
    }
}
