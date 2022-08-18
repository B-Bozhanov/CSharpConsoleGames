namespace SnakeProject.Core.Interfaces
{
    using SnakeProject.Utilites;

    internal interface IController
    {
        public void Move(ISnake snake);
        public bool IsGameOver(Coordinates cords);
    }
}
