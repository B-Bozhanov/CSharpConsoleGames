namespace GameMenu
{
    internal static class InterfaceRepository<T>
    {
        private readonly static Stack<T> interfaces = new();

        public static Stack<T> Interfaces { get => interfaces; }


        public static void Push(T value)
        {
            interfaces.Push(value);
        }
        public static void Pop()
        {
            interfaces.Pop();
        }
        public static T Peek()
        {
            return interfaces.Peek();
        }
    }
}
