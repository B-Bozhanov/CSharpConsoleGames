namespace GameMenu.Menues.UserLoginMenu
{
    using static GameMenu.Utilities.Messages;

    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;
    using UserDatabase.Interfaces;
    using GameMenu.Utilities;
    using GameMenu.Core.Interfaces;

    public class Login : Menu
    {
        private const int SequenceNumber = 1;
        private readonly IDatabase userDatabase;


        public Login(IRepository<string> namespaces, IDatabase users)
            : base(SequenceNumber, namespaces)
        {
            this.userDatabase = users;
        }


        public override int ID { get; protected set; }


        public override string Execute(IWriter writer, IReader reader)
        {
            string username = string.Empty;
            string password = string.Empty;

            writer.Clear();
            writer.Write(EnterUsername, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            username = reader.ReadLine();

            writer.Clear();
            writer.Write(EnterPassword, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            password = writer.PasswordMask();

            try
            {
                this.userDatabase.GetAccount(username, password);

                writer.Clear();
                writer.Write(SuccessfulLogin, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(2000);
                base.namespaces.Add(NameSpacesInfo.MainMenu);
                string currentUser = username + Environment.NewLine + password;
                return currentUser;
            }
            catch (Exception ex)
            {
                writer.Clear();
                writer.Write(ex.Message, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(2000);
                return null!;
            }
        }
    }
}
