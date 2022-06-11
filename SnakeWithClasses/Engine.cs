using System.Threading;
using System.Diagnostics;
using System;

namespace Snake
{
    internal class Engine
    {
        public static void Start(Field field, int snakeLength)
        {
            Snake snake = new Snake(snakeLength);
            snake.SnakeCreation(field.InfoWindow);
            bool wallsApear = false;

            Stopwatch foodDisapearTimer = new Stopwatch();
            foodDisapearTimer.Start();
            
            field.FoodGenerator(snake.SnakeElements);
            while (true)
            {
                Visualizer.DrowingInfoWindow(field.ConsoleCol, field.InfoWindow);
                Visualizer.DrowingGameInfo(field.Score, field.Level);

                snake.NextPossition();
                if (snake.IsDeath(field.ConsoleRow, field.ConsoleCol, field.InfoWindow, wallsApear, field.Obstacles))
                {
                    Visualizer.GameOver(field.Score);
                    GameMenu menu = new GameMenu(field);
                    Thread.Sleep(3000);
                    Console.Clear();
                    snake = null;
                    field = null;
                    menu.Menu(menu.MainMenu);
                }

                snake.Move();
                Visualizer.DrowingSnake(snake.SnakeElements, snake.Direction, snake.NextHead);

                if (snake.NextHead.Row == field.Food.Row && snake.NextHead.Col == field.Food.Col)
                {
                    snake.Eat(field.Food);
                    field.FoodGenerator(snake.SnakeElements);
                    Visualizer.FoodDrowing(field.Food);
                    field.Score += snake.SnakeElements.Count / 5;
                }
                else if (foodDisapearTimer.ElapsedTicks % 100 == 0) // TODO: Something else with this.
                {
                    Visualizer.WriteOnConsole(" ",field.Food.Row, field.Food.Col);
                    field.FoodGenerator(snake.SnakeElements);
                   // foodDisapearTimer.Restart();
                }

                Visualizer.FoodDrowing(field.Food);
                
                Thread.Sleep(100);
                //Console.Clear();
            }
        }
    }
}
