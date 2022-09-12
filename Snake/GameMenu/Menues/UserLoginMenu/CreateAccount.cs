using GameMenu.IO;
using GameMenu.IO.Interfaces;
using GameMenu.Menues.Interfaces;
using GameMenu.Repository.Interfaces;
using UserDatabase;
using UserDatabase.Interfaces;

namespace GameMenu.Menues.UserLoginMenu
{
    internal class CreateAccount : Menu
    {
        private const int SequenceNumber = 2;
        private readonly IUserDatabase users;


        public CreateAccount(int row, int col, IRepository<string> namespaces, IUserDatabase users)
           : base(SequenceNumber, row, col, namespaces)
        {
            this.users = users;
        }

        public override int MenuNumber { get ; protected set ; }

        public override string GetName()
        {
            return "Create new account";
        }

        public override string Execute(IField field, IWriter writer, IReader reader)
        {
            string username = string.Empty;
            string password = string.Empty;
            int score = 0;

            while (true)
            {
                writer.Clear();
                writer.Write("Enter username: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                username = reader.ReadeLine();

                writer.Clear();
                writer.Write("Enter password: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                password = reader.ReadeLine();

                try
                {
                    IUser user = new User(username, password, score);
                    this.users.Add(user);
                    //this.users.SaveDatabase();
                    break;
                }
                catch (Exception ex)
                {
                    writer.Clear();
                    writer.Write(ex.Message, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                    Thread.Sleep(2000);
                }
            }
            writer.Clear();
            writer.Write("Account is successful created!", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            Thread.Sleep(2000);
            return username;
        }
    }
}
