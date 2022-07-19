using System.Threading;
using System.Diagnostics;
using System;

namespace Snake
{
    internal class Engine
    {
        private Snake snake;
        private bool wallsApear;

        public Engine(Snake snake)
        {
            this.snake = snake;
            this.snake = snake;
            this.wallsApear = false;
        }


        internal void Start()
        {
            Visualizer.DrowingInfoWindow(Field.ConsoleCol, Field.InfoWindow);
           
            while (true)
            {
                this.snake.NextPossition();
                if (snake.IsDeath(Field.ConsoleRow, Field.ConsoleCol))
                {
                    //Visualizer.GameOver(field.Score);
                    //wellcome.Wellcome(false);
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }

                snake.Move();
                Visualizer.DrowingSnake(snake.SnakeElements, snake.Direction, snake.NextHead);

                //if (snake.NextHead.Row == this.food.Row && snake.NextHead.Col == field.Food.Col)
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
