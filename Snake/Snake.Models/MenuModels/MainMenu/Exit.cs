namespace Snake.Models.Menu.MainMenu
{
    using Snake.Models.Menu.Repository.Interfaces;
    using Snake.Models.Menu.UserLoginMenu;

    internal class Exit : Quit
    {
        private const int SequenceNumber = 4!;

        public Exit(IRepository<string> namespaces)
            : base(SequenceNumber, namespaces)
        {
        }
    }
}
