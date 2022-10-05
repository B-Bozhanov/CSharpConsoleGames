namespace Snake.Core
{
    using GameMenu.Core.Interfaces;
    using Snake.Core.Interfaces;
    using UserDatabase.Interfaces;
    using Snake.Models.Interfaces;
    using GameMenu.IO.Interfaces;
    using GameMenu.UserInputHandle.Interfaces;

    public class SnakeEngine : ISnakeEngine
    {
        private IField field;
        private ISnake snake;
        private IRenderer renderer;
        private IUserInput userInput;

        public SnakeEngine(IField field, ISnake snake, IRenderer renderer, IUserInput userInput)
        {
            this.field = field;
            this.snake = snake;
            this.renderer = renderer;
            this.userInput = userInput;
        }

        public void StartGame(IAccount account)
        {
            while (true)
            {
                var tail = snake.Move(this.field, this.userInput);
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
