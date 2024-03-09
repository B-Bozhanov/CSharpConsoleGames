namespace Snake
{
    using Common;

    using global::Snake.Drowers;

    public class GameManager(IDrower drower)
    {
        private readonly IDrower drower = drower;

        public void GameOver(Snake snake, bool isGoThroughtWalls, IEnumerable<Coordinates> obstacles, int level, int score)
        {
            var isGameOver = false;
            if (isGoThroughtWalls && level >= 10)
            {
                if (snake.IsOnField())
                {
                    isGameOver = true;
                }
            }
            if (level >= GlobalConstants.Snake.ObstaclesAppearLevel)
            {
                if (snake.IsCrashToObstacle(obstacles))
                {
                    isGameOver = true;
                }
            }
            if (snake.IsEatMySelf())
            {
                isGameOver = true;
            }

            if (isGameOver)
            {
                this.drower.DrowGameOver(score, level, Color.Red);
                Thread.Sleep(10000);
                Environment.Exit(0);
            }
        }
    }
}
