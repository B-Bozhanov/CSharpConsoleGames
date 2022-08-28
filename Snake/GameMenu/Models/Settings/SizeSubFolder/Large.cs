using GameMenu.Repository.Interfaces;

namespace GameMenu.Models.Settings.SizeSubFolder
{
    internal class Large : Menu
    {
        private const int Number = 3;
        private readonly int ConsoleRows = Console.LargestWindowHeight;
        private readonly int ConsoleCols = Console.LargestWindowWidth;

        public Large(int row, int col, IRepository<string> namespaces)
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
