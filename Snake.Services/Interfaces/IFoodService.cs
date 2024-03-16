namespace Snake.Services.Interfaces
{
    using Snake.Models;

    public interface IFoodService
    {
        public Coordinates Coordinates { get; }

        public int RandomDisapearSeconds { get; }

        public Coordinates Generate(IEnumerable<Coordinates> snakeBody, IEnumerable<Coordinates> obstacles, Coordinates wallsSize);
    }
}
