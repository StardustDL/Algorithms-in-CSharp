namespace StardustDL.Algorithms.Graphs
{
    public class WeightedEdge<TVertex> : Edge<TVertex>
    {
        public static readonly WeightEdgeFunc<TVertex, WeightedEdge<TVertex>> WeightFunc = e => e.Weight;

        public WeightedEdge(in TVertex from, in TVertex to, in double weight) : base(from, to)
        {
            Weight = weight;
        }

        public double Weight { get; }
    }
}
