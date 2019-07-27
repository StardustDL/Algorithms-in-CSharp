using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StardustDL.Algorithms.Collections
{
    public class DisjointSet<T> : IEnumerable<T> where T : notnull
    {
        class DisjointSetNode<TValue>
        {
            public DisjointSetNode(TValue value, DisjointSetNode<TValue>? parent = null)
            {
                Value = value;
                Parent = parent ?? this;
                Rank = 0;
            }

            public TValue Value { get; }

            public int Rank { get; set; }

            public DisjointSetNode<TValue> Parent { get; set; }
        }

        Dictionary<T, DisjointSetNode<T>> Contents { get; } = new Dictionary<T, DisjointSetNode<T>>();

        public int ElementCount { get; private set; } = 0;

        public int Count { get; private set; } = 0;

        DisjointSetNode<T> GetParent(DisjointSetNode<T> item)
        {
            if (item.Parent != item)
            {
                var par = GetParent(item.Parent);
                item.Parent = par;
                return par;
            }
            return item;
        }

        public void Unite(in T first, in T second)
        {
            DisjointSetNode<T> _first = GetParent(Contents[first]);
            DisjointSetNode<T> _second = GetParent(Contents[second]);
            if (_first.Rank > _second.Rank)
            {
                _second.Parent = _first;
            }
            else if (_first.Rank < _second.Rank)
            {
                _first.Parent = _second;
            }
            else
            {
                _second.Parent = _first;
                _first.Rank++;
            }

            Count--;
        }

        public bool IsUnited(in T first, in T second)
        {
            DisjointSetNode<T> _first = GetParent(Contents[first]);
            DisjointSetNode<T> _second = GetParent(Contents[second]);
            return _first == _second;
        }

        public IEnumerator<T> GetEnumerator() => (from x in Contents.Values select x.Value).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(in T item)
        {
            Contents.Add(item, new DisjointSetNode<T>(item));
            Count++;
            ElementCount++;
        }

        public void Clear()
        {
            Contents.Clear();
            Count = 0;
            ElementCount = 0;
        }

        public bool Contains(in T value) => Contents.ContainsKey(value);
    }
}
