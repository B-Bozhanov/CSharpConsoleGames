namespace Snake.Models.Menu.UserLoginMenu
{
    using Snake.Common;
    using Snake.Models.Menu.Repository.Interfaces;

    using UserDatabase.Interfaces;


    internal class ContinueWithoutAccount : Menu
    {
        private const int SequenceNumber = 3;
        private readonly IDatabase users;

        public ContinueWithoutAccount(IRepository<string> namespaces, IDatabase users)
            : base(SequenceNumber, namespaces)
        {
            this.users = users;
        }

        public override int ID { get; protected set; }

        public override string GetName()
        {
            return "Continue without account";
        }
        public override string Execute()
        {
            users.AddAccount("Guest", null!);
            namespaces.Add(NameSpacesInfo.MainMenu);
            return "ContinueWithoutAccount";
        }
    }
}
