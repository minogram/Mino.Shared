using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mino.Collections
{
    public abstract class ListEx<TItem> : IList<TItem>
    {
        private readonly List<TItem> list = new();
        private readonly Action<TItem> onAdd;
        private readonly Action<TItem> onRemove;

        public ListEx(Action<TItem> onAdd, Action<TItem> onRemove)
        {
            this.onAdd = onAdd;
            this.onRemove = onRemove;
        }

        public TItem this[int index]
        {
            get => list[index];
            set
            {
                Debug.Assert(value != null);
                list[index] = value;
                onAdd(value);
            }
        }

        public int Count => list.Count;
        public bool IsReadOnly => false;
        public bool Contains(TItem item) => list.Contains(item);
        public void CopyTo(TItem[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);

        public IEnumerator<TItem> GetEnumerator() => list.GetEnumerator();
        public int IndexOf(TItem item) => list.IndexOf(item);

        public void Insert(int index, TItem item)
        {
            Debug.Assert(item != null);

            list.Insert(index, item);
            onAdd(item);
        }

        public void Add(TItem item)
        {
            Debug.Assert(item != null);

            list.Add(item);
            onAdd(item);
        }

        public bool Remove(TItem item)
        {
            if (list.Remove(item))
            {
                onRemove(item);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            var item = list[index];
            list.RemoveAt(index);
            onRemove(item);
        }

        public void Clear()
        {
            foreach (TItem item in list)
                onRemove(item);
            list.Clear();
        }

        public void AddRange(IEnumerable<TItem> collection)
            => InsertRange(list.Count, collection);

        public void InsertRange(int index, IEnumerable<TItem> collection)
        {
            if (collection is ICollection<TItem>)
            {
                list.InsertRange(index, collection);
            }
            else
            {
                using var en = collection.GetEnumerator();
                while (en.MoveNext())
                {
                    Insert(index++, en.Current);
                }
            }
        }

        // IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
    }
}
