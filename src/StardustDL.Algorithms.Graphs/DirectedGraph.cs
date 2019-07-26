using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StardustDL.Algorithms.Graphs
{
    public class DirectedGraph<TVertex, TEdge> : IGraph<TVertex, TEdge> where TEdge : IEdge<TVertex> where TVertex : notnull
    {
        EdgeCollection InnerEdges { get; set; }

        VertexCollection InnerVertexes { get; set; }

        public ICollection<TVertex> Vertexes => InnerVertexes;

        public ICollection<TEdge> Edges => InnerEdges;

        public DirectedGraph()
        {
            InnerEdges = new EdgeCollection(this);
            InnerVertexes = new VertexCollection(this);
        }

        public IEnumerable<TEdge> GetAdjacentEdges(in TVertex vertex)
        {
            return InnerEdges.GetAdjacentEdges(vertex);
        }

        class EdgeCollection : ICollection<TEdge>
        {
            IDictionary<TVertex, IList<TEdge>> Data { get; set; } = new Dictionary<TVertex, IList<TEdge>>();

            DirectedGraph<TVertex, TEdge> Parent { get; set; }

            IEnumerable<TEdge> GetEdges()
            {
                return from list in Data.Values from edge in list select edge;
            }

            public int Count { get; private set; } = 0;

            public bool IsReadOnly => false;

            public EdgeCollection(DirectedGraph<TVertex, TEdge> parent)
            {
                Parent = parent;
            }

            public void Add(TEdge item)
            {
                if (!(Parent.InnerVertexes.Contains(item.From) && Parent.InnerVertexes.Contains(item.To))) throw new ArgumentException("No this edge's vertexes.", nameof(item));

                if (Data.TryGetValue(item.From, out var value))
                {
                    value.Add(item);
                }
                else
                {
                    Data.Add(item.From, new List<TEdge>() { item });
                }
            }

            public void Clear()
            {
                Data.Clear();
                Count = 0;
            }

            public bool Contains(TEdge item)
            {
                if (Data.TryGetValue(item.From, out var value))
                {
                    return value.Contains(item);
                }
                return false;
            }

            public void CopyTo(TEdge[] array, int arrayIndex)
            {
                if (arrayIndex < 0) throw new System.ArgumentOutOfRangeException(nameof(arrayIndex));
                var data = GetEdges().ToList();
                if (array.Length - arrayIndex < data.Count) throw new System.ArgumentException(null, nameof(arrayIndex));
                data.CopyTo(array, arrayIndex);
            }

            public bool Remove(TEdge item)
            {
                if (Data.TryGetValue(item.From, out var value))
                {
                    return value.Remove(item);
                }
                return false;
            }

            public bool RemoveVertex(TVertex item)
            {
                return Data.Remove(item);
            }

            public IEnumerable<TEdge> GetAdjacentEdges(TVertex item)
            {
                if (Data.TryGetValue(item, out var value))
                {
                    return value.AsEnumerable();
                }
                return Enumerable.Empty<TEdge>();
            }

            public IEnumerator<TEdge> GetEnumerator()
            {
                return GetEdges().GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        class VertexCollection : ICollection<TVertex>
        {
            ISet<TVertex> Data { get; set; } = new HashSet<TVertex>();

            DirectedGraph<TVertex, TEdge> Parent { get; set; }

            public VertexCollection(DirectedGraph<TVertex, TEdge> parent)
            {
                Parent = parent;
            }

            public int Count => Data.Count;

            public bool IsReadOnly => Data.IsReadOnly;

            public void Add(TVertex item)
            {
                ((ICollection<TVertex>)Data).Add(item);
            }

            public void Clear()
            {
                Data.Clear();
                Parent.InnerEdges.Clear();
            }

            public bool Contains(TVertex item)
            {
                return Data.Contains(item);
            }

            public void CopyTo(TVertex[] array, int arrayIndex)
            {
                Data.CopyTo(array, arrayIndex);
            }

            public IEnumerator<TVertex> GetEnumerator()
            {
                return Data.GetEnumerator();
            }

            public bool Remove(TVertex item)
            {
                if (Data.Remove(item))
                {
                    Parent.InnerEdges.RemoveVertex(item);
                    return true;
                }
                return false;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return Data.GetEnumerator();
            }
        }
    }
}
