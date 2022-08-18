using GameMenu.Models.Menuses.Settings.Interfaces;

namespace GameMenu.Models.Menuses.Settings.ColorSubFolder
{
    internal class White : Menu, IColor
    {
        private const int Number = 1;
        private const ConsoleColor FieldColor = ConsoleColor.White;
        private const ConsoleColor TextColor = ConsoleColor.Black;

        public White(int row, int col) 
            : base(Number, row, col)
        {
        }

        public override string GetName()
        {
            return base.GetName();
        }
        public override Type Execute()
        {
            Console.ResetColor();
            ConsoleField.SetBackgroundColor(FieldColor);
            ConsoleField.SetTextColor(TextColor);
            return base.BackCommand();
        }
    }
}
