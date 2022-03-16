using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Text;

namespace Snake.v1._1
{
    struct Coordinates
    {
        public int row;
        public int col;
        public Coordinates(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    class Program
    {
        // Console Setings
        static int FieldRow = 18;
        static int FieldCol = 65;
        // TODO If Info is less than 2:
        static int InfoWindow = FieldRow / 8;
        static int ConsoleRow = 1 + InfoWindow + 1 + FieldRow + 1;   // One is borders
        static int ConsoleCol = 1 + FieldCol + 1;
        // Other
        static int Score = 0;
        static int Level = 1;
        static void Main(string[] args)
        {
            int levelUpRow = 0;
            int levelUpCol = 0;
            bool levelUp = false;
            bool levelFive = false;
            ConsoleSettings();
            DrowingInfoWindow();


            Coordinates[] directions = new Coordinates[]
            {
                new Coordinates(0, 1),  // Right
                new Coordinates(0, -1), // Left
                new Coordinates(1, 0),  // Down
                new Coordinates(-1, 0)  // Up
            };
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
                Write("●", element.row, element.col, color);
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
                Coordinates nextHead = new Coordinates(snakeHead.row + nextDirection.row, snakeHead.col + nextDirection.col);

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
                                Write("=", item.row, item.col, ConsoleColor.Cyan);
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
                            obstaclesLastElement.row = generator.Next(InfoWindow + 2, ConsoleRow - levelUpRow);
                            obstaclesLastElement.col = generator.Next(levelUpCol, ConsoleCol - levelUpCol);
                        } while (snakeElements.Contains(obstaclesLastElement)
                          || snakeFood.row == obstaclesLastElement.row
                          || snakeFood.col == obstaclesLastElement.col
                          || obstacle.Contains(obstaclesLastElement)
                          );
                        obstaclesTimer.Restart();
                    }
                    Write("=", obstaclesLastElement.row, obstaclesLastElement.col, ConsoleColor.Cyan);
                    obstacle.Add(obstaclesLastElement);
                }


                if (!levelUp)
                {
                    if (nextHead.col >= ConsoleCol - levelUpCol) nextHead.col = levelUpCol;
                    if (nextHead.col < levelUpCol) nextHead.col = ConsoleCol - 1 - levelUpCol;
                    if (nextHead.row >= ConsoleRow + 1 - levelUpRow) nextHead.row = InfoWindow + 2;
                    if (nextHead.row < InfoWindow + 2) nextHead.row = ConsoleRow - levelUpRow;
                }

                if (Level == 10 && !levelUp) // Level Up
                {
                    DrowingLevelWalls();
                    Write("@", snakeFood.row, snakeFood.col, ConsoleColor.Green);
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
                    Write("●", element.row, element.col, color);
                    colorCount++;
                }
                string direct = string.Empty;
                if (direction == 0) direct = ">";
                if (direction == 1) direct = "<";
                if (direction == 2) direct = "V";
                if (direction == 3) direct = "^";
                Write(direct, nextHead.row, nextHead.col, ConsoleColor.Red);

                foodDisapear = generator.Next(8, 15);
                if (!IsEat)
                {
                    do
                    {
                        snakeFood.row = generator.Next(InfoWindow + 2, ConsoleRow - levelUpRow);
                        snakeFood.col = generator.Next(levelUpCol, ConsoleCol - levelUpCol);
                    } while (snakeElements.Contains(snakeFood) || snakeFood.row == obstaclesLastElement.row || snakeFood.col == obstaclesLastElement.col);
                    IsEat = true;
                    Write("@", snakeFood.row, snakeFood.col, ConsoleColor.Green);
                }

                if (nextHead.row == snakeFood.row && nextHead.col == snakeFood.col)
                {
                    if (snakeElements.Count % 10 == 0)
                    {
                        Level++;
                        snakeSpeed -= 3;
                    }
                    snakeElements.Enqueue(nextHead);
                    do
                    {
                        snakeFood.row = generator.Next(InfoWindow + 2, ConsoleRow - levelUpRow);
                        snakeFood.col = generator.Next(levelUpCol, ConsoleCol - levelUpCol);
                    } while (snakeElements.Contains(snakeFood) || snakeFood.row == obstaclesLastElement.row || snakeFood.col == obstaclesLastElement.col);
                    Write("@", snakeFood.row, snakeFood.col, ConsoleColor.Green);
                    snakeSpeed -= 1;
                    Score += 1 * Level;
                    sw.Restart();
                }
                else if (timer.Seconds == foodDisapear)
                {
                    Write(" ", snakeFood.row, snakeFood.col);
                    sw.Restart();
                    IsEat = false;
                }

                Coordinates possitionToDelete = snakeElements.Dequeue();
                Write(" ", possitionToDelete.row, possitionToDelete.col);
                Thread.Sleep(snakeSpeed);
            }
        }

        static void GameOver(Queue<Coordinates> snakeElements, Coordinates nextHead, bool levelUp, List<Coordinates> obstacles, int level)
        {
            if (levelUp && level >= 10)
            {
                if (nextHead.row >= ConsoleRow + 1 || nextHead.row < InfoWindow + 2
                    || nextHead.col >= ConsoleCol - 1 || nextHead.col < 1)
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
                if (nextHead.row == element.row && nextHead.col == element.col)
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
        static void ConsoleSettings()
        {
            Console.CursorVisible = false;
            Console.Title = "Snake v1.1";
            Console.WindowHeight = ConsoleRow + 2;
            Console.WindowWidth = ConsoleCol;
            Console.BufferHeight = ConsoleRow + 2;
            Console.BufferWidth = ConsoleCol;
            Console.OutputEncoding = Encoding.UTF8;
        }
        static void DrowingInfoWindow()
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
        static void DrowingLevelWalls()
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
    }
}
