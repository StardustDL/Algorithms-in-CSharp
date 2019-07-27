using Microsoft.VisualStudio.TestTools.UnitTesting;
using StardustDL.Algorithms;
using StardustDL.Algorithms.Graphs;
using System;
using System.Linq;

namespace Test.Graphs
{
    [TestClass]
    public class GraphTest
    {
        Random rand = new Random();

        [DataTestMethod]
        [DataRow(typeof(DirectedGraph<int,Edge<int>>))]
        public void Generic(Type type)
        {
            var G = (IGraph<int,Edge<int>>)Activator.CreateInstance(type);
            G.Vertexes.Clear();
            G.Edges.Clear();
            int V = 10, E = 10;
            for(int i = 0; i < V; i++)
            {
                int v = i;
                G.Vertexes.Add(v);
                Assert.IsTrue(G.Vertexes.Contains(v));
            }
            Assert.AreEqual(V, G.Vertexes.Count);
            var vers = G.Vertexes.ToArray();
            for (int i = 0; i < E; i++)
            {
                Edge<int> edge = new Edge<int>(rand.Choice(vers), rand.Choice(vers));
                G.Edges.Add(edge);
                Assert.IsTrue(G.Edges.Contains(edge));
            }
            Assert.AreEqual(E, G.Edges.Count);
            for (int i = 0; i < V; i++)
            {
                int v = i;
                foreach(var e in G.GetAdjacentEdges(v).ToArray())
                {
                    Assert.IsTrue(G.Edges.Remove(e));
                }
                Assert.AreEqual(0, G.GetAdjacentEdges(v).Count());
                Assert.IsTrue(G.Vertexes.Remove(v));
            }
        }
    }
}
