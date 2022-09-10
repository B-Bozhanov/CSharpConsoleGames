namespace GameMenu.Menues.MainMenu
{
    using GameMenu.Menues.UserLoginMenu;
    using GameMenu.Repository.Interfaces;
    internal class Exit : Quit
    {
        private const int SequenceNumber = 4!;

        public Exit(int row, int col, IRepository<string> namespaces) 
            : base(SequenceNumber, row, col, namespaces)
        {
        }
    }
}
