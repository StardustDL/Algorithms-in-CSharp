using System.Collections.Generic;

namespace StardustDL.Algorithms.Sequences
{
    public class Deque<T> : IQueue<T>
    {
        private LinkedList<T> Content { get; set; } = new LinkedList<T>();

        public T Front => Content.First!.Value;

        public T Last => Content.Last!.Value;

        public int Count => Content.Count;

        public void Clear()
        {
            Content.Clear();
        }

        public T DequeueTail()
        {
            T r = Content.Last!.Value;
            Content.RemoveLast();
            return r;
        }

        public void EnqueueHead(T value)
        {
            Content.AddFirst(value);
        }

        public T Dequeue()
        {
            T r = Content.First!.Value;
            Content.RemoveFirst();
            return r;
        }

        public void Enqueue(in T value)
        {
            Content.AddLast(value);
        }
    }
}
