namespace GameMenu.Menues.UserLoginMenu
{
    using GameMenu.IO;
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;
    using UserDatabase.Interfaces;

    internal class Login : Menu
    {
        private const int SequenceNumber = 1;
        private readonly IUserDatabase users;
        private IWriter writer;
        private IReader reader;

        public Login(int row, int col, IRepository<string> namespaces, IUserDatabase users)
            : base(SequenceNumber, row, col, namespaces)
        {
            this.users = users;
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
        }

        public override int MenuNumber { get; protected set; }

        public override string Execute(IField field)
        {
            string username = string.Empty;
            string password = string.Empty;
            IUser user;

            this.writer.Clear();
            this.writer.Write("Enter username: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            username = this.reader.ReadeLine();

            this.writer.Clear();
            this.writer.Write("Enter password: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            password = this.reader.ReadeLine();

            try
            {
                user = this.users.Get(username);
                if (!this.PasswordValidator(user, password))
                {
                    Execute(field);
                } 
                this.writer.Clear();
                this.writer.Write("Successful login!", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(2000);
                return username;
            }
            catch (Exception ex)
            {
                this.writer.Clear();
                this.writer.Write(ex.Message, this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(2000);
                return null!;
            }
        }

        private bool PasswordValidator(IUser user, string password)
        {
            if (user.Password != password)
            {
                this.writer.Clear();
                this.writer.Write("Incorect password, try again!", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(2000);
                return false;
            }
            return true;
        }
    }
}
