namespace StardustDL.Algorithms.Graphs
{
    public interface IEdge<TVertex>
    {
        TVertex From { get; }

        TVertex To { get; }
    }
}
