namespace GameMenu.Menues.MainMenu
{
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;
    using UserDatabase.Interfaces;

    internal class Logout : Menu
    {
        private const int SequenceNumber = 3;

        private readonly IDatabase users;

        public Logout(int row, int col, IRepository<string> namespaces, IDatabase users) 
            : base(SequenceNumber, row, col, namespaces)
        {
            this.users = users;
        }

        public override int MenuNumber { get; protected set; }

        public override string Execute(IField field, IWriter writer, IReader reader)
        {
            writer.Clear();
            writer.Write("Successful logout!", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            Thread.Sleep(2000);
            return this.BackCommand();
        }
    }
}
