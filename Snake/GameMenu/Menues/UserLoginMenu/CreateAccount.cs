namespace GameMenu.Menues.UserLoginMenu
{
    using static GameMenu.Utilities.Messages;

    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;
    using UserDatabase.Interfaces;
    using GameMenu.Utilities;

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
            renderer.Write(EnterUsername, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            username = renderer.ReadLine();

            renderer.Clear();
            renderer.Write(EnterPassword, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            password = renderer.PasswordMask();

            renderer.Clear();
            renderer.Write(ConfirmPassword, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            confirmPass = renderer.PasswordMask();

            if (password != confirmPass)
            {
                renderer.Write(PassNotMutch, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(DefaultPauseAfterMessages);
                return null!;
            }

            try
            {
                this.accounts.AddAccount(username, password);
                renderer.Clear();
                renderer.Write(SuccessfulCreatedAccount, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(DefaultPauseAfterMessages);
                this.namespaces.Add(NameSpacesInfo.MainMenu);
                string user = username + Environment.NewLine + password;
                return user;
            }
            catch (Exception ex)
            {
                renderer.Clear();
                renderer.Write(ex.Message, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(DefaultPauseAfterMessages);
                return null!;
            }
        }
    }
}
