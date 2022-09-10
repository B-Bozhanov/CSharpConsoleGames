namespace GameMenu.Menues.MainMenu
{
    using GameMenu.IO;
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues;
    using GameMenu.Menues.Interfaces;
    using GameMenu.Repository.Interfaces;

    internal class NewGame : Menu
    {
        private const int SequenceNumber = 1;
        private readonly IWriter writer;


        public NewGame(int row, int col, IRepository<string> namespaces)
            : base(SequenceNumber, row, col, namespaces)
        {
            this.writer = new ConsoleWriter();
        }

        public override int MenuNumber { get; protected set; }


        public override string GetName()
        {
            return "New Game";
        }
        public override string Execute(IField field)
        {
            int timer = 5;
            writer.Clear();

            while (timer != 0)
            {
                writer.Write(timer.ToString(), this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                timer--;
                Thread.Sleep(1000);
            }

            return "NewGame";
        }
    }
}
