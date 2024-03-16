namespace Snake.Services.Interfaces
{
    using Snake.Models;
    using Snake.Models.Models;

    public interface ISnakeService
    {
        public IEnumerable<Coordinates> Body { get; }

        public Coordinates TailPossition { get; }

        public int Speed { get; }

        public SnakeModel ChangeNextHeadPossition(IDirectionService direction);

        public bool Eat(Coordinates food);

        public void GoThroughtWalls(Coordinates wallSize);

        public bool IsCrashToObstacle(IEnumerable<Coordinates> obstacles);

        public bool IsEatMySelf();

        public bool IsOnField();

        public void IncreaseSpeed(int speed);

        public void Move();
    }
}
