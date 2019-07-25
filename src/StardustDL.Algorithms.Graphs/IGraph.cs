using System.Collections.Generic;

namespace StardustDL.Algorithms.Graphs
{
    public interface IGraph<TVertex, TEdge> where TEdge : IEdge<TVertex>
    {
        ICollection<TVertex> Vertexs { get; }

        ICollection<TEdge> Edges { get; }
    }
}
