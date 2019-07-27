using StardustDL.Algorithms.Sequences;
using System.Collections.Generic;

namespace StardustDL.Algorithms.Collections.Heaps
{
    public class PriorityQueue<T> : IQueue<T>
    {
        private readonly BinaryHeap<T> queue;

        public PriorityQueue(IComparer<T>? comparer = null)
        {
            queue = new BinaryHeap<T>(comparer ?? Comparer<T>.Default);
        }

        public PriorityQueue() : this(null) { }

        public int Count => queue.Count;

        public void Clear()
        {
            queue.Clear();
        }

        public T Dequeue()
        {
            return queue.Pop();
        }

        public void Enqueue(in T value)
        {
            queue.Push(value);
        }

        public T Front => queue.Top;
    }
}
