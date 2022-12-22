using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp2LabaN1
{
    public class ArrayList<T> : IList<T>
    {
        private const int DEFAULT_SIZE = 4;
        private T[] _arrayList;
        private int _size;
        public int Count { get; private set; }
        public T this[int index] 
        { 
            get 
            {
                return index < Count && index >= 0 
                    ? _arrayList[index] 
                    : throw new ListIndexOutOfRangeException("Выход индекса за границу списка"); 
            }
        }

        public ArrayList()
        {
            _size = DEFAULT_SIZE;
            _arrayList = new T[_size];
        }

        public ArrayList(int size) : this()
        {
            if (size < 0)
            {
                throw new ListArgumentOutOfRangeException("Требуется неотрицательное число");
            }
            _size = size;
        }

        public int Add(T value)
        {
            Insert(Count, value);

            return Count - 1;
        }

        public void Clear()
        {
            _size = DEFAULT_SIZE;
            _arrayList = new T[_size];
            Count = 0;
        }

        public bool Contains(T value)
        {
            if (IsEmpty()) return false;
            return IndexOf(value) != -1;
        }

        public int IndexOf(T value)
        {
            if (IsEmpty()) return -1;

            for (int i = 0; i < Count; i++)
            {
                if (_arrayList[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;          
        }

        public void Insert(int index, T value)
        {
            if (index > Count)
            {
                throw new ListIndexOutOfRangeException("Выход за границу списка");
            }

            if (IsFull())
            {
                _size *= 2;
                Array.Resize(ref _arrayList, _size);
            }

            if (index < Count)
            {
                Array.Copy(_arrayList, index, _arrayList, index + 1, Count - index);
            }

            _arrayList[index] = value;
            Count++;
        }

        public void Remove(T value)
        {
            int index = IndexOf(value);
            if (index >= 0)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (IsEmpty()) return;

            Count--;

            if (index < Count)
            {
                Array.Copy(_arrayList, index + 1, _arrayList, index, Count - index);
            }

            _arrayList[Count] = default(T);
        }

        public IList<T> subList(int fromIndex, int toIndex)
        {
            if (toIndex < fromIndex)
            {
                throw new ListArgumentOutOfRangeException("Неправильный порядок индексов");
            }

            int newListSize = toIndex - fromIndex;
            IList<T> list = new ArrayList<T>(newListSize);

            for (int i = fromIndex; i <= toIndex; i++)
            {
                list.Add(_arrayList[i]);
            }

            return list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _arrayList[i];
            }
        }

        private bool IsFull()
        {
            return _size == Count;
        }

        private bool IsEmpty()
        {
            return _size == 0;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
