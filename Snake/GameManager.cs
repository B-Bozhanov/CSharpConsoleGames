namespace Snake
{
    using System.Diagnostics;

    using Common;

    using Drowers;

    public class GameManager
    {
        private readonly IDrower drower;
        private readonly IField field;
        private readonly IInputHandler inputHandler;
        private readonly Direction direction;
        private readonly Snake snake;
        private readonly ScoreManager scoreManager;
        private readonly Food food;
        private readonly Obstacle obstacle;
        private readonly Stopwatch foodAppearTimer;
        private readonly Stopwatch obstaclesAppearTimer;
        private readonly Stopwatch obstaclesDisappearTimer;
        private bool isFirstObstaclesGenerated;
        private bool isWallsAppear;
        private bool isGoThroughtWalls;
        private int foodRandomDisappearSecondns;
        private int obstacleRandomAppearSecconds ;
        private readonly int obstacleRandomDisappearSecconds;

        private Coordinates wallSize;

        public GameManager(IDrower drower, IField field, IInputHandler inputHandler,Direction direction,Snake snake, ScoreManager scoreManager, Food food, Obstacle obstacle)
        {
            this.foodAppearTimer = new Stopwatch();
            this.obstaclesAppearTimer = new Stopwatch();
            this.obstaclesDisappearTimer = new Stopwatch();
            this.isFirstObstaclesGenerated = false;
            this.isWallsAppear = true;
            this.foodRandomDisappearSecondns = food.RandomDisapearSeconds;
            this.obstacleRandomAppearSecconds = obstacle.RandomAppearSecconds;
            this.obstacleRandomDisappearSecconds = obstacle.RandomDisappearSecconds;
            this.drower = drower;
            this.field = field;
            this.inputHandler = inputHandler;
            this.direction = direction;
            this.snake = snake;
            this.scoreManager = scoreManager;
            this.food = food;
            this.obstacle = obstacle;
            this.isGoThroughtWalls = true;
            this.wallSize = new Coordinates();

            this.foodAppearTimer.Start();
            this.food.Generate(snake.Body, obstacle.Obstacles, wallSize);
            this.drower.Drow(food.Coordinates);
            this.drower.DrowInfoWindow(new Coordinates(0, 0));
        }

        public void Start()
        {
            while (true)
            {
                //Console.WriteLine(snake.Speed);
                int foodDisapearSeconds = foodAppearTimer.Elapsed.Seconds;
                drower.DrowInfoWindowData(scoreManager.Score, scoreManager.Level, Color.Yellow);

                var currentPressedKey = inputHandler.GetPressedKeyboardKey(KeyboardKey.None);
                direction.ChangeCurrentDirection(currentPressedKey);
                snake.ChangeNextHeadPossition(direction);

                if (scoreManager.Level == GlobalConstants.Snake.WallsAppearLevel && isWallsAppear)
                {
                    drower.DrowWalls(new Coordinates(field.InfoWindowHeight + 2, 0));
                    drower.Drow(food.Coordinates);
                    wallSize.Row = 1;
                    wallSize.Column = 1;
                    isGoThroughtWalls = false;
                    isWallsAppear = false;
                }

                if (scoreManager.Level >= GlobalConstants.Snake.ObstaclesAppearLevel)
                {
                    if (!isFirstObstaclesGenerated)
                    {
                        obstacle.GenerateFirstCount(field, snake.Body, food.Coordinates, wallSize);
                        drower.Drow(obstacle.Obstacles);
                        obstaclesAppearTimer.Start();
                        obstaclesDisappearTimer.Start();
                        isFirstObstaclesGenerated = true;
                    }

                    int obstacleAppearSeconds = obstaclesAppearTimer.Elapsed.Seconds;

                    if (obstacleAppearSeconds >= obstacleRandomAppearSecconds)
                    {
                        Coordinates lastGeneratedObstacle = obstacle.Generate(field, snake.Body, food.Coordinates, wallSize);
                        drower.Drow(lastGeneratedObstacle);
                        obstacleRandomAppearSecconds = obstacle.RandomAppearSecconds;
                        obstaclesAppearTimer.Restart();
                    }

                    int obstacleDisappearSeconds = obstaclesDisappearTimer.Elapsed.Seconds;

                    if (obstacleDisappearSeconds >= obstacleRandomDisappearSecconds)
                    {
                        var removedObstacle = obstacle.RandomDisappear();
                        drower.DrowEmpty(removedObstacle);
                        obstaclesDisappearTimer.Restart();
                    }
                }

                if (isGoThroughtWalls)
                {
                    snake.GoThroughtWalls(wallSize);
                }

                this.GameOver(snake, isGoThroughtWalls, obstacle.Obstacles, scoreManager.Level, scoreManager.Score);
                var isEat = snake.Eat(food.Coordinates);

                if (isEat)
                {
                    scoreManager.IncreaseScore(snake);
                    food.Generate(snake.Body, obstacle.Obstacles, wallSize);
                    foodAppearTimer.Restart();
                }
                else if (foodDisapearSeconds >= foodRandomDisappearSecondns)
                {
                    drower.DrowEmpty(food.Coordinates);
                    Coordinates nextFood = food.Generate(snake.Body, obstacle.Obstacles, wallSize);
                    drower.Drow(nextFood);
                    foodAppearTimer.Restart();
                    foodRandomDisappearSecondns = food.RandomDisapearSeconds;
                }

                snake.Move();

                drower.Drow(food.Coordinates);
                drower.Drow(snake.Body);
                drower.DrowEmpty(snake.TailPossition);
                Thread.Sleep(snake.Speed);
            }
        }

        public void GameOver(Snake snake, bool isGoThroughtWalls, IEnumerable<Coordinates> obstacles, int level, int score)
        {
            var isGameOver = false;
            if (!isGoThroughtWalls && level >= GlobalConstants.Snake.WallsAppearLevel)
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
                this.drower.Drow(snake.Body);
                Thread.Sleep(10000);
                Environment.Exit(0);
            }
        }
    }
}
