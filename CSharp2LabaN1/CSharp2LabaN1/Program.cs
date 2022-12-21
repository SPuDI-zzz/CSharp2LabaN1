using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2LabaN1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> array = new ArrayList<int>();
            LinkedList<int> linked = new LinkedList<int>();
            Console.WriteLine("Testing Arraylist");
            Testlist(array);
            Console.WriteLine("Testing Linkedlist");
            Testlist(linked);
            Console.WriteLine("Testing universal utils with Arraylist");
            TestUniversallistUtils(array);
            Console.WriteLine("Testing universal utils with Linkedlist");
            TestUniversallistUtils(linked);
            Console.WriteLine("Testing Arraylist utils");
            TestArraylistUtils(array);
            Console.WriteLine("Testing Linkedlist utils");
            TestLinkedlistUtils(linked);
            Console.ReadLine();
        }

        private static void ListToConsole(IList<int> list)
        {
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
        }

        private static void Testlist(IList<int> list)
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Insert(2, 6);
            ListToConsole(list);
            Console.WriteLine("Удалим из списка элемент со значением 3");
            list.Remove(3);
            ListToConsole(list);
            Console.WriteLine("Очистим список");
            list.Clear();
            ListToConsole(list);
            Console.WriteLine();
        }

        private static void TestUniversallistUtils(IList<int> list)
        {
            list.Add(-1);
            list.Add(2);
            list.Add(3);
            Console.WriteLine(ListUtils.Exists(list, elem => elem < 0));
            ListUtils.ForEach(list, elem => elem * 2);
            ListToConsole(list);
            Console.WriteLine(ListUtils.CheckForAll(list, elem => elem > 0));
            Console.WriteLine();
        }

        private static void TestArraylistUtils(IList<int> list)
        {
            IList<int> result = ListUtils.FindAll(list, elem => elem > 0, ListUtils.ArrayListConstructor<int>());
            ListToConsole(result);
            IList<string> resultStr = ListUtils.ConvertAll(list, elem => elem.ToString(),
                ListUtils.ArrayListConstructor<string>());
            foreach (string str in resultStr)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();
        }

        private static void TestLinkedlistUtils(IList<int> list)
        {
            IList<int> result = ListUtils.FindAll(list, elem => elem > 0, ListUtils.LinkedListConstructor<int>());
            ListToConsole(result);
            IList<string> resultStr = ListUtils.ConvertAll(list, elem => elem.ToString(),
                ListUtils.LinkedListConstructor<string>());
            foreach (string str in resultStr)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();
        }
    }
}
