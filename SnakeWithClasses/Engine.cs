using System;
using System.Threading;
using System.Diagnostics;

namespace TempSnakeWithClasses
{
    internal class Engine
    {
        public static void Start()
        {
            Field field = new Field(new Coordinates(30, 120));
            Snake snake = new Snake(10);
            snake.SnakeCreation(field.InfoWindow);

            bool wallsApear = false;

            Stopwatch foodDisapear = Stopwatch.StartNew();
            while (true)
            {
                Visualizer.DrowingInfoWindow(field.ConsoleCol, field.InfoWindow);
                Visualizer.DrowingGameInfo(field.Score, field.Level);

                snake.NextPossition();

                if (snake.IsDeath(field.ConsoleRow, field.ConsoleCol, field.InfoWindow, wallsApear))
                {
                    Visualizer.GameOver(field.Score);
                }

                snake.Move();
                Visualizer.DrowingSnake(snake.SnakeElements, snake.Direction, snake.NextHead);

                Coordinates food = field.FoodGenerator(snake.SnakeElements);
                Visualizer.FoodDrowing(food);

                Thread.Sleep(100);
               // Console.Clear();
            }
        }
    }
}
