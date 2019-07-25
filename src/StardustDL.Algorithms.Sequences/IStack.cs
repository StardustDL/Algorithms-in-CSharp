namespace StardustDL.Algorithms.Sequences
{
    public interface IStack<T>
    {
        int Count { get; }

        T Top { get; }

        void Push(in T value);

        T Pop();

        void Clear();
    }
}
