using System;

namespace StardustDL.Algorithms.Graphs
{
    public class Edge<TVertex> : IEdge<TVertex>
    {
        public Edge(in TVertex from, in TVertex to)
        {
            From = from;
            To = to;
        }

        public TVertex From { get; }

        public TVertex To { get; }
    }
}
