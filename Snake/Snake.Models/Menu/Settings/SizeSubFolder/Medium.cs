namespace Snake.Models.Menu.Settings.SizeSubFolder
{
    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;

    internal class Medium : Menu
    {
        private const int Number = 2;
        private readonly int ConsoleRows = Console.LargestWindowHeight / 2;
        private readonly int ConsoleCols = Console.LargestWindowWidth / 2;

        public Medium(IRepository<string> namespaces)
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
