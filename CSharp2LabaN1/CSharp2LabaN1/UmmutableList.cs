using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharp2LabaN1
{
    public class UmmutableList<T> : IList<T>
    {
        private readonly List<T> _list;
        public int Count { get; }
        public T this[int index] { get { return _list[index]; } }

        public UmmutableList(List<T> list)
        {
            _list = list;
            Count = list.Count;
        }

        public int Add(T value)
        {
            throw new ListException("Попытка добавления элемента в список");
        }

        public void Clear()
        {
            throw new ListException("Попытка очистка списка");
        }

        public bool Contains(T value)
        {
            return _list.Contains(value);
        }

        public int IndexOf(T value)
        {
            return _list.IndexOf(value);
        }

        public void Insert(int index, T value)
        {
            throw new ListException("Попытка добавления элемента по индексу в список");
        }

        public void Remove(T value)
        {
            throw new ListException("Попытка удаления элемента из списка");
        }

        public void RemoveAt(int index)
        {
            throw new ListException("Попытка удаления элемента по индексу из списка");
        }

        public IList<T> subList(int fromIndex, int toIndex) 
        {
            IList<T> tempList;
            if (_list is ArrayList<T>)
            {
                tempList = _list as ArrayList<T>;
                return tempList.subList(fromIndex, toIndex);
            }
            tempList = _list as LinkedList<T>;
            return tempList.subList(fromIndex, toIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
