using System.Collections.Generic;

namespace StardustDL.Algorithms.Graphs
{
    public interface IGraph<TVertex, TEdge> where TEdge : IEdge<TVertex> where TVertex : notnull
    {
        ICollection<TVertex> Vertexes { get; }

        ICollection<TEdge> Edges { get; }

        IEnumerable<TEdge> GetAdjacentEdges(in TVertex vertex);
    }
}
