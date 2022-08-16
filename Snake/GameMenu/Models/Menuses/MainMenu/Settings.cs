namespace GameMenu.Models.Menuses.MainMenu
{
    using Interfaces;

    internal class Settings : Menu
    {
        private const int Number = 2;
        private const string SubFolder = "GameMenu.Models.Menuses.Settings";

        public Settings(int row, int col)
            : base(Number, row, col)
        {
        }

        public override string Execute()
        {
            NameSpaces.Push(SubFolder);
            return NameSpaces.Peek();
        }
    }
}
