namespace GameMenu.Models.Menuses.Settings.SizeSubFolder
{
    internal class Medium : Menu
    {
        private const int Number = 2;
        private readonly int ConsoleRows = Console.LargestWindowHeight / 2;
        private readonly int ConsoleCols = Console.LargestWindowWidth / 2;

        public Medium(int row, int col)
            : base(Number, row, col)
        {
        }

        public override string Execute()
        {
            ConsoleField.WindowResizer(ConsoleRows, ConsoleCols);
            return base.BackCommand();
        }
    }
}
