namespace GameMenu.Menues.MainMenu
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Repository.Interfaces;
    using UserDatabase.Interfaces;

    internal class Logout : Menu
    {
        private const int SequenceNumber = 3;

        private readonly IDatabase users;

        public Logout(IRepository<string> namespaces, IDatabase users) 
            : base(SequenceNumber, namespaces)
        {
            this.users = users;
        }

        public override int ID { get; protected set; }

        public override string Execute(IField field, IWriter writer)
        {
            writer.Clear();
            writer.Write("Successful logout!", this.MenuCoordinates.Row, this.MenuCoordinates.Col);
            // TODO: Remove Guest player
            field.ResetColor();
            Thread.Sleep(2000);
            this.BackCommand();
            return null;
        }
    }
}
