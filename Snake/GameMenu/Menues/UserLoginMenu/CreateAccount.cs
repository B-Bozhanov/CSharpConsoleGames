namespace GameMenu.Menues.UserLoginMenu
{
    using static GameMenu.Utilities.Messages;

    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;
    using UserDatabase.Interfaces;
    using GameMenu.Utilities;
    using GameMenu.Core.Interfaces;

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

        public override string Execute(IWriter writer, IReader reader)
        {
            string username = string.Empty;
            string password = string.Empty;
            string confirmPass = string.Empty;

            writer.Clear();
            writer.Write(EnterUsername, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            username = reader.ReadLine();

            writer.Clear();
            writer.Write(EnterPassword, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            password = writer.PasswordMask();

            writer.Clear();
            writer.Write(ConfirmPassword, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            confirmPass = writer.PasswordMask();

            if (password != confirmPass)
            {
                writer.Write(PassNotMutch, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(DefaultPauseAfterMessages);
                return null!;
            }

            try
            {
                this.accounts.AddAccount(username, password);
                writer.Clear();
                writer.Write(SuccessfulCreatedAccount, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(DefaultPauseAfterMessages);
                this.namespaces.Add(NameSpacesInfo.MainMenu);
                string user = username + Environment.NewLine + password;
                return user;
            }
            catch (Exception ex)
            {
                writer.Clear();
                writer.Write(ex.Message, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(DefaultPauseAfterMessages);
                return null!;
            }
        }
    }
}
