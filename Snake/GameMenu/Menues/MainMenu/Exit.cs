namespace GameMenu.Menues.MainMenu
{
    using GameMenu.Menues.UserLoginMenu;
    using GameMenu.Repository.Interfaces;

    internal class Exit : Quit
    {
        private const int SequenceNumber = 4!;

        public Exit(IRepository<string> namespaces) 
            : base(SequenceNumber, namespaces)
        {
        }
    }
}
