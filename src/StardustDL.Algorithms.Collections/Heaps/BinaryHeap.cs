using System.Collections.Generic;

namespace StardustDL.Algorithms.Collections.Heaps
{
    public class BinaryHeap<T> : IHeap<T> where T : notnull
    {
        private readonly IComparer<T> comparer;
        private readonly List<T> Contents = new List<T>() { default };

        public int Count => Contents.Count - 1;

        public void Clear()
        {
            Contents.Clear();
            Contents.Add(default);
        }

        public void Push(in T value)
        {
            Contents.Add(value);
            int id = Count, l = id / 2;
            while (id != 1 && comparer.Smaller(value, Contents[l]))
            {
                Utility.Swap(Contents, id, l);
                id = l; l = id / 2;
            }
        }

        public T Pop()
        {
            T res = Top;
            Utility.Swap(Contents, 1, Count);
            Contents.RemoveAt(Contents.Count - 1);
            if (!IsEmpty)
            {
                T item = Contents[1];
                int id = 1, l = id * 2, r = l + 1, len = Count;
                while (true)
                {
                    if (l > len)
                    {
                        break;
                    }
                    else if (r > len)//has left child
                    {
                        if (comparer.Larger(item, Contents[l]))
                        {
                            Utility.Swap<T>(Contents, id, l);
                            id = l;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        int cid;
                        if (comparer.Larger(Contents[l], Contents[r]))
                        {
                            cid = r;
                        }
                        else
                        {
                            cid = l;
                        }

                        if (comparer.Larger(item, Contents[cid]))
                        {
                            Utility.Swap(Contents, id, cid);
                            id = cid;
                        }
                        else
                        {
                            break;
                        }
                    }
                    l = id * 2;
                    r = l + 1;
                }
            }
            return res;
        }

        public T Top => Contents[1];

        public bool IsEmpty => Count == 0;

        public BinaryHeap() : this(null) { }

        public BinaryHeap(IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }
    }
}
