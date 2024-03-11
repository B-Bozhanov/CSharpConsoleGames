using System.Diagnostics;
using System.Text;

using Common;

using Snake;
using Snake.Drowers;

using static Common.GlobalConstants;

int Score = 0;
int Level = 1;

int snakeSpeed = 150;

var wallSize = new Coordinates();
bool isGoThroughtWalls = true;

IDrower drower = new ConsoleDrower();

var gameManager = new GameManager(drower);

SetConsoleSettings();

var snake = new Snake.Snake(GlobalConstants.Snake.StartPossition);
var direction = new Direction();
var food = new Food();
var obstacle = new Obstacle();
IInputHandler consoleInputHandler = new ConsoleInputHandler();

Stopwatch foodAppearTimer = new Stopwatch();
Stopwatch obstaclesAppearTimer = new Stopwatch();
Stopwatch obstaclesDisappearTimer = new Stopwatch();

foodAppearTimer.Start();
food.Generate(snake.Body, obstacle.Obstacles, wallSize);
bool isFirstObstaclesGenerated = false;

drower.DrowInfoWindow(new Coordinates(0, 0));
drower.Drow(food.Coordinates);
int foodRandomDisappearSecondns = food.RandomDisapearSeconds;
int obstacleRandomAppearSecconds = obstacle.RandomAppearSecconds;
int obstacleRandomDisappearSecconds = obstacle.RandomDisappearSecconds;

while (true)
{
    int foodDisapearSeconds = foodAppearTimer.Elapsed.Seconds;
    drower.DrowInfoWindowData(Score, Level, Color.Yellow);

    var currentPressedKey = consoleInputHandler.GetPressedKeyboardKey(KeyboardKey.None);
    direction.ChangeCurrentDirection(currentPressedKey);
    snake.ChangeNextHeadPossition(direction);

    //var level = scoreManager.GetLevel();

    if (Level >= GlobalConstants.Snake.ObstaclesAppearLevel)
    {
        if (!isFirstObstaclesGenerated)
        {
            obstacle.GenerateFirstCount(snake.Body, food.Coordinates, wallSize);
            drower.Drow(obstacle.Obstacles);
            obstaclesAppearTimer.Start();
            obstaclesDisappearTimer.Start();
            isFirstObstaclesGenerated = true;
        }

        int obstacleAppearSeconds = obstaclesAppearTimer.Elapsed.Seconds;

        if (obstacleAppearSeconds >= obstacleRandomAppearSecconds)
        {
            var lastGeneratedObstacle = obstacle.Generate(snake.Body, food.Coordinates, wallSize);
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

    if (Level == 10)
    {
        drower.DrowWalls(new Coordinates(Field.InfoWindowHeight + 2, 0));
        drower.Drow(food.Coordinates);
        wallSize.Row = 1;
        wallSize.Column = 1;
        isGoThroughtWalls = false;
    }

    gameManager.GameOver(snake, isGoThroughtWalls, obstacle.Obstacles, Level, Score);
    var isEat = snake.Eat(food.Coordinates);

    if (isEat)
    {
        if (snake.Body.Count % 10 == 0)
        {
            Level++;
            snakeSpeed -= 5;
        }
        food.Generate(snake.Body, obstacle.Obstacles, wallSize);
        snakeSpeed -= 1;
        Score += 1 * Level;
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
    Thread.Sleep(snakeSpeed);
}
void SetConsoleSettings()
{
    Console.CursorVisible = false;
    Console.Title = GlobalConstants.Snake.Name;
    Console.SetWindowSize(Field.FieldColumns, Field.FieldRows + 1);
    Console.SetBufferSize(Field.FieldColumns, Field.FieldRows + 1);
    Console.OutputEncoding = Encoding.UTF8;
}