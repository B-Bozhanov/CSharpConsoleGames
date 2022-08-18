using GameMenu.Models.Menuses.Settings.Interfaces;

namespace GameMenu.Models.Menuses.Settings.SizeSubFolder
{
    internal class Small : Menu, ISize
    {
        private const int Number = 1;
        private readonly int ConsoleRows = Console.LargestWindowHeight / 3;
        private readonly int ConsoleCols = Console.LargestWindowWidth / 3;

        public Small(int row, int col) 
            : base(Number, row, col)
        {
            
        }

        public override Type Execute()
        {
            ConsoleField.WindowResizer(ConsoleRows, ConsoleCols);
            return base.BackCommand();
        }
    }
}
