using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Text;
using Snake;
using Snake.Helpers;


// Console Setings
int FieldRow = 30;
int FieldCol = 118;
// TODO If Info is less than 2:
int InfoWindow = FieldRow / 8;
int ConsoleRow = 1 + InfoWindow + 1 + FieldRow + 1;   // One is borders
int ConsoleCol = 1 + FieldCol + 1;
// Other
int Score = 0;
int Level = 1;

int snakeSpeed = 150; // was 150
int snakeStartPossition = InfoWindow + 2;

int levelUpRow = 0;
int levelUpCol = 0;
bool levelUp = false;
bool levelFive = false;


ConsoleSettings();
DrowingInfoWindow();

var snake = new Snake.Snake(snakeStartPossition);
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
    Write($"Score: {Score}", 1, 1, ConsoleColor.Yellow);
    Write($"Level: {Level}", 2, 1, ConsoleColor.Yellow);

    var currentPressedKey = consoleInputHandler.GetPressedKey(KeyboardKey.None);
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
                    Write("=", item.Row, item.Column, ConsoleColor.Cyan);
                    if (snake.SnakeElements.Contains(item))
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
                obstaclesLastElement.Row = generator.Next(InfoWindow + 2, ConsoleRow - levelUpRow);
                obstaclesLastElement.Column = generator.Next(levelUpCol, ConsoleCol - levelUpCol);
            } while (snake.SnakeElements.Contains(obstaclesLastElement)
              || snakeFood.Row == obstaclesLastElement.Row
              || snakeFood.Column == obstaclesLastElement.Column
              || obstacle.Contains(obstaclesLastElement)
              );
            obstaclesTimer.Restart();
        }
        Write("=", obstaclesLastElement.Row, obstaclesLastElement.Column, ConsoleColor.Cyan);
        obstacle.Add(obstaclesLastElement);
    }


    if (!levelUp)
    {
        //if (snake.NextHeadPossition.Column >= ConsoleCol - levelUpCol) { snake.NextHeadPossition.Column = levelUpCol; }
        //if (snake.NextHeadPossition.Column < levelUpCol) snake.NextHeadPossition.Column = ConsoleCol - 1 - levelUpCol;
        //if (snake.NextHeadPossition.Row >= ConsoleRow + 1 - levelUpRow) nextHead.Row = InfoWindow + 2;
        //if (snake.NextHeadPossition.Row < InfoWindow + 2) nextHead.Row = ConsoleRow - levelUpRow;
    }

    if (Level == 10 && !levelUp) // Level Up
    {
        DrowingLevelWalls();
        Write("@", snakeFood.Row, snakeFood.Column, ConsoleColor.Green);
        levelUpCol = 1;
        levelUpRow = 1;
        levelUp = true;
    }
    GameOver(snake.SnakeElements, snake.NextHeadPossition, levelUp, obstacle, Level);

    snake.Eat();

    int colorCount = 0;
    foreach (var element in snake.SnakeElements)
    {
        ConsoleColor color;
        if (colorCount % 2 == 0)
        {
            color = ConsoleColor.DarkYellow;
        }
        else
        {
            color = ConsoleColor.DarkGreen;
        }
        Write("●", element.Row, element.Column, color);
        colorCount++;
    }
    string direct = string.Empty;
    if (direction.CurrentDirection.Equals(direction.Right)) direct = ">";
    if (direction.CurrentDirection.Equals(direction.Left)) direct = "<";
    if (direction.CurrentDirection.Equals(direction.Down)) direct = "V";
    if (direction.CurrentDirection.Equals(direction.Up)) direct = "^";
    Write(direct, snake.NextHeadPossition.Row, snake.NextHeadPossition.Column, ConsoleColor.Red);

    foodDisapear = generator.Next(8, 15);
    if (!IsEat)
    {
        do
        {
            snakeFood.Row = generator.Next(InfoWindow + 2, ConsoleRow - levelUpRow);
            snakeFood.Column = generator.Next(levelUpCol, ConsoleCol - levelUpCol);
        } while (snake.SnakeElements.Contains(snakeFood) || snakeFood.Row == obstaclesLastElement.Row || snakeFood.Column == obstaclesLastElement.Column);
        IsEat = true;
        Write("@", snakeFood.Row, snakeFood.Column, ConsoleColor.Green);
    }

    if (snake.NextHeadPossition.Row == snakeFood.Row && snake.NextHeadPossition.Column == snakeFood.Column)
    {
        if (snake.SnakeElements.Count % 10 == 0)
        {
            Level++;
            snakeSpeed -= 3;
        }
        snake.SnakeElements.Enqueue(snake.NextHeadPossition);
        do
        {
            snakeFood.Row = generator.Next(InfoWindow + 2, ConsoleRow - levelUpRow);
            snakeFood.Column = generator.Next(levelUpCol, ConsoleCol - levelUpCol);
        } while (snake.SnakeElements.Contains(snakeFood) || snakeFood.Row == obstaclesLastElement.Row || snakeFood.Column == obstaclesLastElement.Column);
        Write("@", snakeFood.Row, snakeFood.Column, ConsoleColor.Green);
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

    Coordinates possitionToDelete = snake.SnakeElements.Dequeue();
    Write(" ", possitionToDelete.Row, possitionToDelete.Column);
    Thread.Sleep(snakeSpeed);
}


