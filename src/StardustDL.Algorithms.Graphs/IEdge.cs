namespace StardustDL.Algorithms.Graphs
{
    public interface IEdge<TVertex>
    {
        TVertex From { get; }

        TVertex To { get; }
    }

    public delegate double WeightEdgeFunc<TVertex, in TEdge>(TEdge edge) where TEdge : IEdge<TVertex>;
}
