namespace Snake.Models.Menu.UserLoginMenu
{
    using System;
    using System.Threading;

    using Snake.Common;
    using Snake.Models.Menu;
    using Snake.Models.Menu.IO.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;

    using UserDatabase.Interfaces;

    using static Snake.Common.Messages;

    public class Login : Menu
    {
        private const int SequenceNumber = 1;
        private readonly IDatabase userDatabase;


        public Login(IRepository<string> namespaces, IDatabase users)
            : base(SequenceNumber, namespaces)
        {
            userDatabase = users;
        }


        public override int ID { get; protected set; }


        public override string Execute(IRenderer renderer)
        {
            string username = string.Empty;
            string password = string.Empty;

            renderer.Clear();
            renderer.Write(EnterUsername, MenuCoordinates.Row, MenuCoordinates.Col);
            username = renderer.ReadLine();

            renderer.Clear();
            renderer.Write(EnterPassword, MenuCoordinates.Row, MenuCoordinates.Col);
            password = renderer.PasswordMask();

            try
            {
                userDatabase.GetAccount(username, password);

                renderer.Clear();
                renderer.Write(SuccessfulLogin, MenuCoordinates.Row, MenuCoordinates.Col);
                Thread.Sleep(2000);
                namespaces.Add(NameSpacesInfo.MainMenu);
                string currentUser = username + Environment.NewLine + password;
                return currentUser;
            }
            catch (Exception ex)
            {
                renderer.Clear();
                renderer.Write(ex.Message, MenuCoordinates.Row, MenuCoordinates.Col);
                Thread.Sleep(2000);
                return null!;
            }
        }
    }
}
