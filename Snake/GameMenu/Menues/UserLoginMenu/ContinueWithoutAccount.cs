namespace GameMenu.Menues.UserLoginMenu
{
    using GameMenu.Repository.Interfaces;

    using Snake.Common;

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
            this.users.AddAccount("Guest", null!);
            this.namespaces.Add(NameSpacesInfo.MainMenu);
            return "ContinueWithoutAccount";
        }
    }
}
