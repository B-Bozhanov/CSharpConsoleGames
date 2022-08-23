using GameMenu.Repository.Interfaces;

namespace GameMenu.Models.Settings.SizeSubFolder
{
    internal class Small : Menu
    {
        private const int Number = 1;
        private readonly int ConsoleRows = Console.LargestWindowHeight / 3;
        private readonly int ConsoleCols = Console.LargestWindowWidth / 3;

        public Small(int row, int col, IRepository<string> namespaces)
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
