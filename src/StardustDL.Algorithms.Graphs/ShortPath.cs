using StardustDL.Algorithms.Collections.Heaps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StardustDL.Algorithms.Graphs
{
    public static class ShortPath
    {
        // Dijkstra with heap optimize
        public static IReadOnlyDictionary<TVertex, double> SingleSourceSparseWithPositiveWeight<TVertex, TEdge>(in IGraph<TVertex, TEdge> graph, WeightEdgeFunc<TVertex, TEdge> weight, in TVertex source) where TEdge : IEdge<TVertex> where TVertex : notnull
        {
            Dictionary<TVertex, double> result = new Dictionary<TVertex, double>
            {
                { source, 0 }
            };
            var q = new PriorityQueue<(double, TVertex)>(Comparer<(double, TVertex)>.Create((x, y) => x.Item1.CompareTo(y.Item1)));
            q.Enqueue((result[source], source));
            while (q.Count > 0)
            {
                var (d, u) = q.Dequeue();
                if (result[u] < d) continue;
                foreach (TEdge edge in graph.GetAdjacentEdges(u))
                {
                    double len = d + weight(edge);
                    bool y = false;
                    if (result.TryGetValue(edge.To, out var oldLen))
                    {
                        if (oldLen > len)
                        {
                            result[edge.To] = len;
                            y = true;
                        }
                    }
                    else
                    {
                        result.Add(edge.To, len);
                        y = true;
                    }
                    if (y) q.Enqueue((len, edge.To));
                }
            }
            return result;
        }

        // naive Dijkstra
        public static IReadOnlyDictionary<TVertex, double> SingleSourceDenseWithPositiveWeight<TVertex, TEdge>(in IGraph<TVertex, TEdge> graph, WeightEdgeFunc<TVertex, TEdge> weight, in TVertex source) where TEdge : IEdge<TVertex> where TVertex : notnull
        {
            var result = new Dictionary<TVertex, double>
            {
                { source, 0 }
            };
            var remain = graph.Vertexes.ToHashSet();
            foreach (var _ in Enumerable.Range(0, graph.Vertexes.Count - 1))
            {
                object? cur = null;
                foreach (var v in remain)
                {
                    if (cur == null)
                    {
                        if (result.ContainsKey(v))
                            cur = v;
                    }
                    else
                    {
                        if (result.TryGetValue(v, out var len) && len < result[(TVertex)cur!])
                        {
                            cur = v;
                        }
                    }
                }
                if (cur == null) break;
                foreach (var edge in graph.GetAdjacentEdges((TVertex)cur!))
                {
                    double len = result[edge.From] + weight(edge);
                    if (result.TryGetValue(edge.To, out var oldLen))
                    {
                        if (oldLen > len)
                            result[edge.To] = len;
                    }
                    else
                    {
                        result.Add(edge.To, len);
                    }
                }
                remain.Remove((TVertex)cur!);
            }
            return result;
        }

        // Bellman-ford
        public static IReadOnlyDictionary<TVertex, double> SingleSource<TVertex, TEdge>(in IGraph<TVertex, TEdge> graph, WeightEdgeFunc<TVertex, TEdge> weight, in TVertex source) where TEdge : IEdge<TVertex> where TVertex : notnull
        {
            var result = new Dictionary<TVertex, double>
            {
                { source, 0 }
            };
            foreach (var _ in Enumerable.Range(0, graph.Vertexes.Count - 1))
            {
                foreach(var edge in graph.Edges)
                {
                    if (!result.TryGetValue(edge.From, out var dfrom)) continue;
                    double len = dfrom + weight(edge);
                    if(result.TryGetValue(edge.To,out var oldLen))
                    {
                        if (oldLen > len)
                            result[edge.To] = len;
                    }
                    else
                    {
                        result.Add(edge.To, len);
                    }
                }
            }
            return result;
        }

        // Floyd
        public static IReadOnlyDictionary<TVertex, IReadOnlyDictionary<TVertex, double>> MultiSource<TVertex, TEdge>(in IGraph<TVertex, TEdge> graph, WeightEdgeFunc<TVertex, TEdge> weight, in TVertex source) where TEdge : IEdge<TVertex> where TVertex : notnull
        {
            var result = new Dictionary<TVertex, Dictionary<TVertex, double>>();
            foreach (TVertex node in graph.Vertexes)
            {
                var dic = new Dictionary<TVertex, double>();
                foreach (TEdge edge in graph.GetAdjacentEdges(node))
                {
                    double len = weight(edge);
                    if (dic.TryGetValue(edge.To, out double oldLen))
                    {
                        if (oldLen > len)
                            dic[edge.To] = len;
                    }
                    else
                    {
                        dic.Add(edge.To, len);
                    }
                }
                if (dic.ContainsKey(node)) dic[node] = 0;
                else dic.Add(node, 0);
                result.Add(node, dic);
            }
            foreach (TVertex node in graph.Vertexes)
            {
                Dictionary<TVertex, double> dmid = result[node];
                foreach (TVertex s in graph.Vertexes)
                {
                    if (node.Equals(s)) continue;
                    Dictionary<TVertex, double> dic = result[s];
                    foreach (TVertex t in graph.Vertexes)
                    {
                        if (node.Equals(t) || s.Equals(t)) continue;
                        if (!dic.TryGetValue(node, out var dsnode)) continue;
                        if (!dmid.TryGetValue(t, out var dnodet)) continue;
                        double len = dsnode + dnodet;
                        if (dic.TryGetValue(t, out double oldLen))
                        {
                            if (oldLen > len)
                            {
                                dic[t] = len;
                            }
                        }
                        else dic.Add(t, len);
                    }
                }
            }
            return new Dictionary<TVertex, IReadOnlyDictionary<TVertex, double>>(result.Select(x => new KeyValuePair<TVertex, IReadOnlyDictionary<TVertex, double>>(x.Key, x.Value)));
        }
    }
}
