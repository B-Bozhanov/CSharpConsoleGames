namespace Snake.Services.Interfaces
{
    public interface IScoreService
    {
        public int Score { get; }

        public int Level { get; }

        public void IncreaseScore(ISnakeService snakeService);
    }
}
