namespace GameMenu.Models.Menuses.MainMenu
{
    using Interfaces;

    internal class Exit : Menu
    {
        private const int Number = 4;

        public Exit(int row, int col)
            : base(Number, row, col)
        {
        }

        public override string Execute()
        {
            NameSpaces.Pop();
            Environment.Exit(0);
            return null;
        }
    }
}
