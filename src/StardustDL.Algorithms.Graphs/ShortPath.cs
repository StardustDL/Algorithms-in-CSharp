using System;
using System.Collections.Generic;

namespace StardustDL.Algorithms.Graphs
{
    public static class ShortPath
    {
        // Dijkstra with heap optimize
        public static IReadOnlyDictionary<TVertex, double> SingleSourceSparseWithPositiveWeight<TVertex, TEdge>(in IGraph<TVertex, TEdge> graph, WeightEdgeFunc<TVertex, TEdge> weight, in TVertex source) where TEdge : IEdge<TVertex> where TVertex : notnull
        {
            throw new NotImplementedException();
        }

        // naive Dijkstra
        public static IReadOnlyDictionary<TVertex, double> SingleSourceDenseWithPositiveWeight<TVertex, TEdge>(in IGraph<TVertex, TEdge> graph, WeightEdgeFunc<TVertex, TEdge> weight, in TVertex source) where TEdge : IEdge<TVertex> where TVertex : notnull
        {
            throw new NotImplementedException();
        }

        // Bellman-ford
        public static IReadOnlyDictionary<TVertex, double> SingleSource<TVertex, TEdge>(in IGraph<TVertex, TEdge> graph, WeightEdgeFunc<TVertex, TEdge> weight, in TVertex source) where TEdge : IEdge<TVertex> where TVertex : notnull
        {
            throw new NotImplementedException();
        }

        // Floyd
        public static IReadOnlyDictionary<TVertex, double> MultiSource<TVertex, TEdge>(in IGraph<TVertex, TEdge> graph, WeightEdgeFunc<TVertex, TEdge> weight, in TVertex source) where TEdge : IEdge<TVertex> where TVertex : notnull
        {
            throw new NotImplementedException();
        }
    }
}
