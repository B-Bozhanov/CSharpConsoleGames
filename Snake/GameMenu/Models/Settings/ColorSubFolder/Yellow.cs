using GameMenu.Repository.Interfaces;

namespace GameMenu.Models.Settings.ColorSubFolder
{
    internal class Yellow : Menu
    {
        private const int Number = 3;
        private const ConsoleColor FieldColor = ConsoleColor.Yellow;
        private const ConsoleColor TextColor = ConsoleColor.Black;
        public Yellow(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
        }

        public override string GetName()
        {
            return base.GetName();
        }
        public override string Execute()
        {
            ConsoleField.SetBackgroundColor(FieldColor);
            ConsoleField.SetTextColor(TextColor);
            return base.BackCommand();
        }
    }
}
