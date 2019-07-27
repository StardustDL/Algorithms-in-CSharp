using StardustDL.Algorithms.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StardustDL.Algorithms.Graphs
{
    public static class SpanningTree
    {
        public static double MinimumByKruskal<TVertex, TEdge>(in IGraph<TVertex, TEdge> graph, WeightEdgeFunc<TVertex, TEdge> weight, out ISet<TEdge> selectedEdges) where TEdge : IEdge<TVertex> where TVertex : notnull
        {
            var set = new DisjointSet<TVertex>();
            selectedEdges = new HashSet<TEdge>();
            double res = 0;
            foreach (var ver in graph.Vertexes) set.Add(ver);
            foreach (TEdge edge in graph.Edges.OrderBy(x => weight(x)))
            {
                if (!set.IsUnited(edge.From, edge.To))
                {
                    res += weight(edge);
                    set.Unite(edge.From, edge.To);
                    selectedEdges.Add(edge);
                }
            }
            return res;
        }
    }
}
