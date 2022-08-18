namespace SnakeProject.Core
{
    using Models;
    using Core.IO;
    using Utilites;
    using Models.Field;
    using Core.Interfaces;
    using Core.IO.Interfaces;
    using Models.Field.Interfaces;

    public class GameEngine : IGameEngine
    {
        private readonly IController controller;
        private readonly ISnake snake;
        private readonly IWriter writer;
        private readonly IField field;

        public GameEngine()
        {
            this.controller = new Controller();
            this.field = new Field(new Coordinates(30, 120));
            this.writer = new ConsoleWriter(field);
            this.snake = new Snake(6, field.GameInfoWindow);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    this.writer.DrowingInfoWindow();
                    this.controller.Move(this.snake);
                    this.writer.DrowingSnake(snake);

                }
                catch (Exception ex)
                {
                    if (ex.Message == "Game over!")
                    {
                    }
                }
                Thread.Sleep(100);
                this.writer.DrowingSnake(snake);
            }
        }
    }
}
