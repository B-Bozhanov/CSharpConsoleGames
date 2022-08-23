namespace GameMenu.Models.MainMenu
{
    using GameMenu.IO;
    using GameMenu.IO.Interfaces;
    using GameMenu.Models;
    using GameMenu.Repository.Interfaces;

    internal class NewGame : Menu
    {
        private const int Number = 1;
        private IWriter writer;


        public NewGame(int row, int col, IRepository<string> namespaces)
            : base(Number, row, col, namespaces)
        {
            this.writer = new ConsoleWriter();
        }

        public override string GetName()
        {
            return "New Game";
        }
        public override string Execute()
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
