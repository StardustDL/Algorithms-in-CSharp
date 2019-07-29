using System.Collections.Generic;

namespace StardustDL.Algorithms.Collections.Heaps
{
    public class LeftistTree<T> : IHeap<T>
    {
        private class LeftistTreeNode
        {
            public LeftistTreeNode(in T value)
            {
                Value = value;
            }

            public LeftistTreeNode? LeftChild { get; set; }

            public LeftistTreeNode? RightChild { get; set; }

            public T Value { get; }

            public int Distance { get; set; }
        }

        private readonly IComparer<T> comparer;

        private LeftistTreeNode? Root { get; set; }

        public int Count { get; private set; }

        public void Clear()
        {
            while (Count > 0)
            {
                Pop();
            }
        }

        public void Push(in T value)
        {
            Root = Merge(Root, NewNode(value));
            Count++;
        }

        public T Pop()
        {
            T r = Root!.Value;
            Root = Merge(Root.LeftChild, Root.RightChild);
            Count--;
            return r;
        }

        public T Top => Root!.Value;

        public LeftistTree() : this(null) { }

        public LeftistTree(IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            Count = 0;
        }

        private LeftistTreeNode NewNode(in T value)
        {
            return new LeftistTreeNode(value);
        }

        private LeftistTreeNode? Merge(LeftistTreeNode? a, LeftistTreeNode? b)
        {
            if (a == null)
            {
                return b;
            }

            if (b == null)
            {
                return a;
            }

            if (comparer.Larger(a.Value, b.Value))
            {
                Utility.Swap(ref a, ref b);
            }

            a!.RightChild = Merge(a.RightChild, b);
            if ((a.LeftChild?.Distance ?? -1) < a!.RightChild!.Distance)
            {
                LeftistTreeNode t = a!.LeftChild!;
                a.LeftChild = a.RightChild;
                a.RightChild = t;
            }
            if (a.RightChild == null)
            {
                a.Distance = 0;
            }
            else
            {
                a.Distance = a.RightChild.Distance + 1;
            }

            return a;
        }
    }
}
