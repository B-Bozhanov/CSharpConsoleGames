namespace GameMenu.Models.Menuses.MainMenu
{
    using GameMenu.IO;
    using GameMenu.IO.Interfaces;
    using GameMenu.Models.Menuses.MainMenu.Interfaces;
    using Snake.Core;
    using Snake.Core.Interfaces;

    internal class NewGame : Menu, IMainMenu
    {
        private const int Number = 1;
        private readonly ISnakeEngine engine;
        private IWriter writer;


        public NewGame(int row, int col) 
            : base(Number, row, col)
        {
            this.engine = new SnakeEngine();
            this.writer = new ConsoleWriter();
        }

        public override string GetName()
        {
            return "New Game";
        }
        public override Type Execute()
        {
            int timer = 5;
            writer.Clear();

            while (timer != 0)
            {
                writer.Write(timer.ToString(), this.MenuCoordinates.Row, this.MenuCoordinates.Col);
                timer--;
                Thread.Sleep(1000);
            }

            engine.StartGame();
            return null;
        }
    }
}
