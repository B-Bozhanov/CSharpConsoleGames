namespace Snake.Services.Core
{
    using Snake.Models.Menu.Core.Interfaces;
    using Snake.Models.Menu.IO.Interfaces;
    using Snake.Models.Menu.UserInputHandle.Interfaces;
    using Snake.Services.Core.Interfaces;
    using Snake.Services.Models.Interfaces;

    using UserDatabase.Interfaces;

    public class SnakeEngine : ISnakeEngine
    {
        private readonly IField field;
        private readonly ISnake snake;
        private readonly IUserInput userInput;
        private readonly IObstacle obstacle;
        private readonly IFood food;
        private readonly IRenderer renderer;

        public SnakeEngine(IField field, ISnake snake, IUserInput userInput, IObstacle obstacle, IFood food, IRenderer renderer)
        {
            this.field = field;
            this.snake = snake;
            this.userInput = userInput;
            this.obstacle = obstacle;
            this.food = food;
            this.renderer = renderer;
        }

        public void StartGame(IAccount account)
        {
            while (true)
            {
                var test = snake.Move(this.field, this.userInput, this.obstacle, this.food);

                renderer.Write(" ", test.Row, test.Col);
                foreach (var item in snake.Elements)
                {
                    renderer.Write(item.Symbol.ToString(), item.Row, item.Col);
                }

                Thread.Sleep(120);
            }
        }
    }
}
