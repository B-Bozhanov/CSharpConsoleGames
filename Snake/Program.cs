using System.Diagnostics;
using System.Text;

using Common;

using Snake;
using Snake.Drowers;

using static Common.GlobalConstants;
//TODO: If level is five obstacle is appear suddenly.
// Other
int Score = 0;
int Level = 1;

int snakeSpeed = 150; // was 150

int wallsAppearRow = 0;
int wallsAppearCol = 0;
var wallSize = new Coordinates();
bool isWallsAppear = false;
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
int foodDisapearSeconds = 0;
int obstacleAppear = 0;

Coordinates obstaclesLastElement = new Coordinates();
Stopwatch sw = new Stopwatch();
Stopwatch obstaclesTimer = new Stopwatch();

sw.Start();
obstaclesTimer.Start();
food.Generate(snake.Body, obstacles, new Coordinates(Field.InfoWindowHeight + 2, Field.FieldRows - wallsAppearRow),
                                            new Coordinates(wallsAppearCol, Field.FieldColumns - wallsAppearCol));
drower.Drow(food.Symbol.ToString(), food.Coordinates, Color.Green);
while (true)
{
    drower.DrowInfoWindow(new Coordinates(0, 0));
    TimeSpan timer = sw.Elapsed;
    TimeSpan obst = obstaclesTimer.Elapsed;
    drower.Drow($"Score: {Score}", new Coordinates(1, 1), Color.Yellow);
    drower.Drow($"Level: {Level}", new Coordinates(2, 1), Color.Yellow);

    var currentPressedKey = consoleInputHandler.GetPressedKeyboardKey(KeyboardKey.None);
    direction.ChangeCurrentDirection(currentPressedKey);

    snake.Move(direction.CurrentDirection);
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
        if (obst.Seconds == obstacleAppear)
        {
            do
            {
                obstaclesLastElement.Row = generator.Next(Field.InfoWindowHeight + 2, Field.FieldRows - wallsAppearRow);
                obstaclesLastElement.Column = generator.Next(wallsAppearCol, Field.FieldColumns - wallsAppearCol);
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


    if (!isWallsAppear)
    {
        snake.GoThroughtWalls(wallSize);
    }

    if (Level == 10 && !isWallsAppear) // Level Up
    {
        //TODO: Increese Console columns and Rows by 1 for borders;
        drower.DrowWalls(new Coordinates(Field.InfoWindowHeight + 2, 0));
        drower.Drow(food.Symbol, food.Coordinates, Color.Green);
        wallSize.Row = 1;
        wallSize.Column = 1;
        isWallsAppear = true;
    }

    GameOver(isWallsAppear, obstacles, Level);
    snake.Body.Enqueue(snake.NextHeadPossition);

    int colorCount = 0;
    string direct = string.Empty;
    foreach (var element in snake.Body)
    {
        Color color;
        if (colorCount % 2 == 0)
        {
            color = Color.DarkYellow;
        }
        else
        {
            color = Color.DarkGreen;
        }
        drower.Drow("●", new Coordinates(element.Row, element.Column), color);
        if (element.Equals(snake.CurrentHeadPossition))
        {
            if (direction.CurrentDirection.Equals(direction.Right)) direct = ">";
            if (direction.CurrentDirection.Equals(direction.Left)) direct = "<";
            if (direction.CurrentDirection.Equals(direction.Down)) direct = "V";
            if (direction.CurrentDirection.Equals(direction.Up)) direct = "^";
            drower.Drow(direct, new Coordinates(snake.NextHeadPossition.Row, snake.NextHeadPossition.Column), Color.Red);
        }
        colorCount++;
    }

    foodDisapearSeconds = generator.Next(8, 20);

    var isEat = snake.Eat(food.Coordinates);
    if (isEat)
    {
        if (snake.Body.Count % 10 == 0)
        {
            Level++;
            snakeSpeed -= 5;
        }

        food.Generate(snake.Body, obstacles, new Coordinates(Field.InfoWindowHeight + 2, Field.FieldRows - wallsAppearRow), new Coordinates(wallsAppearCol, Field.FieldColumns - wallsAppearCol));
        
        drower.Drow(food.Symbol, food.Coordinates, Color.Green);
        snakeSpeed -= 1;
        Score += 1 * Level;
        sw.Restart();
    }
    else if (timer.Seconds == foodDisapearSeconds)
    {
        drower.Drow(food.Coordinates);
        food.Generate(snake.Body, obstacles, new Coordinates(Field.InfoWindowHeight + 2, Field.FieldRows - wallsAppearRow),
                                             new Coordinates(wallsAppearCol, Field.FieldColumns - wallsAppearCol));
        drower.Drow(food.Symbol, food.Coordinates, Color.Green);
        sw.Restart();
    }
    Coordinates possitionToDeletee = snake.Body.Dequeue();
    drower.Drow(possitionToDeletee);

    Thread.Sleep(snakeSpeed);
}

void GameOver(bool levelUp, List<Coordinates> obstacles, int level)
{
    if (levelUp && level >= 10)
    {
        if (snake.IsOnField())
        {
            drower.Drow($"Game over!\n Your Score is: {Score}\n", new Coordinates(1, 1), Color.DarkRed);
            drower.Drow($"Game over!\n Your Level is: {Level}\n", new Coordinates(1, 1), Color.DarkRed);
            Environment.Exit(0);
        }
    }

    if (level >= 5)
    {
        if (snake.IsCrashToObstacle(obstacles))
        {
            drower.Drow($"Game over!\n Your Score is: {Score}\n", new Coordinates(1, 1), Color.DarkRed);
            drower.Drow($"Game over!\n Your Level is: {Level}\n", new Coordinates(1, 1), Color.DarkRed);
            Environment.Exit(0);
        }
    }

    if (snake.IsEatMySelf())
    {
        drower.Drow($"Game over!{Environment.NewLine} Your Score is: {Score}{Environment.NewLine}", new Coordinates(1, 1), Color.DarkRed);
        drower.Drow($"Game over!{Environment.NewLine} Your Level is: {Level}{Environment.NewLine}", new Coordinates(1, 1), Color.DarkRed);
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