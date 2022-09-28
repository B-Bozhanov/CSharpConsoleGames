namespace GameMenu.Menues.MainMenu
{
    using GameMenu.Core.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.Menues;
    using GameMenu.Repository.Interfaces;


    internal class NewGame : Menu
    {
        private const int SequenceNumber = 1;


        public NewGame(int row, int col, IRepository<string> namespaces)
            : base(SequenceNumber, row, col, namespaces)
        {
        }

        public override int MenuNumber { get; protected set; }


        public override string GetName()
        {
            return "New Game";
        }
        public override string Execute(IField field, IWriter writer, IReader reader)
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
