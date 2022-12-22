using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2LabaN1
{
    public static class ListUtils
    {
        public delegate bool CheckDelegate<T>(T value);

        public delegate IList<T> ListConstructorDelegate<T>();

        public delegate TO ConvertDelegate<TI, TO>(TI value);

        public delegate T ActionDelegate<T>(T value);

        public delegate int CompareDelegate<T>(T firstValue, T secondValue);

        public static ListConstructorDelegate<T> ArrayListConstructor<T>() => () => new ArrayList<T>();

        public static ListConstructorDelegate<T> LinkedListConstructor<T>() => () => new LinkedList<T>();

        public static bool Exists<T>(IList<T> list, CheckDelegate<T> checkDelegate)
        {
            foreach (T elem in list)
            {
                if (checkDelegate(elem))
                {
                    return true;
                }
            }
            return false;
        }

        public static T Find<T>(IList<T> list, CheckDelegate<T> checkDelegate)
        {
            foreach (T elem in list)
            {
                if (checkDelegate(elem))
                {
                    return elem;
                }
            }
            return default(T);
        }

        public static T FindLast<T>(IList<T> list, CheckDelegate<T> checkDelegate)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (checkDelegate(list[i]))
                {
                    return list[i];
                }
            }
            return default(T);
        }

        public static int FindIndex<T>(IList<T> list, CheckDelegate<T> checkDelegate)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (checkDelegate(list[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int FindLastIndex<T>(IList<T> list, CheckDelegate<T> checkDelegate)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (checkDelegate(list[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public static IList<T> FindAll<T>(IList<T> list, CheckDelegate<T> checkDelegate, ListConstructorDelegate<T> listConstructorDelegate)
        {
            IList<T> result = listConstructorDelegate();
            foreach (T elem in list)
            {
                if (checkDelegate(elem))
                {
                    result.Add(elem);
                }
            }
            return result;
        }

        public static IList<TO> ConvertAll<TI, TO>(IList<TI> list, ConvertDelegate<TI, TO> convertDelegate, ListConstructorDelegate<TO> listConstructorDelegate)
        {
            IList<TO> result = listConstructorDelegate();
            foreach (TI elem in list)
            {
                result.Add(convertDelegate(elem));
            }
            return result;
        }

        public static void ForEach<T>(IList<T> list, ActionDelegate<T> actionDelegate)
        {
            for (int i = 0; i < list.Count; i++)
            {
                T elem = list[i];
                list.Remove(elem); 
                list.Add(actionDelegate(elem));
            }
        }

        public static void Sort<T>(IList<T> list, CompareDelegate<T> compareDelegate)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (compareDelegate(list[i], list[j]) > 0)
                    {
                        T tempElem = list[i];
                        list.RemoveAt(i);//2 1 3
                        list.Insert(j, tempElem);
                    }
                }
            }
        }

        public static bool CheckForAll<T>(IList<T> list, CheckDelegate<T> checkDelegate)
        {
            foreach (T elem in list)
            {
                if (!checkDelegate(elem))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