void GameOver(Queue<Coordinates> snakeElements, Coordinates nextHead, bool levelUp, List<Coordinates> obstacles, int level)
{
    if (levelUp && level >= 10)
    {
        if (nextHead.Row >= ConsoleRow + 1 || nextHead.Row < InfoWindow + 2
            || nextHead.Column >= ConsoleCol - 1 || nextHead.Column < 1)
        {
            Write($"Game over!\n Your Score is: {Score}\n", 1, 1, ConsoleColor.DarkRed);
            Environment.Exit(0);
        }
    }
    if (level >= 5)
    {
        foreach (var item in obstacles)
        {
            if (snakeElements.Contains(item))
            {
                Write($"Game over!\n Your Score is: {Score}\n", 1, 1, ConsoleColor.DarkRed);
                Environment.Exit(0);
            }
        }
    }
    foreach (var element in snakeElements)
    {
        if (nextHead.Row == element.Row && nextHead.Column == element.Column)
        {
            Write($"Game over!\n Your Score is: {Score}\n", 1, 1, ConsoleColor.DarkRed);
            Environment.Exit(0);
        }
    }
}

void ConsoleSettings()
{
    Console.CursorVisible = false;
    Console.Title = "Snake v1.0";
    //Console.WindowHeight = ConsoleRow + 2;
    //Console.WindowWidth = ConsoleCol;
    Console.BufferHeight = ConsoleRow ;
    Console.BufferWidth = ConsoleCol;
    Console.SetWindowSize(ConsoleCol, ConsoleRow + 2);
    Console.OutputEncoding = Encoding.UTF8;
}
void DrowingInfoWindow()
{
    Console.SetCursorPosition(0, 0);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    string line = "╔";
    line += new string('═', ConsoleCol - 2);
    line += '╗';
    Console.WriteLine(line);

    for (int i = 0; i < InfoWindow; i++)
    {
        string middleLine = "║";
        middleLine += new string(' ', ConsoleCol - 2);
        middleLine += "║";
        Console.WriteLine(middleLine);
    }

    string endLine = "╠";
    endLine += new string('═', ConsoleCol - 2);
    endLine += "╣";
    Console.WriteLine(endLine);
    Console.ResetColor();

}
void DrowingLevelWalls()
{
    Console.SetCursorPosition(0, InfoWindow + 2);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    for (int i = 0; i <= FieldRow - InfoWindow -4 ; i++)
    {
        string middleLine = "║";
        middleLine += new string(' ', ConsoleCol - 2);
        middleLine += "║";
        Console.Write(middleLine);
    }
    string endLine = "╚";
    endLine += new string('═', ConsoleCol - 2);
    endLine += "╝";
    Console.WriteLine(endLine);
    Console.ResetColor();
}
static void Write(string text, int row, int col, ConsoleColor color = ConsoleColor.Black)
{
    Console.SetCursorPosition(col, row);
    Console.ForegroundColor = color;
    Console.Write(text);
    Console.ResetColor();
}