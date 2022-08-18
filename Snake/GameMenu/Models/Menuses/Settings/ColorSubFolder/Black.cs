using GameMenu.Models.Menuses.Settings.Interfaces;

namespace GameMenu.Models.Menuses.Settings.ColorSubFolder
{
    internal class Black : Menu, IColor
    {
        private const int Number = 2;
        private const ConsoleColor TextColor = ConsoleColor.Yellow;

        public Black(int row, int col)
            : base(Number, row, col)
        {
        }

        public override string GetName()
        {
            return base.GetName();
        }
        public override Type Execute()
        {
            ConsoleField.ResetColor();
            ConsoleField.SetTextColor(TextColor);
            return base.BackCommand();
        }
    }
}
