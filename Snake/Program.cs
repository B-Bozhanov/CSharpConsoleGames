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
bool levelFive = false;

IDrower drower = new ConsoleDrower();
SetConsoleSettings();
drower.DrowInfoWindow(new Coordinates(0, 0));

var snake = new Snake.Snake(GlobalConstants.Snake.StartPossition);
var direction = new Direction();
var food = new Food();

IInputHandler consoleInputHandler = new ConsoleInputHandler();

List<Coordinates> obstacles =
    [
        new Coordinates(5, 20),
        new Coordinates(10, 40),
        new Coordinates(17, 60),
    ];


Random generator = new Random();
int obstacleAppear = 0;

Coordinates obstaclesLastElement = new Coordinates();
Stopwatch foodTimer = new Stopwatch();
Stopwatch obstaclesTimer = new Stopwatch();

foodTimer.Start();
obstaclesTimer.Start();
food.Generate(snake.Body, obstacles, new Coordinates(Field.InfoWindowHeight + 2, Field.FieldRows - wallSize.Row),
                                            new Coordinates(wallSize.Column, Field.FieldColumns - wallSize.Column));
drower.Drow(food.Symbol.ToString(), food.Coordinates, Color.Green);

while (true)
{
    int foodDisapearSeconds = foodTimer.Elapsed.Seconds;
    int obstacleSeconds = foodTimer.Elapsed.Seconds;

    drower.DrowInfoWindow(new Coordinates(0, 0));
    drower.DrowInfoWindowData(Score, Level, Color.Yellow);

    var currentPressedKey = consoleInputHandler.GetPressedKeyboardKey(KeyboardKey.None);
    direction.ChangeCurrentDirection(currentPressedKey);
    snake.ChangeNextHeadPossition(direction);

    if (Level >= 5)
    {
        obstaclesTimer.Start();
        if (!levelFive)
        {
            bool isDead = false;
            do
            {
                isDead = false;
                foreach (var item in obstacles)
                {
                    drower.Drow("=", new Coordinates(item.Row, item.Column), Color.Cyan);
                    if (snake.Body.Contains(item))
                    {
                        isDead = true;
                        break;
                    }
                }
                continue;
            } while (isDead);

            levelFive = true;
        }
        obstacleAppear = generator.Next(5, 10);
        if (obstacleSeconds == obstacleAppear)
        {
            do
            {
                obstaclesLastElement.Row = generator.Next(Field.InfoWindowHeight + 2, Field.FieldRows - wallSize.Row);
                obstaclesLastElement.Column = generator.Next(wallSize.Column, Field.FieldColumns - wallSize.Column);
            } while (snake.Body.Contains(obstaclesLastElement)
              || food.Coordinates.Row == obstaclesLastElement.Row
              || food.Coordinates.Column == obstaclesLastElement.Column
              || obstacles.Contains(obstaclesLastElement)
              );
            obstaclesTimer.Restart();
        }
        drower.Drow("=", new Coordinates(obstaclesLastElement.Row, obstaclesLastElement.Column), Color.Cyan);
        obstacles.Add(obstaclesLastElement);
    }

    if (isGoThroughtWalls)
    {
        snake.GoThroughtWalls(wallSize);
    }

    if (Level == 10)
    {
        drower.DrowWalls(new Coordinates(Field.InfoWindowHeight + 2, 0));
        drower.Drow(food.Symbol, food.Coordinates, Color.Green);
        wallSize.Row = 1;
        wallSize.Column = 1;
        isGoThroughtWalls = false;
    }

    GameOver(isGoThroughtWalls, obstacles, Level);

    var isEat = snake.Eat(food.Coordinates);
    if (isEat)
    {
        if (snake.Body.Count % 10 == 0)
        {
            Level++;
            snakeSpeed -= 5;
        }
        food.Generate(snake.Body, obstacles, new Coordinates(Field.InfoWindowHeight + 2, Field.FieldRows - wallSize.Row), new Coordinates(wallSize.Column, Field.FieldColumns - wallSize.Column));
        snakeSpeed -= 1;
        Score += 1 * Level;
        foodTimer.Restart();
    }
    else if (foodDisapearSeconds == food.DisapearSeconds)
    {
        drower.Drow(food.Coordinates);
        food.Generate(snake.Body, obstacles, new Coordinates(Field.InfoWindowHeight + 2, Field.FieldRows - wallSize.Row),
                                             new Coordinates(wallSize.Column, Field.FieldColumns - wallSize.Column));
        drower.Drow(food.Symbol, food.Coordinates, Color.Green);
        foodTimer.Restart();
    }
    snake.Move();


    drower.Drow(food.Symbol, food.Coordinates, Color.Green);
    drower.Drow(snake.Body);
    drower.Drow(snake.TailPossition);
    Thread.Sleep(snakeSpeed);
}

void GameOver(bool isGoThroughtWalls, List<Coordinates> obstacles, int level)
{
    var isGameOver = false;
    if (isGoThroughtWalls && level >= 10)
    {
        if (snake.IsOnField())
        {
            isGameOver = true;
        }
    }

    if (level >= 5)
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
        drower.DrowGameOver(Score, Level, Color.Red);
        Thread.Sleep(10000);
        Environment.Exit(0);
    }
}

void SetConsoleSettings()
{
    Console.CursorVisible = false;
    Console.Title = GlobalConstants.Snake.Name;
    Console.SetWindowSize(Field.FieldColumns, Field.FieldRows + 1);
    Console.SetBufferSize(Field.FieldColumns, Field.FieldRows + 1);
    Console.OutputEncoding = Encoding.UTF8;
}