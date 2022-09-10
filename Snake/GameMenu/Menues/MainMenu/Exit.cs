namespace GameMenu.Menues.MainMenu
{
    using GameMenu.Menues.UserLoginMenu;
    using GameMenu.Repository.Interfaces;
    internal class Exit : Quit
    {
        private const int Number = 4!;

        public Exit(int row, int col, IRepository<string> namespaces) 
            : base(Number, row, col, namespaces)
        {
        }
    }
}
