namespace GameMenu.Menues.UserLoginMenu
{
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;
    using UserDatabase.Interfaces;


    public class Login : Menu
    {
        private const int SequenceNumber = 1;
        private readonly IDatabase userDatabase;


        public Login(int row, int col, IRepository<string> namespaces, IDatabase users)
            : base(SequenceNumber, row, col, namespaces)
        {
            this.userDatabase = users;
        }


        public override int MenuNumber { get; protected set; }


        public override string Execute(IField field, IWriter writer, IReader reader)
        {
            IAccount user;
            string username = string.Empty;
            string password = string.Empty;

            writer.Clear();
            writer.Write("Enter username: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            username = reader.ReadLine();

            writer.Clear();
            writer.Write("Enter password: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            password = reader.ReadLine();

            try
            {
                user = this.userDatabase.GetAccount(username, password);

                writer.Clear();
                writer.Write("Successful login!", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                user.LastLoggedInTime = DateTime.Now;
                Thread.Sleep(2000);
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
