using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMenu
{
    internal static class NameSpaces
    {
        private static Stack<string> namespaces = new Stack<string>();

        public static Stack<string> Namespaces { get => namespaces; }


        public static void Push(string value)
        {
            namespaces.Push(value);
        }
        public static void Pop()
        {
            namespaces.Pop();
        }
        public static string Peek()
        {
            return namespaces.Peek();
        }
    }
}
