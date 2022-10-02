namespace GameMenu.Menues.Settings.SizeSubFolder
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;

    internal class Small : Menu
    {
        private const int Number = 1;
        private readonly int ConsoleRows = Console.LargestWindowHeight / 3;
        private readonly int ConsoleCols = Console.LargestWindowWidth / 3;

        public Small(IRepository<string> namespaces)
            : base(Number, namespaces)
        {

        }

        public override int ID { get; protected set; }

        public override string Execute(IField field)
        {
            field.WindowResizer(ConsoleRows, ConsoleCols);
            base.BackCommand();
            return null;
        }
    }
}
