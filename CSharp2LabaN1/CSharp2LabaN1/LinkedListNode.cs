using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2LabaN1
{
    internal class LinkedListNode<T>
    {
        internal LinkedListNode<T> Next { get; set; }
        internal T Value{ get; set; }

        public LinkedListNode(T value) 
        {
            Value = value;
        }
    }
}
