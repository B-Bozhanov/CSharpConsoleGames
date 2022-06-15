using System.Threading;
using System.Diagnostics;
using System;

namespace Snake
{
    internal class Engine : Food
    {
        public static void Start(Field field, int snakeLength)
        {
            Snake snake = new Snake(snakeLength);
            Obstacles obstacles = new Obstacles();
            Food food = new Food();
            Stopwatch foodDisapearTimer = new Stopwatch();

            bool wallsApear = false;
            foodDisapearTimer.Start();

            obstacles.Generate(food.FoodCords);
            Visualizer.FoodDrowing(food.Symbol, food.FoodCords);
            while (true)
            {
                //Visualizer.DrowingInfoWindow(ConsoleCol, InfoWindow);
                //Visualizer.DrowingGameInfo(field.Score, field.Level);

                snake.NextPossition();
                //if (snake.IsDeath(ConsoleRow, ConsoleCol, InfoWindow, wallsApear, obstacles.ObstaclesList))
                //{
                //    Visualizer.GameOver(field.Score);
                //    var menu = new GameMenu(field.ConsoleRow, field.ConsoleCol);
                //    Thread.Sleep(3000);
                //    Console.Clear();
                //    snake = null;
                //    field = null;
                //    menu.StartMainMenu();
                //}

                //snake.Move();
                //Visualizer.DrowingSnake(snake.SnakeElements, snake.Direction, snake.NextHead);

                //if (snake.NextHead.Row == field.Food.Row && snake.NextHead.Col == field.Food.Col)
                //{
                //    snake.Eat(field.Food);
                //    food.FoodGenerator(snake.SnakeElements);
                //    Visualizer.FoodDrowing(food.Symbol, field.Food);
                //    field.Score += snake.SnakeElements.Count / 5;
                //}
                //else if (foodDisapearTimer.ElapsedTicks % 100 == 0) // TODO: Something else with this.
                //{
                //    Visualizer.WriteOnConsole(" ", field.Food.Row, field.Food.Col);
                //    food.FoodGenerator(snake.SnakeElements);
                //    // foodDisapearTimer.Restart();
                //}

                //Visualizer.FoodDrowing(food.Symbol, field.Food);

                Thread.Sleep(100);
            }
        }
    }
}
