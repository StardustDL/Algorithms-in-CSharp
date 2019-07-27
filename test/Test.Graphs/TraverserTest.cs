using Microsoft.VisualStudio.TestTools.UnitTesting;
using StardustDL.Algorithms;
using StardustDL.Algorithms.Graphs;
using System.Collections;
using System.Linq;

namespace Test.Graphs
{
    [TestClass]
    public class TraverserTest
    {
        IGraph<int, Edge<int>> GetSampleGraph()
        {
            var graph = new DirectedGraph<int, Edge<int>>();
            graph.Vertexes.Add(0);
            graph.Vertexes.Add(1);
            graph.Vertexes.Add(2);
            graph.Vertexes.Add(3);
            graph.Edges.Add(new Edge<int>(0, 1));
            graph.Edges.Add(new Edge<int>(1, 2));
            graph.Edges.Add(new Edge<int>(0, 3));
            return graph;
        }

        [TestMethod]
        public void Depth()
        {
            var graph = GetSampleGraph();
            var res = Traverser.DepthFirst(graph).ToList();
            CollectionAssert.AreEquivalent(graph.Vertexes.ToArray(), res);
            Assert.IsTrue(res.IndexOf(1) + 1 == res.IndexOf(2));
        }

        [TestMethod]
        public void Breadth()
        {
            var graph = GetSampleGraph();
            var res = Traverser.BreadthFirst(graph).ToList();
            CollectionAssert.AreEquivalent(graph.Vertexes.ToArray(), res);
            Assert.IsFalse(res.IndexOf(1) + 1 == res.IndexOf(2));
        }

        [TestMethod]
        public void Toposort()
        {
            var graph = GetSampleGraph();
            var res = Traverser.TopologicalOrder(graph).ToList();
            CollectionAssert.AreEquivalent(graph.Vertexes.ToArray(), res);
            Assert.IsTrue(res.IndexOf(0) < res.IndexOf(1));
            Assert.IsTrue(res.IndexOf(0) < res.IndexOf(2));
            Assert.IsTrue(res.IndexOf(0) < res.IndexOf(3));
            Assert.IsTrue(res.IndexOf(1) < res.IndexOf(2));
        }
    }
}
