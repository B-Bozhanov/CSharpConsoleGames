using System.Diagnostics;
using System.Text;

using Common;

using Snake;

using static Common.GlobalConstants;

// Other
int Score = 0;
int Level = 1;

int snakeSpeed = 150; // was 150

int levelUpRow = 0;
int levelUpCol = 0;
bool levelUp = false;
bool levelFive = false;


ConsoleSettings();
DrowInfoWindow();

var snake = new Snake.Snake(GlobalConstants.Snake.StartPossition);
Direction direction = new Direction();
IInputHandler consoleInputHandler = new ConsoleInputHandler();

List<Coordinates> obstacle =
    [
         new Coordinates(5, 20),
         new Coordinates(10, 40),
         new Coordinates(17, 60),
    ];
    // Add snake elements to Queue array;


Random generator = new Random();
int foodDisapear = 0;
int obstacleAppear = 0;
bool IsEat = false;
Coordinates snakeFood = new Coordinates();
Coordinates obstaclesLastElement = new Coordinates();
Stopwatch sw = new Stopwatch();
Stopwatch obstaclesTimer = new Stopwatch();

sw.Start();
obstaclesTimer.Start();

while (true)
{
    TimeSpan timer = sw.Elapsed;
    TimeSpan obst = obstaclesTimer.Elapsed;
    Write($"Score: {Score}", 1, 1, Color.Yellow);
    Write($"Level: {Level}", 2, 1, Color.Yellow);

    var currentPressedKey = consoleInputHandler.GetPressedKeyboardKey(KeyboardKey.None);
    direction.ChangeCurrentDirection(currentPressedKey);
    snake.SetNextHeadPossition(direction.CurrentDirection);

    if (Level >= 5)
    {
        obstaclesTimer.Start();
        if (!levelFive)
        {
            bool isDead = false;
            do
            {
                isDead = false;
                foreach (var item in obstacle)
                {
                    Write("=", item.Row, item.Column, Color.Cyan);
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
                obstaclesLastElement.Row = generator.Next(Field.InfoWindow + 2, Field.ConsoleRow - levelUpRow);
                obstaclesLastElement.Column = generator.Next(levelUpCol, Field.ConsoleCol - levelUpCol);
            } while (snake.Body.Contains(obstaclesLastElement)
              || snakeFood.Row == obstaclesLastElement.Row
              || snakeFood.Column == obstaclesLastElement.Column
              || obstacle.Contains(obstaclesLastElement)
              );
            obstaclesTimer.Restart();
        }
        Write("=", obstaclesLastElement.Row, obstaclesLastElement.Column, Color.Cyan);
        obstacle.Add(obstaclesLastElement);
    }


    if (!levelUp)
    {
        if (snake.NextHeadPossition.Column >= Field.ConsoleCol - levelUpCol) snake.ChangeNextHeadPossition(new Coordinates(snake.NextHeadPossition.Row, levelUpCol));
        if (snake.NextHeadPossition.Column < levelUpCol) snake.ChangeNextHeadPossition(new Coordinates(snake.NextHeadPossition.Row, Field.ConsoleCol - 1 - levelUpCol));
        if (snake.NextHeadPossition.Row >= Field.ConsoleRow + 1 - levelUpRow) snake.ChangeNextHeadPossition(new Coordinates(Field.InfoWindow + 2, snake.NextHeadPossition.Column));
        if (snake.NextHeadPossition.Row < Field.InfoWindow + 2) snake.ChangeNextHeadPossition(new Coordinates(Field.ConsoleRow - levelUpRow, snake.NextHeadPossition.Column));
    }

    if (Level == 10 && !levelUp) // Level Up
    {
        DrowWalls();
        Write("@", snakeFood.Row, snakeFood.Column, Color.Green);
        levelUpCol = 1;
        levelUpRow = 1;
        levelUp = true;
    }
    GameOver(snake.Body, snake.NextHeadPossition, levelUp, obstacle, Level);

    snake.Eat();

    int colorCount = 0;
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
        Write("●", element.Row, element.Column, color);
        colorCount++;
    }
    string direct = string.Empty;
    if (direction.CurrentDirection.Equals(direction.Right)) direct = ">";
    if (direction.CurrentDirection.Equals(direction.Left)) direct = "<";
    if (direction.CurrentDirection.Equals(direction.Down)) direct = "V";
    if (direction.CurrentDirection.Equals(direction.Up)) direct = "^";
    Write(direct, snake.NextHeadPossition.Row, snake.NextHeadPossition.Column, Color.Red);

    foodDisapear = generator.Next(8, 15);
    if (!IsEat)
    {
        do
        {
            snakeFood.Row = generator.Next(Field.InfoWindow + 2, Field.ConsoleRow - levelUpRow);
            snakeFood.Column = generator.Next(levelUpCol, Field.ConsoleCol - levelUpCol);
        } while (snake.Body.Contains(snakeFood) || snakeFood.Row == obstaclesLastElement.Row || snakeFood.Column == obstaclesLastElement.Column);
        IsEat = true;
        Write("@", snakeFood.Row, snakeFood.Column, Color.Green);
    }

    if (snake.NextHeadPossition.Row == snakeFood.Row && snake.NextHeadPossition.Column == snakeFood.Column)
    {
        if (snake.Body.Count % 10 == 0)
        {
            Level++;
            snakeSpeed -= 3;
        }
        snake.Body.Enqueue(snake.NextHeadPossition);
        do
        {
            snakeFood.Row = generator.Next(Field.InfoWindow + 2, Field.ConsoleRow - levelUpRow);
            snakeFood.Column = generator.Next(levelUpCol, Field.ConsoleCol - levelUpCol);
        } while (snake.Body.Contains(snakeFood) || snakeFood.Row == obstaclesLastElement.Row || snakeFood.Column == obstaclesLastElement.Column);
        Write("@", snakeFood.Row, snakeFood.Column, Color.Green);
        snakeSpeed -= 1;
        Score += 1 * Level;
        sw.Restart();
    }
    else if (timer.Seconds == foodDisapear)
    {
        Write(" ", snakeFood.Row, snakeFood.Column);
        sw.Restart();
        IsEat = false;
    }

    Coordinates possitionToDelete = snake.Body.Dequeue();
    Write(" ", possitionToDelete.Row, possitionToDelete.Column);
    Thread.Sleep(snakeSpeed);
}


