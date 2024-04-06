namespace Snake.Services
{
    using System.Diagnostics;
    using System.Reflection;

    using Common;

    using Drowers;

    using Snake.Models;
    using Snake.Models.Models.Menues;
    using Snake.Models.Models.Snake;
    using Snake.Services.Interfaces;

    public class GameService : IGameService
    {
        private readonly IDrowerService drowerService;
        private readonly IFieldService field;
        private readonly IInputHandlerService inputHandlerService;
        private readonly IDirectionService direction;
        private readonly ISnakeService snakeService;
        private readonly IScoreService scoreManager;
        private readonly IFoodService foodService;
        private readonly IObstacleService obstacleService;
        private readonly ICursorService cursorService;
        private readonly IMenuService menuService;
        private readonly Stopwatch foodAppearTimer;
        private readonly Stopwatch obstaclesAppearTimer;
        private readonly Stopwatch obstaclesDisappearTimer;
        private bool isFirstObstaclesGenerated;
        private bool isWallsAppear;
        private bool isGoThroughtWalls;
        private int foodRandomDisappearSecondns;
        private int obstacleRandomAppearSecconds;
        private readonly int obstacleRandomDisappearSecconds;
        private readonly Stack<string> namespaces;
        private readonly Assembly menuesAssembly;
        private readonly Coordinates wallSize;
        private HashSet<IMenu> menues;
        private bool isMenuesCreated;

        public GameService()
        {
            this.foodAppearTimer = new Stopwatch();
            this.obstaclesAppearTimer = new Stopwatch();
            this.obstaclesDisappearTimer = new Stopwatch();
            this.wallSize = new Coordinates();
            this.isFirstObstaclesGenerated = false;
            this.isWallsAppear = true;
            this.isGoThroughtWalls = true;
            this.isMenuesCreated = false;
            this.menues = [];

            this.namespaces = new Stack<string>();
        }

        public GameService(IDrowerService drower, 
            IFieldService field, 
            IInputHandlerService inputHandler,
            IDirectionService direction, 
            ISnakeService snakeService, 
            IScoreService scoreManager,
            IFoodService foodService, 
            IObstacleService obstacleService,
            ICursorService cursorService,
            IMenuService menuService) 
            : this()
        {
            this.foodRandomDisappearSecondns = foodService.RandomDisapearSeconds;
            this.obstacleRandomAppearSecconds = obstacleService.RandomAppearSecconds;
            this.obstacleRandomDisappearSecconds = obstacleService.RandomDisappearSecconds;
            this.drowerService = drower;
            this.field = field;
            this.inputHandlerService = inputHandler;
            this.direction = direction;
            this.snakeService = snakeService;
            this.scoreManager = scoreManager;
            this.foodService = foodService;
            this.obstacleService = obstacleService;
            this.cursorService = cursorService;
            this.menuService = menuService;
        }

        public void Start()
        {
            this.StartMenues();

            this.foodAppearTimer.Start();
            this.foodService.Generate(this.snakeService.Body, this.obstacleService.Obstacles, this.wallSize);
            this.StartMainGame();
        }

        private void StartMenues()
        {
            while (true)
            {
                if (!this.isMenuesCreated)
                {
                    this.menues =
                    [
                        .. this.menuService
                            .Create<IMenu>()
                            .OrderBy(x => x.PriorityNumber)
                    ];

                    this.isMenuesCreated = true;
                }

                this.drowerService.Drow(menues);
                var currentCursorPossition = this.cursorService.Move(this.inputHandlerService, this.drowerService, this.menues.Count);
                this.isMenuesCreated = false;

                var currentSelectedMenu = menues.First(x => x.Coordinates.Equals(currentCursorPossition));
                currentSelectedMenu.Execute(this.namespaces);
                Console.WriteLine();
            }


            this.drowerService.Drow(foodService.Coordinates);
            this.drowerService.DrowInfoWindow(new Coordinates());
        }

        private void StartMainGame()
        {
            while (true)
            {
                //Console.WriteLine(snake.Speed);
                int foodDisapearSeconds = this.foodAppearTimer.Elapsed.Seconds;
                this.drowerService.DrowInfoWindowData(this.scoreManager.Score, this.scoreManager.Level, Color.Yellow);

                KeyboardKey currentPressedKey = this.inputHandlerService.GetPressedKeyboardKey();
                this.direction.ChangeCurrentDirection(currentPressedKey);
                SnakeModel snake = snakeService.ChangeNextHeadPossition(direction);

                if (this.scoreManager.Level == GlobalConstants.Snake.WallsAppearLevel && this.isWallsAppear)
                {
                    this.drowerService.DrowWalls(new Coordinates(field.InfoWindowHeight + 2, 0));
                    this.drowerService.Drow(foodService.Coordinates);
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
                        this.drowerService.Drow(this.obstacleService.Obstacles);
                        this.obstaclesAppearTimer.Start();
                        this.obstaclesDisappearTimer.Start();
                        this.isFirstObstaclesGenerated = true;
                    }

                    int obstacleAppearSeconds = this.obstaclesAppearTimer.Elapsed.Seconds;

                    if (obstacleAppearSeconds >= this.obstacleRandomAppearSecconds)
                    {
                        Coordinates lastGeneratedObstacle = this.obstacleService.Generate(field, snake.Body, this.foodService.Coordinates, this.wallSize);
                        this.drowerService.Drow(lastGeneratedObstacle);
                        this.obstacleRandomAppearSecconds = this.obstacleService.RandomAppearSecconds;
                        this.obstaclesAppearTimer.Restart();
                    }

                    int obstacleDisappearSeconds = this.obstaclesDisappearTimer.Elapsed.Seconds;

                    if (obstacleDisappearSeconds >= this.obstacleRandomDisappearSecconds)
                    {
                        var removedObstacle = this.obstacleService.RandomDisappear();
                        this.drowerService.DrowEmpty(removedObstacle);
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
                    this.drowerService.DrowEmpty(this.foodService.Coordinates);
                    Coordinates nextFood = foodService.Generate(snake.Body, this.obstacleService.Obstacles, this.wallSize);
                    this.drowerService.Drow(nextFood);
                    this.foodAppearTimer.Restart();
                    this.foodRandomDisappearSecondns = this.foodService.RandomDisapearSeconds;
                }

                this.snakeService.Move();

                this.drowerService.Drow(this.foodService.Coordinates);
                this.drowerService.Drow(snake.Body);
                this.drowerService.DrowEmpty(this.snakeService.TailPossition);
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
                this.drowerService.DrowGameOver(score, level, Color.Red);
                this.drowerService.Drow(snakeService.Body);
                Thread.Sleep(10000);
                Environment.Exit(0);
            }
        }
    }
}
