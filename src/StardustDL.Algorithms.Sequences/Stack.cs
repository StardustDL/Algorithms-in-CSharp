namespace StardustDL.Algorithms.Sequences
{
    public class Stack<T> : IStack<T>
    {
        private readonly System.Collections.Generic.Stack<T> innerStack = new System.Collections.Generic.Stack<T>();

        public T Top => innerStack.Peek();

        public int Count => innerStack.Count;

        public void Clear()
        {
            innerStack.Clear();
        }

        public T Pop()
        {
            return innerStack.Pop();
        }

        public void Push(in T value)
        {
            innerStack.Push(value);
        }
    }
}
