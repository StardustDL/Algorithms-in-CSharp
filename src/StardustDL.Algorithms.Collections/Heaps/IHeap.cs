namespace StardustDL.Algorithms.Collections.Heaps
{
    public interface IHeap<T>
    {
        int Count { get; }

        void Clear();

        void Push(in T val);

        T Top { get; }

        T Pop();
    }
}
