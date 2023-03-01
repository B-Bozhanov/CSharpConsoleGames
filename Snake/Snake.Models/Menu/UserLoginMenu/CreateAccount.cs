namespace Snake.Models.Menu.UserLoginMenu
{
    using Snake.Common;
    using Snake.Models.Menu.IO.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;

    using UserDatabase.Interfaces;

    using static Snake.Common.Messages;

    internal class CreateAccount : Menu
    {
        private const int SequenceNumber = 2;
        private const int DefaultPauseAfterMessages = 2000;
        private readonly IDatabase accounts;


        public CreateAccount(IRepository<string> namespaces, IDatabase accounts)
           : base(SequenceNumber, namespaces)
        {
            this.accounts = accounts;
        }

        public override int ID { get; protected set; }


        public override string GetName()
        {
            return CreateNewAccount;
        }

        public override string Execute(IRenderer renderer)
        {
            string username = string.Empty;
            string password = string.Empty;
            string confirmPass = string.Empty;

            renderer.Clear();
            renderer.Write(EnterUsername, MenuCoordinates.Row, MenuCoordinates.Col);
            username = renderer.ReadLine();

            renderer.Clear();
            renderer.Write(EnterPassword, MenuCoordinates.Row, MenuCoordinates.Col);
            password = renderer.PasswordMask();

            renderer.Clear();
            renderer.Write(ConfirmPassword, MenuCoordinates.Row, MenuCoordinates.Col);
            confirmPass = renderer.PasswordMask();

            if (password != confirmPass)
            {
                renderer.Write(PassNotMutch, MenuCoordinates.Row, MenuCoordinates.Col);
                Thread.Sleep(DefaultPauseAfterMessages);
                return null!;
            }

            try
            {
                accounts.AddAccount(username, password);
                renderer.Clear();
                renderer.Write(SuccessfulCreatedAccount, MenuCoordinates.Row, MenuCoordinates.Col);
                Thread.Sleep(DefaultPauseAfterMessages);
                namespaces.Add(NameSpacesInfo.MainMenu);
                string user = username + Environment.NewLine + password;
                return user;
            }
            catch (Exception ex)
            {
                renderer.Clear();
                renderer.Write(ex.Message, MenuCoordinates.Row, MenuCoordinates.Col);
                Thread.Sleep(DefaultPauseAfterMessages);
                return null!;
            }
        }
    }
}
