namespace SnakeProject.Core
{
    using SnakeProject.Core.Interfaces;
    using SnakeProject.Models;
    using SnakeProject.Utilites;

    internal class Controller : IController
    {
       

        public Controller()
        {
            
        }

        public void Move(ISnake snake)
        {
            snake.NextPossition();
            var snakeNextHead = snake.GetSnakeNextHead();

            if (IsGameOver(snakeNextHead))
            {
                throw new IndexOutOfRangeException("Game over!");
            }


            snake.Move();
        }
        public bool IsGameOver(Coordinates snakeHead)
        {
            return false;
        }

    }
}
