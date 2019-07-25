namespace StardustDL.Algorithms.Sequences
{
    public interface IQueue<T>
    {
        int Count { get; }

        T Front { get; }

        void Enqueue(in T value);

        T Dequeue();

        void Clear();
    }
}
