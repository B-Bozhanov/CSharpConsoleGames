namespace GameMenu.Menues.UserLoginMenu
{
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;
    using System.Diagnostics;
    using UserDatabase;
    using UserDatabase.Interfaces;

    internal class CreateAccount : Menu
    {
        private const int SequenceNumber = 2;
        private readonly IDatabase accounts;


        public CreateAccount(int row, int col, IRepository<string> namespaces, IDatabase accounts)
           : base(SequenceNumber, row, col, namespaces)
        {
            this.accounts = accounts;
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
            string confirmPass = string.Empty;

            writer.Clear();
            writer.Write("Enter username: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            username = reader.ReadLine();

            writer.Clear();
            writer.Write("Enter password: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            password = reader.ReadLine();

            writer.Clear();
            writer.Write("Confirm password: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            confirmPass = reader.ReadLine();

            if (password != confirmPass)
            {
                writer.Write("Password not matching, try again: ", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(2000);
                return null!;
            }

            try
            {
                this.accounts.AddAccount(username, password);
                writer.Clear();
                writer.Write("Account is successful created!", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                Thread.Sleep(2000);
                string user = username + Environment.NewLine + password;
                return user;
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
