namespace GameMenu.Models.MainMenu
{
    using GameMenu.Models.UserLoginMenu;
    using GameMenu.Repository.Interfaces;
    internal class Exit : Quit
    {
        private const int MenuNumber = 3;

        public Exit(int row, int col, IRepository<string> namespaces) 
            : base(MenuNumber, row, col, namespaces)
        {
        }
    }
}
