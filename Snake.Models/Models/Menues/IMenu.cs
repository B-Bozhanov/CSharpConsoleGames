namespace Snake.Models.Models.Menues
{
    public interface IMenu
    {
        public Coordinates Coordinates { get; }

        public string Name { get; }

        public int PriorityNumber { get; }

        public void Execute(Stack<string> namespaces);
    }
}
