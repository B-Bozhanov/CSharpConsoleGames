using GameMenu.IO;
using GameMenu.IO.Interfaces;
using GameMenu.Repository.Interfaces;
using UserDatabase.Interfaces;
using UserDatabase;

namespace GameMenu.Models.UserLoginMenu
{
    internal class Login : Menu
    {
        private const int MenuNumber = 1;
        private readonly IUserDatabase users;
        private IWriter writer;
        private IReader reader;

        public Login(int row, int col, IRepository<string> namespaces, IUserDatabase users)
            : base(MenuNumber, row, col, namespaces)
        {
            this.users = users;
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
        }

        public override string Execute()
        {
            string username = string.Empty;
            string password = string.Empty;
            IUser user;

            while (true)
            {
                this.writer.Clear();
                this.writer.Write("Enter username: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                username = this.reader.ReadeLine();

                this.writer.Clear();
                this.writer.Write("Enter password: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                password = this.reader.ReadeLine();

                try
                {
                    user = this.users.Get(username);
                    break;
                }
                catch (Exception ex)
                {
                    this.writer.Clear();
                    this.writer.Write(ex.Message, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                }
            }
            return username;
        }
    }
}
