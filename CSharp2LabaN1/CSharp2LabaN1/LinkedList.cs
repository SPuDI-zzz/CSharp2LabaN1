using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2LabaN1
{
    public class LinkedList<T> : IList<T>
    {
        private LinkedListNode<T> head;
        public int Count { get; private set; }
        public T this[int index] 
        { 
            get 
            {
                if (index < 0 || index >= Count)
                {
                    throw new ListIndexOutOfRangeException("Выход за границу списка");
                }

                LinkedListNode<T> temp = head;

                temp = getNodeByIndex(index, temp);

                return temp.Value;
            } 
        }

        public LinkedList() 
        {
            
        }

        public int Add(T value)
        {
            Insert(Count, value);

            return Count - 1;
        }

        public void Clear()
        {
            head = null;
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
                if (this[i].Equals(value))
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

            if (IsEmpty())
            {
                head = new LinkedListNode<T>(value);
                Count++;
                return;
            }

            LinkedListNode<T> cur;

            if (index == Count)
            {
                cur = new LinkedListNode<T>(value)
                {
                    Next = head
                };
                head = cur;
                Count++;
                return;
            }

            cur = head;

            cur = getNodeByIndex(index, cur);

            LinkedListNode<T> temp = new LinkedListNode<T>(value)
            {
                Next = cur.Next
            };
            cur.Next = temp;

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

            LinkedListNode<T> cur = head;

            cur = getNodeByIndex(index, cur);

            cur.Next = cur.Next.Next;
            //temp.Next = null;
        }

        public IList<T> subList(int fromIndex, int toIndex)
        {
            if (toIndex < fromIndex)
            {
                throw new ListArgumentOutOfRangeException("Неправильный порядок индексов");
            }

            IList<T> list = new LinkedList<T>();

            for (int i = fromIndex; i <= toIndex; i++)
            {
                list.Add(this[i]);
            }

            return list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        private bool IsEmpty()
        {
            return Count == 0;
        }

        private LinkedListNode<T> getNodeByIndex(int index, LinkedListNode<T> node)
        {
            while (Count - 1 - index > 0)
            {
                node = node.Next;
                index++;
            }
            return node;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
