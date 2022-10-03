namespace Snake.Core
{
    using GameMenu.Core.Interfaces;
    using Snake.Core.Interfaces;
    using UserDatabase.Interfaces;
    using Snake.Models;

    public class SnakeEngine : ISnakeEngine
    {
        private IAccount user;
        private IField field;
        private Snake snake;
        public SnakeEngine(IAccount user, IField field)
        {
            this.user = user;
            this.field = field;
            this.snake = new Snake();
        }
        public void StartGame()
        {
            foreach (var item in snake.Elements)
            {
                Console.SetCursorPosition(item.Col, item.Row);
                Console.Write("*");
            }

            while (true)
            {
                snake.Move();

                foreach (var item in snake.Elements)
                {
                    Console.SetCursorPosition(item.Col, item.Row);
                    Console.Write("*");
                }

                Thread.Sleep(120);
            }
        }
    }
}
