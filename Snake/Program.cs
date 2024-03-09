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
drower.DrowInfoWindow(new Coordinates(0, 0));

var snake = new Snake.Snake(GlobalConstants.Snake.StartPossition);
var direction = new Direction();
var food = new Food();
var obstacle = new Obstacle();

IInputHandler consoleInputHandler = new ConsoleInputHandler();

Random generator = new Random();

Stopwatch foodTimer = new Stopwatch();
Stopwatch obstaclesTimer = new Stopwatch();

foodTimer.Start();
food.Generate(snake.Body, obstacle.Obstacles, wallSize);
drower.Drow(food.Coordinates);
bool isFirstObstaclesGenerated = false;
drower.DrowInfoWindow(new Coordinates(0, 0));

while (true)
{
    int foodDisapearSeconds = foodTimer.Elapsed.Seconds;
    drower.DrowInfoWindowData(Score, Level, Color.Yellow);

    var currentPressedKey = consoleInputHandler.GetPressedKeyboardKey(KeyboardKey.None);
    direction.ChangeCurrentDirection(currentPressedKey);
    snake.ChangeNextHeadPossition(direction);

    if (Level >= GlobalConstants.Snake.ObstaclesAppearLevel)
    {
        int obstacleSeconds = obstaclesTimer.Elapsed.Seconds;
        if (!isFirstObstaclesGenerated)
        {
            obstacle.GenerateFirstCount(snake.Body, food.Coordinates, wallSize);
            drower.Drow(obstacle.Obstacles);

            obstaclesTimer.Start();
            isFirstObstaclesGenerated = true;
        }

        int obstacleAppear = generator.Next(10, 30);

        if (obstacleSeconds == obstacleAppear)
        {
            var lastGeneratedObstacle = obstacle.Generate(snake.Body, food.Coordinates, wallSize);
            drower.Drow(lastGeneratedObstacle);
            obstaclesTimer.Restart();
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
        foodTimer.Restart();
    }
    else if (foodDisapearSeconds == food.DisapearSeconds)
    {
        drower.DrowEmpty(food.Coordinates);
        food.Generate(snake.Body, obstacle.Obstacles, wallSize);
        drower.Drow(food.Coordinates);
        foodTimer.Restart();
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