using System.Collections.Generic;

namespace StardustDL.Algorithms.Graphs
{
    public static class Traverser
    {
        public static IEnumerable<TVertex> DepthFirst<TVertex, TEdge>(IGraph<TVertex, TEdge> graph) where TEdge : IEdge<TVertex> where TVertex : notnull
        {
            var vis = new HashSet<TVertex>();
            foreach (TVertex vertex in graph.Vertexes)
            {
                if (vis.Contains(vertex)) continue;
                foreach (TVertex s in dfs(vertex)) yield return s;
            }

            IEnumerable<TVertex> dfs(TVertex u)
            {
                vis.Add(u);
                yield return u;
                foreach (TEdge e in graph.GetAdjacentEdges(u))
                {
                    if (vis.Contains(e.To)) continue;
                    foreach (TVertex to in dfs(e.To)) yield return to;
                }
            }
        }

        public static IEnumerable<TVertex> BreadthFirst<TVertex, TEdge>(IGraph<TVertex, TEdge> graph) where TEdge : IEdge<TVertex> where TVertex : notnull
        {
            var q = new Queue<TVertex>();
            var vis = new HashSet<TVertex>();
            foreach (TVertex vertex in graph.Vertexes)
            {
                if (vis.Contains(vertex)) continue;
                appendVertex(vertex);
                while (q.Count > 0)
                {
                    TVertex u = q.Dequeue();
                    yield return u;
                    foreach (TEdge e in graph.GetAdjacentEdges(u))
                    {
                        if (vis.Contains(e.To)) continue;
                        appendVertex(e.To);
                    }
                }
            }

            void appendVertex(in TVertex vertex)
            {
                q.Enqueue(vertex);
                vis.Add(vertex);
            }
        }

        public static IEnumerable<TVertex> TopologicalOrder<TVertex, TEdge>(IGraph<TVertex, TEdge> graph) where TEdge : IEdge<TVertex> where TVertex : notnull
        {
            var degrees = new Dictionary<TVertex, int>();
            var q = new Queue<TVertex>();
            foreach (TVertex vertex in graph.Vertexes) degrees.Add(vertex, 0);
            foreach (TEdge edge in graph.Edges)
                degrees[edge.To]++;
            foreach (KeyValuePair<TVertex, int> v in degrees)
                if (v.Value == 0) q.Enqueue(v.Key);
            while (q.Count > 0)
            {
                TVertex u = q.Dequeue();
                yield return u;
                foreach (TEdge e in graph.GetAdjacentEdges(u))
                {
                    if (degrees[e.To] > 0 && --degrees[e.To] == 0)
                        q.Enqueue(e.To);
                }
            }
            //No exception judge
        }
    }
}
