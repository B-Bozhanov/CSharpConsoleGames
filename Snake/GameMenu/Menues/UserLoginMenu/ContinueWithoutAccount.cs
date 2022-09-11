namespace GameMenu.Menues.UserLoginMenu
{
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;
    using UserDatabase;
    using UserDatabase.Interfaces;


    internal class ContinueWithoutAccount : Menu
    {
        private const int SequenceNumber = 3;
        private IUserDatabase users;

        public ContinueWithoutAccount(int row, int col, IRepository<string> namespaces, IUserDatabase users) 
            : base(SequenceNumber, row, col, namespaces)
        {
            this.users = users;
        }

        public override int MenuNumber { get; protected set; }

        public override string GetName()
        {
            return "Continue without account";
        }
        public override string Execute(IField field)
        {
            IUser guest = new User("Guest", null!, 0);
            this.users.Add(guest);
            this.namespaces.Add(NameSpacesInfo.MainMenu);
            return this.namespaces.Get();
        }
    }
}
