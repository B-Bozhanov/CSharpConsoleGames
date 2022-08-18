namespace GameMenu.Models.Menuses.MainMenu
{
    using GameMenu.Models.Menuses.Settings.Interfaces;
    using Interfaces;

    internal class Settings : Menu, IMainMenu
    {
        private const int Number = 2;

        public Settings(int row, int col)
            : base(Number, row, col)
        {
        }

        public override Type Execute()
        {
            var type = typeof(ISettings);
            InterfaceRepository<Type>.Push(type);
            return InterfaceRepository<Type>.Peek();
        }
    }
}
