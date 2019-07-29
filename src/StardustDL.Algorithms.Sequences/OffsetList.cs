using System.Collections;
using System.Collections.Generic;

namespace StardustDL.Algorithms.Sequences
{
    public class OffsetList<T> : IList<T>
    {
        public int Offset { get; }

        public OffsetList(int offset)
        {
            Offset = offset;
        }

        public T this[int index] { get => ((IList<T>)Inner)[index - Offset]; set => ((IList<T>)Inner)[index - Offset] = value; }

        public int Count => ((IList<T>)Inner).Count;

        public bool IsReadOnly => ((IList<T>)Inner).IsReadOnly;

        List<T> Inner { get; set; } = new List<T>();

        public void Add(T item)
        {
            ((IList<T>)Inner).Add(item);
        }

        public void Clear()
        {
            ((IList<T>)Inner).Clear();
        }

        public bool Contains(T item)
        {
            return ((IList<T>)Inner).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((IList<T>)Inner).CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IList<T>)Inner).GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return ((IList<T>)Inner).IndexOf(item) + Offset;
        }

        public void Insert(int index, T item)
        {
            ((IList<T>)Inner).Insert(index - Offset, item);
        }

        public bool Remove(T item)
        {
            return ((IList<T>)Inner).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<T>)Inner).RemoveAt(index - Offset);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<T>)Inner).GetEnumerator();
        }
    }
}
