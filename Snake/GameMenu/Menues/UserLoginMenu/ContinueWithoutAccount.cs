namespace GameMenu.Menues.UserLoginMenu
{
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;
    using GameMenu.Utilities;
    using UserDatabase;
    using UserDatabase.Interfaces;


    internal class ContinueWithoutAccount : Menu
    {
        private const int SequenceNumber = 3;
        private readonly IDatabase users;

        public ContinueWithoutAccount(int row, int col, IRepository<string> namespaces, IDatabase users) 
            : base(SequenceNumber, row, col, namespaces)
        {
            this.users = users;
        }

        public override int MenuNumber { get; protected set; }

        public override string GetName()
        {
            return "Continue without account";
        }
        public override string Execute(IField field, IWriter writer, IReader reader)
        {
            this.users.AddAccount("Guest", null!);
            this.namespaces.Add(NameSpacesInfo.MainMenu);
            return "ContinueWithoutAccount";
        }
    }
}
