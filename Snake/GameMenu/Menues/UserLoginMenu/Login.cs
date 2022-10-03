namespace GameMenu.Menues.UserLoginMenu
{
    using static GameMenu.Utilities.Messages;

    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;
    using UserDatabase.Interfaces;
    using GameMenu.Utilities;

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


        public override string Execute(IRenderer renderer)
        {
            string username = string.Empty;
            string password = string.Empty;

            renderer.Clear();
            renderer.Write(EnterUsername, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            username = renderer.ReadLine();

            renderer.Clear();
            renderer.Write(EnterPassword, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            password = renderer.PasswordMask();

            try
            {
                this.userDatabase.GetAccount(username, password);

                renderer.Clear();
                renderer.Write(SuccessfulLogin, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(2000);
                base.namespaces.Add(NameSpacesInfo.MainMenu);
                string currentUser = username + Environment.NewLine + password;
                return currentUser;
            }
            catch (Exception ex)
            {
                renderer.Clear();
                renderer.Write(ex.Message, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(2000);
                return null!;
            }
        }
    }
}
