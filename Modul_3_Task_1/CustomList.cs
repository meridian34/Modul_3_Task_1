using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Modul_3_Task_1
{
    public class CustomList<T>
        : ICollection<T>
    {
        private readonly int _defArrayDimension;
        private T[] _container;

        public CustomList()
        {
            _defArrayDimension = 4;
            _container = new T[_defArrayDimension];
        }

        public int Count { get; private set; }

        public int Capacity => _container.Length;

        public bool IsReadOnly => false;

        public T this[int index] { get => _container[index]; set => _container[index] = value; }

        public void Add(T item)
        {
            _container[Count] = item;
            Count++;
            if (Count == Capacity)
            {
                Array.Resize(ref _container, _container.Length * 2);
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Clear()
        {
            Count = 0;
            _container = new T[_defArrayDimension];
        }

        public bool Contains(T item)
        {
            foreach (var i in _container)
            {
                if (i.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if ((array.Length - arrayIndex) != _container.Length)
            {
                throw new ArgumentException();
            }
            else
            {
                for (var i = 0; i < _container.Length; i++)
                {
                    array[i + arrayIndex] = _container[i];
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _container[i];
            }
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < _container.Length; i++)
            {
                if (i.Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < _container.Length; i++)
            {
                if (_container[i].Equals(item))
                {
                    Count--;
                    for (var j = i; j + 1 < _container.Length; j++)
                    {
                        _container[j] = _container[j + 1];
                    }

                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index >= _container.Length)
            {
                throw new IndexOutOfRangeException();
            }

            Count--;
            for (var j = index; j + 1 < _container.Length; j++)
            {
                _container[j] = _container[j + 1];
            }
        }

        public void Sort()
        {
            Array.Sort(_container);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _container[i];
            }
        }
    }
}
