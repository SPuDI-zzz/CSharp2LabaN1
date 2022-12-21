using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2LabaN1
{
    public class ListException : Exception
    {
        public ListException(string message) : base(message) { }
    }

    public class ListArgumentOutOfRangeException : ArgumentOutOfRangeException
    {
        public ListArgumentOutOfRangeException(string message) : base(message) { }
    }

    public class ListIndexOutOfRangeException : Exception
    {
        public ListIndexOutOfRangeException(string message) : base(message) { }
    }
}
