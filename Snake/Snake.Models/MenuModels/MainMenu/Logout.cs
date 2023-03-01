namespace Snake.Models.Menu.MainMenu
{
    using System.Threading;

    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.IO.Interfaces;
    using Snake.Models.Menu.Repository.Interfaces;

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

        public override string Execute(IField field, IRenderer renderer)
        {
            renderer.Clear();
            renderer.Write("Successful logout!", MenuCoordinates.Row, MenuCoordinates.Col);
            // TODO: Remove Guest player
            field.ResetColor();
            Thread.Sleep(2000);
            BackCommand();
            return null;
        }
    }
}