void GameOver(Queue<Coordinates> snakeElements, Coordinates nextHead, bool levelUp, List<Coordinates> obstacles, int level)
{
    if (levelUp && level >= 10)
    {
        if (nextHead.Row >= Field.ConsoleRow + 1 || nextHead.Row < Field.InfoWindow + 2
            || nextHead.Column >= Field.ConsoleCol - 1 || nextHead.Column < 1)
        {
            Write($"Game over!\n Your Score is: {Score}\n", 1, 1, Color.DarkRed);
            Environment.Exit(0);
        }
    }
    if (level >= 5)
    {
        foreach (var item in obstacles)
        {
            if (snakeElements.Contains(item))
            {
                Write($"Game over!\n Your Score is: {Score}\n", 1, 1, Color.DarkRed);
                Environment.Exit(0);
            }
        }
    }

    if (snake.IsDead())
    {
        Write($"Game over!\n Your Score is: {Score}\n", 1, 1, Color.DarkRed);
        Thread.Sleep(3000);
        Environment.Exit(0);
    }
}

void ConsoleSettings()
{
    Console.CursorVisible = false;
    Console.Title = GlobalConstants.Snake.Name;
    //Console.WindowHeight = ConsoleRow + 2;
    //Console.WindowWidth = ConsoleCol;
    Console.BufferHeight = GlobalConstants.Field.ConsoleRow + 2 ;
    Console.BufferWidth = GlobalConstants.Field.ConsoleCol;
    Console.SetWindowSize(GlobalConstants.Field.ConsoleCol, GlobalConstants.Field.ConsoleRow + 2);
    Console.OutputEncoding = Encoding.UTF8;
}
void DrowInfoWindow()
{
    Console.SetCursorPosition(0, 0);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    string line = "╔";
    line += new string('═', Field.ConsoleCol - 2);
    line += '╗';
    Console.WriteLine(line);

    for (int i = 0; i < Field.InfoWindow; i++)
    {
        string middleLine = "║";
        middleLine += new string(' ', Field.ConsoleCol - 2);
        middleLine += "║";
        Console.WriteLine(middleLine);
    }

    string endLine = "╠";
    endLine += new string('═', Field.ConsoleCol - 2);
    endLine += "╣";
    Console.WriteLine(endLine);
    Console.ResetColor();

}
void DrowWalls()
{
    Console.SetCursorPosition(0, Field.InfoWindow + 2);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    for (int i = 0; i <= Field.Rows - Field.InfoWindow -4 ; i++)
    {
        string middleLine = "║";
        middleLine += new string(' ', Field.ConsoleCol - 2);
        middleLine += "║";
        Console.Write(middleLine);
    }
    string endLine = "╚";
    endLine += new string('═', Field.ConsoleCol - 2);
    endLine += "╝";
    Console.WriteLine(endLine);
    Console.ResetColor();
}
static void Write(string text, int row, int col, Color color = Color.Black)//ConsoleColor color = ConsoleColor.Black)
{
    Console.SetCursorPosition(col, row);
    var consoleColor = Enum.GetValues<ConsoleColor>()?.FirstOrDefault(x => x.ToString() == color.ToString());
    if (consoleColor != null)
    {
        Console.ForegroundColor = (ConsoleColor)consoleColor;
    }
    Console.Write(text);
    Console.ResetColor();
}