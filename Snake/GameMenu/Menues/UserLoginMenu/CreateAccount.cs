namespace GameMenu.Menues.UserLoginMenu
{
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;
    using UserDatabase;
    using UserDatabase.Interfaces;

    internal class CreateAccount : Menu
    {
        private const int SequenceNumber = 2;
        private readonly IDatabase users;


        public CreateAccount(int row, int col, IRepository<string> namespaces, IDatabase users)
           : base(SequenceNumber, row, col, namespaces)
        {
            this.users = users;
        }

        public override int MenuNumber { get; protected set; }


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
                username = reader.ReadLine();

                writer.Clear();
                writer.Write("Enter password: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                password = reader.ReadLine();

                try
                {
                    IAccount account = new Account(username, password, score);
                    this.users.AddAccount(account);
                    account.CreatedTime = DateTime.Now;
                    account.LastLoggedInTime = DateTime.Now;
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
