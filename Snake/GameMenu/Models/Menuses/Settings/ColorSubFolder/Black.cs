namespace GameMenu.Models.Menuses.Settings.ColorSubFolder
{
    internal class Black : Menu
    {
        private const int Number = 2;
        private const ConsoleColor FieldColor = ConsoleColor.Black;
        private const ConsoleColor TextColor = ConsoleColor.Yellow;

        public Black(int row, int col)
            : base(Number, row, col)
        {
        }

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute()
        {
            Console.ResetColor();
            ConsoleField.SetBackgroundColor(FieldColor);
            ConsoleField.SetBackgroundColor(TextColor);
            return base.BackCommand();
        }
    }
}
