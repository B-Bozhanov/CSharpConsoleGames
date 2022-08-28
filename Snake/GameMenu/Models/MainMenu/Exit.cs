namespace GameMenu.Models.MainMenu
{
    using GameMenu.Models.UserLoginMenu;
    using GameMenu.Repository.Interfaces;

    internal class Exit : Quit
    {
        private const int MenuPossition = 3;

        public Exit(int row, int col, IRepository<string> namespaces)
            : base(MenuPossition, row, col, namespaces)
        {
        }
    }
}
