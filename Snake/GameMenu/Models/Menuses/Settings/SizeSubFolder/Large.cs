namespace GameMenu.Models.Menuses.Settings.SizeSubFolder
{
    internal class Large : Menu
    {
        private const int Number = 3;
        private readonly int ConsoleRows = Console.LargestWindowHeight;
        private readonly int ConsoleCols = Console.LargestWindowWidth;

        public Large(int row, int col)
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
