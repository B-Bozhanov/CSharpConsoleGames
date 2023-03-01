namespace Snake.Models.Menu.Settings.SizeSubFolder
{
    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;

    internal class Large : Menu
    {
        private const int Number = 3;
        private readonly int ConsoleRows = Console.LargestWindowHeight;
        private readonly int ConsoleCols = Console.LargestWindowWidth;

        public Large(IRepository<string> namespaces)
            : base(Number, namespaces)
        {
        }

        public override int ID { get; protected set; }

        public override string Execute(IField field)
        {
            field.WindowResizer(ConsoleRows, ConsoleCols);
            BackCommand();
            return null;
        }
    }
}
