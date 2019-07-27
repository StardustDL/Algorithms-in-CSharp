using System.Collections.Generic;

namespace StardustDL.Algorithms.Sequences
{
    public class MonotoneQueue<T> : IQueue<T>
    {
        private readonly Deque<T> queue = new Deque<T>();
        private readonly IComparer<T> comparer;

        public int Count => queue.Count;

        public MonotoneQueue(IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public MonotoneQueue() : this(null) { }

        public T Dequeue()
        {
            return queue.Dequeue();
        }

        public void Enqueue(in T value)
        {
            while (queue.Count > 0 && comparer.Larger(queue.Last, value))
            {
                queue.DequeueTail();
            }

            queue.Enqueue(value);
        }

        public T Front => queue.Front;

        public void Clear()
        {
            queue.Clear();
        }
    }
}
