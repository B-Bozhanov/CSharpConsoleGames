﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Text;


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

int levelUpRow = 0;
int levelUpCol = 0;
bool levelUp = false;
bool levelFive = false;
ConsoleSettings();
DrowingInfoWindow();


Coordinates[] directions =
[
    new Coordinates(0, 1),  // Right
    new Coordinates(0, -1), // Left
    new Coordinates(1, 0),  // Down
    new Coordinates(-1, 0)  // Up
];

int direction = 0;  // Right by default

List<Coordinates> obstacle = new List<Coordinates>()
                {
                    new Coordinates(5, 20),
                    new Coordinates(10, 40),
                    new Coordinates(17, 60),
                };

Queue<Coordinates> snakeElements = new Queue<Coordinates>();    // Add snake elements to Queue array;
for (int i = 1; i <= 4; i++)
{
    snakeElements.Enqueue(new Coordinates(InfoWindow + 2, i));
}

int colorCount = 0;
foreach (var element in snakeElements)
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
int snakeSpeed = 150;

while (true)
{
    TimeSpan timer = sw.Elapsed;
    TimeSpan obst = obstaclesTimer.Elapsed;
    Write($"Score: {Score}", 1, 1, ConsoleColor.Yellow);
    Write($"Level: {Level}", 2, 1, ConsoleColor.Yellow);

    direction = SnakeDirection(direction);
    Coordinates snakeHead = snakeElements.Last();
    Coordinates nextDirection = directions[direction];
    Coordinates nextHead = new Coordinates(snakeHead.Row + nextDirection.Row, snakeHead.Column + nextDirection.Column);

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
                    if (snakeElements.Contains(item))
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
            } while (snakeElements.Contains(obstaclesLastElement)
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
        if (nextHead.Column >= ConsoleCol - levelUpCol) nextHead.Column = levelUpCol;
        if (nextHead.Column < levelUpCol) nextHead.Column = ConsoleCol - 1 - levelUpCol;
        if (nextHead.Row >= ConsoleRow + 1 - levelUpRow) nextHead.Row = InfoWindow + 2;
        if (nextHead.Row < InfoWindow + 2) nextHead.Row = ConsoleRow - levelUpRow;
    }

    if (Level == 10 && !levelUp) // Level Up
    {
        DrowingLevelWalls();
        Write("@", snakeFood.Row, snakeFood.Column, ConsoleColor.Green);
        levelUpCol = 1;
        levelUpRow = 1;
        levelUp = true;
    }
    GameOver(snakeElements, nextHead, levelUp, obstacle, Level);

    snakeElements.Enqueue(nextHead);

    colorCount = 0;
    foreach (var element in snakeElements)
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
    if (direction == 0) direct = ">";
    if (direction == 1) direct = "<";
    if (direction == 2) direct = "V";
    if (direction == 3) direct = "^";
    Write(direct, nextHead.Row, nextHead.Column, ConsoleColor.Red);

    foodDisapear = generator.Next(8, 15);
    if (!IsEat)
    {
        do
        {
            snakeFood.Row = generator.Next(InfoWindow + 2, ConsoleRow - levelUpRow);
            snakeFood.Column = generator.Next(levelUpCol, ConsoleCol - levelUpCol);
        } while (snakeElements.Contains(snakeFood) || snakeFood.Row == obstaclesLastElement.Row || snakeFood.Column == obstaclesLastElement.Column);
        IsEat = true;
        Write("@", snakeFood.Row, snakeFood.Column, ConsoleColor.Green);
    }

    if (nextHead.Row == snakeFood.Row && nextHead.Column == snakeFood.Column)
    {
        if (snakeElements.Count % 10 == 0)
        {
            Level++;
            snakeSpeed -= 3;
        }
        snakeElements.Enqueue(nextHead);
        do
        {
            snakeFood.Row = generator.Next(InfoWindow + 2, ConsoleRow - levelUpRow);
            snakeFood.Column = generator.Next(levelUpCol, ConsoleCol - levelUpCol);
        } while (snakeElements.Contains(snakeFood) || snakeFood.Row == obstaclesLastElement.Row || snakeFood.Column == obstaclesLastElement.Column);
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

    Coordinates possitionToDelete = snakeElements.Dequeue();
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

static int SnakeDirection(int direction)
{
    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.RightArrow)
        {
            if (direction == 1)
            {
                direction = 1;
                return direction;
            }
            direction = 0;
        }
        else if (key.Key == ConsoleKey.LeftArrow)
        {
            if (direction == 0)
            {
                direction = 0;
                return direction;
            }
            direction = 1;
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
            if (direction == 3)
            {
                direction = 3;
                return direction;
            }
            direction = 2;
        }
        else if (key.Key == ConsoleKey.UpArrow)
        {
            if (direction == 2)
            {
                direction = 2;
                return direction;
            }
            direction = 3;
        }
    }
    return direction;
}
void ConsoleSettings()
{
    Console.CursorVisible = false;
    Console.Title = "Snake v1.1";
    //Console.WindowHeight = ConsoleRow + 2;
    //Console.WindowWidth = ConsoleCol;
    //Console.BufferHeight = ConsoleRow + 2;
    //Console.BufferWidth = ConsoleCol;
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
    for (int i = 0; i <= FieldRow; i++)
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