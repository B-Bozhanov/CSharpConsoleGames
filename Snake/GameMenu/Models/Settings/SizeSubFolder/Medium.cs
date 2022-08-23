using GameMenu.Repository.Interfaces;

namespace GameMenu.Models.Settings.SizeSubFolder
{
    internal class Medium : Menu
    {
        private const int Number = 2;
        private readonly int ConsoleRows = Console.LargestWindowHeight / 2;
        private readonly int ConsoleCols = Console.LargestWindowWidth / 2;

        public Medium(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override string Execute()
        {
            ConsoleField.WindowResizer(ConsoleRows, ConsoleCols);
            return base.BackCommand();
        }
    }
}
