namespace StardustDL.Algorithms.Sequences
{
    public class Queue<T> : IQueue<T>
    {
        private readonly System.Collections.Generic.Queue<T> innerQueue = new System.Collections.Generic.Queue<T>();

        public T Front => innerQueue.Peek();

        public int Count => innerQueue.Count;

        public void Clear()
        {
            innerQueue.Clear();
        }

        public T Dequeue()
        {
            return innerQueue.Dequeue();
        }

        public void Enqueue(in T value)
        {
            innerQueue.Enqueue(value);
        }
    }
}
