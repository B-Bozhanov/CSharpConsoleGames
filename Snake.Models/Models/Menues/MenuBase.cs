namespace Snake.Models.Models.Menues
{
    using Common;

    public abstract class MenuBase : IMenu
    {
        private readonly Color color;
        private Stack<string> menuNamespacees;

        public MenuBase(string name)
        {
            this.color = Color.Yellow;
            this.Name = name;
            this.Coordinates = new Coordinates(GlobalConstants.Menu.StartRow + this.PriorityNumber, GlobalConstants.Menu.StartColumn, this.Name, this.color);
        }

        public string Name { get; init; }

        public abstract int PriorityNumber { get; protected set; }

        public Coordinates Coordinates { get; protected set; } = null!;

        public abstract void Execute(Stack<string> namespaces);
    }
}
