namespace Snake.Core
{
    using GameMenu.Core.Interfaces;
    using Snake.Core.Interfaces;
    using UserDatabase.Interfaces;
    using Snake.Models.Interfaces;
    using GameMenu.UserInputHandle.Interfaces;
    using GameMenu.IO.Interfaces;
    using Snake.Utilities;

    public class SnakeEngine : ISnakeEngine
    {
        private IField field;
        private ISnake snake;
        private IUserInput input;
        private IRenderer renderer;

        public SnakeEngine(IField field, ISnake snake, IUserInput input, IRenderer renderer)
        {
            this.field = field;
            this.snake = snake;
            this.input = input;
            this.renderer = renderer;
        }

        public void StartGame(IAccount account)
        {
            while (true)
            {
                Coordinates tail =  snake.Move(this.input, this.field);
                this.renderer.Write(" ", tail.Row, tail.Col);

                foreach (var item in snake.Elements)
                {
                    this.renderer.Write("*", item.Row, item.Col);
                }

                Thread.Sleep(120);
            }
        }
    }
}
