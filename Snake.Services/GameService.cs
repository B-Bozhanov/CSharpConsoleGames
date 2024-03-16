namespace Snake.Services
{
    using System.Diagnostics;

    using Common;

    using Drowers;

    using Snake.Models;
    using Snake.Models.Models;
    using Snake.Services.Interfaces;

    public class GameService : IGameService
    {
        private readonly IDrower drower;
        private readonly IFieldService field;
        private readonly IInputHandlerService inputHandler;
        private readonly IDirectionService direction;
        private readonly ISnakeService snakeService;
        private readonly IScoreService scoreManager;
        private readonly IFoodService foodService;
        private readonly IObstacleService obstacleService;
        private readonly Stopwatch foodAppearTimer;
        private readonly Stopwatch obstaclesAppearTimer;
        private readonly Stopwatch obstaclesDisappearTimer;
        private bool isFirstObstaclesGenerated;
        private bool isWallsAppear;
        private bool isGoThroughtWalls;
        private int foodRandomDisappearSecondns;
        private int obstacleRandomAppearSecconds;
        private readonly int obstacleRandomDisappearSecconds;

        private readonly Coordinates wallSize;

        public GameService(IDrower drower, IFieldService field, IInputHandlerService inputHandler, IDirectionService direction, ISnakeService snakeService, IScoreService scoreManager, IFoodService foodService, IObstacleService obstacleService)
        {
            this.foodAppearTimer = new Stopwatch();
            this.obstaclesAppearTimer = new Stopwatch();
            this.obstaclesDisappearTimer = new Stopwatch();
            this.isFirstObstaclesGenerated = false;
            this.isWallsAppear = true;
            this.foodRandomDisappearSecondns = foodService.RandomDisapearSeconds;
            this.obstacleRandomAppearSecconds = obstacleService.RandomAppearSecconds;
            this.obstacleRandomDisappearSecconds = obstacleService.RandomDisappearSecconds;
            this.drower = drower;
            this.field = field;
            this.inputHandler = inputHandler;
            this.direction = direction;
            this.snakeService = snakeService;
            this.scoreManager = scoreManager;
            this.foodService = foodService;
            this.obstacleService = obstacleService;
            this.isGoThroughtWalls = true;
            this.wallSize = new Coordinates();

            this.foodAppearTimer.Start();
            this.foodService.Generate(snakeService.Body, obstacleService.Obstacles, wallSize);
            this.drower.Drow(foodService.Coordinates);
            this.drower.DrowInfoWindow(new Coordinates(0, 0));
        }

        public void Start()
        {
            while (true)
            {
                //Console.WriteLine(snake.Speed);
                int foodDisapearSeconds = this.foodAppearTimer.Elapsed.Seconds;
                this.drower.DrowInfoWindowData(this.scoreManager.Score, this.scoreManager.Level, Color.Yellow);

                KeyboardKey currentPressedKey = this.inputHandler.GetPressedKeyboardKey(KeyboardKey.None);
                this.direction.ChangeCurrentDirection(currentPressedKey);
                SnakeModel snake = snakeService.ChangeNextHeadPossition(direction);

                if (this.scoreManager.Level == GlobalConstants.Snake.WallsAppearLevel && this.isWallsAppear)
                {
                    this.drower.DrowWalls(new Coordinates(field.InfoWindowHeight + 2, 0));
                    this.drower.Drow(foodService.Coordinates);
                    this.wallSize.Row = 1;
                    this.wallSize.Column = 1;
                    this.isGoThroughtWalls = false;
                    this.isWallsAppear = false;
                }

                if (this.scoreManager.Level >= GlobalConstants.Snake.ObstaclesAppearLevel)
                {
                    if (!this.isFirstObstaclesGenerated)
                    {
                        this.obstacleService.GenerateFirstCount(this.field, snake.Body, this.foodService.Coordinates, this.wallSize);
                        this.drower.Drow(this.obstacleService.Obstacles);
                        this.obstaclesAppearTimer.Start();
                        this.obstaclesDisappearTimer.Start();
                        this.isFirstObstaclesGenerated = true;
                    }

                    int obstacleAppearSeconds = this.obstaclesAppearTimer.Elapsed.Seconds;

                    if (obstacleAppearSeconds >= this.obstacleRandomAppearSecconds)
                    {
                        Coordinates lastGeneratedObstacle = this.obstacleService.Generate(field, snake.Body, this.foodService.Coordinates, this.wallSize);
                        this.drower.Drow(lastGeneratedObstacle);
                        this.obstacleRandomAppearSecconds = this.obstacleService.RandomAppearSecconds;
                        this.obstaclesAppearTimer.Restart();
                    }

                    int obstacleDisappearSeconds = this.obstaclesDisappearTimer.Elapsed.Seconds;

                    if (obstacleDisappearSeconds >= this.obstacleRandomDisappearSecconds)
                    {
                        var removedObstacle = this.obstacleService.RandomDisappear();
                        this.drower.DrowEmpty(removedObstacle);
                        this.obstaclesDisappearTimer.Restart();
                    }
                }

                if (this.isGoThroughtWalls)
                {
                    this.snakeService.GoThroughtWalls(this.wallSize);
                }

                GameOver(this.isGoThroughtWalls, this.obstacleService.Obstacles, this.scoreManager.Level, this.scoreManager.Score);
                var isEat = this.snakeService.Eat(this.foodService.Coordinates);

                if (isEat)
                {
                    this.scoreManager.IncreaseScore(this.snakeService);
                    this.foodService.Generate(snake.Body, this.obstacleService.Obstacles, this.wallSize);
                    this.foodAppearTimer.Restart();
                }
                else if (foodDisapearSeconds >= this.foodRandomDisappearSecondns)
                {
                    this.drower.DrowEmpty(this.foodService.Coordinates);
                    Coordinates nextFood = foodService.Generate(snake.Body, this.obstacleService.Obstacles, this.wallSize);
                    this.drower.Drow(nextFood);
                    this.foodAppearTimer.Restart();
                    this.foodRandomDisappearSecondns = this.foodService.RandomDisapearSeconds;
                }

                this.snakeService.Move();

                this.drower.Drow(this.foodService.Coordinates);
                this.drower.Drow(snake.Body);
                this.drower.DrowEmpty(this.snakeService.TailPossition);
                Thread.Sleep(this.snakeService.Speed);
            }
        }

        private void GameOver(bool isGoThroughtWalls, IEnumerable<Coordinates> obstacles, int level, int score)
        {
            var isGameOver = false;
            if (!isGoThroughtWalls && level >= GlobalConstants.Snake.WallsAppearLevel)
            {
                if (this.snakeService.IsOnField())
                {
                    isGameOver = true;
                }
            }
            if (level >= GlobalConstants.Snake.ObstaclesAppearLevel)
            {
                if (this.snakeService.IsCrashToObstacle(obstacles))
                {
                    isGameOver = true;
                }
            }
            if (this.snakeService.IsEatMySelf())
            {
                isGameOver = true;
            }

            if (isGameOver)
            {
                this.drower.DrowGameOver(score, level, Color.Red);
                this.drower.Drow(snakeService.Body);
                Thread.Sleep(10000);
                Environment.Exit(0);
            }
        }
    }
}
