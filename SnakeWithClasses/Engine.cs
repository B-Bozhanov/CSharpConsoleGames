using System.Threading;
using System.Diagnostics;
using System;

namespace Snake
{
    internal class Engine : Field
    {
        private Snake snake;
        private Obstacles obstacles;
        private Food food;
        private Stopwatch timer;
        private Random generator;
        private readonly int consoleRow;
        private readonly int consoleCol;
        private readonly int infoWindow;
        private bool wallsApear;


       
        public Engine(int consoleRow, int consoleCol, int infoWindow, Snake snake)
            : base(consoleRow, consoleCol, infoWindow)
        {
            this.food = new Food();
            this.timer = new Stopwatch();
            this.generator = new Random();
            this.snake = snake;
            this.wallsApear = false;
        }


        internal void Start()
        {
            this.obstacles = new Obstacles(consoleRow, consoleCol, InfoWindow, snake);
            Visualizer.DrowingInfoWindow(this.consoleCol, this.infoWindow);
           
            while (true)
            {
               


                this.snake.NextPossition();
                if (snake.IsDeath(this.consoleRow, this.consoleCol, wallsApear, obstacles.ObstaclesList))
                {
                    //Visualizer.GameOver(field.Score);
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
